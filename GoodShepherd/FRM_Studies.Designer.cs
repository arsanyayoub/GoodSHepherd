namespace GoodShepherd
{
    partial class FRM_Studies
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Studies));
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("TBL_EducationLevel", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EducLevel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_TBL_Collage_TBL_EducationLevel");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn20 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_TBL_EducYear_TBL_EducationLevel");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_TBL_Collage_TBL_EducationLevel", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn21 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn22 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EducLevel_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn23 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Collage");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn24 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_TBL_EducYear_TBL_Collage");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_TBL_EducYear_TBL_Collage", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EducLevel_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Collage_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EducYear");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn29 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LastYear");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_TBL_EducYear_TBL_EducationLevel", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn30 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn31 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EducLevel_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn32 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Collage_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn33 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("EducYear");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn34 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("LastYear");
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("          ");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool2 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Previous");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool6 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Next");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool10 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Delete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool11 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Save");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool9 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_New");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool1 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_New");
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool3 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Save");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool4 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Delete");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool5 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Exit");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool2 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool7 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Previous");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool8 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Next");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("TXT_FindByCode");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("    ");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("          ");
            this.tBL_EducationLevelBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.tBL_EducationLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.studiesDataSet = new GoodShepherd.StudiesDataSet();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tBL_EducationLevelBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.GRD_Studies = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tBL_EducYearBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tBL_CollageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Toolbar_Options = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._panel2_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel2_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel2_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel2_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.tBL_EducationLevelTableAdapter = new GoodShepherd.StudiesDataSetTableAdapters.TBL_EducationLevelTableAdapter();
            this.tableAdapterManager = new GoodShepherd.StudiesDataSetTableAdapters.TableAdapterManager();
            this.tBL_CollageTableAdapter = new GoodShepherd.StudiesDataSetTableAdapters.TBL_CollageTableAdapter();
            this.tBL_EducYearTableAdapter = new GoodShepherd.StudiesDataSetTableAdapters.TBL_EducYearTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_EducationLevelBindingNavigator)).BeginInit();
            this.tBL_EducationLevelBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_EducationLevelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.studiesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_Studies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_EducYearBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_CollageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Toolbar_Options)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tBL_EducationLevelBindingNavigator
            // 
            this.tBL_EducationLevelBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tBL_EducationLevelBindingNavigator.BindingSource = this.tBL_EducationLevelBindingSource;
            this.tBL_EducationLevelBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tBL_EducationLevelBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tBL_EducationLevelBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.tBL_EducationLevelBindingNavigatorSaveItem});
            this.tBL_EducationLevelBindingNavigator.Location = new System.Drawing.Point(0, 71);
            this.tBL_EducationLevelBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tBL_EducationLevelBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tBL_EducationLevelBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tBL_EducationLevelBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tBL_EducationLevelBindingNavigator.Name = "tBL_EducationLevelBindingNavigator";
            this.tBL_EducationLevelBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tBL_EducationLevelBindingNavigator.Size = new System.Drawing.Size(798, 25);
            this.tBL_EducationLevelBindingNavigator.TabIndex = 0;
            this.tBL_EducationLevelBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorAddNewItem.Text = "Add new";
            // 
            // tBL_EducationLevelBindingSource
            // 
            this.tBL_EducationLevelBindingSource.DataMember = "TBL_EducationLevel";
            this.tBL_EducationLevelBindingSource.DataSource = this.studiesDataSet;
            // 
            // studiesDataSet
            // 
            this.studiesDataSet.DataSetName = "StudiesDataSet";
            this.studiesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tBL_EducationLevelBindingNavigatorSaveItem
            // 
            this.tBL_EducationLevelBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBL_EducationLevelBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tBL_EducationLevelBindingNavigatorSaveItem.Image")));
            this.tBL_EducationLevelBindingNavigatorSaveItem.Name = "tBL_EducationLevelBindingNavigatorSaveItem";
            this.tBL_EducationLevelBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.tBL_EducationLevelBindingNavigatorSaveItem.Text = "Save Data";
            this.tBL_EducationLevelBindingNavigatorSaveItem.Click += new System.EventHandler(this.tBL_EducationLevelBindingNavigatorSaveItem_Click);
            // 
            // GRD_Studies
            // 
            this.GRD_Studies.DataSource = this.tBL_EducationLevelBindingSource;
            ultraGridColumn17.Header.VisiblePosition = 0;
            ultraGridColumn17.Hidden = true;
            ultraGridColumn18.Header.Caption = "المرحلة الدراسية";
            ultraGridColumn18.Header.VisiblePosition = 1;
            ultraGridColumn18.Width = 357;
            ultraGridColumn19.Header.VisiblePosition = 2;
            ultraGridColumn20.Header.VisiblePosition = 3;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19,
            ultraGridColumn20});
            ultraGridBand1.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.No;
            ultraGridColumn21.Header.VisiblePosition = 0;
            ultraGridColumn21.Hidden = true;
            ultraGridColumn22.Header.VisiblePosition = 1;
            ultraGridColumn22.Hidden = true;
            ultraGridColumn23.Header.Caption = "الكلية";
            ultraGridColumn23.Header.VisiblePosition = 2;
            ultraGridColumn23.Width = 338;
            ultraGridColumn24.Header.VisiblePosition = 3;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn21,
            ultraGridColumn22,
            ultraGridColumn23,
            ultraGridColumn24});
            ultraGridColumn25.Header.VisiblePosition = 0;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.Header.VisiblePosition = 1;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.Header.VisiblePosition = 2;
            ultraGridColumn27.Hidden = true;
            ultraGridColumn28.Header.Caption = "السنة الدراسية";
            ultraGridColumn28.Header.VisiblePosition = 3;
            ultraGridColumn28.Width = 319;
            ultraGridColumn29.Header.Caption = "اخر سنة في المرحلة";
            ultraGridColumn29.Header.VisiblePosition = 4;
            ultraGridColumn29.Width = 79;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28,
            ultraGridColumn29});
            ultraGridColumn30.Header.VisiblePosition = 0;
            ultraGridColumn30.Hidden = true;
            ultraGridColumn31.Header.VisiblePosition = 1;
            ultraGridColumn31.Hidden = true;
            ultraGridColumn32.Header.VisiblePosition = 2;
            ultraGridColumn32.Hidden = true;
            ultraGridColumn33.Header.Caption = "السنة الدراسية";
            ultraGridColumn33.Header.VisiblePosition = 3;
            ultraGridColumn33.Width = 338;
            ultraGridColumn34.Header.Caption = "اخر سنة في المرحلة";
            ultraGridColumn34.Header.VisiblePosition = 4;
            ultraGridColumn34.Width = 79;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn30,
            ultraGridColumn31,
            ultraGridColumn32,
            ultraGridColumn33,
            ultraGridColumn34});
            this.GRD_Studies.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.GRD_Studies.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.GRD_Studies.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.GRD_Studies.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.GRD_Studies.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.GRD_Studies.DisplayLayout.MaxColScrollRegions = 1;
            this.GRD_Studies.DisplayLayout.MaxRowScrollRegions = 1;
            this.GRD_Studies.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.GRD_Studies.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.GRD_Studies.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.GRD_Studies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRD_Studies.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRD_Studies.Location = new System.Drawing.Point(0, 96);
            this.GRD_Studies.Name = "GRD_Studies";
            this.GRD_Studies.Size = new System.Drawing.Size(798, 317);
            this.GRD_Studies.TabIndex = 1;
            this.GRD_Studies.Text = "ultraGrid1";
            this.GRD_Studies.BeforeRowExpanded += new Infragistics.Win.UltraWinGrid.CancelableRowEventHandler(this.tBL_EducationLevelUltraGrid_BeforeRowExpanded);
            this.GRD_Studies.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.tBL_EducationUltraGrid_CellChange);
            // 
            // tBL_EducYearBindingSource
            // 
            this.tBL_EducYearBindingSource.DataMember = "FK_TBL_EducYear_TBL_EducationLevel";
            this.tBL_EducYearBindingSource.DataSource = this.tBL_EducationLevelBindingSource;
            // 
            // tBL_CollageBindingSource
            // 
            this.tBL_CollageBindingSource.DataMember = "FK_TBL_Collage_TBL_EducationLevel";
            this.tBL_CollageBindingSource.DataSource = this.tBL_EducationLevelBindingSource;
            // 
            // Toolbar_Options
            // 
            this.Toolbar_Options.AlwaysShowMenusExpanded = Infragistics.Win.DefaultableBoolean.True;
            this.Toolbar_Options.DesignerFlags = 1;
            this.Toolbar_Options.DockWithinContainer = this;
            this.Toolbar_Options.DockWithinContainerBaseType = typeof(System.Windows.Forms.Form);
            this.Toolbar_Options.ImageSizeLarge = new System.Drawing.Size(64, 64);
            this.Toolbar_Options.MenuAnimationStyle = Infragistics.Win.UltraWinToolbars.MenuAnimationStyle.Random;
            this.Toolbar_Options.Ribbon.Caption = "";
            this.Toolbar_Options.ShowFullMenusDelay = 500;
            this.Toolbar_Options.Style = Infragistics.Win.UltraWinToolbars.ToolbarStyle.Office2013;
            ultraToolbar1.DockedColumn = 0;
            ultraToolbar1.DockedRow = 0;
            ultraToolbar1.FloatingLocation = new System.Drawing.Point(322, 313);
            ultraToolbar1.FloatingSize = new System.Drawing.Size(213, 280);
            ultraToolbar1.IsMainMenuBar = true;
            labelTool4.InstanceProps.Width = 73;
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            labelTool4,
            buttonTool2,
            buttonTool6,
            buttonTool10,
            buttonTool11,
            buttonTool9});
            ultraToolbar1.Text = "UltraToolbar1";
            this.Toolbar_Options.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.Toolbar_Options.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.True;
            this.Toolbar_Options.ToolbarSettings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.Toolbar_Options.ToolbarSettings.ToolOrientation = Infragistics.Win.UltraWinToolbars.ToolOrientation.Horizontal;
            this.Toolbar_Options.ToolbarSettings.UseLargeImages = Infragistics.Win.DefaultableBoolean.True;
            appearance1.Image = global::GoodShepherd.Properties.Resources._1468181667_file_add;
            buttonTool1.SharedPropsInternal.AppearancesLarge.Appearance = appearance1;
            buttonTool1.SharedPropsInternal.Caption = "جديد";
            buttonTool1.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            appearance2.Image = global::GoodShepherd.Properties.Resources._1468181872_document_save_as;
            buttonTool3.SharedPropsInternal.AppearancesLarge.Appearance = appearance2;
            buttonTool3.SharedPropsInternal.Caption = "حفظ";
            buttonTool3.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            appearance3.Image = global::GoodShepherd.Properties.Resources._1468181797_Close_Box_Red;
            buttonTool4.SharedPropsInternal.AppearancesLarge.Appearance = appearance3;
            buttonTool4.SharedPropsInternal.Caption = "حذف";
            buttonTool4.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            appearance4.Image = global::GoodShepherd.Properties.Resources._1468181962_shutdown;
            buttonTool5.SharedPropsInternal.AppearancesLarge.Appearance = appearance4;
            buttonTool5.SharedPropsInternal.Caption = "اغلاق";
            buttonTool5.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            appearance5.Image = global::GoodShepherd.Properties.Resources._1448741181_previous;
            buttonTool7.SharedPropsInternal.AppearancesLarge.Appearance = appearance5;
            buttonTool7.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
            buttonTool7.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.AltLeftArrow;
            appearance6.Image = global::GoodShepherd.Properties.Resources._1448741173_next;
            buttonTool8.SharedPropsInternal.AppearancesLarge.Appearance = appearance6;
            buttonTool8.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
            buttonTool8.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.AltRightArrow;
            controlContainerTool2.SharedPropsInternal.AllowMultipleInstances = true;
            controlContainerTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            controlContainerTool2.SharedPropsInternal.Width = 69;
            labelTool3.SharedPropsInternal.Caption = "    ";
            labelTool5.SharedPropsInternal.Caption = "          ";
            this.Toolbar_Options.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool1,
            buttonTool3,
            buttonTool4,
            buttonTool5,
            labelTool2,
            buttonTool7,
            buttonTool8,
            controlContainerTool2,
            labelTool3,
            labelTool5});
            this.Toolbar_Options.ToolClick += new Infragistics.Win.UltraWinToolbars.ToolClickEventHandler(this.Toolbar_Options_ToolClick);
            // 
            // _panel2_Toolbars_Dock_Area_Top
            // 
            this._panel2_Toolbars_Dock_Area_Top.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._panel2_Toolbars_Dock_Area_Top.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Top;
            this._panel2_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.Color.Black;
            this._panel2_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._panel2_Toolbars_Dock_Area_Top.Name = "_panel2_Toolbars_Dock_Area_Top";
            this._panel2_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(798, 71);
            this._panel2_Toolbars_Dock_Area_Top.ToolbarsManager = this.Toolbar_Options;
            // 
            // _panel2_Toolbars_Dock_Area_Bottom
            // 
            this._panel2_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._panel2_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._panel2_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.Color.Black;
            this._panel2_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 413);
            this._panel2_Toolbars_Dock_Area_Bottom.Name = "_panel2_Toolbars_Dock_Area_Bottom";
            this._panel2_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(798, 0);
            this._panel2_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Toolbar_Options;
            // 
            // _panel2_Toolbars_Dock_Area_Left
            // 
            this._panel2_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._panel2_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._panel2_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.Color.Black;
            this._panel2_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 96);
            this._panel2_Toolbars_Dock_Area_Left.Name = "_panel2_Toolbars_Dock_Area_Left";
            this._panel2_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 317);
            this._panel2_Toolbars_Dock_Area_Left.ToolbarsManager = this.Toolbar_Options;
            // 
            // _panel2_Toolbars_Dock_Area_Right
            // 
            this._panel2_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._panel2_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._panel2_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.Color.Black;
            this._panel2_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(798, 96);
            this._panel2_Toolbars_Dock_Area_Right.Name = "_panel2_Toolbars_Dock_Area_Right";
            this._panel2_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 317);
            this._panel2_Toolbars_Dock_Area_Right.ToolbarsManager = this.Toolbar_Options;
            // 
            // tBL_EducationLevelTableAdapter
            // 
            this.tBL_EducationLevelTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.TBL_CollageTableAdapter = this.tBL_CollageTableAdapter;
            this.tableAdapterManager.TBL_EducationLevelTableAdapter = this.tBL_EducationLevelTableAdapter;
            this.tableAdapterManager.TBL_EducYearTableAdapter = this.tBL_EducYearTableAdapter;
            this.tableAdapterManager.UpdateOrder = GoodShepherd.StudiesDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tBL_CollageTableAdapter
            // 
            this.tBL_CollageTableAdapter.ClearBeforeFill = true;
            // 
            // tBL_EducYearTableAdapter
            // 
            this.tBL_EducYearTableAdapter.ClearBeforeFill = true;
            // 
            // FRM_Studies
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 413);
            this.Controls.Add(this.GRD_Studies);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Right);
            this.Controls.Add(this.tBL_EducationLevelBindingNavigator);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Top);
            this.Name = "FRM_Studies";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FRM_Studies";
            this.ThemeName = "Office2010Black";
            this.Load += new System.EventHandler(this.FRM_Studies_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tBL_EducationLevelBindingNavigator)).EndInit();
            this.tBL_EducationLevelBindingNavigator.ResumeLayout(false);
            this.tBL_EducationLevelBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_EducationLevelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.studiesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_Studies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_EducYearBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_CollageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Toolbar_Options)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StudiesDataSet studiesDataSet;
        private System.Windows.Forms.BindingSource tBL_EducationLevelBindingSource;
        private StudiesDataSetTableAdapters.TBL_EducationLevelTableAdapter tBL_EducationLevelTableAdapter;
        private StudiesDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tBL_EducationLevelBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton tBL_EducationLevelBindingNavigatorSaveItem;
        private Infragistics.Win.UltraWinGrid.UltraGrid GRD_Studies;
        private StudiesDataSetTableAdapters.TBL_EducYearTableAdapter tBL_EducYearTableAdapter;
        private System.Windows.Forms.BindingSource tBL_EducYearBindingSource;
        private StudiesDataSetTableAdapters.TBL_CollageTableAdapter tBL_CollageTableAdapter;
        private System.Windows.Forms.BindingSource tBL_CollageBindingSource;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Toolbar_Options;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Top;
    }
}