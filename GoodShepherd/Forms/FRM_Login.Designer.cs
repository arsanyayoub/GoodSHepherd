namespace GoodShepherd
{
    partial class FRM_Login
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
            System.Windows.Forms.Label UserNameLabel1;
            System.Windows.Forms.Label PassowrdLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Login));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("VIW_Church", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("City_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CityDesc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Area_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AreaDesc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Street_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StreetDesc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChurchName");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance9 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance10 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance11 = new Infragistics.Win.Appearance();
            Infragistics.Win.Appearance appearance12 = new Infragistics.Win.Appearance();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.BTN_Cancel = new System.Windows.Forms.Button();
            this.BTN_Login = new System.Windows.Forms.Button();
            this.STS_Login = new System.Windows.Forms.Label();
            this.CMX_UserName = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.tBLUserBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.userChurchDataSet = new GoodShepherd.UserChurchDataSet();
            this.TXT_Password = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.Timer_MSgCleaner = new System.Windows.Forms.Timer(this.components);
            this.CMX_City = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.tBLCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CMX_Church = new Infragistics.Win.UltraWinGrid.UltraCombo();
            this.vIWChurchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tBL_UserTableAdapter = new GoodShepherd.UserChurchDataSetTableAdapters.TBL_UserTableAdapter();
            this.vIW_ChurchTableAdapter = new GoodShepherd.UserChurchDataSetTableAdapters.VIW_ChurchTableAdapter();
            this.tBL_CityTableAdapter = new GoodShepherd.UserChurchDataSetTableAdapters.TBL_CityTableAdapter();
            this.office2010BlackTheme1 = new Telerik.WinControls.Themes.Office2010BlackTheme();
            UserNameLabel1 = new System.Windows.Forms.Label();
            PassowrdLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMX_UserName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLUserBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userChurchDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_Password)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMX_City)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMX_Church)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIWChurchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // UserNameLabel1
            // 
            UserNameLabel1.AutoSize = true;
            UserNameLabel1.Location = new System.Drawing.Point(268, 118);
            UserNameLabel1.Name = "UserNameLabel1";
            UserNameLabel1.Size = new System.Drawing.Size(78, 13);
            UserNameLabel1.TabIndex = 123;
            UserNameLabel1.Text = "اسم المستخدم :";
            // 
            // PassowrdLabel
            // 
            PassowrdLabel.AutoSize = true;
            PassowrdLabel.Location = new System.Drawing.Point(279, 145);
            PassowrdLabel.Name = "PassowrdLabel";
            PassowrdLabel.Size = new System.Drawing.Size(66, 13);
            PassowrdLabel.TabIndex = 122;
            PassowrdLabel.Text = "كلمة المرور :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(294, 91);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(49, 13);
            label2.TabIndex = 123;
            label2.Text = "الكنيسة :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(289, 64);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(56, 13);
            label3.TabIndex = 123;
            label3.Text = "المحافظة :";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("PictureBox1.Image")));
            this.PictureBox1.Location = new System.Drawing.Point(388, 39);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(125, 145);
            this.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.PictureBox1.TabIndex = 126;
            this.PictureBox1.TabStop = false;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Tahoma", 16F);
            this.Label1.Location = new System.Drawing.Point(375, 9);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(150, 27);
            this.Label1.TabIndex = 125;
            this.Label1.Text = "دخول مستخدم";
            // 
            // BTN_Cancel
            // 
            this.BTN_Cancel.Location = new System.Drawing.Point(202, 171);
            this.BTN_Cancel.Name = "BTN_Cancel";
            this.BTN_Cancel.Size = new System.Drawing.Size(60, 23);
            this.BTN_Cancel.TabIndex = 4;
            this.BTN_Cancel.Text = "Exit";
            this.BTN_Cancel.UseVisualStyleBackColor = true;
            this.BTN_Cancel.Click += new System.EventHandler(this.BTN_Cancel_Click);
            // 
            // BTN_Login
            // 
            this.BTN_Login.Location = new System.Drawing.Point(136, 171);
            this.BTN_Login.Name = "BTN_Login";
            this.BTN_Login.Size = new System.Drawing.Size(60, 23);
            this.BTN_Login.TabIndex = 5;
            this.BTN_Login.Text = "Sign in";
            this.BTN_Login.UseVisualStyleBackColor = true;
            this.BTN_Login.Click += new System.EventHandler(this.BTN_Login_Click);
            // 
            // STS_Login
            // 
            this.STS_Login.AutoSize = true;
            this.STS_Login.Location = new System.Drawing.Point(183, 208);
            this.STS_Login.Name = "STS_Login";
            this.STS_Login.Size = new System.Drawing.Size(16, 13);
            this.STS_Login.TabIndex = 124;
            this.STS_Login.Text = "...";
            // 
            // CMX_UserName
            // 
            this.CMX_UserName.DataSource = this.tBLUserBindingSource;
            this.CMX_UserName.DisplayMember = "UserName";
            this.CMX_UserName.Location = new System.Drawing.Point(66, 113);
            this.CMX_UserName.Name = "CMX_UserName";
            this.CMX_UserName.Size = new System.Drawing.Size(196, 21);
            this.CMX_UserName.TabIndex = 2;
            this.CMX_UserName.ValueMember = "IDUser";
            // 
            // tBLUserBindingSource
            // 
            this.tBLUserBindingSource.DataMember = "TBL_User";
            this.tBLUserBindingSource.DataSource = this.userChurchDataSet;
            // 
            // userChurchDataSet
            // 
            this.userChurchDataSet.DataSetName = "UserChurchDataSet";
            this.userChurchDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // TXT_Password
            // 
            this.TXT_Password.Location = new System.Drawing.Point(66, 140);
            this.TXT_Password.Name = "TXT_Password";
            this.TXT_Password.PasswordChar = '*';
            this.TXT_Password.Size = new System.Drawing.Size(196, 21);
            this.TXT_Password.TabIndex = 3;
            this.TXT_Password.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TXT_Password_KeyPress);
            // 
            // Timer_MSgCleaner
            // 
            this.Timer_MSgCleaner.Interval = 5000;
            // 
            // CMX_City
            // 
            this.CMX_City.DataSource = this.tBLCityBindingSource;
            this.CMX_City.DisplayMember = "CityDesc";
            this.CMX_City.Location = new System.Drawing.Point(66, 59);
            this.CMX_City.Name = "CMX_City";
            this.CMX_City.Size = new System.Drawing.Size(196, 21);
            this.CMX_City.TabIndex = 0;
            this.CMX_City.ValueMember = "ID";
            this.CMX_City.ValueChanged += new System.EventHandler(this.CMX_City_ValueChanged);
            // 
            // tBLCityBindingSource
            // 
            this.tBLCityBindingSource.DataMember = "TBL_City";
            this.tBLCityBindingSource.DataSource = this.userChurchDataSet;
            // 
            // CMX_Church
            // 
            this.CMX_Church.DataSource = this.vIWChurchBindingSource;
            appearance1.BackColor = System.Drawing.SystemColors.Window;
            appearance1.BorderColor = System.Drawing.SystemColors.InactiveCaption;
            this.CMX_Church.DisplayLayout.Appearance = appearance1;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Hidden = true;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Caption = "المنطقة";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.Caption = "الشارع";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn8.Header.Caption = "الكنيسة";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            this.CMX_Church.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.CMX_Church.DisplayLayout.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            this.CMX_Church.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            appearance2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            appearance2.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance2.BackGradientStyle = Infragistics.Win.GradientStyle.Vertical;
            appearance2.BorderColor = System.Drawing.SystemColors.Window;
            this.CMX_Church.DisplayLayout.GroupByBox.Appearance = appearance2;
            appearance3.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CMX_Church.DisplayLayout.GroupByBox.BandLabelAppearance = appearance3;
            this.CMX_Church.DisplayLayout.GroupByBox.BorderStyle = Infragistics.Win.UIElementBorderStyle.Solid;
            appearance4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            appearance4.BackColor2 = System.Drawing.SystemColors.Control;
            appearance4.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance4.ForeColor = System.Drawing.SystemColors.GrayText;
            this.CMX_Church.DisplayLayout.GroupByBox.PromptAppearance = appearance4;
            this.CMX_Church.DisplayLayout.MaxColScrollRegions = 1;
            this.CMX_Church.DisplayLayout.MaxRowScrollRegions = 1;
            appearance5.BackColor = System.Drawing.SystemColors.Window;
            appearance5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CMX_Church.DisplayLayout.Override.ActiveCellAppearance = appearance5;
            appearance6.BackColor = System.Drawing.SystemColors.Highlight;
            appearance6.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.CMX_Church.DisplayLayout.Override.ActiveRowAppearance = appearance6;
            this.CMX_Church.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.CMX_Church.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.CMX_Church.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            appearance7.BackColor = System.Drawing.SystemColors.Window;
            this.CMX_Church.DisplayLayout.Override.CardAreaAppearance = appearance7;
            appearance8.BorderColor = System.Drawing.Color.Silver;
            appearance8.TextTrimming = Infragistics.Win.TextTrimming.EllipsisCharacter;
            this.CMX_Church.DisplayLayout.Override.CellAppearance = appearance8;
            this.CMX_Church.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.EditAndSelectText;
            this.CMX_Church.DisplayLayout.Override.CellPadding = 0;
            appearance9.BackColor = System.Drawing.SystemColors.Control;
            appearance9.BackColor2 = System.Drawing.SystemColors.ControlDark;
            appearance9.BackGradientAlignment = Infragistics.Win.GradientAlignment.Element;
            appearance9.BackGradientStyle = Infragistics.Win.GradientStyle.Horizontal;
            appearance9.BorderColor = System.Drawing.SystemColors.Window;
            this.CMX_Church.DisplayLayout.Override.GroupByRowAppearance = appearance9;
            appearance10.TextHAlignAsString = "Left";
            this.CMX_Church.DisplayLayout.Override.HeaderAppearance = appearance10;
            this.CMX_Church.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.CMX_Church.DisplayLayout.Override.HeaderStyle = Infragistics.Win.HeaderStyle.WindowsXPCommand;
            appearance11.BackColor = System.Drawing.SystemColors.Window;
            appearance11.BorderColor = System.Drawing.Color.Silver;
            this.CMX_Church.DisplayLayout.Override.RowAppearance = appearance11;
            this.CMX_Church.DisplayLayout.Override.RowSelectors = Infragistics.Win.DefaultableBoolean.False;
            appearance12.BackColor = System.Drawing.SystemColors.ControlLight;
            this.CMX_Church.DisplayLayout.Override.TemplateAddRowAppearance = appearance12;
            this.CMX_Church.DisplayLayout.ScrollBounds = Infragistics.Win.UltraWinGrid.ScrollBounds.ScrollToFill;
            this.CMX_Church.DisplayLayout.ScrollStyle = Infragistics.Win.UltraWinGrid.ScrollStyle.Immediate;
            this.CMX_Church.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy;
            this.CMX_Church.DisplayMember = "ChurchName";
            this.CMX_Church.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMX_Church.Location = new System.Drawing.Point(66, 86);
            this.CMX_Church.Name = "CMX_Church";
            this.CMX_Church.Size = new System.Drawing.Size(196, 22);
            this.CMX_Church.TabIndex = 1;
            this.CMX_Church.ValueMember = "ID";
            this.CMX_Church.ValueChanged += new System.EventHandler(this.CMX_Church_ValueChanged);
            // 
            // vIWChurchBindingSource
            // 
            this.vIWChurchBindingSource.DataMember = "VIW_Church";
            this.vIWChurchBindingSource.DataSource = this.userChurchDataSet;
            // 
            // tBL_UserTableAdapter
            // 
            this.tBL_UserTableAdapter.ClearBeforeFill = true;
            // 
            // vIW_ChurchTableAdapter
            // 
            this.vIW_ChurchTableAdapter.ClearBeforeFill = true;
            // 
            // tBL_CityTableAdapter
            // 
            this.tBL_CityTableAdapter.ClearBeforeFill = true;
            // 
            // FRM_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 242);
            this.ControlBox = false;
            this.Controls.Add(this.CMX_Church);
            this.Controls.Add(this.TXT_Password);
            this.Controls.Add(this.CMX_City);
            this.Controls.Add(this.CMX_UserName);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.BTN_Cancel);
            this.Controls.Add(label3);
            this.Controls.Add(this.BTN_Login);
            this.Controls.Add(label2);
            this.Controls.Add(this.STS_Login);
            this.Controls.Add(UserNameLabel1);
            this.Controls.Add(PassowrdLabel);
            this.Name = "FRM_Login";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دخول المستخدم";
            this.ThemeName = "Office2010Black";
            this.Load += new System.EventHandler(this.FRM_Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMX_UserName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLUserBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userChurchDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_Password)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMX_City)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMX_Church)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIWChurchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button BTN_Cancel;
        internal System.Windows.Forms.Button BTN_Login;
        internal System.Windows.Forms.Label STS_Login;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor CMX_UserName;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TXT_Password;
        internal System.Windows.Forms.Timer Timer_MSgCleaner;
        private UserChurchDataSet userChurchDataSet;
        private System.Windows.Forms.BindingSource tBLUserBindingSource;
        private UserChurchDataSetTableAdapters.TBL_UserTableAdapter tBL_UserTableAdapter;
        private System.Windows.Forms.BindingSource vIWChurchBindingSource;
        private UserChurchDataSetTableAdapters.VIW_ChurchTableAdapter vIW_ChurchTableAdapter;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor CMX_City;
        private System.Windows.Forms.BindingSource tBLCityBindingSource;
        private UserChurchDataSetTableAdapters.TBL_CityTableAdapter tBL_CityTableAdapter;
        private Infragistics.Win.UltraWinGrid.UltraCombo CMX_Church;
        private Telerik.WinControls.Themes.Office2010BlackTheme office2010BlackTheme1;
    }
}