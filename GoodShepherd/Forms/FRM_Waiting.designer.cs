namespace GoodShepherd
{
    partial class FRM_Waiting
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
            this.PNL_Main = new Telerik.WinControls.UI.RadPanel();
            this.LBL_Time = new System.Windows.Forms.Label();
            this.BTN_Action = new System.Windows.Forms.Button();
            this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
            this.LBL1 = new System.Windows.Forms.Label();
            this.TXT_FindByCode = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.ultraToolbarsDockArea1 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea2 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.ultraToolbarsDockArea4 = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel2_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel2_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel2_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.FRM_Questions_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this._panel2_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.Timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PNL_Main)).BeginInit();
            this.PNL_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_FindByCode)).BeginInit();
            this.FRM_Questions_Fill_Panel.ClientArea.SuspendLayout();
            this.FRM_Questions_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // PNL_Main
            // 
            this.PNL_Main.Controls.Add(this.LBL_Time);
            this.PNL_Main.Controls.Add(this.BTN_Action);
            this.PNL_Main.Controls.Add(this.ProgressBar1);
            this.PNL_Main.Controls.Add(this.LBL1);
            this.PNL_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PNL_Main.ImageScalingSize = new System.Drawing.Size(10, 10);
            this.PNL_Main.Location = new System.Drawing.Point(0, 0);
            this.PNL_Main.Name = "PNL_Main";
            this.PNL_Main.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PNL_Main.Size = new System.Drawing.Size(343, 153);
            this.PNL_Main.TabIndex = 1;
            // 
            // LBL_Time
            // 
            this.LBL_Time.AutoSize = true;
            this.LBL_Time.Location = new System.Drawing.Point(171, 74);
            this.LBL_Time.Name = "LBL_Time";
            this.LBL_Time.Size = new System.Drawing.Size(0, 13);
            this.LBL_Time.TabIndex = 4;
            this.LBL_Time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BTN_Action
            // 
            this.BTN_Action.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.BTN_Action.Location = new System.Drawing.Point(116, 90);
            this.BTN_Action.Name = "BTN_Action";
            this.BTN_Action.Size = new System.Drawing.Size(88, 29);
            this.BTN_Action.TabIndex = 3;
            this.BTN_Action.Text = "الغاء العملية";
            this.BTN_Action.TextChanged += new System.EventHandler(this.Button1_TextChanged);
            this.BTN_Action.Click += new System.EventHandler(this.Button1_Click);
            // 
            // ProgressBar1
            // 
            this.ProgressBar1.Location = new System.Drawing.Point(69, 51);
            this.ProgressBar1.Name = "ProgressBar1";
            this.ProgressBar1.Size = new System.Drawing.Size(197, 23);
            this.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.ProgressBar1.TabIndex = 1;
            // 
            // LBL1
            // 
            this.LBL1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.LBL1.Location = new System.Drawing.Point(12, 13);
            this.LBL1.Name = "LBL1";
            this.LBL1.Size = new System.Drawing.Size(320, 28);
            this.LBL1.TabIndex = 0;
            this.LBL1.Text = "label3";
            // 
            // TXT_FindByCode
            // 
            this.TXT_FindByCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_FindByCode.DisplayStyle = Infragistics.Win.EmbeddableElementDisplayStyle.Office2010;
            this.TXT_FindByCode.Enabled = false;
            this.TXT_FindByCode.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TXT_FindByCode.Location = new System.Drawing.Point(-204, 34);
            this.TXT_FindByCode.Name = "TXT_FindByCode";
            this.TXT_FindByCode.ReadOnly = true;
            this.TXT_FindByCode.Size = new System.Drawing.Size(83, 25);
            this.TXT_FindByCode.TabIndex = 81;
            this.TXT_FindByCode.Visible = false;
            // 
            // ultraToolbarsDockArea1
            // 
            this.ultraToolbarsDockArea1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this.ultraToolbarsDockArea1.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this.ultraToolbarsDockArea1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ultraToolbarsDockArea1.Location = new System.Drawing.Point(0, 0);
            this.ultraToolbarsDockArea1.Name = "ultraToolbarsDockArea1";
            this.ultraToolbarsDockArea1.Size = new System.Drawing.Size(343, 0);
            // 
            // ultraToolbarsDockArea2
            // 
            this.ultraToolbarsDockArea2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraToolbarsDockArea2.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this.ultraToolbarsDockArea2.ForeColor = System.Drawing.Color.Black;
            this.ultraToolbarsDockArea2.Location = new System.Drawing.Point(0, 153);
            this.ultraToolbarsDockArea2.Name = "ultraToolbarsDockArea2";
            this.ultraToolbarsDockArea2.Size = new System.Drawing.Size(343, 0);
            // 
            // ultraToolbarsDockArea4
            // 
            this.ultraToolbarsDockArea4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.ultraToolbarsDockArea4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ultraToolbarsDockArea4.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this.ultraToolbarsDockArea4.ForeColor = System.Drawing.Color.Black;
            this.ultraToolbarsDockArea4.Location = new System.Drawing.Point(343, 0);
            this.ultraToolbarsDockArea4.Name = "ultraToolbarsDockArea4";
            this.ultraToolbarsDockArea4.Size = new System.Drawing.Size(0, 153);
            // 
            // _panel2_Toolbars_Dock_Area_Right
            // 
            this._panel2_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this._panel2_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._panel2_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panel2_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(343, 0);
            this._panel2_Toolbars_Dock_Area_Right.Name = "_panel2_Toolbars_Dock_Area_Right";
            this._panel2_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 153);
            // 
            // _panel2_Toolbars_Dock_Area_Left
            // 
            this._panel2_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this._panel2_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._panel2_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panel2_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 0);
            this._panel2_Toolbars_Dock_Area_Left.Name = "_panel2_Toolbars_Dock_Area_Left";
            this._panel2_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 153);
            // 
            // _panel2_Toolbars_Dock_Area_Bottom
            // 
            this._panel2_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this._panel2_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._panel2_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panel2_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 153);
            this._panel2_Toolbars_Dock_Area_Bottom.Name = "_panel2_Toolbars_Dock_Area_Bottom";
            this._panel2_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(343, 0);
            // 
            // FRM_Questions_Fill_Panel
            // 
            // 
            // FRM_Questions_Fill_Panel.ClientArea
            // 
            this.FRM_Questions_Fill_Panel.ClientArea.Controls.Add(this.PNL_Main);
            this.FRM_Questions_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FRM_Questions_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FRM_Questions_Fill_Panel.Location = new System.Drawing.Point(0, 0);
            this.FRM_Questions_Fill_Panel.Name = "FRM_Questions_Fill_Panel";
            this.FRM_Questions_Fill_Panel.Size = new System.Drawing.Size(343, 153);
            this.FRM_Questions_Fill_Panel.TabIndex = 3;
            // 
            // _panel2_Toolbars_Dock_Area_Top
            // 
            this._panel2_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(146)))), ((int)(((byte)(146)))));
            this._panel2_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._panel2_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panel2_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._panel2_Toolbars_Dock_Area_Top.Name = "_panel2_Toolbars_Dock_Area_Top";
            this._panel2_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(343, 0);
            // 
            // Timer1
            // 
            this.Timer1.Enabled = true;
            this.Timer1.Interval = 1000;
            // 
            // FRM_Waiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(343, 153);
            this.ControlBox = false;
            this.Controls.Add(this.FRM_Questions_Fill_Panel);
            this.Controls.Add(this.TXT_FindByCode);
            this.Controls.Add(this.ultraToolbarsDockArea4);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Right);
            this.Controls.Add(this.ultraToolbarsDockArea2);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this.ultraToolbarsDockArea1);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Top);
            this.Font = new System.Drawing.Font("Times New Roman", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FRM_Waiting";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "جارى استيراد البيانات";
            this.ThemeName = "Office2010Black";
            ((System.ComponentModel.ISupportInitialize)(this.PNL_Main)).EndInit();
            this.PNL_Main.ResumeLayout(false);
            this.PNL_Main.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_FindByCode)).EndInit();
            this.FRM_Questions_Fill_Panel.ClientArea.ResumeLayout(false);
            this.FRM_Questions_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadPanel PNL_Main;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea1;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea2;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea ultraToolbarsDockArea4;
        internal System.Windows.Forms.Label label6;
        internal System.Windows.Forms.Label label10;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label2;
        internal System.Windows.Forms.Label label4;
        internal Infragistics.Win.UltraWinEditors.UltraTextEditor TXT_FindByCode;
        private Infragistics.Win.Misc.UltraPanel FRM_Questions_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Top;
        private System.Windows.Forms.Label LBL1;
        internal System.Windows.Forms.ProgressBar ProgressBar1;
        public System.Windows.Forms.Button BTN_Action;
        internal System.Windows.Forms.Timer Timer1;
        internal System.Windows.Forms.Label LBL_Time;
    }
}

