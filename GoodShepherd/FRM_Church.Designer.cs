namespace GoodShepherd
{
    partial class FRM_Church
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
            System.Windows.Forms.Label iDLabel;
            System.Windows.Forms.Label city_IDLabel;
            System.Windows.Forms.Label area_IDLabel;
            System.Windows.Forms.Label street_IDLabel;
            System.Windows.Forms.Label churchNameLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Church));
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("VIW_Church", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn1 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID", -1, null, 0, Infragistics.Win.UltraWinGrid.SortIndicator.Ascending, false);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn2 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("City_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn3 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CityDesc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn4 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Area_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn5 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AreaDesc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn6 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Street_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn7 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StreetDesc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn8 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChurchName");
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
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("TBL_Services", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn25 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn26 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Church_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn27 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Service");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn28 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description");
            this.tBL_ChurchBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.tBL_ChurchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.adressDataSet = new GoodShepherd.AdressDataSet();
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
            this.tBL_ChurchBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.TXT_ID = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.CMX_City = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.tBLCityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CMX_Area = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.tBLAreaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CMX_Street = new Infragistics.Win.UltraWinEditors.UltraComboEditor();
            this.tBLStreetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.TXT_Church = new Infragistics.Win.UltraWinEditors.UltraTextEditor();
            this.GRD_Churches = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.vIW_ChurchBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Toolbar_Options = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._panel2_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel2_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel2_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel2_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.FRM_Church_Fill_Panel = new Infragistics.Win.Misc.UltraPanel();
            this.ultraGroupBox2 = new Infragistics.Win.Misc.UltraGroupBox();
            this.GRD_Services = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tBL_ServicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.GR_SearchDet = new Infragistics.Win.Misc.UltraGroupBox();
            this.ultraGroupBox1 = new Infragistics.Win.Misc.UltraGroupBox();
            this.tBL_ChurchTableAdapter = new GoodShepherd.AdressDataSetTableAdapters.TBL_ChurchTableAdapter();
            this.tableAdapterManager = new GoodShepherd.AdressDataSetTableAdapters.TableAdapterManager();
            this.tBL_CityTableAdapter = new GoodShepherd.AdressDataSetTableAdapters.TBL_CityTableAdapter();
            this.tBL_AreaTableAdapter = new GoodShepherd.AdressDataSetTableAdapters.TBL_AreaTableAdapter();
            this.tBL_StreetTableAdapter = new GoodShepherd.AdressDataSetTableAdapters.TBL_StreetTableAdapter();
            this.vIW_ChurchTableAdapter = new GoodShepherd.AdressDataSetTableAdapters.VIW_ChurchTableAdapter();
            this.tBL_ServicesTableAdapter = new GoodShepherd.AdressDataSetTableAdapters.TBL_ServicesTableAdapter();
            iDLabel = new System.Windows.Forms.Label();
            city_IDLabel = new System.Windows.Forms.Label();
            area_IDLabel = new System.Windows.Forms.Label();
            street_IDLabel = new System.Windows.Forms.Label();
            churchNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_ChurchBindingNavigator)).BeginInit();
            this.tBL_ChurchBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_ChurchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adressDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_ID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMX_City)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLCityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMX_Area)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLAreaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMX_Street)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLStreetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_Church)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_Churches)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIW_ChurchBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Toolbar_Options)).BeginInit();
            this.FRM_Church_Fill_Panel.ClientArea.SuspendLayout();
            this.FRM_Church_Fill_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).BeginInit();
            this.ultraGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_Services)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_ServicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GR_SearchDet)).BeginInit();
            this.GR_SearchDet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).BeginInit();
            this.ultraGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // iDLabel
            // 
            iDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            iDLabel.AutoSize = true;
            iDLabel.Location = new System.Drawing.Point(979, 24);
            iDLabel.Name = "iDLabel";
            iDLabel.Size = new System.Drawing.Size(21, 13);
            iDLabel.TabIndex = 1;
            iDLabel.Text = "ID:";
            iDLabel.Visible = false;
            // 
            // city_IDLabel
            // 
            city_IDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            city_IDLabel.AutoSize = true;
            city_IDLabel.Location = new System.Drawing.Point(360, 51);
            city_IDLabel.Name = "city_IDLabel";
            city_IDLabel.Size = new System.Drawing.Size(56, 13);
            city_IDLabel.TabIndex = 3;
            city_IDLabel.Text = "المحافظة :";
            // 
            // area_IDLabel
            // 
            area_IDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            area_IDLabel.AutoSize = true;
            area_IDLabel.Location = new System.Drawing.Point(368, 86);
            area_IDLabel.Name = "area_IDLabel";
            area_IDLabel.Size = new System.Drawing.Size(51, 13);
            area_IDLabel.TabIndex = 5;
            area_IDLabel.Text = "المنطقة :";
            // 
            // street_IDLabel
            // 
            street_IDLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            street_IDLabel.AutoSize = true;
            street_IDLabel.Location = new System.Drawing.Point(369, 121);
            street_IDLabel.Name = "street_IDLabel";
            street_IDLabel.Size = new System.Drawing.Size(44, 13);
            street_IDLabel.TabIndex = 7;
            street_IDLabel.Text = "الشارع :";
            // 
            // churchNameLabel
            // 
            churchNameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            churchNameLabel.AutoSize = true;
            churchNameLabel.Location = new System.Drawing.Point(345, 156);
            churchNameLabel.Name = "churchNameLabel";
            churchNameLabel.Size = new System.Drawing.Size(70, 13);
            churchNameLabel.TabIndex = 9;
            churchNameLabel.Text = "اسم الكنيسة :";
            // 
            // tBL_ChurchBindingNavigator
            // 
            this.tBL_ChurchBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tBL_ChurchBindingNavigator.BindingSource = this.tBL_ChurchBindingSource;
            this.tBL_ChurchBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tBL_ChurchBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tBL_ChurchBindingNavigator.Dock = System.Windows.Forms.DockStyle.None;
            this.tBL_ChurchBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.tBL_ChurchBindingNavigatorSaveItem});
            this.tBL_ChurchBindingNavigator.Location = new System.Drawing.Point(74, 112);
            this.tBL_ChurchBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tBL_ChurchBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tBL_ChurchBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tBL_ChurchBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tBL_ChurchBindingNavigator.Name = "tBL_ChurchBindingNavigator";
            this.tBL_ChurchBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tBL_ChurchBindingNavigator.Size = new System.Drawing.Size(278, 25);
            this.tBL_ChurchBindingNavigator.TabIndex = 0;
            this.tBL_ChurchBindingNavigator.Text = "bindingNavigator1";
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
            // tBL_ChurchBindingSource
            // 
            this.tBL_ChurchBindingSource.DataMember = "TBL_Church";
            this.tBL_ChurchBindingSource.DataSource = this.adressDataSet;
            // 
            // adressDataSet
            // 
            this.adressDataSet.DataSetName = "AdressDataSet";
            this.adressDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // tBL_ChurchBindingNavigatorSaveItem
            // 
            this.tBL_ChurchBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBL_ChurchBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tBL_ChurchBindingNavigatorSaveItem.Image")));
            this.tBL_ChurchBindingNavigatorSaveItem.Name = "tBL_ChurchBindingNavigatorSaveItem";
            this.tBL_ChurchBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.tBL_ChurchBindingNavigatorSaveItem.Text = "Save Data";
            this.tBL_ChurchBindingNavigatorSaveItem.Click += new System.EventHandler(this.tBL_ChurchBindingNavigatorSaveItem_Click);
            // 
            // TXT_ID
            // 
            this.TXT_ID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_ID.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tBL_ChurchBindingSource, "ID", true));
            this.TXT_ID.Location = new System.Drawing.Point(633, 20);
            this.TXT_ID.Name = "TXT_ID";
            this.TXT_ID.Size = new System.Drawing.Size(293, 21);
            this.TXT_ID.TabIndex = 2;
            // 
            // CMX_City
            // 
            this.CMX_City.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CMX_City.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tBL_ChurchBindingSource, "City_ID", true));
            this.CMX_City.DataSource = this.tBLCityBindingSource;
            this.CMX_City.DisplayMember = "CityDesc";
            this.CMX_City.Location = new System.Drawing.Point(46, 47);
            this.CMX_City.Name = "CMX_City";
            this.CMX_City.Size = new System.Drawing.Size(293, 21);
            this.CMX_City.TabIndex = 4;
            this.CMX_City.ValueMember = "ID";
            this.CMX_City.ValueChanged += new System.EventHandler(this.CMX_City_ValueChanged);
            // 
            // tBLCityBindingSource
            // 
            this.tBLCityBindingSource.DataMember = "TBL_City";
            this.tBLCityBindingSource.DataSource = this.adressDataSet;
            // 
            // CMX_Area
            // 
            this.CMX_Area.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CMX_Area.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tBL_ChurchBindingSource, "Area_ID", true));
            this.CMX_Area.DataSource = this.tBLAreaBindingSource;
            this.CMX_Area.DisplayMember = "AreaDesc";
            this.CMX_Area.Location = new System.Drawing.Point(46, 82);
            this.CMX_Area.Name = "CMX_Area";
            this.CMX_Area.Size = new System.Drawing.Size(293, 21);
            this.CMX_Area.TabIndex = 6;
            this.CMX_Area.ValueMember = "ID";
            this.CMX_Area.ValueChanged += new System.EventHandler(this.CMX_Area_ValueChanged);
            // 
            // tBLAreaBindingSource
            // 
            this.tBLAreaBindingSource.DataMember = "TBL_Area";
            this.tBLAreaBindingSource.DataSource = this.adressDataSet;
            // 
            // CMX_Street
            // 
            this.CMX_Street.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CMX_Street.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tBL_ChurchBindingSource, "Street_ID", true));
            this.CMX_Street.DataSource = this.tBLStreetBindingSource;
            this.CMX_Street.DisplayMember = "StreetDesc";
            this.CMX_Street.Location = new System.Drawing.Point(46, 117);
            this.CMX_Street.Name = "CMX_Street";
            this.CMX_Street.Size = new System.Drawing.Size(293, 21);
            this.CMX_Street.TabIndex = 8;
            this.CMX_Street.ValueMember = "ID";
            // 
            // tBLStreetBindingSource
            // 
            this.tBLStreetBindingSource.DataMember = "TBL_Street";
            this.tBLStreetBindingSource.DataSource = this.adressDataSet;
            // 
            // TXT_Church
            // 
            this.TXT_Church.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TXT_Church.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tBL_ChurchBindingSource, "ChurchName", true));
            this.TXT_Church.Location = new System.Drawing.Point(46, 152);
            this.TXT_Church.Name = "TXT_Church";
            this.TXT_Church.Size = new System.Drawing.Size(293, 21);
            this.TXT_Church.TabIndex = 10;
            // 
            // GRD_Churches
            // 
            this.GRD_Churches.DataSource = this.vIW_ChurchBindingSource;
            ultraGridColumn1.Header.VisiblePosition = 0;
            ultraGridColumn1.Hidden = true;
            ultraGridColumn2.Header.VisiblePosition = 1;
            ultraGridColumn2.Hidden = true;
            ultraGridColumn3.Header.Caption = "محافظة";
            ultraGridColumn3.Header.VisiblePosition = 2;
            ultraGridColumn3.Width = 120;
            ultraGridColumn4.Header.VisiblePosition = 3;
            ultraGridColumn4.Hidden = true;
            ultraGridColumn5.Header.Caption = "منطقة";
            ultraGridColumn5.Header.VisiblePosition = 4;
            ultraGridColumn5.Width = 120;
            ultraGridColumn6.Header.VisiblePosition = 5;
            ultraGridColumn6.Hidden = true;
            ultraGridColumn7.Header.Caption = "شارع";
            ultraGridColumn7.Header.VisiblePosition = 6;
            ultraGridColumn7.Width = 120;
            ultraGridColumn8.Header.Caption = "كنيسة";
            ultraGridColumn8.Header.VisiblePosition = 7;
            ultraGridColumn8.Width = 166;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn1,
            ultraGridColumn2,
            ultraGridColumn3,
            ultraGridColumn4,
            ultraGridColumn5,
            ultraGridColumn6,
            ultraGridColumn7,
            ultraGridColumn8});
            this.GRD_Churches.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.GRD_Churches.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.GRD_Churches.DisplayLayout.Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.GRD_Churches.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.GRD_Churches.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
            this.GRD_Churches.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.GRD_Churches.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRD_Churches.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRD_Churches.Location = new System.Drawing.Point(3, 19);
            this.GRD_Churches.Name = "GRD_Churches";
            this.GRD_Churches.Size = new System.Drawing.Size(581, 367);
            this.GRD_Churches.TabIndex = 11;
            this.GRD_Churches.Text = "ultraGrid1";
            this.GRD_Churches.AfterRowActivate += new System.EventHandler(this.vIW_ChurchUltraGrid_AfterRowActivate);
            // 
            // vIW_ChurchBindingSource
            // 
            this.vIW_ChurchBindingSource.DataMember = "VIW_Church";
            this.vIW_ChurchBindingSource.DataSource = this.adressDataSet;
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
            this._panel2_Toolbars_Dock_Area_Top.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panel2_Toolbars_Dock_Area_Top.Location = new System.Drawing.Point(0, 0);
            this._panel2_Toolbars_Dock_Area_Top.Name = "_panel2_Toolbars_Dock_Area_Top";
            this._panel2_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(1031, 71);
            this._panel2_Toolbars_Dock_Area_Top.ToolbarsManager = this.Toolbar_Options;
            // 
            // _panel2_Toolbars_Dock_Area_Bottom
            // 
            this._panel2_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._panel2_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._panel2_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panel2_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 460);
            this._panel2_Toolbars_Dock_Area_Bottom.Name = "_panel2_Toolbars_Dock_Area_Bottom";
            this._panel2_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(1031, 0);
            this._panel2_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Toolbar_Options;
            // 
            // _panel2_Toolbars_Dock_Area_Left
            // 
            this._panel2_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._panel2_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._panel2_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panel2_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 71);
            this._panel2_Toolbars_Dock_Area_Left.Name = "_panel2_Toolbars_Dock_Area_Left";
            this._panel2_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 389);
            this._panel2_Toolbars_Dock_Area_Left.ToolbarsManager = this.Toolbar_Options;
            // 
            // _panel2_Toolbars_Dock_Area_Right
            // 
            this._panel2_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._panel2_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._panel2_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.SystemColors.ControlText;
            this._panel2_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(1031, 71);
            this._panel2_Toolbars_Dock_Area_Right.Name = "_panel2_Toolbars_Dock_Area_Right";
            this._panel2_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 389);
            this._panel2_Toolbars_Dock_Area_Right.ToolbarsManager = this.Toolbar_Options;
            // 
            // FRM_Church_Fill_Panel
            // 
            // 
            // FRM_Church_Fill_Panel.ClientArea
            // 
            this.FRM_Church_Fill_Panel.ClientArea.Controls.Add(this.ultraGroupBox2);
            this.FRM_Church_Fill_Panel.ClientArea.Controls.Add(this.TXT_ID);
            this.FRM_Church_Fill_Panel.ClientArea.Controls.Add(this.GR_SearchDet);
            this.FRM_Church_Fill_Panel.ClientArea.Controls.Add(this.ultraGroupBox1);
            this.FRM_Church_Fill_Panel.ClientArea.Controls.Add(this.tBL_ChurchBindingNavigator);
            this.FRM_Church_Fill_Panel.ClientArea.Controls.Add(iDLabel);
            this.FRM_Church_Fill_Panel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FRM_Church_Fill_Panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FRM_Church_Fill_Panel.Location = new System.Drawing.Point(0, 71);
            this.FRM_Church_Fill_Panel.Name = "FRM_Church_Fill_Panel";
            this.FRM_Church_Fill_Panel.Size = new System.Drawing.Size(1031, 389);
            this.FRM_Church_Fill_Panel.TabIndex = 20;
            // 
            // ultraGroupBox2
            // 
            this.ultraGroupBox2.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Far;
            this.ultraGroupBox2.Controls.Add(this.GRD_Services);
            this.ultraGroupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ultraGroupBox2.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder;
            this.ultraGroupBox2.Location = new System.Drawing.Point(587, 182);
            this.ultraGroupBox2.Name = "ultraGroupBox2";
            this.ultraGroupBox2.Size = new System.Drawing.Size(444, 207);
            this.ultraGroupBox2.TabIndex = 167;
            this.ultraGroupBox2.Text = "خدمات الكنيسة";
            // 
            // GRD_Services
            // 
            this.GRD_Services.DataSource = this.tBL_ServicesBindingSource;
            ultraGridColumn25.Header.VisiblePosition = 0;
            ultraGridColumn25.Hidden = true;
            ultraGridColumn26.Header.VisiblePosition = 1;
            ultraGridColumn26.Hidden = true;
            ultraGridColumn27.Header.Caption = "اسم الخدمة";
            ultraGridColumn27.Header.VisiblePosition = 2;
            ultraGridColumn27.Width = 141;
            ultraGridColumn28.Header.Caption = "وصف الخدمة";
            ultraGridColumn28.Header.VisiblePosition = 3;
            ultraGridColumn28.Width = 246;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn25,
            ultraGridColumn26,
            ultraGridColumn27,
            ultraGridColumn28});
            this.GRD_Services.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.GRD_Services.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.GRD_Services.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.GRD_Services.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRD_Services.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRD_Services.Location = new System.Drawing.Point(3, 19);
            this.GRD_Services.Name = "GRD_Services";
            this.GRD_Services.Size = new System.Drawing.Size(438, 185);
            this.GRD_Services.TabIndex = 0;
            this.GRD_Services.Text = "ultraGrid1";
            // 
            // tBL_ServicesBindingSource
            // 
            this.tBL_ServicesBindingSource.DataMember = "TBL_Services";
            this.tBL_ServicesBindingSource.DataSource = this.adressDataSet;
            // 
            // GR_SearchDet
            // 
            this.GR_SearchDet.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Far;
            this.GR_SearchDet.Controls.Add(this.TXT_Church);
            this.GR_SearchDet.Controls.Add(churchNameLabel);
            this.GR_SearchDet.Controls.Add(this.CMX_Street);
            this.GR_SearchDet.Controls.Add(street_IDLabel);
            this.GR_SearchDet.Controls.Add(this.CMX_Area);
            this.GR_SearchDet.Controls.Add(city_IDLabel);
            this.GR_SearchDet.Controls.Add(area_IDLabel);
            this.GR_SearchDet.Controls.Add(this.CMX_City);
            this.GR_SearchDet.Dock = System.Windows.Forms.DockStyle.Top;
            this.GR_SearchDet.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder;
            this.GR_SearchDet.Location = new System.Drawing.Point(587, 0);
            this.GR_SearchDet.Name = "GR_SearchDet";
            this.GR_SearchDet.Size = new System.Drawing.Size(444, 182);
            this.GR_SearchDet.TabIndex = 166;
            this.GR_SearchDet.Text = "بيانات الكنيسة";
            // 
            // ultraGroupBox1
            // 
            this.ultraGroupBox1.CaptionAlignment = Infragistics.Win.Misc.GroupBoxCaptionAlignment.Far;
            this.ultraGroupBox1.Controls.Add(this.GRD_Churches);
            this.ultraGroupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ultraGroupBox1.HeaderPosition = Infragistics.Win.Misc.GroupBoxHeaderPosition.TopOnBorder;
            this.ultraGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.ultraGroupBox1.Name = "ultraGroupBox1";
            this.ultraGroupBox1.Size = new System.Drawing.Size(587, 389);
            this.ultraGroupBox1.TabIndex = 167;
            this.ultraGroupBox1.Text = "كل الكنايس";
            // 
            // tBL_ChurchTableAdapter
            // 
            this.tBL_ChurchTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.TBL_AreaTableAdapter = null;
            this.tableAdapterManager.TBL_ChurchTableAdapter = this.tBL_ChurchTableAdapter;
            this.tableAdapterManager.TBL_CityTableAdapter = null;
            this.tableAdapterManager.TBL_ServicesTableAdapter = null;
            this.tableAdapterManager.TBL_StreetTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = GoodShepherd.AdressDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tBL_CityTableAdapter
            // 
            this.tBL_CityTableAdapter.ClearBeforeFill = true;
            // 
            // tBL_AreaTableAdapter
            // 
            this.tBL_AreaTableAdapter.ClearBeforeFill = true;
            // 
            // tBL_StreetTableAdapter
            // 
            this.tBL_StreetTableAdapter.ClearBeforeFill = true;
            // 
            // vIW_ChurchTableAdapter
            // 
            this.vIW_ChurchTableAdapter.ClearBeforeFill = true;
            // 
            // tBL_ServicesTableAdapter
            // 
            this.tBL_ServicesTableAdapter.ClearBeforeFill = true;
            // 
            // FRM_Church
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 460);
            this.Controls.Add(this.FRM_Church_Fill_Panel);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Top);
            this.Name = "FRM_Church";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "الكنائس والخدمات";
            this.ThemeName = "Office2007Black";
            this.Load += new System.EventHandler(this.FRM_Church_Load);
            this.Enter += new System.EventHandler(this.FRM_Church_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.tBL_ChurchBindingNavigator)).EndInit();
            this.tBL_ChurchBindingNavigator.ResumeLayout(false);
            this.tBL_ChurchBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_ChurchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adressDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_ID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMX_City)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLCityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMX_Area)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLAreaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMX_Street)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBLStreetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TXT_Church)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_Churches)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIW_ChurchBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Toolbar_Options)).EndInit();
            this.FRM_Church_Fill_Panel.ClientArea.ResumeLayout(false);
            this.FRM_Church_Fill_Panel.ClientArea.PerformLayout();
            this.FRM_Church_Fill_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox2)).EndInit();
            this.ultraGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GRD_Services)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_ServicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GR_SearchDet)).EndInit();
            this.GR_SearchDet.ResumeLayout(false);
            this.GR_SearchDet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ultraGroupBox1)).EndInit();
            this.ultraGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private AdressDataSet adressDataSet;
        private System.Windows.Forms.BindingSource tBL_ChurchBindingSource;
        private AdressDataSetTableAdapters.TBL_ChurchTableAdapter tBL_ChurchTableAdapter;
        private AdressDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tBL_ChurchBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton tBL_ChurchBindingNavigatorSaveItem;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TXT_ID;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor CMX_City;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor CMX_Area;
        private Infragistics.Win.UltraWinEditors.UltraComboEditor CMX_Street;
        private Infragistics.Win.UltraWinEditors.UltraTextEditor TXT_Church;
        private System.Windows.Forms.BindingSource tBLCityBindingSource;
        private AdressDataSetTableAdapters.TBL_CityTableAdapter tBL_CityTableAdapter;
        private System.Windows.Forms.BindingSource tBLAreaBindingSource;
        private AdressDataSetTableAdapters.TBL_AreaTableAdapter tBL_AreaTableAdapter;
        private System.Windows.Forms.BindingSource tBLStreetBindingSource;
        private AdressDataSetTableAdapters.TBL_StreetTableAdapter tBL_StreetTableAdapter;
        private System.Windows.Forms.BindingSource vIW_ChurchBindingSource;
        private AdressDataSetTableAdapters.VIW_ChurchTableAdapter vIW_ChurchTableAdapter;
        private Infragistics.Win.UltraWinGrid.UltraGrid GRD_Churches;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Toolbar_Options;
        private Infragistics.Win.Misc.UltraPanel FRM_Church_Fill_Panel;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Top;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox2;
        private Infragistics.Win.Misc.UltraGroupBox GR_SearchDet;
        private Infragistics.Win.Misc.UltraGroupBox ultraGroupBox1;
        private System.Windows.Forms.BindingSource tBL_ServicesBindingSource;
        private AdressDataSetTableAdapters.TBL_ServicesTableAdapter tBL_ServicesTableAdapter;
        private Infragistics.Win.UltraWinGrid.UltraGrid GRD_Services;
    }
}