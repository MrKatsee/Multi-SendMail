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

//필요 dll, 닷넷 포함 설치 파일로 -> c# installer .Net Framework

namespace SendMail
{
    public partial class SendMail : Form
    {
        private string currentFile = string.Empty;

        public SendMail()
        {
            InitializeComponent();

            Init_SendMailForm();
        }

        private void Init_SendMailForm()
        {
            Config.ReadINI();

            mailTextBox.Text = Config.Mail;
            pwdTextBox.Text = Config.Pwd;
            subjectTextBox.Text = Config.Subject;
            bodyTextBox.Text = Config.Body;
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            //dialog 창을 염
            if (openCsvFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFile = openCsvFileDialog.FileName;

                //textBox에 파일 경로 입력
                addressTextBox.Text = currentFile;

                //table에 csv 데이터 기입
                dataGridView.DataSource = MailDataManager.CSVParse(currentFile, isFirstLineHeaderCheckBox.Checked);
            }
        }

        private void IsFirstLineHeaderCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //현재 파일 경로가 비어있지 않다면, 테이블을 갱신함
            if (currentFile != string.Empty)
                dataGridView.DataSource = MailDataManager.CSVParse(currentFile, isFirstLineHeaderCheckBox.Checked);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            Log.Clear();
            Log.Logs += "전송 시작...";

            if (mailTextBox.Text == null || pwdTextBox.Text == null)
            {
                Log.Logs += "Error : 메일 혹은 패스워드를 입력하지 않으셨습니다";
                return;
            }
            else if (currentFile == string.Empty)
            {
                Log.Logs += "Error : 불러오기를 하지 않으셨습니다";
                return;
            }

            Mail mail = new Mail(mailTextBox.Text, pwdTextBox.Text, Config.Host, Config.Port);

            foreach (var data in MailDataManager.datas)
            {
                Log.Logs += mail.Send(data.address, Config.Subject, Config.Body, data.file);
            }
            Log.Logs += "전송 종료";
        }
    }

    public class Mail
    {
        private string fromAddress;
        private string password;

        private string host;
        private int port;

        public Mail(string fromAddress, string password, string host, int port)
        {
            this.fromAddress = fromAddress;
            this.password = password;

            this.host = host;
            this.port = port;
        }

        public string Send(string toAddress, string subject, string body, string file)
        {
            SmtpClient smtp = null;
            MailMessage msg = null;

            try
            {
                smtp = new SmtpClient
                {
                    Host = host,
                    Port = port,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress, password),
                    Timeout = 20000
                };
                //메세지
                msg = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                };
                //첨부 파일
                Attachment att = new Attachment(file);
                msg.Attachments.Add(att);

                //발송
                smtp.Send(msg);

                return toAddress + " : 전송 완료";
            }
            catch (Exception e)
            {
                return " : 전송 실패 (" + e + ")";
            }
        }
    }

    public class MailData
    {
        public string address;
        public string file;
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
                    address = dr.Field<string>("address"),
                    file = dr.Field<string>("file")
                };
                datas.Add(data);
            }

            return dt;
        }
    }

    public class Config
    {
        private const string iniFile = "Setting.ini";

        public static string Mail;
        public static string Pwd;
        
        public static string Host;
        public static int Port;

        public static string Subject;
        public static string Body;


        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public static void ReadINI()
        {
            //ini 파일 경로
            string path = Directory.GetCurrentDirectory() + "\\" + iniFile;

            StringBuilder sb = new StringBuilder();

            //ini 읽기
            GetPrivateProfileString("FROM_MAIL", "MAIL", "(NONE)", sb, 32, path);
            if (sb.ToString() != null) Mail = sb.ToString();
            GetPrivateProfileString("FROM_MAIL", "PWD", "(NONE)", sb, 32, path);
            if (sb.ToString() != null) Pwd = sb.ToString();
            GetPrivateProfileString("SMTP", "HOST", "(NONE)", sb, 32, path);
            if (sb.ToString() != null) Host = sb.ToString();
            GetPrivateProfileString("SMTP", "PORT", "(NONE)", sb, 32, path);
            if (sb.ToString() != null) int.TryParse(sb.ToString(), out Port);
            GetPrivateProfileString("DEFAULT", "SUBJECT", "(NONE)", sb, 32, path);
            if (sb.ToString() != null) Subject = sb.ToString();
            GetPrivateProfileString("DEFAULT", "BODY", "(NONE)", sb, 32, path);
            if (sb.ToString() != null) Body = sb.ToString().Replace("\\n", Environment.NewLine);
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

        private static LogWindow logForm = null;

        public static void Clear()
        {
            Logs = string.Empty;
            logForm = null;
        }
    }
}
