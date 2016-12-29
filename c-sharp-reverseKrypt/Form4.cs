using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Krypt
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string path = @"bins\helpFiles\help.txt";
            if (File.Exists(path))
            {
                using (StreamReader ji = new StreamReader(path))
                {
                    string line;
                    while ((line = ji.ReadLine()) != null)
                    {
                        richTextBox1.Text = richTextBox1.Text + "" + line;
                    }
                }
            }
            else
            {
                MessageBox.Show("The help file was not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
