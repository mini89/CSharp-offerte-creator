namespace offerte_creator
{
    partial class PartsController
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
            this.L_PartsCount = new System.Windows.Forms.Label();
            this._TB_countParts = new System.Windows.Forms.TextBox();
            this.L_Totaal = new System.Windows.Forms.Label();
            this._L_PartsName = new System.Windows.Forms.Label();
            this._NUB_Totaal = new System.Windows.Forms.NumericUpDown();
            this._L_Sluiten = new System.Windows.Forms.Label();
            this._L_IDparts = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this._NUB_Totaal)).BeginInit();
            this.SuspendLayout();
            // 
            // L_PartsCount
            // 
            this.L_PartsCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_PartsCount.AutoSize = true;
            this.L_PartsCount.Location = new System.Drawing.Point(203, 8);
            this.L_PartsCount.Name = "L_PartsCount";
            this.L_PartsCount.Size = new System.Drawing.Size(102, 13);
            this.L_PartsCount.TabIndex = 1;
            this.L_PartsCount.Text = "Aantal onderdelen : ";
            this.L_PartsCount.DoubleClick += new System.EventHandler(this._BT_Edit_Click);
            // 
            // _TB_countParts
            // 
            this._TB_countParts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._TB_countParts.Location = new System.Drawing.Point(311, 5);
            this._TB_countParts.Name = "_TB_countParts";
            this._TB_countParts.ReadOnly = true;
            this._TB_countParts.Size = new System.Drawing.Size(24, 20);
            this._TB_countParts.TabIndex = 2;
            this._TB_countParts.DoubleClick += new System.EventHandler(this._BT_Edit_Click);
            // 
            // L_Totaal
            // 
            this.L_Totaal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Totaal.AutoSize = true;
            this.L_Totaal.Location = new System.Drawing.Point(341, 8);
            this.L_Totaal.Name = "L_Totaal";
            this.L_Totaal.Size = new System.Drawing.Size(83, 13);
            this.L_Totaal.TabIndex = 3;
            this.L_Totaal.Text = "Totaal Prijs :    €";
            this.L_Totaal.DoubleClick += new System.EventHandler(this._BT_Edit_Click);
            // 
            // _L_PartsName
            // 
            this._L_PartsName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._L_PartsName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this._L_PartsName.Location = new System.Drawing.Point(15, 0);
            this._L_PartsName.Name = "_L_PartsName";
            this._L_PartsName.Size = new System.Drawing.Size(127, 28);
            this._L_PartsName.TabIndex = 0;
            this._L_PartsName.Text = "Onderdeel naam";
            this._L_PartsName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._L_PartsName.DoubleClick += new System.EventHandler(this._BT_Edit_Click);
            // 
            // _NUB_Totaal
            // 
            this._NUB_Totaal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._NUB_Totaal.DecimalPlaces = 2;
            this._NUB_Totaal.Enabled = false;
            this._NUB_Totaal.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._NUB_Totaal.Location = new System.Drawing.Point(430, 6);
            this._NUB_Totaal.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this._NUB_Totaal.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this._NUB_Totaal.Name = "_NUB_Totaal";
            this._NUB_Totaal.ReadOnly = true;
            this._NUB_Totaal.Size = new System.Drawing.Size(71, 20);
            this._NUB_Totaal.TabIndex = 6;
            this._NUB_Totaal.ThousandsSeparator = true;
            this._NUB_Totaal.Scroll += new System.Windows.Forms.ScrollEventHandler(this._NUB_Totaal_Scroll);
            this._NUB_Totaal.DoubleClick += new System.EventHandler(this._BT_Edit_Click);
            // 
            // _L_Sluiten
            // 
            this._L_Sluiten.BackColor = System.Drawing.Color.DarkRed;
            this._L_Sluiten.Dock = System.Windows.Forms.DockStyle.Left;
            this._L_Sluiten.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._L_Sluiten.ForeColor = System.Drawing.Color.White;
            this._L_Sluiten.Location = new System.Drawing.Point(0, 0);
            this._L_Sluiten.MaximumSize = new System.Drawing.Size(15, 50);
            this._L_Sluiten.MinimumSize = new System.Drawing.Size(15, 15);
            this._L_Sluiten.Name = "_L_Sluiten";
            this._L_Sluiten.Size = new System.Drawing.Size(15, 28);
            this._L_Sluiten.TabIndex = 14;
            this._L_Sluiten.Text = "X";
            this._L_Sluiten.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this._L_Sluiten.Click += new System.EventHandler(this._L_Sluiten_Click);
            // 
            // _L_IDparts
            // 
            this._L_IDparts.AutoSize = true;
            this._L_IDparts.Location = new System.Drawing.Point(148, 5);
            this._L_IDparts.Name = "_L_IDparts";
            this._L_IDparts.Size = new System.Drawing.Size(42, 13);
            this._L_IDparts.TabIndex = 15;
            this._L_IDparts.Text = "IDParts";
            this._L_IDparts.Visible = false;
            // 
            // PartsController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this._L_IDparts);
            this.Controls.Add(this._L_PartsName);
            this.Controls.Add(this._NUB_Totaal);
            this.Controls.Add(this.L_Totaal);
            this.Controls.Add(this._TB_countParts);
            this.Controls.Add(this.L_PartsCount);
            this.Controls.Add(this._L_Sluiten);
            this.MinimumSize = new System.Drawing.Size(500, 30);
            this.Name = "PartsController";
            this.Size = new System.Drawing.Size(500, 28);
            this.Load += new System.EventHandler(this.PartsController_Load);
            this.DoubleClick += new System.EventHandler(this._BT_Edit_Click);
            ((System.ComponentModel.ISupportInitialize)(this._NUB_Totaal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label L_PartsCount;
        private System.Windows.Forms.Label L_Totaal;
        public System.Windows.Forms.TextBox _TB_countParts;
        public System.Windows.Forms.Label _L_PartsName;
        public System.Windows.Forms.NumericUpDown _NUB_Totaal;
        public System.Windows.Forms.Label _L_Sluiten;
        public System.Windows.Forms.Label _L_IDparts;
    }
}
