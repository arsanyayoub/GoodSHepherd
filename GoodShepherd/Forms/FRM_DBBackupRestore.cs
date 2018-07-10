using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Data.SqlClient;
using Telerik.WinControls.UI;

namespace GoodShepherd.Forms
{
    public partial class FRM_DBBackupRestore : RadForm
    {
        SqlConnection con;       
        SqlCommand cmd;
        SqlDataReader dr;
        private FRM_Waiting WaitFRM;
        string db = BasicClass.vSqlConn.Database;
        private System.Threading.Thread vThread;

        public FRM_DBBackupRestore()
        {
            InitializeComponent();
        }

        private void FRM_DBBackupRestore_Load(object sender, EventArgs e)
        {
            ProgressBar1.Enabled = false;
            LBL_Message.Visible = false;
            LBL_Status.Text = "";
            LBL_Status.Visible = false;
            ProgressBar1.Visible = false;
            con = BasicClass.vSqlConn;
           // serverName(BasicClass.vConectionString);          
        }
        //public void serverName(string str)
        //{
        //    con = new SqlConnection("Data Source=" + str + ";Database=Master; uid=sa; pwd=3112005;");
        //    con.Open();
        //    cmd = new SqlCommand("select *  from sysservers  where srvproduct='SQL Server'", con);
        //    dr = cmd.ExecuteReader();
        //    while (dr.Read())
        //    {
        //        ComboBoxserverName.Items.Add(dr[2]);
        //    }
        //    dr.Close();
        //}

       

        public bool query(string statement)
        {
            // ERROR: Not supported in C#: OnErrorStatement
            int result = 0;
            try
            {
                 cmd = new SqlCommand(statement,con);
                 cmd.CommandTimeout = 99999999;
                 con.Open();
                 cmd.ExecuteNonQuery();
                 con.Close();
                 result = 1;
            }
            catch (Exception ex)
            {
                result = -1;
                con.Close();
                MessageBox.Show(ex.Message, "خطأ", MessageBoxButtons.OK);
                ExceptionHandler.HandleException(ex.Message,this.Name,"query");
            }
            if (result > 0)
            {
                return true;
            }
            else
            {
                 return false;
            }
           
        }

        public void Process(string str)
        {
            try
            {
                string db = BasicClass.vSqlConn.Database;
                        LBL_Message.Visible = true;
                        ProgressBar1.Visible = true;
                        LBL_Status.Visible = true;

                        if (str == "backup")
                        {
                            ProgressBar1.Enabled = true;
                            LBL_Status.Text = "جارى انشاء ملف تامين قاعدة البيانات";
                            SaveFileDialog1.FileName = db;
                            DialogResult res=    SaveFileDialog1.ShowDialog();                                      
                            string s = null;
                            s = SaveFileDialog1.FileName;
                            if (s.Length > 0 && res == System.Windows.Forms.DialogResult.OK)
                            {
                                    bool result = false;
                                result = query("Backup database " + db + " to disk='" + s + "'");
                                //long result = BasicClass.fDMLData("Backup database " + ComboBoxDatabaseName.Text + " to disk='" + s + "'", this.Name);
                                  if (result == true)
                                  {
                            
                                      sHandleMessage(4, "تم انشاء ملف تامين قاعدة البيانات بنجاح");
                                  }
                                  else
                                  {
                            
                                      sHandleMessage(1, "فشل انشاء ملف تامين قاعدة البيانات بنجاح");
                                  }
                            }
                            
                            
                        }
                        else if (str == "restore")
                        {
                            ProgressBar1.Enabled = true;
                            LBL_Status.Text = "جارى استرجاع قاعدة البيانات";
                            DialogResult res =  OpenFileDialog1.ShowDialog();
                            string s = null;
                            s = OpenFileDialog1.FileName;
                            if (s.Length > 0 && res== System.Windows.Forms.DialogResult.OK)
                            {
                                   // string a = ComboBoxDatabaseName.Text.ToString();
                                string vStmt = "IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'" + db + "')" + "\n" +
                                    "use master" + "\n" +
                                    "alter database " + db + " set offline with rollback immediate;" + "\n" +
                                    " DROP DATABASE " + db + " RESTORE DATABASE " + db + " FROM DISK = '" + s + "'" + "\n" +
                                    "WITH REPLACE" + "\n" +
                                    "use master" + "\n" +
                                    "alter database " + db + " set Online with rollback immediate;";
                                bool result = false;
                                 result = query(vStmt); 

                                //int result = query("IF EXISTS (SELECT name FROM master.dbo.sysdatabases WHERE name = N'" + ComboBoxDatabaseName.Text + "')" + "\n" +
                                //         "use master" + "\n" +
                                //         "alter database " + ComboBoxDatabaseName.Text + " set offline with rollback immediate;" + "\n" +
                                //         " DROP DATABASE " + ComboBoxDatabaseName.Text + " RESTORE DATABASE " + ComboBoxDatabaseName.Text + " FROM DISK = '" + OpenFileDialog1.FileName + "'" + "\n" +
                                //         "WITH REPLACE" + "\n" +
                                //         "use master" + "\n" +
                                //         "alter database " + ComboBoxDatabaseName.Text + " set Online with rollback immediate;");
                                //long result = BasicClass.fDMLData(vStmt, this.Name);
                                LBL_Message.Visible = true;
                                if (result == true)
                                {

                                    sHandleMessage(4, "تم استرجاع قاعدة البيانات بنجاح");
                                }
                                else
                                {
                                    sHandleMessage(1, "فشل استرجاع قاعدة البيانات بنجاح");
                                } 
                            }
                            
                            
                        
                        
                    }
                       
            }
            catch (Exception ex)
            {
                
                ExceptionHandler.HandleException(ex.Message,this.Name,"Process");
            }
            
        }
        private void sHandleMessage(int pType, string Message)
        {
            try
            {
                LBL_Status.Text = "";
                this.LBL_Message.Text = Message;
                //Critical
                if (pType == 1)
                {
                    this.LBL_Message.ForeColor = System.Drawing.Color.Red;
                }
                //Warning
                else if (pType == 2)
                {
                    this.LBL_Message.ForeColor = System.Drawing.Color.Navy;
                }
                //Done
                else if (pType == 3)
                {
                    LBL_Message.ForeColor = System.Drawing.Color.Green;
                }
                //'Save
                else if (pType == 4)
                {
                    this.LBL_Message.ForeColor = System.Drawing.Color.Blue;
                }
                //''Assistant
                else if (pType == 5)
                {
                    this.LBL_Message.ForeColor = System.Drawing.Color.Black;
                }

                Timer_MSgCleaner.Start();

            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "sHandleMessages");
            }
        }
        private void ComboBoxserverName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Createconnection();
        }

        private void cmbbackup_Click_1(object sender, EventArgs e)
        {
            Process("backup"); 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process("restore"); 
        }

        private void Timer_MSgCleaner_Tick(object sender, EventArgs e)
        {
            this.LBL_Message.Text = "";
            LBL_Status.Text = "";
            ProgressBar1.Visible = false;
            LBL_Status.Visible = false;
        }     
    }
}
