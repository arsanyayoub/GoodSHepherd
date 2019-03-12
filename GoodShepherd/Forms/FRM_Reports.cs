using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using Telerik.WinControls.UI;

namespace MEMN
{
    public partial class FRM_Reports : RadForm
    {
        public FRM_Reports()
        {
            InitializeComponent();
            CMXLoad(ComboCIty, "TBL_City", "id", "CityDesc");
            CMXLoad(CMXCityChurch, "TBL_City", "id", "CityDesc");
            CMXLoad(ComboServices, "TBL_Services","id", "Service");
            CMXLoad(ComboEduc, "TBL_EducationLevel", "id", "EducLevel");
            PickerFormLoad();
            ComboMeeting_Loaded();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Program Files\Microsoft SQL Server\MSSQL13.ME\MSSQL\DATA\GoodShepherd.mdf;Integrated Security=True;Connect Timeout=30");
        SqlDataAdapter DA;
        DataTable DT = new DataTable();
        DataSet DS = new DataSet();
        private void CMXLoad(Infragistics.Win.UltraWinEditors.UltraComboEditor CMXFill,
                     string TableName, string ColumnValue, string ColumnDisplay)
        {
            string query = "select  "+ ColumnValue+","+ ColumnDisplay + " from "+ TableName+" ORDER BY "+ ColumnDisplay + "";
            DA = new SqlDataAdapter(query, Con);
            Con.Open();
            DS = new DataSet();
            DA.Fill(DS, TableName);
            CMXFill.DataSource = DS.Tables[TableName];
            CMXFill.DisplayMember = ColumnDisplay;
            CMXFill.ValueMember = ColumnValue;
            Con.Close(); 
        }
        private void CMXFillValidation(Infragistics.Win.UltraWinEditors.UltraComboEditor CMXFill, Infragistics.Win.UltraWinEditors.UltraComboEditor CMXValidation
                     ,string TableName, string ColumnValue,string ColumnDisplay,string ColumnValidation)
        {
            string query = "select "+ ColumnValue + ","+ ColumnDisplay + " from "+TableName+" where "+ ColumnValidation + "=" + CMXValidation.Value + "  ORDER BY "+ ColumnDisplay + " ";
            DA = new SqlDataAdapter(query, Con);
            Con.Open();
            DS = new DataSet();
            DA.Fill(DS, TableName);
            CMXFill.DataSource = DS.Tables[TableName];
            CMXFill.DisplayMember = ColumnDisplay;
            CMXFill.ValueMember = ColumnValue;
            Con.Close();  
        }
        private void ComboMeeting_Loaded()
        {
            string query = "select Id , Title from TBL_Meetings   ";
            DA = new SqlDataAdapter(query, Con);
            Con.Open();
            DS = new DataSet();
            DA.Fill(DS, " TBL_Meetings");
            ComboMeetingAttend.DataSource = DS.Tables[" TBL_Meetings"];
            ComboMeetingAttend.DisplayMember = "Title";
            ComboMeetingAttend.ValueMember = "Id";
            Con.Close();
        }
        private void PickerFormLoad()
        {
            PickerFromNoAttendMonth.Format = DateTimePickerFormat.Custom;
            PickerFromNoAttendMonth.CustomFormat = "dd/MM/yyyy";
            PickerToNoAttendMonth.Format = DateTimePickerFormat.Custom;
            PickerToNoAttendMonth.CustomFormat = "dd/MM/yyyy";
            PickerFromContinues.Format = DateTimePickerFormat.Custom;
            PickerFromContinues.CustomFormat = "dd/MM/yyyy";
            PickerToContinues.Format = DateTimePickerFormat.Custom;
            PickerToContinues.CustomFormat = "dd/MM/yyyy";
            PickerHighFromContinues.Format = DateTimePickerFormat.Custom;
            PickerHighFromContinues.CustomFormat = "dd/MM/yyyy";
            PickerHighToContinues.Format = DateTimePickerFormat.Custom;
            PickerHighToContinues.CustomFormat = "dd/MM/yyyy";
            PickerNoAttendMonth.Format = DateTimePickerFormat.Custom;
            PickerNoAttendMonth.CustomFormat = "MM/yyyy";
            PckerContinuesMonth.Format = DateTimePickerFormat.Custom;
            PckerContinuesMonth.CustomFormat = "MM/yyyy";
        }
        //------------------------------------------------------
        private void ComboCIty_ValueChanged(object sender, EventArgs e)
        {
            if (ComboCIty.SelectedItem == null)
            {
                CMX_Area.Clear();
                CMX_Area.Items.Clear();
            }
            else CMXFillValidation(CMX_Area, ComboCIty, "TBL_Area", "id", "AreaDesc", "City_id");
        }
        private void ComboArea_ValueChanged(object sender, EventArgs e)
        {
            if (CMX_Area.SelectedItem == null)
            {
                ComboStreet.Clear();
                ComboStreet.Items.Clear();
            }
            else CMXFillValidation(ComboStreet, CMX_Area, "TBL_Street", "id", "StreetDesc", "Area_id");
        }
        private void CMXCityChurch_ValueChanged(object sender, EventArgs e)
        {
            if (CMXCityChurch.SelectedItem == null)
            {
                CMXAreaChurch.Clear();
                CMXAreaChurch.Items.Clear();
            }
            else
            {
                CMXFillValidation(CMXAreaChurch, CMXCityChurch, "TBL_Area", "id", "AreaDesc", "City_id");
                CMXFillValidation(ComboChruch, CMXCityChurch, "TBL_Church", "id", "ChurchName", "City_id");
            }
        }
        private void CMXAreaChurch_ValueChanged(object sender, EventArgs e)
        {
            if (CMXAreaChurch.SelectedItem == null)
            {
                CMXStreetChurch.Clear();
                CMXStreetChurch.Items.Clear();
            }
            else
            {
                CMXFillValidation(CMXStreetChurch, CMXAreaChurch, "TBL_Street", "id", "StreetDesc", "Area_id");
                CMXFillValidation(ComboChruch, CMXAreaChurch, "TBL_Church", "id", "ChurchName", "Area_id");
            }
        }
        private void CMXStreetChurch_ValueChanged(object sender, EventArgs e)
        {
            if (CMXStreetChurch.SelectedItem != null) CMXFillValidation(ComboChruch, CMXStreetChurch, "TBL_Church", "id", "ChurchName", "Street_id");
        }
        private void ComboChruch_ValueChanged(object sender, EventArgs e)
        {
            if (ComboChruch.SelectedItem == null)
            {
                ComboFatherName.Clear();
                ComboFatherName.Items.Clear();
            }
            else
            {
                string query = "select Id , Name from TBL_MainPerson where PersType_ID = 1 and Church_id="+ ComboChruch .Value+ " ORDER BY Name ";
                DA = new SqlDataAdapter(query, Con);
                Con.Open();
                DS = new DataSet();
                DA.Fill(DS, " TBL_MainPerson");
                ComboFatherName.DataSource = DS.Tables[" TBL_MainPerson"];
                ComboFatherName.DisplayMember = "Name";
                ComboFatherName.ValueMember = "Id";
                Con.Close();
            }
        }
        private void ComboEduc_ValueChanged(object sender, EventArgs e)
        {
            if(ComboEduc.SelectedItem==null)
            {
                BtnLoadEduc.Text = "Load all";
            }
            else BtnLoadEduc.Text = "Load";
        }
        //--------------------------------------------------------------
        private void BtnLoadCity_Click(object sender, EventArgs e)
        {
            if (ComboCIty.SelectedItem == null) LblCity.ForeColor = Color.Red;
            else
            {
                LblCity.ForeColor = Color.Black;
                this.vIW_GetPeopleDataTableAdapter.FillByCity(this.goodShepherdDataSet.VIW_GetPeopleData,Convert.ToInt32(ComboCIty.Value));
                ReportAdress.SetDataSource(goodShepherdDataSet);
                ReportAdress.SetParameterValue("Adress","بمحافظة : "+ ComboCIty.Text);
                CR.ReportSource = ReportAdress;
            }
        }
        private void BtnLoadArea_Click(object sender, EventArgs e)
        {
            if (CMX_Area.SelectedItem == null) LBL_Area.ForeColor = Color.Red;
            else
            {
                LBL_Area.ForeColor = Color.Black;
                this.vIW_GetPeopleDataTableAdapter.FillByArea(this.goodShepherdDataSet.VIW_GetPeopleData, Convert.ToInt32(CMX_Area.Value));
                ReportAdress.SetDataSource(goodShepherdDataSet);
                ReportAdress.SetParameterValue("Adress", "بمنطقة : " + CMX_Area.Text);
                CR.ReportSource = ReportAdress;
            }
        }
        private void BtnLoadStreet_Click(object sender, EventArgs e)
        {
            if (ComboStreet.SelectedItem == null) LblStreet.ForeColor = Color.Red;
            else
            {
                LblStreet.ForeColor = Color.Black;
                this.vIW_GetPeopleDataTableAdapter.FillByStreet(this.goodShepherdDataSet.VIW_GetPeopleData, Convert.ToInt32(ComboStreet.Value));
                ReportStreet.SetDataSource(goodShepherdDataSet);
                ReportStreet.SetParameterValue("Adress",  ComboStreet.Text);
                CR.ReportSource = ReportStreet;
            }
        }
        private void BtnLoadFather_Click(object sender, EventArgs e)
        {
            if (ComboFatherName.SelectedItem == null) LblFather.ForeColor = Color.Red;
            else
            {
                LblFather.ForeColor = Color.Black;
                this.vIW_GetPeopleDataTableAdapter.FillByFrPers(this.goodShepherdDataSet.VIW_GetPeopleData, Convert.ToInt32(ComboFatherName.Value));
                ReportChurch.SetDataSource(goodShepherdDataSet);
                ReportChurch.SetParameterValue("Adress", CMXAreaChurch.Text);
                ReportChurch.SetParameterValue("City", CMXCityChurch.Text);
                ReportChurch.SetParameterValue("Church", ComboChruch.Text);
                ReportChurch.SetParameterValue("FRName","أب كاهن :"+ ComboFatherName.Text);
                CR.ReportSource = ReportChurch;
            }
        }
        private void BtnChurch_Click(object sender, EventArgs e)
        {
            if (ComboChruch.SelectedItem == null) LblChurch.ForeColor = Color.Red;
            else
            {
                LblChurch.ForeColor = Color.Black;
                this.vIW_GetPeopleDataTableAdapter.FillByChurch (this.goodShepherdDataSet.VIW_GetPeopleData, Convert.ToInt32(ComboChruch.Value));
                ReportChurch.SetDataSource(goodShepherdDataSet);
                ReportChurch.SetParameterValue("Adress", CMXAreaChurch.Text);
                ReportChurch.SetParameterValue("City", CMXCityChurch.Text);
                ReportChurch.SetParameterValue("Church", ComboChruch.Text);
                ReportChurch.SetParameterValue("FRName", "");
                CR.ReportSource = ReportChurch;
            }
        }
        private void BtnServices_Click(object sender, EventArgs e)
        {
            if (ComboServices.SelectedItem == null) LblServices.ForeColor = Color.Red;
            else
            {
                LblServices.ForeColor = Color.Black;
                this.vIW_GetPeopleDataTableAdapter.FillByService(this.goodShepherdDataSet.VIW_GetPeopleData, Convert.ToInt32(ComboChruch.Value),Convert.ToInt32(ComboServices.Value));
                ReportService.SetDataSource(goodShepherdDataSet);
                ReportService.SetParameterValue("Adress", CMXAreaChurch.Text);
                ReportService.SetParameterValue("City", CMXCityChurch.Text);
                ReportService.SetParameterValue("Church", ComboChruch.Text);
                CR.ReportSource = ReportService;
            }
        }
        private void BtnEduc_Click(object sender, EventArgs e)
        {
            if (ComboEduc.SelectedItem == null) LblEduc.ForeColor = Color.Red;
            else 
            {
            this.vIW_GetPeopleDataTableAdapter.FillByEduc(this.goodShepherdDataSet.VIW_GetPeopleData, Convert.ToInt32(ComboEduc.Value), Convert.ToInt32(ComboChruch.Value));
            ReportEduc.SetDataSource(goodShepherdDataSet);
            ReportEduc.SetParameterValue("Adress", CMXAreaChurch.Text);
            ReportEduc.SetParameterValue("City", CMXCityChurch.Text);
            ReportEduc.SetParameterValue("Church", ComboChruch.Text);
            ReportEduc.SetParameterValue("EducationLevel", ComboEduc.Text);
            CR.ReportSource = ReportEduc;
            }
        }
        private void BtnLoadStatus_Click(object sender, EventArgs e)
        {
            if (ComboStatus.SelectedItem == null) LblStatus.ForeColor = Color.Red;
            else
            {
                LblStatus.ForeColor = Color.Black;
                this.vIW_GetPeopleDataTableAdapter.FillByStatuse(this.goodShepherdDataSet.VIW_GetPeopleData, Convert.ToString(ComboStatus.Value), Convert.ToInt32(ComboChruch.Value));
                ReportStatuse1.SetDataSource(goodShepherdDataSet);
                ReportStatuse1.SetParameterValue("Adress", CMXAreaChurch.Text);
                ReportStatuse1.SetParameterValue("City", CMXCityChurch.Text);
                ReportStatuse1.SetParameterValue("Church", ComboChruch.Text);
                CR.ReportSource = ReportStatuse1;
            }
        }
        private void BtnWork_Click(object sender, EventArgs e)
        {
            if (ComboWork.SelectedItem == null) LblWork.ForeColor = Color.Red;
            else
            {
                LblWork.ForeColor = Color.Black;
                this.vIW_GetPeopleDataTableAdapter.FillByIsWork(this.goodShepherdDataSet.VIW_GetPeopleData, Convert.ToString(ComboWork.Value), Convert.ToInt32(ComboChruch.Value));
                ReportWork1.SetDataSource(goodShepherdDataSet);
                ReportWork1.SetParameterValue("Adress", CMXAreaChurch.Text);
                ReportWork1.SetParameterValue("City", CMXCityChurch.Text);
                ReportWork1.SetParameterValue("Church", ComboChruch.Text);
                CR.ReportSource = ReportWork1;
            }
        }
        private void BtnLoadBirthMonth_Click(object sender, EventArgs e)
        {
            if (ComboBirthMonth.SelectedItem == null) LblBirthMonth.ForeColor = Color.Red;
            else
            {
                LblBirthMonth.ForeColor = Color.Black;
                this.vIW_GetPeopleDataTableAdapter.FillByMonth(this.goodShepherdDataSet.VIW_GetPeopleData, Convert.ToInt32(ComboBirthMonth.Value), Convert.ToInt32(ComboChruch.Value));
                ReportMonth1.SetDataSource(goodShepherdDataSet);
                ReportMonth1.SetParameterValue("Adress", CMXAreaChurch.Text);
                ReportMonth1.SetParameterValue("City", CMXCityChurch.Text);
                ReportMonth1.SetParameterValue("Church", ComboChruch.Text);
                CR.ReportSource = ReportMonth1;
            }
        }

        private void BtnLoadPartBirthMonth_Click(object sender, EventArgs e)
        {
            if (ComboFromBirthMonth.SelectedItem == null && ComboToBirthMonth.SelectedItem==null)
            {
                LblFromBirthMonth.ForeColor = Color.Red;
                LblToBirthMonth.ForeColor = Color.Red;
            }
            else if(ComboFromBirthMonth.SelectedItem == null && ComboToBirthMonth.SelectedItem != null)
            {
                LblFromBirthMonth.ForeColor = Color.Red;
                LblToBirthMonth.ForeColor = Color.Black;
            }
            else if(ComboFromBirthMonth.SelectedItem!= null && ComboToBirthMonth.SelectedItem == null)
            {
                LblFromBirthMonth.ForeColor = Color.Black;
                LblToBirthMonth.ForeColor = Color.Red;
            }
            else
            {
                LblFromBirthMonth.ForeColor = Color.Black;
                LblToBirthMonth.ForeColor = Color.Black;
                this.vIW_GetPeopleDataTableAdapter.FillByPartMonth(this.goodShepherdDataSet.VIW_GetPeopleData, Convert.ToInt32(ComboFromBirthMonth.Value), Convert.ToInt32(ComboToBirthMonth.Value), Convert.ToInt32(ComboChruch.Value));
                ReportMonth1.SetDataSource(goodShepherdDataSet);
                ReportMonth1.SetParameterValue("Adress", CMXAreaChurch.Text);
                ReportMonth1.SetParameterValue("City", CMXCityChurch.Text);
                ReportMonth1.SetParameterValue("Church", ComboChruch.Text);
                CR.ReportSource = ReportMonth1;
            }
        }
        private void BtnLoadAge_Click(object sender, EventArgs e)
        {
            if (NumAge.Value == null) LblAge.ForeColor = Color.Red;
            else
            {
                LblAge.ForeColor = Color.Black;
                this.vIW_GetPeopleDataTableAdapter.FillByAge(this.goodShepherdDataSet.VIW_GetPeopleData,  Convert.ToInt32(NumAge.Value), Convert.ToInt32(ComboChruch.Value));
                ReportMonth1.SetDataSource(goodShepherdDataSet);
                ReportMonth1.SetParameterValue("Adress", CMXAreaChurch.Text);
                ReportMonth1.SetParameterValue("City", CMXCityChurch.Text);
                ReportMonth1.SetParameterValue("Church", ComboChruch.Text);
                CR.ReportSource = ReportMonth1;
            }
        }
        private void BtnLoadPartAge_Click(object sender, EventArgs e)
        {
                LblFromBirthMonth.ForeColor = Color.Black;
                LblToBirthMonth.ForeColor = Color.Black;
                this.vIW_GetPeopleDataTableAdapter.FillByPartAge(this.goodShepherdDataSet.VIW_GetPeopleData, Convert.ToInt32(NumFromAge.Value), Convert.ToInt32(NumToAge.Value), Convert.ToInt32(ComboChruch.Value));
                ReportMonth1.SetDataSource(goodShepherdDataSet);
                ReportMonth1.SetParameterValue("Adress", CMXAreaChurch.Text);
                ReportMonth1.SetParameterValue("City", CMXCityChurch.Text);
                ReportMonth1.SetParameterValue("Church", ComboChruch.Text);
                CR.ReportSource = ReportMonth1;
        }
        private void BtnLoadNoAttendMonth_Click(object sender, EventArgs e)
        {
            if (PickerNoAttendMonth.Text == "") LblNoAttendMonth.ForeColor = Color.Red;
            else
            {
                LblNoAttendMonth.ForeColor = Color.Black;
                MessageBox.Show("Load Month Attend");
            }
        }

        private void BtnLoadPartNoAttendMonth_Click(object sender, EventArgs e)
        {
            if (PickerFromNoAttendMonth.Text == "" && PickerToNoAttendMonth.Text == "")
            {
                LblFromNoAttendMonth.ForeColor = Color.Red;
                LblToNoAttendMonth.ForeColor = Color.Red;
            }
            else if (PickerFromNoAttendMonth.Text == "" && PickerToNoAttendMonth.Text != "")
            {
                LblFromNoAttendMonth.ForeColor = Color.Red;
                LblToNoAttendMonth.ForeColor = Color.Black;
            }
            else if (PickerFromNoAttendMonth.Text != "" && PickerToNoAttendMonth.Text == "")
            {
                LblFromNoAttendMonth.ForeColor = Color.Black;
                LblToNoAttendMonth.ForeColor = Color.Red;
            }
            else
            {
                LblFromNoAttendMonth.ForeColor = Color.Black;
                LblToNoAttendMonth.ForeColor = Color.Black;
                MessageBox.Show("Load No Attend Month");
            }
        }
        private void BtnLoadContinuesMonth_Click(object sender, EventArgs e)
        {
            if (PckerContinuesMonth.Text == "") LblContinuesMonth.ForeColor = Color.Red;
            else
            {
                LblContinuesMonth.ForeColor = Color.Black;
                MessageBox.Show("Load Contiunes Month");
            }
        }
        private void BtnPartContinuesMonth_Click(object sender, EventArgs e)
        {
            if (PickerFromContinues.Text == "" && PickerToContinues.Text == "")
            {
                LblFromContinues.ForeColor = Color.Red;
                LblToContinues.ForeColor = Color.Red;
            }
            else if (PickerFromContinues.Text == "" && PickerToContinues.Text != "")
            {
                LblFromContinues.ForeColor = Color.Red;
                LblToContinues.ForeColor = Color.Black;
            }
            else if (PickerFromContinues.Text != "" && PickerToContinues.Text == "")
            {
                LblFromContinues.ForeColor = Color.Black;
                LblToContinues.ForeColor = Color.Red;
            }
            else
            {
                LblFromContinues.ForeColor = Color.Black;
                LblToContinues.ForeColor = Color.Black;
                MessageBox.Show("Load Contiunes Month");
            }
        }
        private void BtnHighContinues_Click(object sender, EventArgs e)
        {
            if (PickerHighFromContinues.Text == "" && PickerHighToContinues.Text == "")
            {
                LblHighFromContinues.ForeColor = Color.Red;
                LblHighToContinues.ForeColor = Color.Red;
            }
            else if (PickerHighFromContinues.Text == "" && PickerHighToContinues.Text != "")
            {
                LblHighFromContinues.ForeColor = Color.Red;
                LblHighToContinues.ForeColor = Color.Black;
            }
            else if (PickerHighFromContinues.Text != "" && PickerHighToContinues.Text == "")
            {
                LblHighFromContinues.ForeColor = Color.Black;
                LblHighToContinues.ForeColor = Color.Red;
            }
            else
            {
                LblHighFromContinues.ForeColor = Color.Black;
                LblHighToContinues.ForeColor = Color.Black;
                MessageBox.Show("Load Contiunes Part Month");
            }
        }
        private void BtnLoadMeetingAttend_Click(object sender, EventArgs e)
        {
            if (ComboMeetingAttend.SelectedItem == null) LblMeetingAttend.ForeColor = Color.Red;
            else
            {
                LblMeetingAttend.ForeColor = Color.Black;
                MessageBox.Show("Load meeting attend");
            }
        }
        private void BtnLoadHighAttend_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Load Attend");
        }
        private void FRM_Reports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'goodShepherdDataSet.VIW_GetPeopleData' table. You can move, or remove it, as needed.
        }
    }
}
