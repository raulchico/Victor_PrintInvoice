namespace Test2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button4 = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.PivotTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DSInv = new Test2.DSInv();
            this.dSInvBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.invoiceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipMethodDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCatIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extra1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delAdd1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delAdd2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSZDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricePerUnitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataTable3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataTable1TableAdapter = new Test2.DSInvTableAdapters.DataTable1TableAdapter();
            this.dataTable3TableAdapter = new Test2.DSInvTableAdapters.DataTable3TableAdapter();
            this.dataTable5BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataTable5TableAdapter = new Test2.DSInvTableAdapters.DataTable5TableAdapter();
            this.invoiceIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productCatIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.invoiceDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shipIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extra1DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pricePerUnitDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delAdd1DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delAdd2DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSZDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PivotTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSInv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInvBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable5BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Test2.Invoice.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 110);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1496, 678);
            this.reportViewer1.TabIndex = 0;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy/MM/dd";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(62, 29);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(349, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Invoices";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(452, 66);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Delivery List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(187, 66);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "List Inv";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoiceIDDataGridViewTextBoxColumn,
            this.customerIDDataGridViewTextBoxColumn,
            this.cNameDataGridViewTextBoxColumn,
            this.shipMethodDataGridViewTextBoxColumn,
            this.productCatIDDataGridViewTextBoxColumn,
            this.invoiceDateDataGridViewTextBoxColumn,
            this.shipIDDataGridViewTextBoxColumn,
            this.productIDDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.extra1DataGridViewTextBoxColumn,
            this.delAdd1DataGridViewTextBoxColumn,
            this.delAdd2DataGridViewTextBoxColumn,
            this.cSZDataGridViewTextBoxColumn,
            this.pricePerUnitDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.dataTable3BindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(37, 110);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1462, 633);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(62, 66);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 6;
            this.button4.Text = "Test";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.invoiceIDDataGridViewTextBoxColumn1,
            this.customerIDDataGridViewTextBoxColumn1,
            this.cNameDataGridViewTextBoxColumn1,
            this.productCatIDDataGridViewTextBoxColumn1,
            this.invoiceDateDataGridViewTextBoxColumn1,
            this.shipIDDataGridViewTextBoxColumn1,
            this.productIDDataGridViewTextBoxColumn1,
            this.descriptionDataGridViewTextBoxColumn1,
            this.extra1DataGridViewTextBoxColumn1,
            this.pricePerUnitDataGridViewTextBoxColumn1,
            this.delAdd1DataGridViewTextBoxColumn1,
            this.delAdd2DataGridViewTextBoxColumn1,
            this.cSZDataGridViewTextBoxColumn1});
            this.dataGridView2.DataSource = this.dataTable5BindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(3, 110);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(1507, 666);
            this.dataGridView2.TabIndex = 7;
            this.dataGridView2.Visible = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(555, 66);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "Order List";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(654, 66);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "Work Sheet";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.DSInv;
            // 
            // DSInv
            // 
            this.DSInv.DataSetName = "DSInv";
            this.DSInv.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dSInvBindingSource
            // 
            this.dSInvBindingSource.DataSource = this.DSInv;
            this.dSInvBindingSource.Position = 0;
            // 
            // invoiceIDDataGridViewTextBoxColumn
            // 
            this.invoiceIDDataGridViewTextBoxColumn.DataPropertyName = "InvoiceID";
            this.invoiceIDDataGridViewTextBoxColumn.HeaderText = "InvoiceID";
            this.invoiceIDDataGridViewTextBoxColumn.Name = "invoiceIDDataGridViewTextBoxColumn";
            // 
            // customerIDDataGridViewTextBoxColumn
            // 
            this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.HeaderText = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
            // 
            // cNameDataGridViewTextBoxColumn
            // 
            this.cNameDataGridViewTextBoxColumn.DataPropertyName = "CName";
            this.cNameDataGridViewTextBoxColumn.HeaderText = "CName";
            this.cNameDataGridViewTextBoxColumn.Name = "cNameDataGridViewTextBoxColumn";
            // 
            // shipMethodDataGridViewTextBoxColumn
            // 
            this.shipMethodDataGridViewTextBoxColumn.DataPropertyName = "ShipMethod";
            this.shipMethodDataGridViewTextBoxColumn.HeaderText = "ShipMethod";
            this.shipMethodDataGridViewTextBoxColumn.Name = "shipMethodDataGridViewTextBoxColumn";
            // 
            // productCatIDDataGridViewTextBoxColumn
            // 
            this.productCatIDDataGridViewTextBoxColumn.DataPropertyName = "ProductCatID";
            this.productCatIDDataGridViewTextBoxColumn.HeaderText = "ProductCatID";
            this.productCatIDDataGridViewTextBoxColumn.Name = "productCatIDDataGridViewTextBoxColumn";
            // 
            // invoiceDateDataGridViewTextBoxColumn
            // 
            this.invoiceDateDataGridViewTextBoxColumn.DataPropertyName = "InvoiceDate";
            this.invoiceDateDataGridViewTextBoxColumn.HeaderText = "InvoiceDate";
            this.invoiceDateDataGridViewTextBoxColumn.Name = "invoiceDateDataGridViewTextBoxColumn";
            // 
            // shipIDDataGridViewTextBoxColumn
            // 
            this.shipIDDataGridViewTextBoxColumn.DataPropertyName = "ShipID";
            this.shipIDDataGridViewTextBoxColumn.HeaderText = "ShipID";
            this.shipIDDataGridViewTextBoxColumn.Name = "shipIDDataGridViewTextBoxColumn";
            // 
            // productIDDataGridViewTextBoxColumn
            // 
            this.productIDDataGridViewTextBoxColumn.DataPropertyName = "ProductID";
            this.productIDDataGridViewTextBoxColumn.HeaderText = "ProductID";
            this.productIDDataGridViewTextBoxColumn.Name = "productIDDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // extra1DataGridViewTextBoxColumn
            // 
            this.extra1DataGridViewTextBoxColumn.DataPropertyName = "Extra1";
            this.extra1DataGridViewTextBoxColumn.HeaderText = "Extra1";
            this.extra1DataGridViewTextBoxColumn.Name = "extra1DataGridViewTextBoxColumn";
            // 
            // delAdd1DataGridViewTextBoxColumn
            // 
            this.delAdd1DataGridViewTextBoxColumn.DataPropertyName = "DelAdd1";
            this.delAdd1DataGridViewTextBoxColumn.HeaderText = "DelAdd1";
            this.delAdd1DataGridViewTextBoxColumn.Name = "delAdd1DataGridViewTextBoxColumn";
            // 
            // delAdd2DataGridViewTextBoxColumn
            // 
            this.delAdd2DataGridViewTextBoxColumn.DataPropertyName = "DelAdd2";
            this.delAdd2DataGridViewTextBoxColumn.HeaderText = "DelAdd2";
            this.delAdd2DataGridViewTextBoxColumn.Name = "delAdd2DataGridViewTextBoxColumn";
            // 
            // cSZDataGridViewTextBoxColumn
            // 
            this.cSZDataGridViewTextBoxColumn.DataPropertyName = "CSZ";
            this.cSZDataGridViewTextBoxColumn.HeaderText = "CSZ";
            this.cSZDataGridViewTextBoxColumn.Name = "cSZDataGridViewTextBoxColumn";
            this.cSZDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pricePerUnitDataGridViewTextBoxColumn
            // 
            this.pricePerUnitDataGridViewTextBoxColumn.DataPropertyName = "PricePerUnit";
            this.pricePerUnitDataGridViewTextBoxColumn.HeaderText = "PricePerUnit";
            this.pricePerUnitDataGridViewTextBoxColumn.Name = "pricePerUnitDataGridViewTextBoxColumn";
            // 
            // dataTable3BindingSource
            // 
            this.dataTable3BindingSource.DataMember = "DataTable3";
            this.dataTable3BindingSource.DataSource = this.DSInv;
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // dataTable3TableAdapter
            // 
            this.dataTable3TableAdapter.ClearBeforeFill = true;
            // 
            // dataTable5BindingSource
            // 
            this.dataTable5BindingSource.DataMember = "DataTable5";
            this.dataTable5BindingSource.DataSource = this.dSInvBindingSource;
            // 
            // dataTable5TableAdapter
            // 
            this.dataTable5TableAdapter.ClearBeforeFill = true;
            // 
            // invoiceIDDataGridViewTextBoxColumn1
            // 
            this.invoiceIDDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceID";
            this.invoiceIDDataGridViewTextBoxColumn1.HeaderText = "InvoiceID";
            this.invoiceIDDataGridViewTextBoxColumn1.Name = "invoiceIDDataGridViewTextBoxColumn1";
            // 
            // customerIDDataGridViewTextBoxColumn1
            // 
            this.customerIDDataGridViewTextBoxColumn1.DataPropertyName = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn1.HeaderText = "CustomerID";
            this.customerIDDataGridViewTextBoxColumn1.Name = "customerIDDataGridViewTextBoxColumn1";
            // 
            // cNameDataGridViewTextBoxColumn1
            // 
            this.cNameDataGridViewTextBoxColumn1.DataPropertyName = "CName";
            this.cNameDataGridViewTextBoxColumn1.HeaderText = "CName";
            this.cNameDataGridViewTextBoxColumn1.Name = "cNameDataGridViewTextBoxColumn1";
            // 
            // productCatIDDataGridViewTextBoxColumn1
            // 
            this.productCatIDDataGridViewTextBoxColumn1.DataPropertyName = "ProductCatID";
            this.productCatIDDataGridViewTextBoxColumn1.HeaderText = "ProductCatID";
            this.productCatIDDataGridViewTextBoxColumn1.Name = "productCatIDDataGridViewTextBoxColumn1";
            // 
            // invoiceDateDataGridViewTextBoxColumn1
            // 
            this.invoiceDateDataGridViewTextBoxColumn1.DataPropertyName = "InvoiceDate";
            this.invoiceDateDataGridViewTextBoxColumn1.HeaderText = "InvoiceDate";
            this.invoiceDateDataGridViewTextBoxColumn1.Name = "invoiceDateDataGridViewTextBoxColumn1";
            // 
            // shipIDDataGridViewTextBoxColumn1
            // 
            this.shipIDDataGridViewTextBoxColumn1.DataPropertyName = "ShipID";
            this.shipIDDataGridViewTextBoxColumn1.HeaderText = "ShipID";
            this.shipIDDataGridViewTextBoxColumn1.Name = "shipIDDataGridViewTextBoxColumn1";
            // 
            // productIDDataGridViewTextBoxColumn1
            // 
            this.productIDDataGridViewTextBoxColumn1.DataPropertyName = "ProductID";
            this.productIDDataGridViewTextBoxColumn1.HeaderText = "ProductID";
            this.productIDDataGridViewTextBoxColumn1.Name = "productIDDataGridViewTextBoxColumn1";
            // 
            // descriptionDataGridViewTextBoxColumn1
            // 
            this.descriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn1.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn1.Name = "descriptionDataGridViewTextBoxColumn1";
            // 
            // extra1DataGridViewTextBoxColumn1
            // 
            this.extra1DataGridViewTextBoxColumn1.DataPropertyName = "Extra1";
            this.extra1DataGridViewTextBoxColumn1.HeaderText = "Extra1";
            this.extra1DataGridViewTextBoxColumn1.Name = "extra1DataGridViewTextBoxColumn1";
            // 
            // pricePerUnitDataGridViewTextBoxColumn1
            // 
            this.pricePerUnitDataGridViewTextBoxColumn1.DataPropertyName = "PricePerUnit";
            this.pricePerUnitDataGridViewTextBoxColumn1.HeaderText = "PricePerUnit";
            this.pricePerUnitDataGridViewTextBoxColumn1.Name = "pricePerUnitDataGridViewTextBoxColumn1";
            // 
            // delAdd1DataGridViewTextBoxColumn1
            // 
            this.delAdd1DataGridViewTextBoxColumn1.DataPropertyName = "DelAdd1";
            this.delAdd1DataGridViewTextBoxColumn1.HeaderText = "DelAdd1";
            this.delAdd1DataGridViewTextBoxColumn1.Name = "delAdd1DataGridViewTextBoxColumn1";
            // 
            // delAdd2DataGridViewTextBoxColumn1
            // 
            this.delAdd2DataGridViewTextBoxColumn1.DataPropertyName = "DelAdd2";
            this.delAdd2DataGridViewTextBoxColumn1.HeaderText = "DelAdd2";
            this.delAdd2DataGridViewTextBoxColumn1.Name = "delAdd2DataGridViewTextBoxColumn1";
            // 
            // cSZDataGridViewTextBoxColumn1
            // 
            this.cSZDataGridViewTextBoxColumn1.DataPropertyName = "CSZ";
            this.cSZDataGridViewTextBoxColumn1.HeaderText = "CSZ";
            this.cSZDataGridViewTextBoxColumn1.Name = "cSZDataGridViewTextBoxColumn1";
            this.cSZDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 800);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "add";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PivotTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DSInv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dSInvBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable5BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private DSInv DSInv;
        private DSInvTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.BindingSource PivotTBindingSource;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipMethodDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCatIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extra1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delAdd1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn delAdd2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSZDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricePerUnitDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dataTable3BindingSource;
        private DSInvTableAdapters.DataTable3TableAdapter dataTable3TableAdapter;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipMethodDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn lineIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.BindingSource dSInvBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCatIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn invoiceDateDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn shipIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn productIDDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn extra1DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pricePerUnitDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn delAdd1DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn delAdd2DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSZDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource dataTable5BindingSource;
        private DSInvTableAdapters.DataTable5TableAdapter dataTable5TableAdapter;
    }
}

