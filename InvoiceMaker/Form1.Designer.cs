﻿namespace InvoiceMaker
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.createPdfButton = new System.Windows.Forms.Button();
            this.myCompanyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.customerTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonVAT25 = new System.Windows.Forms.RadioButton();
            this.radioButtonVAT6 = new System.Windows.Forms.RadioButton();
            this.radioButtonVAT12 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButtonVAT0 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.deleteCustomerButton = new System.Windows.Forms.Button();
            this.addCustomerButton = new System.Windows.Forms.Button();
            this.fetchCustomerButton = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.allRadioButton = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.archiveInvoiceButton = new System.Windows.Forms.Button();
            this.invoiceNumberNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.createPdfFromArchivebutton = new System.Windows.Forms.Button();
            this.archiveComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButton30Days = new System.Windows.Forms.RadioButton();
            this.radioButton14Days = new System.Windows.Forms.RadioButton();
            this.groupBoxCurrency = new System.Windows.Forms.GroupBox();
            this.radioButtonEUR = new System.Windows.Forms.RadioButton();
            this.radioButtonUSD = new System.Windows.Forms.RadioButton();
            this.radioButtonSEK = new System.Windows.Forms.RadioButton();
            this.buttonLogo = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceNumberNumericUpDown)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBoxCurrency.SuspendLayout();
            this.SuspendLayout();
            // 
            // createPdfButton
            // 
            this.createPdfButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.createPdfButton.Location = new System.Drawing.Point(406, 564);
            this.createPdfButton.Name = "createPdfButton";
            this.createPdfButton.Size = new System.Drawing.Size(135, 40);
            this.createPdfButton.TabIndex = 0;
            this.createPdfButton.Text = "Skapa Pdf";
            this.createPdfButton.UseVisualStyleBackColor = true;
            this.createPdfButton.Click += new System.EventHandler(this.createPdfButton_Click);
            // 
            // myCompanyTextBox
            // 
            this.myCompanyTextBox.Location = new System.Drawing.Point(34, 49);
            this.myCompanyTextBox.Multiline = true;
            this.myCompanyTextBox.Name = "myCompanyTextBox";
            this.myCompanyTextBox.Size = new System.Drawing.Size(329, 199);
            this.myCompanyTextBox.TabIndex = 1;
            this.myCompanyTextBox.Text = "Jonathan Dahl\r\nJakobsdalsvägen 10,\r\n126 54, Stockholm\r\nSWEDEN\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Mitt bolag";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Location = new System.Drawing.Point(34, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(665, 191);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fakturering";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 22);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(659, 166);
            this.dataGridView1.TabIndex = 11;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Label";
            this.dataGridViewTextBoxColumn1.HeaderText = "Tjänst/Artikel";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 260;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Amount";
            this.dataGridViewTextBoxColumn2.HeaderText = "Antal";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 65;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Price";
            this.dataGridViewTextBoxColumn3.HeaderText = "Pris";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 65;
            // 
            // customerTextBox
            // 
            this.customerTextBox.Location = new System.Drawing.Point(370, 49);
            this.customerTextBox.Multiline = true;
            this.customerTextBox.Name = "customerTextBox";
            this.customerTextBox.Size = new System.Drawing.Size(329, 199);
            this.customerTextBox.TabIndex = 5;
            this.customerTextBox.Text = "SNASK AB\r\nRiddargatan 38, 114 57\r\nStockholm, SWEDEN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(370, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Kund";
            // 
            // radioButtonVAT25
            // 
            this.radioButtonVAT25.AutoSize = true;
            this.radioButtonVAT25.Checked = true;
            this.radioButtonVAT25.Location = new System.Drawing.Point(15, 25);
            this.radioButtonVAT25.Name = "radioButtonVAT25";
            this.radioButtonVAT25.Size = new System.Drawing.Size(66, 24);
            this.radioButtonVAT25.TabIndex = 7;
            this.radioButtonVAT25.TabStop = true;
            this.radioButtonVAT25.Text = "25%";
            this.radioButtonVAT25.UseVisualStyleBackColor = true;
            // 
            // radioButtonVAT6
            // 
            this.radioButtonVAT6.AutoSize = true;
            this.radioButtonVAT6.Location = new System.Drawing.Point(159, 25);
            this.radioButtonVAT6.Name = "radioButtonVAT6";
            this.radioButtonVAT6.Size = new System.Drawing.Size(57, 24);
            this.radioButtonVAT6.TabIndex = 8;
            this.radioButtonVAT6.Text = "6%";
            this.radioButtonVAT6.UseVisualStyleBackColor = true;
            // 
            // radioButtonVAT12
            // 
            this.radioButtonVAT12.AutoSize = true;
            this.radioButtonVAT12.Location = new System.Drawing.Point(87, 25);
            this.radioButtonVAT12.Name = "radioButtonVAT12";
            this.radioButtonVAT12.Size = new System.Drawing.Size(66, 24);
            this.radioButtonVAT12.TabIndex = 9;
            this.radioButtonVAT12.Text = "12%";
            this.radioButtonVAT12.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.radioButtonVAT0);
            this.groupBox2.Controls.Add(this.radioButtonVAT25);
            this.groupBox2.Controls.Add(this.radioButtonVAT12);
            this.groupBox2.Controls.Add(this.radioButtonVAT6);
            this.groupBox2.Location = new System.Drawing.Point(39, 532);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(294, 60);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Moms:";
            // 
            // radioButtonVAT0
            // 
            this.radioButtonVAT0.AutoSize = true;
            this.radioButtonVAT0.Location = new System.Drawing.Point(222, 25);
            this.radioButtonVAT0.Name = "radioButtonVAT0";
            this.radioButtonVAT0.Size = new System.Drawing.Size(57, 24);
            this.radioButtonVAT0.TabIndex = 10;
            this.radioButtonVAT0.Text = "0%";
            this.radioButtonVAT0.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.deleteCustomerButton);
            this.groupBox3.Controls.Add(this.addCustomerButton);
            this.groupBox3.Controls.Add(this.fetchCustomerButton);
            this.groupBox3.Controls.Add(this.listBox1);
            this.groupBox3.Location = new System.Drawing.Point(705, 26);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(373, 222);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Kunder";
            // 
            // deleteCustomerButton
            // 
            this.deleteCustomerButton.Location = new System.Drawing.Point(7, 147);
            this.deleteCustomerButton.Name = "deleteCustomerButton";
            this.deleteCustomerButton.Size = new System.Drawing.Size(75, 59);
            this.deleteCustomerButton.TabIndex = 5;
            this.deleteCustomerButton.Text = "Ta bort kund";
            this.deleteCustomerButton.UseVisualStyleBackColor = true;
            this.deleteCustomerButton.Click += new System.EventHandler(this.deleteCustomerButton_Click);
            // 
            // addCustomerButton
            // 
            this.addCustomerButton.Location = new System.Drawing.Point(7, 86);
            this.addCustomerButton.Name = "addCustomerButton";
            this.addCustomerButton.Size = new System.Drawing.Size(75, 59);
            this.addCustomerButton.TabIndex = 2;
            this.addCustomerButton.Text = "=>";
            this.addCustomerButton.UseVisualStyleBackColor = true;
            this.addCustomerButton.Click += new System.EventHandler(this.addCustomerButton_Click);
            // 
            // fetchCustomerButton
            // 
            this.fetchCustomerButton.Location = new System.Drawing.Point(7, 25);
            this.fetchCustomerButton.Name = "fetchCustomerButton";
            this.fetchCustomerButton.Size = new System.Drawing.Size(75, 59);
            this.fetchCustomerButton.TabIndex = 1;
            this.fetchCustomerButton.Text = "<=";
            this.fetchCustomerButton.UseVisualStyleBackColor = true;
            this.fetchCustomerButton.Click += new System.EventHandler(this.fetchCustomerButton_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(91, 23);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(257, 184);
            this.listBox1.TabIndex = 4;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.button3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.radioButton6);
            this.groupBox4.Controls.Add(this.allRadioButton);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.startDateTimePicker);
            this.groupBox4.Controls.Add(this.endDateTimePicker);
            this.groupBox4.Location = new System.Drawing.Point(705, 348);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(373, 141);
            this.groupBox4.TabIndex = 12;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Rapporter";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(177, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(190, 26);
            this.textBox1.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(248, 85);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 42);
            this.button3.TabIndex = 7;
            this.button3.Text = "Rapport!";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(124, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Till";
            // 
            // radioButton6
            // 
            this.radioButton6.AutoSize = true;
            this.radioButton6.Location = new System.Drawing.Point(99, 26);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(71, 24);
            this.radioButton6.TabIndex = 3;
            this.radioButton6.TabStop = true;
            this.radioButton6.Text = "Kund";
            this.radioButton6.UseVisualStyleBackColor = true;
            // 
            // allRadioButton
            // 
            this.allRadioButton.AutoSize = true;
            this.allRadioButton.Checked = true;
            this.allRadioButton.Location = new System.Drawing.Point(32, 26);
            this.allRadioButton.Name = "allRadioButton";
            this.allRadioButton.Size = new System.Drawing.Size(60, 24);
            this.allRadioButton.TabIndex = 2;
            this.allRadioButton.TabStop = true;
            this.allRadioButton.Text = "Alla";
            this.allRadioButton.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Från";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.startDateTimePicker.Location = new System.Drawing.Point(8, 91);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(113, 26);
            this.startDateTimePicker.TabIndex = 1;
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.endDateTimePicker.Location = new System.Drawing.Point(128, 91);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(116, 26);
            this.endDateTimePicker.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(373, 536);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Fakturanummer:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(505, 536);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "label6";
            // 
            // archiveInvoiceButton
            // 
            this.archiveInvoiceButton.Location = new System.Drawing.Point(564, 564);
            this.archiveInvoiceButton.Name = "archiveInvoiceButton";
            this.archiveInvoiceButton.Size = new System.Drawing.Size(135, 40);
            this.archiveInvoiceButton.TabIndex = 15;
            this.archiveInvoiceButton.Text = "Arkivera faktura";
            this.archiveInvoiceButton.UseVisualStyleBackColor = true;
            this.archiveInvoiceButton.Click += new System.EventHandler(this.archiveInvoiceButton_Click);
            // 
            // invoiceNumberNumericUpDown
            // 
            this.invoiceNumberNumericUpDown.Location = new System.Drawing.Point(564, 532);
            this.invoiceNumberNumericUpDown.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.invoiceNumberNumericUpDown.Name = "invoiceNumberNumericUpDown";
            this.invoiceNumberNumericUpDown.Size = new System.Drawing.Size(135, 26);
            this.invoiceNumberNumericUpDown.TabIndex = 16;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.createPdfFromArchivebutton);
            this.groupBox5.Controls.Add(this.archiveComboBox);
            this.groupBox5.Location = new System.Drawing.Point(705, 255);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(373, 79);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Arkiv";
            // 
            // createPdfFromArchivebutton
            // 
            this.createPdfFromArchivebutton.Location = new System.Drawing.Point(158, 25);
            this.createPdfFromArchivebutton.Name = "createPdfFromArchivebutton";
            this.createPdfFromArchivebutton.Size = new System.Drawing.Size(86, 34);
            this.createPdfFromArchivebutton.TabIndex = 1;
            this.createPdfFromArchivebutton.Text = "Visa PDF";
            this.createPdfFromArchivebutton.UseVisualStyleBackColor = true;
            // 
            // archiveComboBox
            // 
            this.archiveComboBox.FormattingEnabled = true;
            this.archiveComboBox.Location = new System.Drawing.Point(9, 25);
            this.archiveComboBox.Name = "archiveComboBox";
            this.archiveComboBox.Size = new System.Drawing.Size(121, 28);
            this.archiveComboBox.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButton30Days);
            this.groupBox6.Controls.Add(this.radioButton14Days);
            this.groupBox6.Location = new System.Drawing.Point(39, 452);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(230, 57);
            this.groupBox6.TabIndex = 18;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Betalningsperiod";
            // 
            // radioButton30Days
            // 
            this.radioButton30Days.AutoSize = true;
            this.radioButton30Days.Location = new System.Drawing.Point(120, 21);
            this.radioButton30Days.Name = "radioButton30Days";
            this.radioButton30Days.Size = new System.Drawing.Size(97, 24);
            this.radioButton30Days.TabIndex = 1;
            this.radioButton30Days.Text = "30 dagar";
            this.radioButton30Days.UseVisualStyleBackColor = true;
            // 
            // radioButton14Days
            // 
            this.radioButton14Days.AutoSize = true;
            this.radioButton14Days.Checked = true;
            this.radioButton14Days.Location = new System.Drawing.Point(17, 21);
            this.radioButton14Days.Name = "radioButton14Days";
            this.radioButton14Days.Size = new System.Drawing.Size(97, 24);
            this.radioButton14Days.TabIndex = 0;
            this.radioButton14Days.TabStop = true;
            this.radioButton14Days.Text = "14 dagar";
            this.radioButton14Days.UseVisualStyleBackColor = true;
            // 
            // groupBoxCurrency
            // 
            this.groupBoxCurrency.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxCurrency.Controls.Add(this.radioButtonEUR);
            this.groupBoxCurrency.Controls.Add(this.radioButtonUSD);
            this.groupBoxCurrency.Controls.Add(this.radioButtonSEK);
            this.groupBoxCurrency.Location = new System.Drawing.Point(275, 452);
            this.groupBoxCurrency.Name = "groupBoxCurrency";
            this.groupBoxCurrency.Size = new System.Drawing.Size(244, 57);
            this.groupBoxCurrency.TabIndex = 19;
            this.groupBoxCurrency.TabStop = false;
            this.groupBoxCurrency.Text = "Valuta";
            // 
            // radioButtonEUR
            // 
            this.radioButtonEUR.AutoSize = true;
            this.radioButtonEUR.Location = new System.Drawing.Point(170, 25);
            this.radioButtonEUR.Name = "radioButtonEUR";
            this.radioButtonEUR.Size = new System.Drawing.Size(69, 24);
            this.radioButtonEUR.TabIndex = 2;
            this.radioButtonEUR.TabStop = true;
            this.radioButtonEUR.Text = "EUR";
            this.radioButtonEUR.UseVisualStyleBackColor = true;
            // 
            // radioButtonUSD
            // 
            this.radioButtonUSD.AutoSize = true;
            this.radioButtonUSD.Location = new System.Drawing.Point(95, 25);
            this.radioButtonUSD.Name = "radioButtonUSD";
            this.radioButtonUSD.Size = new System.Drawing.Size(69, 24);
            this.radioButtonUSD.TabIndex = 1;
            this.radioButtonUSD.Text = "USD";
            this.radioButtonUSD.UseVisualStyleBackColor = true;
            // 
            // radioButtonSEK
            // 
            this.radioButtonSEK.AutoSize = true;
            this.radioButtonSEK.Checked = true;
            this.radioButtonSEK.Location = new System.Drawing.Point(23, 25);
            this.radioButtonSEK.Name = "radioButtonSEK";
            this.radioButtonSEK.Size = new System.Drawing.Size(66, 24);
            this.radioButtonSEK.TabIndex = 0;
            this.radioButtonSEK.TabStop = true;
            this.radioButtonSEK.Text = "SEK";
            this.radioButtonSEK.UseVisualStyleBackColor = true;
            // 
            // buttonLogo
            // 
            this.buttonLogo.Location = new System.Drawing.Point(970, 569);
            this.buttonLogo.Name = "buttonLogo";
            this.buttonLogo.Size = new System.Drawing.Size(102, 38);
            this.buttonLogo.TabIndex = 20;
            this.buttonLogo.Text = "Logo";
            this.buttonLogo.UseVisualStyleBackColor = true;
            this.buttonLogo.Click += new System.EventHandler(this.buttonLogo_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1090, 619);
            this.Controls.Add(this.buttonLogo);
            this.Controls.Add(this.groupBoxCurrency);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.invoiceNumberNumericUpDown);
            this.Controls.Add(this.archiveInvoiceButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.customerTextBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.myCompanyTextBox);
            this.Controls.Add(this.createPdfButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Form1";
            this.Text = "Inherent Invoice";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.invoiceNumberNumericUpDown)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBoxCurrency.ResumeLayout(false);
            this.groupBoxCurrency.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button createPdfButton;
        private System.Windows.Forms.TextBox myCompanyTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox customerTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonVAT25;
        private System.Windows.Forms.RadioButton radioButtonVAT6;
        private System.Windows.Forms.RadioButton radioButtonVAT12;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButtonVAT0;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button fetchCustomerButton;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.RadioButton radioButton6;
        private System.Windows.Forms.RadioButton allRadioButton;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button addCustomerButton;
        private System.Windows.Forms.Button archiveInvoiceButton;
        private System.Windows.Forms.NumericUpDown invoiceNumberNumericUpDown;
        private System.Windows.Forms.Button deleteCustomerButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.ComboBox archiveComboBox;
        private System.Windows.Forms.Button createPdfFromArchivebutton;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RadioButton radioButton30Days;
        private System.Windows.Forms.RadioButton radioButton14Days;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBoxCurrency;
        private System.Windows.Forms.RadioButton radioButtonEUR;
        private System.Windows.Forms.RadioButton radioButtonUSD;
        private System.Windows.Forms.RadioButton radioButtonSEK;
        private System.Windows.Forms.Button buttonLogo;
    }
}

