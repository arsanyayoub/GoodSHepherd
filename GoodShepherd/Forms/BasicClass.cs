
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Data;
using Microsoft.SqlServer.Management.Smo;
using GoodShepherd;
public class BasicClass
{

    public static string vConectionString = "";//"Data Source=.;Initial Catalog=GoodShepherd;Persist Security Info=True;User ID=sa;Password=P@$$w0rdMeedos4";

   // public static string vConectionString =""; //"Data Source=EimeCinter\\EimeSRV;Initial Catalog=StudentExam;User Id=sa;Password=P@$$w0rd2017;";

    // public static string vConectionString = "Data Source=192.168.1.47,1433;Network Library=DBMSSOCN;Initial Catalog=StudentExam;User ID=sa;Password=EimeP@$$w0rd;";
	public bool vSuccess;
    //For collecting SQL statements to send themm as a transaction
    #region "Variables Declaration                                                                           "
    public static int  vUsrID= 0;
    public static int vCityID = 0;
    public static int vChurchID = 0;
    public static string vUsrCode = "";
    public static string vUsrName = "";
    public static string vPassword = "";
    public static int vRoleID = 0;
    public static string vRoleName = "";
    #endregion
    public static string[] vSqlStatment = new string[1];
	#region " Connection Management                                                                         "
	private void sTestConenction(string pRegKey)
	{
		try {
            //Microsoft.Win32.RegistryKey vRegVer = default(Microsoft.Win32.RegistryKey);
            //string vPath = null;
            //string vDecryptedText = "";
            //vPath = "SOFTWARE\\ProVision";
            //vRegVer = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(vPath);
            //vDecryptedText = vRegVer.GetValue(pRegKey).ToString();
            ////vDecryptedText = "rz6hrkSLFbceHYh20294wkDXx+u/olCta5b6TAodMy2rlcBvg4nFgIFb9cN4KzGOi0FbTfjz0sir1ZQDx6TYTB0wTdmbqCcdzN14gEFfWWk3rtptHHFSB1A5EvCJVDgEmdT4fa64KSM2U1C7pUIcZrjzqcdcLaFCTFr/DjUXQS8=";
            //vConectionString = sDecrypt(vDecryptedText);
           vConectionString = "Data Source=ARCI;Initial Catalog=GoodShepherd;Persist Security Info=True;User ID=sa;Password=P@$$w0rdMeedos4";
           //vConectionString = "Data Source=EIME00/EIMESRV;Initial Catalog=StudentExam;User ID=sa;Password=EimeP@$$w0rd";
           //vConectionString = "Data Source=Lenovo-PC\\SQL2014;Initial Catalog=GoodShepherd;User Id=sa;Password=3112005;";
           	System.Data.SqlClient.SqlConnection vSqlConnection = new System.Data.SqlClient.SqlConnection(vConectionString);
			Microsoft.SqlServer.Management.Common.ServerConnection vConn = new Microsoft.SqlServer.Management.Common.ServerConnection(vSqlConnection);
			vConn.Connect();
			vConn.Disconnect();
			vSuccess = true;
           // MessageBox.Show("Passed !!!!!!!!!!!!!!");
            GoodShepherd.Properties.Settings.Default["GoodShepherdConnectionString"] = BasicClass.vConectionString;
		} catch (Exception ex) {
            FRM_DBConfiguration vFrm = new FRM_DBConfiguration();
            vFrm.vRegKey = pRegKey;
            vFrm.ShowDialog();
            if (vFrm.vSuccess == true)
            {
                sTestConenction(pRegKey);
                vSuccess = true;
            }
            else
            {
                vSuccess = false;
            }
            MessageBox.Show(ex.Message);
		}
	}
	#endregion
	#region " Initialize  Sql Connection                                                                    "
	//Here I Intialize sql connection that I'll use it in program
	public static SqlConnection vSqlConn;

