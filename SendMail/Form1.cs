using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SendMail
{
    public partial class SendMail : Form
    {
        public SendMail()
        {
            InitializeComponent();
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {

        }

        private void SendButton_Click(object sender, EventArgs e)
        {

        }

        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }

    public class CSVParser
    {
        private static char[] delimiters = { ',', ';' };            //구분자

        private static string[] keys = { "address", "file" };       
        public static string[] Keys { get { return keys; } }

        public static Dictionary<string, string> Parse(string file)
        {
            Dictionary<string, string> parsedData = new Dictionary<string, string>();   //key : string / value : List<string>

            string[] lines = file.Split('\n');
            string[] splitedLine;

            foreach (var line in lines)
            {
                splitedLine = line.Split(delimiters);

                for (int i = 0; i < keys.Length; i++)
                {
                    parsedData.Add(keys[i], splitedLine[i]);
                }
            }

            return parsedData;
        }
    }
}
