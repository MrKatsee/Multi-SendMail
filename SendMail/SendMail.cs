using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.IO;
using System.Reflection;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;

namespace SendMail
{
    //해야되는 것
    //files 경로가 포함되도록 빌드
    //인증? https://youtu.be/9qt2EHzYv9Q
    //로그 간소화
    //인증을 별도 UI로 받아서 config에 저장

    public partial class SendMail : Form
    {
        private string currentCSVFile = string.Empty;
        private string currentFilePath = string.Empty;
        private string secretFilePath { get { return currentFilePath + "\\" + "files_s"; } }

        public SendMail()
        {
            InitializeComponent();

            Init_SendMailForm();
        }

        private void Init_SendMailForm()
        {
            Config.Init();

            subjectTextBox.Text = Config.Read(ConfigKey.Subject);
            bodyTextBox.Text = Config.Read(ConfigKey.Body).Replace("\\n", Environment.NewLine);
            txt_fromAddress.Text = Config.Read(ConfigKey.FromAddress);
            txt_password.Text = Config.Read(ConfigKey.Password);

            currentCSVFile = Config.Read(ConfigKey.CsvPath);
            currentFilePath = Config.Read(ConfigKey.FilePath);

            txt_csvPath.Text = currentCSVFile;
            txt_filePath.Text = currentFilePath;

            if (string.IsNullOrEmpty(currentCSVFile) == false) {
                dataGridView.DataSource = MailDataManager.CSVParse(currentCSVFile, isFirstLineHeaderCheckBox.Checked);
            }
        }

        private void OnClick_CsvImport(object sender, EventArgs e)
        {
            //dialog 창을 염
            if (openCsvFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentCSVFile = openCsvFileDialog.FileName;

                //textBox에 파일 경로 입력
                txt_csvPath.Text = currentCSVFile;

                //table에 csv 데이터 기입
                dataGridView.DataSource = MailDataManager.CSVParse(currentCSVFile, isFirstLineHeaderCheckBox.Checked);

                //현재 파일 경로가 없다면, 기본값을 넣어준다
                if (string.IsNullOrEmpty(currentFilePath)) {
                    currentFilePath = Path.GetDirectoryName(currentCSVFile) + "\\files";

                    txt_filePath.Text = currentFilePath;

                    if (Directory.Exists(currentFilePath) == false) {
                        //해당 경로가 없다면, 생성
                        Directory.CreateDirectory(currentFilePath);
                    }

                    Config.Write(ConfigKey.FilePath, currentFilePath, false);
                }

                //저장
                Config.Write(ConfigKey.CsvPath, currentCSVFile);
            }
        }
        private void OnClick_FilePathImport(object sender, EventArgs e) {
            //dialog 창을 염
            if (openFilePathDialog.ShowDialog() == DialogResult.OK) {
                currentFilePath = openFilePathDialog.SelectedPath;

                //textBox에 파일 경로 입력
                txt_filePath.Text = currentFilePath;

                //저장
                Config.Write(ConfigKey.FilePath, currentFilePath);
            }
        }

        private void IsFirstLineHeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //현재 파일 경로가 비어있지 않다면, 테이블을 갱신함
            if (currentCSVFile != string.Empty)
                dataGridView.DataSource = MailDataManager.CSVParse(currentCSVFile, isFirstLineHeaderCheckBox.Checked);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            Config.Write(ConfigKey.Subject, subjectTextBox.Text, false);
            Config.Write(ConfigKey.Body, bodyTextBox.Text, false);
            Config.Write(ConfigKey.FromAddress, txt_fromAddress.Text, false);
            Config.Write(ConfigKey.Password, txt_password.Text, false);

            Config.Save();

            Log.Clear();

            if (Directory.Exists(secretFilePath) == false) {
                Directory.CreateDirectory(secretFilePath);
            }