	public BasicClass(string pRegKey)
	{
		sTestConenction(pRegKey);
		if (vSuccess == false) {
			return;
		}
       // MessageBox.Show(vConectionString);
		vSqlConn = new SqlConnection(vConectionString);
        GoodShepherd.Properties.Settings.Default.Properties["GoodShepherdConnectionString"].IsReadOnly = false;
        
        GoodShepherd.Properties.Settings.Default.Properties["GoodShepherdConnectionString"].DefaultValue = vConectionString;
      
		//Dim vConfig_rd As New Configuration.AppSettingsReader
		//vSqlConn = New SqlConnection(vConfig_rd.GetValue("ConnectionString", GetType(String)))

	}
	#endregion
	#region " Create Global Server Sql Connection                                                           "
	//NG 18-1-2009
	//Here I Intialize sql connection for master server transaction
	public static bool fTestGlobalConenction(string pConnStr)
	{

		try {
			string vDecryptedText = "";
			string vlConectionString = "";

			vDecryptedText = pConnStr;
			vlConectionString = sDecrypt(vDecryptedText);
			System.Data.SqlClient.SqlConnection vSqlConnection = new System.Data.SqlClient.SqlConnection(vlConectionString);
			Microsoft.SqlServer.Management.Common.ServerConnection vConn = new Microsoft.SqlServer.Management.Common.ServerConnection(vSqlConnection);
			vConn.Connect();
			vConn.Disconnect();
			return true;

		} catch (Exception ex) {
			return false;

		}
	}
	public static SqlConnection fGetGlobalConnection(string pConnStr)
	{
		SqlConnection functionReturnValue = default(SqlConnection);
		if (fTestGlobalConenction(pConnStr) == false) {
			return null;
		}
		try {
			pConnStr = sDecrypt(pConnStr);
			functionReturnValue = new SqlConnection(pConnStr);
		} catch {
			return null;
		}
		return functionReturnValue;

	}
	#endregion
	#region " Making DML Command                                                                            "
	//FK 13/4/2005
	//Here I'm making functions that executing DML command on System.Database
	public static long fDMLData(string pSqlStatment, string pFormName)
	{
		//FK 13/4/2005
		//In this function I execute only one command.
		SqlTransaction vTrans = default(SqlTransaction);
		try {
			SqlCommand vSqlCommand = new SqlCommand(pSqlStatment, vSqlConn);
			long vNoOfRowsAffected = 0;

			vSqlConn.Open();
			vTrans = vSqlConn.BeginTransaction(IsolationLevel.ReadCommitted);
			vSqlCommand.Transaction = vTrans;
			vNoOfRowsAffected = vSqlCommand.ExecuteNonQuery();
			vTrans.Commit();
			vSqlConn.Close();

			return vNoOfRowsAffected;
		} catch (SqlException vex) {
			vTrans.Rollback();
			if (vex.Number == 547) {
				vSqlConn.Close();
				////MessageCenter.fCallMsg("66", null);
			} else {
				////cException.sHandleException(vex.Message, pFormName, "cbase.fDMLSystem.Data");
			}

			return -1;
		} catch (Exception ex) {
			vTrans.Rollback();
			vSqlConn.Close();
			////cException.sHandleException(ex.Message, pFormName, "cbase.fDMLSystem.Data");
			return -1;
		} finally {
			if (vSqlConn.State == ConnectionState.Open | vSqlConn.State == ConnectionState.Broken) {
				vSqlConn.Close();
			}
		}
	}
	public static long fDMLData(string[] pSqlStatment, string pFormName)
	{
		long functionReturnValue = 0;
		//FK 13/4/2005
		//In this Function I execute a group of commands and sure that all command
		//are executed without errors by using transactions
		long vNoOfRowsAffected = 0;
		long vCounter = 0;
		SqlCommand vSqlCommand = default(SqlCommand);
		SqlTransaction vTrans = default(SqlTransaction);
		try {

			if (pSqlStatment.Length == 1 & string.IsNullOrEmpty(pSqlStatment[0])) {
				return functionReturnValue;
			}
			vSqlConn.Open();
			vTrans = vSqlConn.BeginTransaction(IsolationLevel.ReadCommitted);
			for (vCounter = 0; vCounter <= pSqlStatment.Length - 1; vCounter++) {
				vSqlCommand = new SqlCommand(pSqlStatment[vCounter], vSqlConn);
				///''''''''''''''''
				//MessageBox.Show(pSqlStatment(vCounter))
				///'''''''''''''''
				vSqlCommand.Transaction = vTrans;
				vNoOfRowsAffected = vNoOfRowsAffected + vSqlCommand.ExecuteNonQuery();
			}
			vTrans.Commit();
			vSqlConn.Close();
			return vNoOfRowsAffected;
		} catch (SqlException vex) {
			if (vex.Number == 547) {
				vTrans.Rollback();
				vSqlConn.Close();
				////MessageCenter.fCallMsg("67", null);
				//MessageBox.Show("áÇ íãßä ÇáÊÛííÑ Ýí åÐÇÇáÓÌá áÃÑÊÈÇØÉ ÈÓÌáÇÊ ÃÎÑì", "ÎØÃ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign Or MessageBoxOptions.RtlReading Or MessageBoxOptions.RtlReading)
			} else if (vex.Number == 2627) {
				vTrans.Rollback();
				vSqlConn.Close();
				////MessageCenter.fCallMsg("68", null);
				//MessageBox.Show("íæÌÏ ÊßÑÇÑ Ýí ÇáãÝÊÇÍ ÇáÃÓÇÓí ááÓÌá", "ÎØÃ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign Or MessageBoxOptions.RtlReading Or MessageBoxOptions.RtlReading)
			} else {
				vTrans.Rollback();
				vSqlConn.Close();
				////cException.sHandleException(vex.Message, pFormName, "cbase.fDMLSystem.Data");
			}
			return -1;
		} catch (Exception ex) {
			vTrans.Rollback();
			vSqlConn.Close();
			////cException.sHandleException(ex.Message, pFormName, "cbase.fDMLSystem.Data");
			return -1;
		} finally {
			if (vSqlConn.State == ConnectionState.Open | vSqlConn.State == ConnectionState.Broken) {
				vSqlConn.Close();
			}
		}
		return functionReturnValue;
	}
	public static long fDMLData(Hashtable pSqlStatmentHashtable, string pFormName)
	{
		//BF 08-04-2008
		//This function executes the received hashtable of sql statements and executes its items one by one
		//This function is specific for GLI...
		long vNoOfRowsAffected = 0;
		//Dim vCounter As Long
		SqlCommand vSqlCommand = default(SqlCommand);
		SqlTransaction vTrans = default(SqlTransaction);
		try {
			if (pSqlStatmentHashtable.Count == 0) {
				return 0;
			}
			vSqlConn.Open();
			vTrans = vSqlConn.BeginTransaction(IsolationLevel.ReadCommitted);
			IDictionaryEnumerator MyEnum = pSqlStatmentHashtable.GetEnumerator();
			while (MyEnum.MoveNext()==true) {
				vSqlCommand = new SqlCommand(MyEnum.Current.ToString(), vSqlConn);
				vSqlCommand.Transaction = vTrans;
				int vCommandResult = vSqlCommand.ExecuteNonQuery();
				if (vCommandResult == 0) {
					return 0;
				}
				vNoOfRowsAffected = vNoOfRowsAffected + vCommandResult;
			}
			vTrans.Commit();
			vSqlConn.Close();
			return vNoOfRowsAffected;
		} catch (SqlException vex) {
			if (vex.Number == 547) {
				vTrans.Rollback();
				vSqlConn.Close();
				////MessageCenter.fCallMsg("67", null);
			} else if (vex.Number == 2627) {
				vTrans.Rollback();
				vSqlConn.Close();
				////MessageCenter.fCallMsg("68", null);
			} else {
				vTrans.Rollback();
				vSqlConn.Close();
				////cException.sHandleException(vex.Message, pFormName, "cbase.fDMLSystem.Data");
			}
			return -1;
		} catch (Exception ex) {
			vTrans.Rollback();
			vSqlConn.Close();
			//cException.sHandleException(ex.Message, pFormName, "cbase.fDMLSystem.Data");
			return -1;
		} finally {
			if (vSqlConn.State == ConnectionState.Open | vSqlConn.State == ConnectionState.Broken) {
				vSqlConn.Close();
			}
		}
	}
	public static string fReturnScalar(string pSqlStatment, string pFormName)
	{
		//FK 26/4/2005
		//In this function I execute only one command and return single value.
		try {
			SqlCommand vSqlCommand = new SqlCommand(pSqlStatment, vSqlConn);
			string vReturn = null;
			vSqlConn.Open();
			vReturn = vSqlCommand.ExecuteScalar().ToString().Trim();
			vSqlConn.Close();
			return vReturn;
		} catch (SqlException vex) {
			if (vex.Number == 547) {
				vSqlConn.Close();
				//MessageCenter.fCallMsg("66", null);
				//MessageBox.Show("Row can't be updated because of child rows", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign Or MessageBoxOptions.RtlReading Or MessageBoxOptions.RtlReading)
			} else {
				//cException.sHandleException(vex.Message, pFormName, "cbase.fReturnScalar");
			}
			return "-1";
		} catch (Exception ex) {
			vSqlConn.Close();
			//cException.sHandleException(ex.Message, pFormName, "cbase.fReturnScalar");
			return "0";
		} finally {
			if (vSqlConn.State == ConnectionState.Open | vSqlConn.State == ConnectionState.Broken) {
				vSqlConn.Close();
			}
		}
	}
	public static string fReturnNonQuery(string pSqlStatment, string pFormName)
	{
		//FK 26/4/2005
		//In this function I execute only one command and return single value.
		try {
			SqlCommand vSqlCommand = new SqlCommand(pSqlStatment, vSqlConn);
			string vReturn = null;
			vSqlConn.Open();
			vReturn = vSqlCommand.ExecuteNonQuery().ToString().Trim();
			vSqlConn.Close();
			return vReturn;
		} catch (SqlException vex) {
			if (vex.Number == 547) {
				vSqlConn.Close();
				//MessageCenter.fCallMsg("66", null);
				//MessageBox.Show("Row can't be updated because of child rows", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign Or MessageBoxOptions.RtlReading Or MessageBoxOptions.RtlReading)
			} else {
				//cException.sHandleException(vex.Message, pFormName, "cbase.fReturnScalar");
			}
			return "-1";
		} catch (Exception ex) {
			vSqlConn.Close();
			//cException.sHandleException(ex.Message, pFormName, "cbase.fReturnScalar");
			return "0";
		} finally {
			if (vSqlConn.State == ConnectionState.Open | vSqlConn.State == ConnectionState.Broken) {
				vSqlConn.Close();
			}
		}
	}
    public static string Right(string str, int length)
    {
        return str.Substring(str.Length - length);
    }
    public static string Left( string str, int length)
    {
        return str.Substring(0, Math.Min(length, str.Length));
    }
    public static string Mid(string param, int startIndex, int length)
    {
        //start at the specified index in the string ang get N number of
        //characters depending on the lenght and assign it to a variable
        string result = param.Substring(startIndex, length);
        //return the result of the operation
        return result;
    }

