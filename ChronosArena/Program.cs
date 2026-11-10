using System;
using System.Windows.Forms;

namespace ChronosArena
{
    internal sealed class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
        	
        	System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;
        	
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}