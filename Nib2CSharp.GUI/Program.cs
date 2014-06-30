using System;
using System.Windows.Forms;

namespace Nib2CSharp.GUI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

           
            Application.Run(new Form1());


        }

     
    }
}