            foreach (var data in MailDataManager.datas) {
                PdfDocument doc = PdfReader.Open(currentFilePath + "\\" + data.file, PdfDocumentOpenMode.Modify);
                PdfSecuritySettings settings = doc.SecuritySettings;

                settings.UserPassword = data.password;
                settings.OwnerPassword = "rohmmis";

                settings.PermitAccessibilityExtractContent = false;
                settings.PermitAnnotations = false;
                settings.PermitAssembleDocument = false;
                settings.PermitExtractContent = false;
                settings.PermitFormsFill = false;
                settings.PermitFullQualityPrint = false;
                settings.PermitModifyDocument = false;
                settings.PermitPrint = false;

                doc.Save(secretFilePath + "\\" + data.file);
            }

            Log.Logs += string.Format("{0}{1}", "== 발송 시작 ==", Environment.NewLine);
            
            if (string.IsNullOrEmpty(currentCSVFile) || string.IsNullOrEmpty(currentFilePath)) {
                Log.Logs += "Error: csv 파일 혹은 파일 경로 불러오기를 하지 않으셨습니다";
                return;
            }

            Mail mail = new Mail(txt_fromAddress.Text, txt_password.Text);

            foreach (var data in MailDataManager.datas) {
                Log.Logs += mail.Send(data.address, subjectTextBox.Text, bodyTextBox.Text, secretFilePath + "\\" + data.file);
            }

            Log.Logs += string.Format("{0}{1}{2}", Environment.NewLine, "== 발송 완료 ==", Environment.NewLine);

