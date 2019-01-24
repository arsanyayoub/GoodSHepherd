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
    public partial class FRM_PersonsData : Telerik.WinControls.UI.RadForm
    {
        public FRM_PersonsData()
        {
            InitializeComponent();
        }
       
        #region VARIABLES__DECLARATION
        string[] vSqlStatment = new string[1];
        public string vFormMode = "NI";
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
                TXT_Name.Tag = "";
                TXT_Name.Text = "";
                isFormLoaded = false;
                vFormMode = "NI";
                CHK_IsWorking.Checked = false;

                TXT_WorkDesc.Visible = false;
                LBL_WorkDesc.Visible = false;

                OPT_PersType.CheckedIndex = 1;
                OPT_PersGender.Value = null;
                
                TXT_City.SelectedIndex = -1;
                TXT_Area.SelectedIndex = -1;
                TXT_Street.SelectedIndex = -1;
                TXT_BuildingNo.Text = "";
                TXT_Floor.Text = "";
                TXT_AddressDesc.Text = "";
                TXT_PhoneNo.Text = "";
                TXT_MobileNo.Text = "";

                TXT_BirthDate.Value = null;

                TXT_AcademicLevel.SelectedIndex = -1;
                TXT_AcademicYear.SelectedIndex = -1;
                CMX_College.SelectedIndex = -1;
                CMX_Department.SelectedIndex = -1;
                CMX_Service.SelectedIndex = -1;
                TXT_ResponsibleServant.SelectedIndex = -1;
                TXT_ResponsibleChurch.SelectedIndex = -1;
                TXT_Father.SelectedIndex = -1;
                TXT_FatherChurch.SelectedIndex = -1;
                TXT_ResponsibleChurch.SelectedIndex = -1;
                TXT_Facebook.Text = "";
                TXT_Email.Text = "";
                TXT_Status.SelectedIndex = -1;
                TXT_WorkDesc.Text = "";

                DateTime date = DateTime.Parse(BasicClass.fGetCurDateTime().ToString());
                string Tdateformat = "dd-MM-yyyy";
                TXT_BirthDate.Value = BasicClass.fGetCurDateTime();//date.ToString(Tdateformat);
               }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "sNewRecord");
            }
        }
        #endregion
        #region FILL_DROP_DOWNS
        private void sFillCity()
        {
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                TXT_City.Items.Clear();
                // Here i open connection to databse and execute command to get roles to fill dropdown list
                SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;
                vSqlCommand.CommandText = "\n" +
                                   "SELECT       ID, CityDesc" + "\n" +
                                   "FROM         dbo.TBL_City";
                sqlConnection1.Open();
                vSQLReader = vSqlCommand.ExecuteReader();
                while (vSQLReader.Read())
                {
                    if (vSQLReader["ID"] != System.DBNull.Value)
                    {
                        TXT_City.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["CityDesc"].ToString());
                    }

                }
                vSQLReader.Close();
                sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                
                ExceptionHandler.HandleException(ex.Message,this.Name,"sFillCity");
            }
        }
        private void sFillAreas(int CityId)
        {
           


            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                TXT_Area.Items.Clear();
                if (CityId > 0)
                {
                            // Here i open connection to databse and execute command to get areas to fill dropdown list
                            SqlDataReader vSQLReader;
                            vSqlCommand.Connection = sqlConnection1;
                            vSqlCommand.CommandText = "\n" +
                                               "SELECT     ID, AreaDesc" + "\n" +
                                               "FROM       dbo.TBL_Area" + "\n" +
                                               "WHERE     (City_ID = " + CityId +")";
                            sqlConnection1.Open();
                            vSQLReader = vSqlCommand.ExecuteReader();
                            while (vSQLReader.Read())
                            {
                                if (vSQLReader["ID"] != System.DBNull.Value)
                                {
                                    TXT_Area.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["AreaDesc"].ToString());
                                }

                            }
                            vSQLReader.Close();
                            sqlConnection1.Close();
                }
                else
                {
                    sHandleMessage(1,"يرجى اختيار المحافظة");
                }
                
            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "sFillAreas");
            }
        }
        private void sFillStreet(int CityId , int AreaID)
        {



            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                TXT_Street.Items.Clear();
                if (CityId >0 && AreaID > 0 )
                {
                    // Here i open connection to databse and execute command to get areas to fill dropdown list
                    SqlDataReader vSQLReader;
                    vSqlCommand.Connection = sqlConnection1;
                    vSqlCommand.CommandText = "\n" +
                                       "SELECT     ID, StreetDesc" + "\n" +
                                       "FROM       dbo.TBL_Street" + "\n" +
                                       "WHERE     (Area_ID ="+ AreaID +")";
                    sqlConnection1.Open();
                    vSQLReader = vSqlCommand.ExecuteReader();
                    while (vSQLReader.Read())
                    {
                        if (vSQLReader["ID"] != System.DBNull.Value)
                        {
                            TXT_Street.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["StreetDesc"].ToString());
                        }

                    }
                    vSQLReader.Close();
                    sqlConnection1.Close();
                }
                else
                {
                    if (CityId<=0)
                    {
                         sHandleMessage(1, "يرجى اختيار المحافظة");
                    }
                    else if (AreaID <= 0 )
                    {
                       sHandleMessage(1, "يرجى اختيار المنطقة");  
                    }
                   
                }

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "sFillAreas");
            }
        }
        private void sFillEducationLevel()
        {
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                TXT_AcademicLevel.Items.Clear();
                // Here i open connection to databse and execute command to get roles to fill dropdown list
                SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;
                vSqlCommand.CommandText = "\n" +
                                   "SELECT       ID, EducLevel" + "\n" +
                                   "FROM         dbo.TBL_EducationLevel";
                sqlConnection1.Open();
                vSQLReader = vSqlCommand.ExecuteReader();
                while (vSQLReader.Read())
                {
                    if (vSQLReader["ID"] != System.DBNull.Value)
                    {
                        TXT_AcademicLevel.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["EducLevel"].ToString());
                    }

                }
                vSQLReader.Close();
                sqlConnection1.Close();
            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "sFillEducLevel");
            }
        }
        private void sFillServantChurch()
        {
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                TXT_ResponsibleChurch.Items.Clear();
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
                        TXT_ResponsibleChurch.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["ChurchName"].ToString());
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
        private void sFillfatherChurch()
        {
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                TXT_FatherChurch.Items.Clear();
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
                      TXT_FatherChurch.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["ChurchName"].ToString());
                        
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
        private void sFillService()
        {
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                CMX_Service.Items.Clear();
                // Here i open connection to databse and execute command to get roles to fill dropdown list
                SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;
                vSqlCommand.CommandText = "\n" +
                                   "SELECT       ID, Service" + "\n" +
                                   "FROM         dbo.TBL_Services";
                sqlConnection1.Open();
                vSQLReader = vSqlCommand.ExecuteReader();
                while (vSQLReader.Read())
                {
                    if (vSQLReader["ID"] != System.DBNull.Value)
                    {
                        CMX_Service.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["Service"].ToString());

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
        private void sFillServant()
        {
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                TXT_ResponsibleServant.Items.Clear();
               
                // Here i open connection to databse and execute command to get roles to fill dropdown list
                SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;
                vSqlCommand.CommandText = "\n" +
                                   "SELECT       ID, Name" + "\n" +
                                   "FROM         dbo.TBL_MainPerson" + "\n" +
                                   "WHERE PersType_ID =  2";
                sqlConnection1.Open();
                vSQLReader = vSqlCommand.ExecuteReader();
                while (vSQLReader.Read())
                {
                    if (vSQLReader["ID"] != System.DBNull.Value)
                    {
                        TXT_ResponsibleServant.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["Name"].ToString());
                       
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
        private void sFillFather()
        {
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                TXT_Father.Items.Clear();

                // Here i open connection to databse and execute command to get roles to fill dropdown list
                SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;
                vSqlCommand.CommandText = "\n" +
                                   "SELECT       ID, Name" + "\n" +
                                   "FROM         dbo.TBL_MainPerson" + "\n" +
                                   "WHERE PersType_ID =  1";
                sqlConnection1.Open();
                vSQLReader = vSqlCommand.ExecuteReader();
                while (vSQLReader.Read())
                {
                    if (vSQLReader["ID"] != System.DBNull.Value)
                    {
                        TXT_Father.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["Name"].ToString());

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
        private void sFillEucationYear(int EducLevel_ID)
        {



            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                TXT_AcademicYear.Items.Clear();
                if (EducLevel_ID > 0 )
                {
                    // Here i open connection to databse and execute command to get areas to fill dropdown list
                    SqlDataReader vSQLReader;
                    vSqlCommand.Connection = sqlConnection1;
                    vSqlCommand.CommandText = "\n" +
                                       "SELECT     ID, EducYear" + "\n" +
                                       "FROM       dbo.TBL_EducYear" + "\n" +
                                       "WHERE     (EducLevel_ID = " + EducLevel_ID + ")";
                    sqlConnection1.Open();
                    vSQLReader = vSqlCommand.ExecuteReader();
                    while (vSQLReader.Read())
                    {
                        if (vSQLReader["ID"] != System.DBNull.Value)
                        {
                            TXT_AcademicYear.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["EducYear"].ToString());
                        }

                    }
                    vSQLReader.Close();
                    sqlConnection1.Close();
                }
                else
                {
                    if (EducLevel_ID <= 0)
                    {
                        sHandleMessage(1, "يرجى اختيار المرحلة الدراسية");
                    }
                    
                }

            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "sFillEucationYear");
            }
        }
        private void sFillCollege(int EducLevel_ID)
        {



            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                CMX_College.Items.Clear();
                if (EducLevel_ID > 0)
                {
                    // Here i open connection to databse and execute command to get areas to fill dropdown list
                    SqlDataReader vSQLReader;
                    vSqlCommand.Connection = sqlConnection1;
                    vSqlCommand.CommandText = "\n" +
                                       "SELECT     ID, Collage" + "\n" +
                                       "FROM       dbo.TBL_Collage" + "\n" +
                                       "WHERE     (EducLevel_ID = " + EducLevel_ID + ")";
                    sqlConnection1.Open();
                    vSQLReader = vSqlCommand.ExecuteReader();
                    while (vSQLReader.Read())
                    {
                        if (vSQLReader["ID"] != System.DBNull.Value)
                        {
                            CMX_College.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["Collage"].ToString());
                        }

                    }
                    vSQLReader.Close();
                    sqlConnection1.Close();
                }
                else
                {
                    if (EducLevel_ID <= 0)
                    {
                        sHandleMessage(1, "يرجى اختيار المرحلة الدراسية");
                    }

                }

            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "sFillCollege");
            }
        }
        private void sFillDepartment(int College_ID)
        {



            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                CMX_Department.Items.Clear();
                if (College_ID > 0)
                {
                    // Here i open connection to databse and execute command to get areas to fill dropdown list
                    SqlDataReader vSQLReader;
                    vSqlCommand.Connection = sqlConnection1;
                    vSqlCommand.CommandText = "\n" +
                                       "SELECT     ID, Department" + "\n" +
                                       "FROM       dbo.TBL_Department" + "\n" +
                                       "WHERE     (Coolage_ID = " + College_ID + ")";
                    sqlConnection1.Open();
                    vSQLReader = vSqlCommand.ExecuteReader();
                    while (vSQLReader.Read())
                    {
                        if (vSQLReader["ID"] != System.DBNull.Value)
                        {
                            CMX_Department.Items.Add(vSQLReader["ID"].ToString(), vSQLReader["Department"].ToString());
                        }

                    }
                    vSQLReader.Close();
                    sqlConnection1.Close();
                }
                else
                {
                    if (College_ID <= 0)
                    {
                        sHandleMessage(1, "يرجى اختيار الكلية");
                    }

                }

            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "sFillCollege");
            }
        }
        private void sRefreshDropdowns()
        {
            try
            {
                sFillCity();
                //sFillAreas();
                //sFillStreet();
                sFillEducationLevel();
                sFillServantChurch();
                sFillfatherChurch();
                sFillServant();
                sFillFather();
                sFillService();
                //sFillEucationYear();
                //sFillCollege();
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
            private void FRM_PersonsData_Load(object sender, EventArgs e)                                                   
            {
                this.vIW_ChurchTableAdapter.Fill(this.goodShepherdDataSet.VIW_Church);
                this.vIW_ChurchTableAdapter.Fill(this.goodShepherdDataSet.VIW_Church);
            
                //this.vIW_GetPeopleData1TableAdapter.GetDataByCityID(BasicClass.vCityID);
                this.vIW_GetPeopleData1TableAdapter.FillByChurchID(this.goodShepherdDataSet.VIW_GetPeopleData1,BasicClass.vChurchID);
                tabControl1.TabPages[0].Select();
                TXT_WorkDesc.Visible = false;
                LBL_WorkDesc.Visible = false;
                RefreshTools(true, false, false, true, true,false);
                sRefreshDropdowns();
            }

            private void GRD_Summary_DoubleClick(object sender, EventArgs e)                                                
            {
                try
                {
                    if (GRD_Summary.ActiveRow != null)
                    {
                        if (GRD_Summary.ActiveRow.Cells["ID_Pers"].Value != null)
                        {
                            sQueryPerson(int.Parse(GRD_Summary.ActiveRow.Cells["ID_Pers"].Value.ToString()));
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
         
            private void TXTs_BeforeDropDown(object sender, CancelEventArgs e)                                              
            {
                try
                {
                    string checkedName = ((Infragistics.Win.UltraWinEditors.UltraComboEditor)sender).Name;

                    int cityId = 0;
                    int areaId = 0;
                    int AcademicLevelId = 0;
                    int CollegeId = 0;
                    if (TXT_City.SelectedItem != null)
                    {
                        cityId = int.Parse(TXT_City.SelectedItem.DataValue.ToString());
                    }
                    else
                    {
                        cityId = 0;
                    }

                    if (TXT_Area.SelectedItem != null)
                    {
                        areaId = int.Parse(TXT_Area.SelectedItem.DataValue.ToString());
                    }
                    else
                    {
                        areaId = 0;
                    }

                    if (TXT_AcademicLevel.SelectedItem != null)
                    {
                        AcademicLevelId = int.Parse(TXT_AcademicLevel.SelectedItem.DataValue.ToString());
                    }
                    else
                    {
                        AcademicLevelId = 0;
                    }
                    if (CMX_College.SelectedItem != null)
                    {
                        CollegeId = int.Parse(CMX_College.SelectedItem.DataValue.ToString());
                    }
                    else
                    {
                        CollegeId = 0;
                    }

                    if (checkedName == "TXT_City")
                    {
                        sFillCity();
                    }
                    else if (checkedName == "TXT_Area")
                    {

                        sFillAreas(cityId);
                    }

                    else if (checkedName == "TXT_Street")
                    {
                        sFillStreet(cityId, areaId);
                    }
                    else if (checkedName == "TXT_AcademicLevel")
                    {
                        sFillEducationLevel();
                    }
                    else if (checkedName == "TXT_AcademicYear")
                    {
                        sFillEucationYear(AcademicLevelId);
                    }
                    else if (checkedName == "CMX_College")
                    {
                        sFillCollege(AcademicLevelId);
                    }
                    else if (checkedName == "CMX_Department")
                    {
                        sFillDepartment(CollegeId);
                    }
                    else if (checkedName == "TXT_Service")
                    {
                        sFillService();
                    }
                    else if (checkedName == "TXT_ResponsibleChurch")
                    {
                        sFillServantChurch();
                    }
                    else if (checkedName == "TXT_FatherChurch")
                    {
                        sFillfatherChurch();
                    }
                    else if (checkedName == "TXT_Father")
                    {
                        sFillFather();
                    }
                    else if (checkedName == "TXT_ResponsibleServant")
                    {
                        sFillServant();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, this.Name, "TXT_City_BeforeDropDown");
                }
            }
            private void TXTs_SelectionChanged(object sender, EventArgs e)                                                  
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

            private void Timer_MSgCleaner_Tick(object sender, EventArgs e)                                                  
            {
                //Timer_MSgCleaner.Stop();
                this.STS_Message.Items["MSG"].Text = "";
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
            private void CHK_IsWorking_CheckStateChanged(object sender, EventArgs e)
            {

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
                    RefreshTools(true, true, true, false, true,true);
                }
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
                                sExportToExcel();
                            }
                        
                            break;
                        case "BTN_ImportFromExcel":
                            if (fCancelTransaction() == true)
                            {
                            sImportFromExcel();
                        
                            }
                            break;
                        case "BTN_Delete":
                            if (fCancelTransaction() == true)
                            {
                                //  Delete();
                                DeletePerson();
                            }

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
                private void sSaveData()                                
                {
                    BasicClass.vSqlConn = new SqlConnection(BasicClass.vConectionString);
                    try
                    {
                        string vIsWorking = "";
                        string vSaveStatment = null;
                        string vName = "";
                        string vCity = "";
                        string vArea = "";
                        string vStreet = "";
                        string vAcademicLevel = "";
                        string vAcademicYear = "";
                        string vCollage = "";
                        string vDepartment = "";

                        string vService = "";
                        string vResponsibleChurch = "";
                        string vResponsibleServant = "";

                        string vFatherChurch = "";
                        string vFather = "";
                        string vBirthdate;

                        string vStatus = "";
                        string vPersonType="";
                        string vGender;
                        string vQuestionAbrev = "";



                        if (OPT_PersGender.Value != null)
                        {
                            vGender = "'" + OPT_PersGender.Value + "'";
                        }
                        else
                        {
                            vGender = "NULL";
                        }




                        if (OPT_PersType.CheckedIndex != -1)
                        {
                            vPersonType =  int.Parse(OPT_PersType.Value.ToString()).ToString() ;
                        }
                        else
                        {
                            vPersonType = "NULL" ;
                        }



                        if (CHK_IsWorking.Checked == true)
                        {
                            vIsWorking = "'Y'";
                        }
                        else
                        {
                            vIsWorking = "'N'";
                        }
                        if (TXT_Status.SelectedItem != null)
                        {
                            vStatus = "'" + TXT_Status.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vStatus = "NULL";
                        }
                        if (TXT_Name.Text != "")
                        {
                            vName = "'" + TXT_Name.Text.ToString().Trim() + "'";
                        }
                        else
                        {
                            vName = "NULL";
                        }
                        if (TXT_City.SelectedIndex != -1)
                        {
                            vCity = "'" + TXT_City.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vCity = "NULL";
                        }

                        if (TXT_Area.SelectedIndex != -1)
                        {
                            vArea = "'" + TXT_Area.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vArea = "NULL";
                        }

                        if (TXT_Street.SelectedIndex != -1)
                        {
                            vStreet = "'" + TXT_Street.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vStreet = "NULL";
                        }

                        if (TXT_AcademicLevel.SelectedIndex != -1)
                        {
                            vAcademicLevel = "'" + TXT_AcademicLevel.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vAcademicLevel = "NULL";
                        }

                        if (TXT_AcademicYear.SelectedIndex != -1)
                        {
                            vAcademicYear = "'" + TXT_AcademicYear.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vAcademicYear = "NULL";
                        }

                        if (CMX_College.SelectedIndex != -1)
                        {
                            vCollage= "'" + CMX_College.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vCollage = "NULL";
                        }

                        if (CMX_Department.SelectedIndex != -1)
                        {
                            vDepartment = "'" + CMX_Department.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vDepartment = "NULL";
                        }


                         if (CMX_Service.SelectedIndex != -1)
                        {
                            vService= "'" + CMX_Service.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vService = "NULL";
                        }


                          if (TXT_ResponsibleChurch.SelectedIndex != -1)
                        {
                            vResponsibleChurch= "'" + TXT_ResponsibleChurch.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vResponsibleChurch = "NULL";
                        }

                          if (TXT_ResponsibleServant.SelectedIndex != -1)
                        {
                            vResponsibleServant= "'" + TXT_ResponsibleServant.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vResponsibleServant = "NULL";
                        }


                          if (TXT_FatherChurch.SelectedIndex != -1)
                        {
                            vFatherChurch= "'" + TXT_FatherChurch.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vFatherChurch = "NULL";
                        }

                          if (TXT_Father.SelectedIndex != -1)
                        {
                            vFather= "'" + TXT_Father.SelectedItem.DataValue.ToString().Trim() + "'";
                        }
                        else
                        {
                            vFather = "NULL";
                        }



                        if (TXT_BirthDate.Value !=null)
	                    {
                             DateTime time = DateTime.Parse(TXT_BirthDate.Value.ToString());
                             string format = "MM-dd-yyyy";
                              // DateTime dt = DateTime.Parse(TXT_Date.Text);
                                vBirthdate = "'" + time.ToString(format) + "'";
	                    }
                        else
	                    {
                            vBirthdate = "NULL";
	                    }

                        if (vFormMode == "N")
                        {
                            return;
                        }
                        else if (vFormMode == "U")
                        {
                            vSaveStatment =     "UPDATE [dbo].[TBL_MainPerson]							" + "\n" +
                                                "   SET [PersType_ID]		=		" + vPersonType +"	                " + "\n" +
                                                "      ,[Name]				=		" + vName +"					    " + "\n" +
                                                "      ,[Gender]			=		" + vGender +"					    " + "\n" +	
                                                "      ,[City_ID]			=		" + vCity +"					    " + "\n" +
                                                "      ,[Area_ID]			=		"+ vArea + "					    " + "\n" +
                                                "      ,[Street_ID]			=		"+vStreet+"					        " + "\n" +
                                                "      ,[BuildingNum]		=		'"+TXT_BuildingNo.Text+"'			" + "\n" +	
                                                "      ,[FloorNum]			=		'"+TXT_Floor.Text+"'				" + "\n" +
                                                "      ,[AdressDisc]		=		'"+TXT_AddressDesc.Text+"'			" + "\n" +
                                                "      ,[Phone]				=		'"+TXT_PhoneNo.Text+"'				" + "\n" +
                                                "      ,[Mobile]			=		'"+TXT_MobileNo.Text+"'				" + "\n" +
                                                "      ,[BirthDate]			=		"+vBirthdate+"					    " + "\n" +
                                                "      ,[EducLevel_ID]		=	    "+vAcademicLevel+"					" + "\n" +
                                                "      ,[Collage_ID]		=	    "+vCollage+"						" + "\n" +
                                                "      ,[Department_ID]		=	    " + vDepartment + "					" + "\n" +
                                                "      ,[EducYear_ID]		=	    "+vAcademicYear+"					" + "\n" +
                                                "      ,[Service_ID]		=	    "+vService+"						" + "\n" +
                                                "      ,[MrFrom_ChurchID]	=	    "+vResponsibleChurch+"				" + "\n" +
                                                "      ,[MrName_PersID]		=       "+vResponsibleServant+"				" + "\n" +
                                                "      ,[FrFrom_ChurchID]	=	    "+vFatherChurch+"					" + "\n" +
                                                "      ,[FrName_PersID]		=	    "+vFather+"						    " + "\n" +
                                                "      ,[Facebook]			=       '"+TXT_Facebook.Text+"'				" + "\n" +
                                                "      ,[Email]             =	    '"+TXT_Email.Text+"'				" + "\n" +
                                                "      ,[Statuse]           =	    "+vStatus+"							" + "\n" +
                                                "	   ,[IsWorking]		    =       " + vIsWorking + "		" + "\n" +
                                                "	   ,[WorkDisc]		    =       '"+TXT_WorkDesc.Text+"' 			" + "\n" +
                                                "      ,LastUserUpdate      ='" + BasicClass.vUsrName + "'" + "\n" +
                                                "      ,LastUpdate          =   GetDate()                 " + "\n" +
                                                "      ,ProcessID           ='" + Process.GetCurrentProcess().Id.ToString() + "'" + "\n" +
                                                "      ,MachineName         ='" + Strings.Trim(System.Environment.MachineName) + "'" + "\n" +
                                                " WHERE ID                  =		"+TXT_Name.Tag+"    				" + "\n" +
                                                " AND       Church_ID       =" + BasicClass.vChurchID + "\n"; 
                        }
                        else if (vFormMode == "I")
                        {
                            string vIsActive = null;
                            string vIsSalesMan = null;
                                vSaveStatment = "INSERT INTO [dbo].[TBL_MainPerson]																				" + "\n" +
                                                "           (Church_ID          ,[PersType_ID]		,[Name]				,[Gender]					" + "\n" +
                                                "           ,[City_ID]     		,[Area_ID]			,[Street_ID]		,[BuildingNum]							" + "\n" +
                                                "           ,[FloorNum]    		,[AdressDisc]		,[Phone]			,[Mobile]								" + "\n" +
                                                "           ,[BirthDate]   		,[EducLevel_ID]		,[Collage_ID]		,[Department_ID]	        		" + "\n" +
                                                "           ,[EducYear_ID] 		,[Service_ID]		,[MrFrom_ChurchID]	,[MrName_PersID]						" + "\n" +
                                                "           ,[FrFrom_ChurchID]	,[FrName_PersID]	,[Facebook]			,[Email]								" + "\n" +
                                                "           ,[Statuse]        ,IsWorking  ,[WorkDisc],LastUpdate ,LastUserUpdate,MachineName,ProcessID)         " + "\n" +
                                                "     VALUES (																									" + "\n" 
                                           + BasicClass.vChurchID + "," + vPersonType 					+","  + vName 	                    +"," + vGender 	    +","+ "\n" 
                                             +vCity + "," + vArea + "," + vStreet + "," + "'" + TXT_BuildingNo.Text + "'," + "\n" 
                                             +"'" + TXT_Floor.Text + "'," + "'" + TXT_AddressDesc.Text + "'," + "'" + TXT_PhoneNo.Text + "'," + "'" + TXT_MobileNo.Text + "'," + "\n"
                                             + vBirthdate + "," + vAcademicLevel + "," + vCollage + "," + vDepartment + "," + "\n" 
                                             +vAcademicYear + "," + vService + "," + vResponsibleChurch + "," + vResponsibleServant + "," + "\n" 
                                             +vFatherChurch + "," + vFather + "," + "'" + TXT_Facebook.Text + "'," + "'" + TXT_Email.Text + "'," + "\n"
                                             + vStatus + "," + vIsWorking + ",'" + TXT_WorkDesc.Text + "', getDate() ,'" + BasicClass.vUsrName + "','" + Environment.MachineName.Trim() + "','" + Process.GetCurrentProcess().Id.ToString() + "') ";
                        }
                        sFillSqlStatmentArray(vSaveStatment);

                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.HandleException(ex.Message, this.Name, "sSave");
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
                                            if (fValidatePerson() == false)
                                        {
                                            return false;
                                        }
                                        else
                                        {
                                            sSaveData();
                                            rowsAffected = BasicClass.fDMLData(vSqlStatment, this.Name);
                                            if (rowsAffected > 0)
                                            {
                                                vIsSaved = true;
                                                this.vIW_GetPeopleData1TableAdapter.FillByChurchID(this.goodShepherdDataSet.VIW_GetPeopleData1,BasicClass.vChurchID);
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
                        }
                        else
                        {
                            if (fIsDataChanged() == true)
                            {
                                if (fValidatePerson() == false)
                                {
                                    return false;
                                }
                                else
                                {
                                    sSaveData();
                                    rowsAffected = BasicClass.fDMLData(vSqlStatment, this.Name);
                                    if (rowsAffected > 0)
                                    {
                                        vIsSaved = true;
                                        this.vIW_GetPeopleData1TableAdapter.FillByChurchID(this.goodShepherdDataSet.VIW_GetPeopleData1,BasicClass.vChurchID);
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

                        if (TXT_Name.Text == "")
                        {
                            sHandleMessage(1,"من فضلك ادخل الاسم");
                    
                            TXT_Name.SelectAll();
                            TXT_Name.Focus();
                            return false;
                        }
                        if (TXT_MobileNo.Text.Trim() == "")
                        {
                            sHandleMessage(1, "من فضلك ادخل رقم الموبايل");
                            TXT_MobileNo.SelectAll();
                            TXT_MobileNo.Focus();
                            return false;
                        }
                        if (TXT_City.SelectedIndex  == -1)
                        {
                            sHandleMessage(1, "من فضلك اختار المحافظة");
                            TXT_City.SelectAll();
                            TXT_City.Focus();
                            return false;
                        }

                        if (OPT_PersType.CheckedIndex == -1)
                        {
                            sHandleMessage(1, "يجب اختيار طبيعة الشخص فى النظام");
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
            private void DeletePerson()                                 
            {
                try
                {
                    string vDeleteStatment = "";
                    if (MessageBox.Show("هل تريد حذف هذا البيان ؟", "تنبيه", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                             if (fIsvalidDelete() == true)
                                    {
                    
                                        vDeleteStatment =   "DELETE FROM [dbo].[TBL_MainPerson]							" + "\n" +
                                                            " WHERE     ID                  =		" + TXT_Name.Tag + "    				" + "\n" +
                                                            " AND       Church_ID           =" + BasicClass.vChurchID + "\n"; 
                                        long vRowsAffected = 0;
                                        vRowsAffected = BasicClass.fDMLData(vDeleteStatment, this.Name);
                                        if (vRowsAffected > 0)
                                        {
                                            sHandleMessage(4, "تم حذف البيانات بنجاح");
                                            this.vIW_GetPeopleData1TableAdapter.FillByChurchID(this.goodShepherdDataSet.VIW_GetPeopleData1,BasicClass.vChurchID);
                                            sNewRecord();
                                        }
                                        else
                                        {
                                            sHandleMessage(1, "خطأ فى حذف البيانات");
                                        }
                                    }
                                    else
                                    {
                                        sHandleMessage(1, "يوجد سجلات مرتبطة بذلك البيان");
                                    }
                    }


                

                }
                catch (Exception ex)
                {
                
                    ExceptionHandler.HandleException(ex.Message,this.Name,"");
                }
                finally
                {
                    if (BasicClass.vSqlConn.State == ConnectionState.Broken || BasicClass.vSqlConn.State == ConnectionState.Open)
                    {
                        BasicClass.vSqlConn.Close();
                    }
                }
            }
            private bool fIsvalidDelete()                               
        {
            bool result = false;
            try
            {
                string vstmt = "";
                vstmt = "FROM [TBL_Meetings_Details]		" + "\n" +
                        "WHERE (Pers_ID = " + TXT_Name.Tag + ")" + "\n";
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

        #region QUERY_Person
            private bool sQueryPerson(int pID)
            {
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            string vGender = "";
            bool vResult = false;
            tabControl1.SelectedTab = tabControl1.TabPages["TAB_Details"];
            string vSelectedArea = "";
            string vSelectedStreet = "";
            string vSelectedCollege = "";
            string vSelectedDepartment = "";
            string vSelectedacademicYear = "";

            try
            {
                SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;
                vSqlCommand.CommandText = "\n" +
                       "SELECT				TBL_MainPerson.Name , TBL_MainPerson.ID AS ID_Pers,	TBL_MainPerson.Statuse , TBL_MainPerson.Email , TBL_MainPerson.Facebook				" + "\n" +
                        "						,TBL_PersonType.ID  AS PRS_Type_ID, dbo.TBL_PersonType.PersonType	AS PRS_Type_Desc												" + "\n" +
                        "						,TBL_MainPerson.BirthDate , TBL_MainPerson.BuildingNum , TBL_MainPerson.AdressDisc													" + "\n" +
                        "						,TBL_MainPerson.FloorNum,TBL_MainPerson.Gender																						" + "\n" +
                        "						,TBL_MainPerson.Mobile ,TBL_MainPerson.Phone ,TBL_MainPerson.Church_ID																" + "\n" +
                        "																																							" + "\n" +
                        "						,TBL_City.ID	AS City_ID	, TBL_City.CityDesc																						" + "\n" +
                        "						, dbo.TBL_Area.ID AS ID_Area, dbo.TBL_Area.AreaDesc																					" + "\n" +
                        "						, dbo.TBL_Street.ID AS ID_Str, dbo.TBL_Street.StreetDesc																			" + "\n" +
                        "						, dbo.TBL_EducationLevel.ID AS ID_EducLevel, dbo.TBL_EducationLevel.EducLevel														" + "\n" +
                        "						, dbo.TBL_EducYear.ID AS ID_EducYear, dbo.TBL_EducYear.EducYear																		" + "\n" +
                        "						 , dbo.TBL_Collage.ID AS ID_Collage, dbo.TBL_Collage.Collage																		" + "\n" +
                        "						 , dbo.TBL_Department.ID AS ID_Department, dbo.TBL_Department.Department            												" + "\n" +
                        "						 ,TBL_MainPerson.MrFrom_ChurchID , MR_From_Church.ChurchName AS MrFrom_ChurchDesc													" + "\n" +
                        "					     ,TBL_MainPerson.MrName_PersID , MR_Person.Name AS MrName_PersDesc																	" + "\n" +
                        "					     ,TBL_MainPerson.FrName_PersID , FR_Person.Name AS FrName_PersDesc																	" + "\n" +
                        "					     ,TBL_MainPerson.FrFrom_ChurchID , FR_From_Church.ChurchName AS FRFrom_ChurchDesc													" + "\n" +
                        "					     ,ISNULL(TBL_MainPerson.IsWorking,'N') AS IsWorking , TBL_MainPerson.WorkDisc														" + "\n" +
                        "						, dbo.TBL_Services.ID AS Service_ID, dbo.TBL_Services.Service														                " + "\n" +
                        "FROM					dbo.TBL_MainPerson																													" + "\n" +
                        "INNER JOIN				dbo.TBL_PersonType																													" + "\n" +
                        "ON						dbo.TBL_MainPerson.PersType_ID		= TBL_PersonType.ID																				" + "\n" +
                        "LEFT OUTER JOIN 		dbo.TBL_City																														" + "\n" +
                        "ON						dbo.TBL_MainPerson.City_ID			= dbo.TBL_City.ID																				" + "\n" +
                        "LEFT OUTER JOIN			dbo.TBL_Area																													" + "\n" +
                        "ON						dbo.TBL_Area.ID						= dbo.TBL_MainPerson.Area_ID																	" + "\n" +
                        "LEFT OUTER JOIN 		dbo.TBL_Street																														" + "\n" +
                        "ON						dbo.TBL_MainPerson.Street_ID		= dbo.TBL_Street.ID																				" + "\n" +
                        "LEFT OUTER JOIN			dbo.TBL_EducationLevel																											" + "\n" +
                        "ON						dbo.TBL_MainPerson.EducLevel_ID		= dbo.TBL_EducationLevel.ID																		" + "\n" +
                        "LEFT OUTER JOIN			dbo.TBL_EducYear																												" + "\n" +
                        "ON						dbo.TBL_MainPerson.EducYear_ID		= dbo.TBL_EducYear.ID																			" + "\n" +
                        "LEFT OUTER JOIN			dbo.TBL_Collage																													" + "\n" +
                        "ON						dbo.TBL_MainPerson.Collage_ID		= dbo.TBL_Collage.ID																			" + "\n" +
                        "LEFT OUTER JOIN			dbo.TBL_Department																													" + "\n" +
                        "ON						dbo.TBL_MainPerson.Department_ID	= dbo.TBL_Department.ID																			" + "\n" +
                        "LEFT Join				TBL_Church MR_From_Church																											" + "\n" +
                        "ON						MR_From_Church.ID					= TBL_MainPerson.MrFrom_ChurchID																" + "\n" +
                        "LEFT Join				TBL_MainPerson MR_Person																											" + "\n" +
                        "ON						MR_Person.ID						= TBL_MainPerson.MrName_PersID																	" + "\n" +
                        "LEFT Join				TBL_MainPerson FR_Person																											" + "\n" +
                        "ON						FR_Person.ID						= TBL_MainPerson.FrName_PersID																	" + "\n" +
                        "LEFT Join				TBL_Church FR_From_Church																											" + "\n" +
                        "ON						FR_From_Church.ID					= TBL_MainPerson.FrFrom_ChurchID																" + "\n" +
                        "LEFT Join				TBL_Services																											" + "\n" +
                        "ON						TBL_Services.ID					    = TBL_MainPerson.Service_ID																" + "\n" +
                        "WHERE					dbo.TBL_MainPerson.ID				= "+ pID +"																		" + "\n" +
                        " AND                   dbo.TBL_MainPerson.Church_ID                    =" + BasicClass.vChurchID + "\n"; 

                sqlConnection1.Open();
                vSQLReader = vSqlCommand.ExecuteReader();
                if (vSQLReader.HasRows == true)
                {
                    while (vSQLReader.Read())
                    {
                        if (vSQLReader["ID_Pers"] != System.DBNull.Value)
                        {
                            TXT_Name.Tag = vSQLReader["ID_Pers"].ToString();
                        }
                        else
                        {
                            TXT_Name.Tag = "";
                        }

                        if (vSQLReader["Name"] != System.DBNull.Value)
                        {
                            TXT_Name.Text = vSQLReader["Name"].ToString().Trim();
                        }
                        else
                        {
                            TXT_Name.Text = "";
                        }

                        
                        if (vSQLReader["Church_ID"] != System.DBNull.Value)
                        {
                            CMX_Churc.Value = vSQLReader["Church_ID"].ToString().Trim();
                        }
                        else
                        {
                            CMX_Churc.Value = null;
                        }



                        if (vSQLReader["PRS_Type_ID"] != System.DBNull.Value)
                        {
                            OPT_PersType.Value = int.Parse(vSQLReader["PRS_Type_ID"].ToString());
                        }

                        else
                        {
                            OPT_PersType.CheckedIndex = -1;
                        }


                        if (vSQLReader["Statuse"] != System.DBNull.Value)
                        {
                            TXT_Status.Value = vSQLReader["Statuse"].ToString();
                        }
                        else
                        {
                            TXT_Status.SelectedIndex  = -1;
                        }
                        



                        if (vSQLReader["Email"] != System.DBNull.Value)
                        {
                            TXT_Email.Text = vSQLReader["Email"].ToString();
                        }
                        else
                        {
                            TXT_Email.Text = "";
                        }

                        if (vSQLReader["Facebook"] != System.DBNull.Value)
                        {
                            TXT_Facebook.Text = vSQLReader["Facebook"].ToString();
                        }

                        else
                        {
                            TXT_Facebook.Text = "";
                        }
                        if (vSQLReader["BirthDate"] != System.DBNull.Value)
                        {
                            DateTime time = DateTime.Parse(GRD_Summary.ActiveRow.Cells["BirthDate"].Value.ToString().Trim());
                            string format = "dd-MM-yyyy";
                            // DateTime dt = DateTime.Parse(TXT_Date.Text);
                            string vTDate =  time.ToString(format) ;
                            TXT_BirthDate.Value = GRD_Summary.ActiveRow.Cells["BirthDate"].Value;//vTDate;
                        }
                        else
                        {
                            TXT_BirthDate.Value = null;
                        }
                       

                       

                        if (vSQLReader["BuildingNum"] != System.DBNull.Value)
                        {
                            TXT_BuildingNo.Text = vSQLReader["BuildingNum"].ToString();
                        }

                        else
                        {
                            TXT_BuildingNo.Text = "";
                        }

                        if (vSQLReader["AdressDisc"] != System.DBNull.Value)
                        {
                            TXT_AddressDesc.Text = vSQLReader["AdressDisc"].ToString();
                        }

                        else
                        {
                            TXT_AddressDesc.Text = "";
                        }

                        if (vSQLReader["FloorNum"] != System.DBNull.Value)
                        {
                            TXT_Floor.Text = vSQLReader["FloorNum"].ToString();
                        }
                        else
                        {
                            TXT_Floor.Text = "";
                        }


                        if (vSQLReader["Gender"] != System.DBNull.Value)
                        {
                            OPT_PersGender.Value = vSQLReader["Gender"];
                        }
                        else
                        {
                            OPT_PersGender.CheckedIndex = -1;
                        }





                        if (vSQLReader["Mobile"] != System.DBNull.Value)
                        {
                            TXT_MobileNo.Text = vSQLReader["Mobile"].ToString();
                        }
                        else
                        {
                            TXT_MobileNo.Text = "";
                        }


                        if (vSQLReader["Phone"] != System.DBNull.Value)
                        {

                            TXT_PhoneNo.Text = vSQLReader["Phone"].ToString();
                        }
                        else
                        {
                            TXT_PhoneNo.Text = "";
                        }



                        if (vSQLReader["City_ID"] != System.DBNull.Value)
                        {
                            foreach (var item in TXT_City.Items)
                            {
                                if (item.DataValue.ToString().Trim() == vSQLReader["City_ID"].ToString().Trim())
                                {
                                    TXT_City.SelectedItem = item;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            TXT_City.SelectedIndex = -1;
                        }


                        if (vSQLReader["ID_Area"] != System.DBNull.Value)
                        {
                            //////////foreach (var item in TXT_Area.Items)
                            //////////{
                            //////////    if (item.DataValue.ToString().Trim() == vSQLReader["ID_Area"].ToString().Trim())
                            //////////    {
                            //////////        TXT_Area.SelectedItem = item;
                            //////////        break;
                            //////////    }
                            //////////}
                            vSelectedArea = vSQLReader["ID_Area"].ToString().Trim();
                        }

                        else
                        {
                            ////TXT_Area.SelectedIndex = -1;
                            vSelectedArea = "";

                        }

                        if (vSQLReader["ID_Str"] != System.DBNull.Value)
                        {
                            //////////foreach (var item in TXT_Street.Items)
                            //////////{
                            //////////    if (item.DataValue.ToString().Trim() == vSQLReader["ID_Str"].ToString().Trim())
                            //////////    {
                            //////////        TXT_Street.SelectedItem = item;
                            //////////        break;
                            //////////    }
                            //////////}
                            vSelectedStreet = vSQLReader["ID_Str"].ToString().Trim();
                        }

                        else
                        {
                            /////////TXT_Street.SelectedIndex = -1;
                            vSelectedStreet = "";
                        }


                        if (vSQLReader["ID_EducLevel"] != System.DBNull.Value)
                        {
                            foreach (var item in TXT_AcademicLevel.Items)
                            {
                                if (item.DataValue.ToString().Trim() == vSQLReader["ID_EducLevel"].ToString().Trim())
                                {
                                    TXT_AcademicLevel.SelectedItem = item;
                                    break;
                                }
                            }
                        }

                        else
                        {
                            TXT_AcademicLevel.SelectedIndex = -1;
                        }
                        if (vSQLReader["ID_EducYear"] != System.DBNull.Value)
                        {
                            ////////foreach (var item in TXT_AcademicYear.Items)
                            ////////{
                            ////////    if (item.DataValue.ToString().Trim() == vSQLReader["ID_EducYear"].ToString().Trim())
                            ////////    {
                            ////////        TXT_AcademicYear.SelectedItem = item;
                            ////////        break;
                            ////////    }
                            ////////}
                            vSelectedacademicYear = vSQLReader["ID_EducYear"].ToString().Trim();
                        }

                        else
                        {
                            ///////TXT_AcademicYear.SelectedIndex = -1;
                            vSelectedacademicYear = "";
                        }
                        if (vSQLReader["ID_Collage"] != System.DBNull.Value)
                        {
                            ////////foreach (var item in TXT_College.Items)
                            ////////{
                            ////////    if (item.DataValue.ToString().Trim() == vSQLReader["ID_Collage"].ToString().Trim())
                            ////////    {
                            ////////        TXT_College.SelectedItem = item;
                            ////////        break;
                            ////////    }
                            ////////}
                            vSelectedCollege = vSQLReader["ID_Collage"].ToString().Trim();
                        }

                        else
                        {
                            ///////TXT_College.SelectedIndex = -1;
                            vSelectedCollege = "";
                        }

                        if (vSQLReader["ID_Department"] != System.DBNull.Value)
                        {
                            vSelectedDepartment = vSQLReader["ID_Department"].ToString().Trim();
                        }

                        else
                        {
                            ///////TXT_College.SelectedIndex = -1;
                            vSelectedDepartment = "";
                        }
                        if (vSQLReader["Service_ID"] != System.DBNull.Value)
                        {
                            foreach (var item in CMX_Service.Items)
                            {
                                if (item.DataValue.ToString().Trim() == vSQLReader["Service_ID"].ToString().Trim())
                                {
                                    CMX_Service.SelectedItem = item;
                                    break;
                                }
                            }
                        }

                        else
                        {
                            CMX_Service.SelectedIndex = -1;
                        }

                       if (vSQLReader["MrFrom_ChurchID"] != System.DBNull.Value)
                        {
                            foreach (var item in TXT_ResponsibleChurch.Items)
                            {
                                if (item.DataValue.ToString().Trim() == vSQLReader["MrFrom_ChurchID"].ToString().Trim())
                                {
                                    TXT_ResponsibleChurch.SelectedItem = item;
                                    break;
                                }
                            }
                        }

                        else
                        {
                            TXT_ResponsibleChurch.SelectedIndex = -1;
                        }

                       if (vSQLReader["MrName_PersID"] != System.DBNull.Value)
                       {
                           foreach (var item in TXT_ResponsibleServant.Items)
                           {
                               if (item.DataValue.ToString().Trim() == vSQLReader["MrName_PersID"].ToString().Trim())
                               {
                                   TXT_ResponsibleServant.SelectedItem = item;
                                   break;
                               }
                           }
                       }

                       else
                       {
                           TXT_ResponsibleServant.SelectedIndex = -1;
                       }


                       if (vSQLReader["FrName_PersID"] != System.DBNull.Value)
                       {
                           foreach (var item in TXT_Father.Items)
                           {
                               if (item.DataValue.ToString().Trim() == vSQLReader["FrName_PersID"].ToString().Trim())
                               {
                                   TXT_Father.SelectedItem = item;
                                   break;
                               }
                           }
                       }

                       else
                       {
                           TXT_Father.SelectedIndex = -1;
                       }


                       if (vSQLReader["FrFrom_ChurchID"] != System.DBNull.Value)
                       {
                           foreach (var item in TXT_FatherChurch.Items)
                           {
                               if (item.DataValue.ToString().Trim() == vSQLReader["FrFrom_ChurchID"].ToString().Trim())
                               {
                                   TXT_FatherChurch.SelectedItem = item;
                                   break;
                               }
                           }
                       }

                       else
                       {
                           TXT_FatherChurch.SelectedIndex = -1;
                       }
                       if (vSQLReader["IsWorking"] != System.DBNull.Value)
                       {
                           if (vSQLReader["IsWorking"].ToString().Trim() == "Y")
                           {
                               CHK_IsWorking.Checked = true;
                               TXT_WorkDesc.Visible = true;
                           }
                           else if (vSQLReader["IsWorking"].ToString().Trim()  == "N")
                           {
                               CHK_IsWorking.Checked = false;
                               TXT_WorkDesc.Visible = false;
                           }
                       }

                       else
                       {
                           CHK_IsWorking.Checked = false;
                           TXT_WorkDesc.Visible = false;
                          
                       }


                       if (vSQLReader["WorkDisc"] != System.DBNull.Value)
                       {
                           TXT_WorkDesc.Text = vSQLReader["WorkDisc"].ToString();
                       }

                       else
                       {
                           TXT_WorkDesc.Text = "";
                       }
                    }
                    

                    vSQLReader.Close();
                    sqlConnection1.Close();
                    if (TXT_City.SelectedItem != null)
                    {
                      sFillAreas(int.Parse(TXT_City.SelectedItem.DataValue.ToString()));
                        if (vSelectedArea.Trim() !="")
                        {
                            foreach (var item in TXT_Area.Items)
                            {
                                if (item.DataValue.ToString().Trim() == vSelectedArea.ToString().Trim())
                                {
                                    TXT_Area.SelectedItem = item;
                                    break;
                                }
                            }
                        }
                        else
	                    {
                            TXT_Area.SelectedIndex = -1;
	                    }

                        if (TXT_Area.SelectedItem != null)
                        {
                           sFillStreet(int.Parse(TXT_City.SelectedItem.DataValue.ToString()), int.Parse(TXT_Area.SelectedItem.DataValue.ToString()));
                            if (vSelectedStreet.Trim() != "")
                            {
                                foreach (var item in TXT_Street.Items)
                                {
                                    if (item.DataValue.ToString().Trim() == vSelectedStreet.ToString().Trim())
                                    {
                                        TXT_Street.SelectedItem = item;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                TXT_Street.SelectedIndex = -1;
                            }
                        }
                        else
                        {
                            TXT_Street.SelectedIndex = -1;
                        }
                        


                    }
                    else
                    {
                        TXT_Area.SelectedIndex = -1;
                        TXT_Street.SelectedIndex = -1;
                    }
                    

                    if (TXT_AcademicLevel.SelectedItem != null)
                    {
                         sFillEucationYear(int.Parse(TXT_AcademicLevel.SelectedItem.DataValue.ToString()));
                            if (vSelectedacademicYear.Trim() != "")
                            {
                                foreach (var item in TXT_AcademicYear.Items)
                                {
                                    if (item.DataValue.ToString().Trim() == vSelectedacademicYear.ToString().Trim())
                                    {
                                        TXT_AcademicYear.SelectedItem = item;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                TXT_AcademicYear.SelectedIndex = -1;
                            }
                           sFillCollege(int.Parse(TXT_AcademicLevel.SelectedItem.DataValue.ToString()));
                            if (vSelectedCollege.Trim() != "")
                            {
                                foreach (var item in CMX_College.Items)
                                {
                                    if (item.DataValue.ToString().Trim() == vSelectedCollege.ToString().Trim())
                                    {
                                        CMX_College.SelectedItem = item;
                                        break;
                                    }
                                }
                             sFillDepartment(int.Parse(CMX_College.SelectedItem.DataValue.ToString()));
                                if (vSelectedDepartment.Trim() != "")
                                {
                                    foreach (var item in CMX_Department.Items)
                                    {
                                        if (item.DataValue.ToString().Trim() == vSelectedDepartment.ToString().Trim())
                                        {
                                            CMX_Department.SelectedItem = item;
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    CMX_Department.SelectedIndex = -1;
                                }
                            }
                            else
                            {
                                CMX_College.SelectedIndex = -1;
                                CMX_Department.SelectedIndex = -1;
                            }
      
                    }
                    else
                    {
                        TXT_AcademicYear.SelectedIndex = -1;
                        CMX_College.SelectedIndex = -1;
                        CMX_Department.SelectedIndex = -1;
                    }

                    

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
                saveDialog.FileName = "بيانات الاشخاص ";
                saveDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveDialog.FilterIndex = 1;

                if (saveDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    ultraGridExcelExporter1.Export(GRD_Summary,saveDialog.FileName);
                   
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
                this.vIW_GetPeopleData1TableAdapter.FillByChurchID(this.goodShepherdDataSet.VIW_GetPeopleData1,BasicClass.vChurchID);
            }
            catch (Exception ex)
            {
                
                ExceptionHandler.HandleException(ex.Message,this.Name,"sImportFromExcel");
            }
        }
#endregion

        private void TXT_AcademicLevel_ValueChanged(object sender, EventArgs e)
        {
            if ( TXT_AcademicLevel.Text != "" && TXT_AcademicLevel.IsItemInList() && TXT_AcademicLevel.Value.ToString() == "6" )
            {
                LBL_College   .Visible = true;
                LBL_Department.Visible = true;

                CMX_College   .Visible = true;
                CMX_Department.Visible = true;
            }
            else
            {
                LBL_College   .Visible = false;
                LBL_Department.Visible = false;

                CMX_College   .Visible = false;
                CMX_Department.Visible = false;
            }
        }

        private void OPT_PersType_ValueChanged(object sender, EventArgs e)
        {
            switch ( OPT_PersType.Value.ToString() )
            {
                case "1" ://كاهن
                    
                    //Check Male
                    OPT_PersGender.Value = "M";

                    //invisible Gender
                    OPT_PersGender.Visible = false;

                    //visible Detail of esrvice
                    LBL_ChrService.Visible = false;
                    CMX_ChrService.Visible = false;
                    LBL_Service.Visible    = false;
                    CMX_Service.Visible    = false;
                    break;

                case "2"://مخدوم
                    
                    //invisible Gender
                    OPT_PersGender.Visible = true;

                    //visible Detail of esrvice
                    LBL_ChrService.Visible = false;
                    CMX_ChrService.Visible = false;
                    LBL_Service.Visible    = false;
                    CMX_Service.Visible    = false;
                    break;

                case "3"://خادم
                    //invisible Gender
                    OPT_PersGender.Visible = true;
                    
                    //visible Detail of esrvice
                    LBL_ChrService.Visible = true;
                    CMX_ChrService.Visible = true;
                    LBL_Service.Visible    = true;
                    CMX_Service.Visible    = true;
                    break;
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

        private void OPT_PersGender_ValueChanged(object sender, EventArgs e)
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




    }
}

