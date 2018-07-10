using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Telerik.WinControls.UI;

namespace GoodShepherd
{
    public partial class FRM_Login : RadForm
    {
        public FRM_Login()                                              
        {
            InitializeComponent();
        }

        private void FRM_Login_Load(object sender, EventArgs e)         
        {
            CMX_City.Focus();
            CMX_City.SelectAll();
            this.tBL_CityTableAdapter.Fill(this.userChurchDataSet.TBL_City);
            
            //Properties.Settings.Default["GoodShepherdConnectionString"] = BasicClass.vConectionString;
            //this.tBL_UserTableAdapter.Connection   = BasicClass.vSqlConn;
        }

        //when click on sign in button
        int i = 0;
        private void BTN_Login_Click(object sender, EventArgs e)        
        {
            try
            {   //if dont enter user name
                if (CMX_UserName.Text.ToString() == "")
                {
                    STS_Login.Text = "من فضلك ادخل اسم المستخدم";
                    CMX_UserName.Focus();
                    Timer_MSgCleaner.Start();
                }
                else
                {   //************if user name or password not valid ***********************//
                    sFillUserdata(CMX_UserName.Value.ToString(), TXT_Password.Text.ToString());
                    
                    //check fill basic class or not 
                    if (BasicClass.vUsrID == 0)
                    {
                        STS_Login.Text = "  اسم المستخدم / كلمة المرور غير صحيح محاولة خطا رقم  " + (i + 1);
                        TXT_Password.Text = "";
                        Timer_MSgCleaner.Start();

                        i = i + 1;
                        //    MessageBox.Show("Password Error please try again");
                        //    Label4.Text = ("this is error number " + i);
                        //    TextBox1.Text = "";
                        //    TextBox1.Focus();

                        if (i >= 3)
                        {
                            Application.Exit();
                        }
                    }
                    else
                    {
                        if (CMX_Church.Value != null)
                        {
                            BasicClass.vChurchID = int.Parse(CMX_Church.Value.ToString());
                        }
                        if (CMX_City.Value !=null)
                        {
                            BasicClass.vCityID = int.Parse(CMX_City.Value.ToString());
                        }
                        Close();    //if not close 
                        //close mean return false to intializer
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "BTN_Login_Click");
            }
        }

        private void BTN_Cancel_Click(object sender, EventArgs e)       
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "BTN_Cancel_Click");
            }
        }       

        // to fill basic class (user name rolr to use when open program
        private void sFillUserdata(string IDUser, string password)      
        {
            SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
            SqlCommand vSqlCommand = new SqlCommand();
            try
            {
                SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;

                vSqlCommand.CommandText = "\n" +
                                            "select IDUser as USR_ID,UserName" + "\n" +
                                            "from  TBL_User " + "\n" +
                                            "where IDUser ='" + IDUser + "' " + "\n" +
                                            "and   Password ='" + password + "' OR Password IS NULL" + "\n";
                sqlConnection1.Open();
                vSQLReader = vSqlCommand.ExecuteReader();
                while (vSQLReader.Read())
                {
                    if (vSQLReader["USR_ID"] != System.DBNull.Value) { BasicClass.vUsrID = int.Parse(vSQLReader["USR_ID"].ToString()); }
                    if (vSQLReader["UserName"] != System.DBNull.Value) { BasicClass.vUsrName = vSQLReader["UserName"].ToString(); }
                }
                vSQLReader.Close();
                sqlConnection1.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "sFillUserdata");
            }
            finally
            {
                if (sqlConnection1.State == ConnectionState.Broken || sqlConnection1.State == ConnectionState.Open)
                {
                    sqlConnection1.Close();
                }
            }
        }

        //to clean massage after x time
        private void Timer_MSgCleaner_Tick(object sender, EventArgs e)  
        {
            STS_Login.Text = "...";
            Timer_MSgCleaner.Stop();
        }

        private void TXT_Password_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BTN_Login.PerformClick();
            }
        }

        private void CMX_City_ValueChanged(object sender, EventArgs e)
        {
            if (CMX_City.Text != "" && CMX_City.IsItemInList())
            {
                this.vIW_ChurchTableAdapter.FillByCity(this.userChurchDataSet.VIW_Church, int.Parse(CMX_City.Value.ToString()) );
            }
            else
            {
                CMX_City.Value = null;
            }

            if (!CMX_Church.IsItemInList())
            {
                CMX_Church.Value   = null;
                CMX_UserName.Value = null;
            }
        }

        private void CMX_Church_ValueChanged(object sender, EventArgs e)
        {
            if (CMX_Church.Text != "" && CMX_Church.IsItemInList() )
            {
                this.tBL_UserTableAdapter.FillByChurch(this.userChurchDataSet.TBL_User, int.Parse(CMX_Church.Value.ToString() ) );
            }
            else
            {
                CMX_Church.Value = null; 
            }

            if (!CMX_UserName.IsItemInList() )
            {
                CMX_UserName.Value = null;
            }
        }


    }
}
