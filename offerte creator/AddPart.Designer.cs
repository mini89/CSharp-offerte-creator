namespace offerte_creator
{
    partial class AddPart
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPart));
            this.BT_Toevoegen = new System.Windows.Forms.Button();
            this.L_PartName = new System.Windows.Forms.Label();
            this.TB_PartName = new System.Windows.Forms.TextBox();
            this.GB_Kosten = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this._BT_Calculator = new System.Windows.Forms.Button();
            this._BT_Cancel = new System.Windows.Forms.Button();
            this._NUD_TotalPart = new System.Windows.Forms.NumericUpDown();
            this._L_TotalPart = new System.Windows.Forms.Label();
            this._L_IDPart = new System.Windows.Forms.Label();
            this.BT_AddRow = new System.Windows.Forms.Button();
            this.GB_Kosten_box = new System.Windows.Forms.GroupBox();
            this._P_Kosten = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._NUD_TotalPart)).BeginInit();
            this.GB_Kosten_box.SuspendLayout();
            this.SuspendLayout();
            // 
            // BT_Toevoegen
            // 
            this.BT_Toevoegen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_Toevoegen.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.BT_Toevoegen.Location = new System.Drawing.Point(637, 31);
            this.BT_Toevoegen.Name = "BT_Toevoegen";
            this.BT_Toevoegen.Size = new System.Drawing.Size(75, 23);
            this.BT_Toevoegen.TabIndex = 999;
            this.BT_Toevoegen.Text = "Toevoegen";
            this.BT_Toevoegen.UseVisualStyleBackColor = true;
            this.BT_Toevoegen.Click += new System.EventHandler(this.BT_Toevoegen_Click);
            // 
            // L_PartName
            // 
            this.L_PartName.AutoSize = true;
            this.L_PartName.Location = new System.Drawing.Point(12, 15);
            this.L_PartName.Name = "L_PartName";
            this.L_PartName.Size = new System.Drawing.Size(91, 13);
            this.L_PartName.TabIndex = 1;
            this.L_PartName.Text = "Onderdeel naam :";
            // 
            // TB_PartName
            // 
            this.TB_PartName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_PartName.Location = new System.Drawing.Point(110, 12);
            this.TB_PartName.Name = "TB_PartName";
            this.TB_PartName.Size = new System.Drawing.Size(602, 20);
            this.TB_PartName.TabIndex = 0;
            this.TB_PartName.TextChanged += new System.EventHandler(this.TB_PartName_TextChanged);
            // 
            // GB_Kosten
            // 
            this.GB_Kosten.Location = new System.Drawing.Point(0, 0);
            this.GB_Kosten.Name = "GB_Kosten";
            this.GB_Kosten.Size = new System.Drawing.Size(200, 100);
            this.GB_Kosten.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.L_PartName);
            this.panel1.Controls.Add(this.TB_PartName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 42);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._BT_Calculator);
            this.panel2.Controls.Add(this._BT_Cancel);
            this.panel2.Controls.Add(this._NUD_TotalPart);
            this.panel2.Controls.Add(this._L_TotalPart);
            this.panel2.Controls.Add(this._L_IDPart);
            this.panel2.Controls.Add(this.BT_AddRow);
            this.panel2.Controls.Add(this.BT_Toevoegen);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 303);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(724, 58);
            this.panel2.TabIndex = 0;
            // 
            // _BT_Calculator
            // 
            this._BT_Calculator.Location = new System.Drawing.Point(12, 31);
            this._BT_Calculator.Name = "_BT_Calculator";
            this._BT_Calculator.Size = new System.Drawing.Size(92, 23);
            this._BT_Calculator.TabIndex = 1001;
            this._BT_Calculator.Text = "Rekenmachine";
            this._BT_Calculator.UseVisualStyleBackColor = true;
            this._BT_Calculator.Visible = false;
            this._BT_Calculator.Click += new System.EventHandler(this._BT_Calculator_Click);
            // 
            // _BT_Cancel
            // 
            this._BT_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._BT_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._BT_Cancel.Location = new System.Drawing.Point(556, 32);
            this._BT_Cancel.Name = "_BT_Cancel";
            this._BT_Cancel.Size = new System.Drawing.Size(75, 23);
            this._BT_Cancel.TabIndex = 1000;
            this._BT_Cancel.Text = "Terug";
            this._BT_Cancel.UseVisualStyleBackColor = true;
            this._BT_Cancel.Click += new System.EventHandler(this._BT_Cancel_Click);
            // 
            // _NUD_TotalPart
            // 
            this._NUD_TotalPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._NUD_TotalPart.DecimalPlaces = 2;
            this._NUD_TotalPart.Enabled = false;
            this._NUD_TotalPart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this._NUD_TotalPart.Location = new System.Drawing.Point(619, 4);
            this._NUD_TotalPart.Maximum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            0});
            this._NUD_TotalPart.Minimum = new decimal(new int[] {
            1661992959,
            1808227885,
            5,
            -2147483648});
            this._NUD_TotalPart.Name = "_NUD_TotalPart";
            this._NUD_TotalPart.ReadOnly = true;
            this._NUD_TotalPart.Size = new System.Drawing.Size(100, 20);
            this._NUD_TotalPart.TabIndex = 6;
            this._NUD_TotalPart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._NUD_TotalPart.ThousandsSeparator = true;
            this._NUD_TotalPart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // _L_TotalPart
            // 
            this._L_TotalPart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._L_TotalPart.AutoSize = true;
            this._L_TotalPart.Location = new System.Drawing.Point(494, 6);
            this._L_TotalPart.Name = "_L_TotalPart";
            this._L_TotalPart.Size = new System.Drawing.Size(119, 13);
            this._L_TotalPart.TabIndex = 5;
            this._L_TotalPart.Text = "Totaal dit onderdeel    €";
            // 
            // _L_IDPart
            // 
            this._L_IDPart.AutoSize = true;
            this._L_IDPart.Location = new System.Drawing.Point(208, 11);
            this._L_IDPart.Name = "_L_IDPart";
            this._L_IDPart.Size = new System.Drawing.Size(37, 13);
            this._L_IDPart.TabIndex = 3;
            this._L_IDPart.Text = "IDPart";
            this._L_IDPart.Visible = false;
            // 
            // BT_AddRow
            // 
            this.BT_AddRow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_AddRow.Location = new System.Drawing.Point(455, 30);
            this.BT_AddRow.MaximumSize = new System.Drawing.Size(95, 25);
            this.BT_AddRow.MinimumSize = new System.Drawing.Size(93, 23);
            this.BT_AddRow.Name = "BT_AddRow";
            this.BT_AddRow.Size = new System.Drawing.Size(95, 25);
            this.BT_AddRow.TabIndex = 998;
            this.BT_AddRow.Text = "Nieuwe kosten";
            this.BT_AddRow.UseVisualStyleBackColor = true;
            this.BT_AddRow.Click += new System.EventHandler(this.BT_AddRow_Click);
            // 
            // GB_Kosten_box
            // 
            this.GB_Kosten_box.Controls.Add(this._P_Kosten);
            this.GB_Kosten_box.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GB_Kosten_box.Location = new System.Drawing.Point(0, 42);
            this.GB_Kosten_box.Name = "GB_Kosten_box";
            this.GB_Kosten_box.Size = new System.Drawing.Size(724, 261);
            this.GB_Kosten_box.TabIndex = 5;
            this.GB_Kosten_box.TabStop = false;
            this.GB_Kosten_box.Text = "Kosten";
            // 
            // _P_Kosten
            // 
            this._P_Kosten.AutoScroll = true;
            this._P_Kosten.Dock = System.Windows.Forms.DockStyle.Fill;
            this._P_Kosten.Location = new System.Drawing.Point(3, 16);
            this._P_Kosten.Name = "_P_Kosten";
            this._P_Kosten.Size = new System.Drawing.Size(718, 242);
            this._P_Kosten.TabIndex = 0;
            // 
            // AddPart
            // 
            this.AcceptButton = this.BT_AddRow;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._BT_Cancel;
            this.ClientSize = new System.Drawing.Size(724, 361);
            this.Controls.Add(this.GB_Kosten_box);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(740, 200);
            this.Name = "AddPart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddPart";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AddPart_FormClosing);
            this.Load += new System.EventHandler(this.AddPart_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._NUD_TotalPart)).EndInit();
            this.GB_Kosten_box.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BT_Toevoegen;
        private System.Windows.Forms.Label L_PartName;
        private System.Windows.Forms.TextBox TB_PartName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BT_AddRow;
        public System.Windows.Forms.Label _L_IDPart;
        private System.Windows.Forms.Label _L_TotalPart;
        public System.Windows.Forms.NumericUpDown _NUD_TotalPart;
        public System.Windows.Forms.Panel GB_Kosten;
        private System.Windows.Forms.GroupBox GB_Kosten_box;
        public System.Windows.Forms.Panel _P_Kosten;
        private System.Windows.Forms.Button _BT_Cancel;
        public System.Windows.Forms.Button _BT_Calculator;
    }
}