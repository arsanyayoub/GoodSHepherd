using Microsoft.Office.Interop;
using System.Windows.Forms;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;
using System.Windows.Forms;
//using System.Threading.Thread;
using System.Collections.Generic;
using GoodShepherd;
using Microsoft.Office.Interop;
using Microsoft.Office;
using System;
using Microsoft.Office.Interop.Excel;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

// AR 06-04-2017
// AR 07-05-2017
// AR 08-05-2017 To Fix Bug In Import From Excel
// AR 19-11-2017
// AR 26-11-2017
// AR 04-12-2017 To Get Only Non Reserved Items Before Transaction Date
public class cImportExcel {
    
    private FRM_Waiting WaitFRM;
    
    private System.Threading.Thread vThread;
    
    //  Excel variables 
    private Microsoft.Office.Interop.Excel.Application vXLS;
    
    private Microsoft.Office.Interop.Excel.Workbook vWorkBook;
    
    // Parameters
    public string vFileName;
    
    private int vWorkSheetNumber;
    
  
    
    private int vFirstEmpRow;
    
    

    private List<cHumanDetails> vLstData = new List<cHumanDetails>();
    
    private int vItemsCount = 0;
    
    private int vErrorFound = 0;
    
    private bool vIsUserConfirm = true;
    
    private Worksheet vErrorsWorkSheet;
    private Worksheet vWorkSheet;
    private string vImportMode = "";
    
   
    
    public DateTime vTDate;
    
    public string vStrCode;


    public int vNameCol = 0;
    public int vAddressCol = 0;
    public int vMobileNoCol = 0;
    public int vEducationCol = 0;

    public int vBirthDateCol = 0;
    public int vGenderCol = 0;


    public int vWorkSheetNo = 0;
    public int vFirstRow = 0;
    public int vFirstColumn = 0;

