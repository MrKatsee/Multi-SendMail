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
            this.importButton = new System.Windows.Forms.Button();
            this.sendButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.addressTextBox = new System.Windows.Forms.TextBox();
            this.openCsvFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.isFirstLineHeaderCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.Label();
            this.mailTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pwdTextBox = new System.Windows.Forms.TextBox();
            this.subjectTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bodyTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(594, 9);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(94, 36);
            this.importButton.TabIndex = 0;
            this.importButton.Text = "불러오기";
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(694, 9);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(94, 36);
            this.sendButton.TabIndex = 1;
            this.sendButton.Text = "전송";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 196);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 30;
            this.dataGridView.Size = new System.Drawing.Size(775, 335);
            this.dataGridView.TabIndex = 2;
            // 
            // addressTextBox
            // 
            this.addressTextBox.Location = new System.Drawing.Point(64, 169);
            this.addressTextBox.Name = "addressTextBox";
            this.addressTextBox.Size = new System.Drawing.Size(571, 21);
            this.addressTextBox.TabIndex = 3;
            // 
            // openCsvFileDialog
            // 
            this.openCsvFileDialog.FileName = "openCsvFileDialog";
            // 
            // isFirstLineHeaderCheckBox
            // 
            this.isFirstLineHeaderCheckBox.AutoSize = true;
            this.isFirstLineHeaderCheckBox.Location = new System.Drawing.Point(666, 51);
            this.isFirstLineHeaderCheckBox.Name = "isFirstLineHeaderCheckBox";
            this.isFirstLineHeaderCheckBox.Size = new System.Drawing.Size(122, 16);
            this.isFirstLineHeaderCheckBox.TabIndex = 4;
            this.isFirstLineHeaderCheckBox.Text = "isFirstLineHeader";
            this.isFirstLineHeaderCheckBox.UseVisualStyleBackColor = true;
            this.isFirstLineHeaderCheckBox.CheckedChanged += new System.EventHandler(this.IsFirstLineHeaderCheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "mail";
            // 
            // txtLog
            // 
            this.txtLog.AutoSize = true;
            this.txtLog.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(9, 534);
            this.txtLog.Name = "txtLog";
            this.txtLog.Size = new System.Drawing.Size(36, 16);
            this.txtLog.TabIndex = 6;
            this.txtLog.Text = "Log";
            this.txtLog.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mailTextBox
            // 
            this.mailTextBox.Location = new System.Drawing.Point(64, 9);
            this.mailTextBox.Name = "mailTextBox";
            this.mailTextBox.Size = new System.Drawing.Size(182, 21);
            this.mailTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(306, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 8;
            this.label3.Text = "pwd";
            // 
            // pwdTextBox
            // 
            this.pwdTextBox.Location = new System.Drawing.Point(360, 9);
            this.pwdTextBox.Name = "pwdTextBox";
            this.pwdTextBox.PasswordChar = '*';
            this.pwdTextBox.Size = new System.Drawing.Size(189, 21);
            this.pwdTextBox.TabIndex = 9;
            // 
            // subjectTextBox
            // 
            this.subjectTextBox.Location = new System.Drawing.Point(64, 36);
            this.subjectTextBox.Name = "subjectTextBox";
            this.subjectTextBox.Size = new System.Drawing.Size(214, 21);
            this.subjectTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(11, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 12);
            this.label2.TabIndex = 11;
            this.label2.Text = "subject";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(12, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "body";
            // 
            // bodyTextBox
            // 
            this.bodyTextBox.Location = new System.Drawing.Point(64, 63);
            this.bodyTextBox.Multiline = true;
            this.bodyTextBox.Name = "bodyTextBox";
            this.bodyTextBox.Size = new System.Drawing.Size(571, 100);
            this.bodyTextBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(12, 172);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "path";
            // 
            // SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 559);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.bodyTextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.subjectTextBox);
            this.Controls.Add(this.pwdTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.mailTextBox);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.isFirstLineHeaderCheckBox);
            this.Controls.Add(this.addressTextBox);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.importButton);
            this.Name = "SendMail";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox addressTextBox;
        private System.Windows.Forms.OpenFileDialog openCsvFileDialog;
        private System.Windows.Forms.CheckBox isFirstLineHeaderCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtLog;
        private System.Windows.Forms.TextBox mailTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox pwdTextBox;
        private System.Windows.Forms.TextBox subjectTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bodyTextBox;
        private System.Windows.Forms.Label label5;
    }
}

