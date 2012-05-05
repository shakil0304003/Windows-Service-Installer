using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Security;

namespace Installer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string a = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\sc.exe");
            string path = Directory.GetCurrentDirectory();
            path += @"\SycapCRMWindowsService.exe";
            try
            {
                System.Diagnostics.ProcessStartInfo si = new System.Diagnostics.ProcessStartInfo("cmd");

                si.RedirectStandardInput = true;

                si.RedirectStandardOutput = true;

                si.RedirectStandardError = true;

                si.UseShellExecute = false;

                si.CreateNoWindow = true;

                si.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

                System.Diagnostics.Process console = System.Diagnostics.Process.Start(si);
                for (int i = 0; i < 100; i++)
                    console.StandardInput.WriteLine("cd..");

                string command = a + " create SycapCRMWindowsService  binPath= \"" + path + "\"";

                console.StandardInput.WriteLine(command);
                MessageBox.Show("Sycap CRM Service has successfully been installed.");
            }
            catch (Exception objException)
            {
                MessageBox.Show(objException.Message.ToString());
            }
            this.Close();
        }
    }
}
