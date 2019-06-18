using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using GoodShepherd.Reports;

namespace GoodShepherd
{
    public partial class FRM_ReportLev1 : Form
    {

        public string _repKey = "";
        public FRM_ReportLev1(string repKey)
        {
            InitializeComponent();
            _repKey = repKey;
            CMXLoad(CMX_CIty, "TBL_City", "id", "CityDesc" , "");
           // CMXLoad(CMX_Services, "TBL_Services", "id", "Service", "WHERE Church_ID = " + BasicClass.vChurchID.ToString());
            CMXLoad(CMX_Educ, "TBL_EducationLevel", "id", "EducLevel" , "");
            
        }


        private void FRM_ReportLev1_Load(object sender, EventArgs e)
        {
            this.vIW_GetPeopleData1TableAdapter.Fill(this.goodShepherdDataSet.VIW_GetPeopleData1);
            this.vIW_ChurchTableAdapter.Fill(this.goodShepherdDataSet.VIW_Church);
        }

        SqlConnection Con = new SqlConnection(BasicClass.vConectionString);
        SqlDataAdapter DA;
        DataTable DT = new DataTable();
        DataSet DS = new DataSet();
        private void CMXLoad(Infragistics.Win.UltraWinEditors.UltraComboEditor CMXFill,
                     string TableName, string ColumnValue, string ColumnDisplay  , string pWhere)
        {
            string query = "select  "+ ColumnValue+","+ ColumnDisplay + " from "+ TableName+ "\n"  +
                pWhere + "\n" +
                " ORDER BY "+ ColumnDisplay + "";
            DA = new SqlDataAdapter(query, Con);
            Con.Open();
            DS = new DataSet();
            DA.Fill(DS, TableName);
            CMXFill.DataSource = DS.Tables[TableName];
            CMXFill.DisplayMember = ColumnDisplay;
            CMXFill.ValueMember = ColumnValue;
            Con.Close(); 
        }
        private void CMXFillValidation(Infragistics.Win.UltraWinEditors.UltraComboEditor CMXFill, Infragistics.Win.UltraWinEditors.UltraComboEditor CMXValidation
                     ,string TableName, string ColumnValue,string ColumnDisplay,string ColumnValidation)
        {
            string query = "select "+ ColumnValue + ","+ ColumnDisplay + " from "+TableName+" where "+ ColumnValidation + "=" + CMXValidation.Value + "  ORDER BY "+ ColumnDisplay + " ";
            DA = new SqlDataAdapter(query, Con);
            Con.Open();
            DS = new DataSet();
            DA.Fill(DS, TableName);
            CMXFill.DataSource = DS.Tables[TableName];
            CMXFill.DisplayMember = ColumnDisplay;
            CMXFill.ValueMember = ColumnValue;
            Con.Close();  
        }
        //------------------------------------------------------
        private void ComboCIty_ValueChanged(object sender, EventArgs e)
        {
            if (CMX_CIty.SelectedItem == null)
            {
                CMX_Area.Clear();
                CMX_Area.Items.Clear();
            }
            else
            {
                CMXFillValidation(CMX_Area, CMX_CIty, "TBL_Area", "id", "AreaDesc", "City_id");
                CMXFillValidation(CMX_Chruch, CMX_CIty, "TBL_Church", "id", "ChurchName", "City_id");
            }
        }
        private void ComboArea_ValueChanged(object sender, EventArgs e)
        {
            if (CMX_Area.SelectedItem == null)
            {
                CMX_Street.Clear();
                CMX_Street.Items.Clear();
            }
            else CMXFillValidation(CMX_Street, CMX_Area, "TBL_Street", "id", "StreetDesc", "Area_id");
        }
       
