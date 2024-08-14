namespace offerte_creator
{
    partial class Settings
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
            this._PB_Logo = new System.Windows.Forms.PictureBox();
            this._GB_Company = new System.Windows.Forms.GroupBox();
            this._L_Dubble_Handtekening = new System.Windows.Forms.Label();
            this._L_Dubble_Watermark = new System.Windows.Forms.Label();
            this._L_Dubble_Logo = new System.Windows.Forms.Label();
            this._L_Handtekening = new System.Windows.Forms.Label();
            this._PB_Handtekening = new System.Windows.Forms.PictureBox();
            this._L_Watermark = new System.Windows.Forms.Label();
            this._PB_Watermark = new System.Windows.Forms.PictureBox();
            this._L_Logo = new System.Windows.Forms.Label();
            this._TB_CompanyName = new System.Windows.Forms.TextBox();
            this._L_CompanyName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bt_resetEenheidList = new System.Windows.Forms.Button();
            this._BT_Cancel = new System.Windows.Forms.Button();
            this._BT_Save = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this._GB_Plugin = new System.Windows.Forms.GroupBox();
            this.LB_Plugins = new System.Windows.Forms.ListBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this._BT_AddPlugIn = new System.Windows.Forms.Button();
            this._BT_RemovePlugIn = new System.Windows.Forms.Button();
            this.openFileDialogDLL = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this._PB_Logo)).BeginInit();
            this._GB_Company.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PB_Handtekening)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._PB_Watermark)).BeginInit();
            this.panel1.SuspendLayout();
            this._GB_Plugin.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // _PB_Logo
            // 
            this._PB_Logo.BackColor = System.Drawing.SystemColors.Window;
            this._PB_Logo.Location = new System.Drawing.Point(15, 35);
            this._PB_Logo.Name = "_PB_Logo";
            this._PB_Logo.Size = new System.Drawing.Size(170, 89);
            this._PB_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._PB_Logo.TabIndex = 0;
            this._PB_Logo.TabStop = false;
            this._PB_Logo.DoubleClick += new System.EventHandler(this.Dubbel_Click_Logo);
            this._PB_Logo.MouseClick += new System.Windows.Forms.MouseEventHandler(this._PB_Logo_MouseClick);
            // 
            // _GB_Company
            // 
            this._GB_Company.Controls.Add(this._L_Dubble_Handtekening);
            this._GB_Company.Controls.Add(this._L_Dubble_Watermark);
            this._GB_Company.Controls.Add(this._L_Dubble_Logo);
            this._GB_Company.Controls.Add(this._L_Handtekening);
            this._GB_Company.Controls.Add(this._PB_Handtekening);
            this._GB_Company.Controls.Add(this._L_Watermark);
            this._GB_Company.Controls.Add(this._PB_Watermark);
            this._GB_Company.Controls.Add(this._L_Logo);
            this._GB_Company.Controls.Add(this._TB_CompanyName);
            this._GB_Company.Controls.Add(this._L_CompanyName);
            this._GB_Company.Controls.Add(this._PB_Logo);
            this._GB_Company.Dock = System.Windows.Forms.DockStyle.Top;
            this._GB_Company.Location = new System.Drawing.Point(0, 0);
            this._GB_Company.Name = "_GB_Company";
            this._GB_Company.Size = new System.Drawing.Size(553, 166);
            this._GB_Company.TabIndex = 1;
            this._GB_Company.TabStop = false;
            this._GB_Company.Text = "Bedrijfs gegevens";
            // 
            // _L_Dubble_Handtekening
            // 
            this._L_Dubble_Handtekening.AutoSize = true;
            this._L_Dubble_Handtekening.Location = new System.Drawing.Point(382, 72);
            this._L_Dubble_Handtekening.Name = "_L_Dubble_Handtekening";
            this._L_Dubble_Handtekening.Size = new System.Drawing.Size(138, 13);
            this._L_Dubble_Handtekening.TabIndex = 10;
            this._L_Dubble_Handtekening.Text = "Dubbel klik voor toevoegen";
            this._L_Dubble_Handtekening.Visible = false;
            this._L_Dubble_Handtekening.DoubleClick += new System.EventHandler(this.Dubbel_Click_Handtekening);
            // 
            // _L_Dubble_Watermark
            // 
            this._L_Dubble_Watermark.AutoSize = true;
            this._L_Dubble_Watermark.Location = new System.Drawing.Point(209, 72);
            this._L_Dubble_Watermark.Name = "_L_Dubble_Watermark";
            this._L_Dubble_Watermark.Size = new System.Drawing.Size(138, 13);
            this._L_Dubble_Watermark.TabIndex = 9;
            this._L_Dubble_Watermark.Text = "Dubbel klik voor toevoegen";
            this._L_Dubble_Watermark.Visible = false;
            this._L_Dubble_Watermark.DoubleClick += new System.EventHandler(this.Dubbel_Click_Watermark);
            // 
            // _L_Dubble_Logo
            // 
            this._L_Dubble_Logo.AutoSize = true;
            this._L_Dubble_Logo.Location = new System.Drawing.Point(32, 72);
            this._L_Dubble_Logo.Name = "_L_Dubble_Logo";
            this._L_Dubble_Logo.Size = new System.Drawing.Size(138, 13);
            this._L_Dubble_Logo.TabIndex = 8;
            this._L_Dubble_Logo.Text = "Dubbel klik voor toevoegen";
            this._L_Dubble_Logo.Visible = false;
            this._L_Dubble_Logo.DoubleClick += new System.EventHandler(this.Dubbel_Click_Logo);
            // 
            // _L_Handtekening
            // 
            this._L_Handtekening.AutoSize = true;
            this._L_Handtekening.Location = new System.Drawing.Point(364, 19);
            this._L_Handtekening.Name = "_L_Handtekening";
            this._L_Handtekening.Size = new System.Drawing.Size(74, 13);
            this._L_Handtekening.TabIndex = 7;
            this._L_Handtekening.Text = "Handtekening";
            // 
            // _PB_Handtekening
            // 
            this._PB_Handtekening.BackColor = System.Drawing.SystemColors.Window;
            this._PB_Handtekening.Location = new System.Drawing.Point(367, 35);
            this._PB_Handtekening.Name = "_PB_Handtekening";
            this._PB_Handtekening.Size = new System.Drawing.Size(170, 89);
            this._PB_Handtekening.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._PB_Handtekening.TabIndex = 6;
            this._PB_Handtekening.TabStop = false;
            this._PB_Handtekening.DoubleClick += new System.EventHandler(this.Dubbel_Click_Handtekening);
            // 
            // _L_Watermark
            // 
            this._L_Watermark.AutoSize = true;
            this._L_Watermark.Location = new System.Drawing.Point(188, 19);
            this._L_Watermark.Name = "_L_Watermark";
            this._L_Watermark.Size = new System.Drawing.Size(59, 13);
            this._L_Watermark.TabIndex = 5;
            this._L_Watermark.Text = "Watermerk";
            // 
            // _PB_Watermark
            // 
            this._PB_Watermark.BackColor = System.Drawing.SystemColors.Window;
            this._PB_Watermark.Location = new System.Drawing.Point(191, 35);
            this._PB_Watermark.Name = "_PB_Watermark";
            this._PB_Watermark.Size = new System.Drawing.Size(170, 89);
            this._PB_Watermark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this._PB_Watermark.TabIndex = 4;
            this._PB_Watermark.TabStop = false;
            this._PB_Watermark.DoubleClick += new System.EventHandler(this.Dubbel_Click_Watermark);
            // 
            // _L_Logo
            // 
            this._L_Logo.AutoSize = true;
            this._L_Logo.Location = new System.Drawing.Point(12, 19);
            this._L_Logo.Name = "_L_Logo";
            this._L_Logo.Size = new System.Drawing.Size(31, 13);
            this._L_Logo.TabIndex = 3;
            this._L_Logo.Text = "Logo";
            // 
            // _TB_CompanyName
            // 
            this._TB_CompanyName.Location = new System.Drawing.Point(91, 136);
            this._TB_CompanyName.Name = "_TB_CompanyName";
            this._TB_CompanyName.Size = new System.Drawing.Size(100, 20);
            this._TB_CompanyName.TabIndex = 2;
            // 
            // _L_CompanyName
            // 
            this._L_CompanyName.AutoSize = true;
            this._L_CompanyName.Location = new System.Drawing.Point(12, 139);
            this._L_CompanyName.Name = "_L_CompanyName";
            this._L_CompanyName.Size = new System.Drawing.Size(73, 13);
            this._L_CompanyName.TabIndex = 1;
            this._L_CompanyName.Text = "Bedrijfsnaam :";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bt_resetEenheidList);
            this.panel1.Controls.Add(this._BT_Cancel);
            this.panel1.Controls.Add(this._BT_Save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 348);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(553, 33);
            this.panel1.TabIndex = 2;
            // 
            // bt_resetEenheidList
            // 
            this.bt_resetEenheidList.Location = new System.Drawing.Point(84, 3);
            this.bt_resetEenheidList.Name = "bt_resetEenheidList";
            this.bt_resetEenheidList.Size = new System.Drawing.Size(129, 23);
            this.bt_resetEenheidList.TabIndex = 3;
            this.bt_resetEenheidList.Text = "Reset eenheid lijst";
            this.bt_resetEenheidList.UseVisualStyleBackColor = true;
            this.bt_resetEenheidList.Click += new System.EventHandler(this.bt_resetEenheidList_Click);
            // 
            // _BT_Cancel
            // 
            this._BT_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._BT_Cancel.Location = new System.Drawing.Point(3, 3);
            this._BT_Cancel.Name = "_BT_Cancel";
            this._BT_Cancel.Size = new System.Drawing.Size(75, 23);
            this._BT_Cancel.TabIndex = 1;
            this._BT_Cancel.Text = "Terug";
            this._BT_Cancel.UseVisualStyleBackColor = true;
            // 
            // _BT_Save
            // 
            this._BT_Save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._BT_Save.Location = new System.Drawing.Point(475, 3);
            this._BT_Save.Name = "_BT_Save";
            this._BT_Save.Size = new System.Drawing.Size(75, 23);
            this._BT_Save.TabIndex = 0;
            this._BT_Save.Text = "Opslaan";
            this._BT_Save.UseVisualStyleBackColor = true;
            this._BT_Save.Click += new System.EventHandler(this._BT_Save_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image File(JPG,PNG,GIF)|*.JPG;*.PNG;*.GIF;";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // _GB_Plugin
            // 
            this._GB_Plugin.Controls.Add(this.LB_Plugins);
            this._GB_Plugin.Controls.Add(this.panel2);
            this._GB_Plugin.Dock = System.Windows.Forms.DockStyle.Top;
            this._GB_Plugin.Location = new System.Drawing.Point(0, 166);
            this._GB_Plugin.Name = "_GB_Plugin";
            this._GB_Plugin.Size = new System.Drawing.Size(553, 141);
            this._GB_Plugin.TabIndex = 4;
            this._GB_Plugin.TabStop = false;
            this._GB_Plugin.Text = "Plugin\'s";
            // 
            // LB_Plugins
            // 
            this.LB_Plugins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LB_Plugins.FormattingEnabled = true;
            this.LB_Plugins.Location = new System.Drawing.Point(3, 16);
            this.LB_Plugins.Name = "LB_Plugins";
            this.LB_Plugins.Size = new System.Drawing.Size(547, 93);
            this.LB_Plugins.TabIndex = 0;
            this.LB_Plugins.SelectedIndexChanged += new System.EventHandler(this.LB_Plugins_SelectedIndexChanged);
            this.LB_Plugins.Leave += new System.EventHandler(this.LB_Plugins_Leave);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._BT_AddPlugIn);
            this.panel2.Controls.Add(this._BT_RemovePlugIn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 109);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(547, 29);
            this.panel2.TabIndex = 5;
            // 
            // _BT_AddPlugIn
            // 
            this._BT_AddPlugIn.Dock = System.Windows.Forms.DockStyle.Right;
            this._BT_AddPlugIn.Location = new System.Drawing.Point(472, 0);
            this._BT_AddPlugIn.Name = "_BT_AddPlugIn";
            this._BT_AddPlugIn.Size = new System.Drawing.Size(75, 29);
            this._BT_AddPlugIn.TabIndex = 1;
            this._BT_AddPlugIn.Text = "Toevoegen";
            this._BT_AddPlugIn.UseVisualStyleBackColor = true;
            this._BT_AddPlugIn.Click += new System.EventHandler(this._BT_AddPlugIn_Click);
            // 
            // _BT_RemovePlugIn
            // 
            this._BT_RemovePlugIn.Dock = System.Windows.Forms.DockStyle.Left;
            this._BT_RemovePlugIn.Enabled = false;
            this._BT_RemovePlugIn.Location = new System.Drawing.Point(0, 0);
            this._BT_RemovePlugIn.Name = "_BT_RemovePlugIn";
            this._BT_RemovePlugIn.Size = new System.Drawing.Size(75, 29);
            this._BT_RemovePlugIn.TabIndex = 0;
            this._BT_RemovePlugIn.Text = "Verwijderen";
            this._BT_RemovePlugIn.UseVisualStyleBackColor = true;
            this._BT_RemovePlugIn.Click += new System.EventHandler(this._BT_RemovePlugIn_Click);
            // 
            // openFileDialogDLL
            // 
            this.openFileDialogDLL.Filter = "Plugin(DLL)|*.DLL;";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 381);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._GB_Plugin);
            this.Controls.Add(this._GB_Company);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Settings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Instellingen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Settings_FormClosed);
            this.Load += new System.EventHandler(this.Settings_Load);
            ((System.ComponentModel.ISupportInitialize)(this._PB_Logo)).EndInit();
            this._GB_Company.ResumeLayout(false);
            this._GB_Company.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PB_Handtekening)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._PB_Watermark)).EndInit();
            this.panel1.ResumeLayout(false);
            this._GB_Plugin.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox _PB_Logo;
        private System.Windows.Forms.GroupBox _GB_Company;
        private System.Windows.Forms.TextBox _TB_CompanyName;
        private System.Windows.Forms.Label _L_CompanyName;
        private System.Windows.Forms.Label _L_Handtekening;
        private System.Windows.Forms.PictureBox _PB_Handtekening;
        private System.Windows.Forms.Label _L_Watermark;
        private System.Windows.Forms.PictureBox _PB_Watermark;
        private System.Windows.Forms.Label _L_Logo;
        private System.Windows.Forms.Label _L_Dubble_Handtekening;
        private System.Windows.Forms.Label _L_Dubble_Watermark;
        private System.Windows.Forms.Label _L_Dubble_Logo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _BT_Cancel;
        private System.Windows.Forms.Button _BT_Save;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button bt_resetEenheidList;
        private System.Windows.Forms.GroupBox _GB_Plugin;
        private System.Windows.Forms.ListBox LB_Plugins;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _BT_AddPlugIn;
        private System.Windows.Forms.Button _BT_RemovePlugIn;
        private System.Windows.Forms.OpenFileDialog openFileDialogDLL;
    }
}