    public static string Mid(string param, int startIndex)
    {
        //start at the specified index and return all characters after it
        //and assign it to a variable
        string result = param.Substring(startIndex);
        //return the result of the operation
        return result;
    }
	public static string fFixQuote(string strIn)
	{
		string functionReturnValue = null;
		int y = 0;
		if (strIn.IndexOf( "'") != 0) {
			for (y = 1; y <= strIn.Length; y++) {
				if (Mid(strIn, y, 1) == "'") {
					functionReturnValue = functionReturnValue + "''";
				} else {
					functionReturnValue = functionReturnValue + Mid(strIn, y, 1);
				}
			}
		} else {
			functionReturnValue = strIn;
		}
		return functionReturnValue;
	}
	public static int fCount_Rec(Object pSqlStatment)
	{
		try {
			int vCount_Rec = 0;
			System.Data.SqlClient.SqlCommand vSql_Command = new System.Data.SqlClient.SqlCommand();
			vSql_Command.Connection = vSqlConn;
			vSql_Command.CommandText = " Select Count(*) " + pSqlStatment;
            SqlDataReader Sql_Reader = default(SqlDataReader);
			vSqlConn.Open();
			Sql_Reader = vSql_Command.ExecuteReader();
			while (Sql_Reader.Read()) {
				if (Sql_Reader.IsDBNull(0) == false) {
					vCount_Rec = Sql_Reader.GetInt32(0);
				}
				break; // TODO: might not be correct. Was : Exit Do
			}
			Sql_Reader.Close();
			vSqlConn.Close();
			return vCount_Rec;
		} catch (Exception ex) {
			vSqlConn.Close();
			//cException.sHandleException(ex.Message, "cBase", "fCount_Rec");
			return 0;
		} finally {
			if (vSqlConn.State == ConnectionState.Open | vSqlConn.State == ConnectionState.Broken) {
				vSqlConn.Close();
			}
		}
	}
	


