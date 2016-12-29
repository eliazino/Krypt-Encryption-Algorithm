using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.IO;

namespace Krypt
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
           //string path = @"depence\bins\maths\strApps\Decryptor.exe";
           //string path = @"C:\Users\waheed\Downloads\Documents\MATLAB\maths\scriptsfolder\encryptor\distrib\encryptor.exe";
           //ProcessStartInfo startInfo = new ProcessStartInfo();
           //startInfo.CreateNoWindow = false;
           //startInfo.UseShellExecute = false;
           //startInfo.FileName = path;
           //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
           //startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y " + ex2;
          // Process.Start(startInfo);
           //bool boolV = true; 
           //while (boolV)
           //{
           //    // Omit the exe part.

           //    Process[] setup = Process.GetProcessesByName("decryptor");
           //    //Console.WriteLine("{0} chrome processes", chromes.Length);
           //    if (setup.Length >= 1)
           //    {
           //        Thread.Sleep(3000);
           //        boolV = false;
           //    }

           //}
            //this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {   
                Krypt kt = new Krypt();
                kt.Show();
                Form3 ji = new Form3();
                ji.WindowState = FormWindowState.Minimized;
                
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Form2 fr = new Form2();
            fr.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            label6.Text = "Please wait...";
            Thread.Sleep(1000);
            string pathT = @"depence\bins\maths\strApps\Decryptor.exe";
            Process startInf = new Process();
            //startInf.CreateNoWindow = false;
            //startInfo.UseShellExecute = false;
            startInf.StartInfo.FileName = pathT;
            startInf.StartInfo.Verb = "runas";
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y " + ex2;

            if (File.Exists(pathT))
            {
                startInf.Start();
                bool v = true;
                while (v)
                {
                    // Omit the exe part.
                    Process[] setup = Process.GetProcessesByName("Decryptor");
                    //Console.WriteLine("{0} chrome processes", chromes.Length);
                    Thread.Sleep(10000);
                    if (setup.Length >= 1)
                    {
                        label6.Text = "Done";
                        if (checkBox1.Checked == true)
                        {
                            Form3 ji = new Form3();
                            ji.WindowState = FormWindowState.Minimized;

                        }
                        v = false;
                    }

                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label6.Text = "Please wait...";
            label1.Text = "Recieved";
            Form3 jop = new Form3();
            jop.Cursor = Cursors.AppStarting;
            //button2.Enabled = false;
            string pathT = @"depence\bins\maths\strApps\Decryptor.exe";
            Process startInf = new Process();
            //startInf.CreateNoWindow = false;
            //startInfo.UseShellExecute = false;
            startInf.StartInfo.FileName = pathT;
            startInf.StartInfo.Verb = "runas";
            //startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            //startInfo.Arguments = "-f j -o \"" + ex1 + "\" -z 1.0 -s y " + ex2;
            label6.Text = "Please wait...";
            if (File.Exists(pathT))
            {
                label6.Text = "Please wait...";
                bool v = true;
                while (v)
                {
                    // Omit the exe part.
                    Process[] setup = Process.GetProcessesByName("Decryptor");
                    //Console.WriteLine("{0} chrome processes", chromes.Length);
                    Thread.Sleep(2000);
                    if (setup.Length >= 1)
                    {
                        MessageBox.Show("Application Was started", "Information",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        label6.Text = "Done";
                        if (checkBox1.Checked == true)
                        {
                            Form3 ji = new Form3();
                            ji.WindowState = FormWindowState.Minimized;

                        }
                        v = false;
                    }
                    else
                    {
                        startInf.Start();
                    }

                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                Krypt kt = new Krypt();
                kt.Show();
                Form3 ji = new Form3();
                ji.WindowState = FormWindowState.Minimized;

            }
        }
    }
}
