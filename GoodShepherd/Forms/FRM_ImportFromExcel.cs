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
using Infragistics.Documents.Excel;
using Infragistics.Win.UltraWinToolTip;
using Infragistics.Win;



namespace GoodShepherd
{
    public partial class FRM_ImportFromExcel : RadForm
    {
        string activeText = "";
    List<cHumanDetails> vLstItems =  new List<cHumanDetails>();
    DateTime vTDate; 
        public FRM_ImportFromExcel()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "excel files (*.xls, *.xlt , .xlsx)|*.xls;*.xlt|XLSX files (*.xlsx, *.xlsm, *.xltx, *.xltm) | *.xlsx";
          //  openFileDialog.FilterIndex = 2;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                TXT_FileName.Text = openFileDialog.FileName;

                ultraSpreadsheet1.Workbook = Workbook.Load(openFileDialog.FileName);

                ultraSpreadsheet1.FormulaBar.Visible = false;
            }
        }

        
        private bool fValidateInputs()
        {
            ERO_Error.Clear();
            if (TXT_FileName.Text == "")
            {
                TXT_FileName.Focus();
                ERO_Error.SetError(TXT_FileName, " يرجى اختيار الملف الاكسيل");
                return false;
            }

            if (int.Parse(TXT_WorkSheet.Value.ToString()) == 0)
            {
                TXT_WorkSheet.Focus();
                ERO_Error.SetError(TXT_WorkSheet, " يرجى اختيار ورقة العمل");
                return false;
            }

            if (int.Parse(TXT_FirstRow.Value.ToString()) == 0)
            {
                TXT_FirstRow.Focus();
                ERO_Error.SetError(TXT_FirstRow, "يرجى اختيار اول صف ");
                return false;
            }
            if (int.Parse(TXT_FirstColumn.Value.ToString()) == 0)
            {
                TXT_FirstColumn.Focus();
                ERO_Error.SetError(TXT_FirstColumn, "يرجى اختيار اول عامود ");
                return false;
            }
            if (int.Parse(TXT_Name.Value.ToString()) == 0)
            {
                TXT_Name.Focus();
                ERO_Error.SetError(TXT_Name, " يرجى اختيار عمود الاسم");
                return false;
            }

            if (int.Parse(TXT_MobileNumber.Value.ToString()) == 0)
            {
                TXT_MobileNumber.Focus();
                ERO_Error.SetError(TXT_MobileNumber, " يرجى اختيار عمود رقم الموبايل");
                return false;
            }

            if (int.Parse(TXT_BirthDate.Value.ToString()) == 0)
            {
                TXT_BirthDate.Focus();
                ERO_Error.SetError(TXT_BirthDate, " يرجى اختيار عمود تاريخ الميلاد");
                return false;
            }
            if (int.Parse(TXT_Gender.Value.ToString()) == 0)
            {
                TXT_Gender.Focus();
                ERO_Error.SetError(TXT_Gender, " يرجى اختيار عمود النوع");
                return false;
            }
            return true;
        }


        private void STS_Main_ButtonClick(object sender, Infragistics.Win.UltraWinStatusBar.PanelEventArgs e)
        {
            try
            {
                if ( e.Panel.Key.ToString() == "BTN_OK")
                {
                    if (fValidateInputs())
                    {
                        cImportExcel vImport = new cImportExcel();
                        vImport.vTDate = BasicClass.fGetCurDateTime();

                        vImport.vFileName     = TXT_FileName.Text;
                        vImport.vWorkSheetNo  = int.Parse(TXT_WorkSheet.Value.ToString());
                        vImport.vFirstRow     = int.Parse(TXT_FirstRow.Value.ToString());
                        vImport.vFirstColumn  = int.Parse(TXT_FirstColumn.Value.ToString());
                        vImport.vNameCol      = int.Parse(TXT_Name.Value.ToString());
                        vImport.vMobileNoCol  = int.Parse(TXT_MobileNumber.Value.ToString());
                        vImport.vAddressCol   = int.Parse(TXT_Address.Value.ToString());
                        vImport.vBirthDateCol = int.Parse(TXT_BirthDate.Value.ToString());
                        vImport.vGenderCol    = int.Parse(TXT_Gender.Value.ToString());
                        vLstItems             = vImport.fImportPersons();
                        this.Close();
                    }
                }
                else if (e.Panel.Key.ToString() == "BTN_Cancel")
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.HandleException(ex.Message, this.Name, "StatusBar_Lov_ButtonClick");
            }
        }


        private void ultraSpreadsheet1_SelectionChanged(object sender, Infragistics.Win.UltraWinSpreadsheet.SpreadsheetSelectionChangedEventArgs e)
        {
            try
            {
                int sheet = ultraSpreadsheet1.ActiveWorksheet.Index + 1;
                int Row = ultraSpreadsheet1.ActiveCell.Row + 1;
                int Column = ultraSpreadsheet1.ActiveCell.Column + 1;


                if (activeText == "TXT_Name" )
                {
                    TXT_Name.Value = Column;
                }
                else if (activeText == "TXT_MobileNumber" )
                {
                    TXT_MobileNumber.Value = Column;
                }
                else if (activeText == "TXT_Address")
                {
                    TXT_Address.Value = Column;
                }
                else if (activeText == "TXT_Gender")
                {
                    TXT_Gender.Value = Column;
                }
                else if (activeText == "TXT_BirthDate")
                {
                    TXT_BirthDate.Value = Column;
                }
                else
                {
                    

                    TXT_WorkSheet.Text = sheet.ToString();
                    TXT_FirstRow.Text = Row.ToString();
                    TXT_FirstColumn.Text = Column.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
           // ultraSpreadsheet1.ActiveCell.Column + 1;
            Infragistics.Documents.Excel.Worksheet sheet = ultraSpreadsheet1.ActiveWorksheet;
            foreach (var item in sheet.Columns)
            {
               
            }

        }

        private void TXT_Name_EditorButtonClick(object sender, Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e)
        {
            TXT_Name.Focus();
        }

        private void TXT_Name_MouseHover(object sender, EventArgs e)
        {
            // Create a new ToolTipInfo
            UltraToolTipInfo toolTipInfo = new UltraToolTipInfo("برجاء اختيار عمود اسم المخدوم ", ToolTipImage.Info, "", DefaultableBoolean.True);
            this.ultraToolTipManager1.SetUltraToolTip(TXT_Name, toolTipInfo);
        }

        private void TXT_MobileNumber_MouseHover(object sender, EventArgs e)
        {
            // Create a new ToolTipInfo
            UltraToolTipInfo toolTipInfo = new UltraToolTipInfo("برجاء اختيار عمود رقم الموبيل ", ToolTipImage.Info, "", DefaultableBoolean.True);
            this.ultraToolTipManager1.SetUltraToolTip(TXT_MobileNumber, toolTipInfo);
        }

        private void TXT_Address_MouseHover(object sender, EventArgs e)
        {
            // Create a new ToolTipInfo
            UltraToolTipInfo toolTipInfo = new UltraToolTipInfo("برجاء اختيار عمود العنوان ", ToolTipImage.Info, "", DefaultableBoolean.True);
            this.ultraToolTipManager1.SetUltraToolTip(TXT_Address, toolTipInfo);
        }
        private void TXT_BirthDate_MouseHover(object sender, EventArgs e)
        {
            // Create a new ToolTipInfo
            UltraToolTipInfo toolTipInfo = new UltraToolTipInfo("برجاء اختيار عمود تاريخ الميلاد ", ToolTipImage.Info, "", DefaultableBoolean.True);
            this.ultraToolTipManager1.SetUltraToolTip(TXT_BirthDate, toolTipInfo);
        }

        private void TXT_Gender_MouseHover(object sender, EventArgs e)
        {
            // Create a new ToolTipInfo
            UltraToolTipInfo toolTipInfo = new UltraToolTipInfo("برجاء اختيار النوع ", ToolTipImage.Info, "", DefaultableBoolean.True);
            this.ultraToolTipManager1.SetUltraToolTip(TXT_Gender, toolTipInfo);
        }

      

        private void TXT_Name_Enter(object sender, EventArgs e)
        {
            string TextName = ((Infragistics.Win.UltraWinEditors.UltraNumericEditor)sender).Name;
            activeText = TextName;
        }

               
               

            
    }
}
