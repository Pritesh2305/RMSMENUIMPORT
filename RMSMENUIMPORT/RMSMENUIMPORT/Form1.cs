using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RMSMENUIMPORT
{
    public partial class Form1 : Form
    {
        private clsmssqldbfunction mssql = new clsmssqldbfunction();

        public static string sheetnm = "Sheet1";

        public Form1()
        {
            InitializeComponent();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();  //create openfileDialog Object
                openFileDialog1.Filter = "XML Files (*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb) |*.xml; *.xls; *.xlsx; *.xlsm; *.xlsb";//open file format define Excel Files(.xls)|*.xls| Excel Files(.xlsx)|*.xlsx| 
                openFileDialog1.FilterIndex = 3;
                openFileDialog1.Multiselect = false;
                openFileDialog1.Title = "Open Text File-R13";   //define the name of openfileDialog
                openFileDialog1.InitialDirectory = Path.Combine(Application.StartupPath, @"DEMO");

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string pathName = openFileDialog1.FileName;
                    this.txtexcelfilepath.Text = pathName;

                    string fileName = System.IO.Path.GetFileNameWithoutExtension(openFileDialog1.FileName);
                    DataTable tbContainer = new DataTable();
                    string strConn = string.Empty;
                    string sheetName = fileName;

                    FileInfo file = new FileInfo(pathName);
                    if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }
                    string extension = file.Extension;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " Error occures in btnbakupbrows_Click())", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnshow_Click(object sender, EventArgs e)
        {

            string pathName = "";
            string fileName = "";
            DataSet ds1 = new DataSet();

            try
            {

                pathName = this.txtexcelfilepath.Text.Trim();
                fileName = System.IO.Path.GetFileNameWithoutExtension(pathName);

                if (fileName.Trim() == "")
                {
                    throw new Exception("Please Select Menu file.");
                }

                FileInfo file = new FileInfo(pathName);
                if (!file.Exists) { throw new Exception("Error, file doesn't exists!"); }

                ds1 = this.Import(pathName, false);
                this.dtgdata.DataSource = ds1.Tables[0];
                this.dtgdata.Refresh();

                if (ds1.Tables[0].Rows.Count > 0)
                {
                    this.btnimport.Visible = true;
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString() + " Error occures in btnbakupbrows_Click())", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.txtexcelfilepath.Text = "";
            this.btnimport.Visible = false;
            this.ClearDatagrid();
        }


        public DataSet Import(string filename, bool headers = true)
        {
            var _xl = new Microsoft.Office.Interop.Excel.Application();
            var wb = _xl.Workbooks.Open(filename);
            var sheets = wb.Sheets;
            DataSet dataSet = null;

            try
            {
                if (sheets != null && sheets.Count != 0)
                {
                    dataSet = new DataSet();
                    foreach (var item in sheets)
                    {
                        var sheet = (Microsoft.Office.Interop.Excel.Worksheet)item;
                        DataTable dt = null;
                        if (sheet != null)
                        {
                            dt = new DataTable();
                            var ColumnCount = ((Microsoft.Office.Interop.Excel.Range)sheet.UsedRange.Rows[1, Type.Missing]).Columns.Count;
                            var rowCount = ((Microsoft.Office.Interop.Excel.Range)sheet.UsedRange.Columns[1, Type.Missing]).Rows.Count;

                            for (int j = 0; j < ColumnCount; j++)
                            {
                                var cell = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[1, j + 1];
                                var column = new DataColumn(headers ? cell.Value : string.Empty);
                                dt.Columns.Add(column);
                            }

                            for (int i = 0; i < rowCount; i++)
                            {
                                var r = dt.NewRow();
                                for (int j = 0; j < ColumnCount; j++)
                                {
                                    var cell = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[i + 1 + (headers ? 1 : 0), j + 1];
                                    r[j] = cell.Value;
                                }
                                dt.Rows.Add(r);
                            }

                        }
                        dataSet.Tables.Add(dt);
                    }
                }
                _xl.Quit();
                return dataSet;
            }
            catch (Exception)
            {
                return dataSet;
            }
        }

        private void btnimport_Click(object sender, EventArgs e)
        {
            string sqlinsert = "";            
            StringBuilder duplicateiteminfo = new StringBuilder("");
            try
            {
                if (!mssql.OpenMsSqlConnection())
                {
                    MessageBox.Show("Please Check Your Connection");
                }

                DataTable dt =   mssql.DataGridView2DataTable(this.dtgdata, "");
                DataTable dticode = new DataTable();

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        mssql.OpenMsSqlConnection();

                        string icode1= item["column1"] + "".Trim();
                        string strchq = "SELECT ICODE FROM MSTITEM WHERE ISNULL(DELFLG,0)=0 AND ICODE = '" + icode1 + "'";

                        dticode = mssql.FillDataTable(strchq, "MSTITEM");

                        if (dticode.Rows.Count <= 0)
                        {
                            sqlinsert = "INSERT INTO MSTITEM (ICODE,INAME,IRATE,IGRPRID,DELFLG,ADATETIME,IPNAME,ISHIDEITEM) values (@ICODE,@INAME,@IRATE,@IGRPRID,@DELFLG,@ADATETIME,@IPNAME,@ISHIDEITEM)";

                            if (item["column2"] + "".Trim() != "")                            {

                                SqlCommand cmd = new SqlCommand(sqlinsert, clsmssqldbfunction.mssqlcon);

                                cmd.Parameters.Add("@ICODE", SqlDbType.VarChar);
                                cmd.Parameters["@ICODE"].Value = item["column1"] + "".Trim();

                                cmd.Parameters.Add("@INAME", SqlDbType.VarChar);
                                cmd.Parameters["@INAME"].Value = item["column2"] + "".Trim();

                                cmd.Parameters.Add("@IRATE", SqlDbType.Decimal);
                                decimal rate1;
                                decimal.TryParse(item["column3"] + "", out rate1);
                                cmd.Parameters["@IRATE"].Value = rate1;

                                cmd.Parameters.Add("@IGRPRID", SqlDbType.Int);
                                int igrprid1;
                                int.TryParse(item["column4"] + "", out igrprid1);
                                cmd.Parameters["@IGRPRID"].Value = igrprid1;                             
                                
                                cmd.Parameters.Add("@DELFLG", SqlDbType.Bit);
                                cmd.Parameters["@DELFLG"].Value = 0;

                                cmd.Parameters.Add("@ADATETIME", SqlDbType.DateTime);
                                cmd.Parameters["@ADATETIME"].Value = DateTime.Now;

                                cmd.Parameters.Add("@IPNAME", SqlDbType.VarChar);
                                cmd.Parameters["@IPNAME"].Value = item["column2"] + "".Trim();

                                cmd.Parameters.Add("@ISHIDEITEM", SqlDbType.Int);
                                cmd.Parameters["@ISHIDEITEM"].Value = 0;

                                cmd.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            duplicateiteminfo.Append(icode1 + ",");
                        }
                    }

                    MessageBox.Show("IMPORT SUCESSFULLY. " + System.Environment.NewLine + "WITH FOLLOWING INFORMATION." + System.Environment.NewLine + " * DUPLICATE CODE FOUND : " + duplicateiteminfo +" WHICH IS NOT IMPORTED.");

                    this.Form1_Load(sender, e);
                }

            }
            catch (Exception ex)
            { }
            finally
            {
                mssql.CloseMsSqlConnection();
            }
        }

        private bool ClearDatagrid()
        {
            try
            {
                this.dtgdata.DataSource = null;
                this.dtgdata.Refresh();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        private bool Checkconnection()
        {
            try
            {

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete the All Item ?.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                mssql.OpenMsSqlConnection();
                string str1 = "DELETE FROM MSTITEM";
                mssql.ExecuteMsSqlCommand_NoMsg(str1);
                MessageBox.Show("Delete Sucessfully");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Delete the All Group ?.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                mssql.OpenMsSqlConnection();
                string str1 = "DELETE FROM MSTITEMGROUP";
                mssql.ExecuteMsSqlCommand_NoMsg(str1);
                MessageBox.Show("Delete Sucessfully");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to Hide All Item ?.", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (dialogResult == DialogResult.Yes)
            {
                mssql.OpenMsSqlConnection();
                string str1 = "update mstitem set ISHIDEITEM = 1";
                mssql.ExecuteMsSqlCommand_NoMsg(str1);
                MessageBox.Show("Sucessfully");
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            this.Form1_Load(sender, e);

        }
    }
}
