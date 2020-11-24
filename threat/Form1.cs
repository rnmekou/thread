using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace threat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "Notepad";
            process.Start();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "Notepad";
            process.Start();
            process.WaitForInputIdle();
            Thread.Sleep(5000);
            if (!process.CloseMainWindow())
            {
                process.Kill();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            const int ERROR_FILE_NOT_FOUND = 2;
            const int ERROR_ACCESS_DENIED = 5;
            Process myProcess = new Process();
            try
            {
                // Get the path that stores user documents.
                string myDocumentsPath
                =
                Environment.GetFolderPath
                (Environment.SpecialFolder.Personal);
                myProcess.StartInfo.FileName = myDocumentsPath + "\\Document.txt";
                myProcess.StartInfo.Verb = "Print";
                myProcess.StartInfo.CreateNoWindow = true
                ;
                myProcess.Start();
            }
            catch (Win32Exception ex)
            {
                if (ex.NativeErrorCode == ERROR_FILE_NOT_FOUND)
                {
                    String msg = ex.Message + ". Check the path.";
                    MessageBox.Show
                    (msg, "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else if (ex.NativeErrorCode == ERROR_ACCESS_DENIED)
                {
                    // Note that if your word processor might generate exceptions
                    // such as this, which are handled first.
                    String msg = ex.Message + ". Permission denied";
                    MessageBox.Show
                    (msg, "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process process = new Process();
            process.StartInfo.FileName = "Notepad";
            process.Kill();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
            }

        }
    }
}
