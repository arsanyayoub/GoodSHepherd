namespace GoodShepherd
{
    partial class FRM_Adress
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Adress));
            Infragistics.Win.Appearance appearance1 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand1 = new Infragistics.Win.UltraWinGrid.UltraGridBand("TBL_City", -1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn16 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn17 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("CityDesc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn18 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_TBL_Area_TBL_City");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn19 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_TBL_Church_TBL_City");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand2 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_TBL_Area_TBL_City", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn48 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn49 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("City_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn50 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("AreaDesc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn51 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_TBL_Church_TBL_Area");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn52 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_TBL_Street_TBL_Area");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand3 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_TBL_Church_TBL_Area", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn53 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn54 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("City_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn55 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Area_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn56 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Street_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn57 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChurchName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn58 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_TBL_Services_TBL_Church");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand4 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_TBL_Services_TBL_Church", 2);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn59 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn60 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Church_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn61 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Service");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn62 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand5 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_TBL_Street_TBL_Area", 1);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn63 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn64 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Area_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn65 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("StreetDesc");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn66 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_TBL_Church_TBL_Street");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand6 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_TBL_Church_TBL_Street", 4);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn67 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn68 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("City_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn69 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Area_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn70 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Street_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn71 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChurchName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn72 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_TBL_Services_TBL_Church");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand7 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_TBL_Services_TBL_Church", 5);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn73 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn74 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Church_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn75 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Service");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn76 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand8 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_TBL_Church_TBL_City", 0);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn77 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn78 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("City_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn79 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Area_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn80 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Street_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn81 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ChurchName");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn82 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("FK_TBL_Services_TBL_Church");
            Infragistics.Win.UltraWinGrid.UltraGridBand ultraGridBand9 = new Infragistics.Win.UltraWinGrid.UltraGridBand("FK_TBL_Services_TBL_Church", 7);
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn83 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn84 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Church_ID");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn85 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Service");
            Infragistics.Win.UltraWinGrid.UltraGridColumn ultraGridColumn86 = new Infragistics.Win.UltraWinGrid.UltraGridColumn("Description");
            Infragistics.Win.Appearance appearance2 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.UltraToolbar ultraToolbar1 = new Infragistics.Win.UltraWinToolbars.UltraToolbar("UltraToolbar1");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool4 = new Infragistics.Win.UltraWinToolbars.LabelTool("          ");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool6 = new Infragistics.Win.UltraWinToolbars.LabelTool("                                                       ");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool13 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Previous");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool14 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Next");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool15 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Delete");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool16 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Save");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool17 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_New");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool18 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_New");
            Infragistics.Win.Appearance appearance3 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool19 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Save");
            Infragistics.Win.Appearance appearance4 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool20 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Delete");
            Infragistics.Win.Appearance appearance5 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool21 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Exit");
            Infragistics.Win.Appearance appearance6 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool7 = new Infragistics.Win.UltraWinToolbars.LabelTool("LabelTool1");
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool22 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Previous");
            Infragistics.Win.Appearance appearance7 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ButtonTool buttonTool23 = new Infragistics.Win.UltraWinToolbars.ButtonTool("BTN_Next");
            Infragistics.Win.Appearance appearance8 = new Infragistics.Win.Appearance();
            Infragistics.Win.UltraWinToolbars.ControlContainerTool controlContainerTool2 = new Infragistics.Win.UltraWinToolbars.ControlContainerTool("TXT_FindByCode");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool3 = new Infragistics.Win.UltraWinToolbars.LabelTool("    ");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool5 = new Infragistics.Win.UltraWinToolbars.LabelTool("          ");
            Infragistics.Win.UltraWinToolbars.LabelTool labelTool8 = new Infragistics.Win.UltraWinToolbars.LabelTool("                                                       ");
            this.adressDataSet = new GoodShepherd.AdressDataSet();
            this.tBL_CityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tBL_CityTableAdapter = new GoodShepherd.AdressDataSetTableAdapters.TBL_CityTableAdapter();
            this.tableAdapterManager = new GoodShepherd.AdressDataSetTableAdapters.TableAdapterManager();
            this.tBL_CityBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
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
            this.tBL_CityBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.GRD_City = new Infragistics.Win.UltraWinGrid.UltraGrid();
            this.tBL_AreaTableAdapter = new GoodShepherd.AdressDataSetTableAdapters.TBL_AreaTableAdapter();
            this.tBL_StreetTableAdapter = new GoodShepherd.AdressDataSetTableAdapters.TBL_StreetTableAdapter();
            this.Toolbar_Options = new Infragistics.Win.UltraWinToolbars.UltraToolbarsManager(this.components);
            this._panel2_Toolbars_Dock_Area_Top = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel2_Toolbars_Dock_Area_Bottom = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel2_Toolbars_Dock_Area_Left = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this._panel2_Toolbars_Dock_Area_Right = new Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea();
            this.goodShepherdDataSet = new GoodShepherd.GoodShepherdDataSet();
            this.vIWGetPeopleData1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vIW_GetPeopleData1TableAdapter = new GoodShepherd.GoodShepherdDataSetTableAdapters.VIW_GetPeopleData1TableAdapter();
            this.tBL_AreaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tBL_StreetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.adressDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_CityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_CityBindingNavigator)).BeginInit();
            this.tBL_CityBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_City)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Toolbar_Options)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodShepherdDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIWGetPeopleData1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_AreaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_StreetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // adressDataSet
            // 
            this.adressDataSet.DataSetName = "AdressDataSet";
            this.adressDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tBL_CityBindingSource
            // 
            this.tBL_CityBindingSource.DataMember = "TBL_City";
            this.tBL_CityBindingSource.DataSource = this.adressDataSet;
            // 
            // tBL_CityTableAdapter
            // 
            this.tBL_CityTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.TBL_AreaTableAdapter = null;
            this.tableAdapterManager.TBL_ChurchTableAdapter = null;
            this.tableAdapterManager.TBL_CityTableAdapter = this.tBL_CityTableAdapter;
            this.tableAdapterManager.TBL_ServicesTableAdapter = null;
            this.tableAdapterManager.TBL_StreetTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = GoodShepherd.AdressDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // tBL_CityBindingNavigator
            // 
            this.tBL_CityBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.tBL_CityBindingNavigator.BindingSource = this.tBL_CityBindingSource;
            this.tBL_CityBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.tBL_CityBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.tBL_CityBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.tBL_CityBindingNavigatorSaveItem});
            this.tBL_CityBindingNavigator.Location = new System.Drawing.Point(0, 71);
            this.tBL_CityBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.tBL_CityBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.tBL_CityBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.tBL_CityBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.tBL_CityBindingNavigator.Name = "tBL_CityBindingNavigator";
            this.tBL_CityBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.tBL_CityBindingNavigator.Size = new System.Drawing.Size(802, 25);
            this.tBL_CityBindingNavigator.TabIndex = 0;
            this.tBL_CityBindingNavigator.Text = "bindingNavigator1";
            this.tBL_CityBindingNavigator.Visible = false;
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
            // tBL_CityBindingNavigatorSaveItem
            // 
            this.tBL_CityBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tBL_CityBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("tBL_CityBindingNavigatorSaveItem.Image")));
            this.tBL_CityBindingNavigatorSaveItem.Name = "tBL_CityBindingNavigatorSaveItem";
            this.tBL_CityBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
            this.tBL_CityBindingNavigatorSaveItem.Text = "Save Data";
            this.tBL_CityBindingNavigatorSaveItem.Click += new System.EventHandler(this.tBL_CityBindingNavigatorSaveItem_Click);
            // 
            // GRD_City
            // 
            this.GRD_City.DataSource = this.tBL_CityBindingSource;
            appearance1.TextHAlignAsString = "Center";
            appearance1.TextVAlignAsString = "Middle";
            this.GRD_City.DisplayLayout.Appearance = appearance1;
            ultraGridColumn16.Header.VisiblePosition = 0;
            ultraGridColumn16.Hidden = true;
            ultraGridColumn17.Header.Caption = "المحافظة";
            ultraGridColumn17.Header.VisiblePosition = 1;
            ultraGridColumn17.Width = 328;
            ultraGridColumn18.Header.VisiblePosition = 2;
            ultraGridColumn19.Header.VisiblePosition = 3;
            ultraGridBand1.Columns.AddRange(new object[] {
            ultraGridColumn16,
            ultraGridColumn17,
            ultraGridColumn18,
            ultraGridColumn19});
            ultraGridColumn48.Header.VisiblePosition = 0;
            ultraGridColumn48.Hidden = true;
            ultraGridColumn49.Header.VisiblePosition = 1;
            ultraGridColumn49.Hidden = true;
            ultraGridColumn49.Width = 206;
            ultraGridColumn50.Header.Caption = "المنطقة";
            ultraGridColumn50.Header.VisiblePosition = 2;
            ultraGridColumn50.Width = 309;
            ultraGridColumn51.Header.VisiblePosition = 3;
            ultraGridColumn52.Header.VisiblePosition = 4;
            ultraGridBand2.Columns.AddRange(new object[] {
            ultraGridColumn48,
            ultraGridColumn49,
            ultraGridColumn50,
            ultraGridColumn51,
            ultraGridColumn52});
            ultraGridColumn53.Header.VisiblePosition = 0;
            ultraGridColumn54.Header.VisiblePosition = 1;
            ultraGridColumn54.Width = 206;
            ultraGridColumn55.Header.VisiblePosition = 2;
            ultraGridColumn56.Header.VisiblePosition = 3;
            ultraGridColumn57.Header.VisiblePosition = 4;
            ultraGridColumn58.Header.VisiblePosition = 5;
            ultraGridBand3.Columns.AddRange(new object[] {
            ultraGridColumn53,
            ultraGridColumn54,
            ultraGridColumn55,
            ultraGridColumn56,
            ultraGridColumn57,
            ultraGridColumn58});
            ultraGridBand3.Hidden = true;
            ultraGridColumn59.Header.VisiblePosition = 0;
            ultraGridColumn60.Header.VisiblePosition = 1;
            ultraGridColumn61.Header.VisiblePosition = 2;
            ultraGridColumn62.Header.VisiblePosition = 3;
            ultraGridBand4.Columns.AddRange(new object[] {
            ultraGridColumn59,
            ultraGridColumn60,
            ultraGridColumn61,
            ultraGridColumn62});
            ultraGridColumn63.Header.VisiblePosition = 0;
            ultraGridColumn63.Hidden = true;
            ultraGridColumn64.Header.VisiblePosition = 1;
            ultraGridColumn64.Hidden = true;
            ultraGridColumn64.Width = 206;
            ultraGridColumn65.Header.Caption = "الشارع";
            ultraGridColumn65.Header.VisiblePosition = 2;
            ultraGridColumn65.Width = 290;
            ultraGridColumn66.Header.VisiblePosition = 3;
            ultraGridBand5.Columns.AddRange(new object[] {
            ultraGridColumn63,
            ultraGridColumn64,
            ultraGridColumn65,
            ultraGridColumn66});
            ultraGridColumn67.Header.VisiblePosition = 0;
            ultraGridColumn68.Header.VisiblePosition = 1;
            ultraGridColumn68.Width = 206;
            ultraGridColumn69.Header.VisiblePosition = 2;
            ultraGridColumn70.Header.VisiblePosition = 3;
            ultraGridColumn71.Header.VisiblePosition = 4;
            ultraGridColumn72.Header.VisiblePosition = 5;
            ultraGridBand6.Columns.AddRange(new object[] {
            ultraGridColumn67,
            ultraGridColumn68,
            ultraGridColumn69,
            ultraGridColumn70,
            ultraGridColumn71,
            ultraGridColumn72});
            ultraGridBand6.Hidden = true;
            ultraGridColumn73.Header.VisiblePosition = 0;
            ultraGridColumn74.Header.VisiblePosition = 1;
            ultraGridColumn75.Header.VisiblePosition = 2;
            ultraGridColumn76.Header.VisiblePosition = 3;
            ultraGridBand7.Columns.AddRange(new object[] {
            ultraGridColumn73,
            ultraGridColumn74,
            ultraGridColumn75,
            ultraGridColumn76});
            ultraGridColumn77.Header.VisiblePosition = 0;
            ultraGridColumn78.Header.VisiblePosition = 1;
            ultraGridColumn78.Width = 206;
            ultraGridColumn79.Header.VisiblePosition = 2;
            ultraGridColumn80.Header.VisiblePosition = 3;
            ultraGridColumn81.Header.VisiblePosition = 4;
            ultraGridColumn82.Header.VisiblePosition = 5;
            ultraGridBand8.Columns.AddRange(new object[] {
            ultraGridColumn77,
            ultraGridColumn78,
            ultraGridColumn79,
            ultraGridColumn80,
            ultraGridColumn81,
            ultraGridColumn82});
            ultraGridBand8.Hidden = true;
            ultraGridColumn83.Header.VisiblePosition = 0;
            ultraGridColumn84.Header.VisiblePosition = 1;
            ultraGridColumn85.Header.VisiblePosition = 2;
            ultraGridColumn86.Header.VisiblePosition = 3;
            ultraGridBand9.Columns.AddRange(new object[] {
            ultraGridColumn83,
            ultraGridColumn84,
            ultraGridColumn85,
            ultraGridColumn86});
            this.GRD_City.DisplayLayout.BandsSerializer.Add(ultraGridBand1);
            this.GRD_City.DisplayLayout.BandsSerializer.Add(ultraGridBand2);
            this.GRD_City.DisplayLayout.BandsSerializer.Add(ultraGridBand3);
            this.GRD_City.DisplayLayout.BandsSerializer.Add(ultraGridBand4);
            this.GRD_City.DisplayLayout.BandsSerializer.Add(ultraGridBand5);
            this.GRD_City.DisplayLayout.BandsSerializer.Add(ultraGridBand6);
            this.GRD_City.DisplayLayout.BandsSerializer.Add(ultraGridBand7);
            this.GRD_City.DisplayLayout.BandsSerializer.Add(ultraGridBand8);
            this.GRD_City.DisplayLayout.BandsSerializer.Add(ultraGridBand9);
            this.GRD_City.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
            this.GRD_City.DisplayLayout.MaxColScrollRegions = 1;
            this.GRD_City.DisplayLayout.MaxRowScrollRegions = 1;
            this.GRD_City.DisplayLayout.Override.AllowAddNew = Infragistics.Win.UltraWinGrid.AllowAddNew.TemplateOnBottom;
            this.GRD_City.DisplayLayout.Override.AllowDelete = Infragistics.Win.DefaultableBoolean.True;
            this.GRD_City.DisplayLayout.Override.AllowRowFiltering = Infragistics.Win.DefaultableBoolean.True;
            this.GRD_City.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
            this.GRD_City.DisplayLayout.Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
            this.GRD_City.DisplayLayout.Override.FilterClearButtonLocation = Infragistics.Win.UltraWinGrid.FilterClearButtonLocation.RowAndCell;
            this.GRD_City.DisplayLayout.Override.FilterOperatorDefaultValue = Infragistics.Win.UltraWinGrid.FilterOperatorDefaultValue.Contains;
            this.GRD_City.DisplayLayout.Override.FilterUIType = Infragistics.Win.UltraWinGrid.FilterUIType.FilterRow;
            appearance2.FontData.BoldAsString = "True";
            this.GRD_City.DisplayLayout.Override.HeaderAppearance = appearance2;
            this.GRD_City.DisplayLayout.Override.HeaderClickAction = Infragistics.Win.UltraWinGrid.HeaderClickAction.SortMulti;
            this.GRD_City.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GRD_City.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GRD_City.Location = new System.Drawing.Point(0, 71);
            this.GRD_City.Name = "GRD_City";
            this.GRD_City.Size = new System.Drawing.Size(802, 318);
            this.GRD_City.TabIndex = 1;
            this.GRD_City.Text = "ultraGrid1";
            this.GRD_City.BeforeRowExpanded += new Infragistics.Win.UltraWinGrid.CancelableRowEventHandler(this.GRD_City_BeforeRowExpanded);
            this.GRD_City.CellChange += new Infragistics.Win.UltraWinGrid.CellEventHandler(this.tBL_CityUltraGrid_CellChange);
            // 
            // tBL_AreaTableAdapter
            // 
            this.tBL_AreaTableAdapter.ClearBeforeFill = true;
            // 
            // tBL_StreetTableAdapter
            // 
            this.tBL_StreetTableAdapter.ClearBeforeFill = true;
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
            ultraToolbar1.NonInheritedTools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            labelTool4,
            labelTool6,
            buttonTool13,
            buttonTool14,
            buttonTool15,
            buttonTool16,
            buttonTool17});
            ultraToolbar1.Text = "UltraToolbar1";
            this.Toolbar_Options.Toolbars.AddRange(new Infragistics.Win.UltraWinToolbars.UltraToolbar[] {
            ultraToolbar1});
            this.Toolbar_Options.ToolbarSettings.AllowFloating = Infragistics.Win.DefaultableBoolean.True;
            this.Toolbar_Options.ToolbarSettings.ToolDisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.ImageAndText;
            this.Toolbar_Options.ToolbarSettings.ToolOrientation = Infragistics.Win.UltraWinToolbars.ToolOrientation.Horizontal;
            this.Toolbar_Options.ToolbarSettings.UseLargeImages = Infragistics.Win.DefaultableBoolean.True;
            appearance3.Image = global::GoodShepherd.Properties.Resources._1468181667_file_add;
            buttonTool18.SharedPropsInternal.AppearancesLarge.Appearance = appearance3;
            buttonTool18.SharedPropsInternal.Caption = "جديد";
            buttonTool18.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            appearance4.Image = global::GoodShepherd.Properties.Resources._1468181872_document_save_as;
            buttonTool19.SharedPropsInternal.AppearancesLarge.Appearance = appearance4;
            buttonTool19.SharedPropsInternal.Caption = "حفظ";
            buttonTool19.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
            appearance5.Image = global::GoodShepherd.Properties.Resources._1468181797_Close_Box_Red;
            buttonTool20.SharedPropsInternal.AppearancesLarge.Appearance = appearance5;
            buttonTool20.SharedPropsInternal.Caption = "حذف";
            buttonTool20.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            appearance6.Image = global::GoodShepherd.Properties.Resources._1468181962_shutdown;
            buttonTool21.SharedPropsInternal.AppearancesLarge.Appearance = appearance6;
            buttonTool21.SharedPropsInternal.Caption = "اغلاق";
            buttonTool21.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            appearance7.Image = global::GoodShepherd.Properties.Resources._1448741181_previous;
            buttonTool22.SharedPropsInternal.AppearancesLarge.Appearance = appearance7;
            buttonTool22.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
            buttonTool22.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.AltLeftArrow;
            appearance8.Image = global::GoodShepherd.Properties.Resources._1448741173_next;
            buttonTool23.SharedPropsInternal.AppearancesLarge.Appearance = appearance8;
            buttonTool23.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.DefaultForToolType;
            buttonTool23.SharedPropsInternal.Shortcut = System.Windows.Forms.Shortcut.AltRightArrow;
            controlContainerTool2.SharedPropsInternal.AllowMultipleInstances = true;
            controlContainerTool2.SharedPropsInternal.DisplayStyle = Infragistics.Win.UltraWinToolbars.ToolDisplayStyle.TextOnlyAlways;
            controlContainerTool2.SharedPropsInternal.Width = 69;
            labelTool3.SharedPropsInternal.Caption = "    ";
            labelTool5.SharedPropsInternal.Caption = "          ";
            labelTool8.SharedPropsInternal.Caption = "                                                       ";
            this.Toolbar_Options.Tools.AddRange(new Infragistics.Win.UltraWinToolbars.ToolBase[] {
            buttonTool18,
            buttonTool19,
            buttonTool20,
            buttonTool21,
            labelTool7,
            buttonTool22,
            buttonTool23,
            controlContainerTool2,
            labelTool3,
            labelTool5,
            labelTool8});
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
            this._panel2_Toolbars_Dock_Area_Top.Size = new System.Drawing.Size(802, 71);
            this._panel2_Toolbars_Dock_Area_Top.ToolbarsManager = this.Toolbar_Options;
            // 
            // _panel2_Toolbars_Dock_Area_Bottom
            // 
            this._panel2_Toolbars_Dock_Area_Bottom.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Bottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._panel2_Toolbars_Dock_Area_Bottom.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Bottom;
            this._panel2_Toolbars_Dock_Area_Bottom.ForeColor = System.Drawing.Color.Black;
            this._panel2_Toolbars_Dock_Area_Bottom.Location = new System.Drawing.Point(0, 389);
            this._panel2_Toolbars_Dock_Area_Bottom.Name = "_panel2_Toolbars_Dock_Area_Bottom";
            this._panel2_Toolbars_Dock_Area_Bottom.Size = new System.Drawing.Size(802, 0);
            this._panel2_Toolbars_Dock_Area_Bottom.ToolbarsManager = this.Toolbar_Options;
            // 
            // _panel2_Toolbars_Dock_Area_Left
            // 
            this._panel2_Toolbars_Dock_Area_Left.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Left.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._panel2_Toolbars_Dock_Area_Left.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Left;
            this._panel2_Toolbars_Dock_Area_Left.ForeColor = System.Drawing.Color.Black;
            this._panel2_Toolbars_Dock_Area_Left.Location = new System.Drawing.Point(0, 71);
            this._panel2_Toolbars_Dock_Area_Left.Name = "_panel2_Toolbars_Dock_Area_Left";
            this._panel2_Toolbars_Dock_Area_Left.Size = new System.Drawing.Size(0, 318);
            this._panel2_Toolbars_Dock_Area_Left.ToolbarsManager = this.Toolbar_Options;
            // 
            // _panel2_Toolbars_Dock_Area_Right
            // 
            this._panel2_Toolbars_Dock_Area_Right.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this._panel2_Toolbars_Dock_Area_Right.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this._panel2_Toolbars_Dock_Area_Right.DockedPosition = Infragistics.Win.UltraWinToolbars.DockedPosition.Right;
            this._panel2_Toolbars_Dock_Area_Right.ForeColor = System.Drawing.Color.Black;
            this._panel2_Toolbars_Dock_Area_Right.Location = new System.Drawing.Point(802, 71);
            this._panel2_Toolbars_Dock_Area_Right.Name = "_panel2_Toolbars_Dock_Area_Right";
            this._panel2_Toolbars_Dock_Area_Right.Size = new System.Drawing.Size(0, 318);
            this._panel2_Toolbars_Dock_Area_Right.ToolbarsManager = this.Toolbar_Options;
            // 
            // goodShepherdDataSet
            // 
            this.goodShepherdDataSet.DataSetName = "GoodShepherdDataSet";
            this.goodShepherdDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vIWGetPeopleData1BindingSource
            // 
            this.vIWGetPeopleData1BindingSource.DataMember = "VIW_GetPeopleData1";
            this.vIWGetPeopleData1BindingSource.DataSource = this.goodShepherdDataSet;
            // 
            // vIW_GetPeopleData1TableAdapter
            // 
            this.vIW_GetPeopleData1TableAdapter.ClearBeforeFill = true;
            // 
            // tBL_AreaBindingSource
            // 
            this.tBL_AreaBindingSource.DataMember = "FK_TBL_Area_TBL_City";
            this.tBL_AreaBindingSource.DataSource = this.tBL_CityBindingSource;
            // 
            // tBL_StreetBindingSource
            // 
            this.tBL_StreetBindingSource.DataMember = "FK_TBL_Street_TBL_Area";
            this.tBL_StreetBindingSource.DataSource = this.tBL_AreaBindingSource;
            // 
            // FRM_Adress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 389);
            this.Controls.Add(this.GRD_City);
            this.Controls.Add(this.tBL_CityBindingNavigator);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Left);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Right);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Bottom);
            this.Controls.Add(this._panel2_Toolbars_Dock_Area_Top);
            this.Name = "FRM_Adress";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "FRM_Adress";
            this.ThemeName = "Office2007Black";
            this.Load += new System.EventHandler(this.FRM_Adress_Load);
            ((System.ComponentModel.ISupportInitialize)(this.adressDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_CityBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_CityBindingNavigator)).EndInit();
            this.tBL_CityBindingNavigator.ResumeLayout(false);
            this.tBL_CityBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GRD_City)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Toolbar_Options)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.goodShepherdDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vIWGetPeopleData1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_AreaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBL_StreetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AdressDataSet adressDataSet;
        private System.Windows.Forms.BindingSource tBL_CityBindingSource;
        private AdressDataSetTableAdapters.TBL_CityTableAdapter tBL_CityTableAdapter;
        private AdressDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator tBL_CityBindingNavigator;
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
        private System.Windows.Forms.ToolStripButton tBL_CityBindingNavigatorSaveItem;
        private Infragistics.Win.UltraWinGrid.UltraGrid GRD_City;
        private System.Windows.Forms.BindingSource tBL_AreaBindingSource;
        private AdressDataSetTableAdapters.TBL_AreaTableAdapter tBL_AreaTableAdapter;
        private System.Windows.Forms.BindingSource tBL_StreetBindingSource;
        private AdressDataSetTableAdapters.TBL_StreetTableAdapter tBL_StreetTableAdapter;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsManager Toolbar_Options;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Left;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Right;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Bottom;
        private Infragistics.Win.UltraWinToolbars.UltraToolbarsDockArea _panel2_Toolbars_Dock_Area_Top;
        private GoodShepherdDataSet goodShepherdDataSet;
        private System.Windows.Forms.BindingSource vIWGetPeopleData1BindingSource;
        private GoodShepherdDataSetTableAdapters.VIW_GetPeopleData1TableAdapter vIW_GetPeopleData1TableAdapter;

    }
}