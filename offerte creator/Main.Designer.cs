namespace offerte_creator
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.GB_Customers = new System.Windows.Forms.GroupBox();
            this.TB_Town = new System.Windows.Forms.TextBox();
            this.L_Town = new System.Windows.Forms.Label();
            this.TB_Zipcode2 = new System.Windows.Forms.TextBox();
            this.TB_Zipcode1 = new System.Windows.Forms.TextBox();
            this.L_Zipcode = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_HomeNumber2 = new System.Windows.Forms.TextBox();
            this.TB_HomeNumber1 = new System.Windows.Forms.TextBox();
            this.TB_Street = new System.Windows.Forms.TextBox();
            this.TB_CustomersName = new System.Windows.Forms.TextBox();
            this.L_CustomersName = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nieuwToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opslaanToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createOfferteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afsluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onderdeelToevoegenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instellingenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.GB_Parts = new System.Windows.Forms.GroupBox();
            this._P_Parts = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TB_Totaal = new System.Windows.Forms.TextBox();
            this.L_Totaal = new System.Windows.Forms.Label();
            this.saveFileDialogPDF = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogLogo = new System.Windows.Forms.OpenFileDialog();
            this._GB_Offerte = new System.Windows.Forms.GroupBox();
            this._CB_Regie = new System.Windows.Forms.CheckBox();
            this._TB_Referentie = new System.Windows.Forms.TextBox();
            this._L_Referentie = new System.Windows.Forms.Label();
            this._L_ExpairingDate = new System.Windows.Forms.Label();
            this._DTP_ExpairingDate = new System.Windows.Forms.DateTimePicker();
            this._DTP_OfferteDate = new System.Windows.Forms.DateTimePicker();
            this._L_OfferteDate = new System.Windows.Forms.Label();
            this._NUD_OfferteNumber = new System.Windows.Forms.NumericUpDown();
            this._L_OfferteNumber = new System.Windows.Forms.Label();
            this.GB_Customers.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.GB_Parts.SuspendLayout();
            this.panel1.SuspendLayout();
            this._GB_Offerte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._NUD_OfferteNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // GB_Customers
            // 
            this.GB_Customers.Controls.Add(this.TB_Town);
            this.GB_Customers.Controls.Add(this.L_Town);
            this.GB_Customers.Controls.Add(this.TB_Zipcode2);
            this.GB_Customers.Controls.Add(this.TB_Zipcode1);
            this.GB_Customers.Controls.Add(this.L_Zipcode);
            this.GB_Customers.Controls.Add(this.label1);
            this.GB_Customers.Controls.Add(this.TB_HomeNumber2);
            this.GB_Customers.Controls.Add(this.TB_HomeNumber1);
            this.GB_Customers.Controls.Add(this.TB_Street);
            this.GB_Customers.Controls.Add(this.TB_CustomersName);
            this.GB_Customers.Controls.Add(this.L_CustomersName);
            this.GB_Customers.Dock = System.Windows.Forms.DockStyle.Top;
            this.GB_Customers.Location = new System.Drawing.Point(0, 24);
            this.GB_Customers.Name = "GB_Customers";
            this.GB_Customers.Size = new System.Drawing.Size(509, 99);
            this.GB_Customers.TabIndex = 0;
            this.GB_Customers.TabStop = false;
            this.GB_Customers.Text = "Klant gegevens";
            // 
            // TB_Town
            // 
            this.TB_Town.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Town.Location = new System.Drawing.Point(234, 73);
            this.TB_Town.Name = "TB_Town";
            this.TB_Town.Size = new System.Drawing.Size(269, 20);
            this.TB_Town.TabIndex = 10;
            this.TB_Town.TextChanged += new System.EventHandler(this.TB_Town_TextChanged);
            // 
            // L_Town
            // 
            this.L_Town.AutoSize = true;
            this.L_Town.Location = new System.Drawing.Point(158, 76);
            this.L_Town.Name = "L_Town";
            this.L_Town.Size = new System.Drawing.Size(70, 13);
            this.L_Town.TabIndex = 9;
            this.L_Town.Text = "Woonplaats :";
            // 
            // TB_Zipcode2
            // 
            this.TB_Zipcode2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TB_Zipcode2.Location = new System.Drawing.Point(112, 73);
            this.TB_Zipcode2.MaxLength = 2;
            this.TB_Zipcode2.Name = "TB_Zipcode2";
            this.TB_Zipcode2.Size = new System.Drawing.Size(40, 20);
            this.TB_Zipcode2.TabIndex = 8;
            this.TB_Zipcode2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_Zipcode2.TextChanged += new System.EventHandler(this.TB_Zipcode_TextChanged);
            // 
            // TB_Zipcode1
            // 
            this.TB_Zipcode1.Location = new System.Drawing.Point(70, 73);
            this.TB_Zipcode1.MaxLength = 4;
            this.TB_Zipcode1.Name = "TB_Zipcode1";
            this.TB_Zipcode1.Size = new System.Drawing.Size(40, 20);
            this.TB_Zipcode1.TabIndex = 7;
            this.TB_Zipcode1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_Zipcode1.TextChanged += new System.EventHandler(this.TB_Zipcode_TextChanged);
            this.TB_Zipcode1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly_KeyPress);
            // 
            // L_Zipcode
            // 
            this.L_Zipcode.AutoSize = true;
            this.L_Zipcode.Location = new System.Drawing.Point(6, 76);
            this.L_Zipcode.Name = "L_Zipcode";
            this.L_Zipcode.Size = new System.Drawing.Size(58, 13);
            this.L_Zipcode.TabIndex = 6;
            this.L_Zipcode.Text = "Postcode :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Àdres :";
            // 
            // TB_HomeNumber2
            // 
            this.TB_HomeNumber2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_HomeNumber2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.TB_HomeNumber2.Location = new System.Drawing.Point(463, 49);
            this.TB_HomeNumber2.Name = "TB_HomeNumber2";
            this.TB_HomeNumber2.Size = new System.Drawing.Size(40, 20);
            this.TB_HomeNumber2.TabIndex = 4;
            this.TB_HomeNumber2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_HomeNumber2.TextChanged += new System.EventHandler(this.TB_Adres_TextChanged);
            // 
            // TB_HomeNumber1
            // 
            this.TB_HomeNumber1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_HomeNumber1.Location = new System.Drawing.Point(417, 49);
            this.TB_HomeNumber1.Name = "TB_HomeNumber1";
            this.TB_HomeNumber1.Size = new System.Drawing.Size(40, 20);
            this.TB_HomeNumber1.TabIndex = 3;
            this.TB_HomeNumber1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TB_HomeNumber1.TextChanged += new System.EventHandler(this.TB_Adres_TextChanged);
            this.TB_HomeNumber1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOnly_KeyPress);
            // 
            // TB_Street
            // 
            this.TB_Street.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Street.Location = new System.Drawing.Point(70, 49);
            this.TB_Street.Name = "TB_Street";
            this.TB_Street.Size = new System.Drawing.Size(341, 20);
            this.TB_Street.TabIndex = 2;
            this.TB_Street.TextChanged += new System.EventHandler(this.TB_Adres_TextChanged);
            // 
            // TB_CustomersName
            // 
            this.TB_CustomersName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_CustomersName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.TB_CustomersName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.RecentlyUsedList;
            this.TB_CustomersName.Location = new System.Drawing.Point(70, 23);
            this.TB_CustomersName.Name = "TB_CustomersName";
            this.TB_CustomersName.Size = new System.Drawing.Size(433, 20);
            this.TB_CustomersName.TabIndex = 1;
            this.TB_CustomersName.TextChanged += new System.EventHandler(this.TB_CustomersName_TextChanged);
            // 
            // L_CustomersName
            // 
            this.L_CustomersName.AutoSize = true;
            this.L_CustomersName.Location = new System.Drawing.Point(23, 23);
            this.L_CustomersName.Name = "L_CustomersName";
            this.L_CustomersName.Size = new System.Drawing.Size(41, 13);
            this.L_CustomersName.TabIndex = 0;
            this.L_CustomersName.Text = "Naam :";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestandToolStripMenuItem,
            this.onderdeelToevoegenToolStripMenuItem,
            this.instellingenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(509, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bestandToolStripMenuItem
            // 
            this.bestandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nieuwToolStripMenuItem,
            this.openenToolStripMenuItem,
            this.opslaanToolStripMenuItem,
            this.createOfferteToolStripMenuItem,
            this.afsluitenToolStripMenuItem});
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.bestandToolStripMenuItem.Text = "Bestand";
            // 
            // nieuwToolStripMenuItem
            // 
            this.nieuwToolStripMenuItem.Name = "nieuwToolStripMenuItem";
            this.nieuwToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.nieuwToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.nieuwToolStripMenuItem.Text = "Nieuw";
            this.nieuwToolStripMenuItem.Click += new System.EventHandler(this.nieuwToolStripMenuItem_Click);
            // 
            // openenToolStripMenuItem
            // 
            this.openenToolStripMenuItem.Name = "openenToolStripMenuItem";
            this.openenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openenToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openenToolStripMenuItem.Text = "Openen";
            this.openenToolStripMenuItem.Click += new System.EventHandler(this.openenToolStripMenuItem_Click);
            // 
            // opslaanToolStripMenuItem
            // 
            this.opslaanToolStripMenuItem.Name = "opslaanToolStripMenuItem";
            this.opslaanToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.opslaanToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.opslaanToolStripMenuItem.Text = "Opslaan";
            this.opslaanToolStripMenuItem.Click += new System.EventHandler(this.opslaanToolStripMenuItem_Click);
            // 
            // createOfferteToolStripMenuItem
            // 
            this.createOfferteToolStripMenuItem.Name = "createOfferteToolStripMenuItem";
            this.createOfferteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.createOfferteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.createOfferteToolStripMenuItem.Text = "Offerte maken";
            this.createOfferteToolStripMenuItem.Visible = false;
            // 
            // afsluitenToolStripMenuItem
            // 
            this.afsluitenToolStripMenuItem.Name = "afsluitenToolStripMenuItem";
            this.afsluitenToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.afsluitenToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.afsluitenToolStripMenuItem.Text = "Afsluiten";
            this.afsluitenToolStripMenuItem.Click += new System.EventHandler(this.afsluitenToolStripMenuItem_Click);
            // 
            // onderdeelToevoegenToolStripMenuItem
            // 
            this.onderdeelToevoegenToolStripMenuItem.Name = "onderdeelToevoegenToolStripMenuItem";
            this.onderdeelToevoegenToolStripMenuItem.Size = new System.Drawing.Size(133, 20);
            this.onderdeelToevoegenToolStripMenuItem.Text = "Onderdeel toevoegen";
            this.onderdeelToevoegenToolStripMenuItem.Click += new System.EventHandler(this.onderdeelToevoegenToolStripMenuItem_Click);
            // 
            // instellingenToolStripMenuItem
            // 
            this.instellingenToolStripMenuItem.Name = "instellingenToolStripMenuItem";
            this.instellingenToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.instellingenToolStripMenuItem.Text = "Instellingen";
            this.instellingenToolStripMenuItem.Click += new System.EventHandler(this.instellingenToolStripMenuItem_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Offerte creator files (*.OCF)|*.OCF";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Offerte creator files (*.OCF)|*.OCF";
            // 
            // GB_Parts
            // 
            this.GB_Parts.Controls.Add(this._P_Parts);
            this.GB_Parts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_Parts.Location = new System.Drawing.Point(0, 202);
            this.GB_Parts.Name = "GB_Parts";
            this.GB_Parts.Size = new System.Drawing.Size(509, 191);
            this.GB_Parts.TabIndex = 3;
            this.GB_Parts.TabStop = false;
            this.GB_Parts.Text = "Onderdelen";
            // 
            // _P_Parts
            // 
            this._P_Parts.AutoScroll = true;
            this._P_Parts.AutoSize = true;
            this._P_Parts.Dock = System.Windows.Forms.DockStyle.Fill;
            this._P_Parts.Location = new System.Drawing.Point(3, 16);
            this._P_Parts.Name = "_P_Parts";
            this._P_Parts.Size = new System.Drawing.Size(503, 172);
            this._P_Parts.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TB_Totaal);
            this.panel1.Controls.Add(this.L_Totaal);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 393);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(509, 48);
            this.panel1.TabIndex = 4;
            // 
            // TB_Totaal
            // 
            this.TB_Totaal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Totaal.Enabled = false;
            this.TB_Totaal.Location = new System.Drawing.Point(417, 16);
            this.TB_Totaal.Name = "TB_Totaal";
            this.TB_Totaal.ReadOnly = true;
            this.TB_Totaal.Size = new System.Drawing.Size(86, 20);
            this.TB_Totaal.TabIndex = 6;
            // 
            // L_Totaal
            // 
            this.L_Totaal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Totaal.AutoSize = true;
            this.L_Totaal.Location = new System.Drawing.Point(343, 19);
            this.L_Totaal.Name = "L_Totaal";
            this.L_Totaal.Size = new System.Drawing.Size(68, 13);
            this.L_Totaal.TabIndex = 5;
            this.L_Totaal.Text = "Totaal Prijs : ";
            // 
            // saveFileDialogPDF
            // 
            this.saveFileDialogPDF.Filter = "PDF (*.PDF)|*.PDF";
            // 
            // openFileDialogLogo
            // 
            this.openFileDialogLogo.Filter = "Foto bestanden|*.bmp;*.jpg;*.jpeg;*.png;\"";
            // 
            // _GB_Offerte
            // 
            this._GB_Offerte.Controls.Add(this._CB_Regie);
            this._GB_Offerte.Controls.Add(this._TB_Referentie);
            this._GB_Offerte.Controls.Add(this._L_Referentie);
            this._GB_Offerte.Controls.Add(this._L_ExpairingDate);
            this._GB_Offerte.Controls.Add(this._DTP_ExpairingDate);
            this._GB_Offerte.Controls.Add(this._DTP_OfferteDate);
            this._GB_Offerte.Controls.Add(this._L_OfferteDate);
            this._GB_Offerte.Controls.Add(this._NUD_OfferteNumber);
            this._GB_Offerte.Controls.Add(this._L_OfferteNumber);
            this._GB_Offerte.Dock = System.Windows.Forms.DockStyle.Top;
            this._GB_Offerte.Location = new System.Drawing.Point(0, 123);
            this._GB_Offerte.Name = "_GB_Offerte";
            this._GB_Offerte.Size = new System.Drawing.Size(509, 79);
            this._GB_Offerte.TabIndex = 0;
            this._GB_Offerte.TabStop = false;
            this._GB_Offerte.Text = "Offerte gegevens";
            // 
            // _CB_Regie
            // 
            this._CB_Regie.AutoSize = true;
            this._CB_Regie.CheckAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._CB_Regie.Location = new System.Drawing.Point(432, 25);
            this._CB_Regie.Name = "_CB_Regie";
            this._CB_Regie.Size = new System.Drawing.Size(65, 31);
            this._CB_Regie.TabIndex = 7;
            this._CB_Regie.Text = "Regie werk";
            this._CB_Regie.UseVisualStyleBackColor = true;
            this._CB_Regie.CheckedChanged += new System.EventHandler(this._CB_Regie_CheckedChanged);
            // 
            // _TB_Referentie
            // 
            this._TB_Referentie.Location = new System.Drawing.Point(299, 25);
            this._TB_Referentie.Name = "_TB_Referentie";
            this._TB_Referentie.Size = new System.Drawing.Size(115, 20);
            this._TB_Referentie.TabIndex = 2;
            this._TB_Referentie.TextChanged += new System.EventHandler(this._TB_Referentie_Leave);
            this._TB_Referentie.Leave += new System.EventHandler(this._TB_Referentie_Leave);
            // 
            // _L_Referentie
            // 
            this._L_Referentie.AutoSize = true;
            this._L_Referentie.Location = new System.Drawing.Point(231, 28);
            this._L_Referentie.Name = "_L_Referentie";
            this._L_Referentie.Size = new System.Drawing.Size(62, 13);
            this._L_Referentie.TabIndex = 6;
            this._L_Referentie.Text = "Referentie :";
            // 
            // _L_ExpairingDate
            // 
            this._L_ExpairingDate.AutoSize = true;
            this._L_ExpairingDate.Location = new System.Drawing.Point(231, 58);
            this._L_ExpairingDate.Name = "_L_ExpairingDate";
            this._L_ExpairingDate.Size = new System.Drawing.Size(75, 13);
            this._L_ExpairingDate.TabIndex = 5;
            this._L_ExpairingDate.Text = "Verval datum :";
            // 
            // _DTP_ExpairingDate
            // 
            this._DTP_ExpairingDate.CustomFormat = "dd-MM-yyyy";
            this._DTP_ExpairingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._DTP_ExpairingDate.Location = new System.Drawing.Point(314, 52);
            this._DTP_ExpairingDate.Name = "_DTP_ExpairingDate";
            this._DTP_ExpairingDate.Size = new System.Drawing.Size(100, 20);
            this._DTP_ExpairingDate.TabIndex = 4;
            this._DTP_ExpairingDate.ValueChanged += new System.EventHandler(this._DTP_ExpairingDate_Leave);
            this._DTP_ExpairingDate.Leave += new System.EventHandler(this._DTP_ExpairingDate_Leave);
            // 
            // _DTP_OfferteDate
            // 
            this._DTP_OfferteDate.CustomFormat = "dd-MM-yyyy";
            this._DTP_OfferteDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this._DTP_OfferteDate.Location = new System.Drawing.Point(103, 52);
            this._DTP_OfferteDate.Name = "_DTP_OfferteDate";
            this._DTP_OfferteDate.Size = new System.Drawing.Size(100, 20);
            this._DTP_OfferteDate.TabIndex = 3;
            this._DTP_OfferteDate.ValueChanged += new System.EventHandler(this._DTP_OfferteDate_Leave);
            this._DTP_OfferteDate.Leave += new System.EventHandler(this._DTP_OfferteDate_Leave);
            // 
            // _L_OfferteDate
            // 
            this._L_OfferteDate.AutoSize = true;
            this._L_OfferteDate.Location = new System.Drawing.Point(12, 58);
            this._L_OfferteDate.Name = "_L_OfferteDate";
            this._L_OfferteDate.Size = new System.Drawing.Size(77, 13);
            this._L_OfferteDate.TabIndex = 2;
            this._L_OfferteDate.Text = "Offerte datum :";
            // 
            // _NUD_OfferteNumber
            // 
            this._NUD_OfferteNumber.Location = new System.Drawing.Point(103, 26);
            this._NUD_OfferteNumber.Maximum = new decimal(new int[] {
            276447231,
            23283,
            0,
            0});
            this._NUD_OfferteNumber.Name = "_NUD_OfferteNumber";
            this._NUD_OfferteNumber.Size = new System.Drawing.Size(120, 20);
            this._NUD_OfferteNumber.TabIndex = 1;
            this._NUD_OfferteNumber.Scroll += new System.Windows.Forms.ScrollEventHandler(this._NUD_OfferteNumber_Scroll);
            this._NUD_OfferteNumber.Leave += new System.EventHandler(this._NUD_OfferteNumber_Leave);
            // 
            // _L_OfferteNumber
            // 
            this._L_OfferteNumber.AutoSize = true;
            this._L_OfferteNumber.Location = new System.Drawing.Point(12, 28);
            this._L_OfferteNumber.Name = "_L_OfferteNumber";
            this._L_OfferteNumber.Size = new System.Drawing.Size(85, 13);
            this._L_OfferteNumber.TabIndex = 0;
            this._L_OfferteNumber.Text = "Offerte nummer :";
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 441);
            this.Controls.Add(this.GB_Parts);
            this.Controls.Add(this._GB_Offerte);
            this.Controls.Add(this.GB_Customers);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(525, 480);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Offerte creator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.GB_Customers.ResumeLayout(false);
            this.GB_Customers.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.GB_Parts.ResumeLayout(false);
            this.GB_Parts.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this._GB_Offerte.ResumeLayout(false);
            this._GB_Offerte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._NUD_OfferteNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox GB_Customers;
        private System.Windows.Forms.Label L_Zipcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label L_CustomersName;
        private System.Windows.Forms.Label L_Town;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nieuwToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem opslaanToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afsluitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onderdeelToevoegenToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.GroupBox GB_Parts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label L_Totaal;
        public System.Windows.Forms.TextBox TB_Totaal;
        public System.Windows.Forms.Panel _P_Parts;
        private System.Windows.Forms.ToolStripMenuItem instellingenToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogLogo;
        private System.Windows.Forms.GroupBox _GB_Offerte;
        private System.Windows.Forms.Label _L_OfferteNumber;
        private System.Windows.Forms.Label _L_OfferteDate;
        private System.Windows.Forms.Label _L_ExpairingDate;
        private System.Windows.Forms.Label _L_Referentie;
        public System.Windows.Forms.TextBox TB_Zipcode1;
        public System.Windows.Forms.TextBox TB_HomeNumber2;
        public System.Windows.Forms.TextBox TB_HomeNumber1;
        public System.Windows.Forms.TextBox TB_Street;
        public System.Windows.Forms.TextBox TB_CustomersName;
        public System.Windows.Forms.TextBox TB_Zipcode2;
        public System.Windows.Forms.TextBox TB_Town;
        public System.Windows.Forms.NumericUpDown _NUD_OfferteNumber;
        public System.Windows.Forms.DateTimePicker _DTP_OfferteDate;
        public System.Windows.Forms.TextBox _TB_Referentie;
        public System.Windows.Forms.DateTimePicker _DTP_ExpairingDate;
        public System.Windows.Forms.CheckBox _CB_Regie;
        public System.Windows.Forms.ToolStripMenuItem createOfferteToolStripMenuItem;
        public System.Windows.Forms.SaveFileDialog saveFileDialogPDF;
        public System.Windows.Forms.MenuStrip menuStrip1;
    }
}

