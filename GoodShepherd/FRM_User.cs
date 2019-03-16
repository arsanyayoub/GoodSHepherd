using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Telerik.WinControls;
using Telerik.WinControls.UI;

using System.Collections;
using System.ComponentModel;
using System.Data;
using GoodShepherd;
using Infragistics.Win.UltraWinGrid;

namespace GoodShepherd
{
    public partial class FRM_User : Telerik.WinControls.UI.RadForm                             
    {


            public FRM_User()                                                                  
            {
                InitializeComponent();

                ChangePicBox();
            }

            string[]       vSqlStatment = new string[1];
            public string  vFormMode    = "NI"         ;//نوع الفورم اضافة او تحديث
            public string  vCurrentCode = ""           ;// كود البيان اللى واقف علية حاليا

            public int     vFRM_recPos  = 0            ;// رقم الريكورد الحالي
            public int     vMaxRec      = 0            ;// لمعرفة عدد البيانات الموجودة



            private void FRM_Users_Load(object sender,EventArgs e)                             
            {
                // TODO: This line of code loads data into the 'userChurchDataSet.VIW_Church' table. You can move, or remove it, as needed.
                this.vIW_ChurchTableAdapter.Fill(this.userChurchDataSet.VIW_Church);


                try
                {
                  

                    GetMaxRec();

                    CheckPosition();
                    EnableOptions();
                    //sNew();


                    //if (BasicClass.vRoleID == 3)      بعمل شيك على الرول اللى شغال بيها او هنا الأكسيس ليفيل 
                    //{
                    //    sQueryUserByID(BasicClass.vUsrID);   مش فاهمها اوي
                    //}
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, "FRM_User", "FRM_User_Load");
                }
            }

       