        private void ComboEduc_ValueChanged(object sender, EventArgs e)
        {
            if(CMX_Educ.SelectedItem==null)
            {
                BtnLoadEduc.Text = "Load all";
            }
            else BtnLoadEduc.Text = "Load";
        }
        //--------------------------------------------------------------
        private void BtnLoadCity_Click(object sender, EventArgs e)
        {
            if (CMX_CIty.SelectedItem == null) LblCity.ForeColor = Color.Red;
            else
            {

                //CR.ReportSource = null;

                LblCity.ForeColor = Color.Black;
                this.vIW_GetPeopleData1TableAdapter.FillByCity(this.goodShepherdDataSet.VIW_GetPeopleData1,Convert.ToInt32(CMX_CIty.Value));

                //creating a new Report (FBCReport.rpt)
                ReportDocument RPT_City = new ReportPeopleData();
                RPT_City.Load("ReportPeopleData.rpt");
                RPT_City.SetDataSource(goodShepherdDataSet);
                RPT_City.SetParameterValue("Adress", "بمحافظة : " + CMX_CIty.Text);
                
                CR.ReportSource = RPT_City;
                //CR.Refresh();
            }
        }
        private void BtnLoadArea_Click(object sender, EventArgs e)
        {
            try
            {
                
            if (CMX_Area.SelectedItem == null) LBL_Area.ForeColor = Color.Red;
            else
            {
                LBL_Area.ForeColor = Color.Black;
                this.vIW_GetPeopleData1TableAdapter.FillByArea(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_Area.Value));

                //creating a new Report (FBCReport.rpt)
                ReportDocument reportDocument = new ReportPeopleData();
                reportDocument.Load("ReportPeopleData.rpt");
                reportDocument.SetDataSource(goodShepherdDataSet);
                reportDocument.SetParameterValue("Adress", "بمنطقة : " + CMX_Area.Text);
                
                CR.ReportSource = reportDocument;
                //CR.Refresh();
            }
            }
            catch (Exception ex)
            {
                
                ExceptionHandler.HandleException(ex.Message,this.Name,"BtnLoadArea_Click");
            }
        }
        private void BtnLoadStreet_Click(object sender, EventArgs e)
        {
            try
            {
                if (CMX_Street.SelectedItem == null) LblStreet.ForeColor = Color.Red;
                else
                {

                    LblStreet.ForeColor = Color.Black;
                    this.vIW_GetPeopleData1TableAdapter.FillByStreet(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_Street.Value));

                    //creating a new Report (FBCReport.rpt)
                    ReportDocument reportDocument = new ReportPeopleData();
                    reportDocument.Load("ReportPeopleData.rpt");

                    reportDocument.SetDataSource(goodShepherdDataSet);
                    reportDocument.SetParameterValue("Adress", CMX_Street.Text);

                    CR.ReportSource = reportDocument;
                    //CR.Refresh();
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "BtnLoadStreet_Click");
            }
        }
        private void BtnLoadFather_Click(object sender, EventArgs e)
        {
            if (CMX_FatherName.SelectedItem == null) LblFather.ForeColor = Color.Red;
            else
            {
                LblFather.ForeColor = Color.Black;
                this.vIW_GetPeopleData1TableAdapter.FillByFrPers(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_FatherName.Value));

                //creating a new Report (FBCReport.rpt)
                ReportDocument reportDocument = new ReportPeopleData();
                reportDocument.Load("ReportPeopleData.rpt");
                reportDocument.SetDataSource(goodShepherdDataSet);
                reportDocument.SetParameterValue("Adress", "اب اعتراف  : " + CMX_FatherName.Text);

                CR.ReportSource = reportDocument;
            }
        }
        private void BtnChurch_Click(object sender, EventArgs e)
        {
            if (CMX_Chruch.SelectedItem == null) LblChurch.ForeColor = Color.Red;
            else
            {
                LblChurch.ForeColor = Color.Black;
                this.vIW_GetPeopleData1TableAdapter.FillByFrChurch(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_Chruch.Value));
                //creating a new Report (FBCReport.rpt)
                ReportDocument reportDocument = new ReportPeopleData();
                reportDocument.Load("ReportPeopleData.rpt");
                reportDocument.SetDataSource(goodShepherdDataSet);
                reportDocument.SetParameterValue("Adress", "بكنيسة : " + CMX_Chruch.Text);

                CR.ReportSource = reportDocument;
            }
        }
        private void TXTs_BeforeDropDown(object sender, CancelEventArgs e)
        {
            try
            {
                string checkedName = ((Infragistics.Win.UltraWinEditors.UltraComboEditor)sender).Name;
                if (checkedName == "CMX_Services")
                {
                    if (CMX_Chruch.SelectedItem != null)
                    {
                        CMXLoad(CMX_Services, "TBL_Services", "ID", "Service", "WHERE Church_ID = " + CMX_Chruch.SelectedItem.DataValue.ToString());
                    }
                    else
                    {
                        CMX_Services.Items.Clear();
                    }

                }
                else if (checkedName == "CMX_FatherName")
                {
                     if (CMX_Chruch.SelectedItem != null)
                    {
                        CMXLoad(CMX_FatherName, "TBL_MainPerson", "Id", "Name", "where PersType_ID = 1 and Church_id="+ CMX_Chruch.Value.ToString());
                    }
                    else
                    {
                        CMX_FatherName.Items.Clear();
                    }
                }

                else if (checkedName == "CMX_Chruch")
                {
                    if (BasicClass.vCityID > 0)
                    {
                        CMXLoad(CMX_Chruch, "TBL_Church", "ID", "ChurchName", "where City_ID=" + BasicClass.vCityID.ToString());
                    }
                    else
                    {
                        CMX_Chruch.Items.Clear();
                    }
                }                              
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "TXT_City_BeforeDropDown");
            }
        }
       
        private void BtnServices_Click(object sender, EventArgs e)
        {
            if (CMX_Services.SelectedItem == null) LblServices.ForeColor = Color.Red;
            else
            {
                LblServices.ForeColor = Color.Black;
                this.vIW_GetPeopleData1TableAdapter.FillByService(this.goodShepherdDataSet.VIW_GetPeopleData1, BasicClass.vChurchID, Convert.ToInt32(CMX_Services.Value));
                //creating a new Report (FBCReport.rpt)
                ReportDocument reportDocument = new ReportPeopleData();
                reportDocument.Load("ReportPeopleData.rpt");
                reportDocument.SetDataSource(goodShepherdDataSet);
                reportDocument.SetParameterValue("Adress", "بخدمة  : " + CMX_Services.Text);

                CR.ReportSource = reportDocument;
            }
        }
        private void BtnEduc_Click(object sender, EventArgs e)
        {
            if (CMX_Educ.SelectedItem == null) LblEduc.ForeColor = Color.Red;
            else 
            {
            this.vIW_GetPeopleData1TableAdapter.FillByEduc(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_Educ.Value));
            //creating a new Report (FBCReport.rpt)
            ReportDocument reportDocument = new ReportPeopleData();
            reportDocument.Load("ReportPeopleData.rpt");
            reportDocument.SetDataSource(goodShepherdDataSet);
            reportDocument.SetParameterValue("Adress", "بمرحلة  : " + CMX_Educ.Text);

            CR.ReportSource = reportDocument;
            }
        }
        private void BtnLoadStatus_Click(object sender, EventArgs e)
        {
            if (CMX_Status.SelectedItem == null) LblStatus.ForeColor = Color.Red;
            else
            {
                LblStatus.ForeColor = Color.Black;
                this.vIW_GetPeopleData1TableAdapter.FillByStatuse(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToString(CMX_Status.Value));
                //creating a new Report (FBCReport.rpt)
                ReportDocument reportDocument = new ReportPeopleData();
                reportDocument.Load("ReportPeopleData.rpt");
                reportDocument.SetDataSource(goodShepherdDataSet);
                reportDocument.SetParameterValue("Adress", "الحالة الاجتماعية   : " + CMX_Status.Text);

                CR.ReportSource = reportDocument;
            }
        }
        private void BtnWork_Click(object sender, EventArgs e)
        {
            if (CMX_Work.SelectedItem == null) LblWork.ForeColor = Color.Red;
            else if (CMX_CIty.SelectedItem == null) LblCity.ForeColor = Color.Red;  
            else
            {
                LblWork.ForeColor = Color.Black;
                this.vIW_GetPeopleData1TableAdapter.FillByIsWork(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToString(CMX_Work.Value), BasicClass.vCityID);
                //creating a new Report (FBCReport.rpt)
                ReportDocument reportDocument = new ReportPeopleData();
                reportDocument.Load("ReportPeopleData.rpt");
                reportDocument.SetDataSource(goodShepherdDataSet);
                reportDocument.SetParameterValue("Adress", "حالة العمل : " + CMX_Work.Text);

                CR.ReportSource = reportDocument;
            }
        }
       
        private void BtnLoadPartAge_Click(object sender, EventArgs e)
        {
                //LblFromBirthMonth.ForeColor = Color.Black;
                //LblToBirthMonth.ForeColor = Color.Black;
                //this.vIW_GetPeopleData1TableAdapter.FillByPartAge(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_FromAge.Value), Convert.ToInt32(CMX_ToAge.Value), Convert.ToInt32(CMX_Chruch.Value));
                //ReportMonth1.SetDataSource(goodShepherdDataSet);
                //ReportMonth1.SetParameterValue("Adress", CMX_Area.Text);
                //ReportMonth1.SetParameterValue("City", CMX_CIty.Text);
                //ReportMonth1.SetParameterValue("Church", CMX_Chruch.Text);
                //CR.ReportSource = ReportMonth1;
        }

        private void EXP_MainItems_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            try
            {
                LblCity.Visible = false;
                CMX_CIty.Visible = false;
                BtnLoadCity.Visible = false;


                LBL_Area.Visible = false;
                CMX_Area.Visible = false;
                BtnLoadArea.Visible = false;

                LblStreet.Visible = false;
                CMX_Street.Visible = false;
                BtnLoadStreet.Visible = false;


                LblChurch.Visible = false;
                CMX_Chruch.Visible = false;
                BtnLoadFrChurch.Visible = false;
                LblFather.Visible = false;
                CMX_FatherName.Visible = false;
                BtnLoadFather.Visible = false;
                LblServices.Visible = false;
                CMX_Services.Visible = false;
                BtnLoadServices.Visible = false;

                LblEduc.Visible = false;
                CMX_Educ.Visible = false;
                BtnLoadEduc.Visible = false;
                LblStatus.Visible = false;
                CMX_Status.Visible = false;
                BtnLoadStatus.Visible = false;

                LblWork.Visible = false;
                CMX_Work.Visible = false;
                BtnWork.Visible = false;
                switch (e.Item.Key)
                {
                    case "RepPeopleDataByCity":
                        LblCity.Visible = true;
                        CMX_CIty.Visible = true;
                        BtnLoadCity.Visible = true;


                        LBL_Area.Visible = true;
                        CMX_Area.Visible = true;
                        BtnLoadArea.Visible = true;

                        LblStreet.Visible = true;
                        CMX_Street.Visible = true;
                        BtnLoadStreet.Visible = true;
                        
                        break;
                    case "RepPeopleDataByArea":
                        LblCity.Visible = true;
                        CMX_CIty.Visible = true;
                        BtnLoadCity.Visible = true;


                        LBL_Area.Visible = true;
                        CMX_Area.Visible = true;
                        BtnLoadArea.Visible = true;

                        LblStreet.Visible = true;
                        CMX_Street.Visible = true;
                        BtnLoadStreet.Visible = true;
                        break;
                    case "RepPeopleDataByStreet":
                        LblCity.Visible = true;
                        CMX_CIty.Visible = true;
                        BtnLoadCity.Visible = true;


                        LBL_Area.Visible = true;
                        CMX_Area.Visible = true;
                        BtnLoadArea.Visible = true;

                        LblStreet.Visible = true;
                        CMX_Street.Visible = true;
                        BtnLoadStreet.Visible = true;
                        break;
                    case "RepPeopleDataByGodFather":
                        LblChurch.Visible = true;
                        CMX_Chruch.Visible = true;
                        //BtnLoadFrChurch.Visible = true;
                        LblFather.Visible = true;
                        CMX_FatherName.Visible = true;
                        BtnLoadFather.Visible = true;
                        break;
                    case "RepPeopleDataByFatherChurch":
                          LblChurch.Visible = true;
                        CMX_Chruch.Visible = true;
                        //BtnLoadFrChurch.Visible = true;
                        LblFather.Visible = true;
                        CMX_FatherName.Visible = true;
                        BtnLoadFather.Visible = true;
                        break;
                    case "RepPeopleDataByService":
                        LblChurch.Visible = true;
                        CMX_Chruch.Visible = true;
                        //BtnLoadFrChurch.Visible = true;
                        LblServices.Visible = true;
                        CMX_Services.Visible = true;
                        BtnLoadServices.Visible = true;


                        break;
                    case "RepPeopleDataByEduLevel":
                        
                            LblEduc.Visible = true;
                            CMX_Educ.Visible = true;
                            BtnLoadEduc.Visible = true;
                        break;
                    case "RepPeopleDataByStatus":
                        LblStatus.Visible = true;
                            CMX_Status.Visible = true;
                            BtnLoadStatus.Visible = true;
                        break;
                    case "RepPeopleDataByWorkStatus":
                         LblCity.Visible = true;
                        CMX_CIty.Visible = true;
                        BtnLoadCity.Visible = true;

                        LblWork.Visible = true;
                            CMX_Work.Visible = true;
                            BtnWork.Visible = true;
                        break;
                
                }
            }
            catch (Exception ex)
            {
                
                ExceptionHandler.HandleException(ex.Message,this.Name ,  "EXP_MainItems_ItemClick");
            }
        }

       
      
    }
}
