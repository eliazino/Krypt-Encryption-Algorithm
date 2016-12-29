using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Diagnostics;

namespace Krypt
{
    public partial class Krypt : Form
    {
        public Krypt()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox3_KeyUp(object sender, KeyEventArgs e)
        {            
            string txt = richTextBox3.Text;
            int sh = txt.Length;
            int tErr = 0;
            if (sh < 1)
            {
            }
            else
            {
                string[] supported = { "!", " ", "|", @"\", "¬", "`", "\"", "£", "$", "%", "^", "&", "*", "(", ")", "_", "-", "+", "=", "{", "}", "[", "]", ":", ";", "@", "'", "~", "#", "<", ",", ".", ">", "?", "/", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "\n" };
                int found = 0;
                int start = 0;
                int startT = 0;
                string used = "";
                int errLog = 0;
                bool cont = true;
                if (sh < 120)
                {
                    label3.Text = sh.ToString();
                    richTextBox3.BackColor = System.Drawing.Color.White;
                    richTextBox3.ForeColor = System.Drawing.Color.ForestGreen;
                }
                else if (sh >= 120 && sh <= 160)
                {
                    label3.Text = sh.ToString();
                    label3.ForeColor = System.Drawing.Color.Maroon;

                    richTextBox3.BackColor = System.Drawing.Color.White;
                    richTextBox3.ForeColor = System.Drawing.Color.ForestGreen;
                }
                else
                {
                    //string color;
                    richTextBox2.Text = richTextBox2.Text + "Characters cannot be more than 160 \n";
                    richTextBox2.SelectionStart = richTextBox2.Text.Length;
                    richTextBox2.ScrollToCaret();
                    richTextBox3.BackColor = System.Drawing.Color.Maroon;
                    richTextBox3.ForeColor = System.Drawing.Color.White;
                    int hi = sh - 160;
                    label3.Text = "-"+hi.ToString();
                    cont = false;
                }
                if (cont == true)
                {
                    while (startT < sh)
                    {
                        string latest = txt.Substring(startT, 1);
                        while (start < supported.Length)
                        {
                            string cons = supported[start];
                            if (latest == cons)
                            {
                                found = 1;
                                break;
                            }
                            else
                            {
                                found = 0;
                            }

                            start++;
                        }
                        if (found == 0)
                        {
                            tErr = 1;
                            errLog = startT + 1;
                            used = txt.Substring(startT, 1);
                            richTextBox3.ForeColor = System.Drawing.Color.Maroon;
                            richTextBox2.Text = richTextBox2.Text + "Instance: One or more character was reported. see " + used + " character " + errLog + "\n";
                            richTextBox2.SelectionStart = richTextBox2.Text.Length;
                            richTextBox2.ScrollToCaret();
                        }
                        else
                        {
                        }
                        start = 0;
                        startT++;

                    }
                    if (tErr > 0)
                    {
                        // richTextBox3.ForeColor = System.Drawing.Color.Maroon;
                        //  richTextBox2.Text = richTextBox2.Text + "Instance: One or more character was reported. see " + used + " character "+errLog+"\n";
                    }
                    else
                    {
                        richTextBox3.ForeColor = System.Drawing.Color.ForestGreen;
                        //richTextBox2.Text = richTextBox2.Text + "Instance: One or more character was reported.\n";
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (richTextBox3.Text == "")
            {
                MessageBox.Show("Nothing to write. TARGCLIPB is empty","Reference Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                SaveFileDialog pfd = new SaveFileDialog();
                pfd.Title = "Save As";
                pfd.Filter = "Text File (*.txt)|*.txt | All files (*.*)|*.*";
                if (pfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (StreamWriter sr = new StreamWriter(pfd.OpenFile()))
                        {
                            sr.WriteLine(richTextBox3.Text);
                            label6.Text = "Done:OK";
                        }
                    }
                    catch (Exception msg)
                    {
                        MessageBox.Show(msg.Message);
                    }
                }
                pfd.Dispose();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string txt = "";
            if (checkBox1.Checked == true)
            {
                textBox1.Enabled = true;
                richTextBox4.Show();
                txt = "<<set IsRequiredKey: true \n";
            }
            else
            {
                textBox1.Enabled = false;
                richTextBox4.Hide();
                txt = "<<set IsRequiredKey: false \n";
            }
            richTextBox2.Text = richTextBox2.Text+""+txt;
            richTextBox2.SelectionStart = richTextBox2.Text.Length;
            richTextBox2.ScrollToCaret();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 newF = new Form2();
            newF.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox1.SelectedIndex;
            if (i == 0)
            {
                richTextBox3.ForeColor = System.Drawing.Color.Maroon;
            }
            else if (i == 1)
            {
                richTextBox3.ForeColor = System.Drawing.Color.ForestGreen;
            }
            else if (i == 2)
            {
                richTextBox3.ForeColor = System.Drawing.Color.Snow;
            }
            else if (i == 3)
            {
                richTextBox3.ForeColor = System.Drawing.Color.SaddleBrown;
            }
            else if (i == 4)
            {
                richTextBox3.ForeColor = System.Drawing.Color.Black;
            }
            else
            {
                richTextBox3.ForeColor = System.Drawing.Color.Blue;
            }
            //MessageBox.Show(i.ToString());
            //string txtcom = comboBox1.Text.to;
            //richTextBox3.ForeColor = System.Drawing.Color;
        }

        private void textFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog pfd = new OpenFileDialog();
            pfd.Title = "Select a text file";
            pfd.Filter = "Text File (*.txt)|*.txt | All files (*.*)|*.*";
            if (pfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader sr = new StreamReader(pfd.OpenFile()))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            richTextBox3.Text = richTextBox3.Text+""+line;
                            label6.Text = "Please Wait";
                        }
                        label6.Text = "Done:OK";
                    }
                }
                catch (Exception msg)
                {
                    MessageBox.Show(msg.Message);
                }
            }
            pfd.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int process = 1;
            toolStripProgressBar1.Minimum = 1;
            toolStripProgressBar1.Maximum = 20;
            toolStripProgressBar1.Step = 20;
            string txt = richTextBox3.Text;
            int strlen = txt.Length;
            string pass = textBox1.Text;
            int passle = pass.Length;
            string shit;
            if (strlen < 1 || strlen > 160)
            {
                MessageBox.Show("Cant Start the Krypt Engine: Encryption data cannot be less than 1 or greater than 160", "Prank Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox2.Text = richTextBox2.Text + "Error: cannot send data to Krypt engine >> Krypt Rejected it \n";
                richTextBox2.SelectionStart = richTextBox2.Text.Length;
                richTextBox2.ScrollToCaret();
               
            }
            else if (checkBox1.Checked == true && textBox1.Text == "")
            {
                MessageBox.Show("Cant Start the Krypt Engine: Krypt Expects a key", "Key Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox2.Text = richTextBox2.Text+" Error: Krypt Engine could not be started because the KeyPort was empty \n Please check that you have assigned a key length value of 4 or Key textbox is not checked \n";
                richTextBox2.SelectionStart = richTextBox2.Text.Length;
                richTextBox2.ScrollToCaret();

            }
            else if (checkBox1.Checked == true && passle != 4)
            {
                MessageBox.Show("Cant Start the Krypt Engine: Krypt Expects a key of length 4", "Key Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                richTextBox2.Text = richTextBox2.Text + " Error: Krypt Engine could not be started because the KeyPort has key of invalid length \n Please check that you have assigned a key length value of 4 or Key textbox is not checked \n";
                richTextBox2.SelectionStart = richTextBox2.Text.Length;
                richTextBox2.ScrollToCaret();
            }
            else
            {
                double tBite = strlen * 8 + passle * 8;
                string sta;
                if (checkBox1.Checked == false)
                {
                    sta = "No";
                    shit = "Hey No key!";
                }
                else
                {
                    sta = pass;
                    shit = pass;
                }
                toolStripProgressBar1.PerformStep();
                toolStripLabel2.Text = "Process "+process + " ...";
                label6.Text = "Sending...";
                richTextBox2.Text = richTextBox2.Text + "<<send $package:\n     <:data>"+txt+"</:data>\n using Key:\n      "+sta+"\n total of "+tBite+"Bit sent \n Contacting the Krypt engine now \n";
                richTextBox2.SelectionStart = richTextBox2.Text.Length;
                richTextBox2.ScrollToCaret();
                inputStack ninp = new inputStack();
                ninp.safeChar(txt, shit, richTextBox1, richTextBox2, toolStripProgressBar1, process, label6, toolStripLabel2);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            textBox1.Focus();
            richTextBox4.Show();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            string vart = textBox1.Text;
            int ai = 4 - vart.Length;
            string tot = vart;
            int start = 0;
            while (start < ai)
            {
                tot = tot + "*";
                start++;
            }
            richTextBox4.Text = "<keyVar> \n"+tot+"\n</keyVar>";
            richTextBox2.Text = richTextBox2.Text + "<<Require:" + tot+"\n";
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
            richTextBox3.Text = "";
            checkBox1.Checked = false;
            richTextBox4.Hide();
            textBox1.Text = "";
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            Form4 ha = new Form4();
            ha.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please write into the field and use the Start Krypt Key","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            richTextBox3.Focus();
        }

        private void kryptPictureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string pathT = @"depence\bins\maths\strApps\Decryptor.exe";
            Process startInf = new Process();
            //startInf.CreateNoWindow = false;
            //startInfo.UseShellExecute = false;
            startInf.StartInfo.FileName = pathT;
            startInf.StartInfo.Verb = "runas";
            startInf.Start();
        }

        private void kryptFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form3 fr = new Form3();
           // fr.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = comboBox2.SelectedIndex;
            if (i == 0)
            {
                richTextBox3.BackColor = System.Drawing.Color.Maroon;
            }
            else if (i == 1)
            {
                richTextBox3.BackColor = System.Drawing.Color.ForestGreen;
            }
            else if (i == 2)
            {
                richTextBox3.BackColor = System.Drawing.Color.Snow;
            }
            else if (i == 3)
            {
                richTextBox3.BackColor = System.Drawing.Color.SaddleBrown;
            }
            else if (i == 4)
            {
                richTextBox3.BackColor = System.Drawing.Color.Black;
            }
            else
            {
                richTextBox3.BackColor = System.Drawing.Color.Blue;
            }
        }
    }

}
