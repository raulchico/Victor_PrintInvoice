using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Test2
{

    public partial class Form1 : Form
    {
        int lastRow1, lastRow2, lastRow3, lastRow4;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'DSInv.DataTable1' table. You can move, or remove it, as needed.
            this.DataTable1TableAdapter.Fill(this.DSInv.DataTable1, dateTimePicker1.Value.Date);



        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            this.DataTable1TableAdapter.Fill(this.DSInv.DataTable1, dateTimePicker1.Value.Date);
            reportViewer1.Visible = true;
            this.reportViewer1.RefreshReport();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            reportViewer1.Visible = true;
            DataTable PivotData = createPivot(dateTimePicker1.Value.Date);



            this.reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Test2.Delivery2.rdlc";

            this.reportViewer1.LocalReport.DataSources.Clear();


            Microsoft.Reporting.WinForms.ReportDataSource DataSet1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", PivotData);

            this.reportViewer1.LocalReport.DataSources.Add(DataSet1);

            var setup = reportViewer1.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            reportViewer1.SetPageSettings(setup);


            this.reportViewer1.RefreshReport();


        }
        public DataTable createPivot(DateTime dateReport)
        {
            lastRow1 = lastRow2 = lastRow3 = lastRow4 = 0;
            //this.DataTable1TableAdapter.Fill(this.DSInv.DataTable1, dateTimePicker1.Value.Date);
            this.DataTable1TableAdapter.Fill(this.DSInv.DataTable1, dateReport);
            DataTable pivot = new DataTable();
            DataTable cloneTab = this.DSInv.DataTable1.Copy();
            cloneTab.Columns.Add("Column_No", typeof(String));
            cloneTab.Columns.Add("Key", typeof(String));
            cloneTab.Columns.Add("Extra", typeof(String));
            cloneTab.Columns.Add("Qty", typeof(String));
            cloneTab.Columns.Add("UM", typeof(String));

            foreach (DataRow dr in cloneTab.Rows)
            {
                string extra = "";
                if (dr["Extra1"].ToString().Length > 0)
                {
                    extra = "<b>" + dr["Extra1"].ToString().Substring(0, dr["Extra1"].ToString().IndexOf(" ") + 2).ToUpper() + "</b>";
                    dr["Qty"] = dr["Extra1"].ToString().Substring(0, dr["Extra1"].ToString().IndexOf(" ") );
                    dr["UM"] = dr["Extra1"].ToString().Substring(dr["Extra1"].ToString().IndexOf(" ") + 1, 1);
                }
                else
                {
                    extra = "<b>0 X</b>";
                    dr["Qty"] = "0";
                    dr["UM"] = "X";
                }
                dr["Key"] = dr["Description"].ToString();// +extra;
                dr["Extra"] = extra;

                if (dr["ProductCatID"].ToString() == "BF")
                    dr["Column_No"] = "3";
                if (dr["ProductCatID"].ToString() == "OTH")
                    dr["Column_No"] = "4";
                if (dr["ProductCatID"].ToString() == "CHK")
                    dr["Column_No"] = "1";
                if (dr["ProductCatID"].ToString() == "PK")
                    dr["Column_No"] = "2";
            }
            //createCSV createfile = new createCSV();
            //string fileName = @"C:\ProgramData\Invoiceit!Pro52\cloneTab.csv";
            //createfile.printCSV_fullProcess(fileName, cloneTab, "", "N");

            DataRow[] resultNoRoute = cloneTab.Select("ShipMethod is null");

            //DataRow[] resultNoRoute = myDataSet.Tables["DataInvoices"].Select("ShipMethod is null");
            //if (resultNoRoute.Count() != 0)
            //{

            string prevRoute = "";
            var distinctCust = (from row in cloneTab.AsEnumerable()
                                select row.Field<string>("Cname")).Distinct();
            var distinctRoute = (from row in cloneTab.AsEnumerable()
                                 select row.Field<string>("ShipMethod")).Distinct();



            //pivot.Columns.Add("ShipMethod", typeof(String));
            pivot.Columns.Add("Customer", typeof(String));
            pivot.Columns.Add("Class1", typeof(String));

            pivot.Columns.Add("Class2", typeof(String));

            pivot.Columns.Add("Class3", typeof(String));

            pivot.Columns.Add("Class4", typeof(String));

            pivot.Columns.Add("Class1q", typeof(String));
            pivot.Columns.Add("Class2q", typeof(String));
            pivot.Columns.Add("Class3q", typeof(String));
            pivot.Columns.Add("Class4q", typeof(String));

            //pivot.Rows.Add("Customer", "BEE", "OTH", "CHK", "POR");

            foreach (var Route in distinctRoute)
            {

                foreach (var name in distinctCust)
                {
                    if (String.IsNullOrEmpty(Route))
                    {
                        if (prevRoute != Route)
                        {
                            pivot.Rows.Add("<b> No Route </b>", "", "", "", "");
                            pivot.Rows.Add("Customer", "CHK", "PK", "BF", "OTH");
                            prevRoute = Route;
                        }
                        DataRow pnewRow = pivot.NewRow();
                        DataRow[] result = cloneTab.Select("ShipMethod is null and Cname = '" + name + "'");
                        //pnewRow[0] = Route;
                        pnewRow[0] = name;
                        int countRecs = 0;
                        foreach (DataRow dr in result)
                        {
                            int coll = Convert.ToInt16(dr["Column_No"].ToString());
                            pnewRow[coll] = pnewRow[coll] + "~" + dr["key"].ToString();  // +"</tr>";
                            countRecs++;
                        }
                        if (countRecs > 0)
                            pivot.Rows.Add(pnewRow);
                    }
                    else
                    {
                        if (prevRoute != Route)
                        {
                            pivot.Rows.Add("<b>" + Route + "</b>", "", "", "", "");
                            pivot.Rows.Add("Customer", "CHK", "PK", "BF", "OTH");
                            prevRoute = Route;
                        }
                        DataRow pnewRow = pivot.NewRow();
                        DataRow[] result = cloneTab.Select("ShipMethod = '" + Route + "' and Cname = '" + name + "'");
                        //pnewRow[0] = Route;
                        pnewRow[0] = name;
                        int countRecs = 0;
                        foreach (DataRow dr in result)
                        {
                            int coll = Convert.ToInt16(dr["Column_No"].ToString());
                            pnewRow[coll] = pnewRow[coll] + "<p>" + dr["key"].ToString(); //  +"</tr>";
                            pnewRow[coll + 4] = pnewRow[coll + 4] + "<p>" + dr["Extra"].ToString();
                            countRecs++;
                        }
                        if (countRecs > 0)
                            pivot.Rows.Add(pnewRow);
                    }
                }

            }

            pivot.Columns[5].SetOrdinal(2);
            pivot.Columns[6].SetOrdinal(4);
            pivot.Columns[7].SetOrdinal(6);
            string bk_column,bk_key, bk_extra, bk_letter;
            bk_column = bk_key = bk_extra = bk_letter = string.Empty;
            int totgroup = 0;
            string totExtraInitial = "";
            DataTable pivotSummary = pivot.Clone();

            cloneTab.DefaultView.Sort = "Column_No, key, Extra";

            DataView view = cloneTab.DefaultView;

            for (int i = 0; i < view.Count ; i++)
            {
                string[] words = view[i][18].ToString().Replace("<b>", "").Replace("</b>", "").Split(' ');
                if (words[0] == "")
                {
                    string newitem = "";
                    words[0] = "0";
                    words = (words ?? Enumerable.Empty<string>()).Concat(new[] { newitem }).ToArray();
                }


                if (view[i][16].ToString() == bk_column)
                {
                    if (view[i][17].ToString() == bk_key)
                    {
                        
                        if (words[1].ToString() == bk_extra)
                        {
                            int totLine = Convert.ToInt16(words[0].ToString());
                            totgroup = totgroup + totLine;

                        }
                        else
                        {
                            //int totLine = Convert.ToInt16(words[0].ToString());
                            addRowSummary(bk_column, bk_key, totgroup, bk_letter, pivotSummary);
                            bk_extra = words[1].ToString(); // view[i][18].ToString();
                            bk_column = view[i][16].ToString();
                            bk_key = view[i][17].ToString();
                            bk_letter = words[1];
                            totgroup = Convert.ToInt16(words[0].ToString());
                        }
                    }
                    else
                    {  //no same key (product) 
                        addRowSummary(bk_column, bk_key, totgroup, bk_letter, pivotSummary);
                        bk_extra = words[1].ToString(); //view[i][18].ToString();
                        bk_column = view[i][16].ToString();
                        bk_key = view[i][17].ToString();
                        bk_letter = words[1];
                        totgroup = Convert.ToInt16(words[0].ToString()); 
                    }

                }
                else
                {// diff column
                   //int totLine = Convert.ToInt16(words[0].ToString());
                    addRowSummary(bk_column, bk_key, totgroup, bk_letter, pivotSummary);
                    bk_extra = words[1].ToString(); //view[i][18].ToString();
                    bk_column = view[i][16].ToString();
                    bk_key = view[i][17].ToString();
                    bk_letter = words[1];
                    totgroup = Convert.ToInt16(words[0].ToString());
                }

                if (i == view.Count -1)
                    addRowSummary(bk_column, bk_key, totgroup, bk_letter, pivotSummary);
            }
            //fileName = @"C:\ProgramData\Invoiceit!Pro52\pivotSummary.csv";
            // createfile.printCSV_fullProcess(fileName, pivotSummary, "", "N");

            pivot.Rows.Add("", "<b>=============</b>", "", "", "");
            pivot.Merge(pivotSummary);

            return pivot;
        }

        public void addRowSummary(string bk_column, string bk_key, int totgroup, string bk_letter, DataTable pivotSummary)
        {
            // var tempo = "";
            //if(bk_key =="Bacon (Pack)")
            //    tempo = "";
            if (bk_column.Length > 0)
            {
                if(bk_column == "1")
                {
                    var rowS = pivotSummary.NewRow();
                    rowS[1] = bk_key;
                    rowS[2] = totgroup + " " + bk_letter;
                    lastRow1++;
                    pivotSummary.Rows.Add(rowS);
                }
                if (bk_column == "2")
                {
                    if (lastRow1 > lastRow2)
                    {
                        pivotSummary.Rows[lastRow2][3]= bk_key;
                        pivotSummary.Rows[lastRow2][4] = totgroup + " " + bk_letter;
                        lastRow2++;

                    }
                    else
                    {
                        var rowS = pivotSummary.NewRow();
                        rowS[3] = bk_key;
                        rowS[4] = totgroup + " " + bk_letter;
                        lastRow2++;
                        pivotSummary.Rows.Add(rowS);
                        lastRow1++;
                    }
      
                }
                if (bk_column == "3")
                {
                    if (lastRow1 > lastRow3 )
                    {
                        pivotSummary.Rows[lastRow3][5] = bk_key;
                        pivotSummary.Rows[lastRow3][6] = totgroup + " " + bk_letter;
                        lastRow3++;
                        
                    }
                    else
                    {
                        var rowS = pivotSummary.NewRow();
                        rowS[5] = bk_key;
                        rowS[6] = totgroup + " " + bk_letter;
                        lastRow3++;
                        pivotSummary.Rows.Add(rowS);
                        lastRow1++;
                    }

                }
             
                if (bk_column == "4")
                {
                    if (lastRow1 > lastRow4 )
                    {
                        pivotSummary.Rows[lastRow4][7] = bk_key;
                        pivotSummary.Rows[lastRow4][8] = totgroup + " " + bk_letter;
                        lastRow4++;
                    }
                    else
                    {
                        var rowS = pivotSummary.NewRow();
                        rowS[7] = bk_key;
                        rowS[8] = totgroup + " " + bk_letter;
                        lastRow4++;
                        pivotSummary.Rows.Add(rowS);
                        lastRow1++;
                    }

                }
                
            
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView2.Visible = false;
             this.dataTable3TableAdapter.Fill(this.DSInv.DataTable3, dateTimePicker1.Value.Date);
             reportViewer1.Visible = false;

             dataGridView1.Refresh();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView2.Visible = true;
            dataGridView1.Visible = false;
            reportViewer1.Visible = false;



            this.dataTable5TableAdapter.Fill(this.DSInv.DataTable5, dateTimePicker1.Value.Date, dateTimePicker1.Value.Date, dateTimePicker1.Value.Date);
            

            reportViewer1.Visible = false;
            dataGridView2.Refresh();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            reportViewer1.Visible = true;
            DataTable PivotData = createPivotOrder(dateTimePicker1.Value.Date);



            this.reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Test2.OrderList.rdlc";

            this.reportViewer1.LocalReport.DataSources.Clear();


            Microsoft.Reporting.WinForms.ReportDataSource DataSet1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", PivotData);

            this.reportViewer1.LocalReport.DataSources.Add(DataSet1);

            var setup = reportViewer1.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            reportViewer1.SetPageSettings(setup);


            this.reportViewer1.RefreshReport();
        }
        public DataTable createPivotOrder(DateTime dateReport)
        {
            lastRow1 = lastRow2 = lastRow3 = lastRow4 = 0;
            //this.DataTable1TableAdapter.Fill(this.DSInv.DataTable1, dateTimePicker1.Value.Date);
            this.DataTable1TableAdapter.Fill(this.DSInv.DataTable1, dateReport);
            DataTable pivot1 = new DataTable();
            DataTable pivot4 = new DataTable();
            DataTable pivot = new DataTable();
            DataTable cloneTab = this.DSInv.DataTable1.Copy();
            cloneTab.Columns.Add("Column_No", typeof(String));
            cloneTab.Columns.Add("Key", typeof(String));
            cloneTab.Columns.Add("Extra", typeof(String));
            cloneTab.Columns.Add("Qty", typeof(String));
            cloneTab.Columns.Add("UM", typeof(String));

            foreach (DataRow dr in cloneTab.Rows)
            {
                string extra = "";
                if (dr["Extra1"].ToString().Length > 0)
                {
                    extra = dr["Extra1"].ToString().Substring(0, dr["Extra1"].ToString().IndexOf(" ") + 2).ToUpper();
                    dr["Qty"] = dr["Extra1"].ToString().Substring(0, dr["Extra1"].ToString().IndexOf(" "));
                    dr["UM"] = dr["Extra1"].ToString().Substring(dr["Extra1"].ToString().IndexOf(" ") + 1, 1);
                }
                else
                {
                    extra = "0 X";
                    dr["Qty"] = "0";
                    dr["UM"] = "X";
                }
                dr["Key"] = dr["Description"].ToString();// +extra;
                dr["Extra"] = extra;

                if (dr["ProductCatID"].ToString() == "BF")
                    dr["Column_No"] = "1";
                if (dr["ProductCatID"].ToString() == "OTH")
                    dr["Column_No"] = "4";
                if (dr["ProductCatID"].ToString() == "CHK")
                    dr["Column_No"] = "4";
                if (dr["ProductCatID"].ToString() == "PK")
                    dr["Column_No"] = "1";
            }
            createCSV createfile = new createCSV();
            string fileName = @"C:\ProgramData\Invoiceit!Pro52\cloneTab.csv";
            createfile.printCSV_fullProcess(fileName, cloneTab, "", "N");

            DataRow[] resultNoRoute = cloneTab.Select("ShipMethod is null");

            //DataRow[] resultNoRoute = myDataSet.Tables["DataInvoices"].Select("ShipMethod is null");
            //if (resultNoRoute.Count() != 0)
            //{

            string prevCol = "";
            string PrevProd = "";
         
            var distinctProd = (from row in cloneTab.AsEnumerable()
                                 select row.Field<string>("Key")).Distinct();



            //pivot.Columns.Add("ShipMethod", typeof(String));
            pivot.Columns.Add("Prod1", typeof(String));
            pivot.Columns.Add("Qty1", typeof(String));
            pivot.Columns.Add("Detail1", typeof(String));
            pivot.Columns.Add("Prod2", typeof(String));
            pivot.Columns.Add("Qty2", typeof(String));
            pivot.Columns.Add("Detail2", typeof(String));

            pivot1.Columns.Add("Prod1", typeof(String));
            pivot1.Columns.Add("Qty1", typeof(String));
            pivot1.Columns.Add("Detail1", typeof(String));
            pivot4.Columns.Add("Prod2", typeof(String));
            pivot4.Columns.Add("Qty2", typeof(String));
            pivot4.Columns.Add("Detail2", typeof(String));




            //pivot.Rows.Add("<b>Order Listg</b>", "", "", "", "", "");
            //pivot.Rows.Add("Beef, Pork", "Qty", "Detail", "Chicken, Others", "Qty", "Detail");


            string wDetail = "";
            string wProd = "";
            string wQty = "";
            string wUM = "";
            int col1Row = 0;
            int col4Ropw = 0;
            int wColumn = 0;
           
               
                foreach (var Prod in distinctProd)
                {
                   
                    {
                        if (PrevProd != Prod)
                        {
                            //pivot.Rows.Add("<b>Order Listg</b>", "", "", "", "", "");
                            //pivot.Rows.Add("Beef, Pork", "Qty", "Detail", "Chicken, Others", "Qty", "Detail");
                            PrevProd = Prod;
                        }
                        DataRow pnewRow = pivot.NewRow();
                        string sortOrder = "UM ASC";
                        //string wwProd = Prod.Replace("'", "");
                        //string thisCharacter = wwProd.Substring(7, 1);
                        DataRow[] result = cloneTab.Select("Key = '" + Prod.Replace("'", "") + "'", sortOrder);
                        //pnewRow[0] = Route;
                        pnewRow[0] = "name";
                        int countRecs = 0;
                        int totUM = 0; 
                        string wExtra1 = "";
                        foreach (DataRow dr in result)
                        {
                            
                            if (wExtra1 != dr["key"].ToString())
                            {
                                wColumn = Convert.ToInt16(dr["Column_No"].ToString());
                                if (wDetail != "")
                                {
                                    if (wColumn == 1)
                                    {
                                        DataRow newRow = pivot1.NewRow();
                                        newRow[0] = Prod; newRow[1] = dr["key"].ToString(); newRow[2] = wDetail.Substring(0, wDetail.Length - 2);
                                        pivot1.Rows.Add(newRow);
                                        wExtra1 = dr["key"].ToString();
                                        wDetail = "";
                                        totUM = Convert.ToInt16(dr["qty"].ToString());
                                        wDetail = wDetail + dr["Extra"].ToString() + ", ";
                                        col1Row++;
                                    }
                                    else
                                    {
                                        DataRow newRow = pivot4.NewRow();
                                        newRow[0] = Prod; newRow[1] = dr["key"].ToString(); newRow[2] = wDetail.Substring(0, wDetail.Length - 2);
                                        pivot4.Rows.Add(newRow); wExtra1 = dr["key"].ToString();
                                        wDetail = "";
                                        totUM = Convert.ToInt16(dr["qty"].ToString());
                                        wDetail = wDetail + dr["Extra"].ToString() + ", ";
                                        col4Ropw++;
                                    }
                                }
                                else
                                {
                                    wDetail = ""; 
                                    wExtra1 = dr["key"].ToString();
                                    wDetail = wDetail + dr["Extra"].ToString() + ", ";
                                    totUM = totUM + Convert.ToInt16(dr["qty"].ToString()); 
                                }
                                wUM = dr["UM"].ToString().ToUpper();
                                countRecs = 0;
                            }
                            else
                            {
                                if (wUM == dr["UM"].ToString().ToUpper())
                                {
                                    //int coll = Convert.ToInt16(dr["Column_No"].ToString());
                                    totUM = totUM + Convert.ToInt16(dr["qty"].ToString()); 
                                    wDetail = wDetail + dr["Extra"].ToString() + ", ";
                                }
                                else
                                {
                                    if (wColumn == 1)
                                    {
                                        DataRow newRow = pivot1.NewRow();
                                        newRow[0] = Prod;
                                        newRow[1] = totUM + " " + wUM;
                                        newRow[2] = wDetail.Substring(0, wDetail.Length - 2);
                                        pivot1.Rows.Add(newRow);
                                        wExtra1 = dr["key"].ToString();
                                        wDetail = "";

                                        wUM = dr["UM"].ToString().ToUpper();
                                        totUM = Convert.ToInt16(dr["qty"].ToString());
                                        wDetail = wDetail + dr["Extra"].ToString() + ", ";
                                        countRecs = 0;
                                    }
                                    else 
                                    {
                                        DataRow newRow = pivot4.NewRow();
                                        newRow[0] = Prod;
                                        newRow[1] = totUM + " " + wUM;
                                        newRow[2] = wDetail.Substring(0, wDetail.Length - 2);
                                        pivot4.Rows.Add(newRow);
                                        wExtra1 = dr["key"].ToString();
                                        wDetail = "";

                                        wUM = dr["UM"].ToString().ToUpper();
                                        totUM = Convert.ToInt16(dr["qty"].ToString());
                                        wDetail = wDetail + dr["Extra"].ToString() + ", ";
                                        countRecs = 0;
                                    }

                                }
                                //pnewRow[coll] = pnewRow[coll] + "<p>" + dr["key"].ToString(); //  +"</tr>";
                                //pnewRow[coll + 4] = pnewRow[coll + 4] + "<p>" + dr["Extra"].ToString();
                            }
                            countRecs++;
                        }
                        if (countRecs > 0)
                        {
                            if (wColumn == 1)
                            {
                                DataRow newRow = pivot1.NewRow();
                                newRow[0] = Prod;
                                newRow[1] = totUM + " " + wUM;
                                newRow[2] = wDetail.Substring(0,wDetail.Length - 2);
                                pivot1.Rows.Add(newRow);
                            }
                            else
                            {
                                DataRow newRow = pivot4.NewRow();
                                newRow[0] = Prod;
                                newRow[1] = totUM + " " + wUM;
                                newRow[2] = wDetail.Substring(0, wDetail.Length - 2);
                                pivot4.Rows.Add(newRow);
                            }
                            wExtra1 = "";
                            wDetail = "";

                            wUM = "";
                            totUM = 0;
                        }
                            //pivot.Rows.Add(pnewRow);
                    }
                }

                foreach (DataRow row in pivot1.Rows)
                {
                    DataRow newRow = pivot.NewRow();
                    newRow[0] = row[0];
                    newRow[1] = row[1];
                    newRow[2] = row[2];
                    pivot.Rows.Add(newRow);
                }
                int xrows4 = pivot1.Rows.Count - 1;
                int currRow4 = 0;
                foreach (DataRow row in pivot4.Rows)
                {
                    if (currRow4 > xrows4)
                    {
                    DataRow newRow = pivot.NewRow();
                    newRow[3] = row[0];
                    newRow[4] = row[1];
                    newRow[5] = row[2];
                    pivot.Rows.Add(newRow);
                    }
                    else
                    {
                        pivot.Rows[currRow4][3] = row[0];
                        pivot.Rows[currRow4][4] = row[1];
                        pivot.Rows[currRow4][5] = row[2];
                        currRow4++;
                    }
                }
            
            

            return pivot;
        }

        public DataTable createPivotWsheet(DateTime dateReport)
        {
            lastRow1 = lastRow2 = lastRow3 = lastRow4 = 0;
            //this.DataTable1TableAdapter.Fill(this.DSInv.DataTable1, dateTimePicker1.Value.Date);
            this.DataTable1TableAdapter.Fill(this.DSInv.DataTable1, dateReport);
            DataTable pivot1 = new DataTable();
            DataTable pivot4 = new DataTable();
            DataTable pivot = new DataTable();
            DataTable cloneTab = this.DSInv.DataTable1.Copy();
            cloneTab.Columns.Add("Column_No", typeof(String));
            cloneTab.Columns.Add("Key", typeof(String));
            cloneTab.Columns.Add("Extra", typeof(String));
            cloneTab.Columns.Add("Qty", typeof(String));
            cloneTab.Columns.Add("UM", typeof(String));

            foreach (DataRow dr in cloneTab.Rows)
            {
                string extra = "";
                if (dr["Extra1"].ToString().Length > 0)
                {
                    extra = dr["Extra1"].ToString().Substring(0, dr["Extra1"].ToString().IndexOf(" ") + 2).ToUpper();
                    dr["Qty"] = dr["Extra1"].ToString().Substring(0, dr["Extra1"].ToString().IndexOf(" "));
                    dr["UM"] = dr["Extra1"].ToString().Substring(dr["Extra1"].ToString().IndexOf(" ") + 1, dr["Extra1"].ToString().Length - (dr["Qty"].ToString().Length + 1));
                        //dr["Extra1"].ToString().Substring(dr["Extra1"].ToString().IndexOf(" ") + 1, 1);
                }
                else
                {
                    extra = "0 X";
                    dr["Qty"] = "0";
                    dr["UM"] = "X";
                }
                dr["Key"] = dr["Description"].ToString();// +extra;
                dr["Extra"] = extra;

                if (dr["ProductCatID"].ToString() == "BF")
                    dr["Column_No"] = "1";
                if (dr["ProductCatID"].ToString() == "OTH")
                    dr["Column_No"] = "1";
                if (dr["ProductCatID"].ToString() == "CHK")
                    dr["Column_No"] = "1";
                if (dr["ProductCatID"].ToString() == "PK")
                    dr["Column_No"] = "1";
            }
         

            string prevCol = "";
            string PrevProd = "";

            var distinctProd = (from row in cloneTab.AsEnumerable()
                                select row.Field<string>("Key")).Distinct();



            //pivot.Columns.Add("ShipMethod", typeof(String));
            pivot.Columns.Add("Prod1", typeof(String));
            pivot.Columns.Add("Qty1", typeof(String));
            pivot.Columns.Add("Unit", typeof(String));
            pivot.Columns.Add("Detail1", typeof(String));
           



            //pivot.Rows.Add("<b>Order Listg</b>", "", "", "", "", "");
            //pivot.Rows.Add("Beef, Pork", "Qty", "Detail", "Chicken, Others", "Qty", "Detail");


            string wDetail = "";
            string wProd = "";
            string wQty = "";
            string wUM = "";
            int col1Row = 0;
            int col4Ropw = 0;
            int wColumn = 0;


            foreach (var Prod in distinctProd)
            {

                {
                    if (PrevProd != Prod)
                    {
                        //pivot.Rows.Add("<b>Order Listg</b>", "", "", "", "", "");
                        //pivot.Rows.Add("Beef, Pork", "Qty", "Detail", "Chicken, Others", "Qty", "Detail");
                        PrevProd = Prod;
                    }
                    DataRow pnewRow = pivot.NewRow();
                    string sortOrder = "UM ASC";
                    //string wwProd = Prod.Replace("'", "");
                    //string thisCharacter = wwProd.Substring(7, 1);
                    DataRow[] result = cloneTab.Select("Key = '" + Prod.Replace("'", "") + "'", sortOrder);
                    //pnewRow[0] = Route;
                    pnewRow[0] = "name";
                    int countRecs = 0;
                    int totUM = 0;
                    string wExtra1 = "";
                    foreach (DataRow dr in result)
                    {

                        if (wExtra1 != dr["key"].ToString())
                        {
                            wColumn = Convert.ToInt16(dr["Column_No"].ToString());
                            if (wDetail != "")
                            {
                              
                                    DataRow newRow = pivot.NewRow();
                                    //newRow[0] = Prod; newRow[1] = dr["key"].ToString(); newRow[2] = wDetail.Substring(0, wDetail.Length - 2);
                                    newRow[0] = Prod;
                                    newRow[1] = totUM;
                                    newRow[2] = wUM;
                                    newRow[3] = wDetail.Substring(0, wDetail.Length - 2);
                                    pivot.Rows.Add(newRow);
                                    wExtra1 = dr["key"].ToString();
                                    wDetail = "";
                                    totUM = Convert.ToInt16(dr["qty"].ToString());
                                    wDetail = wDetail + dr["Extra"].ToString() + ", ";
                                    col1Row++;
                               
                            }
                            else
                            {
                                wDetail = "";
                                wExtra1 = dr["key"].ToString();
                                wDetail = wDetail + dr["Extra"].ToString() + ", ";
                                totUM = totUM + Convert.ToInt16(dr["qty"].ToString());
                            }
                            wUM = dr["UM"].ToString().ToUpper();
                            countRecs = 0;
                        }
                        else
                        {
                            if (wUM == dr["UM"].ToString().ToUpper())
                            {
                                //int coll = Convert.ToInt16(dr["Column_No"].ToString());
                                totUM = totUM + Convert.ToInt16(dr["qty"].ToString());
                                wDetail = wDetail + dr["Extra"].ToString() + ", ";
                            }
                            else
                            {
                               
                                    DataRow newRow = pivot.NewRow();
                                    newRow[0] = Prod;
                                    newRow[1] = totUM ;
                                    newRow[2] = wUM;
                                    newRow[3] = wDetail.Substring(0, wDetail.Length - 2);
                                    pivot.Rows.Add(newRow);
                                    wExtra1 = dr["key"].ToString();
                                    wDetail = "";

                                    wUM = dr["UM"].ToString().ToUpper();
                                    totUM = Convert.ToInt16(dr["qty"].ToString());
                                    wDetail = wDetail + dr["Extra"].ToString() + ", ";
                                    countRecs = 0;
                                
                            }
                            //pnewRow[coll] = pnewRow[coll] + "<p>" + dr["key"].ToString(); //  +"</tr>";
                            //pnewRow[coll + 4] = pnewRow[coll + 4] + "<p>" + dr["Extra"].ToString();
                        }
                        countRecs++;
                    }
                    if (countRecs > 0)
                    {
                        
                            DataRow newRow = pivot.NewRow();
                            newRow[0] = Prod;
                            newRow[1] = totUM;
                            newRow[2] = wUM;
                            newRow[3] = wDetail.Substring(0, wDetail.Length - 2);
                            pivot.Rows.Add(newRow);
                        
                        wExtra1 = "";
                        wDetail = "";

                        wUM = "";
                        totUM = 0;
                    }
                    //pivot.Rows.Add(pnewRow);
                }
            }

            


            return pivot;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = false;
            dataGridView2.Visible = false;
            reportViewer1.Visible = true;
            DataTable PivotData = createPivotWsheet(dateTimePicker1.Value.Date);



            this.reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.Reset();
            reportViewer1.LocalReport.ReportEmbeddedResource = "Test2.WorkSheet.rdlc";

            this.reportViewer1.LocalReport.DataSources.Clear();


            Microsoft.Reporting.WinForms.ReportDataSource DataSet1 = new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", PivotData);

            this.reportViewer1.LocalReport.DataSources.Add(DataSet1);

            var setup = reportViewer1.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            reportViewer1.SetPageSettings(setup);


            this.reportViewer1.RefreshReport();
        }

       
    }

  

    //to create datasource for report  DO NOT DELETE
    public class PivotOrderList
    {
        private string _Prod1;
        public string Prod1
        {
            get { return _Prod1; }
            set { _Prod1 = value; }
        }

        private string _Qty1;
        public string Qty1
        {
            get { return _Qty1; }
            set { _Qty1 = value; }
        }

        private string _Detail1;
        public string Detail1
        {
            get { return _Detail1; }
            set { _Detail1 = value; }
        }



        private string _Prod2;
        public string Prod2
        {
            get { return _Prod2; }
            set { _Prod2 = value; }
        }

        private string _Qty2;
        public string Qty2
        {
            get { return _Qty2; }
            set { _Qty2 = value; }
        }

        private string _Detail2;
        public string Detail2
        {
            get { return _Detail2; }
            set { _Detail2 = value; }
        }
        public PivotOrderList(string Prod1, string Qty1, string Detail1, string Prod2, string Qty2, string Detail2)
        {

            _Prod1 = Prod1;
            _Qty1 = Qty1;
            _Detail1 = Detail1;
            _Prod2 = Prod2;
            _Qty2 = Qty2;
            _Detail2 = Detail2;

        }
    }
    public class PivotWSheet
    {
        private string _Prod1;
        public string Prod1
        {
            get { return _Prod1; }
            set { _Prod1 = value; }
        }

        private string _Qty1;
        public string Qty1
        {
            get { return _Qty1; }
            set { _Qty1 = value; }
        }

        private string _Detail1;
        public string Detail1
        {
            get { return _Detail1; }
            set { _Detail1 = value; }
        }



        private string _Unit;
        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }


        public PivotWSheet(string Prod1, string Qty1, string Unit, string Detail1 )
        {

            _Prod1 = Prod1;
            _Qty1 = Qty1;
            _Unit = Unit;
            _Detail1 = Detail1;

        }
    }
    public class PivotT
    {
        private string _ShipMethod;
        public string ShipMethod
        {
            get { return _ShipMethod; }
            set { _ShipMethod = value; }
        }
        private string _Customer;
        public string Customer
        {
            get { return _Customer; }
            set { _Customer = value; }
        }

        private string _Class1;
        public string Class1
        {
            get { return _Class1; }
            set { _Class1 = value; }
        }

        private string _Class2;
        public string Class2
        {
            get { return _Class2; }
            set { _Class2 = value; }
        }

        private string _Class3;
        public string Class3
        {
            get { return _Class3; }
            set { _Class3 = value; }
        }

        private string _Class4;
        public string Class4
        {
            get { return _Class4; }
            set { _Class4 = value; }
        }
        
        private string _Class1q;
        public string Class1q
        {
            get { return _Class1q; }
            set { _Class1q = value; }
        }

        private string _Class2q;
        public string Class2q
        {
            get { return _Class2q; }
            set { _Class2q = value; }
        }

        private string _Class3q;
        public string Class3q
        {
            get { return _Class3q; }
            set { _Class3q = value; }
        }

        private string _Class4q;
        public string Class4q
        {
            get { return _Class4q; }
            set { _Class4q = value; }
        }
        public PivotT(string ShipMethod, string Customer,
               string Class1, string Class2, string Class3, string Class4,string Class1q, string Class2q, string Class3q, string Class4q)
        {
            // _PurchaseDate = Convert.ToDateTime(purchaseDate);
           // _ShipMethod = ShipMethod;
            _Customer = Customer;
            _Class1 = Class1;
            _Class1q = Class1q;
            _Class2 = Class2;
            _Class2q = Class2q;
            _Class3 = Class3;
            _Class3q = Class3q;
            _Class4 = Class4;
            _Class4q = Class4q;
        }
        
    }

     //pivot.Rows.Add("ShipMethod", "Customer", "BEE", "OTH", "CHK", "POR");

     //       foreach (var Route in distinctRoute)
     //       {

     //           foreach (var name in distinctCust)
     //           {
     //               if (String.IsNullOrEmpty(Route))
     //               {
     //                   DataRow pnewRow = pivot.NewRow();
     //                   DataRow[] result = cloneTab.Select("ShipMethod is null and Cname = '" + name + "'");
     //                   pnewRow[0] = Route;
     //                   pnewRow[1] = name;
     //                   int countRecs = 0;
     //                   foreach (DataRow dr in result)
     //                   {
     //                       int coll = Convert.ToInt16(dr["Column_No"].ToString());
     //                       pnewRow[coll + 1] = pnewRow[coll + 1] + "~" + dr["key"].ToString();  // +"</tr>";
     //                       countRecs++;
     //                   }
     //                   if (countRecs > 0)
     //                       pivot.Rows.Add(pnewRow);
     //               }
     //               else
     //               {
     //                   DataRow pnewRow = pivot.NewRow();
     //                   DataRow[] result = cloneTab.Select("ShipMethod = '" + Route + "' and Cname = '" + name + "'");
     //                   pnewRow[0] = Route;
     //                   pnewRow[1] = name;
     //                   int countRecs = 0;
     //                   foreach (DataRow dr in result)
     //                   {
     //                       int coll = Convert.ToInt16(dr["Column_No"].ToString());
     //                       pnewRow[coll + 1] = pnewRow[coll + 1] +  "~" + dr["key"].ToString() ; //  +"</tr>";
     //                       countRecs++;
     //                   }
     //                   if (countRecs > 0)
     //                       pivot.Rows.Add(pnewRow);
     //               }
     //           }

     //       }
   
}
