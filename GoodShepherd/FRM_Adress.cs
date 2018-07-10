using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;


namespace GoodShepherd
{
    public partial class FRM_Adress : RadForm
    {
        public string vFormMode = "NI";

        public FRM_Adress()                                                                                             
        {
            InitializeComponent();
        }

        private void FRM_Adress_Load(object sender, EventArgs e)                                                        
        {
            this.tBL_StreetTableAdapter.Fill(this.adressDataSet.TBL_Street);
            this.tBL_AreaTableAdapter.Fill(this.adressDataSet.TBL_Area);
            this.tBL_CityTableAdapter.Fill(this.adressDataSet.TBL_City);
        }

        private void tBL_CityBindingNavigatorSaveItem_Click(object sender, EventArgs e)                                 
        {
            //to select any control rether than changed row
            //bindingNavigatorPositionItem.Focus();
            //this.Focus();
            //GRD_City.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode);
            //GRD_City.Focus();


            //to save change in services table refresh and update GRD
            GRD_City.UpdateData();
            GRD_City.Refresh();

            //Save all tables
            this.Validate();
            this.tBL_CityBindingSource.EndEdit();
            this.tBL_CityTableAdapter.Update(this.adressDataSet.TBL_City);

            this.Validate();
            this.tBL_AreaBindingSource.EndEdit();
            this.tBL_AreaTableAdapter.Update(this.adressDataSet.TBL_Area);

            this.Validate();
            this.tBL_StreetBindingSource.EndEdit();
            this.tBL_StreetTableAdapter.Update(this.adressDataSet.TBL_Street);

            this.tableAdapterManager.UpdateAll(this.adressDataSet);

            vFormMode = "NI";
        }

        private void tBL_CityUltraGrid_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)         
        {
            if (vFormMode.Trim().ToUpper() == "NI")
            {
                vFormMode = "U";
            }
        }

        private bool fIsDataChanged()                                                                                   
        {
            try
            {
                if (vFormMode == "I" || vFormMode.Trim().ToUpper() == "U")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "fIsDataChanged");
                return false;
            }
        }
        public bool fCancelTransaction()                                                                                
        {
            try
            {

                if (fIsDataChanged() == true)
                {
                    if (MessageBox.Show("هل تريد إلغاء التغييرات الحالية", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == System.Windows.Forms.DialogResult.Yes)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                //End If
                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "fAppExitValidation");
                return false;
            }
        }

        private void Toolbar_Options_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)   
        {
            try
            {
                switch (e.Tool.Key)
                {
                    case "BTN_Delete":
                        GRD_City.ActiveRow.Delete(false);
                        //select last row
                        GRD_City.ActiveRow = GRD_City.Rows[GRD_City.Rows.Count - 1];
                        break;
                    case "BTN_New":
                        if (GRD_City.ActiveRow.Band.ToString() == "TBL_City")
                        {
                            //bindingNavigatorAddNewItem.PerformClick();

                            ////select last row
                            //GRD_City.ActiveRow = GRD_City.Rows[GRD_City.Rows.Count - 1];
                            ////select cell
                            //GRD_City.ActiveCell = GRD_City.ActiveRow.Cells[1];
                            ////enter edit mode
                            //GRD_City.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);

                            GRD_City.DisplayLayout.Bands["TBL_City"].AddNew();
                        }
                        else if (GRD_City.ActiveRow.Band.ToString() == "FK_TBL_Area_TBL_City")
                        {
                            GRD_City.DisplayLayout.Bands["FK_TBL_Area_TBL_City"].AddNew();
                        }
                        else if (GRD_City.ActiveRow.Band.ToString() == "FK_TBL_Street_TBL_Area")
                        {
                            GRD_City.DisplayLayout.Bands["FK_TBL_Street_TBL_Area"].AddNew();
                        }

                        break;
                    case "BTN_Save":
                        tBL_CityBindingNavigatorSaveItem.PerformClick();
                        break;
                    case "BTN_Next":
                        bindingNavigatorMoveNextItem.PerformClick();
                        break;
                    case "BTN_Previous":
                        bindingNavigatorMovePreviousItem.PerformClick();

                        
                        //GRD_City.ActiveRow = GRD_City.Rows[GRD_City.Rows.Count - 1];

                        //GRD_City.ActiveRow = GRD_City.Rows[GRD_City.DisplayLayout.Bands["TBL_City"].Rows.Count - 1];

                        //GRD_City.DisplayLayout.Bands[].


                        //GRD_City.DisplayLayout.Bands["TBL_City"].

                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, "FRM_Students", "Toolbar_Options_ToolClick");
            }
        }

        private void GRD_City_BeforeRowExpanded(object sender, Infragistics.Win.UltraWinGrid.CancelableRowEventArgs e)
        {
            if (e.Row.Band.ToString() == "TBL_City")
            {
                this.GRD_City.Rows.CollapseAll(false);
            }
        }


    }
}
