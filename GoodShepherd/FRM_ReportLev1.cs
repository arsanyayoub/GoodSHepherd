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
            CMXLoad(CMX_CIty, "TBL_City", "id", "CityDesc");
            CMXLoad(CMX_Services, "TBL_Services","id", "Service");
            CMXLoad(CMX_Educ, "TBL_EducationLevel", "id", "EducLevel");
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
                     string TableName, string ColumnValue, string ColumnDisplay)
        {
            string query = "select  "+ ColumnValue+","+ ColumnDisplay + " from "+ TableName+" ORDER BY "+ ColumnDisplay + "";
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
        private void ComboChruch_ValueChanged(object sender, EventArgs e)
        {
            if (CMX_Chruch.SelectedItem == null)
            {
                CMX_FatherName.Clear();
                CMX_FatherName.Items.Clear();
            }
            else
            {
                string query = "select Id , Name from TBL_MainPerson where PersType_ID = 1 and Church_id="+ CMX_Chruch .Value+ " ORDER BY Name ";
                DA = new SqlDataAdapter(query, Con);
                Con.Open();
                DS = new DataSet();
                DA.Fill(DS, " TBL_MainPerson");
                CMX_FatherName.DataSource = DS.Tables[" TBL_MainPerson"];
                CMX_FatherName.DisplayMember = "Name";
                CMX_FatherName.ValueMember = "Id";
                Con.Close();
            }
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
                ReportDocument RPT_City = new RportAdress();
                RPT_City.Load("RportAdress.rpt");
                RPT_City.SetDataSource(goodShepherdDataSet);
                RPT_City.SetParameterValue("Adress", "بمحافظة : " + CMX_CIty.Text);
                
                CR.ReportSource = RPT_City;
                //CR.Refresh();
            }
        }
        private void BtnLoadArea_Click(object sender, EventArgs e)
        {
            if (CMX_Area.SelectedItem == null) LBL_Area.ForeColor = Color.Red;
            else
            {
                LBL_Area.ForeColor = Color.Black;
                this.vIW_GetPeopleData1TableAdapter.FillByArea(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_Area.Value));

                //creating a new Report (FBCReport.rpt)
                ReportDocument reportDocument = new RportAdress();
                reportDocument.Load("RportAdress.rpt");
                reportDocument.SetDataSource(goodShepherdDataSet);
                reportDocument.SetParameterValue("Adress", "بمنطقة : " + CMX_Area.Text);
                
                CR.ReportSource = reportDocument;
                //CR.Refresh();
            }
        }
        private void BtnLoadStreet_Click(object sender, EventArgs e)
        {
            if (CMX_Street.SelectedItem == null) LblStreet.ForeColor = Color.Red;
            else
            {
                
                LblStreet.ForeColor = Color.Black;
                this.vIW_GetPeopleData1TableAdapter.FillByStreet(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_Street.Value));

                //creating a new Report (FBCReport.rpt)
                ReportDocument reportDocument = new RportAdress();
                reportDocument.Load("RportAdress.rpt");

                reportDocument.SetDataSource(goodShepherdDataSet);
                reportDocument.SetParameterValue("Adress", CMX_Street.Text);
                
                CR.ReportSource = reportDocument;
                //CR.Refresh();
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
                ReportDocument reportDocument = new RportAdress();
                reportDocument.Load("RportAdress.rpt");

                //ReportChurch.SetDataSource(goodShepherdDataSet);
                //ReportChurch.SetParameterValue("Adress", CMX_Area.Text);
                //ReportChurch.SetParameterValue("City", CMX_CIty.Text);
                //ReportChurch.SetParameterValue("Church", CMX_Chruch.Text);
                //ReportChurch.SetParameterValue("FRName","أب كاهن :"+ CMX_FatherName.Text);
                //CR.ReportSource = ReportChurch;
            }
        }
        private void BtnChurch_Click(object sender, EventArgs e)
        {
            if (CMX_Chruch.SelectedItem == null) LblChurch.ForeColor = Color.Red;
            else
            {
                //LblChurch.ForeColor = Color.Black;
                //this.vIW_GetPeopleData1TableAdapter.FillByChurch (this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_Chruch.Value));
                //ReportChurch.SetDataSource(goodShepherdDataSet);
                //ReportChurch.SetParameterValue("Adress", CMX_Area.Text);
                //ReportChurch.SetParameterValue("City", CMX_CIty.Text);
                //ReportChurch.SetParameterValue("Church", CMX_Chruch.Text);
                //ReportChurch.SetParameterValue("FRName", "");
                //CR.ReportSource = ReportChurch;
            }
        }
        private void BtnServices_Click(object sender, EventArgs e)
        {
            if (CMX_Services.SelectedItem == null) LblServices.ForeColor = Color.Red;
            else
            {
                //LblServices.ForeColor = Color.Black;
                //this.vIW_GetPeopleData1TableAdapter.FillByService(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_Chruch.Value),Convert.ToInt32(CMX_Services.Value));
                //ReportService.SetDataSource(goodShepherdDataSet);
                //ReportService.SetParameterValue("Adress", CMX_Area.Text);
                //ReportService.SetParameterValue("City", CMX_CIty.Text);
                //ReportService.SetParameterValue("Church", CMX_Chruch.Text);
                //CR.ReportSource = ReportService;
            }
        }
        private void BtnEduc_Click(object sender, EventArgs e)
        {
            if (CMX_Educ.SelectedItem == null) LblEduc.ForeColor = Color.Red;
            else 
            {
            //this.vIW_GetPeopleData1TableAdapter.FillByEduc(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_Educ.Value));
            //ReportEduc.SetDataSource(goodShepherdDataSet);
            //ReportEduc.SetParameterValue("Adress", CMX_Area.Text);
            //ReportEduc.SetParameterValue("City", CMX_CIty.Text);
            //ReportEduc.SetParameterValue("Church", CMX_Chruch.Text);
            //ReportEduc.SetParameterValue("EducationLevel", CMX_Educ.Text);
            //CR.ReportSource = ReportEduc;
            }
        }
        private void BtnLoadStatus_Click(object sender, EventArgs e)
        {
            if (CMX_Status.SelectedItem == null) LblStatus.ForeColor = Color.Red;
            else
            {
                //LblStatus.ForeColor = Color.Black;
                //this.vIW_GetPeopleData1TableAdapter.FillByStatuse(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToString(CMX_Status.Value));
                //ReportStatuse1.SetDataSource(goodShepherdDataSet);
                //ReportStatuse1.SetParameterValue("Adress", CMX_Area.Text);
                //ReportStatuse1.SetParameterValue("City", CMX_CIty.Text);
                //ReportStatuse1.SetParameterValue("Church", CMX_Chruch.Text);
                //CR.ReportSource = ReportStatuse1;
            }
        }
        private void BtnWork_Click(object sender, EventArgs e)
        {
            if (CMX_Work.SelectedItem == null) LblWork.ForeColor = Color.Red;
            else
            {
                //LblWork.ForeColor = Color.Black;
                //this.vIW_GetPeopleData1TableAdapter.FillByIsWork(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToString(CMX_Work.Value), Convert.ToInt32(CMX_Chruch.Value));
                //ReportWork1.SetDataSource(goodShepherdDataSet);
                //ReportWork1.SetParameterValue("Adress", CMX_Area.Text);
                //ReportWork1.SetParameterValue("City", CMX_CIty.Text);
                //ReportWork1.SetParameterValue("Church", CMX_Chruch.Text);
                //CR.ReportSource = ReportWork1;
            }
        }
        private void BtnLoadBirthMonth_Click(object sender, EventArgs e)
        {
            if (CMX_BirthMonth.SelectedItem == null) LblBirthMonth.ForeColor = Color.Red;
            else
            {
                //LblBirthMonth.ForeColor = Color.Black;
                //this.vIW_GetPeopleData1TableAdapter.FillByMonth(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_BirthMonth.Value), Convert.ToInt32(CMX_Chruch.Value));
                //ReportMonth1.SetDataSource(goodShepherdDataSet);
                //ReportMonth1.SetParameterValue("Adress", CMX_Area.Text);
                //ReportMonth1.SetParameterValue("City", CMX_CIty.Text);
                //ReportMonth1.SetParameterValue("Church", CMX_Chruch.Text);
                //CR.ReportSource = ReportMonth1;
            }
        }

        private void BtnLoadPartBirthMonth_Click(object sender, EventArgs e)
        {
            if (CMX_FromBirthMonth.SelectedItem == null && CMX_ToBirthMonth.SelectedItem==null)
            {
                LblFromBirthMonth.ForeColor = Color.Red;
                LblToBirthMonth.ForeColor = Color.Red;
            }
            else if(CMX_FromBirthMonth.SelectedItem == null && CMX_ToBirthMonth.SelectedItem != null)
            {
                LblFromBirthMonth.ForeColor = Color.Red;
                LblToBirthMonth.ForeColor = Color.Black;
            }
            else if(CMX_FromBirthMonth.SelectedItem!= null && CMX_ToBirthMonth.SelectedItem == null)
            {
                LblFromBirthMonth.ForeColor = Color.Black;
                LblToBirthMonth.ForeColor = Color.Red;
            }
            else
            {
                //LblFromBirthMonth.ForeColor = Color.Black;
                //LblToBirthMonth.ForeColor = Color.Black;
                //this.vIW_GetPeopleData1TableAdapter.FillByPartMonth(this.goodShepherdDataSet.VIW_GetPeopleData1, Convert.ToInt32(CMX_FromBirthMonth.Value), Convert.ToInt32(CMX_ToBirthMonth.Value), Convert.ToInt32(CMX_Chruch.Value));
                //ReportMonth1.SetDataSource(goodShepherdDataSet);
                //ReportMonth1.SetParameterValue("Adress", CMX_Area.Text);
                //ReportMonth1.SetParameterValue("City", CMX_CIty.Text);
                //ReportMonth1.SetParameterValue("Church", CMX_Chruch.Text);
                //CR.ReportSource = ReportMonth1;
            }
        }
        private void BtnLoadAge_Click(object sender, EventArgs e)
        {
            if (CMX_Age.Value == null) LblAge.ForeColor = Color.Red;
            else
            {
                //LblAge.ForeColor = Color.Black;
                //this.vIW_GetPeopleData1TableAdapter.FillByAge(this.goodShepherdDataSet.VIW_GetPeopleData1,  Convert.ToInt32(CMX_Age.Value), Convert.ToInt32(CMX_Chruch.Value));
                //ReportMonth1.SetDataSource(goodShepherdDataSet);
                //ReportMonth1.SetParameterValue("Adress", CMX_Area.Text);
                //ReportMonth1.SetParameterValue("City", CMX_CIty.Text);
                //ReportMonth1.SetParameterValue("Church", CMX_Chruch.Text);
                //CR.ReportSource = ReportMonth1;
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
        private void OPT_RepType_ValueChanged(object sender, EventArgs e)
        {
            switch (OPT_RepType.Value.ToString())
	        {
                case   "1" :
                    GRP_Details.Visible = true;
                    GRP_Attendance.Visible = false;
                break;

                case "2":
                    GRP_Details.Visible = false;
                    GRP_Attendance.Visible = true;
                break;
	        }
        }

        #region Meetings Reports
        #region Report HighestAttendance
        private void HighestAttendanceReport(object pFromDate, object pToDate)
        {
            try
            {
               string vFromDate;
                string vToDate ;
                 DateTime    vDate;
            if (pFromDate !=null)  
                {
                    
                    vFromDate = "'" + pFromDate.ToString() + "'";
                }
            else
	            {
                    vFromDate = "NULL";
	            }

            if (pToDate != null)
            {
                vToDate = "'" + pToDate.ToString() + "'";
            }
            else
            {
                vToDate = "NULL";
            }
                
                string statement = "";
                statement = "" + "\n" +
                "SELECT				  TBL_MainPerson.Name													" + "\n" +
                "					  ,TBL_MainPerson.Mobile												" + "\n" +
                "					  ,TBL_Area.AreaDesc													" + "\n" +
                "					  ,TBL_Street.StreetDesc												" + "\n" +
                "					  ,TBL_MainPerson.Phone													" + "\n" +
                "					  ,TBL_MainPerson.FloorNum												" + "\n" +
                "					  ,TBL_MainPerson.BuildingNum											" + "\n" +
                "					  ,ISNULL(COUNT(TBL_Meetings_Details.Pers_ID),0)  AS AttendanceNumber	" + "\n" +
                "					  																		" + "\n" +
                "FROM				  TBL_MainPerson														" + "\n" +
                "LEFT JOIN			  TBL_Meetings_Details													" + "\n" +
                "ON					  TBL_MainPerson.ID = TBL_Meetings_Details.Pers_ID						" + "\n" +
                "LEFT JOIN            TBL_Meetings															" + "\n" +
                "ON					  TBL_Meetings.ID = TBL_Meetings_Details.Meetings_ID					" + "\n" +
                "AND        (MONTH(TBL_Meetings.TDate) >= " + vFromDate + " Or " + vFromDate + " Is Null ) " + "\n" +
                "AND        (MONTH(TBL_Meetings.TDate) <= " + vToDate + " Or " + vToDate + " Is Null ) " + "\n" +
                "LEFT JOIN			  TBL_Area															    " + "\n" +
                "ON					  TBL_Area.ID		 = TBL_MainPerson.Area_ID							" + "\n" +
                "LEFT JOIN			  TBL_Street															" + "\n" +
                "ON					  TBL_Street.ID		 = TBL_MainPerson.Street_ID							" + "\n" +
                "WHERE					1= 1																" + "\n" +
                "GROUP BY			   TBL_MainPerson.Name													" + "\n" +
                "					  ,TBL_MainPerson.Mobile												" + "\n" +
                "					  ,TBL_Area.AreaDesc													" + "\n" +
                "					  ,TBL_Street.StreetDesc 												" + "\n" +
                "					  ,TBL_MainPerson.Phone													" + "\n" +
                "					  ,TBL_MainPerson.FloorNum												" + "\n" +
                "					  ,TBL_MainPerson.BuildingNum											" + "\n" +
                " ORDER BY 8 Desc																			";

                SqlConnection conn = new SqlConnection(BasicClass.vConectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = statement;
                da.SelectCommand = cmd;
                Datasets.DS_Meetings ds = new Datasets.DS_Meetings();

                conn.Open();
                da.Fill(ds.Tables[0]);
                conn.Close();

                ReportDocument reportDocument = new ReportHighestAttendance();
                reportDocument.Load("ReportHighestAttendance.rpt");
                reportDocument.SetDataSource(ds);
                reportDocument.SetParameterValue("Adress", "اعلى نسبة حضور ");

                CR.ReportSource = reportDocument;


            }
            catch (Exception ex)
            {
                
                ExceptionHandler.HandleException(ex.Message,this.Name, "HighestAttendanceReport");
            }
        }
        private void BTN_LoadByDate_Click(object sender, EventArgs e)
        {
            try
            {
                if (_repKey !=null)
                {
                    if (_repKey == "RepHighestAttendance")
                    {
                        HighestAttendanceReport(TXT_fromDate.Value, TXT_ToDate.Value);
                    }
                    else if (_repKey == "RepAttendanceInMonth")
                    {
                        AttendanceInMonthReport(CMX_MeetingMonth.Value);
                    }
                    else if (_repKey == "RepAttendanceInPeriod")
                    {
                        AttendanceInPeriodReport(TXT_fromDate.Value, TXT_ToDate.Value);
                    }
                }
            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "BTN_LoadByDate_Click");
            }
        }
        #endregion
        #region Attendance in Month
        private void AttendanceInMonthReport(object pFromDate)
        {
            try
            {
                string vFromDate;
                if (pFromDate != null)
                {

                    vFromDate = "'" + pFromDate.ToString() + "'";
                }
                else
                {
                    vFromDate = "NULL";
                }

                

                string statement = "";
               statement = "" + "\n" +
                "SELECT	Distinct	 	TBL_Meetings_Details.Pers_ID									" + "\n" +
                "					  , TBL_Meetings.TDate												" + "\n" +
                "					  ,  TBL_MainPerson.Name											" + "\n" +
                "					  ,TBL_MainPerson.Mobile											" + "\n" +
                "					  ,TBL_Area.AreaDesc												" + "\n" +
                "					  ,TBL_Street.StreetDesc											" + "\n" +
                "					  ,TBL_MainPerson.Phone												" + "\n" +
                "					  ,TBL_MainPerson.FloorNum											" + "\n" +
                "					  ,TBL_MainPerson.BuildingNum										" + "\n" +
                "FROM				  TBL_Meetings														" + "\n" +
                "LEFT JOIN			  TBL_Meetings_Details												" + "\n" +
                "ON					  TBL_Meetings.ID = TBL_Meetings_Details.Meetings_ID				" + "\n" +
                "LEFT JOIN			  TBL_MainPerson													" + "\n" +
                "ON					  TBL_MainPerson.ID = TBL_Meetings_Details.Pers_ID					" + "\n" +
                "LEFT JOIN			  TBL_Area															" + "\n" +
                "ON					  TBL_Area.ID		 = TBL_MainPerson.Area_ID						" + "\n" +
                "LEFT JOIN			  TBL_Street														" + "\n" +
                "ON					  TBL_Street.ID		 = TBL_MainPerson.Street_ID						" + "\n" +
                "WHERE		1=1																			" + "\n" +
                "AND        (MONTH(TBL_Meetings.TDate) >= " + vFromDate + " Or " + vFromDate + " Is Null )	" + "\n" +
                "AND        (MONTH(TBL_Meetings.TDate) <= " + vFromDate + " Or " + vFromDate + " Is Null )	" + "\n" +
                "																						";
                SqlConnection conn = new SqlConnection(BasicClass.vConectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = statement;
                da.SelectCommand = cmd;
                Datasets.DS_Meetings ds = new Datasets.DS_Meetings();

                conn.Open();
                da.Fill(ds.Tables[0]);
                conn.Close();

                ReportDocument reportDocument = new AttendanceInMonth();
                reportDocument.Load("AttendanceInMonth.rpt");
                reportDocument.SetDataSource(ds);
                reportDocument.SetParameterValue("Adress", "المواظبة فى شهر ");

                CR.ReportSource = reportDocument;


            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "HighestAttendanceReport");
            }
        }
        private void BTN_MeetingMonth_Click(object sender, EventArgs e)
        {
            try
            {
                AttendanceInMonthReport(CMX_MeetingMonth.Value);
            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "BTN_MeetingMonth_Click");
            }
        }
        #endregion
        #region Attendance in Period
        private void AttendanceInPeriodReport(object pFromDate, object pToDate)
        {
            try
            {
                string vFromDate;
                string vToDate;
                if (pFromDate != null)
                {

                    vFromDate = "'" + pFromDate.ToString() + "'";
                }
                else
                {
                    vFromDate = "NULL";
                }


                if (pToDate != null)
                {

                    vToDate = "'" + pToDate.ToString() + "'";
                }
                else
                {
                    vToDate = "NULL";
                }


                string statement = "";
                statement = "" + "\n" +
                 "SELECT	Distinct	 	TBL_Meetings_Details.Pers_ID									" + "\n" +
                 "					  , TBL_Meetings.TDate												" + "\n" +
                 "					  ,  TBL_MainPerson.Name											" + "\n" +
                 "					  ,TBL_MainPerson.Mobile											" + "\n" +
                 "					  ,TBL_Area.AreaDesc												" + "\n" +
                 "					  ,TBL_Street.StreetDesc											" + "\n" +
                 "					  ,TBL_MainPerson.Phone												" + "\n" +
                 "					  ,TBL_MainPerson.FloorNum											" + "\n" +
                 "					  ,TBL_MainPerson.BuildingNum										" + "\n" +
                 "FROM				  TBL_Meetings														" + "\n" +
                 "LEFT JOIN			  TBL_Meetings_Details												" + "\n" +
                 "ON					  TBL_Meetings.ID = TBL_Meetings_Details.Meetings_ID				" + "\n" +
                 "LEFT JOIN			  TBL_MainPerson													" + "\n" +
                 "ON				  TBL_MainPerson.ID = TBL_Meetings_Details.Pers_ID					" + "\n" +
                 "LEFT JOIN			  TBL_Area															" + "\n" +
                 "ON				  TBL_Area.ID		 = TBL_MainPerson.Area_ID						" + "\n" +
                 "LEFT JOIN			  TBL_Street														" + "\n" +
                 "ON				  TBL_Street.ID		 = TBL_MainPerson.Street_ID						" + "\n" +
                 "WHERE		1=1																			" + "\n" +
                 "AND                 (MONTH(TBL_Meetings.TDate) >= " + vFromDate + " Or " + vFromDate + " Is Null )	" + "\n" +
                 "AND                 (MONTH(TBL_Meetings.TDate) <= " + vToDate + " Or " + vToDate + " Is Null )	" + "\n" +
                 "																						";
                SqlConnection conn = new SqlConnection(BasicClass.vConectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = statement;
                da.SelectCommand = cmd;
                Datasets.DS_Meetings ds = new Datasets.DS_Meetings();

                conn.Open();
                da.Fill(ds.Tables[0]);
                conn.Close();

                ReportDocument reportDocument = new AttendanceInMonth();
                reportDocument.Load("AttendanceInMonth.rpt");
                reportDocument.SetDataSource(ds);
                reportDocument.SetParameterValue("Adress", "المواظبة فى فترة ");

                CR.ReportSource = reportDocument;


            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "AttendanceInPeriodReport");
            }
        }
        #endregion
     
        #endregion

      





    }
}
