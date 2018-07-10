using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Telerik.WinControls.UI;
namespace GoodShepherd
{
    public partial class FRM_Waiting : RadForm
    {
        SqlConnection vConn = new SqlConnection();
        SqlCommand vSqlCommand = new SqlCommand();
        TimeSpan vTimer;
        TimeSpan StartTime;
        public FRM_Waiting()
        {
            InitializeComponent();
            vSqlCommand = null;
            vConn = null;
            BTN_Action.Visible = false;
           LBL1.Text = "جارى استيراد البيانات";
           
        }

        private void FRM_Waiting_Load(object sender, System.EventArgs e)
        {
           // I set this property 'False' so i can close this form from another thread
            FRM_Waiting.CheckForIllegalCrossThreadCalls = false;
           // BTN_Action.CheckForIllegalCrossThreadCalls = false;
            ProgressBar1.Visible = true;
            StartTime = DateTime.Now.TimeOfDay;
            LBL_Time.Text = "0:0:0";
        }

        public FRM_Waiting(ref SqlCommand Command, ref SqlConnection Connection)
        {
        // Constructor
        InitializeComponent();
        vSqlCommand = Command;
        vConn = Connection;
        BTN_Action.Text = "الغاء العملية";
        LBL1.Text = "جارى العمل";
        
        
    }
    
       private void Button1_Click(object sender, System.EventArgs e)
    {
        try
        {
            if (BTN_Action.Text == "الغاء")
            {
                if (!(vSqlCommand == null))
                {
                    vSqlCommand.Cancel();
                }

                this.Close();
            }
            else if (BTN_Action.Text == "تم")
            {
                this.Close();
            }

        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(ex.Message, "", "vExecuteNonQueryCallback");
        }

    }

        private void Timer1_Tick(object sender, System.EventArgs e)
        {
            vTimer = (DateTime.Now.TimeOfDay - StartTime);
            if (!(BTN_Action.Text == "تم"))
                {
                    LBL_Time.Text = (vTimer.Hours.ToString() + (":"
                                + (vTimer.Minutes.ToString() + (":" + vTimer.Seconds.ToString()))));
                }
                else
                {
                    if (this.Controls.Contains(BTN_Action))
                    {
                        this.Controls.Remove(BTN_Action);
                        this.Controls.Add(BTN_Action);
                    }

                    BTN_Action.Visible = true;
                }

           
            
        }
        private void Button1_TextChanged(object sender, System.EventArgs e)
        {
            BTN_Action.Visible = true;
        }
        //public static void shandleAction(bool isSucceeded, int vSuccessCount, int vItemsCount)
        //{
        //    try
        //    {
        //        if ((isSucceeded == true))
        //        {
        //            FRM_Waiting FRM ;
        //            this.Text = "تم استيراد البيانات";
        //            this.Controls["BTN_Action"].Text = "تم";
        //            this.Controls["LBL1"].Text = ("تم استيراد البيانات بنجاح " + ("\r\n"
        //                        + (vSuccessCount.ToString() + (" من "
        //                        + (vItemsCount.ToString() + " عدد ")))));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ExceptionHandler.HandleException(ex.Message, "", "shandleAction");
        //    }
        //}
        public delegate void updatebar();
        public void UpdateProgress(string Mode , bool isSucceeded, int vSuccessCount, int vItemsCount)
	        {
             if ((isSucceeded == true))
                {
                    //this.Text = "تم استيراد البيانات";
                    //this.Controls["BTN_Action"].Text = "تم";
                    //this.Controls["LBL1"].Text = ("تم استيراد البيانات بنجاح " + ("\r\n"
                    //            + (vSuccessCount.ToString() + (" من "
                    //            + (vItemsCount.ToString() + " عدد ")))));
                    if (Mode == "Import")
                    {
                       this.BeginInvoke((Action)(() => this.Text = "تم استيراد البيانات"));
                       if (this.BTN_Action !=null)
                       {
                            this.BeginInvoke((Action)(() => this.BTN_Action.Text = "تم"));
                       }
                       if (this.Controls["LBL1"] != null)
                       {
                              this.BeginInvoke((Action)(() => this.LBL1.Text = ("تم استيراد البيانات بنجاح " + ("\r\n"
                                + (vSuccessCount.ToString() + (" من "
                                + (vItemsCount.ToString() + " عدد "))))))); 
                       }
                        //  WaitFRM.Controls["ProgressBar1"].Visible = false;
                        //  WaitFRM.Controls["BTN_Action"].Tag = "Done";
                      
                 
                    }
                    else if (Mode== "Export")
                    {
                        this.BeginInvoke((Action)(() => this.Text = "تم تصدير البيانات"));
                        if (this.Controls["BTN_Action"] != null)
                        {
                               this.BeginInvoke((Action)(() => this.BTN_Action.Text = "تم"));
                        }
                        if (this.Controls["LBL1"] != null)
                        {
                            this.BeginInvoke((Action)(() => this.LBL1.Text = ("تم تصدير البيانات بنجاح " + ("\r\n"
                                + (vSuccessCount.ToString() + (" من "
                                + (vItemsCount.ToString() + " عدد "))))))); 
                        }
                         
                 
                    

                    }
                
                }
             else
             {
                    this.BeginInvoke((Action)(() => this.LBL1.Text ="تم الغاء العملية"));
                    this.BeginInvoke((Action)(() => this.Text = "فشل العملية"));
                    this.BeginInvoke((Action)(() => this.BTN_Action.Text = "تم"));
             }
             this.BeginInvoke((Action)(() => this.ProgressBar1.Visible = false));
             this.BeginInvoke((Action)(() => this.BTN_Action.Tag = "Done"));
	        }

	 
    }
}
