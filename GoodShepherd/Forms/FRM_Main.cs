using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GoodShepherd.Forms;
using Telerik.WinControls.UI;
using MEMN;

namespace GoodShepherd
{
    public partial class FRM_MainForm : RadForm
    {
        public FRM_MainForm()
        {
            InitializeComponent();
        }
        
        private void FRM_MainForm_Load(object sender, EventArgs e)
        {
            FRM_Login vFrm = new FRM_Login();
            vFrm.ShowDialog();
        }

        //All Form
        public FRM_PersonsData     Persons_FRM        ;
        public FRM_Adress          Adress_FRM         ;
        public FRM_Church          Church_FRM         ;
        public FRM_Studies         Studies_FRM        ;
        public FRM_Meetings        Meeting_FRM        ;
        public FRM_DBBackupRestore DBBackupRestore_FRM;
        public FRM_User            User_FRM           ;
        public FRM_Reports Reports_FRM;

        private void EXP_MainItems_ItemClick(object sender, Infragistics.Win.UltraWinExplorerBar.ItemEventArgs e)
        {
            //if this tab not visible 
            if (TAB_Main.Tabs[e.Item.Key].Visible == false)
            {
                //show tab
                TAB_Main.Tabs[e.Item.Key].Visible = true;

                // and do this code depend on key 
                switch (e.Item.Key)
                {
                    case "City":
                    
                        //Fill tab
                        Adress_FRM                 = new FRM_Adress();
                        Adress_FRM.TopLevel        = false;
                        Adress_FRM.FormBorderStyle = FormBorderStyle.None;
                        Adress_FRM.Dock            = DockStyle.Fill;
                        Adress_FRM.Visible         = true;

                        PAG_City.Controls.Clear();
                        PAG_City.Controls.Add(Adress_FRM);
                        
                        break;

                    case "Chur":
                    
                        //Fill tab
                        Church_FRM = new FRM_Church();
                        Church_FRM.TopLevel = false;
                        Church_FRM.FormBorderStyle = FormBorderStyle.None;
                        Church_FRM.Dock = DockStyle.Fill;
                        Church_FRM.Visible = true;

                        PAG_Chur.Controls.Clear();
                        PAG_Chur.Controls.Add(Church_FRM);
                        
                        break;

                    case "Serv":

                        break;
                    case "Reports":

                        //Fill tab
                        Reports_FRM = new FRM_Reports();
                        Reports_FRM.TopLevel = false;
                        Reports_FRM.FormBorderStyle = FormBorderStyle.None;
                        Reports_FRM.Dock = DockStyle.Fill;
                        Reports_FRM.Visible = true;

                        PAG_Rep.Controls.Clear();
                        PAG_Rep.Controls.Add(Reports_FRM);
                        Reports_FRM.ShowDialog();
                        break;
                    case "Edu":
                    
                        //Fill tab
                        Studies_FRM = new FRM_Studies();
                        Studies_FRM.TopLevel = false;
                        Studies_FRM.FormBorderStyle = FormBorderStyle.None;
                        Studies_FRM.Dock = DockStyle.Fill;
                        Studies_FRM.Visible = true;

                        PAG_Edu.Controls.Clear();
                        PAG_Edu.Controls.Add(Studies_FRM);
                        
                        break;

                    case "Pers":
                                            
                        Persons_FRM                 = new FRM_PersonsData() ;
                        Persons_FRM.TopLevel        = false                 ;
                        Persons_FRM.FormBorderStyle = FormBorderStyle.None  ;
                        Persons_FRM.Dock            = DockStyle.Fill        ;
                        Persons_FRM.Visible         = true                  ;

                        PAG_Pers.Controls.Clear();
                        PAG_Pers.Controls.Add(Persons_FRM);

                        break;

                    case "Meet":

                        break;

                    case "Aten":
                    
                        //Fill tab
                        Meeting_FRM = new FRM_Meetings();
                        Meeting_FRM.TopLevel = false;
                        Meeting_FRM.FormBorderStyle = FormBorderStyle.None;
                        Meeting_FRM.Dock = DockStyle.Fill;
                        Meeting_FRM.Visible = true;

                        PAG_Aten.Controls.Clear();
                        PAG_Aten.Controls.Add(Meeting_FRM);
                        
                        break;

                    case "BacResDB":
                    
                    //Fill tab
                    DBBackupRestore_FRM                 = new FRM_DBBackupRestore();
                    DBBackupRestore_FRM.TopLevel        = false;
                    DBBackupRestore_FRM.FormBorderStyle = FormBorderStyle.None;
                    DBBackupRestore_FRM.Dock            = DockStyle.Fill;
                    DBBackupRestore_FRM.Visible         = true;

                    PAG_BacResDB.Controls.Clear();
                    PAG_BacResDB.Controls.Add(DBBackupRestore_FRM);
                        
                    break;


                    case "Users":
                    
                    //Fill tab
                    User_FRM                 = new FRM_User();
                    User_FRM.TopLevel        = false;
                    User_FRM.FormBorderStyle = FormBorderStyle.None;
                    User_FRM.Dock            = DockStyle.Fill;
                    User_FRM.Visible         = true;

                    PAG_Users.Controls.Clear();
                    PAG_Users.Controls.Add(User_FRM);
                        
                    break;

                        
                }
            }
            //Go to tab
            TAB_Main.SelectedTab = TAB_Main.Tabs[e.Item.Key];
        }

        public void TAB_Main_TabClosing(object sender, Infragistics.Win.UltraWinTabControl.TabClosingEventArgs e)
        {
            try
            {
                switch ( e.Tab.Key )
                {
                    case "City":
                        if (Adress_FRM.fCancelTransaction())
                        {
                            Adress_FRM.Close();
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                        break;

                    case "Chur":
                        if (Church_FRM.fCancelTransaction())
                        {
                            Church_FRM.Close();
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                        break;

                    case "Serv":
                        break;

                    case "Edu":
                        break;

                    case "Pers":
                        if (Persons_FRM.fCancelTransaction())
                        {
                            Persons_FRM.Close();
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                        break;

                    case "Meet":

                        break;

                    case "Aten":
                        if (Meeting_FRM.fCancelTransaction())
                        {
                            Meeting_FRM.Close();
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "Tab_InventoryOptions_TabClosed");
            }
        }



    }
}