        #region "When Button Click                                                                        "
            private void SaveUser_Click  (object sender, EventArgs e)                           
            {
                try
                {   //will check validation of all Field
                    if (fValidate() == true)
                    {
                        //if this record is new record
                        if (vFormMode == "I")
                        {
                            if (InsertNew() == true)
                            {
                                vFormMode = "N";
                                MessageBox.Show("تم الحفظ بنجاح");

                                GetMaxRec();
                                Last_Click(null,null);
                            }
                            else
                            {
                                MessageBox.Show("لم يتم الحفظ");
                            }
                        }
                        //if this record is exist record
                        if (vFormMode == "U")
                        {
                            if (UpdateExist()==true)
                            {
                                vFormMode = "N";
                                MessageBox.Show("تم تحديث البيانات بنجاح");
                            }
                            else
                            {
                                MessageBox.Show("لم يتم تحديث البيانات");
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("لم يتم الحفظ بيانات غير كاملة");
                    }
                }
                catch (Exception ex )
                {
                    ExceptionHandler.HandleException(ex.Message, this.Name, "SaveUser");
                }
            }
            private void AddUser_Click   (object sender, EventArgs e)                           
            {
                if (fCancelTransaction() == true)
                {
                    sNew();
                }
            }
            private void DeleteUser_Click(object sender, EventArgs e)                           
            {
                try
                {
                    if (TXT_UserID.Text == "")
                    {
                        
                    }
                    else
                    {
                        if (vFormMode == "I" )
                        {
                            MessageBox.Show("لم يتم أضافة البيان حتى الأن حتي يتم مسحة");
                        }
                        else
                        {
                            if (MessageBox.Show("هل تريد مسح هذا البيان ؟؟", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == System.Windows.Forms.DialogResult.Yes)
                            {
                                if (Delete() == true)
                                {
                                    MessageBox.Show("تم مسح البيان بنجاح");

                                    GetMaxRec();

                                    Counting();

                                    //sNew();

                                    Previous_Click(null,null);
                                }
                                else
                                {
                                    MessageBox.Show("لم يتم مسح البيان");
                                }
                            }
                        }
                    }

                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, this.Name, "DeleteUser");
                }
            }
            private void Next_Click      (object sender, EventArgs e)                           
            {
                try
                {
                    if (fCancelTransaction() == true)
                    {
                        if (sFind(1) == true)
                        {
                            sHandleMessage(7);
                            Timer_MSgCleaner.Start();
                        }

                        CheckPosition();

                        Counting();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, this.Name, "NextUser");
                }
            }
            private void Previous_Click  (object sender, EventArgs e)                           
            {
                try
                {
                    if (fCancelTransaction() == true)
                    {
                        if (sFind(-1) == true)
                        {
                            sHandleMessage(7);
                            Timer_MSgCleaner.Start();
                        }

                        CheckPosition();

                        Counting();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, "FRM_Users", "Previous");
                }
            }
            private void Firest_Click    (object sender, EventArgs e)                           
            {
                try
                {
                    if (fCancelTransaction() == true)
                    {
                        vFRM_recPos = 0;

                        sFind(1);

                        CheckPosition();

                        Counting();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, "FRM_Users", "Firest");
                }

            }
            public void Last_Click       (object sender, EventArgs e)                           
            {
                try
                {
                    if (fCancelTransaction() == true)
                    {
                        vFRM_recPos = vMaxRec;

                        sFind(0);

                        CheckPosition();

                        Counting();
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, "FRM_Users", "Last");
                }

            }
        #endregion  

        #region "Load And unload Pic And His Shapes                                                       "
            //To change bic box to circle 
            private void ChangePicBox()                                                         
            {
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(0, 0, picPictureBox.Width - 3, picPictureBox.Height - 3);
                picPictureBox.Region = new Region(path);
            }

            //select image
            private void BTN_LoadPic_Click(object sender, EventArgs e)                          
            {

                //this.OpnDlg_Picture.Filter = "Image Files (jpg - png - gif - ico)|*.jpg;*.png;*.ico;*.gif | Text Files (.txt)|*.txt|All Files (*.*)|*.*";
                //this.OpnDlg_Picture.ShowDialog();

                //if (Strings.Trim(this.OpnDlg_Picture.FileName).Length > 0)
                //{
                //    System.IO.FileStream vBLOBFile = new System.IO.FileStream(this.OpnDlg_Picture.FileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
                //    byte[] vBLOBData = new byte[vBLOBFile.Length];
                //    vBLOBFile.Read(vBLOBData, 0, vBLOBData.Length);
                //    System.IO.MemoryStream stmBLOBData = new System.IO.MemoryStream(vBLOBData);
                //    this.picPictureBox.Image = System.Drawing.Image.FromStream(stmBLOBData);
                //    this.picPictureBox.Visible = true;
                //}

                //picPictureBox.Image = System.Drawing.Image.FromStream(mstream);
                //----------------------------------------------------------------------
                //Ask user to select file.
                OpenFileDialog dlg = new OpenFileDialog();

                //dlg.Filter = "JPG Files (*.jpg)|*.jpg|PNG Files (*.png)|*.png|  ICON Files (*.ico)|*.ico  |GIF Files (*.gif)|*.gif | Text Files (.txt)|*.txt|All Files (*.*)|*.*";
                dlg.Filter = "Image Files (jpg - png - gif - ico)|*.jpg;*.png;*.ico;*.gif | Text Files (.txt)|*.txt|All Files (*.*)|*.*";
                dlg.FilterIndex = 1;
                dlg.InitialDirectory = @"Desktop";
                dlg.Title = "Please select an image file to Product.";

                DialogResult dlgRes = dlg.ShowDialog();
                if (dlgRes != DialogResult.Cancel)
                {
                    string PicPath = dlg.FileName.ToString();

                    //Set image in picture box
                    picPictureBox.ImageLocation = PicPath;

                    //Provide file path in txtImagePath text box.
                    TXT_PicPath.Text = dlg.FileName;

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

            //Clear image
            private void BTN_ClearPic_Click(object sender, EventArgs e)                         
            {
                picPictureBox.Image = null;
                TXT_PicPath.Text = "";
                if (vFormMode.Trim().ToUpper() == "NI")
                {
                    vFormMode = "I";
                }
                else if (vFormMode.Trim().ToUpper() == "N")
                {
                    vFormMode = "U";
                }
            }
        #endregion


        #region "insert Updater And Delete                                                                "
            
            public bool InsertNew()                                                             
            {
                try
                {
                    SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
                    SqlCommand vSqlCommand = new SqlCommand();
                    vSqlCommand.Connection = sqlConnection1;
                    

                    //to fill any field by null value if not selected
                    string vdeptId;
                    if (CMX_Role.Value == null)   {vdeptId = "NULL";}     else{vdeptId = "'" + CMX_Role.Value.ToString().Trim() + "'";}
                    Byte[] imgBytes = null;

                    if (TXT_PicPath.Text != "")
                    {

                        ImageConverter imgConverter = new ImageConverter();
                        imgBytes = (System.Byte[])imgConverter.ConvertTo(picPictureBox.Image, Type.GetType("System.Byte[]"));
                                               
                    }

                    vSqlCommand.CommandText = "INSERT INTO [TBL_User]" + "([UserName]                 ,         [Password]                    ,           [Church_ID]             ,[Picture], LastUpdate,             MachineName                ,                    ProcessID                      ) " + "\n" +
                                                  "OUTPUT INSERTED.IDUser" + "\n" + 
                                                  "VALUES                 " + "('" + this.TXT_UserName.Text.Trim() + "','" + this.TXT_Password.Text.Trim() + "','" + this.CMX_ChurchName.Value + "',  @image , getDate() ,'" + Environment.MachineName.Trim() + "','" + Process.GetCurrentProcess().Id.ToString() + "') ";
                  

                   

                    if (imgBytes != null)
                    {
                        vSqlCommand.Parameters.AddWithValue("@image", imgBytes);
                    }
                    else
                    {
                        SqlParameter imageParameter = new SqlParameter("@image", SqlDbType.Image);
                        imageParameter.Value = DBNull.Value;
                        vSqlCommand.Parameters.Add(imageParameter);
                    }
                    sqlConnection1.Open();  
                    Int64 newId = (Int64)vSqlCommand.ExecuteScalar();
                    TXT_UserID.Text = newId.ToString();
                    vCurrentCode = newId.ToString();
                    sqlConnection1.Close();
                    sSaveSystemModules();
                    return true;
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, this.Name, "UpdateExist");

                    return false;
                }

            }


            public bool UpdateExist()                                                           
            {
                try
                {
                    SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
                    SqlCommand vSqlCommand = new SqlCommand();

                    SqlDataReader vSQLReader;
                    vSqlCommand.Connection = sqlConnection1;

                    string vPersonStatment = null;

                    ////to convert pic Box
                    //byte[] imageBt = null;
                    //FileStream fstrem = new FileStream(this.TXT_PicPath.Text, FileMode.Open, FileAccess.Read);
                    //BinaryReader br = new BinaryReader(fstrem);
                    //imageBt = br.ReadBytes((int)fstrem.Length);


                    vPersonStatment = "  Update [TBL_User] Set                                 " + "\n" +
                        "  UserName         ='" + Strings.Trim(TXT_UserName.Text)           + "'" + "\n" +
                        " ,Password         ='" + Strings.Trim(TXT_Password.Text)           + "'" + "\n" +
                        " ,Church_ID        ='" + CMX_ChurchName.Value + "'" + "\n" +
                        " ,Picture          =   @image                                          " + "\n" +
                        " ,LastUpdate       =   GetDate()                                       " + "\n" +
                        " ,ProcessID        ='" + Process.GetCurrentProcess().Id.ToString() + "'" + "\n" +
                        " ,MachineName      ='" + Strings.Trim(System.Environment.MachineName) + "'";


                    vSqlCommand.CommandText = vPersonStatment + " Where IDUser ='" + vCurrentCode + "'";
                    Byte[] imgBytes = null;

                    if (TXT_PicPath.Text != "")
                    {

                        ImageConverter imgConverter = new ImageConverter();
                        imgBytes = (System.Byte[])imgConverter.ConvertTo(picPictureBox.Image, Type.GetType("System.Byte[]"));

                    }
                    if (imgBytes != null)
                    {
                        vSqlCommand.Parameters.AddWithValue("@image", imgBytes);
                    }
                    else
                    {
                        SqlParameter imageParameter = new SqlParameter("@image", SqlDbType.Image);
                        imageParameter.Value = DBNull.Value;
                        vSqlCommand.Parameters.Add(imageParameter);
                    }
                    sqlConnection1.Open();

                   

                    vSQLReader = vSqlCommand.ExecuteReader();

                    vSQLReader.Close();
                    sqlConnection1.Close();
                    sSaveSystemModules();
                    return true;
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, this.Name, "UpdateExist");

                    return false;
                }
            }

            public bool Delete()                                                                
            {
                try
                {
                    SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
                    SqlCommand vSqlCommand = new SqlCommand();

                    SqlDataReader vSQLReader;
                    vSqlCommand.Connection = sqlConnection1;

                    vSqlCommand.CommandText = "  Delete from [TBL_User]  Where IDUser ='" + vCurrentCode + "'";

                    sqlConnection1.Open();
                    
                    vSQLReader = vSqlCommand.ExecuteReader();

                    vSQLReader.Close();
                    sqlConnection1.Close();

                    return true;
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, this.Name, "UpdateExist");

                    return false;
                }
            }

        #endregion

            //check position of record to enable and disaple (firest , last ,next and previous) button 
            private void CheckPosition()                                                        
            {   //If no record or one record
                if (vMaxRec == 1 || vMaxRec == 0)
                {
                    //to display firest and previous
                    Toolbar_Options.Tools["BTN_Firest"].SharedProps.Enabled   = false;//0
                    Toolbar_Options.Tools["BTN_Previous"].SharedProps.Enabled = false;//1

                    //to display last and next
                    Toolbar_Options.Tools["BTN_Next"].SharedProps.Enabled = false;//2
                    Toolbar_Options.Tools["BTN_Last"].SharedProps.Enabled = false;//3
                }
                else
                {   //if in the Firest record
                    if (vFRM_recPos == 1)
                    {
                        //to display firest and previous
                        Toolbar_Options.Tools["BTN_Firest"].SharedProps.Enabled = false;
                        Toolbar_Options.Tools["BTN_Previous"].SharedProps.Enabled = false;

                        //to enabl last and next
                        Toolbar_Options.Tools["BTN_Next"].SharedProps.Enabled = true;
                        Toolbar_Options.Tools["BTN_Last"].SharedProps.Enabled = true;

                        sHandleMessage(8);//Firest Record
                        Timer_MSgCleaner.Start();
                    }

                    //if in the Last record
                    else if (vFRM_recPos == vMaxRec)
                    {
                        //to display last and next
                        Toolbar_Options.Tools["BTN_Next"].SharedProps.Enabled = false;
                        Toolbar_Options.Tools["BTN_Last"].SharedProps.Enabled = false;

                        //to enabl firest and previous
                        Toolbar_Options.Tools["BTN_Firest"].SharedProps.Enabled = true;
                        Toolbar_Options.Tools["BTN_Previous"].SharedProps.Enabled = true;

                        sHandleMessage(9);//Last Record
                        Timer_MSgCleaner.Start();
                    }
                    else
                    {
                        //to enabl last and next
                        Toolbar_Options.Tools["BTN_Next"].SharedProps.Enabled = true;
                        Toolbar_Options.Tools["BTN_Last"].SharedProps.Enabled = true;

                        //to enabl firest and previous
                        Toolbar_Options.Tools["BTN_Firest"].SharedProps.Enabled = true;
                        Toolbar_Options.Tools["BTN_Previous"].SharedProps.Enabled = true;
                    }
                }
            }
        
            //When Open Enable And Disable By Role Access Level And Department
            public void sEnableOptions()                                                        
            {
                try
                {
                    //if (BasicClass.vRoleID == 1)
                    //{
                    //    Toolbar_Options.Tools["BTN_New"].SharedProps.Enabled = true;
                    //    Toolbar_Options.Tools["BTN_Save"].SharedProps.Enabled = true;
                    //    Toolbar_Options.Tools["BTN_Delete"].SharedProps.Enabled = false;
                    //    Toolbar_Options.Tools["BTN_Exit"].SharedProps.Enabled = true;
                    //    Toolbar_Options.Tools["BTN_Previous"].SharedProps.Enabled = true;
                    //    Toolbar_Options.Tools["BTN_Next"].SharedProps.Enabled = true;
                    //    Toolbar_Options.Tools["BTN_Save"].SharedProps.Caption = "حفظ ";
                    //}

                    //else if (BasicClass.vRoleID == 2)
                    //{
                    //    Toolbar_Options.Tools["BTN_New"].SharedProps.Enabled = true;
                    //    Toolbar_Options.Tools["BTN_Save"].SharedProps.Enabled = true;
                    //    Toolbar_Options.Tools["BTN_Delete"].SharedProps.Enabled = false;
                    //    Toolbar_Options.Tools["BTN_Exit"].SharedProps.Enabled = true;
                    //    Toolbar_Options.Tools["BTN_Previous"].SharedProps.Enabled = true;
                    //    Toolbar_Options.Tools["BTN_Next"].SharedProps.Enabled = true;
                    //    Toolbar_Options.Tools["BTN_Save"].SharedProps.Caption = "حفظ ";
                    //}

                    //else if (BasicClass.vRoleID == 3)
                    //{
                    //    Toolbar_Options.Tools["BTN_New"].SharedProps.Enabled = false;
                    //    Toolbar_Options.Tools["BTN_Save"].SharedProps.Enabled = true;
                    //    Toolbar_Options.Tools["BTN_Save"].SharedProps.Caption = "حفظ وبدأ الامتحان";
                    //    Toolbar_Options.Tools["BTN_Delete"].SharedProps.Enabled = false;
                    //    Toolbar_Options.Tools["BTN_Exit"].SharedProps.Enabled = true;
                    //    Toolbar_Options.Tools["BTN_Previous"].SharedProps.Enabled = false;
                    //    Toolbar_Options.Tools["BTN_Next"].SharedProps.Enabled = false;
                    //}

                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, this.Name, "sEnableTool");
                }
            }

