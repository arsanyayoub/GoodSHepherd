namespace GoodShepherd
{
    partial class FRM_DBConfiguration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TXT_TimeOut = new System.Windows.Forms.NumericUpDown();
            this.TXT_ServerName = new System.Windows.Forms.ComboBox();
            this.TXT_Database = new System.Windows.Forms.ComboBox();
            this.TXT_DataSource = new System.Windows.Forms.TextBox();
            this.TXT_Login = new System.Windows.Forms.TextBox();
            this.TXT_Password = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RDB_SQLAuth = new System.Windows.Forms.RadioButton();
            this.RDB_WinAuth = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BTN_Test = new System.Windows.Forms.Button();
            this.BTN_Select = new System.Windows.Forms.Button();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.Notification = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_TimeOut)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Server Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Login";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Password";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Connect To Database";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Connect Time Out";
            // 
            // TXT_TimeOut
            // 
            this.TXT_TimeOut.Location = new System.Drawing.Point(130, 56);
            this.TXT_TimeOut.Name = "TXT_TimeOut";
            this.TXT_TimeOut.Size = new System.Drawing.Size(213, 20);
            this.TXT_TimeOut.TabIndex = 2;
            // 
            // TXT_ServerName
            // 
            this.TXT_ServerName.FormattingEnabled = true;
            this.TXT_ServerName.Location = new System.Drawing.Point(145, 39);
            this.TXT_ServerName.Name = "TXT_ServerName";
            this.TXT_ServerName.Size = new System.Drawing.Size(213, 21);
            this.TXT_ServerName.TabIndex = 3;
            // 
            // TXT_Database
            // 
            this.TXT_Database.FormattingEnabled = true;
            this.TXT_Database.Location = new System.Drawing.Point(130, 27);
            this.TXT_Database.Name = "TXT_Database";
            this.TXT_Database.Size = new System.Drawing.Size(213, 21);
            this.TXT_Database.TabIndex = 3;
            this.TXT_Database.Enter += new System.EventHandler(this.TXT_Database_Enter);
            // 
            // TXT_DataSource
            // 
            this.TXT_DataSource.Location = new System.Drawing.Point(145, 13);
            this.TXT_DataSource.Name = "TXT_DataSource";
            this.TXT_DataSource.ReadOnly = true;
            this.TXT_DataSource.Size = new System.Drawing.Size(213, 20);
            this.TXT_DataSource.TabIndex = 4;
            this.TXT_DataSource.Text = "Microsoft SQL Server (SqlClient)";
            // 
            // TXT_Login
            // 
            this.TXT_Login.Location = new System.Drawing.Point(130, 94);
            this.TXT_Login.Name = "TXT_Login";
            this.TXT_Login.Size = new System.Drawing.Size(213, 20);
            this.TXT_Login.TabIndex = 4;
            // 
            // TXT_Password
            // 
            this.TXT_Password.Location = new System.Drawing.Point(130, 123);
            this.TXT_Password.Name = "TXT_Password";
            this.TXT_Password.Size = new System.Drawing.Size(213, 20);
            this.TXT_Password.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RDB_SQLAuth);
            this.groupBox1.Controls.Add(this.RDB_WinAuth);
            this.groupBox1.Controls.Add(this.TXT_Password);
            this.groupBox1.Controls.Add(this.TXT_Login);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(15, 82);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 160);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Log On TO The Server";
            // 
            // RDB_SQLAuth
            // 
            this.RDB_SQLAuth.AutoSize = true;
            this.RDB_SQLAuth.Location = new System.Drawing.Point(16, 48);
            this.RDB_SQLAuth.Name = "RDB_SQLAuth";
            this.RDB_SQLAuth.Size = new System.Drawing.Size(173, 17);
            this.RDB_SQLAuth.TabIndex = 5;
            this.RDB_SQLAuth.TabStop = true;
            this.RDB_SQLAuth.Text = "Use SQL Server Authentication";
            this.RDB_SQLAuth.UseVisualStyleBackColor = true;
            this.RDB_SQLAuth.CheckedChanged += new System.EventHandler(this.RDB_SQLAuth_CheckedChanged);
            // 
            // RDB_WinAuth
            // 
            this.RDB_WinAuth.AutoSize = true;
            this.RDB_WinAuth.Location = new System.Drawing.Point(16, 25);
            this.RDB_WinAuth.Name = "RDB_WinAuth";
            this.RDB_WinAuth.Size = new System.Drawing.Size(162, 17);
            this.RDB_WinAuth.TabIndex = 5;
            this.RDB_WinAuth.TabStop = true;
            this.RDB_WinAuth.Text = "Use Windows Authentication";
            this.RDB_WinAuth.UseVisualStyleBackColor = true;
            this.RDB_WinAuth.CheckedChanged += new System.EventHandler(this.RDB_WinAuth_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.TXT_Database);
            this.groupBox2.Controls.Add(this.TXT_TimeOut);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(15, 262);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(357, 100);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connect To A Database";
            // 
            // BTN_Test
            // 
            this.BTN_Test.Location = new System.Drawing.Point(15, 368);
            this.BTN_Test.Name = "BTN_Test";
            this.BTN_Test.Size = new System.Drawing.Size(106, 23);
            this.BTN_Test.TabIndex = 7;
            this.BTN_Test.Text = "Test Connection";
            this.BTN_Test.UseVisualStyleBackColor = true;
            this.BTN_Test.Click += new System.EventHandler(this.BTN_Test_Click);
            // 
            // BTN_Select
            // 
            this.BTN_Select.Location = new System.Drawing.Point(216, 368);
            this.BTN_Select.Name = "BTN_Select";
            this.BTN_Select.Size = new System.Drawing.Size(75, 23);
            this.BTN_Select.TabIndex = 8;
            this.BTN_Select.Text = "Apply";
            this.BTN_Select.UseVisualStyleBackColor = true;
            this.BTN_Select.Click += new System.EventHandler(this.BTN_Select_Click);
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Location = new System.Drawing.Point(297, 368);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(75, 23);
            this.BTN_Cancel.TabIndex = 9;
            this.BTN_Cancel.Text = "Cancel";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // Notification
            // 
            this.Notification.AutoSize = true;
            this.Notification.Location = new System.Drawing.Point(19, 401);
            this.Notification.Name = "Notification";
            this.Notification.Size = new System.Drawing.Size(22, 13);
            this.Notification.TabIndex = 1;
            this.Notification.Text = ". . .";
            // 
            // FRM_DBConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 426);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(this.BTN_Select);
            this.Controls.Add(this.BTN_Test);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Notification);
            this.Controls.Add(this.TXT_DataSource);
            this.Controls.Add(this.TXT_ServerName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FRM_DBConfiguration";
            this.Text = "FRM_DBConfigration";
            this.Load += new System.EventHandler(this.FRM_DBConfigMgr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TXT_TimeOut)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown TXT_TimeOut;
        private System.Windows.Forms.ComboBox TXT_ServerName;
        private System.Windows.Forms.ComboBox TXT_Database;
        private System.Windows.Forms.TextBox TXT_DataSource;
        private System.Windows.Forms.TextBox TXT_Login;
        private System.Windows.Forms.TextBox TXT_Password;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RDB_SQLAuth;
        private System.Windows.Forms.RadioButton RDB_WinAuth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BTN_Test;
        private System.Windows.Forms.Button BTN_Select;
        private System.Windows.Forms.Button BTN_Cancel;
        private System.Windows.Forms.Label Notification;
    }
}