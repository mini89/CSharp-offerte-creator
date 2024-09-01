namespace offerte_creator
{
    partial class PluginDownload
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
            this._LB_Plugins = new System.Windows.Forms.ListBox();
            this._RB_Details = new System.Windows.Forms.RichTextBox();
            this._BT_Back = new System.Windows.Forms.Button();
            this._BT_Install = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _LB_Plugins
            // 
            this._LB_Plugins.Dock = System.Windows.Forms.DockStyle.Top;
            this._LB_Plugins.FormattingEnabled = true;
            this._LB_Plugins.Location = new System.Drawing.Point(0, 0);
            this._LB_Plugins.Name = "_LB_Plugins";
            this._LB_Plugins.Size = new System.Drawing.Size(228, 121);
            this._LB_Plugins.TabIndex = 0;
            this._LB_Plugins.SelectedIndexChanged += new System.EventHandler(this._LB_Plugins_SelectedIndexChanged);
            // 
            // _RB_Details
            // 
            this._RB_Details.Dock = System.Windows.Forms.DockStyle.Top;
            this._RB_Details.Location = new System.Drawing.Point(0, 121);
            this._RB_Details.Name = "_RB_Details";
            this._RB_Details.Size = new System.Drawing.Size(228, 96);
            this._RB_Details.TabIndex = 1;
            this._RB_Details.Text = "";
            // 
            // _BT_Back
            // 
            this._BT_Back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._BT_Back.Location = new System.Drawing.Point(12, 226);
            this._BT_Back.Name = "_BT_Back";
            this._BT_Back.Size = new System.Drawing.Size(75, 23);
            this._BT_Back.TabIndex = 2;
            this._BT_Back.Text = "Terug";
            this._BT_Back.UseVisualStyleBackColor = true;
            this._BT_Back.Click += new System.EventHandler(this._BT_Back_Click);
            // 
            // _BT_Install
            // 
            this._BT_Install.Enabled = false;
            this._BT_Install.Location = new System.Drawing.Point(141, 226);
            this._BT_Install.Name = "_BT_Install";
            this._BT_Install.Size = new System.Drawing.Size(75, 23);
            this._BT_Install.TabIndex = 3;
            this._BT_Install.Text = "Installeren";
            this._BT_Install.UseVisualStyleBackColor = true;
            this._BT_Install.Click += new System.EventHandler(this._BT_Install_Click);
            // 
            // PluginDownload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(228, 261);
            this.Controls.Add(this._BT_Install);
            this.Controls.Add(this._BT_Back);
            this.Controls.Add(this._RB_Details);
            this.Controls.Add(this._LB_Plugins);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PluginDownload";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PluginDownload";
            this.Load += new System.EventHandler(this.PluginDownload_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox _LB_Plugins;
        private System.Windows.Forms.RichTextBox _RB_Details;
        private System.Windows.Forms.Button _BT_Back;
        private System.Windows.Forms.Button _BT_Install;
    }
}