	#endregion
	#region " Get Server DateTime                                                                           "
	public static DateTime fGetCurDateTime()
	{
		//JN 18-05-2005
		//Function To Get Current DateTime From DB Server
		DateTime vCurDateTime = default(DateTime);
        BasicClass vcBase = new BasicClass("BTS");
		try {
			System.Data.SqlClient.SqlCommand vSqlCommand = new System.Data.SqlClient.SqlCommand();
			vSqlCommand.Connection = BasicClass.vSqlConn;
			BasicClass.vSqlConn.Open();
			//Open System.Database Connection.
			vSqlCommand.CommandText = " Select GetDate() ";
			SqlDataReader SqlReader = default(SqlDataReader);
			SqlReader = vSqlCommand.ExecuteReader();
			while (SqlReader.Read()) {
				if (SqlReader.IsDBNull(0) == false) {
					vCurDateTime = Convert.ToDateTime(SqlReader[0]);
				}
			}
		} catch (Exception ex) {
			//cException.sHandleException(ex.Message, "cBase", "fGetCurDateTime");
		} finally {
			if (BasicClass.vSqlConn.State == ConnectionState.Open | BasicClass.vSqlConn.State == ConnectionState.Broken) {
				BasicClass.vSqlConn.Close();
			}
		}
		return vCurDateTime;
	}
	#endregion
	#region " Lock Record                                                                                   "
	public static void sLockRecord(string pTableName, string pWhereClause, string pLockMode)
	{
		//fk 26/5/2005
		//I check for lock record
		try {
			System.Data.SqlClient.SqlCommand vSqlCommand = new System.Data.SqlClient.SqlCommand();
			vSqlCommand.Connection = BasicClass.vSqlConn;
			BasicClass.vSqlConn.Open();
			//Open System.Database Connection.
			if (pTableName.ToString().Trim() == "Y") {
				vSqlCommand.CommandText = " Update " + pTableName.ToString().Trim() + " Set " + "   Lock        ='" + pTableName.ToString().Trim() + "' " + " , ProcessID   ='" + Process.GetCurrentProcess().Id.ToString() + "' " + " , MachineName ='" + System.Environment.MachineName.Trim() + "' " + " Where 1=1 " + pWhereClause;
			} else if (pLockMode.Trim() == "N") {
				vSqlCommand.CommandText = " Update " + pTableName.ToString().Trim() + " Set " + "   Lock        ='" + pTableName.ToString().Trim() + "' " + " , ProcessID   = Null " + " , MachineName = Null " + " Where 1=1 " + pWhereClause;
			}

			vSqlCommand.ExecuteNonQuery();
			BasicClass.vSqlConn.Close();
		} catch (Exception ex) {
			//cException.sHandleException(ex.Message, "cBase", "sLockRecord");
		} finally {
			if (BasicClass.vSqlConn.State == ConnectionState.Open | BasicClass.vSqlConn.State == ConnectionState.Broken) {
				BasicClass.vSqlConn.Close();
			}
		}
	}
	#endregion
    #region " Encrypt / Decrypt                                                                             "
    public static string sEncrypt(string pText)
    {
        return Encrypt(pText, "&%#@?,:*");
    }
    //Decrypt the text 
    public static string sDecrypt(string pText)
    {
        return Decrypt(pText, "&%#@?,:*");
    }
    //The function used to encrypt the text
    private static string Encrypt(string strText, string strEncrKey)
    {
        byte[] byKey = {
			
		};
        byte[] IV = {
			0x12,
			0x34,
			0x56,
			0x78,
			0x90,
			0xab,
			0xcd,
			0xef
		};
        try
        {
            byKey = System.Text.Encoding.UTF8.GetBytes(Left(strEncrKey, 8));
            System.Security.Cryptography.DESCryptoServiceProvider des = new System.Security.Cryptography.DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.UTF8.GetBytes(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Convert.ToBase64String(ms.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    //The function used to decrypt the text
    private static string Decrypt(string strText, string sDecrKey)
    {
        byte[] byKey = {
			
		};
        byte[] IV = {
			0x12,
			0x34,
			0x56,
			0x78,
			0x90,
			0xab,
			0xcd,
			0xef
		};
        byte[] inputByteArray = new byte[strText.Length + 1];

        try
        {
            byKey = System.Text.Encoding.UTF8.GetBytes(Left(sDecrKey, 8));
            DESCryptoServiceProvider des = new DESCryptoServiceProvider();
            inputByteArray = Convert.FromBase64String(strText);
            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            System.Text.Encoding encoding = System.Text.Encoding.UTF8;
            return encoding.GetString(ms.ToArray());
        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
    #endregion
	#region " Collect Statments                                                                             "
	// TD 24-09-2008
	// handels statments arrays
	public static void sEmptySqlStatmentArray()
	{
		//TD 24-09-2008
		//This sub empty the SQL statements array
		vSqlStatment = new string[1];
	}
	public static void sFillSqlStatmentArray(string pStatment)
	{
		//TD 24-09-2008
		//This sub fill the Array to send it to transaction
		if (string.IsNullOrEmpty(vSqlStatment[vSqlStatment.GetUpperBound(0)])) {
			vSqlStatment[vSqlStatment.GetUpperBound(1)] = pStatment;
		} else {
            Array.Resize(ref vSqlStatment, vSqlStatment.GetUpperBound(0) + 2);
            vSqlStatment[vSqlStatment.GetUpperBound(1)] = pStatment;
		}
	}
	#endregion

    public static int fAttachImage(string pImageFileName, string pTableName, string pColumnName, string pWhereCluase, string pFormName)
    {
        //JN 13/4/2005
        //In this Function I Attach an Image To Binary Column
        int vNoOfRowsAffected = default(int);
        SqlCommand vSqlCommand = default(SqlCommand);
        SqlTransaction vTrans = default(SqlTransaction);
        try
        {
            //Create Binary Object With Image 
            System.IO.FileStream vBLOBFile = new System.IO.FileStream(pImageFileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            byte[] vBLOBData = new byte[vBLOBFile.Length];
            vBLOBFile.Read(vBLOBData, 0, vBLOBData.Length);
            vBLOBFile.Close();

            vSqlConn.Open();

            vTrans = vSqlConn.BeginTransaction(IsolationLevel.ReadCommitted);
            vSqlCommand = new SqlCommand(" Update " + pTableName + " Set " + pColumnName + " = @BLOBData " + pWhereCluase, vSqlConn);

            System.Data.SqlClient.SqlParameter vSqlParameter = new System.Data.SqlClient.SqlParameter("@BLOBData", SqlDbType.VarBinary, vBLOBData.Length, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Current, vBLOBData);
            vSqlCommand.Parameters.Add(vSqlParameter);
            vSqlCommand.Transaction = vTrans;
            vNoOfRowsAffected = int.Parse(vNoOfRowsAffected.ToString()) + vSqlCommand.ExecuteNonQuery();
            vTrans.Commit();
            vSqlConn.Close();
            return vNoOfRowsAffected;
        }
        catch (SqlException vex)
        {
            if (vex.Number == 547)
            {
                vTrans.Rollback();
                vSqlConn.Close();
                MessageBox.Show("خطأ فى حفظ البيانات", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
            }
            else
            {
                MessageBox.Show(vex.Message); 
            }
            return -1;
        }
        catch (Exception ex)
        {
            vTrans.Rollback();
            vSqlConn.Close();
            ExceptionHandler.HandleException(ex.Message, pFormName, "cbase.fAttachImage");
            return 0;
        }
        finally
        {
            if (vSqlConn.State == ConnectionState.Open | vSqlConn.State == ConnectionState.Broken)
            {
                vSqlConn.Close();
            }
        }
    }

    //=======================================================
    //Service provided by Telerik (www.telerik.com)
    //Conversion powered by NRefactory.
    //Twitter: @telerik
    //Facebook: facebook.com/telerik
    //=======================================================

}

//=======================================================
//Service provided by Telerik (www.telerik.com)
//Conversion powered by NRefactory.
//Twitter: @telerik
//Facebook: facebook.com/telerik
//=======================================================
