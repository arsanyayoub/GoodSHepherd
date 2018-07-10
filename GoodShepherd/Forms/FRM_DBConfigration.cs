using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using Microsoft.SqlServer;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System.Data.SqlClient;
using System.Data.Sql;


namespace GoodShepherd
{
    public partial class FRM_DBConfiguration : Form
    {
        public FRM_DBConfiguration()
        {
            InitializeComponent();
        }

        
#region  Varibales Declaration on Form Level                                                       
public cFrmLevelVariable vcFrmLevelVariable = new cFrmLevelVariable();
public bool vSuccess;
public string vConnection;
public object vMDIForm;
public string vRegKey ="BTS";
	// NG 18-1-2009
bool vGetStr;

#endregion
#region  Form Level                                                                               
public bool fTestConnection(bool pReturnMsg = true)
{
	try {
		Microsoft.SqlServer.Management.Common.ServerConnection vConn = new Microsoft.SqlServer.Management.Common.ServerConnection(TXT_ServerName.Text, TXT_Login.Text, TXT_Password.Text);
		Microsoft.SqlServer.Management.Smo.Server vServer = new Microsoft.SqlServer.Management.Smo.Server(vConn);
		vConn.Connect();
		if (pReturnMsg) {
			if (System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "ar") {
				MessageBox.Show("تم اختبار الوصله بنجاح", "??????");
			} else if (System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "en") {
				MessageBox.Show("Test connection succeeded", "Test");
			}
		}
		return true;
	} catch (Exception ex) {
		MessageBox.Show(ex.Message, "Error");
		return false;
	}
}
public void sFillListAvailableSQLServers()
{
   
    //DataTable a = default(DataTable);
    //DataRow vRow = default(DataRow);
    //SmoApplication oSQLApp = default(SmoApplication);
    //oSQLApp = new SmoApplication();
    //a = oSQLApp.EnumAvailableSqlServers;
    //foreach ( vRow  in a.Rows) {
    //    TXT_ServerName.Items.Add(vRow(0));
    //}

    System.Data.Sql.SqlDataSourceEnumerator instance =
   System.Data.Sql.SqlDataSourceEnumerator.Instance;
    System.Data.DataTable dataTable = instance.GetDataSources();  
    string myServer = Environment.MachineName;

    //DataTable servers = SqlDataSourceEnumerator.Instance.GetDataSources();
    for (int i = 0; i < dataTable.Rows.Count; i++)
    {
        if (myServer == dataTable.Rows[i]["ServerName"].ToString()) ///// used to get the servers in the local machine////
        {
            if ((dataTable.Rows[i]["InstanceName"] as string) != null)
                TXT_ServerName.Items.Add(dataTable.Rows[i]["ServerName"] + "\\" + dataTable.Rows[i]["InstanceName"]);
            else
                TXT_ServerName.Items.Add(dataTable.Rows[i]["ServerName"]);
        }
    }
}
public void sFillListAvailableDatabasesSqlAuth(string pServerName, string pLogIn = "", string pPassword = "")
{
	try {
		Microsoft.SqlServer.Management.Common.ServerConnection vConn = new Microsoft.SqlServer.Management.Common.ServerConnection(pServerName, pLogIn, pPassword);
		Microsoft.SqlServer.Management.Smo.Server vServer = new Microsoft.SqlServer.Management.Smo.Server(vConn);
		vConn.Connect();
     
        foreach (Database vDB2 in vServer.Databases)
	{
		 TXT_Database.Items.Add(vDB2.Name);
	}
	} catch (Exception vEx) {
		return;
	}
}
private void FRM_DBConfigMgr_Load(object sender, System.EventArgs e)
{
	vcFrmLevelVariable.vSystem = "GN";
	vcFrmLevelVariable.vModule = "FRM_DBConfigMgr";
	object vMdi = null;
	if ((BasicClass.vSqlConn != null)) {
	}
	vcFrmLevelVariable.vParentFrm = vMdi;
	sFillListAvailableSQLServers();
	TXT_Login.ReadOnly = true;
	TXT_Password.ReadOnly = true;
    //TXT_Database.ReadOnly = false;
}
#endregion
#region " Master Navigation Block                                                                   "
private void TXT_ServerName_SelectionChanged(object sender, System.EventArgs e)
{
	
	if (RDB_WinAuth.Checked=true) {
        //this.TXT_Database.ReadOnly = false;
	} else {
		if (TXT_Database.SelectedIndex == -1) {
            //this.TXT_Database.ReadOnly = true;
		} else {
            //this.TXT_Database.ReadOnly = false;
		}
		TXT_Login.ReadOnly = false;
		TXT_Password.ReadOnly = false;
	}
}
private void TXT_Login_TextChanged(object sender, System.EventArgs e)
{
	if (this.TXT_Database.Enabled == true) {
		this.TXT_Database.Enabled = false;
		this.TXT_Database.Update();
	}
}

private void TXT_Database_Enter(object sender, System.EventArgs e)
{
	sFillListAvailableDatabasesSqlAuth(this.TXT_ServerName.Text, TXT_Login.Text, TXT_Password.Text);
}
#endregion
#region " Save Connection String In registry                                                        "
public void sSaveConnection()
{

	Microsoft.Win32.RegistryKey vRegVer = default(Microsoft.Win32.RegistryKey);
	string vPath = null;
	vPath = "SOFTWARE\\ProVision";
	vRegVer = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(vPath);
	if (fTestConnection(false) == false) {
		return;
	} else {
		vSuccess = true;
	}
	if (TXT_TimeOut.Value == 0) {
		TXT_TimeOut.Value = 15;
	}
	if (RDB_SQLAuth.Checked=true) {
		// In Case of Sql Authentication
        vConnection = "data source=" + TXT_ServerName.Text + ";initial catalog=" + TXT_Database.Text + ";user id=" + TXT_Login.Text + " ;password=" + TXT_Password.Text + ";Connect Timeout=" + TXT_TimeOut.Value;
	} else {
		// In Case of Windows Authentication
        vConnection = "data source=" + TXT_ServerName.Text + ";initial catalog=" + TXT_Database.Text + ";Integrated Security=SSPI;";
	}
	BasicClass.vConectionString = vConnection;
    string vEncryptedConnection =  BasicClass.sEncrypt(vConnection);
	Microsoft.Win32.Registry.LocalMachine.CreateSubKey(vPath).SetValue(vRegKey, vEncryptedConnection);
	if (System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "ar") {
		MessageBox.Show("تم الحفظ بنجاح", "Cofiguration");
	} else if (System.Threading.Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "en") {
        MessageBox.Show("Configuration is saved successfully", "Cofiguration");
	}

}
public object fGetConnectionStr()
{
	object functionReturnValue = null;
	//NG 18-1-2009
	//to get string only
	string RetStr = "";
	if (vGetStr == true) {
		if (fTestConnection(false) == false) {
			return functionReturnValue;
		} else {
			vSuccess = true;
		}
		if (TXT_TimeOut.Value == 0) {
			TXT_TimeOut.Value = 15;
		}
		if (RDB_SQLAuth.Checked =true) {
			// In Case of Sql Authentication
            vConnection = "data source=" + TXT_ServerName.Text + ";initial catalog=" + TXT_Database.Text + ";user id=" + TXT_Login.Text + " ;password=" + TXT_Password.Text + ";Connect Timeout=" + TXT_TimeOut.Value;
		} else {
			// In Case of Windows Authentication
            vConnection = "data source=" + TXT_ServerName.Text + ";initial catalog=" + TXT_Database.Text + ";Integrated Security=SSPI;";
		}
        string vEncryptedConnection =  BasicClass.sEncrypt(vConnection);
		RetStr = vEncryptedConnection;

	}
	return RetStr;
	return functionReturnValue;
}
#endregion

private void BTN_Test_Click(object sender, EventArgs e)
{
    fTestConnection();
}

private void BTN_Select_Click(object sender, EventArgs e)
{
    if (fTestConnection() == false)
    {
        return;
    }
    //NG 18-1-2009
    //modified
    if (vGetStr == true)
    {
        object connectionStr = fGetConnectionStr();
    }
    else
    {
        sSaveConnection();
    }

    this.Close();
    if ((BasicClass.vSqlConn != null))
    {
    }
}

private void BTN_Cancel_Click(object sender, EventArgs e)
{
    this.Close();
}

private void RDB_WinAuth_CheckedChanged(object sender, EventArgs e)
{
    TXT_Login.Text = "";
    TXT_Password.Text = "";
    TXT_Login.ReadOnly = true;
    TXT_Password.ReadOnly = true;
    TXT_Database.Enabled = false;
}

private void RDB_SQLAuth_CheckedChanged(object sender, EventArgs e)
{
    TXT_Login.Text = "";
    TXT_Password.Text = "";
    TXT_Login.ReadOnly = false;
    TXT_Password.ReadOnly = false;
    TXT_Database.Enabled = true;
}

    }
}
