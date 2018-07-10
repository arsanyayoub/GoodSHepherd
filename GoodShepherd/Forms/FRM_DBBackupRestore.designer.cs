namespace GoodShepherd.Forms
{
    partial class FRM_DBBackupRestore
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
            this.components = new System.ComponentModel.Container();
            this.OpenFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.LBL_Message = new System.Windows.Forms.Label();
            this.cmbbackup = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.Timer_MSgCleaner = new System.Windows.Forms.Timer(this.components);
            this.LBL_Status = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenFileDialog1
            // 
            this.OpenFileDialog1.Filter = "Bakup files (*.Bak)|*.Bak";
            // 
            // SaveFileDialog1
            // 
            this.SaveFileDialog1.Filter = "Bakup files (*.Bak)|*.Bak";
            // 
            // LBL_Message
            // 
            this.LBL_Message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_Message.AutoSize = true;
            this.LBL_Message.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Message.ForeColor = System.Drawing.Color.Red;
            this.LBL_Message.Location = new System.Drawing.Point(194, 119);
            this.LBL_Message.Name = "LBL_Message";
            this.LBL_Message.Size = new System.Drawing.Size(0, 15);
            this.LBL_Message.TabIndex = 29;
            this.LBL_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbbackup
            // 
            this.cmbbackup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbbackup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.cmbbackup.Location = new System.Drawing.Point(141, 12);
            this.cmbbackup.Name = "cmbbackup";
            this.cmbbackup.Size = new System.Drawing.Size(91, 29);
            this.cmbbackup.TabIndex = 30;
            this.cmbbackup.Text = "تأمين";
            this.cmbbackup.UseVisualStyleBackColor = true;
            this.cmbbackup.Click += new System.EventHandler(this.cmbbackup_Click_1);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(9, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 29);
            this.button1.TabIndex = 31;
            this.button1.Text = "استرجاع";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar1.Location = new System.Drawing.Point(9, 58);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(223, 23);
            this.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar1.TabIndex = 32;
            // 
            // Timer_MSgCleaner
            // 
            this.Timer_MSgCleaner.Interval = 5000;
            this.Timer_MSgCleaner.Tick += new System.EventHandler(this.Timer_MSgCleaner_Tick);
            // 
            // LBL_Status
            // 
            this.LBL_Status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LBL_Status.AutoSize = true;
            this.LBL_Status.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBL_Status.ForeColor = System.Drawing.Color.Blue;
            this.LBL_Status.Location = new System.Drawing.Point(138, 87);
            this.LBL_Status.Name = "LBL_Status";
            this.LBL_Status.Size = new System.Drawing.Size(40, 15);
            this.LBL_Status.TabIndex = 33;
            this.LBL_Status.Text = "label3";
            this.LBL_Status.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FRM_DBBackupRestore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 153);
            this.Controls.Add(this.LBL_Status);
            this.Controls.Add(this.ProgressBar1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbbackup);
            this.Controls.Add(this.LBL_Message);
            this.Name = "FRM_DBBackupRestore";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حماية قاعدة البيانات";
            this.ThemeName = "Office2007Black";
            this.Load += new System.EventHandler(this.FRM_DBBackupRestore_Load);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.OpenFileDialog OpenFileDialog1;
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog1;
        private System.Windows.Forms.Label LBL_Message;
        private System.Windows.Forms.Button cmbbackup;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        internal System.Windows.Forms.Timer Timer_MSgCleaner;
        private System.Windows.Forms.Label LBL_Status;
    }
}

