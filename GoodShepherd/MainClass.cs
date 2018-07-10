using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GoodShepherd
{
    static class MainClass
    {


        #region " Determine which form will run in subMain                                          "
        //Here In sub Main I initialize sql connection
        //determine which form will run
        [STAThread]
        public static void Main()
        {
            //modifide to start configartion 
            
                string vPath = null;
              //'I initialize sql connection
                BasicClass z = new BasicClass("BTS");
            if (z.vSuccess == false)
                System.Environment.Exit(0);
            FRM_MainForm vFrm_main = new FRM_MainForm();
            Application.EnableVisualStyles();
            Application.Run(vFrm_main);
        }
        #region " Protection functions                                                              "
        private static int fCheckRegisteration()
        {
            try
            {
                //    Dim vValidate As String
                //    Dim vStart As String

                //    Dim vLast As String
                //    Dim vStartDate As Date
                //    Dim vLastDate As Date = DateTime.Now
                //    Dim vPinCode As Decimal
                //    Dim vRegVer As Microsoft.Win32.RegistryKey
                //    Dim vPath As String
                //    Dim vProtect As New Protect.cProtection
                //    Return 3

                //    vPinCode = Val(vProtect.fGetMacId()) + Val("POS".GetHashCode)

                //    vPath = "Software\Microsoft\Windows\CurrentVersion\Policies\System\"
                //    vRegVer = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(vPath)
                //    vValidate = vRegVer.GetValue("XPv1")

                //    vStart = vRegVer.GetValue("XPv1D")
                //    If vStart Is Nothing Then Return -1
                //    vStart = sDecrypt(vStart)
                //    If Not Date.TryParse(vStart, vStartDate) Then
                //        If vStart = "" Then Return -1
                //        vStartDate = DateAdd(DateInterval.Day, -15, Date.Today)
                //    End If

                //    vLast = vRegVer.GetValue("XPv1U")
                //    If vLast Is Nothing Then Return -1
                //    vLast = sDecrypt(vLast)
                //    If Not Date.TryParse(vLast, vLastDate) Then vLastDate = Date.Now

                //    If vLast > Date.Now Then Return 4

                //    If vValidate = vProtect.UnLock(vPinCode) Then
                //        Return 1
                //    ElseIf vValidate = "Trial".GetHashCode Then
                //        If (vLastDate - vStartDate).Days < 15 And (vLastDate - vStartDate).Days >= 0 Then
                //            Return 2
                //        ElseIf (vLastDate - vStartDate).Days < 0 Then
                //            Return 4
                //        Else
                //            Return 3
                //        End If
                //    Else
                //        Return -1
                //    End If
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        #endregion
        #endregion

    }
}
