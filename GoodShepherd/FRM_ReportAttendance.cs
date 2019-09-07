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
    public partial class FRM_ReportAttendance : Form
    {

        public string _repKey = "";
        public FRM_ReportAttendance()
        {
            InitializeComponent();
            
            TXT_fromDate.Visible = false;
            TXT_ToDate.Visible = false;
            lbl_fromDate.Visible = false;
            lbl_toDate.Visible = false;
            BTN_LoadMeetingByDate.Visible = false;

            lbl_Meetingmonth.Visible = false;
            CMX_MeetingMonth.Visible = false;
            BTN_MeetingMonth.Visible = false;
            BTN_LoadMeetingByDate.Visible = false;           
           
        }
        private void EXP_MainItems_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            _repKey = e.Item.Key;
            TXT_fromDate.Visible = false;
            TXT_ToDate.Visible = false;
            lbl_fromDate.Visible = false;
            lbl_toDate.Visible = false;
            BTN_LoadMeetingByDate.Visible = false;
            BTN_LoadMeetingByDate.Visible = false;
            lbl_Meetingmonth.Visible = false;
            CMX_MeetingMonth.Visible = false;
            BTN_MeetingMonth.Visible = false;
            if (_repKey != null)
            {
                if (_repKey == "RepHighestAttendance")
                {
                    TXT_fromDate.Visible = true;
                    TXT_ToDate.Visible = true;
                    lbl_fromDate.Visible = true;
                    lbl_toDate.Visible = true;
                    BTN_LoadMeetingByDate.Visible = true;
                }
                else if (_repKey == "RepAttendanceInMonth")
                {
                    lbl_Meetingmonth.Visible = true;
                    CMX_MeetingMonth.Visible = true;
                    BTN_MeetingMonth.Visible = true;
                }
                else if (_repKey == "RepAttendanceInPeriod")
                {
                    TXT_fromDate.Visible = true;
                    TXT_ToDate.Visible = true;
                    lbl_fromDate.Visible = true;
                    lbl_toDate.Visible = true;
                    BTN_LoadMeetingByDate.Visible = true;

                }
                else if (_repKey == "RepNoAttendanceInMonth")
                {
                    lbl_Meetingmonth.Visible = true;
                    CMX_MeetingMonth.Visible = true;
                    BTN_MeetingMonth.Visible = true;
                }
                else if (_repKey == "RepNoAttendanceInPeriod")
                {
                    TXT_fromDate.Visible = true;
                    TXT_ToDate.Visible = true;
                    lbl_fromDate.Visible = true;
                    lbl_toDate.Visible = true;
                    BTN_LoadMeetingByDate.Visible = true;
                }
                else if (_repKey == "RepMonthBirthdates")
                {
                    lbl_Meetingmonth.Visible = true;
                    CMX_MeetingMonth.Visible = true;
                    BTN_MeetingMonth.Visible = true;
                }
            }
                
        }


        private void FRM_ReportAttendance_Load(object sender, EventArgs e)
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
       
        //------------------------------------------------------
     
        
        //--------------------------------------------------------------
    
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
                "					  ,TBL_City.CityDesc  As City                       					" + "\n" +
                "FROM				  TBL_MainPerson														" + "\n" +
                "LEFT JOIN			  TBL_Meetings_Details													" + "\n" +
                "ON					  TBL_MainPerson.ID = TBL_Meetings_Details.Pers_ID						" + "\n" +
                "LEFT JOIN            TBL_Meetings															" + "\n" +
                "ON					  TBL_Meetings.ID = TBL_Meetings_Details.Meetings_ID					" + "\n" +
                "LEFT JOIN			  TBL_Area															    " + "\n" +
                "ON					  TBL_Area.ID		 = TBL_MainPerson.Area_ID							" + "\n" +
                "LEFT JOIN			  TBL_City														    " + "\n" +
                "ON					  TBL_City.ID		 = TBL_MainPerson.City_ID							" + "\n" +
                "LEFT JOIN			  TBL_Street															" + "\n" +
                "ON					  TBL_Street.ID		 = TBL_MainPerson.Street_ID							" + "\n" +
                "WHERE					1= 1																" + "\n" +
                "AND        (MONTH(TBL_Meetings.TDate) >= " + vFromDate + " Or " + vFromDate + " Is Null ) " + "\n" +
                "AND        (MONTH(TBL_Meetings.TDate) <= " + vToDate + " Or " + vToDate + " Is Null ) " + "\n" +
                "GROUP BY			   TBL_MainPerson.Name													" + "\n" +
                "					  ,TBL_MainPerson.Mobile												" + "\n" +
                "					  ,TBL_Area.AreaDesc													" + "\n" +
                "					  ,TBL_Street.StreetDesc 												" + "\n" +
                "					  ,TBL_MainPerson.Phone													" + "\n" +
                "					  ,TBL_MainPerson.FloorNum												" + "\n" +
                "					  ,TBL_MainPerson.BuildingNum	,TBL_City.CityDesc      				" + "\n" +
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
                    else if (_repKey == "RepNoAttendanceInMonth")
                    {
                        NoAttendanceInMonthReport(CMX_MeetingMonth.Value);
                    }
                    else if (_repKey == "RepNoAttendanceInPeriod")
                    {
                        NoAttendanceInPeriodReport(TXT_fromDate.Value, TXT_ToDate.Value);
                    }
                    else if (_repKey == "RepMonthBirthdates")
                    {
                        MonthBirthdatesReport(TXT_fromDate.Value);
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
                "SELECT	Distinct	 	TBL_Meetings_Details.Pers_ID	AS ID_Pers								" + "\n" +
                "					  , TBL_Meetings.TDate												" + "\n" +
                "					  , TBL_Meetings.Title 	,TBL_Meetings_Details.AttendanceTime	" + "\n" +
                "				       ,TBL_city	.CityDesc	AS City								" + "\n" +
                "					  , TBL_MainPerson.Name											" + "\n" +
                "					  ,TBL_MainPerson.Mobile											" + "\n" +
                "					  ,TBL_Area.AreaDesc												" + "\n" +
                "					  ,TBL_Street.StreetDesc											" + "\n" +
                "					  ,TBL_MainPerson.Phone												" + "\n" +
                "					  ,TBL_MainPerson.FloorNum											" + "\n" +
                "					  ,TBL_MainPerson.BuildingNum	,	TBL_DayTypes.[Desc] As DayType    " + "\n" +
                "FROM				  TBL_Meetings														" + "\n" +
                "LEFT JOIN			  TBL_Meetings_Details												" + "\n" +
                "ON					  TBL_Meetings.ID = TBL_Meetings_Details.Meetings_ID				" + "\n" +
                "Left JOIN			dbo.TBL_DayTypes														" + "\n" +
                "ON					dbo.TBL_Meetings.ID					= dbo.TBL_DayTypes.ID				" + "\n" +
                "LEFT JOIN			  TBL_MainPerson													" + "\n" +
                "ON					  TBL_MainPerson.ID = TBL_Meetings_Details.Pers_ID					" + "\n" +
                "Left JOIN      TBL_City																		" + "\n" +
                "ON				TBL_MainPerson.City_ID = TBL_City.ID											" + "\n" +
                "LEFT JOIN			  TBL_Area															" + "\n" +
                "ON					  TBL_Area.ID		 = TBL_MainPerson.Area_ID						" + "\n" +
                "LEFT JOIN			  TBL_Street														" + "\n" +
                "ON					  TBL_Street.ID		 = TBL_MainPerson.Street_ID						" + "\n" +
                "WHERE		1=1																			" + "\n" +
                "AND        (MONTH(TBL_Meetings.TDate) = " + vFromDate + " Or " + vFromDate + " Is Null )	" + "\n" +
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
                if (_repKey != null)
                {
                    if (_repKey == "RepAttendanceInMonth")
                    {
                        AttendanceInMonthReport(CMX_MeetingMonth.Value);
                    }
                   
                    else if (_repKey == "RepNoAttendanceInMonth")
                    {
                        NoAttendanceInMonthReport(CMX_MeetingMonth.Value);
                    }
                    else if (_repKey == "RepMonthBirthdates")
                    {
                        MonthBirthdatesReport(CMX_MeetingMonth.Value);
                    }
                   
                }
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
                 "SELECT	Distinct	 	TBL_Meetings_Details.Pers_ID AS ID_Pers						" + "\n" +
                 "					  , TBL_Meetings.TDate												" + "\n" +
                 "					  , TBL_Meetings.Title ,TBL_Meetings_Details.AttendanceTime			" + "\n" +
                 "				       ,TBL_city	.CityDesc	AS City								" + "\n" +
                 "					  ,  TBL_MainPerson.Name											" + "\n" +
                 "					  ,TBL_MainPerson.Mobile											" + "\n" +
                 "					  ,TBL_Area.AreaDesc												" + "\n" +
                 "					  ,TBL_Street.StreetDesc											" + "\n" +
                 "					  ,TBL_MainPerson.Phone												" + "\n" +
                 "					  ,TBL_MainPerson.FloorNum											" + "\n" +
                 "					  ,TBL_MainPerson.BuildingNum,	TBL_DayTypes.[Desc] As DayType    " + "\n" +
                 "FROM				  TBL_Meetings														" + "\n" +
                 "LEFT JOIN			  TBL_Meetings_Details												" + "\n" +
                 "ON					  TBL_Meetings.ID = TBL_Meetings_Details.Meetings_ID			" + "\n" +
                 "Left JOIN			dbo.TBL_DayTypes													" + "\n" +
                 "ON					dbo.TBL_Meetings.ID					= dbo.TBL_DayTypes.ID		" + "\n" +
                 "LEFT JOIN			  TBL_MainPerson													" + "\n" +
                 "ON				  TBL_MainPerson.ID = TBL_Meetings_Details.Pers_ID					" + "\n" +
                 "Left JOIN           TBL_City															" + "\n" +
                "ON				      TBL_MainPerson.City_ID = TBL_City.ID								" + "\n" +
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
        #region No Attendance in Month
        private void NoAttendanceInMonthReport(object pFromDate)
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
                        "SELECT			 TBL_MainPerson.ID			AS ID_Pers													" + "\n" +		
                        "				,TBL_MainPerson.Name , TBL_MainPerson.Mobile									" + "\n" +
                        "				,TBL_city	.CityDesc	AS City														" + "\n" +
                        "				,TBL_Area.AreaDesc																" + "\n" +
                        "				,TBL_Church.ChurchName															" + "\n" +
                        "				, TBL_MainPerson.BirthDate														" + "\n" +
                        "				,TBL_Street.StreetDesc	  														" + "\n" +
                        "				,TBL_MainPerson.BuildingNum														" + "\n" +
                        "				,TBL_MainPerson.FloorNum  														" + "\n" +
                        "FROM			TBL_MainPerson			  														" + "\n" +
                        "INNER JOIN      TBL_Church																		" + "\n" +	 
                        "ON				TBL_Church.ID = TBL_MainPerson.Church_ID										" + "\n" +	
                        "INNER JOIN      TBL_City																		" + "\n" +
                        "ON				TBL_MainPerson.City_ID = TBL_City.ID											" + "\n" +
                        "INNER JOIN      TBL_Area																		" + "\n" +
                        "ON				TBL_Area.ID = TBL_MainPerson.Area_ID											" + "\n" +
                        "INNER JOIN      TBL_Street																		" + "\n" +
                        "ON				TBL_Street.ID = TBL_MainPerson.Street_ID										" + "\n" +
                        "WHERE TBL_MainPerson.ID																		" + "\n" +
                        "NOT IN (																						" + "\n" +
                        "SELECT			Pers_ID																			" + "\n" +
                        "from			TBL_Meetings																	" + "\n" +
                        "INNER JOIN		TBL_Meetings_Details															" + "\n" +
                        "ON				TBL_Meetings.ID	 = TBL_Meetings_Details.Meetings_ID								" + "\n" +
                        "WHERE        (MONTH(TBL_Meetings.TDate) = " + vFromDate + " Or " + vFromDate + " Is Null )	" + "\n" +
                        ")"  ;
                SqlConnection conn = new SqlConnection(BasicClass.vConectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = statement;
                da.SelectCommand = cmd;
                Datasets.DS_Meetings ds = new Datasets.DS_Meetings();

                conn.Open();
                da.Fill(ds.Tables[0]);
                conn.Close();

                ReportDocument reportDocument = new ReportNoAttendanceInMonth();
                reportDocument.Load("AttendanceInMonth.rpt");
                reportDocument.SetDataSource(ds);
                reportDocument.SetParameterValue("Adress", "لم يحضر فى شهر ");

                CR.ReportSource = reportDocument;


            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "NoAttendanceInMonthReport");
            }
        }
       
        #endregion
        #region No Attendance in Period
        private void NoAttendanceInPeriodReport(object pFromDate , object pToDate)
        {
            try
            {
                string vFromDate ="";
                string vToDate="";
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
                        "SELECT			 TBL_MainPerson.ID	AS ID_Pers															" + "\n" +		
                        "				,TBL_MainPerson.Name , TBL_MainPerson.Mobile									" + "\n" +
                        "				,TBL_city	.CityDesc	 AS City														" + "\n" +
                        "				,TBL_Area.AreaDesc																" + "\n" +
                        "				,TBL_Church.ChurchName															" + "\n" +
                        "				, TBL_MainPerson.BirthDate														" + "\n" +
                        "				,TBL_Street.StreetDesc	  														" + "\n" +
                        "				,TBL_MainPerson.BuildingNum														" + "\n" +
                        "				,TBL_MainPerson.FloorNum  														" + "\n" +
                        "FROM			TBL_MainPerson			  														" + "\n" +
                        "INNER JOIN      TBL_Church																		" + "\n" +	 
                        "ON				TBL_Church.ID = TBL_MainPerson.Church_ID										" + "\n" +	
                        "INNER JOIN      TBL_City																		" + "\n" +
                        "ON				TBL_MainPerson.City_ID = TBL_City.ID											" + "\n" +
                        "INNER JOIN      TBL_Area																		" + "\n" +
                        "ON				TBL_Area.ID = TBL_MainPerson.Area_ID											" + "\n" +
                        "INNER JOIN      TBL_Street																		" + "\n" +
                        "ON				TBL_Street.ID = TBL_MainPerson.Street_ID										" + "\n" +
                        "WHERE TBL_MainPerson.ID																		" + "\n" +
                        "NOT IN (																						" + "\n" +
                        "SELECT			Pers_ID																			" + "\n" +
                        "from			TBL_Meetings																	" + "\n" +
                        "INNER JOIN		TBL_Meetings_Details															" + "\n" +
                        "ON				TBL_Meetings.ID	 = TBL_Meetings_Details.Meetings_ID								" + "\n" +
                        "WHERE        (MONTH(TBL_Meetings.TDate) >= " + vFromDate + " Or " + vFromDate + " Is Null ) " + "\n" +
                        "AND        (MONTH(TBL_Meetings.TDate) <= " + vToDate + " Or " + vToDate + " Is Null ) " + "\n" +
                        "		)																				";
                SqlConnection conn = new SqlConnection(BasicClass.vConectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = statement;
                da.SelectCommand = cmd;
                Datasets.DS_Meetings ds = new Datasets.DS_Meetings();

                conn.Open();
                da.Fill(ds.Tables[0]);
                conn.Close();

                ReportDocument reportDocument = new ReportNoAttendanceInMonth();
                reportDocument.Load("ReportNoAttendanceInMonth.rpt");
                reportDocument.SetDataSource(ds);
                reportDocument.SetParameterValue("Adress", "لم يحضر فى فترة ");

                CR.ReportSource = reportDocument;


            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "NoAttendanceInPeriodReport");
            }
        }

        #endregion
        #region Month birthdates
        private void MonthBirthdatesReport(object pFromDate)
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
                        "SELECT AgeIntYears													" + "\n" +
                        ", AreaDesc															" + "\n" +
                        ", BirthDate														" + "\n" +
                        ", BuildingNum														" + "\n" +
                        ", ChurchName														" + "\n" +
                        ", Church_ID														" + "\n" +
                        ", City, FloorNum, Mobile, Name, PersType_ID, PersonType, Phone		" + "\n" +
                        ", Statuse															" + "\n" +
                        ", StreetDesc														" + "\n" +
                        "FROM VIW_GetPeopleData												" + "\n" + 
                        "WHERE        (MONTH(BirthDate) = " + vFromDate + " Or " + vFromDate + " Is Null )	" ;
                SqlConnection conn = new SqlConnection(BasicClass.vConectionString);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = statement;
                da.SelectCommand = cmd;
                Datasets.DS_PeopleData ds = new Datasets.DS_PeopleData();
                ds.EnforceConstraints = false;
                conn.Open();
                da.Fill(ds.Tables[0]);
                conn.Close();

                ReportDocument reportDocument = new MonthbirthDates();
                reportDocument.Load("MonthbirthDates.rpt");
                reportDocument.SetDataSource(ds);
                reportDocument.SetParameterValue("Adress", "اعياد ميلاد الشهر");

                CR.ReportSource = reportDocument;


            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "NoAttendanceInMonthReport");
            }
        }

        #endregion
        #endregion

      





    }
}