    string[] vSqlStatment = new string[1];
    private void sEmptySqlStatmentArray()
    {
        vSqlStatment = new string[1];
    }
    private void sFillSqlStatmentArray(string pStatment)
    {

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
    [STAThread]
    public List<cHumanDetails> fImportPersons() {
        try {
            vImportMode = "Persons";
            vLstData.Clear();
            vXLS = new Microsoft.Office.Interop.Excel.Application();
            vWorkBook = vXLS.Workbooks.Open(vFileName);
            vWorkSheet = vWorkBook.Worksheets[vWorkSheetNo];
            vErrorsWorkSheet = this.fGenerateExcel();
            vWorkSheetNumber = vWorkSheetNo;
            vFirstEmpRow = vFirstRow;
            vThread = new System.Threading.Thread(sOpenWaitingForm);
            vThread.SetApartmentState(ApartmentState.STA);
            vThread.Start();
            WaitFRM = new FRM_Waiting();
            WaitFRM.ShowDialog();
        }
        catch (Exception ex) {
            MessageBox.Show(ex.Message);
            vLstData.Clear();
            vWorkBook.Close(false);
            vXLS.Quit();
        }
        
        return vLstData;
    }
    
    private Microsoft.Office.Interop.Excel.Worksheet fGenerateExcel() {
       // insert new excel sheet to copy errors to it
        Microsoft.Office.Interop.Excel.Worksheet vWorkSheet = new Worksheet();
        try {
            vWorkSheet = vWorkBook.Worksheets.Add();
            vWorkSheet.Name = ("Errors" + DateTime.Now.Ticks.ToString());
            vWorkBook.Activate();
            if ((System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "ar")) {
                vWorkSheet.DisplayRightToLeft = true;
            }
            else if ((System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "en")) {
                vWorkSheet.DisplayRightToLeft = false;
            }
            
            vXLS.Visible = true;
         
        }
        catch (Exception ex) {
            // vProgress.sProgressOff()
            vWorkBook.Close(true);
            // sKillAllExcels()
            ExceptionHandler.HandleException(ex.Message, "cImportExcel", "fGenerateExcel");
        }
        return vWorkSheet; 
    }

    private void sCopyRowTo(Microsoft.Office.Interop.Excel.Worksheet pInputSheet, Microsoft.Office.Interop.Excel.Worksheet pOutputSheet,  int pRowIn, int pRowOut, int pErrorCell, DateTime pToDate, string pErrorMessage)
    {
        pErrorMessage = "";
        pInputSheet.Activate();
        pInputSheet.Rows[pRowIn].Copy();
        pOutputSheet.Activate();
        pOutputSheet.Rows[pRowOut].Select();
        pOutputSheet.Paste();
        if ((pErrorCell != 0)) {
            pOutputSheet.Cells[pRowOut, pErrorCell].Interior.Color = Color.Red;
        }
        else {
            for (int i = 1; (i <= 40); i++) {
                string vDateString;
                vDateString = (pToDate.Month.ToString() + ("/" 
                            + (pOutputSheet.Cells[pRowOut, i].Value + ("/" + pToDate.Year.ToString()))));
                if (IsDate(vDateString)) {
                    pOutputSheet.Cells[(pRowOut + 1), i].Value = Convert.ToDateTime(vDateString).DayOfWeek.ToString();
                }
                
            }
            
        }
        
        if ((pErrorMessage != "")) {
            pOutputSheet.Cells[pRowOut, (pOutputSheet.UsedRange.Column 
                        + (pOutputSheet.UsedRange.Columns.Count - 1))].Value = pErrorMessage;
            pOutputSheet.Cells[pRowOut, (pOutputSheet.UsedRange.Column 
                        + (pOutputSheet.UsedRange.Columns.Count - 1))].Interior.Color = Color.Red;
        }
        
    }
    public static bool IsDate(Object obj)
    {
        string strDate = obj.ToString();
        try
        {
            DateTime dt = DateTime.Parse(strDate);
            if ((dt.Month != System.DateTime.Now.Month) || (dt.Day < 1 && dt.Day > 31) || dt.Year != System.DateTime.Now.Year)
                return false;
            else
                return true;
        }
        catch
        {
            return false;
        }
    }
       
    private void sOpenWaitingForm() {
        // AR 06-04-2017
        try {
            if ((vImportMode == "Persons")) {
                this.sImportPersons();
            }
            
            int vSuccessCount = (vItemsCount - vErrorFound);
            if (!(WaitFRM == null)) {
                if (vIsUserConfirm) {
                    if ((WaitFRM.Name == "FRM_Waiting")) {

                        WaitFRM.UpdateProgress("Import",true ,vSuccessCount, vItemsCount);
                        
                    }
                                       
                }
                else if ((WaitFRM.Name == "FRM_Waiting")) {
                    WaitFRM.UpdateProgress("Import", false, vSuccessCount, vItemsCount);
                 
                }
                
              //  WaitFRM.Controls["ProgressBar1"].Visible = false;
              //  WaitFRM.Controls["BTN_Action"].Tag = "Done";
            }
            vLstData.Clear();
            // vThread.Abort()
        }
        catch (Exception ex) {
            ExceptionHandler.HandleException(ex.Message, "cImportExcel", "sOpenWaitingForm");
        }
        
    }
    
    private void sImportPersons() {
        // AR 04-05-2017
        try {
            DateTime vCurrentDate = BasicClass.fGetCurDateTime();
            int x = vFirstEmpRow;
            this.sCopyRowTo(vWorkSheet, vErrorsWorkSheet, 1, (vErrorFound + 1), 1 , BasicClass.fGetCurDateTime() , "");
            //  testing getting value 
            string vName = "";
           string vAddress = "";
            string vMobileNumber = "";
            string vEducation = "";
            string vBirthdate = "";
            string vGender = "";
            

             int vErrorCol = 0;
            string vErrorMessage = "";
            Microsoft.Office.Interop.Excel.Range vRange;
            vRange = vWorkSheet.UsedRange;
            for (x = vFirstEmpRow; (x <= vRange.Rows.Count); x++) {
                if ((vWorkSheet.Cells[x, vNameCol].Value != null))
                {
                    vErrorCol = 0;
                    if ((vWorkSheet.Cells[x, vNameCol].Value == null)) {
                        vErrorCol = vNameCol;
                        vErrorMessage = "يرجى  اختيار الاسم";
                    }
                    else
                    {
                            if (vWorkSheet.Cells[x, vNameCol].Value != null)
                            {
                                vName = vWorkSheet.Cells[x, vNameCol].Value.ToString();
                            }
                    }

                    //////////if (isAlphabetsWord(vWorkSheet.Cells[x, vNameCol].Value.ToString()) == false)
                    //////////{
                    //////////    vErrorCol = vNameCol;
                    //////////    vErrorMessage = "خطأ فى الاسم";
                    //////////}

                    if (vAddressCol > 0)
                    {
                        if ((vWorkSheet.Cells[x, vAddressCol].Value == null))
                        {
                            vErrorCol = vAddressCol;
                            vErrorMessage = "يرجى  اختيار العنوان";
                        }
                        else
                        {
                                if (vWorkSheet.Cells[x, vAddressCol].Value != null)
                                {
                                    vAddress = vWorkSheet.Cells[x, vAddressCol].Value.ToString();
                                }
                        }
                    }

                    if (vMobileNoCol > 0)
                    {
                        
                        if ((vWorkSheet.Cells[x, vMobileNoCol].Value == null))
                        {
                            vErrorCol = vMobileNoCol;
                            vErrorMessage = "يرجى  اختيار رقم الموبايل";

                        }
                        else if (isPhoneNumber(vWorkSheet.Cells[x, vMobileNoCol].Value.ToString()) == false)
                                        {
                                            vErrorCol = vMobileNoCol;
                                            vErrorMessage = "خطأ فى رقم الموبايل";
                                        }

                        else
                        {
                            if (vWorkSheet.Cells[x, vMobileNoCol].Value != null)
                            {
                                vMobileNumber = vWorkSheet.Cells[x, vMobileNoCol].Value.ToString();
                            }
                        }
                        
                    }

                    if (vBirthDateCol > 0)
                    {
                        if ((vWorkSheet.Cells[x, vBirthDateCol].Value == null ))
                        {
                            vErrorCol = vBirthDateCol;
                            vErrorMessage = "يرجى  اختيار تاريخ الميلاد";

                        }
                          else
                          {
                                  string xx = vWorkSheet.Cells[x, vBirthDateCol].Value.ToString();
                                  if (xx.Contains(@"^[a-zA-Z]+$") == false)
                                  {
                                      DateTime time = DateTime.Parse(vWorkSheet.Cells[x, vBirthDateCol].Value.ToString());
                                      string format = "yyyy-MM-dd";
                                      // DateTime dt = DateTime.Parse(TXT_Date.Text);
                                      vBirthdate = time.ToString(format);
                                  }

                          }
                        
                    }
                    

                    if (vEducationCol > 0 )
                    {
                        if ((vWorkSheet.Cells[x, vEducationCol].Value == null))
                        {
                            vErrorCol = vEducationCol;
                            vErrorMessage = "يرجى  اختيار المؤهل الدراسي";
                        }
                        else
                        {
                            if (vWorkSheet.Cells[x, vEducationCol].Value != null)
                            {
                                vEducation = vWorkSheet.Cells[x, vEducationCol].Value.ToString();
                            }
              
                        }
                    }

                    if (vGenderCol > 0)
                    {
                        if ((vWorkSheet.Cells[x, vGenderCol].Value == null))
                        {
                            vErrorCol = vGenderCol;
                            vErrorMessage = "يرجى  اختيار النوع";
                        }
                        else
                        {
                            vGender = vWorkSheet.Cells[x, vGenderCol].Value;
                            if (vGender.ToString().Trim().Contains("كر") == true || vGender.ToString().Trim().Equals("M") == true)
                            {
                                vGender = "M";
                            }
                            else if (vGender.ToString().Trim().Contains("نث") == true || vGender.ToString().Trim().Equals("F") == true)
                            {
                                vGender = "F";
                            }
                        }
                    }



                    if ((vErrorCol != 0)) {
                        vErrorFound++;
                        this.sCopyRowTo(vWorkSheet, vErrorsWorkSheet, x, (vErrorFound + 1), vErrorCol,BasicClass.fGetCurDateTime(), vErrorMessage);
                        // TODO: Labeled Arguments not supported. Argument: 6 := 'pErrorMessage'
                    }
                    else {
                        cHumanDetails vHumanItem = new cHumanDetails();
                        vHumanItem.vName = vName;
                        vHumanItem.vAddress =vAddress;
                        vHumanItem.vMobileNo = vMobileNumber;
                        vHumanItem.vEducation = vEducation;
                        vHumanItem.vBirthDate = vBirthdate;
                        vHumanItem.vGender = vGender;
                         vHumanItem.vIndex = vLstData.Count;
                        // AR ADDED 10-04-2017 
                        // ---------------------------------------------------------------------------------------
                        //if ((this.fIsItemExistAgainOnGrid(vCountItem) == false)) {
                        //    this.sGetAvailableQtyWithCost(vCountItem, vTDate, vStrCode);
                        //    // TODO: Labeled Arguments not supported. Argument: 2 := 'pTDate'
                        //    // TODO: Labeled Arguments not supported. Argument: 3 := 'pStrCode'
                        //}
                        
                        // ---------------------------------------------------------------------------------------
                        vLstData.Add(vHumanItem);
                    }


                    
                    //  Increase Counter
                    vItemsCount++;
                }
                
                // x += 1
                //  get new values
                vName = vWorkSheet.Cells[x, vNameCol].Value;
            }
           //  excute databse 
            int vSuccessCount = (vItemsCount - vErrorFound);
            if ((vSuccessCount > 0)) {
                if ((MessageBox.Show(("تم استيراد البيانات " + ("\r\n" 
                                + (vSuccessCount.ToString() + (" من " 
                                + (vItemsCount.ToString() + (" عدد " + ("\r\n" + "هل تريد الاستمرار ؟"))))))), "استعلام عن العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)) {
                    // HERE I INSERT DATA INTO DATA BASE
                                    string vsqlstmt = "";   
                                foreach (var item in vLstData)
                                    {
                                        if (item !=null)
                                        {
                                            vsqlstmt = "INSERT INTO [dbo].[TBL_MainPerson]" + "\n" +
                                                        "           ([Church_ID]" + "\n" +
                                                        "           ,[City_ID]" + "\n" +
                                                        "           ,[PersType_ID]" + "\n" +
                                                        "           ,[Name]" + "\n" +
                                                        "           ,[AdressDisc]" + "\n" +
                                                        "           ,[Mobile]" + "\n" +
                                                        "           ,[BirthDate]" + "\n" +
                                                        "           ,[Gender]" + "\n" +
                                                        "          )" + "\n" +
                                                        "     VALUES " + "\n" +
                                                        "           (" + BasicClass.vChurchID + ", " + "\n" +
                                                        "           "+ BasicClass.vCityID +", " + "\n" +
                                                        "           3, " + "\n" +
                                                        "           '"+ item.vName  +"', " + "\n" +
                                                        "           '"+ item.vAddress +"', " + "\n" +
                                                        "           '"+ item.vMobileNo +"', " + "\n" +
                                                        "           '" + item.vBirthDate + "', " + "\n" +
                                                        "           '" + item.vGender + "' " + "\n" +
                                                        "           ) " + "\n";
                                            sFillSqlStatmentArray(vsqlstmt);
                                        }
                                    }
                                long vRowsAffected = 0;
                                vRowsAffected = BasicClass.fDMLData(vSqlStatment, "cImportExcel");
                                if (vRowsAffected > 0 )
                                {
                                    MessageBox.Show("تم ادخال البيانات بنجاح", "نجاح", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                                }
                }
                else {
                    vIsUserConfirm = false;
                }
                
            }
            else {
                vIsUserConfirm = false;
            }
            
            //  output errors 
            if ((vErrorFound >= 1)) {
                // MessageBox.Show(vCollectErrors)
                vErrorsWorkSheet.Activate();
            }
            else {
                // vErrorsWorkSheet.Delete()
            }
            
        }
        catch (Exception ex) {
            MessageBox.Show(ex.Message);
            vWorkBook.Close(false);
            vXLS.Quit();
        }
        finally {
            BasicClass.fReturnNonQuery(("ALTER DATABASE " 
                            + (BasicClass.vSqlConn.Database + " SET MULTI_USER WITH ROLLBACK IMMEDIATE")), "");
        }
        
    }
    
    public cImportExcel() {
       this.sEmptySqlStatmentArray();
    }
    
     
    private bool fIsItemExistAgainOnGrid(ref cHumanDetails pRow) {
        // AR ADDED 04-05-2017 To Validate that if there is newer items with cost on grid
        bool vResult = false;
        try {
           
            foreach (cHumanDetails vRow in vLstData) {
                if ((pRow.vIndex != vRow.vIndex)) {
                    if (((vRow.vName) != null)) {
                        if ((vRow.vName == pRow.vName)) {
                            return true;
                        }
                        
                    }
                    
                }
                
            }
            

        }
        catch (Exception ex) {
            ExceptionHandler.HandleException(ex.Message, "cImportExcel", "fIsItemExistAgainOnGrid");
        }
        return vResult;        
    }
    public bool isPhoneNumber(string pNumber)
    {
        bool result = false;
        try
        {
            if (Regex.IsMatch(pNumber,"^[0-9]{11}$"))
            {
                result = true;
            }
            else
            {
                result = false;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(ex.Message, "cImportFromExcel", "isPhoneNumber");
        }
        return result;
    }
    public bool isAlphabetsWord(string pWord)
    {
        bool result = false;
        try
        {
            if (Regex.IsMatch(pWord, @"^[a-zA-Z]+$"))
            {
                result = true;
            }
            else
            {
                result = false;
            }
        }
        catch (Exception ex)
        {
            ExceptionHandler.HandleException(ex.Message, "cImportFromExcel", "isPhoneNumber");
        }
        return result;
    }
}