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
    public partial class FRM_Church : RadForm
    {
        public string vFormMode = "NI";


        public FRM_Church()                                                                 
        {
            InitializeComponent();
        }

        private void FRM_Church_Load(object sender, EventArgs e)                            
        {
            // TODO: This line of code loads data into the 'adressDataSet.TBL_Services' table. You can move, or remove it, as needed.
            
            this.tBL_CityTableAdapter  .Fill(this.adressDataSet.TBL_City  );
            this.tBL_AreaTableAdapter  .Fill(this.adressDataSet.TBL_Area  );
            this.tBL_StreetTableAdapter.Fill(this.adressDataSet.TBL_Street);
            
            this.tBL_ChurchTableAdapter.Fill(this.adressDataSet.TBL_Church);

            this.vIW_ChurchTableAdapter.Fill(this.adressDataSet.VIW_Church);

            //bindingNavigatorAddNewItem.PerformClick();

            
            //to select row in filter row to dont chang curent
            //GRD_Churches.ActiveRow = GRD_Churches.Rows.FilterRow;
        }

        private void tBL_ChurchBindingNavigatorSaveItem_Click(object sender, EventArgs e)   
        {
            if ( SaveValidation() )
            {
                //to save change in church table
                this.Validate();
                this.tBL_ChurchBindingSource.EndEdit();
                this.tBL_ChurchTableAdapter.Update(this.adressDataSet.TBL_Church);

                //to save change in services table
                GRD_Services.UpdateData();
                GRD_Services.Refresh();

                this.Validate();
                this.tBL_ServicesBindingSource.EndEdit();
                this.tBL_ServicesTableAdapter.Update(this.adressDataSet.TBL_Services);

                //to reload data
                this.vIW_ChurchTableAdapter.Fill(this.adressDataSet.VIW_Church);
            }
            else
            {
                MessageBox.Show("please check and compleate your data");
            }


        }
        private void CMX_City_ValueChanged(object sender, EventArgs e)                      
        
        

        

        {
            if (CMX_City.Value != null )
            {
                this.tBL_AreaTableAdapter.FillByCity(this.adressDataSet.TBL_Area, long.Parse(CMX_City.Value.ToString()));

                if (!CMX_Area.IsItemInList())
                {
                    CMX_Area.Value = null;

                    if (!CMX_Street.IsItemInList())
                    {
                        CMX_Street.Value = null;
                    }
                }
            }
            else
            {
                this.tBL_AreaTableAdapter.FillByCity(this.adressDataSet.TBL_Area, 0);

                //if not in list remove it 
                CMX_City.Text = "";
            }
        }
        private void CMX_Area_ValueChanged(object sender, EventArgs e)                      
        {

            if (CMX_Area.Value != null)
            {
                this.tBL_StreetTableAdapter.FillByArea(this.adressDataSet.TBL_Street, long.Parse(CMX_Area.Value.ToString()));


                if (!CMX_Street.IsItemInList())
                {
                    CMX_Street.Value = null;
                }
            }
            else
            {
                this.tBL_StreetTableAdapter.FillByArea(this.adressDataSet.TBL_Street, 0 );

                CMX_Area.Text = "";
            }
        }
        private void FRM_Church_Enter(object sender, EventArgs e)                           
        {
            //to reload city every enter to the form and other (area and street) depend on it 
            this.tBL_CityTableAdapter.Fill(this.adressDataSet.TBL_City);
        }
        private bool SaveValidation()                                                       
        






        
        {
            bool ressult;
            try
            {
                //if all existing in list
                if (CMX_City.IsItemInList() && CMX_Area.IsItemInList())
                {   //check text name of church
                    if (TXT_Church.Text != "")
                    {
                        ressult=  true;
                    }
                    else
                    {
                        MessageBox.Show("please enter church name");
                        TXT_Church.Focus();
                        ressult = false;
                    }
                }
                else
                {
                    ressult = false;
                }
            }
            catch (Exception)
            {
                ressult = false;
            }

            return ressult;
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
                        bindingNavigatorDeleteItem.PerformClick();
                        break;
                    case "BTN_New":
                        bindingNavigatorAddNewItem.PerformClick();

                        //to disable services when church not saved
                        GRD_Services.Enabled = false;
                        break;
                    case "BTN_Save":
                        //to get row index number befor save
                        int x = GRD_Churches.ActiveRow.Index;

                        //Save
                        tBL_ChurchBindingNavigatorSaveItem.PerformClick();
                        
                        //select Same row
                        GRD_Churches.ActiveRow = GRD_Churches.Rows[x];
                        break;
                    case "BTN_Next":
                        bindingNavigatorMoveNextItem.PerformClick();

                        if (GRD_Churches.Rows.Count != GRD_Churches.ActiveRow.Index + 1)
                        {
                            int N = GRD_Churches.Rows.Count;
                            GRD_Churches.ActiveRow = GRD_Churches.Rows[GRD_Churches.ActiveRow.Index + 1];
                        }

                        //enable and reload data in services table
                        GRD_Services.Enabled = true;
                        this.tBL_ServicesTableAdapter.FillByChurch(this.adressDataSet.TBL_Services, Convert.ToInt64(TXT_ID.Text));

                        //Defultvalue by ID to insert with same key
                        GRD_Services.DisplayLayout.Bands[0].Columns["Church_ID"].DefaultCellValue = Convert.ToInt64(TXT_ID.Text);

                        break;
                    case "BTN_Previous":
                        bindingNavigatorMovePreviousItem.PerformClick();

                        //if active row firest row dont previouse
                        if (GRD_Churches.ActiveRow.Index != 0)
                        {
                            GRD_Churches.ActiveRow = GRD_Churches.Rows[GRD_Churches.ActiveRow.Index - 1];
                        }



                        //enable and reload data in services table
                        GRD_Services.Enabled = true;
                        this.tBL_ServicesTableAdapter.FillByChurch(this.adressDataSet.TBL_Services, Convert.ToInt64(TXT_ID.Text));

                        //Defultvalue by ID to insert with same key
                        GRD_Services.DisplayLayout.Bands[0].Columns["Church_ID"].DefaultCellValue = Convert.ToInt64(TXT_ID.Text);

                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, "FRM_Students", "Toolbar_Options_ToolClick");
            }
        }

        private void vIW_ChurchUltraGrid_AfterRowActivate(object sender, EventArgs e)
        {
            string y = GRD_Churches.ActiveRow.Cells["ID"].Text;

            //to get record position and go to it 
            int x = GRD_Churches.ActiveRow.Index + 1;
            bindingNavigatorPositionItem.Text = x.ToString();

            bindingNavigatorPositionItem.Focus();
            SendKeys.Send("{ENTER}");


            //to enabled data and refill services grd
            GRD_Services.Enabled = true;
            this.tBL_ServicesTableAdapter.FillByChurch(this.adressDataSet.TBL_Services, Convert.ToInt64(y));

            //Defultvalue by ID to insert with same key
            GRD_Services.DisplayLayout.Bands[0].Columns["Church_ID"].DefaultCellValue = Convert.ToInt64(y);

        }

    }
}
