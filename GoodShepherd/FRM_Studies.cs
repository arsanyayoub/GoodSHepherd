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
    public partial class FRM_Studies : RadForm
    {
        public string vFormMode = "NI";


        public FRM_Studies()                        
        {
            InitializeComponent();
        }

        private void tBL_EducationLevelBindingNavigatorSaveItem_Click(object sender, EventArgs e)   
        {
            //to save change in services table refresh and update GRD
            GRD_Studies.UpdateData();
            GRD_Studies.Refresh();

            this.Validate();

            this.tBL_EducationLevelBindingSource.EndEdit();
            this.tBL_EducationLevelTableAdapter.Update(this.studiesDataSet.TBL_EducationLevel);

            this.tBL_EducYearBindingSource.EndEdit();
            this.tBL_EducYearTableAdapter.Update(this.studiesDataSet.TBL_EducYear);

            this.tBL_CollageBindingSource.EndEdit();
            this.tBL_CollageTableAdapter.Update(this.studiesDataSet.TBL_Collage);

            this.tBL_EducationLevelTableAdapter.Update(this.studiesDataSet.TBL_EducationLevel);
        }

        private void FRM_Studies_Load(object sender, EventArgs e)                                   
        {
            this.tBL_CollageTableAdapter.Fill(this.studiesDataSet.TBL_Collage);
            this.tBL_EducYearTableAdapter.Fill(this.studiesDataSet.TBL_EducYear);
            this.tBL_EducationLevelTableAdapter.Fill(this.studiesDataSet.TBL_EducationLevel);
        }

        private void tBL_EducationLevelUltraGrid_BeforeRowExpanded(object sender, Infragistics.Win.UltraWinGrid.CancelableRowEventArgs e)
        {
            if (e.Row.Band.ToString() == "TBL_EducationLevel" )
            {
                this.GRD_Studies.Rows.CollapseAll(false);


                if (e.Row.Cells["ID"].Text.ToString() == "6")
                {
                    GRD_Studies.DisplayLayout.Bands["FK_TBL_Collage_TBL_EducationLevel"].Hidden = false;

                    GRD_Studies.DisplayLayout.Bands["FK_TBL_EducYear_TBL_EducationLevel"].Hidden = true;
                }
                else
                {
                    GRD_Studies.DisplayLayout.Bands["FK_TBL_Collage_TBL_EducationLevel"].Hidden = true;

                    GRD_Studies.DisplayLayout.Bands["FK_TBL_EducYear_TBL_EducationLevel"].Hidden = false;
                }
            }
        }

        private void tBL_EducationUltraGrid_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
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
                        GRD_Studies.ActiveRow.Delete(false);
                        break;
                    case "BTN_New":
                        bindingNavigatorAddNewItem.PerformClick();


                        //select last row
                        GRD_Studies.ActiveRow = GRD_Studies.Rows[GRD_Studies.Rows.Count - 1];
                        //select cell
                        GRD_Studies.ActiveCell = GRD_Studies.ActiveRow.Cells[1];
                        //enter edit mode
                        GRD_Studies.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode);
                        break;
                    case "BTN_Save":
                        tBL_EducationLevelBindingNavigatorSaveItem.PerformClick();
                        break;
                    case "BTN_Next":
                        bindingNavigatorMoveNextItem.PerformClick();
                        break;
                    case "BTN_Previous":
                        bindingNavigatorMovePreviousItem.PerformClick();
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, "FRM_Students", "Toolbar_Options_ToolClick");
            }
        }


    }
}
