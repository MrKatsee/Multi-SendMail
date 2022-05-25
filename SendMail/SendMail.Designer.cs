namespace SendMail
{
    partial class SendMail
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_csvImport = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.txt_csvPath = new System.Windows.Forms.TextBox();
            this.openCsvFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.isFirstLineHeaderCheckBox = new System.Windows.Forms.CheckBox();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bodyTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_filePath = new System.Windows.Forms.TextBox();
            this.btn_fileImport = new System.Windows.Forms.Button();
            this.openFilePathDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_fromAddress = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_password = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_csvImport
            // 
            this.btn_csvImport.Location = new System.Drawing.Point(1030, 231);
            this.btn_csvImport.Margin = new System.Windows.Forms.Padding(4);
            this.btn_csvImport.Name = "btn_csvImport";
            this.btn_csvImport.Size = new System.Drawing.Size(95, 36);
            this.btn_csvImport.TabIndex = 0;
            this.btn_csvImport.Text = "불러오기";
            this.btn_csvImport.UseVisualStyleBackColor = true;
            this.btn_csvImport.Click += new System.EventHandler(this.OnClick_CsvImport);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(991, 772);
            this.sendButton.Margin = new System.Windows.Forms.Padding(4);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(134, 54);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "전송";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(19, 315);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 62;
            this.dataGridView.RowTemplate.Height = 30;
            this.dataGridView.Size = new System.Drawing.Size(1107, 446);
            this.dataGridView.TabIndex = 2;
            // 
            // txt_csvPath
            // 
            this.txt_csvPath.Location = new System.Drawing.Point(105, 237);
            this.txt_csvPath.Margin = new System.Windows.Forms.Padding(4);
            this.txt_csvPath.Name = "txt_csvPath";
            this.txt_csvPath.Size = new System.Drawing.Size(899, 28);
            this.txt_csvPath.TabIndex = 3;
            // 
            // openCsvFileDialog
            // 
            this.openCsvFileDialog.FileName = "openCsvFileDialog";
            // 
            // isFirstLineHeaderCheckBox
            // 
            this.isFirstLineHeaderCheckBox.AutoSize = true;
            this.isFirstLineHeaderCheckBox.Checked = true;
            this.isFirstLineHeaderCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.isFirstLineHeaderCheckBox.Location = new System.Drawing.Point(20, 789);
            this.isFirstLineHeaderCheckBox.Margin = new System.Windows.Forms.Padding(4);
            this.isFirstLineHeaderCheckBox.Name = "isFirstLineHeaderCheckBox";
            this.isFirstLineHeaderCheckBox.Size = new System.Drawing.Size(196, 22);
            this.isFirstLineHeaderCheckBox.TabIndex = 4;
            this.isFirstLineHeaderCheckBox.Text = "첫 줄을 헤더로 사용";
            this.isFirstLineHeaderCheckBox.UseVisualStyleBackColor = true;
            this.isFirstLineHeaderCheckBox.CheckedChanged += new System.EventHandler(this.IsFirstLineHeaderCheckBox_CheckedChanged);
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(105, 45);
            this.subjectTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(480, 28);
            this.subjectTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 11;
            this.label2.Text = "제목";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(16, 84);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "본문";
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.Location = new System.Drawing.Point(105, 81);
            this.bodyTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.bodyTextBox.Multiline = true;
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.Size = new System.Drawing.Size(800, 148);
            this.bodyTextBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(17, 241);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "csv 경로";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(17, 279);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "파일 경로";
            // 
            // txt_filePath
            // 
            this.txt_filePath.Location = new System.Drawing.Point(105, 275);
            this.txt_filePath.Margin = new System.Windows.Forms.Padding(4);
            this.txt_filePath.Name = "txt_filePath";
            this.txt_filePath.Size = new System.Drawing.Size(899, 28);
            this.txt_filePath.TabIndex = 15;
            // 
            // btn_fileImport
            // 
            this.btn_fileImport.Location = new System.Drawing.Point(1030, 270);
            this.btn_fileImport.Margin = new System.Windows.Forms.Padding(4);
            this.btn_fileImport.Name = "btn_fileImport";
            this.btn_fileImport.Size = new System.Drawing.Size(95, 36);
            this.btn_fileImport.TabIndex = 17;
            this.btn_fileImport.Text = "불러오기";
            this.btn_fileImport.UseVisualStyleBackColor = true;
            this.btn_fileImport.Click += new System.EventHandler(this.OnClick_FilePathImport);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(16, 12);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "메일";
            // 
            // txt_fromAddress
            // 
            this.txt_fromAddress.Location = new System.Drawing.Point(105, 9);
            this.txt_fromAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txt_fromAddress.Name = "txt_fromAddress";
            this.txt_fromAddress.Size = new System.Drawing.Size(342, 28);
            this.txt_fromAddress.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(573, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "비밀번호";
            // 
            // txt_password
            // 
            this.txt_password.Location = new System.Drawing.Point(662, 13);
            this.txt_password.Margin = new System.Windows.Forms.Padding(4);
            this.txt_password.Name = "txt_password";
            this.txt_password.PasswordChar = '*';
            this.txt_password.Size = new System.Drawing.Size(342, 28);
            this.txt_password.TabIndex = 20;
            // 
            // SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 838);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_password);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_fromAddress);
            this.Controls.Add(this.btn_fileImport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_filePath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bodyTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.isFirstLineHeaderCheckBox);
            this.Controls.Add(this.txt_csvPath);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.btn_csvImport);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SendMail";
            this.Text = "SendMail";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_csvImport;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox txt_csvPath;
        private System.Windows.Forms.OpenFileDialog openCsvFileDialog;
        private System.Windows.Forms.CheckBox isFirstLineHeaderCheckBox;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bodyTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_filePath;
        private System.Windows.Forms.Button btn_fileImport;
        private System.Windows.Forms.FolderBrowserDialog openFilePathDialog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_fromAddress;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_password;
    }
}