            Log.OnSendComplete();
        }
    }

    public class Mail
    {
        private string fromAddress;
        private string password;

        public Mail(string fromAddress, string password)
        {
            this.fromAddress = fromAddress;
            this.password = password;
        }

        public string Send(string toAddress, string subject, string body, string file) {
            SmtpClient smtp = null;
            MailMessage msg = null;

            try {
                smtp = new SmtpClient {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress, password),
                    Timeout = 20000
                };
                //메세지
                msg = new MailMessage(fromAddress, toAddress) {
                    Subject = subject,
                    Body = body
                };
                //첨부 파일
                Attachment att = new Attachment(file);
                msg.Attachments.Add(att);

                //발송
                smtp.Send(msg);

                return toAddress + " : 전송 완료";
            } catch (Exception e) {
                return " : 전송 실패 (" + e + ")";
            }
        }
    }

    public class MailData
    {
        public string address;
        public string file; 
        public string password;
    }

    public class MailDataManager
    {
        private static char[] delimiters = { ',', ';' };                                //구분자
        public static string[] headers { get; private set; } = { "address", "file" };   //헤더

        public static List<MailData> datas { get; private set; }

        public static DataTable CSVParse(string file, bool isFirstLineHeader = false)
        {
            DataTable dt = new DataTable();

            datas = new List<MailData>();

            foreach (var header in headers)
            {
                dt.Columns.Add(new DataColumn(header));
            }

            string[] lines = System.IO.File.ReadAllLines(file);
            string[] splitedLines;

            //첫 줄이 헤더라면, 두 번째 줄부터 시작
            int i = isFirstLineHeader ? 1 : 0;

            for (; i < lines.Length; i++)
            {
                DataRow dr = dt.NewRow();

                //구분자로 읽어들인 줄을 나누고, 각 열에 집어넣음
                splitedLines = lines[i].Split(delimiters);
                for (int k = 0; k < headers.Length; k++)
                {
                    dr[k] = splitedLines[k];
                }
                dt.Rows.Add(dr);

                //각 행을 데이터화 하여 저장
                MailData data = new MailData()
                {
                    address = splitedLines[0],
                    file = splitedLines[1],
                    password = splitedLines[2]
                };
                datas.Add(data);
            }

            return dt;
        }
    }

    public enum ConfigKey {
        Host, Port, Subject, Body, ClientID, SecretID, CsvPath, FilePath, FromAddress, Password
    }
    public static class Config {

        private const string iniFile = "Setting.ini";
        private static string iniPath { get { return Directory.GetCurrentDirectory() + "\\" + iniFile; } }

        private static Dictionary<ConfigKey, string> _iniData;


        public static void Init() {
            _iniData = new Dictionary<ConfigKey, string>();

            if (File.Exists(iniPath)) {
                //파일이 있는 경우, 데이터를 읽어옴
                using (var reader = new StreamReader(iniPath)) {
                    string line = string.Empty;

                    while ((line = reader.ReadLine()) != null) {
                        var words = line.Split('=');

                        Write(GetKey(words[0]), words[1], false);
                    }
                }
                Save();
            } else {
                //파일이 없는 경우, 초기화
                Write(ConfigKey.Host, "smtp.gmail.com", false);
                Write(ConfigKey.Port, "587", false);
                Write(ConfigKey.Subject, "", false);
                Write(ConfigKey.Body, "", false);
                Write(ConfigKey.ClientID, "", false);
                Write(ConfigKey.SecretID, "", false); 
                Write(ConfigKey.CsvPath, "", false);
                Write(ConfigKey.FilePath, "", false);
                Write(ConfigKey.FromAddress, "", false);
                Write(ConfigKey.Password, "", false);

                Save();
            }
        }

        public static void Write(ConfigKey key, string value, bool immediateSave = true) {
            value = value.Replace(Environment.NewLine, "\\n");

            if (_iniData.ContainsKey(key)) {
                _iniData[key] = value;
            } else {
                _iniData.Add(key, value);
            }

            if (immediateSave) { Save(); }
        }

        public static string Read(ConfigKey key) {
            if (_iniData.ContainsKey(key)) {
                return _iniData[key];
            } else {
                return null;
            }
        }

        public static void Save() {
            using (var writer = new StreamWriter(iniPath)) {
                foreach (ConfigKey key in _iniData.Keys) {
                    writer.WriteLine(string.Format("{0}={1}", GetKey(key), _iniData[key]));
                }
            }
        }

        private static string GetKey(ConfigKey key) {
            switch (key) {
                case ConfigKey.Host: return "HOST";
                case ConfigKey.Port: return "PORT";
                case ConfigKey.Subject: return "SUBJECT";
                case ConfigKey.Body: return "BODY";
                case ConfigKey.ClientID: return "CLIENTID";
                case ConfigKey.SecretID: return "SECRETID";
                case ConfigKey.CsvPath: return "CSVPATH";
                case ConfigKey.FilePath: return "FILEPATH";
                case ConfigKey.FromAddress: return "FROM";
                case ConfigKey.Password: return "PASSWORD";

                default: throw new NotImplementedException();
            }
        }
        private static ConfigKey GetKey(string key) {
            switch (key) {
                case "HOST": return ConfigKey.Host;
                case "PORT": return ConfigKey.Port;
                case "SUBJECT": return ConfigKey.Subject;
                case "BODY": return ConfigKey.Body;
                case "CLIENTID": return ConfigKey.ClientID;
                case "SECRETID": return ConfigKey.SecretID;
                case "CSVPATH": return ConfigKey.CsvPath;
                case "FILEPATH": return ConfigKey.FilePath;
                case "FROM": return ConfigKey.FromAddress;
                case "PASSWORD": return ConfigKey.Password;

                default: throw new NotImplementedException();
            }
        }
    }

    public class Log
    {
        private static string logs;
        public static string Logs
        {
            get { return logs; }
            set
            {
                if (value != string.Empty)
                {
                    if (logForm == null)
                    {
                        logForm = new LogWindow();
                        logForm.Show();
                    }

                    logs = value + Environment.NewLine;

                    logForm.UpdateLog(logs);
                }
                else logs = value;
            }
        }
        private static List<string> failList = new List<string>();

        private static LogWindow logForm = null;

        public static void Clear()
        {
            Logs = string.Empty;
            logForm = null;

            failList.Clear();
        }

        public static void AddFailList(string address) {
            failList.Add(address);
        }
        public static void OnSendComplete() {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("{0}{1}", "== 실패 목록 ==", Environment.NewLine));

            foreach(string address in failList) {
                sb.AppendLine(address);
            }

            Logs += sb.ToString();
        }
    }
}
