using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.IO;
using Infragistics.Win.UltraWinGrid;
using System.Diagnostics;

namespace GoodShepherd.Forms
{
    public partial class FRM_Meetings : Telerik.WinControls.UI.RadForm
    {
        public FRM_Meetings()
        {
            InitializeComponent();
        }
       
        #region VARIABLES__DECLARATION
        string[] vSqlStatment = new string[1];
        public string vFormMode = "NI";
        public string vFormBlock = "";
        public string vQuestionCode = "";
        public bool isFormLoaded = false;
        public int vFRM_recPos = 0;
        #endregion
        #region NEW__RECORD
        private void sNewRecord()
        {
            try
            {
                tabControl1.SelectedTab = tabControl1.TabPages["TAB_Details"];
                Timer_MSgCleaner.Stop();
                TXT_Title.Tag = "";
                TXT_Title.Text = "";
                 CHK_Servant.Checked = false;
                CHK_Father.Checked = false;

                DateTime date = DateTime.Parse(BasicClass.fGetCurDateTime().ToString());
                string Tdateformat = "dd-MM-yyyy";
                TXT_TDate.Value = date.ToString(Tdateformat);

                // DateTime dt = DateTime.Parse(TXT_Date.Text);
             

                string DayStartformat = "hh:mm";
                string vDayStart = "";
                // DateTime dt = DateTime.Parse(TXT_Date.Text);
                vDayStart =  date.ToString(DayStartformat) ;
               
               TXT_DayStart.Value = vDayStart  ;
                TXT_Speaker.SelectedIndex = -1;
                TXT_SpeakerChurch.SelectedIndex = -1;
                TXT_DayType.SelectedIndex = -1;
                TXT_SpeakerChurch.SelectedIndex = -1;
                
                TXT_DayType.SelectedIndex = -1;
                DS_MeetingDetail.Rows.Clear();

                isFormLoaded = false;
                vFormMode = "NI";
                vFormBlock = "";
               
               
              }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "sNewRecord");
            }
        }
        #endregion
        #region FILL_DROP_DOWNS
        private void sFillSpeakerChurch()
        {
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                TXT_SpeakerChurch.Items.Clear();
                //TXT_FatherChurch.Items.Clear();
                // Here i open connection to databse and execute command to get roles to fill dropdown list
                SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;
                vSqlCommand.CommandText = "\n" +
                                   "SELECT       ID, ChurchName" + "\n" +
                                   "FROM         dbo.TBL_Church";
                sqlConnection1.Open();
                vSQLReader = vSqlCommand.ExecuteReader();
                while (vSQLReader.Read())
                {
                    if (vSQLReader["ID"] != System.DBNull.Value)
                    {
                        // TXT_FatherChurch.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["ChurchName"].ToString());
                        TXT_SpeakerChurch.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["ChurchName"].ToString());
                    }

                }
                vSQLReader.Close();
                sqlConnection1.Close();
            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "sFillChurch");
            }
        }
        private void sFillDayType()
        {
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                TXT_DayType.Items.Clear();
                // Here i open connection to databse and execute command to get roles to fill dropdown list
                SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;
                vSqlCommand.CommandText = "\n" +
                                   "SELECT       ID, [Desc]" + "\n" +
                                   "FROM         dbo.TBL_DayTypes";
                sqlConnection1.Open();
                vSQLReader = vSqlCommand.ExecuteReader();
                while (vSQLReader.Read())
                {
                    if (vSQLReader["ID"] != System.DBNull.Value)
                    {
                       TXT_DayType.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["Desc"].ToString());
                    }

                }
                vSQLReader.Close();
                sqlConnection1.Close();
            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "sFillDayType");
            }
        }
        private void sFillSpeaker()
        {
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                TXT_Speaker.Items.Clear();
               
                // Here i open connection to databse and execute command to get roles to fill dropdown list
                SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;
                vSqlCommand.CommandText = "\n" +
                                   "SELECT       ID, Name" + "\n" +
                                   "FROM         dbo.TBL_MainPerson" + "\n" +
                                   "WHERE        PersType_ID IN(1,2)";
                sqlConnection1.Open();
                vSQLReader = vSqlCommand.ExecuteReader();
                while (vSQLReader.Read())
                {
                    if (vSQLReader["ID"] != System.DBNull.Value)
                    {
                        TXT_Speaker.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["Name"].ToString());
                       
                    }

                }
                vSQLReader.Close();
                sqlConnection1.Close();
            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "sFillServant");
            }
        }
        private void sRefreshDropdowns()
        {
            try
            {
                sFillSpeaker();
                sFillSpeakerChurch();
                sFillDayType();
            }
            catch (Exception ex)
            {
                
               ExceptionHandler.HandleException(ex.Message,this.Name,"RefreshDropdowns");
            }
        }
        #endregion
        #region HANDLE__MESSAGES
        private void sHandleMessage(int pType ,string Message)
        {
            try
            {
                this.STS_Message.Items["MSG"].Text = Message;
                //Critical
                if (pType == 1)
                {
                    this.STS_Message.Items["MSG"].ForeColor = System.Drawing.Color.Red;
                }
                //Warning
                else if (pType == 2)
                {
                    this.STS_Message.Items["MSG"].ForeColor = System.Drawing.Color.Navy;
                }
                //Done
                else if (pType == 3)
                {
                    this.STS_Message.Items["MSG"].ForeColor = System.Drawing.Color.Green;
                }
                //'Save
                else if (pType == 4)
                {
                    this.STS_Message.Items["MSG"].ForeColor = System.Drawing.Color.Blue;
                }
                //''Assistant
                else if (pType == 5)
                {
                    this.STS_Message.Items["MSG"].ForeColor = System.Drawing.Color.Black;
                }

                Timer_MSgCleaner.Start();
               
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "sHandleMessages");
            }
        }
        #endregion
        #region TOOLBAR_HANDLING
        private void RefreshTools(bool pNew, bool pSave, bool pDelete, bool pExportToExcel, bool pClose, bool pImportFromExcel)
        {
            try
            {
                Toolbar_Options.Tools["BTN_New"].SharedProps.Enabled = pNew;
                Toolbar_Options.Tools["BTN_Save"].SharedProps.Enabled = pSave;
                Toolbar_Options.Tools["BTN_Delete"].SharedProps.Enabled = pDelete;
                Toolbar_Options.Tools["BTN_Exit"].SharedProps.Enabled = pClose;
                Toolbar_Options.Tools["BTN_ExportToExcel"].SharedProps.Enabled = pExportToExcel;
                Toolbar_Options.Tools["BTN_ImportFromExcel"].SharedProps.Enabled = pImportFromExcel;
            }
            catch (Exception ex)
            {
                
                ExceptionHandler.HandleException(ex.Message, this.Name,"RefreshTools");
            }
        }
        #endregion
        #region FORM_EVENTS
            private void FRM_Meetings_Load(object sender, EventArgs e)
            {
                try
                {
                   // this.vIW_MeetingsDataTableAdapter.GetDataByChurchAndCity(BasicClass.vChurchID, BasicClass.vCityID);
                    this.vIW_MeetingsDataTableAdapter.FillByCityAndChurch(this.dS_Meetings.VIW_MeetingsData,BasicClass.vChurchID, BasicClass.vCityID);
                    this.vIW_GetPeopleData1TableAdapter.FillByChurchID(this.goodShepherdDataSet.VIW_GetPeopleData1,BasicClass.vChurchID);
                    tabControl1.TabPages[0].Select();
                    RefreshTools(true, false, false, true, true, false);
                    sRefreshDropdowns();
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, this.Name, "FRM_Meetings_Load");
                }
            }
            private void GRD_Summary_DoubleClick(object sender, EventArgs e)
            {
                try
                {
                    if (GRD_Summary.ActiveRow != null)
                    {
                        if (GRD_Summary.ActiveRow.Cells["ID"].Value != null)
                        {

                            sQueryMeeting(long.Parse(GRD_Summary.ActiveRow.Cells["ID"].Value.ToString()));
                        }
                    }
                    else
                    {
                        sNewRecord();
                    }
                }
                catch (Exception ex)
                {

                    ExceptionHandler.HandleException(ex.Message, this.Name, "GRD_Summary_DoubleClick");
                }
            }
            private void TXTs_Enter(object sender, EventArgs e)
            {
                try
                {
                    vFormBlock = "Master";
                }
                catch (Exception ex)
                {

                    ExceptionHandler.HandleException(ex.Message, this.Name, "TXT_Title_Enter");
                }
            }
            private void CHK_Father_CheckStateChanged(object sender, EventArgs e)
            {

            string checkedName = ((Infragistics.Win.UltraWinEditors.UltraCheckEditor)sender).Name;
            if (checkedName == "CHK_Father")
            {
                if (CHK_Father.Checked == true)
                {
                  CHK_Servant.Checked = false;
             
                }
        
            }
            else if (checkedName == "CHK_Servant")
            {
                if (CHK_Servant.Checked ==true)
                {
                  CHK_Father.Checked = false;
       
                }
        
            }
            if (vFormMode.Trim().ToUpper() == "NI")
            {
                vFormMode = "I";
            }
            else if (vFormMode.Trim().ToUpper() == "N")
            {
                vFormMode = "U";
            }
        }
            private void TXTs_BeforeDropDown(object sender, CancelEventArgs e)
            {
                try
                {
                    string checkedName = ((Infragistics.Win.UltraWinEditors.UltraComboEditor)sender).Name;
                    if (checkedName == "TXT_ResponsibleChurch")
                    {
                        sFillSpeakerChurch();
                    }
                   else if (checkedName == "TXT_Speaker")
                    {
                        sFillSpeaker();
                    }
                     else if (checkedName == "TXT_DayType")
                    {
                        sFillDayType();
                    }
                }
                catch (Exception ex)
                {

                    ExceptionHandler.HandleException(ex.Message, this.Name, "TXT_City_BeforeDropDown");
                }
            }
            private void TXT_City_SelectionChanged(object sender, EventArgs e)
            {
                try
                {
                    if (vFormMode.Trim().ToUpper() == "NI")
                    {
                        vFormMode = "I";
                    }
                    else if (vFormMode.Trim().ToUpper() == "N")
                    {
                        vFormMode = "U";
                    }
                }
                catch (Exception ex)
                {

                    ExceptionHandler.HandleException(ex.Message, this.Name, "TXT_City_SelectionChanged");
                }
            }
            private void CMX_Person_ValueChanged(object sender, EventArgs e)
            {
                if (CMX_Person.Value != null)
                {
                    if (GRD_Details.ActiveRow!= null)
                    {
                        if (CMX_Person.Value != null)
                        {
                            GRD_Details.ActiveRow.Cells["ID_Pers"].Value = long.Parse(CMX_Person.Value.ToString().Trim());
                            GRD_Details.ActiveRow.Cells["Name"].Value = CMX_Person.SelectedRow.Cells["Name"].Value.ToString();
                            GRD_Details.ActiveRow.Cells["MobileNumber"].Value = CMX_Person.SelectedRow.Cells["Mobile"].Value.ToString();
                            GRD_Details.ActiveRow.Cells["City"].Value = CMX_Person.SelectedRow.Cells["City"].Value.ToString();
                            GRD_Details.ActiveRow.Cells["Area"].Value = CMX_Person.SelectedRow.Cells["AreaDesc"].Value.ToString();
                            GRD_Details.ActiveRow.Cells["Street"].Value = CMX_Person.SelectedRow.Cells["StreetDesc"].Value.ToString();
                   
                            if (CMX_Person.SelectedRow.Cells["BirthDate"].Value != System.DBNull.Value)
                            {
                                DateTime time = DateTime.Parse(CMX_Person.SelectedRow.Cells["BirthDate"].Value.ToString());
                                string format = "dd-MM-yyyy";
                                // DateTime dt = DateTime.Parse(TXT_Date.Text);
                                string vTDate = time.ToString(format);
                                GRD_Details.ActiveRow.Cells["BirthDate"].Value = vTDate;
                            }

                            else
                            {
                                GRD_Details.ActiveRow.Cells["BirthDate"].Value = null;
                            }

                            DateTime attTime = DateTime.Parse(BasicClass.fGetCurDateTime().ToString());
                            string attFormat = "hh:mm";
                            // DateTime dt = DateTime.Parse(TXT_Date.Text);
                            string MeetingattTime = attTime.ToString(attFormat);
                            GRD_Details.ActiveRow.Cells["AttendanceTime"].Value = MeetingattTime;
                        }

                    }
                }
            }
            private void Timer_MSgCleaner_Tick(object sender, EventArgs e)
            {
                //Timer_MSgCleaner.Stop();
                this.STS_Message.Items["MSG"].Text = "";
            }
            private void CHK_Male_CheckStateChanged(object sender, EventArgs e)
            {
                string checkedName = ((Infragistics.Win.UltraWinEditors.UltraCheckEditor)sender).Name;

                if (vFormMode.Trim().ToUpper() == "NI")
                {
                    vFormMode = "I";
                }
                else if (vFormMode.Trim().ToUpper() == "N")
                {
                    vFormMode = "U";
                }

            }
            private void TXTs_TextChanged(object sender, EventArgs e)
            {
                if (vFormMode.Trim().ToUpper() == "NI")
                {
                    vFormMode = "I";
                }
                else if (vFormMode.Trim().ToUpper() == "N")
                {
                    vFormMode = "U";
                }
            }
            private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
            {
                if (e.TabPage.Name == "TAB_Summary")
                {
                    vIW_GetPeopleData1TableAdapter.GetDataByChurchID(BasicClass.vChurchID);
                    GRD_Summary.Refresh();
                    GRD_Summary.UpdateData();
                    RefreshTools(true, false, false, true, true,false);
                }
                else if (e.TabPage.Name == "TAB_Details")
                {
                    RefreshTools(true, true, true, false, true,false);
                }
            }
            private void CMX_Person_BeforeDropDown(object sender, CancelEventArgs e)
            {
                this.vIW_MeetingsDataTableAdapter.FillByCityAndChurch(this.dS_Meetings.VIW_MeetingsData, BasicClass.vChurchID, BasicClass.vCityID);
            }
            private void Toolbar_Options_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
            {

                try
                {

                    switch (e.Tool.Key)
                    {
                        case "BTN_Exit":
                            if (fCancelTransaction() == true)
                            {
                                this.Close();

                            }
                            break;
                        case "BTN_ExportToExcel":
                            if (fCancelTransaction() == true)
                            {
                              //  sExportToExcel();
                                SaveFileDialog saveDialog = new SaveFileDialog();
                                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                                saveDialog.FilterIndex = 2;

                                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {
                                    ultraGridExcelExporter1.Export(GRD_Summary, saveDialog.FileName);
                                    sHandleMessage(4, "تم تصدير البيانات بنجاح");
                                }
                            }
                        
                            break;
                        case "BTN_ImportFromExcel":
                            if (fCancelTransaction() == true)
                            {
                            sImportFromExcel();
                        
                            }
                            break;
                        case "BTN_Delete":
                            //if (fCancelTransaction() == true)
                            //{
                                //  Delete();
                                sDeleteRecord();
                            //}

                            break;
                        case "BTN_New":
                            if (fCancelTransaction() == true)
                            {
                                sNewRecord();
                            }

                            break;
                        case "BTN_Save":
                            Timer_MSgCleaner.Stop();
                            if (fSaveData(false) == true)
                            {
                                sHandleMessage(4, "تم الحفظ بنجاح");
                            }
                        

                            break;


                    }

                }
                catch (Exception ex)
                {

                    ExceptionHandler.HandleException(ex.Message, this.Name, "Toolbar_Options_ToolClick");
                }
            

            }
        #endregion
        #region SAVE_DATA
        private long fGetNewID(string Table, string CodeColumn)
        {
            long GetCode = 0;
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                //SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;
                vSqlCommand.CommandText = "SELECT ISNULL(MAX(" + CodeColumn + "),0) + 1 " + "\n" +
                                          "FROM [" + Table + "]" + "\n" +
                                          " WHERE   City_Id                      =" + BasicClass.vCityID + "\n" +
                                          " AND     Church_ID                    =" + BasicClass.vChurchID + "\n";
                sqlConnection1.Open();
                GetCode = long.Parse(vSqlCommand.ExecuteScalar().ToString());
                sqlConnection1.Close();
                //vSQLReader.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "fGetGetCode");
            }
            return GetCode;
        }
        private void sSaveMaster()
        {
            BasicClass.vSqlConn = new SqlConnection(BasicClass.vConectionString);
            try
            {
                string vIsWorking = "";
                string vSaveStatment = null;
                string vTitle = "";
               
                string vSpeakerChurch = "";
                string vSpeakerServant = "";

                string vTDate;
                string vDayStart;
                string vDayType = "";
                int vPersonType=0;
                
                if (CHK_Father.Checked == true)
                {
                    vPersonType = 1;
                }
                else if (CHK_Servant.Checked == true)
                {
                    vPersonType = 2;
                }
                if (TXT_Title.Text != "")
                {
                    vTitle = "'" + TXT_Title.Text.ToString().Trim() + "'";
                }
                else
                {
                    vTitle = "NULL";
                }
                
                

                  if (TXT_SpeakerChurch.SelectedIndex != -1)
                {
                    vSpeakerChurch= "'" + TXT_SpeakerChurch.SelectedItem.DataValue.ToString().Trim() + "'";
                }
                else
                {
                    vSpeakerChurch = "NULL";
                }

                  if (TXT_Speaker.SelectedIndex != -1)
                {
                    vSpeakerServant= "'" + TXT_Speaker.SelectedItem.DataValue.ToString().Trim() + "'";
                }
                else
                {
                    vSpeakerServant = "NULL";
                }


                  if (TXT_DayType.SelectedIndex != -1)
                  {
                      vDayType = "'" + TXT_DayType.SelectedItem.DataValue.ToString().Trim() + "'";
                  }
                  else
                  {
                      vDayType = "NULL";
                  }

                if (TXT_TDate.Value !=null)
	            {
                     DateTime time = DateTime.Parse(TXT_TDate.Value.ToString());
                     string format = "MM-dd-yyyy";
                      // DateTime dt = DateTime.Parse(TXT_Date.Text);
                        vTDate = "'" + time.ToString(format) + "'";
	            }
                else
	            {
                                vTDate = "NULL";
	            }

                if (TXT_DayStart.Value != null)
                {
                    DateTime time = DateTime.Parse(TXT_DayStart.Value.ToString());
                    string format = "hh:mm";
                    // DateTime dt = DateTime.Parse(TXT_Date.Text);
                    vDayStart = "'" + time.ToString(format) + "'";
                }
                else
                {
                    //vDayStart = "NULL";
                    DateTime time = DateTime.Parse(DateTime.Now.TimeOfDay.ToString());
                    string format = "hh:mm";
                    // DateTime dt = DateTime.Parse(TXT_Date.Text);
                    vDayStart = "'" + time.ToString(format) + "'";
                }
                if (vFormMode == "N")
                {
                    return;
                }
                else if (vFormMode == "U")
                {
                    vSaveStatment = "UPDATE [dbo].[TBL_Meetings]							            " + "\n" +
                                        "   SET [Title]				    =		" + vTitle +"			" + "\n" +
                                        "      ,[TDate]			        =		"+vTDate+"				" + "\n" +
                                        "      ,[DayStart]			    =		" + vDayStart + "		" + "\n" +
                                        "      ,[SpeakerPersType_ID]	=		" + vPersonType + "	    " + "\n" +
                                        "      ,[SpeakerChurch_ID]	    =	    " + vSpeakerChurch + "	" + "\n" +
                                        "      ,[SpeakerPerson_ID]		=       " + vSpeakerServant + "	" + "\n" +
                                        "      ,[DayType_ID]		    =       " + vDayType + "	" + "\n" +
                                        "      ,LastUserUpdate          ='" + BasicClass.vUsrName + "'" + "\n" +
                                        "      ,LastUpdate              =   GetDate()                 " + "\n" +
                                        "      ,ProcessID               ='" + Process.GetCurrentProcess().Id.ToString() + "'" + "\n" +
                                        "      ,MachineName             ='" + Strings.Trim(System.Environment.MachineName) + "'" + "\n" +
                                        " WHERE     ID                  ="+TXT_Title.Tag+"" + "\n" +
                                        " AND       City_Id            =" + BasicClass.vCityID +  "\n" +
                                        " AND       Church_ID          =" + BasicClass.vChurchID +  "\n" ;
                    }
                else if (vFormMode == "I")
                {
                    TXT_Title.Tag = fGetNewID("TBL_Meetings", "ID");
                    string vIsActive = null;
                    string vIsSalesMan = null;
                    vSaveStatment =     "INSERT INTO [dbo].[TBL_Meetings]																				" + "\n" +
                                        "      ([Church_ID]			    " + "\n" +
                                        "      ,[City_ID]			        " + "\n" +
                                        "      ,[ID]			        " + "\n" +
                                        "      ,[Title]				    " + "\n" +
                                        "      ,[TDate]			        " + "\n" +
                                        "      ,[DayStart]			    " + "\n" +
                                        "      ,[SpeakerPersType_ID]	" + "\n" +
                                        "      ,[SpeakerChurch_ID]	    " + "\n" +
                                        "      ,[SpeakerPerson_ID]		" + "\n" +
                                        "      ,[DayType_ID]		    " + "\n" +
                                        "      ,LastUserUpdate         " + "\n" +
                                        "      ,LastUpdate             " + "\n" +
                                        "      ,ProcessID              " + "\n" +
                                        "      ,MachineName)           " + "\n" +
                                        "     VALUES (					" + "\n"+
                                        "       "+ BasicClass.vChurchID +"" + "\n" +
                                        "      ," + BasicClass.vCityID + " " + "\n" +
                                        "      ," + TXT_Title.Tag + "   " + "\n" +
                                        "      ," + vTitle +"			" + "\n" +
                                        "      ,"+vTDate+"				" + "\n" +
                                        "      ," + vDayStart + "		" + "\n" +
                                        "      ," + vPersonType + "	    " + "\n" +
                                        "      ," + vSpeakerChurch + "	" + "\n" +
                                        "      ," + vSpeakerServant + "	" + "\n" +
                                        "      ," + vDayType +  "\n"+
                                        "      ,'" + BasicClass.vUsrName + "'" + "\n" +
                                        "      ,   GetDate()                 " + "\n" +
                                        "      ,'" + Process.GetCurrentProcess().Id.ToString() + "'" + "\n" +
                                        "      ,'" + Strings.Trim(System.Environment.MachineName) + "')" + "\n";
                }
                sFillSqlStatmentArray(vSaveStatment);

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "sSaveMaster");
            }
            finally
            {
                if (BasicClass.vSqlConn.State == ConnectionState.Broken || BasicClass.vSqlConn.State == ConnectionState.Open)
                {
                    BasicClass.vSqlConn.Close();
                }
            }
        }
        public void sSaveDetails()
        {
            GRD_Details.UpdateData();
            string vStatement = "";
            long vNoOfRows = 0;
            try
            {
                foreach (UltraGridRow vRow in GRD_Details.Rows)
                {
                    if (vRow!= null)
                    {
                        string vAttendanceTime = "NULL";
                        if (vRow.Cells["AttendanceTime"].Value != null)
                        {
                            DateTime time = DateTime.Parse(vRow.Cells["AttendanceTime"].Value.ToString());
                            string format = "hh:mm";
                               vAttendanceTime = "'" + time.ToString(format) + "'";
                        }
                       
                        // DateTime dt = DateTime.Parse(TXT_Date.Text);
                     

                        if (vRow.Cells["Name"].Value != null)
                        {
                            if (vRow.Cells["DML"].Value == "I")
                            {
                                
                                vStatement =
                                 "INSERT INTO [dbo].[TBL_Meetings_Details]														   " + "\n" +
                                 "           ( City_Id                  , Church_ID                 ,       [Meetings_ID]                 ,        [Pers_ID]                                    ,          [AttendanceTime]             ,               [ProcessID]                         ,[Lastupdate],                [MachineName]    ,LastUserUpdate       ) " + "\n" +
                                 "     VALUES(" + BasicClass.vCityID + "," + BasicClass.vChurchID + "," + TXT_Title.Tag.ToString().Trim() + " ,'" + vRow.Cells["ID_Pers"].Value.ToString() + "'  ," + vAttendanceTime + ",'" + Process.GetCurrentProcess().Id.ToString() + "',  getDate() ,'" + Environment.MachineName.Trim() + "','" + BasicClass.vUsrName + "') " + "\n";

                                sFillSqlStatmentArray(vStatement);

                            }
                            else if (vRow.Cells["DML"].Value == "U")
                            {
                                vStatement +=
                                  "UPDATE     [dbo].[TBL_Meetings_Details]														   " + "\n" +
                                  " Set        [Pers_ID]            = '" + vRow.Cells["ID_Pers"].Value.ToString() + "'  " + "\n" +
                                  " ,          [AttendanceTime]     = " + vAttendanceTime + " " + "\n" +
                                  " ,          [ProcessID]          = '" + Process.GetCurrentProcess().Id.ToString() + "' " + "\n" +
                                  " ,          [MachineName]        = '" + Environment.MachineName.Trim() + "' " + "\n" +
                                  " ,          [Lastupdate]         = GETDATE() " + "\n" +
                                  " ,           LastUserUpdate   ='" + BasicClass.vUsrName + "'" + "\n" +
                                  "WHERE   TBL_Meetings_Details.City_Id                      =" + BasicClass.vCityID + "\n" +
                                  "AND     TBL_Meetings_Details.Church_ID                    =" + BasicClass.vChurchID + "\n" +
                                  "AND	    TBL_Meetings_Details.Meetings_ID		         =" + TXT_Title.Tag.ToString().Trim() + "	" + "\n" +
                                  "AND         Ser                  = " + vRow.Cells["Ser"].Value.ToString() + "   ";
                                sFillSqlStatmentArray(vStatement);

                            }
                        }
                    }
                }




            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "sSaveDetails");

            }
            finally
            {
                if (BasicClass.vSqlConn.State == ConnectionState.Broken || BasicClass.vSqlConn.State == ConnectionState.Open)
                {
                    BasicClass.vSqlConn.Close();
                }
            }
        }
        private bool fSaveData(bool pMessage)
        {
            bool vIsSaved = false;
            long rowsAffected = 0;
            string vGender = "";

            try
            {
                if (pMessage == true)
                {
                    if (MessageBox.Show("هل تريد الحفظ ؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == System.Windows.Forms.DialogResult.Yes)
                    {
                        
                        if (fIsDataChanged() ==true)
                        {
                                if (fValidatePerson() == true)
                                {
                                    sSaveMaster();
                                }
                                else
                                {
                                    return false;
                                }
                                if (fValidateDetails() == true)
                                {
                                   sSaveDetails();
                                }
                                else
                                {
                                  
                                    return false;
                                }
                                    rowsAffected = BasicClass.fDMLData(vSqlStatment, this.Name);
                                    if (rowsAffected > 0)
                                    {
                                        vIsSaved = true;
                                        this.vIW_MeetingsDataTableAdapter.FillByCityAndChurch(this.dS_Meetings.VIW_MeetingsData,BasicClass.vChurchID , BasicClass.vCityID);
                                        sNewRecord();
                                        sResetFormMode();
                                    }
                                    else
                                    {
                                        sHandleMessage(1, "فشل حفظ البيانات");
                                    }
                               
                        }

                    }
                }
                else
                {
                    if (fIsDataChanged() == true)
                    {
                        if (fValidatePerson() == true)
                        {
                            sSaveMaster();
                        }
                        else
                        {
                            return false;
                        }
                        if (fValidateDetails() == true)
                        {
                             sSaveDetails();
                        }
                        else
                        {

                            return false;
                        }
                        rowsAffected = BasicClass.fDMLData(vSqlStatment, this.Name);
                        if (rowsAffected > 0)
                        {
                            vIsSaved = true;
                            this.vIW_MeetingsDataTableAdapter.Fill(this.dS_Meetings.VIW_MeetingsData);
                            sNewRecord();
                            sResetFormMode();
                        }
                        else
                        {
                            sHandleMessage(1, "فشل حفظ البيانات");
                        }

                    }
                }
                sEmptySqlStatmentArray();

            }
            catch (Exception Ex)
            {
                ExceptionHandler.HandleException(Ex.Message, this.Name, "fSaveData");
            }
            finally
            {
                if (BasicClass.vSqlConn.State == ConnectionState.Broken || BasicClass.vSqlConn.State == ConnectionState.Open)
                {
                    BasicClass.vSqlConn.Close();
                }
            }
            return vIsSaved;
        }
        private void sResetFormMode()
        {
            try
            {
                vFormMode = "N";
                foreach (var item in GRD_Details.Rows)
                {
                    item.Cells["DML"].Value = "N";
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "sResetFormMode");
            }
        }
        private bool fValidatePerson()
        {
            bool vReult = false;
            try
            {

                Timer_MSgCleaner.Stop();

                if (TXT_Title.Text == "")
                {
                    sHandleMessage(1,"من فضلك ادخل عنوان الموضوع");
                    
                    TXT_Title.SelectAll();
                    TXT_Title.Focus();
                    return false;
                }

                if (TXT_DayType.SelectedIndex == -1)
                {
                    sHandleMessage(1, "من فضلك اختار نوع الاجتماع");

                    TXT_DayType.SelectAll();
                    TXT_DayType.Focus();
                    return false;
                }


                if (CHK_Father.Checked ==false && CHK_Servant.Checked ==false)
                {
                 sHandleMessage(1, "يجب اختيار طبيعة المتكلم فى الموضوع");
                    return false;   
                }
                

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "fValidatePerson");
            }
            return true;
        }
        private void sEmptySqlStatmentArray()
        {
            vSqlStatment = new string[1];
        }
        private void sFillSqlStatmentArray(string pStatment)
        {
            //FK 16/4/2005
            //here I fill the Array to send it to transaction
            if (string.IsNullOrEmpty(vSqlStatment[Information.UBound(vSqlStatment)]))
            {
                vSqlStatment[Information.UBound(vSqlStatment)] = pStatment;
            }
            else
            {
                Array.Resize(ref vSqlStatment, Information.UBound(vSqlStatment) + 2);
                vSqlStatment[Information.UBound(vSqlStatment)] = pStatment;
            }
        }
        private bool fIsDataChanged()
        {
            bool result = false;
            try
            {
                if (vFormMode == "I" || vFormMode.Trim().ToUpper() == "U")
                {
                    return true;
                }

                else if (GRD_Details.Rows.Count > 0)
                {
                    foreach (var item in GRD_Details.Rows)
                    {
                        if (item != null)
                        {
                            if (item.Cells["DML"].Value.ToString().Trim() =="I" ||item.Cells["DML"].Value.ToString().Trim() =="U")
                            {
                                return true;
                            }
                        }
                    }
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
            return result;
        }
        public bool fCancelTransaction()
        {
            try
            {

                if (fIsDataChanged() == true)
                {
                    if (MessageBox.Show("هل تريد إلغاء التغييرات الحالية", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == System.Windows.Forms.DialogResult.Yes)
                    {
                        sNewRecord();
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
        #endregion
        #region DELETE_PERSON
         private long fDeleteMaster()
        {
            long vResult = 0;
            try
            {
                if (GRD_Details.Rows.Count > 0)
                {
                    MessageBox.Show("يرجى حذف التفاصيل اولا", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return 0;
                }

                string vDeleteStmt = "";
                vDeleteStmt = "DELETE FROM [TBL_Meetings]		" + "\n" +
                              " WHERE ID                      =" + TXT_Title.Tag + "" + "\n" +
                              " AND City_Id                      =" + BasicClass.vCityID + "\n" +
                              " AND Church_ID                    =" + BasicClass.vChurchID + "\n";
                vResult = BasicClass.fDMLData(vDeleteStmt, this.Name);
            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "fDeleteMaster");
                vResult = 0;
            }
            return vResult;
        }
         private long fDeleteDetail()
         {
             long vResult = 0;
             try
             {

                 string vDeleteStmt = "";
                 vDeleteStmt = "DELETE FROM [TBL_Meetings_Details]		" + "\n" +
                                "WHERE   TBL_Meetings_Details.City_Id                      =" + BasicClass.vCityID + "\n" +
                                "AND     TBL_Meetings_Details.Church_ID                    =" + BasicClass.vChurchID + "\n" +
                                "AND	TBL_Meetings_Details.Meetings_ID		               =" + TXT_Title.Tag + "	" + "\n" +
                               "AND		Ser =	" + GRD_Details.ActiveRow.Cells["Ser"].Value + "			" + "\n";
                 vResult = BasicClass.fDMLData(vDeleteStmt, this.Name);
             }
             catch (Exception ex)
             {

                 ExceptionHandler.HandleException(ex.Message, this.Name, "fDeletedetail");
                 vResult = 0;
             }
             return vResult;
         }
        private void sDeleteRecord()
        {
            try
            {
                long vRowsAffected = 0;


                if (MessageBox.Show("هل تريد حذف هذا البيان ؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    bool vIsRowSelected = false;
                    if (vFormBlock == "Detail")
                    {
                        if (GRD_Details.ActiveRow!= null)
                        {
                            vIsRowSelected = false;
                        }
                        else
                        {
                            vIsRowSelected = true;
                        }
                    }
                    else
                    {
                        vIsRowSelected = true;
                    }
                    if (vIsRowSelected = false)
                    {
                        MessageBox.Show("يرجى اختيار بيان للحذف", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (vFormBlock == "Master")
                        {
                            vRowsAffected = fDeleteMaster();
                            if (vRowsAffected > 0)
                            {
                                MessageBox.Show("تم حذف البيان بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                               //to go to new record after delete last record
                                this.vIW_MeetingsDataTableAdapter.Fill(this.dS_Meetings.VIW_MeetingsData);
                                    sNewRecord();
                                
                                
                            }
                            else
                            {
                                MessageBox.Show("لم يتم مسح البيان", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else if (vFormBlock == "Details")
                        {
                            if (GRD_Details.ActiveRow.Cells["DML"].Value.ToString().Trim() == "N" || GRD_Details.ActiveRow.Cells["DML"].Value.ToString().Trim() == "U")
                            {
                                   vRowsAffected = fDeleteDetail();
                                    if (vRowsAffected > 0)
                                    {
                                        GRD_Details.ActiveRow.Delete(false);


                                    }
                            }
                            else
                            {
                                GRD_Details.ActiveRow.Delete(false);
                                vRowsAffected = 1;
                            }
                            if (vRowsAffected > 0)
                            {
                                MessageBox.Show("تم حذف البيان بنجاح", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("لم يتم مسح البيان", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }


                        }

                    }

                }

            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "sDeleteRecord");
            }
        }
        private bool fIsvalidDelete()
        {
            bool result = false;
            try
            {
                string vstmt = "";
                vstmt = "FROM [TBL_Meetings_Details]		" + "\n" +
                        "WHERE (Meetings_ID = " + TXT_Title.Tag + ")" + "\n";
                if (BasicClass.fCount_Rec(vstmt) > 0)
                {
                    result = false;
                }
                else
                {
                    result = true;
                }

            }
            catch (Exception ex )
            {
                
                ExceptionHandler.HandleException(ex.Message,this.Name,"fIsvalidDelete");
            }
            return result;
        }
        #endregion
        #region SAVE_DETAILS
        private bool fValidateDetails()
        {
            try
            {
                if (GRD_Details.Rows.Count == 0)
                {
                    MessageBox.Show("يرجى اختيار المخدومين", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                foreach (var item in GRD_Details.Rows)
                {
                    if (item != null)
                    {

                        if (item.Cells["Name"].Value != null)
                        {
                            if (item.Cells["Name"].Value.ToString() == "")
                            {
                                MessageBox.Show("يرجى اختيار الاسم", "معلومات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                item.Selected = true;
                                return false;
                            }
                            
                        }

                   }
                }

                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "Validatation");
                return false;
            }
        }
        #endregion
        #region QUERY_Person
        private bool sQueryMeeting(long pID)
        {
            ////SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            ////SqlCommand vSqlCommand = new SqlCommand();
            bool vResult = false;
            tabControl1.SelectedTab = tabControl1.TabPages["TAB_Details"];
           
            try
            {
                    ////////SqlDataReader vSQLReader;
                    ////////vSqlCommand.Connection = sqlConnection1;
                    ////////vSqlCommand.CommandText = "\n" +
                    ////////        "SELECT				dbo.TBL_Church.ChurchName												" + "\n" +
                    ////////        "					, dbo.TBL_Meetings.SpeakerChurch_ID										" + "\n" +
                    ////////        "					, dbo.TBL_Meetings.SpeakerPerson_ID										" + "\n" +
                    ////////        "					, dbo.TBL_Meetings.SpeakerPersType_ID									" + "\n" +
                    ////////        "					, dbo.TBL_Meetings.Title												" + "\n" +
                    ////////        "					, dbo.TBL_Meetings.DayType_ID											" + "\n" +
                    ////////        "					, dbo.TBL_MainPerson.Name												" + "\n" +
                    ////////        "					, dbo.TBL_PersonType.PersonType											" + "\n" +
                    ////////        "					, dbo.TBL_DayTypes.[Desc]												" + "\n" +
                    ////////        "					, dbo.TBL_Meetings.DayStart												" + "\n" +
                    ////////        "					, dbo.TBL_Meetings.TDate												" + "\n" +
                    ////////        "FROM				dbo.TBL_Meetings														" + "\n" +
                    ////////        "INNER JOIN         dbo.TBL_Church															" + "\n" +
                    ////////        "ON					dbo.TBL_Meetings.SpeakerChurch_ID	= dbo.TBL_Church.ID					" + "\n" +
                    ////////        "INNER JOIN         dbo.TBL_MainPerson														" + "\n" +
                    ////////        "ON					dbo.TBL_Meetings.SpeakerPerson_ID	= dbo.TBL_MainPerson.ID				" + "\n" +
                    ////////        "AND				dbo.TBL_Church.ID					= dbo.TBL_MainPerson.Church_ID		" + "\n" +
                    ////////        "INNER JOIN         dbo.TBL_PersonType														" + "\n" +
                    ////////        "ON					dbo.TBL_Meetings.SpeakerPersType_ID = dbo.TBL_PersonType.ID				" + "\n" +
                    ////////        "INNER JOIN			dbo.TBL_DayTypes														" + "\n" +
                    ////////        "ON					dbo.TBL_Meetings.ID					= dbo.TBL_DayTypes.ID				" + "\n" +
                    ////////        "WHERE				dbo.TBL_Meetings.ID				    = " + pID + "																		" + "\n";

                //////sqlConnection1.Open();
                //////vSQLReader = vSqlCommand.ExecuteReader();
                if (GRD_Summary.ActiveRow != null && pID > 0)
                {
                       if (pID > 0)
                        {
                            TXT_Title.Tag = pID;
                            TXT_Title.Focus();
                        }

                        else
                        {
                            TXT_Title.Tag = 0;
                        }

                        if (GRD_Summary.ActiveRow.Cells["Title"].Value != System.DBNull.Value)
                        {
                            TXT_Title.Text = GRD_Summary.ActiveRow.Cells["Title"].Value.ToString();
                        }

                        else
                        {
                            TXT_Title.Text = "";
                        }


                        if (GRD_Summary.ActiveRow.Cells["PersonType"].Value != System.DBNull.Value)
                        {
                            if (CHK_Servant.Text.ToString() == GRD_Summary.ActiveRow.Cells["PersonType"].Value.ToString())
                            {
                                CHK_Servant.Checked = true;
                            }
                            else if (CHK_Father.Text.ToString() == GRD_Summary.ActiveRow.Cells["PersonType"].Value.ToString())
                            {
                                CHK_Father.Checked = true;
                            }

                        }

                        else
                        {
                            CHK_Father.Checked = false;
                            CHK_Servant.Checked = false;

                        }
                      if (GRD_Summary.ActiveRow.Cells["TDate"].Value != System.DBNull.Value)
                        {
                            DateTime time = DateTime.Parse(GRD_Summary.ActiveRow.Cells["TDate"].Value.ToString().Trim()).Date;
                            string format = "dd-MM-yyyy";
                            // DateTime dt = DateTime.Parse(TXT_Date.Text);
                            string vTDate = time.ToString(format);
                            TXT_TDate.Value = GRD_Summary.ActiveRow.Cells["TDate"].Value;
                        }

                        else
                        {
                            TXT_TDate.Value = null;
                        }

                      if (GRD_Summary.ActiveRow.Cells["DayStart"].Value != System.DBNull.Value)
                      {
                          DateTime time = DateTime.Parse(GRD_Summary.ActiveRow.Cells["DayStart"].Value.ToString().Trim());
                          string format = "hh:mm";
                          // DateTime dt = DateTime.Parse(TXT_Date.Text);
                          string vDayStart = "" + time.ToString(format) + "";
                          TXT_DayStart.Value = vDayStart;
                      }

                      else
                      {
                          TXT_DayStart.Value = null;
                      }


                        if (GRD_Summary.ActiveRow.Cells["SpeakerChurch_ID"].Value != System.DBNull.Value)
                        {
                            foreach (var item in TXT_SpeakerChurch.Items)
                            {
                                if (item.DataValue.ToString().Trim() == GRD_Summary.ActiveRow.Cells["SpeakerChurch_ID"].Value.ToString().Trim())
                                {
                                    TXT_SpeakerChurch.SelectedItem = item;
                                    break;
                                }
                            }
                        }

                        else
                        {
                            TXT_SpeakerChurch.SelectedIndex = -1;
                        }

                        if (GRD_Summary.ActiveRow.Cells["SpeakerPerson_ID"].Value != System.DBNull.Value)
                        {
                            foreach (var item in TXT_Speaker.Items)
                            {
                                if (item.DataValue.ToString().Trim() == GRD_Summary.ActiveRow.Cells["SpeakerPerson_ID"].Value.ToString().Trim())
                                {
                                    TXT_Speaker.SelectedItem = item;
                                    break;
                                }
                            }
                        }

                        else
                        {
                            TXT_Speaker.SelectedIndex = -1;
                        }

                        if (GRD_Summary.ActiveRow.Cells["DayType_ID"].Value != System.DBNull.Value)
                        {
                            foreach (var item in TXT_DayType.Items)
                            {
                                if (item.DataValue.ToString().Trim() == GRD_Summary.ActiveRow.Cells["DayType_ID"].Value.ToString().Trim())
                                {
                                    TXT_DayType.SelectedItem = item;
                                    break;
                                }
                            }
                        }

                        else
                        {
                            TXT_DayType.SelectedIndex = -1;
                        }
                        sQueryDetails(pID);

                        vResult = true;
                        vFormMode = "N";
                    }
                 else
                {
                    sNewRecord();
                }

            }
            catch (Exception ex)
            {
                vResult = false;
                ExceptionHandler.HandleException(ex.Message, this.Name, "TXT_FindByCode_Enter");
            }
            finally
            {
                if (BasicClass.vSqlConn.State == ConnectionState.Broken || BasicClass.vSqlConn.State == ConnectionState.Open)
                {
                    BasicClass.vSqlConn.Close();
                }
            }
            return vResult;
        }
        private bool sQueryDetails(long MeetingID)
        {
            bool vResult = false;
            try
            {

                SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
                SqlCommand vSqlCommand = new SqlCommand();

                SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;

                string vstmt = "";

                vstmt = "SELECT				  TBL_Meetings_Details.Ser			AS 	Ser							" + "\n" +
                        "					 , TBL_Meetings_Details.AttendanceTime								" + "\n" +
                        "					 , TBL_MainPerson.ID		        AS ID_Pers						" + "\n" +
                        "					 , TBL_MainPerson.Name												" + "\n" +
                        "					 , TBL_MainPerson.City_ID											" + "\n" +
                        "					 , TBL_MainPerson.Area_ID											" + "\n" +
                        "					 , TBL_MainPerson.Street_ID											" + "\n" +
                        "					 , TBL_City.CityDesc												" + "\n" +
                        "                     , TBL_Area.AreaDesc												" + "\n" +
                        "                     , TBL_Street.StreetDesc											" + "\n" +
                        "                     , TBL_MainPerson.Mobile	AS MobileNumber							" + "\n" +
                        "                     , TBL_MainPerson.BirthDate										" + "\n" +
                        "FROM			TBL_Meetings_Details													" + "\n" +
                        "LEFT JOIN      TBL_MainPerson															" + "\n" +
                        "ON				TBL_Meetings_Details.Pers_ID	= TBL_MainPerson.ID						" + "\n" +
                        "LEFT JOIN      TBL_City																" + "\n" +
                        "ON				TBL_MainPerson.City_ID			= TBL_City.ID							" + "\n" +
                        "LEFT JOIN      TBL_Area																" + "\n" +
                        "ON				TBL_MainPerson.Area_ID			= TBL_Area.ID							" + "\n" +
                        "LEFT JOIN		TBL_Street																" + "\n" +
                        "ON				TBL_MainPerson.Street_ID		= TBL_Street.ID							" + "\n" +
                        "WHERE   TBL_Meetings_Details.City_Id                      =" + BasicClass.vCityID + "\n" +
                        "AND     TBL_Meetings_Details.Church_ID                    =" + BasicClass.vChurchID + "\n"+
                        "AND	TBL_Meetings_Details.Meetings_ID		               =" + MeetingID + "	" + "\n";
                vSqlCommand.CommandText = vstmt;

                sqlConnection1.Open();
                vSQLReader = vSqlCommand.ExecuteReader();

                if (vSQLReader.HasRows == true)
                {
                    DS_MeetingDetail.Rows.Clear();
                    int vRowCounter = 0;
                    while (vSQLReader.Read())
                    {
                        //to fill all field by found to next adn previous
                        DS_MeetingDetail.Rows.SetCount(vRowCounter + 1);

                        DS_MeetingDetail.Rows[vRowCounter]["DisplaySer"] = vRowCounter + 1;
                        if (vSQLReader["Ser"] != System.DBNull.Value) { DS_MeetingDetail.Rows[vRowCounter]["Ser"] = vSQLReader["Ser"].ToString().Trim(); } else { DS_MeetingDetail.Rows[vRowCounter]["Ser"] = 0; }
                        if (vSQLReader["ID_Pers"] != System.DBNull.Value) { DS_MeetingDetail.Rows[vRowCounter]["ID_Pers"] = vSQLReader["ID_Pers"].ToString().Trim(); } else { DS_MeetingDetail.Rows[vRowCounter]["ID_Pers"] = ""; }
                        if (vSQLReader["Name"] != System.DBNull.Value) { DS_MeetingDetail.Rows[vRowCounter]["Name"] = vSQLReader["Name"].ToString().Trim(); } else { DS_MeetingDetail.Rows[vRowCounter]["Name"] = ""; }
                        if (vSQLReader["AttendanceTime"] != System.DBNull.Value) {
                            DateTime time = DateTime.Parse(vSQLReader["AttendanceTime"].ToString().Trim());
                            string format = "hh:mm";
                            // DateTime dt = DateTime.Parse(TXT_Date.Text);
                            string vAttendanceTime = "" + time.ToString(format) + "";
                            DS_MeetingDetail.Rows[vRowCounter]["AttendanceTime"] = vAttendanceTime; 
                        } else { DS_MeetingDetail.Rows[vRowCounter]["AttendanceTime"] = null; }
                        if (vSQLReader["CityDesc"] != System.DBNull.Value) { DS_MeetingDetail.Rows[vRowCounter]["City"] = vSQLReader["CityDesc"].ToString().Trim(); } else { DS_MeetingDetail.Rows[vRowCounter]["City"] = ""; }
                        if (vSQLReader["AreaDesc"] != System.DBNull.Value) { DS_MeetingDetail.Rows[vRowCounter]["Area"] = vSQLReader["AreaDesc"].ToString().Trim(); } else { DS_MeetingDetail.Rows[vRowCounter]["Area"] = ""; }
                        if (vSQLReader["StreetDesc"] != System.DBNull.Value) { DS_MeetingDetail.Rows[vRowCounter]["Street"] = vSQLReader["StreetDesc"].ToString().Trim(); } else { DS_MeetingDetail.Rows[vRowCounter]["Street"] = ""; }
                        if (vSQLReader["MobileNumber"] != System.DBNull.Value) { DS_MeetingDetail.Rows[vRowCounter]["MobileNumber"] = vSQLReader["MobileNumber"].ToString().Trim(); } else { DS_MeetingDetail.Rows[vRowCounter]["MobileNumber"] = ""; }
                        if (vSQLReader["BirthDate"] != System.DBNull.Value) {
                            //DateTime time = DateTime.Parse(vSQLReader["BirthDate"].ToString().Trim());
                            //string format = "dd-MM-yyyy";
                            //// DateTime dt = DateTime.Parse(TXT_Date.Text);
                            //string vBirthDate = time.ToString(format) ;
                            DS_MeetingDetail.Rows[vRowCounter]["BirthDate"] = vSQLReader["BirthDate"];//vBirthDate;
                        } else { DS_MeetingDetail.Rows[vRowCounter]["BirthDate"] = null; }
                         DS_MeetingDetail.Rows[vRowCounter]["DML"] = "N";
                        vRowCounter += 1;
                    }
                    vSQLReader.Close();
                    sqlConnection1.Close();
                    GRD_Details.DataSource = DS_MeetingDetail;
                    GRD_Details.DataBind();
                    GRD_Details.Refresh();
                    GRD_Details.UpdateData();
                    vResult = true;
                }

            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "sQueryDetails");
                vResult = false;
            }
            finally
            {
                BasicClass.vSqlConn.Close();
            }

            return vResult;


        }
        #endregion
        #region EXPORT_Summary_TO_EXCEL
        private void sExportToExcel()
        {
            try
            {
                /// <summary> 
                /// Exports the datagridview values to Excel. 
                /// </summary> 
                // Creating a Excel object. 
                sHandleMessage(2, "جارى تصدير البيانات");


                //Getting the location and file name of the excel to save from user. 
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.FileName = "بيانات حضور الاجتماع ";
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ultraGridExcelExporter1.Export(GRD_Summary, saveDialog.FileName);

                }
            }



            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "ExportToExcel");
            }
            finally
            {

            }
        }
        #endregion
        #region EXPORT_TO_EXCEL
        [STAThread]
        private void sImportFromExcel()
        {
            try
            {
                FRM_ImportFromExcel vFrm = new FRM_ImportFromExcel();
                vFrm.ShowDialog();
            }
            catch (Exception ex)
            {
                
                ExceptionHandler.HandleException(ex.Message,this.Name,"sImportFromExcel");
            }
        }
#endregion
        #region GRDs_Management
        private void GRD_Details_Enter(object sender, EventArgs e)
        {
            vFormBlock = "Details";
        }
        private void GRD_Details_CellChange(object sender, CellEventArgs e)
        {

            ////////if (vFormMode == "NI")
            ////////{
            ////////    vFormMode = "I";
            ////////}
            ////////else if (vFormMode == "N")
            ////////{
            ////////    vFormMode = "U";
            ////////}

            if (GRD_Details.ActiveRow != null)
            {
                if (GRD_Details.ActiveRow.Cells["ID_Pers"].Value != null)
                {
                    vFormBlock = "Details";
                    if (GRD_Details.ActiveRow.Cells["ID_Pers"].Value.ToString() != "")
                    {
                        if (GRD_Details.ActiveRow.Cells["DML"].Value.ToString() == "NI")
                        {
                            GRD_Details.ActiveRow.Cells["DML"].Value = "I";
                        }
                        else if (GRD_Details.ActiveRow.Cells["DML"].Value.ToString() == "N")
                        {
                            GRD_Details.ActiveRow.Cells["DML"].Value = "U";
                        }
                       
                    }
                }
            }
            
        }
        private void GRD_Details_AfterRowInsert(object sender, RowEventArgs e)
        {
            vFormBlock = "Details";
            e.Row.Cells["DisplaySer"].Value = e.Row.Index + 1;
            
        }
        private void GRD_Details_AfterRowsDeleted(object sender, EventArgs e)
        {
            foreach (var vRow in GRD_Details.Rows)
            {
                vRow.Cells["DisplaySer"].Value = vRow.Index + 1;
            }
        }

        private void GRD_Details_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (GRD_Details.ActiveRow!= null)
                {
                    if (GRD_Details.ActiveRow.Cells["AttendanceTime"].IsActiveCell == true)
                    {
                        GRD_Details.PerformAction(UltraGridAction.NextRow);
                    }
                    else
                    {
                        GRD_Details.PerformAction(UltraGridAction.NextCell);
                    } 
                }
                
                GRD_Details.PerformAction(UltraGridAction.EnterEditMode);

            }
        }

        #endregion

     
        



    }
}

