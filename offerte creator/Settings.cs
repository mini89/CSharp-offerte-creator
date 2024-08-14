using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace offerte_creator
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }
        String pathDocuments;
        Boolean replace = false;
        public Form_Main formMain;
        private void Settings_Load(object sender, EventArgs e)
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            this.Text = "Offerte creator versie " + version;
            pathDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (!Directory.Exists(pathDocuments + "\\offerte creator\\image\\"))
            {
                Directory.CreateDirectory(pathDocuments + "\\offerte creator\\image\\");
            }
            _TB_CompanyName.Text = Properties.Settings.Default.CompanyName;
            try
            {
                String extentie=null;
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\logo.png"))
                    extentie = ".png";
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\logo.jpg"))
                    extentie = ".jpg";
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\logo.gif"))
                    extentie = ".gif";
                String imageFolder = pathDocuments + "\\offerte creator\\image\\logo" + extentie;
                if (File.Exists(imageFolder))
                {
                    _PB_Logo.Image = Image.FromFile(imageFolder);
                    _PB_Logo.ImageLocation = imageFolder;
                }
                else
                {
                    _PB_Logo.BackColor = Color.Maroon;
                    _L_Dubble_Logo.Visible = true;
                }
            }
            finally { }
            try
            {
                String extentie = null;
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\watermark.png"))
                    extentie = ".png";
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\watermark.jpg"))
                    extentie = ".jpg";
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\watermark.gif"))
                    extentie = ".gif";
                String imageFolder = pathDocuments + "\\offerte creator\\image\\watermark" + extentie;
                if (File.Exists(imageFolder))
                {
                    _PB_Watermark.Image = Image.FromFile(imageFolder);
                    _PB_Watermark.ImageLocation = imageFolder;
                }
                else
                {
                    _PB_Watermark.BackColor = Color.Maroon;
                    _L_Dubble_Watermark.Visible = true;
                }
            }
            finally { }
            try
            {
                String extentie = null;
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\handtekening.png"))
                    extentie = ".png";
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\handtekening.jpg"))
                    extentie = ".jpg";
                if (File.Exists(pathDocuments + "\\offerte creator\\image\\handtekening.gif"))
                    extentie = ".gif";
                String imageFolder = pathDocuments + "\\offerte creator\\image\\handtekening" + extentie;
                if (File.Exists(imageFolder))
                {
                    _PB_Handtekening.Image = Image.FromFile(imageFolder);
                    _PB_Handtekening.ImageLocation = imageFolder;
                }
                else
                {
                    _PB_Handtekening.BackColor = Color.Maroon;
                    _L_Dubble_Handtekening.Visible = true;
                }
            }
            finally { }
            LoadPlugins();


        }
        private void StopPlugins()
        {
            foreach (var plugin in formMain._plugins)
            {
                plugin.Stop();
            }
            formMain._plugins.Clear(); // Optioneel: leeg de lijst met plugins na stoppen
        }
        private void LoadPlugins()
        {
            string pluginsPath = Path.Combine(pathDocuments+ "\\offerte creator\\", "Plugins");          

            var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                var assembly = Assembly.LoadFile(file);
                var pluginTypes = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);

                foreach (var type in pluginTypes)
                {
                    var plugin = (IPlugin)Activator.CreateInstance(type);
                    LB_Plugins.Items.Add(plugin.Name+" ("+plugin.Version+")");
                }
            }
        }
        private void _BT_Save_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.CompanyName = _TB_CompanyName.Text;
            Properties.Settings.Default.Save();

            replace = true;



        }

        private void Dubbel_Click_Logo(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if(result == DialogResult.OK)
            {
                _PB_Logo.Image = Image.FromFile(openFileDialog1.FileName);
                _PB_Logo.ImageLocation = openFileDialog1.FileName;
                _PB_Logo.BackColor = Color.White;
                _L_Dubble_Logo.Visible = false;
            }
        }

        private void Dubbel_Click_Watermark(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _PB_Watermark.Image = Image.FromFile(openFileDialog1.FileName);
                _PB_Watermark.ImageLocation = openFileDialog1.FileName;
                _PB_Watermark.BackColor = Color.White;
                _L_Dubble_Watermark.Visible = false;
            }

        }

        private void Dubbel_Click_Handtekening(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                _PB_Handtekening.Image = Image.FromFile(openFileDialog1.FileName);
                _PB_Handtekening.ImageLocation = openFileDialog1.FileName;
                _PB_Handtekening.BackColor = Color.White;
                _L_Dubble_Handtekening.Visible = false;
            }

        }

        private void _PB_Logo_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                _PB_Logo.InitialImage = null;
                _PB_Logo.Image.Dispose();
                _PB_Logo.Image = null;
                _PB_Logo.Update();

                File.Delete(_PB_Logo.ImageLocation);
            }
        }

        private void Settings_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (replace) {
                _PB_Handtekening.Image = null;
                _PB_Handtekening.InitialImage = null;
                _PB_Logo.Image = null;
                _PB_Logo.InitialImage = null;
                _PB_Watermark.Image = null;
                _PB_Watermark.InitialImage = null;
                String extentie = null;
            String[] files = new String[] { "logo", "watermark", "handtekening" };
            PictureBox[] MyObjects = new PictureBox[] { _PB_Logo, _PB_Watermark, _PB_Handtekening };
                for (int i = 0; i < files.Length; i++)
                {
                    Boolean exist = false;
                    try
                    {
                        if (File.Exists(pathDocuments + "\\offerte creator\\image\\" + files[i] + ".png"))
                        {
                            extentie = ".png";
                            exist = true;
                        }
                        else
                        {
                            if (File.Exists(pathDocuments + "\\offerte creator\\image\\" + files[i] + ".jpg"))
                            {
                                extentie = ".jpg";
                                exist = true;
                            }
                            else
                            {
                                if (File.Exists(pathDocuments + "\\offerte creator\\image\\" + files[i] + ".gif"))
                                {
                                    extentie = ".gif";
                                    exist = true;
                                }
                            }
                        }
                    }
                    finally { }
                    if (exist)
                    {
                        if (MyObjects[i].ImageLocation == pathDocuments + "\\offerte creator\\image\\" + files[i] + extentie)
                        {
                        }
                        else
                        {
                            File.Replace(MyObjects[i].ImageLocation, pathDocuments + "\\offerte creator\\image\\" + files[i] + extentie, pathDocuments + "\\offerte creator\\image\\",true);
                        }
                    }
                    else
                    {
                        File.Copy(MyObjects[i].ImageLocation, pathDocuments + "\\offerte creator\\image\\" + files[i] + Path.GetExtension(MyObjects[i].ImageLocation));
                    }
                }
            }            
        }

        private void bt_resetEenheidList_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Eenheid_Data = "st|m2";
            Properties.Settings.Default.Save();
            MessageBox.Show( "Alle eenheden zij gereset", "Reset Eenheden", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        int IndexPlugIn;
        private void LB_Plugins_SelectedIndexChanged(object sender, EventArgs e)
        {
            _BT_RemovePlugIn.Enabled = true;
            IndexPlugIn = LB_Plugins.SelectedIndex;
        }

        private void LB_Plugins_Leave(object sender, EventArgs e)
        {
            if(!_BT_RemovePlugIn.Focused)
            _BT_RemovePlugIn.Enabled = false;
        }

        private void _BT_RemovePlugIn_Click(object sender, EventArgs e)
        {
            StopPlugins();
            string pluginsPath = Path.Combine(pathDocuments+ "\\offerte creator\\", "Plugins");
            var pluginFiles = Directory.GetFiles(pluginsPath, "*.dll");
            foreach (var file in pluginFiles)
            {
                var assembly = Assembly.LoadFile(file);
                var pluginTypes = assembly.GetTypes().Where(t => typeof(IPlugin).IsAssignableFrom(t) && !t.IsInterface);

                foreach (var type in pluginTypes)
                {
                    var plugin = (IPlugin)Activator.CreateInstance(type);
                    if (plugin.Name.Trim().Equals(LB_Plugins.Items[IndexPlugIn].ToString().Split('(')[0].Trim()))
                    {
                     DialogResult result = MessageBox.Show("Weet u zeker dat u "+ LB_Plugins.Items[IndexPlugIn].ToString().Split('(')[0].Trim()+ " Wilt verwijderen", "Verwijder Plugin " + LB_Plugins.Items[IndexPlugIn].ToString().Split('(')[0],MessageBoxButtons.YesNo,MessageBoxIcon.Information,MessageBoxDefaultButton.Button1);
                        if(result == DialogResult.Yes)
                        {
                            File.Delete(file);
                            LB_Plugins.Items.Clear();
                            LoadPlugins();
                        }
                    }
                }
                
            }
            _BT_RemovePlugIn.Enabled = false;
        }

        private void _BT_AddPlugIn_Click(object sender, EventArgs e)
        {
            string pluginsPath = Path.Combine(pathDocuments+ "\\offerte creator\\", "Plugins");
            DialogResult result = openFileDialogDLL.ShowDialog();
            if(result == DialogResult.OK)
            {
                string fileName = openFileDialogDLL.FileName;
                string fileNameWithoutPath = Path.GetFileName(fileName);
                if (!File.Exists(pluginsPath + "\\" + fileNameWithoutPath))
                {
                    File.Copy(fileName, pluginsPath + "\\" + fileNameWithoutPath);
                    LB_Plugins.Items.Clear();
                    LoadPlugins();
                }
                else
                    MessageBox.Show(pluginsPath + fileNameWithoutPath + " Bestaat al", "Bestaat al", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
