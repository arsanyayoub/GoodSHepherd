using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace GoodShepherd
{
  public  class ExceptionHandler
    {
        public static void HandleException(string pRetrivedException, string pFormName, string pSubName)
        {
            FileStream vTxtFile = new FileStream(Application.StartupPath + "\\Errors.txt", FileMode.Append, FileAccess.Write);
            System.IO.StreamWriter vTxtWriter = new System.IO.StreamWriter(vTxtFile);
            vTxtWriter.AutoFlush = true;
            vTxtWriter.WriteLine("\n" + "\n" + DateTime.Now.ToShortDateString() + "  =  " + DateTime.Now.ToShortTimeString());
            vTxtWriter.WriteLine("\t" + "THE FORM NAME THAT HAS OCCURED THE ERROR: " + pFormName + "\n"+ "\t" + "THE SUB NAME THAT HAS OCCURED THE ERROR: " + pSubName + "\n"+ "\t" + "\t" + "The Error Is " + pRetrivedException);
            vTxtWriter.WriteLine("============================================================================");
            vTxtWriter.Close();
            MessageBox.Show(pRetrivedException, "Handled Exception", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading | MessageBoxOptions.RtlReading);
        }

    }
}