            //time to clean massage
            private void Timer_MSgCleaner_Tick(object sender, EventArgs e)                      
            {
                STS_Message.Items["Msg"].Text = "";
                Timer_MSgCleaner.Stop();
            }

            // will check all field in the form 
            private bool fValidate()                                                            
            {
                try
                {
                    if (TXT_UserName.Text.Trim() == "")
                    {
                        STS_Message.Items["Msg"].Text = "من فضلك ادخل الاسم";
                        STS_Message.Items["Msg"].ForeColor = Color.Red;
                        Timer_MSgCleaner.Start();
                        TXT_UserName.SelectAll();
                        TXT_UserName.Focus();
                        return false;
                    }
                    if (TXT_Password.Text.Trim() == "")
                    {
                        STS_Message.Items["Msg"].Text = "من فضلك ادخل كلمة المرور";
                        STS_Message.Items["Msg"].ForeColor = Color.Red;
                        Timer_MSgCleaner.Start();
                        TXT_Password.SelectAll();
                        TXT_Password.Focus();
                        return false;
                    }
                    if (TXT_Password.Text.Trim() != TXT_ConfirmPassword.Text.Trim())
                    {
                        STS_Message.Items["Msg"].Text = "كلمة المرور / تأكيد كلمة المرور غير متطابقين ";
                        STS_Message.Items["Msg"].ForeColor = Color.Red;
                        Timer_MSgCleaner.Start();
                        TXT_ConfirmPassword.SelectAll();
                        TXT_ConfirmPassword.Focus();
                        return false;
                    }
                    if (CMX_ChurchName.Text == "")
                    {
                        STS_Message.Items["Msg"].Text = "من فضلك اختار الفرع";
                        STS_Message.Items["Msg"].ForeColor = Color.Red;
                        Timer_MSgCleaner.Start();
                        CMX_ChurchName.Focus();
                        return false;
                    }
                   
                    //////if (CMX_Role.Text == "")
                    //////{
                    //////    STS_Message.Items["Msg"].Text = "من فضلك اختار القسم";
                    //////    STS_Message.Items["Msg"].ForeColor = Color.Red;
                    //////    Timer_MSgCleaner.Start();
                    //////    CMX_Role.Focus();
                    //////    return false;
                    //////}
                   
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, this.Name, "fValidatePerson");
                    return false;
                }
                return true;
            }
            
            //show masage box in statuse bar
            private void sHandleMessage(int pType)                                              
            {
                try
                {
                    //Critical
                    if (pType == 1)
                    {
                        this.STS_Message.Items["Msg"].ForeColor = System.Drawing.Color.Red;
                    }
                    //Warning
                    else if (pType == 2)
                    {
                        this.STS_Message.Items["Msg"].ForeColor = System.Drawing.Color.Navy;
                    }
                    //Done
                    else if (pType == 3)
                    {
                        this.STS_Message.Items["Msg"].ForeColor = System.Drawing.Color.Green;
                    }
                    //'Save
                    else if (pType == 4)
                    {
                        this.STS_Message.Items["Msg"].ForeColor = System.Drawing.Color.Blue;
                        this.STS_Message.Items["Msg"].Text = "....... تم الحفظ بنجاح";
                    }
                    //''Assistant
                    else if (pType == 5)
                    {
                        this.STS_Message.Items["Msg"].ForeColor = System.Drawing.Color.Black;
                    }


                    else if (pType == 6)
                    {
                        this.STS_Message.Items["Msg"].ForeColor = System.Drawing.Color.Red;
                        this.STS_Message.Items["Msg"].Text = "";
                    }

                    //''QUERY
                    else if (pType == 7)
                    {
                        this.STS_Message.Items["Msg"].ForeColor = System.Drawing.Color.Blue;
                        this.STS_Message.Items["Msg"].Text = "....... تم الاستعلام بنجاح";
                    }

                   //''FirstRecord
                    else if (pType == 8)
                    {
                        this.STS_Message.Items["Msg"].ForeColor = System.Drawing.Color.Blue;
                        this.STS_Message.Items["Msg"].Text = "....... اول سجل";
                    }
                    //''LastRecord
                    else if (pType == 9)
                    {
                        this.STS_Message.Items["Msg"].ForeColor = System.Drawing.Color.Blue;
                        this.STS_Message.Items["Msg"].Text = "....... اخر سجل";
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, "FRM_Students", "sHandleMessage");
                }
            }

            //to change form mode
            private void TexttChanged(object sender, EventArgs e)                               
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

            //statuse to tell me number of current record of total
            public void Counting()                                                              
            {
                string z = vFRM_recPos.ToString() + " OF " + vMaxRec.ToString();

                LBL_Count.Text  = z ;
            }

            public void GetMaxRec()                                                             
            {
                SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
                SqlCommand vSqlCommand = new SqlCommand();

                SqlDataReader vSQLReader;
                vSqlCommand.Connection = sqlConnection1;

                vSqlCommand.CommandText =  " With MyItems as                                         " + "\n" +
                                           " (SELECT *                                               " + "\n" +
                                           ",ROW_NUMBER() over(Order  By [TBL_User].IDUser) RecPos  " + "\n" +
                                           " FROM [dbo].[TBL_User])                     " + "\n" +
                                           " Select MAX(RecPos)as Maxx From MyItems                  ";

                    sqlConnection1.Open();
                    vSQLReader = vSqlCommand.ExecuteReader();

                    if (vSQLReader.HasRows == true)
                    {
                        vSQLReader.Read();
                        if (vSQLReader["Maxx"] != System.DBNull.Value)
                        {
                            vMaxRec = Convert.ToInt32(vSQLReader["Maxx"]);
                        }
                    }
                    vSQLReader.Close();
                    sqlConnection1.Close();
            }

            private void ultraButton1_Click(object sender, EventArgs e)                         
            {
                MessageBox.Show(vFormMode);
            }

            private void PPPP_Click(object sender, EventArgs e)                                 
            {

            } 

            private bool sFind(int pRecordPosition)                                             
            {
                SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
                SqlCommand vSqlCommand = new SqlCommand();
                bool vResult = false;
                try
                {
                    SqlDataReader vSQLReader;
                    vSqlCommand.Connection = sqlConnection1;
                    string vWhereStmt = "";
                    int vfetchRec = 0;

                    vfetchRec = pRecordPosition + vFRM_recPos;
                    
                    vWhereStmt = " And RecPos='" + vfetchRec + "' ";
                    vSqlCommand.CommandText = "\n" +
                                                " With MyItems as                                                                                    " + "\n" +
                                                " (SELECT *                                                 " + "\n" +
                                                ", ROW_NUMBER() over(Order  By [TBL_User].IDUser) RecPos                                            " + "\n" +
                                                " FROM [dbo].[TBL_User])                                                                " + "\n" +
                                                " Select * From MyItems                                                                              " + "\n" +
                                                " WHERE 1=1                                                                                          " + "\n" +
                                                vWhereStmt;

                    sqlConnection1.Open();
                    vSQLReader = vSqlCommand.ExecuteReader();

                    if (vSQLReader.HasRows == true)
                    {
                        while (vSQLReader.Read())
                        {
                            vFormMode = "N";

                            //to fill all field by found to next adn previous
                            if (vSQLReader["IDUser"] != System.DBNull.Value)
                            {
                                TXT_UserID.Text = vSQLReader["IDUser"].ToString().Trim();
                                vCurrentCode = vSQLReader["IDUser"].ToString().Trim();
                            }
                            else
                            {
                                TXT_UserID.Text = "";
                                vCurrentCode = "";
                            }


                            if (vSQLReader["UserName"] != System.DBNull.Value)
                            {
                                TXT_UserName.Text = vSQLReader["UserName"].ToString().Trim();
                            }
                            else
                            {
                                TXT_UserName.Text = "";
                            }

                            if (vSQLReader["Password"] != System.DBNull.Value)
                            {
                                TXT_Password.Text        = vSQLReader["Password"].ToString().Trim();
                                TXT_ConfirmPassword.Text = vSQLReader["Password"].ToString().Trim();
                            }
                            else
                            {
                                TXT_Password.Text        = "";
                                TXT_ConfirmPassword.Text = "";
                            }

                            if (vSQLReader["Church_ID"] != System.DBNull.Value)
                            {
                                CMX_ChurchName.Text = vSQLReader["Church_ID"].ToString().Trim();
                            }
                            else
                            {
                                CMX_ChurchName.Text = "";
                            }

                            if (vSQLReader["Role_ID"] != System.DBNull.Value)
                            {
                                CMX_Role.Text = vSQLReader["Role_ID"].ToString().Trim();
                            }
                            else
                            {
                                CMX_Role.Text = "";
                            }

                            //to retrive Pic
                            //-----------------------------------------------------------------------------
                            if (vSQLReader["Picture"] != System.DBNull.Value)
                            {
                                byte[] Pic = (byte[])(vSQLReader["Picture"]);

                                MemoryStream mstream = new MemoryStream(Pic);

                                picPictureBox.Image = System.Drawing.Image.FromStream(mstream);

                                //to not sellect path selection if change data
                                TXT_PicPath.Text = "";
                            }
                            else
                            {

                                picPictureBox.Image = global::GoodShepherd.Properties.Resources.Users;

                                //to not sellect path selection if change data
                                TXT_PicPath.Text = "";
                            }


                            if (vSQLReader["RecPos"] != System.DBNull.Value)
                            {
                                vFRM_recPos = int.Parse(vSQLReader["RecPos"].ToString());
                            }
                            else
                            {
                                vFRM_recPos = 0;
                            }
                        }
                        vSQLReader.Close();
                        sqlConnection1.Close();
                        vResult = true;
                        vFormMode = "N";
                        sQueryForms();
                    }


                    //to add new after last record
                    //else
                    //{
                    //    sNew();
                    //}
                }
                catch (Exception ex)
                {
                    vResult = false;
                    ExceptionHandler.HandleException(ex.Message, "FRM_Users", "sFind");
                }
                return vResult;
            }

            //To clean all field to add new
            public void sNew()                                                                  
            {
                try
                {
                    vCurrentCode                    = ""   ;
                    vFormMode                       = "NI" ;
                    vFRM_recPos                     = vMaxRec + 1;

                    
                    TXT_UserID.Text                 = ""   ;
                    TXT_UserName.Text               = ""   ;
                    TXT_UserName.Focus()                   ;
                    TXT_Password.Text               = ""   ;
                    TXT_ConfirmPassword.Text        = ""   ;
                    CMX_ChurchName.Text          = ""   ;
                    CMX_Role.Text             = ""   ;

                    picPictureBox.Image             = global::GoodShepherd.Properties.Resources.Users;
                    TXT_PicPath.Text                = ""   ;


                    Timer_MSgCleaner.Stop();
                    STS_Message.Items["Msg"].Text   = ""   ;


                    LBL_Count.Text = vFRM_recPos.ToString() + " OF " + vFRM_recPos.ToString();

                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, "FRM_User", "New");
                }
            }


        #region "check if form mode is I or U and cancell changing or no                                  "
            //when cancel record 
            private bool fCancelTransaction()                                                   
            {
                try
                {
                    //check if form mode is insert or update
                    if (fIsDataChanged() == true)
                    {
                        if (MessageBox.Show("هل تريد إلغاء التغييرات الحالية", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign) == System.Windows.Forms.DialogResult.Yes)
                        {
                            //sNew();
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
            
            //check form Type
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
        #endregion
            //to writ int number only in fid record by number
            private void TXT_FindByCode_KeyPress(object sender, KeyPressEventArgs e)            
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }


            private void FRM_User_FormClosing(object sender, FormClosingEventArgs e)            
            {
                try
                {
                    if (fCancelTransaction() == false)
                    {
                        e.Cancel = true;
                    }
                }
                catch (Exception ex)
                {
                    ExceptionHandler.HandleException(ex.Message, this.Name, "FormClosing");
                }
            }

            private void Toolbar_Options_ToolClick(object sender, Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e)
            {
                switch (e.Tool.Key)
                {
                    case "BTN_New":    // ButtonTool
                        AddUser_Click(null, null);
                        break;

                    case "BTN_Save":    // ButtonTool
                        SaveUser_Click(null, null);
                        break;

                    case "BTN_Delete":    // ButtonTool
                        DeleteUser_Click(null, null);
                        break;

                    case "BTN_Exit":    // ButtonTool
                        // Place code here
                        break;

                    case "LabelTool1":    // LabelTool
                        // Place code here
                        break;

                    case "BTN_Previous":    // ButtonTool
                        Previous_Click(null, null);
                        break;

                    case "BTN_Next":    // ButtonTool
                        Next_Click(null, null);
                        break;

                    case "BTN_Firest":    // ButtonTool
                        Firest_Click(null, null);
                        break;

                    case "BTN_Last":    // ButtonTool
                        Last_Click(null, null);
                        break;
                }

            }


        #region "HANDLE USER CONTROLS "
            private void sQueryForms()
            {
                SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
                SqlCommand vSqlCommand = new SqlCommand();
                try
                {
                    SqlDataReader vSQLReader;
                    vSqlCommand.Connection = sqlConnection1;
                    string vWhereStmt = "";
                    vSqlCommand.CommandText = "\n" +
                                            "SELECT     System_Forms.Code, System_Forms.DescA									" + "\n" +
                                            "		   , ISNULL(User_System_Forms.IsEnabled,'N') AS IsEnabled					" + "\n" +
                                            "		   , ISNULL(User_System_Forms.AllowQuery,'N') AS AllowQuery					" + "\n" +
                                            "		   , ISNULL(User_System_Forms.AllowInsert,'N')  AS AllowInsert				" + "\n" +
                                            "		   , ISNULL(User_System_Forms.AllowUpdate,'N')  AS AllowUpdate				" + "\n" +
                                            "		   ,ISNULL (User_System_Forms.AllowDelete , 'N') AS AllowDelete				" + "\n" +
                                            "          ,       Case IsNull(USR_ID, '')"  + "\n" +
                                            "                 When '' then 'NI'"  + "\n" +
                                            "                 else 'N' "  + "\n" +
                                            "                 End  DML " + "\n" +
                                            "FROM				System_Forms													" + "\n" +
                                            "LEFT OUTER JOIN    User_System_Forms												" + "\n" +
                                            "ON					System_Forms.Code = User_System_Forms.SYS_FRM_Code				" + "\n" +
                                            "AND				User_System_Forms.USR_ID = "+ TXT_UserID.Text +"									" + "\n";

                    sqlConnection1.Open();
                    vSQLReader = vSqlCommand.ExecuteReader();

                    if (vSQLReader.HasRows == true)
                    {
                        DS_System_Modules.Rows.Clear();
                        int vRowCounter = 0;
                        while (vSQLReader.Read())
                        {
                            //to fill all field by found to next adn previous
                            DS_System_Modules.Rows.SetCount(vRowCounter + 1);

                            if (vSQLReader["Code"] != System.DBNull.Value) { DS_System_Modules.Rows[vRowCounter]["Code"] = vSQLReader["Code"].ToString().Trim(); } else { DS_System_Modules.Rows[vRowCounter]["Code"] = 0; }
                            if (vSQLReader["DescA"] != System.DBNull.Value) { DS_System_Modules.Rows[vRowCounter]["DescA"] = vSQLReader["DescA"].ToString().Trim(); } else { DS_System_Modules.Rows[vRowCounter]["DescA"] = ""; }
                            if (vSQLReader["IsEnabled"] != System.DBNull.Value) {
                                if (vSQLReader["IsEnabled"].ToString().Trim() == "Y")
                                {
                                    DS_System_Modules.Rows[vRowCounter]["IsEnabled"] = true;
                                }
                                else
                                {
                                    DS_System_Modules.Rows[vRowCounter]["IsEnabled"] = false;
                                }
                            } else {
                                DS_System_Modules.Rows[vRowCounter]["IsEnabled"] = false; 
                            }
                            if (vSQLReader["AllowQuery"] != System.DBNull.Value)
                            {
                                if (vSQLReader["AllowQuery"].ToString().Trim() == "Y")
                                {
                                    DS_System_Modules.Rows[vRowCounter]["AllowQuery"] = true;
                                }
                                else
                                {
                                    DS_System_Modules.Rows[vRowCounter]["AllowQuery"] = false;
                                }
                            }
                            else
                            {
                                DS_System_Modules.Rows[vRowCounter]["AllowQuery"] = false;
                            }

                            if (vSQLReader["AllowInsert"] != System.DBNull.Value)
                            {
                                if (vSQLReader["AllowInsert"].ToString().Trim() == "Y")
                                {
                                    DS_System_Modules.Rows[vRowCounter]["AllowInsert"] = true;
                                }
                                else
                                {
                                    DS_System_Modules.Rows[vRowCounter]["AllowInsert"] = false;
                                }
                            }
                            else
                            {
                                DS_System_Modules.Rows[vRowCounter]["AllowInsert"] = false;
                            }

                            if (vSQLReader["AllowUpdate"] != System.DBNull.Value)
                            {
                                if (vSQLReader["AllowUpdate"].ToString().Trim() == "Y")
                                {
                                    DS_System_Modules.Rows[vRowCounter]["AllowUpdate"] = true;
                                }
                                else
                                {
                                    DS_System_Modules.Rows[vRowCounter]["AllowUpdate"] = false;
                                }
                            }
                            else
                            {
                                DS_System_Modules.Rows[vRowCounter]["AllowUpdate"] = false;
                            }

                            if (vSQLReader["AllowDelete"] != System.DBNull.Value)
                            {
                                if (vSQLReader["AllowDelete"].ToString().Trim() == "Y")
                                {
                                    DS_System_Modules.Rows[vRowCounter]["AllowDelete"] = true;
                                }
                                else
                                {
                                    DS_System_Modules.Rows[vRowCounter]["AllowDelete"] = false;
                                }
                            }
                            else
                            {
                                DS_System_Modules.Rows[vRowCounter]["AllowDelete"] = false;
                            }

                            if (vSQLReader["DML"] != System.DBNull.Value) { DS_System_Modules.Rows[vRowCounter]["DML"] = vSQLReader["DML"].ToString().Trim(); } else { DS_System_Modules.Rows[vRowCounter]["DML"] = "NI"; }
                            
                            vRowCounter += 1;
                        }
                        vSQLReader.Close();
                        sqlConnection1.Close();
                        GRD_Forms.DataSource = DS_System_Modules;
                        GRD_Forms.DataBind();
                        GRD_Forms.Refresh();
                        GRD_Forms.UpdateData();
                       
                    }


                }
                catch (Exception ex)
                {
                    
                    ExceptionHandler.HandleException(ex.Message,this.Name, "sControlForm");
                }
            }
            private void GRD_Forms_CellChange(object sender, Infragistics.Win.UltraWinGrid.CellEventArgs e)
            {

                if (vFormMode == "NI")
                {
                    vFormMode = "I";
                }
                else if (vFormMode == "N")
                {
                    vFormMode = "U";
                }
                if (GRD_Forms.ActiveRow != null)
                {
                    if (GRD_Forms.ActiveRow.Cells["Code"].Value != null)
                    {
                        if (GRD_Forms.ActiveRow.Cells["Code"].Value.ToString() != "")
                        {
                            if (GRD_Forms.ActiveRow.Cells["DML"].Value.ToString() == "NI")
                            {
                                GRD_Forms.ActiveRow.Cells["DML"].Value = "I";
                            }
                            else if (GRD_Forms.ActiveRow.Cells["DML"].Value.ToString() == "N")
                            {
                                GRD_Forms.ActiveRow.Cells["DML"].Value = "U";
                            }

                        }
                    }
                }

            }

            private void sSaveSystemModules()
            {
                try
                {
                    GRD_Forms.PerformAction(UltraGridAction.ExitEditMode);

                    if (GRD_Forms.Rows.Count > 0)
                    {
                        long rowsAffected = 0;
                        string vIsEnabled = "";
                        string vQuery = "";
                        string vUpdate = "";
                        string vInsert = "";
                        string vDelete = "";
                        string vSysStatment = "";
                        foreach (UltraGridRow vCurrRow in GRD_Forms.Rows)
                        {
                            if (vCurrRow.Cells["IsEnabled"].Value.ToString() == "True")
                                vIsEnabled = "Y";
                            else if (vCurrRow.Cells["IsEnabled"].Value.ToString() == "False")
                                vIsEnabled = "N";
                            if (vCurrRow.Cells["AllowQuery"].Value.ToString() == "True")
                                vQuery = "Y";
                            else if (vCurrRow.Cells["AllowQuery"].Value.ToString() == "False")
                                vQuery = "N";
                            if (vCurrRow.Cells["AllowInsert"].Value.ToString() == "True")
                                vInsert = "Y";
                            else if (vCurrRow.Cells["AllowInsert"].Value.ToString() == "False")
                                vInsert = "N";
                            if (vCurrRow.Cells["AllowUpdate"].Value.ToString() == "True")
                                vUpdate = "Y";
                            else if (vCurrRow.Cells["AllowUpdate"].Value.ToString() == "False")
                                vUpdate = "N";
                            if (vCurrRow.Cells["AllowDelete"].Value.ToString() == "True")
                                vDelete = "Y";
                            else if (vCurrRow.Cells["AllowDelete"].Value.ToString() == "False")
                                vDelete = "N";

                            if (vCurrRow.Cells["DML"].Value == "I")
                            {
                                vSysStatment += "INSERT INTO [User_System_Forms]" + "                 ([SYS_FRM_Code]                        , [USR_ID]                                  ,      [IsEnabled]         ,     [AllowQuery]      ,  [AllowInsert]    ,   [AllowUpdate]    ,   [AllowDelete]  ) VALUES" + "\n" +
                                                                                " ('" + (vCurrRow.Cells["Code"].Value.ToString()) + "','" + (TXT_UserID.Text.ToString()) + "','" + vIsEnabled + "','" + vQuery + "','" + vInsert + "'  ,'" + vUpdate + "'   ,'" + vDelete + "' )";



                            }
                            else if (vCurrRow.Cells["DML"].Value == "U")
                            {
                                vSysStatment += " UPDATE [User_System_Forms] SET " + "        [IsEnabled] = '" + vIsEnabled + "'" + "       ,[AllowQuery] = '" + vQuery + "'" + "       ,[AllowInsert] = '" + vInsert + "'" + "       ,[AllowUpdate] = '" + vUpdate + "'" + "       ,[AllowDelete] = '" + vDelete + "'" + " WHERE  [SYS_FRM_Code] = '" + (vCurrRow.Cells["Code"].Value.ToString()) + "' " + " And    [USR_ID] = '" + TXT_UserID.Text.ToString() + "'";
                                
                            }
                            
                        }
                        rowsAffected = BasicClass.fDMLData(vSysStatment, this.Name);
                        if (rowsAffected > 0)
                        {

                        }    
                    }


                   
                }
                catch (Exception ex)
                {
                    
                    ExceptionHandler.HandleException(ex.Message,this.Name , "sSaveSystemModules");
                }
                
            }
            private void EnableOptions()
            {
                SqlConnection sqlConnection1 = new SqlConnection(BasicClass.vConectionString);
                SqlCommand vSqlCommand = new SqlCommand();
                try
                {
                    SqlDataReader vSQLReader;
                    vSqlCommand.Connection = sqlConnection1;
                    string vWhereStmt = "";
                    vSqlCommand.CommandText = "\n" +
                                            "SELECT     System_Forms.Code, System_Forms.DescA									" + "\n" +
                                            "		   , ISNULL(User_System_Forms.IsEnabled,'N') AS IsEnabled					" + "\n" +
                                            "		   , ISNULL(User_System_Forms.AllowQuery,'N') AS AllowQuery					" + "\n" +
                                            "		   , ISNULL(User_System_Forms.AllowInsert,'N')  AS AllowInsert				" + "\n" +
                                            "		   , ISNULL(User_System_Forms.AllowUpdate,'N')  AS AllowUpdate				" + "\n" +
                                            "		   ,ISNULL (User_System_Forms.AllowDelete , 'N') AS AllowDelete				" + "\n" +
                                            "FROM				System_Forms													" + "\n" +
                                            "LEFT OUTER JOIN    User_System_Forms												" + "\n" +
                                            "ON					System_Forms.Code = User_System_Forms.SYS_FRM_Code				" + "\n" +
                                            "AND				User_System_Forms.USR_ID = " + BasicClass.vUsrID + "									" + "\n" +
                                            "AND				User_System_Forms.SYS_FRM_Code = '" + this.Name + "'									" + "\n";

                    sqlConnection1.Open();
                    vSQLReader = vSqlCommand.ExecuteReader();

                    if (vSQLReader.HasRows == true)
                    {
                        while (vSQLReader.Read())
                        {
                            //to fill all field by found to next adn previous
                            
                            if (vSQLReader["AllowQuery"] != System.DBNull.Value)
                            {
                                if (vSQLReader["AllowQuery"].ToString().Trim() == "Y")
                                {
                                    Toolbar_Options.Tools["BTN_Previous"].SharedProps.Enabled = true;
                                    Toolbar_Options.Tools["BTN_Next"].SharedProps.Enabled = true;
                                    Toolbar_Options.Tools["BTN_Firest"].SharedProps.Enabled = true;
                                    Toolbar_Options.Tools["BTN_last"].SharedProps.Enabled = true;
                                }
                                else
                                {
                                    Toolbar_Options.Tools["BTN_Previous"].SharedProps.Enabled = false;
                                    Toolbar_Options.Tools["BTN_Next"].SharedProps.Enabled = false;
                                    Toolbar_Options.Tools["BTN_Firest"].SharedProps.Enabled = false;
                                    Toolbar_Options.Tools["BTN_last"].SharedProps.Enabled = false;
                                }
                            }
                            else
                            {
                                Toolbar_Options.Tools["BTN_Previous"].SharedProps.Enabled = false;
                                Toolbar_Options.Tools["BTN_Next"].SharedProps.Enabled = false;
                            }

                            if (vSQLReader["AllowInsert"] != System.DBNull.Value)
                            {
                                if (vSQLReader["AllowInsert"].ToString().Trim() == "Y")
                                {
                                    Toolbar_Options.Tools["BTN_New"].SharedProps.Enabled = true;
                                }
                                else
                                {
                                    Toolbar_Options.Tools["BTN_New"].SharedProps.Enabled = false;
                                }
                            }
                            else
                            {
                                Toolbar_Options.Tools["BTN_New"].SharedProps.Enabled = false;
                            }

                            if (vSQLReader["AllowUpdate"] != System.DBNull.Value)
                            {
                                if (vSQLReader["AllowUpdate"].ToString().Trim() == "Y")
                                {

                                    Toolbar_Options.Tools["BTN_Save"].SharedProps.Enabled = true;
                                }
                                else
                                {
                                    Toolbar_Options.Tools["BTN_Save"].SharedProps.Enabled = false;
                                }
                            }
                            else
                            {
                                Toolbar_Options.Tools["BTN_Save"].SharedProps.Enabled = false;
                            }

                            if (vSQLReader["AllowDelete"] != System.DBNull.Value)
                            {
                                if (vSQLReader["AllowDelete"].ToString().Trim() == "Y")
                                {
                                    Toolbar_Options.Tools["BTN_Delete"].SharedProps.Enabled = true;
                                }
                                else
                                {
                                    Toolbar_Options.Tools["BTN_Delete"].SharedProps.Enabled = false;
                                }
                            }
                            else
                            {
                                Toolbar_Options.Tools["BTN_Delete"].SharedProps.Enabled = false;
                            }

                        }
                        vSQLReader.Close();
                        sqlConnection1.Close();
                        
                    }
                }
                catch (Exception ex)
                {
                    
                    ExceptionHandler.HandleException(ex.Message,this.Name ,"EnableOptions");
                }
            }

        #endregion

           



    }
}
