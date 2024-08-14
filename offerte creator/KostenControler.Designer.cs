namespace offerte_creator
{
    partial class KostenControler
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.L_Kosten = new System.Windows.Forms.Label();
            this._TB_Kosten = new System.Windows.Forms.TextBox();
            this._L_EenheidPrijs = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.L_Totaal = new System.Windows.Forms.Label();
            this._NUD_Totaal = new System.Windows.Forms.NumericUpDown();
            this._L_Aantal = new System.Windows.Forms.Label();
            this._L_Eenheid = new System.Windows.Forms.Label();
            this._L_IDkosten = new System.Windows.Forms.Label();
            this._L_Sluiten = new System.Windows.Forms.Label();
            this._TB_Eenheid = new System.Windows.Forms.ComboBox();
            this._RB_21 = new System.Windows.Forms.RadioButton();
            this._RB_9 = new System.Windows.Forms.RadioButton();
            this._L_BTW = new System.Windows.Forms.Label();
            this._CB_indicatie = new System.Windows.Forms.CheckBox();
            this._L_indicatie = new System.Windows.Forms.Label();
            this._NUD_EenheidPrijs = new System.Windows.Forms.TextBox();
            this._NUD_TotalStuk = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this._NUD_Totaal)).BeginInit();
            this.SuspendLayout();
            // 
            // L_Kosten
            // 
            this.L_Kosten.AutoSize = true;
            this.L_Kosten.Location = new System.Drawing.Point(80, 0);
            this.L_Kosten.Name = "L_Kosten";
            this.L_Kosten.Size = new System.Drawing.Size(40, 13);
            this.L_Kosten.TabIndex = 0;
            this.L_Kosten.Text = "Kosten";
            // 
            // _TB_Kosten
            // 
            this._TB_Kosten.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._TB_Kosten.Location = new System.Drawing.Point(19, 16);
            this._TB_Kosten.Name = "_TB_Kosten";
            this._TB_Kosten.Size = new System.Drawing.Size(253, 20);
            this._TB_Kosten.TabIndex = 1;
            this._TB_Kosten.TextChanged += new System.EventHandler(this.TB_Kosten_TextChanged);
            // 
            // _L_EenheidPrijs
            // 
            this._L_EenheidPrijs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._L_EenheidPrijs.AutoSize = true;
            this._L_EenheidPrijs.Location = new System.Drawing.Point(287, 0);
            this._L_EenheidPrijs.Name = "_L_EenheidPrijs";
            this._L_EenheidPrijs.Size = new System.Drawing.Size(67, 13);
            this._L_EenheidPrijs.TabIndex = 3;
            this._L_EenheidPrijs.Text = "Eenheid prijs";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(697, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "€";
            // 
            // L_Totaal
            // 
            this.L_Totaal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Totaal.AutoSize = true;
            this.L_Totaal.Location = new System.Drawing.Point(743, 2);
            this.L_Totaal.Name = "L_Totaal";
            this.L_Totaal.Size = new System.Drawing.Size(37, 13);
            this.L_Totaal.TabIndex = 6;
            this.L_Totaal.Text = "Totaal";
            // 
            // _NUD_Totaal
            // 
            this._NUD_Totaal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._NUD_Totaal.DecimalPlaces = 2;
            this._NUD_Totaal.Enabled = false;
            this._NUD_Totaal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._NUD_Totaal.Location = new System.Drawing.Point(716, 18);
            this._NUD_Totaal.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this._NUD_Totaal.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this._NUD_Totaal.Name = "_NUD_Totaal";
            this._NUD_Totaal.ReadOnly = true;
            this._NUD_Totaal.Size = new System.Drawing.Size(97, 20);
            this._NUD_Totaal.TabIndex = 6;
            this._NUD_Totaal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._NUD_Totaal.ThousandsSeparator = true;
            // 
            // _L_Aantal
            // 
            this._L_Aantal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._L_Aantal.AutoSize = true;
            this._L_Aantal.Location = new System.Drawing.Point(482, 2);
            this._L_Aantal.Name = "_L_Aantal";
            this._L_Aantal.Size = new System.Drawing.Size(37, 13);
            this._L_Aantal.TabIndex = 9;
            this._L_Aantal.Text = "Aantal";
            // 
            // _L_Eenheid
            // 
            this._L_Eenheid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._L_Eenheid.AutoSize = true;
            this._L_Eenheid.Location = new System.Drawing.Point(392, 0);
            this._L_Eenheid.Name = "_L_Eenheid";
            this._L_Eenheid.Size = new System.Drawing.Size(46, 13);
            this._L_Eenheid.TabIndex = 10;
            this._L_Eenheid.Text = "Eenheid";
            // 
            // _L_IDkosten
            // 
            this._L_IDkosten.AutoSize = true;
            this._L_IDkosten.Location = new System.Drawing.Point(23, 1);
            this._L_IDkosten.Name = "_L_IDkosten";
            this._L_IDkosten.Size = new System.Drawing.Size(51, 13);
            this._L_IDkosten.TabIndex = 12;
            this._L_IDkosten.Text = "IDKosten";
            this._L_IDkosten.Visible = false;
            // 
            // _L_Sluiten
            // 
            this._L_Sluiten.AutoSize = true;
            this._L_Sluiten.BackColor = System.Drawing.Color.DarkRed;
            this._L_Sluiten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._L_Sluiten.ForeColor = System.Drawing.Color.White;
            this._L_Sluiten.Location = new System.Drawing.Point(3, 20);
            this._L_Sluiten.Name = "_L_Sluiten";
            this._L_Sluiten.Size = new System.Drawing.Size(15, 13);
            this._L_Sluiten.TabIndex = 13;
            this._L_Sluiten.Text = "X";
            this._L_Sluiten.Click += new System.EventHandler(this._L_Sluiten_Click);
            // 
            // _TB_Eenheid
            // 
            this._TB_Eenheid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._TB_Eenheid.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this._TB_Eenheid.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._TB_Eenheid.FormattingEnabled = true;
            this._TB_Eenheid.Location = new System.Drawing.Point(368, 16);
            this._TB_Eenheid.Name = "_TB_Eenheid";
            this._TB_Eenheid.Size = new System.Drawing.Size(89, 21);
            this._TB_Eenheid.TabIndex = 3;
            this._TB_Eenheid.TextChanged += new System.EventHandler(this._TB_Eenheid_TextChanged);
            this._TB_Eenheid.Leave += new System.EventHandler(this._TB_Eenheid_Leave);
            // 
            // _RB_21
            // 
            this._RB_21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._RB_21.AutoSize = true;
            this._RB_21.Checked = true;
            this._RB_21.Location = new System.Drawing.Point(567, 16);
            this._RB_21.Name = "_RB_21";
            this._RB_21.Size = new System.Drawing.Size(45, 17);
            this._RB_21.TabIndex = 5;
            this._RB_21.TabStop = true;
            this._RB_21.Text = "21%";
            this._RB_21.UseVisualStyleBackColor = true;
            // 
            // _RB_9
            // 
            this._RB_9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._RB_9.AutoSize = true;
            this._RB_9.Location = new System.Drawing.Point(567, 35);
            this._RB_9.Name = "_RB_9";
            this._RB_9.Size = new System.Drawing.Size(39, 17);
            this._RB_9.TabIndex = 15;
            this._RB_9.Text = "9%";
            this._RB_9.UseVisualStyleBackColor = true;
            // 
            // _L_BTW
            // 
            this._L_BTW.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._L_BTW.AutoSize = true;
            this._L_BTW.Location = new System.Drawing.Point(550, 1);
            this._L_BTW.Name = "_L_BTW";
            this._L_BTW.Size = new System.Drawing.Size(62, 13);
            this._L_BTW.TabIndex = 16;
            this._L_BTW.Text = "BTW Tarief";
            // 
            // _CB_indicatie
            // 
            this._CB_indicatie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._CB_indicatie.AutoSize = true;
            this._CB_indicatie.CheckAlign = System.Drawing.ContentAlignment.TopCenter;
            this._CB_indicatie.Location = new System.Drawing.Point(657, 22);
            this._CB_indicatie.Name = "_CB_indicatie";
            this._CB_indicatie.Size = new System.Drawing.Size(15, 14);
            this._CB_indicatie.TabIndex = 6;
            this._CB_indicatie.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._CB_indicatie.UseVisualStyleBackColor = true;
            this._CB_indicatie.CheckedChanged += new System.EventHandler(this._SomWith_ValueChanged);
            // 
            // _L_indicatie
            // 
            this._L_indicatie.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._L_indicatie.AutoSize = true;
            this._L_indicatie.Location = new System.Drawing.Point(645, 1);
            this._L_indicatie.Name = "_L_indicatie";
            this._L_indicatie.Size = new System.Drawing.Size(47, 13);
            this._L_indicatie.TabIndex = 17;
            this._L_indicatie.Text = "Indicatie";
            // 
            // _NUD_EenheidPrijs
            // 
            this._NUD_EenheidPrijs.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._NUD_EenheidPrijs.Location = new System.Drawing.Point(278, 16);
            this._NUD_EenheidPrijs.Name = "_NUD_EenheidPrijs";
            this._NUD_EenheidPrijs.Size = new System.Drawing.Size(84, 20);
            this._NUD_EenheidPrijs.TabIndex = 2;
            this._NUD_EenheidPrijs.Text = "€0,00";
            this._NUD_EenheidPrijs.MouseClick += new System.Windows.Forms.MouseEventHandler(this._NUD_EenheidPrijs_MouseClick);
            this._NUD_EenheidPrijs.TextChanged += new System.EventHandler(this._TB_EenheidPrijs_TextChanged);
            this._NUD_EenheidPrijs.Enter += new System.EventHandler(this._TB_EenheidPrijs_Enter);
            this._NUD_EenheidPrijs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._TB_EenheidPrijs_KeyPress);
            this._NUD_EenheidPrijs.Leave += new System.EventHandler(this._TB_EenheidPrijs_Leave);
            // 
            // _NUD_TotalStuk
            // 
            this._NUD_TotalStuk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._NUD_TotalStuk.Location = new System.Drawing.Point(463, 17);
            this._NUD_TotalStuk.Name = "_NUD_TotalStuk";
            this._NUD_TotalStuk.Size = new System.Drawing.Size(84, 20);
            this._NUD_TotalStuk.TabIndex = 4;
            this._NUD_TotalStuk.Text = "0,00";
            this._NUD_TotalStuk.MouseClick += new System.Windows.Forms.MouseEventHandler(this._NUD_TotalStuk_MouseClick);
            this._NUD_TotalStuk.TextChanged += new System.EventHandler(this._TB_TotaalStuk_TextChanged);
            this._NUD_TotalStuk.Enter += new System.EventHandler(this._TB_TotalStuk_Enter);
            this._NUD_TotalStuk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._TB_EenheidPrijs_KeyPress);
            this._NUD_TotalStuk.Leave += new System.EventHandler(this._TB_TotaalStuk_Leave);
            // 
            // KostenControler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this._NUD_TotalStuk);
            this.Controls.Add(this._NUD_EenheidPrijs);
            this.Controls.Add(this._CB_indicatie);
            this.Controls.Add(this._L_indicatie);
            this.Controls.Add(this._L_BTW);
            this.Controls.Add(this._RB_9);
            this.Controls.Add(this._RB_21);
            this.Controls.Add(this._TB_Eenheid);
            this.Controls.Add(this._L_Sluiten);
            this.Controls.Add(this._L_IDkosten);
            this.Controls.Add(this._L_Eenheid);
            this.Controls.Add(this._L_Aantal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.L_Totaal);
            this.Controls.Add(this._NUD_Totaal);
            this.Controls.Add(this._L_EenheidPrijs);
            this.Controls.Add(this._TB_Kosten);
            this.Controls.Add(this.L_Kosten);
            this.MaximumSize = new System.Drawing.Size(9999, 55);
            this.MinimumSize = new System.Drawing.Size(720, 55);
            this.Name = "KostenControler";
            this.Size = new System.Drawing.Size(816, 51);
            this.Load += new System.EventHandler(this.KostenControler_Load);
            ((System.ComponentModel.ISupportInitialize)(this._NUD_Totaal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label L_Kosten;
        private System.Windows.Forms.Label _L_EenheidPrijs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label L_Totaal;
        private System.Windows.Forms.Label _L_Aantal;
        private System.Windows.Forms.Label _L_Eenheid;
        public System.Windows.Forms.Label _L_IDkosten;
        public System.Windows.Forms.TextBox _TB_Kosten;
        public System.Windows.Forms.NumericUpDown _NUD_Totaal;
        public System.Windows.Forms.Label _L_Sluiten;
        public System.Windows.Forms.ComboBox _TB_Eenheid;
        private System.Windows.Forms.Label _L_BTW;
        public System.Windows.Forms.RadioButton _RB_21;
        public System.Windows.Forms.RadioButton _RB_9;
        private System.Windows.Forms.Label _L_indicatie;
        public System.Windows.Forms.CheckBox _CB_indicatie;
        public System.Windows.Forms.TextBox _NUD_EenheidPrijs;
        public System.Windows.Forms.TextBox _NUD_TotalStuk;
    }
}
