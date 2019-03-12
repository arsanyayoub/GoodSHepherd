using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Collections;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;

namespace GoodShepherd.Forms
{
    public partial class FRM_reportViewer : RadForm
    {
        public FRM_reportViewer(SortedList pSqlCommand, DataSet pDataSet, ReportClass pReport)
        {
           
            InitializeComponent();
            try
            {
                System.Data.SqlClient.SqlDataAdapter vSqlDataAdapter = new System.Data.SqlClient.SqlDataAdapter();
                IDictionaryEnumerator vEnum = pSqlCommand.GetEnumerator();
                DataSet vReportDs = new DataSet();
                while (vEnum.MoveNext())
                {
                    vSqlDataAdapter.SelectCommand = (SqlCommand)vEnum.Value;
                    vSqlDataAdapter.SelectCommand.Connection = BasicClass.vSqlConn;
                    string vTableName = "";
                    vTableName = vEnum.Key.ToString();
                    DataTable vTable = new DataTable();
                    // vTable = vReportDs.Tables[vTableName];


                    if (vTable != null)
                    {
                        vTable.Clear();
                    }

                    vTable.TableName = vTableName;
                    vSqlDataAdapter.Fill(vTable);
                    vReportDs.Tables.Add(vTable);
                }
                pReport.SetDataSource(vReportDs);
                crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
                crystalReportViewer1.ReportSource = pReport;
                crystalReportViewer1.Refresh();
                //crystalReportViewer1.ReportSource = pReport;
            }
            catch (Exception ex)
            {

                ExceptionHandler.HandleException(ex.Message, this.Name, "FRM_reportViewer");
            }
        }

       
    }


}
