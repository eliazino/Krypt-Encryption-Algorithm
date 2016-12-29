using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Diagnostics;
using System.Threading;

namespace Krypt
{
    class binstack
    {        
        public void falseStack(string contxt, string[] contxtbin, string[] colx, string[] rowx, string[] mainpopulate, string[] indexpopulate, string strcount, int[] ro, int[] col, string[] datet, string[] keyvb, RichTextBox rtx, ToolStripProgressBar ts, int p, Label l, ToolStripLabel tst)
        {
            p++;
            tst.Text = "Process " + p + " ..."; ;
            ts.Minimum = 1;
            ts.Value = 1;
            string[,] bins = new string[80, 80];
            int rs = 34;
            int cs = 36;
            int stack = 0;
            int row = 0;
            int cols = 0;
            ts.Maximum = 80 + 8 + 16 + 8;
            rtx.Text = rtx.Text+" Inviting Neo to the Matrix \n^";
            rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
            rtx.ScrollToCaret();
            while (row < 80)
            {
                ts.PerformStep();
                while (cols < 80)
                {
                    if ((row > 31 && row < 48) && (cols > 31 && cols < 48))
                    {
                        if ((row > 34 && row < 45) && (cols > 34 && cols < 45))
                        {
                            bins[row, cols] = "1";
                        }
                        else
                        {
                            bins[row, cols] = "0";
                        }

                    }
                    else
                    {
                        bins[row, cols] = "9";
                    }
                    cols = cols + 1;
                }
                cols = 0;
                row = row + 1;
            }
            int start = 0;
            int rowd = 0;
            int colz = 32;
            rtx.Text = rtx.Text+"What's the Time by the Matrix? \n";
            rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
            rtx.ScrollToCaret();
            while (start < 8)
            {
                //Console.WriteLine(rowd);
                ts.PerformStep();
                string nowthis = datet[start];
                int fi = 0;
                while (fi < 8)
                {

                    bins[rowd, colz] = nowthis.Substring(fi, 1);
                    fi++;
                    colz++;
                }
                colz = 32;
                rowd++;
                start++;
            }
            start = 8;
            rowd = 0;
            colz = 40;
            while (start < 16)
            {
                ts.PerformStep();
                string nowthis = datet[start];
                int fi = 0;
                while (fi < 8)
                {
                    bins[rowd, colz] = nowthis.Substring(fi, 1);
                    fi++;
                    colz++;
                }
                colz = 40;
                rowd++;
                start++;
            }
            while (stack < 8)
            {
                ts.PerformStep();
                string nsta = keyvb[stack];
                int ioC = 0;
                while (ioC < 8)
                {
                    bins[rs, cs] = nsta.Substring(ioC, 1);
                    cs++;
                    ioC++;
                }
                cs = 36;
                stack++;
                if (rs == 37)
                {
                    rs = 42;
                }
                else
                {
                    rs++;
                }
            }
            //writer(bins, contxt);
            finalStack(bins, contxtbin, colx, rowx, mainpopulate, indexpopulate, strcount, contxt, ro, col, rtx,  ts,  p, l, tst);
        }
        public void finalStack(string[,] bluep, string[] contxtbi, string[] col, string[] row, string[] mainpopulat, string[] indexpopulat, string strcoun, string contx, int[] ro, int[] co, RichTextBox rtx, ToolStripProgressBar ts, int p, Label l, ToolStripLabel tst)
        {
            p++;
            tst.Text = "Process " + p + " ...";
            ts.Minimum = 1;
            ts.Value = 1;
            ts.Maximum = strcoun.Length + contxtbi.Length + row.Length + indexpopulat.Length;
            int start = 0;
            int rowstart = 39;
            int colstart = 38;
            rtx.Text = rtx.Text + "Now finally \n......         ...... \n";
            rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
            rtx.ScrollToCaret();
            while (start < strcoun.Length)
            {
                ts.PerformStep();
                string thisstr = strcoun.Substring(start, 1);
                bluep[rowstart, colstart] = thisstr;
                if (colstart == 41)
                {
                    rowstart = 40;
                    colstart = 38;
                }
                else
                {
                    colstart++;
                }
                start++;
            }
            start = 0;
            int rowvar;
            int colvar;
            while (start < contxtbi.Length)
            {
                ts.PerformStep();
                rowvar = ro[start];
                colvar = co[start];
                string encodingNow = contxtbi[start];
                int starttwo = 0;
                while (starttwo < encodingNow.Length)
                {
                    string nstr = encodingNow.Substring(starttwo, 1);
                    bluep[rowvar, colvar] = nstr;
                    starttwo++;
                    colvar++;
                }
                starttwo = 0;
                start++;
            }
            start = 0;
            rowvar = 48;
            colvar = 0;
            while (start < row.Length)
            {
                ts.PerformStep();
                string encodingrowNow = row[start];
                string encodingcolNow = col[start];
                int starttwo = 0;
                if (colvar == 80)
                {
                    colvar = 0;
                    rowvar++;
                }
                while (starttwo < encodingrowNow.Length)
                {
                    string nstr = encodingrowNow.Substring(starttwo, 1);
                    bluep[rowvar, colvar] = nstr;
                    starttwo++;
                    colvar++;
                }
                if (colvar == 80)
                {
                    colvar = 0;
                    rowvar++;
                }
                starttwo = 0;
                while (starttwo < encodingcolNow.Length)
                {
                    string nstr = encodingcolNow.Substring(starttwo, 1);
                    bluep[rowvar, colvar] = nstr;
                    starttwo++;
                    colvar++;
                }
                start++;
            }
            start = 0;
            while (start < indexpopulat.Length)
            {
                ts.PerformStep();
                if (colvar == 80)
                {
                    colvar = 0;
                    rowvar++;
                }
                string dstr = indexpopulat[start];
                int st = 0;
                while (st < dstr.Length)
                {
                    string op = dstr.Substring(st, 1);
                    bluep[rowvar, colvar] = op;
                    colvar++;
                    st++;

                }
                start++;
            }
            int ctart = 0;
            int rstart = 0;
            int count = 0;
            while (ctart < 80)
            {
                while (rstart < 48)
                {
                    if (count == mainpopulat.Length)
                    {
                        break;
                    }
                    string xstr = mainpopulat[count];
                    string gstr = bluep[rstart, ctart];
                    int a = rstart;
                    int b = ctart;
                    if (gstr == "9")
                    {
                        int i = 0;
                        while (i < 8)
                        {
                            bluep[a, b] = xstr.Substring(i, 1);
                            b++;
                            i++;
                        }
                        count++;
                    }
                    rstart++;
                }
                rstart = 0;
                ctart = ctart + 8;
            }
            rtx.Text = rtx.Text + "Doing the Calculations \n";
            rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
            rtx.ScrollToCaret();
            writer(bluep, contx, rtx,ts, p, l, tst);
        }
        public void writer(string[,] rval, string subjext, RichTextBox rtx, ToolStripProgressBar ts, int p, Label l, ToolStripLabel tst)
        {
            p++;
            tst.Text = "Process " + p + " ... Final phase!";
            ts.Minimum = 1;
            ts.Value = 1;
            rtx.Text = rtx.Text + "Writting the answers \n";
            rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
            rtx.ScrollToCaret();
            string arraystack = "";
            int startrow = 0;
            int startcols = 0;
            string separator = "";
            string path;
            ts.Maximum = 80 + 2;
            while (startrow < 80)
            {
                ts.PerformStep();
                while (startcols < 80)
                {
                    if (startcols == 79)
                    {
                        separator = "\n";
                    }
                    else
                    {
                        separator = " ";
                    }
                    arraystack = arraystack + rval[startrow, startcols] + separator;
                    startcols++;
                }
                startcols = 0;
                startrow++;
            }
            rtx.Text = rtx.Text + "Writting the answers still\n";
            rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
            rtx.ScrollToCaret();
            if (File.Exists(@"depence\bins\maths\strApps\pixelate.txt"))
            {
                File.Delete(@"depence\bins\maths\strApps\pixelate.txt");
                path = @"depence\bins\maths\strApps\pixelate.txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(arraystack);
                }
                using (StreamWriter sv = new StreamWriter("pixelate.txt"))
                {
                    sv.WriteLine(arraystack);
                }
                inputStack istack = new inputStack();
               // Console.WriteLine("The program from here calls another program from a safe distance...");
                //Console.Read();
            }
            else
            {

                path = @"depence\bins\maths\strApps\pixelate.txt";
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(arraystack);
                }
                using (StreamWriter sv = new StreamWriter("pixelate.txt"))
                {
                    sv.WriteLine(arraystack);
                }
                //Console.WriteLine("The program from here calls another program from a safe distance...");
               // Console.Read();
            }
            ts.PerformStep();
            rtx.Text = rtx.Text + "Putting the file\nThe program from here calls another program from a safe distance...";
            rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
            rtx.ScrollToCaret();
            l.Text = "please wait a little while...";
            ts.PerformStep();
            //Process caller = new Process();
            string pathT = @"depence\bins\maths\strApps\encryptor.exe";
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
                    Process[] setup = Process.GetProcessesByName("encryptor");
                    //Console.WriteLine("{0} chrome processes", chromes.Length);
                    Thread.Sleep(10000);
                    if (setup.Length >= 1)
                    {
                        ts.Value = 1;
                        tst.Text = "No thread";
                        l.Text = "Status:Done";
                        v = false;
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Something went wrong and the program could not complete the action. This may be due to missing application extention on the installation folder. If the error persists, kindly reinstall / repair the program.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ts.Value = 1;
                tst.Text = "No thread";
                l.Text = "Status:Done";
            }
        }
    }
    class pstack
    {
        public void arenc(string input, int trials, string sender, int[] arrayz, string keyV, RichTextBox tX, ToolStripProgressBar ts, int p, Label l, ToolStripLabel tst)
        {
            //string[] colchar = { "a", "x", "z", "f", "9", "5", "2", "0", "p", "n", "b","c","g","y","8","l","k","q","i","m"};
            //int[] colint = { 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72 };
            int[] rowvals = { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 13, 13, 13, 13, 13, 13, 13, 13, 13, 13, 14, 14, 14, 14, 14, 14, 14, 14, 14, 14, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 16, 16, 16, 16, 16, 16, 16, 16, 16, 16, 17, 17, 17, 17, 17, 17, 17, 17, 17, 17, 18, 18, 18, 18, 18, 18, 18, 18, 18, 18, 19, 19, 19, 19, 19, 19, 19, 19, 19, 19, 20, 20, 20, 20, 20, 20, 20, 20, 20, 20, 21, 21, 21, 21, 21, 21, 21, 21, 21, 21, 22, 22, 22, 22, 22, 22, 22, 22, 22, 22, 23, 23, 23, 23, 23, 23, 23, 23, 23, 23, 24, 24, 24, 24, 24, 24, 24, 24, 24, 24, 25, 25, 25, 25, 25, 25, 25, 25, 25, 25, 26, 26, 26, 26, 26, 26, 26, 26, 26, 26, 27, 27, 27, 27, 27, 27, 27, 27, 27, 27, 28, 28, 28, 28, 28, 28, 28, 28, 28, 28, 29, 29, 29, 29, 29, 29, 29, 29, 29, 29, 30, 30, 30, 30, 30, 30, 30, 30, 30, 30, 31, 31, 31, 31, 31, 31, 31, 31, 31, 31, 32, 32, 32, 32, 32, 32, 32, 32, 33, 33, 33, 33, 33, 33, 33, 33, 34, 34, 34, 34, 34, 34, 34, 34, 35, 35, 35, 35, 35, 35, 35, 35, 36, 36, 36, 36, 36, 36, 36, 36, 37, 37, 37, 37, 37, 37, 37, 37, 38, 38, 38, 38, 38, 38, 38, 38, 39, 39, 39, 39, 39, 39, 39, 39, 40, 40, 40, 40, 40, 40, 40, 40, 41, 41, 41, 41, 41, 41, 41, 41, 42, 42, 42, 42, 42, 42, 42, 42, 43, 43, 43, 43, 43, 43, 43, 43, 44, 44, 44, 44, 44, 44, 44, 44, 45, 45, 45, 45, 45, 45, 45, 45, 46, 46, 46, 46, 46, 46, 46, 46, 47, 47, 47, 47, 47, 47, 47, 47 };
            int[] colvals = { 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 32, 40, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72, 0, 8, 16, 24, 48, 56, 64, 72 };
            if (sender == "szend" || sender == "j")
            {
                p++;
                ts.Maximum = 1;
                ts.Minimum = 1;
                ts.Value = 1;
                ts.PerformStep();
                tst.Text = "Process " + p + " ...";
                tX.Text = tX.Text + ">>Locate PosWr \n";
                positionWriter pzw = new positionWriter();
                pzw.runner(input.Length, input, keyV, tX, ts, p, l, tst);
            }
            else
            {
                p++;
                tst.Text = "Process " + p + " ...";
                ts.Minimum = 1;
                ts.Maximum = input.Length;
                ts.Value = 1;
                tX.Text = tX.Text + "arenc reloaded \n >> seiving and stacking \n";
                tX.SelectionStart = tX.Text.Length; //Set the current caret position at the end
                tX.ScrollToCaret();
                int start = 0;
                int[] rowl = new int[input.Length];
                int[] coll = new int[input.Length];
                string[] colab = new string[input.Length];
                while (start < input.Length)
                {
                    ts.PerformStep();
                    int checkNow = arrayz[start];
                    rowl[start] = rowvals[checkNow];
                    coll[start] = colvals[checkNow];
                    colab[start] = rowl[start] + "," + coll[start];
                    start++;
                }
                tX.Text = tX.Text + ">>Locate CrossCheck \n";
                tX.SelectionStart = tX.Text.Length; //Set the current caret position at the end
                tX.ScrollToCaret();
                crossCheck(colab, input, trials, rowl, coll, keyV, tX,ts, p,l, tst);
            }

            //trials++;
            //if (input == null)
            //{
            //    Console.WriteLine("Please write something...");
            //    input = Console.ReadLine();
            //}
            //else
            //{
            //}
            //int inlen = input.Length;
            //int[] rowlay = new int[inlen];
            //int[] collay = new int[inlen];
            //string[] colab = new string[inlen];
            ////int sky = 0;
            //int maximumValue = 445;
            //int minimumValue = 0;
            //int start = 0;
            //int err = 0;
            //int[] allindex = new int[inlen];
            ////sky = 0;
            ////while (sky < inlen)
            ////{
            ////    string path = Path.GetRandomFileName();
            ////    path = (path.Replace(".", "")).Substring(0, 1);
            ////    //Console.WriteLine(path);
            ////    int res = 0;
            ////    int status = 0;
            ////    while (res < colchar.Length)
            ////    {
            ////        if (path == colchar[res])
            ////        {
            ////            collay[sky] = colint[res];
            ////            status = 1;
            ////            //Console.WriteLine("hy"+path+"kill"+colint[res]);
            ////            break;
            ////        }
            ////        else
            ////        {
            ////            status = 0;
            ////        }
            ////        res++;
            ////    }
            ////    if (status == 1)
            ////    {
            ////        sky++;
            ////    }
            ////    else
            ////    {
            ////    }
            ////}



            //RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();
            //while (start < inlen)
            //{
            //    int corres = collay[start];
            //    byte[] randomNumber = new byte[1];
            //    _generator.GetBytes(randomNumber);
            //    double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);
            //    // We are using Math.Max, and substracting 0.00000000001,
            //    // to ensure "multiplier" will always be between 0.0 and .99999999999
            //    // Otherwise, it's possible for it to be "1", which causes problems in our rounding.
            //    double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
            //    // We need to add one to the range, to allow for the rounding done with Math.Floor
            //    int range = maximumValue - minimumValue + 1;
            //    double randomValueInRange = Math.Floor(multiplier * range);
            //    int indexer = (int)(minimumValue + randomValueInRange);
            //    int localcounter = 0;
            //    if (start < 1)
            //    {
            //    }
            //    else
            //    {
            //        while (localcounter < start - 1)
            //        {
            //            if (allindex[localcounter] == indexer)
            //            {
            //                err++;
            //                break;
            //            }
            //            else
            //            {
            //                err = 0;
            //            }
            //            localcounter++;
            //        }
            //    }
            //    if (err > 0)
            //    {

            //    }
            //    else
            //    {
            //        collay[start] = colvals[indexer];
            //        rowlay[start] = rowvals[indexer];
            //        start++;
            //    }
            //    //if (corres == 32 || corres == 40)
            //    //{
            //    //    if ((rowlay[start] >= 0 && rowlay[start] <= 7) || (rowlay[start] <= 32 && rowlay[start] >= 47))
            //    //    {
            //    //        err = 1;
            //    //        //Console.WriteLine("Error one!!");
            //    //    }
            //    //    else
            //    //    {
            //    //        err = 0;
            //    //    }
            //    //}
            //    //else
            //    //{
            //    //    err = 0;
            //    //}
            //    //if (err > 0)
            //    //{
            //    //}
            //    //else
            //    //{
            //    //    start++;
            //    //}

            //}

            //int o = 0;
            //while (o < rowlay.Length)
            //{
            //    //Console.WriteLine(rowlay[o] + "," + collay[o]);
            //    colab[o] = rowlay[o] + "," + collay[o];
            //    o++;
            //}
            //crossCheck(colab, input, trials, rowlay, collay);
        }
        public void populate(string exp, int[] cols, int[] rows, string keyVi, RichTextBox rtx, ToolStripProgressBar ts, int p, Label l, ToolStripLabel tst)
        {
            p++;
            tst.Text = "Process " + p + " ...";
            ts.Minimum = 1;
            ts.Value = 1;
            int a = exp.Length;
            int total = 800;
            int taken = a + 320 + 32 + 16;
            int rem = total - taken;
            int remtwo = 320 - a * 2;
            string popula = "";
            string poput = "";
            int start = 0;
            DateTime ex = DateTime.Now;
            string alldate = ex.ToString();
            string date = alldate.Substring(0, 10);
            string time = alldate.Substring(11, 11);
            string nda = "";
            string nti = "";
            ts.Maximum = date.Length + rem + time.Length + remtwo;
            while (start < date.Length)
            {
                ts.PerformStep();
                string i = date.Substring(start, 1);
                if (i == ":" || i == " " || i == "/")
                {
                    i = "";
                }
                nda = nda + "" + i;
                start++;
            }
            start = 0;
            while (start < rem)
            {
                ts.PerformStep();
                string path = Path.GetRandomFileName();
                path = (path.Replace(".", "")).Substring(0, 1);
                popula = popula + "" + path;
                start++;
            }
            start = 0;
            while (start < time.Length)
            {
                ts.PerformStep();
                string il = time.Substring(start, 1);
                if (il == ":" || il == " " || il == "/")
                {
                    il = "";
                }
                nti = nti + "" + il;
                start++;
            } string tdat = nda + "" + nti;
            start = 0;
            while (start < remtwo)
            {
                ts.PerformStep();
                string path = Path.GetRandomFileName();
                path = (path.Replace(".", "")).Substring(0, 1);
                poput = poput + "" + path;
                start++;
            }
            int op = exp.Length;
            binconverter mik = new binconverter();
            rtx.Text = rtx.Text + "Exit \n start >> Music() \n";
            rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
            rtx.ScrollToCaret();
            mik.eqstack(exp, popula, op, rows, cols, poput, tdat, keyVi, rtx,ts, p, l, tst);
        }
        public void crossCheck(string[] checks, string previn, int tryal, int[] row, int[] cols, string keyV, RichTextBox rtx, ToolStripProgressBar ts, int p, Label l, ToolStripLabel tst)
        {
            p++;
            tst.Text = "Process " + p + " ...";
            ts.Minimum = 1;
            ts.Maximum = checks.Length;
            ts.Value = 1;
            int strlen = checks.Length;
            int start = 0;
            int errors = 0;
            while (start < strlen)
            {
                ts.PerformStep();
                string thisstr = checks[start];
                int zwy = start + 1;
                while (zwy < strlen)
                {
                    string kil = checks[zwy];
                    if (thisstr == kil)
                    {
                        string text = "An Error has occured when " + thisstr + " equals " + kil;
                        //Console.WriteLine("An Error has occured when " + thisstr + " equals " + kil);
                        errors++;
                    }
                    zwy++;
                }
                start++;
            }
            if (errors > 0)
            {
                //Console.WriteLine(errors + " errors has terminated the program!! buhahahahahah!!!!");
                //Console.WriteLine("The string has just " + previn.Length + " characters");
                //Console.Read();
                int[] hey = { 1, 3, 4 };
                rtx.Text = rtx.Text + "Something happened and CrossCheck had to reCall arenc \n";
                rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
                rtx.ScrollToCaret();
                arenc(previn, tryal, "szend", hey, keyV, rtx, ts,  p, l, tst);
            }
            else
            {
                //Console.WriteLine("everything seems clean for " + previn + " After " + tryal + " trials");
                rtx.Text = rtx.Text + "arenc was not recalled \n preparing for >> Excite()Ment \n      >> Loading dancers() \n";
                rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
                rtx.ScrollToCaret();
                populate(previn, cols, row, keyV, rtx, ts, p,l, tst);
                //Console.WriteLine(rem + " characters will be generated");
                //Console.Read();
            }
        }
    }
    class binconverter
    {
        string[] supported = { "!", " ", "|", @"\", "¬", "`", "\"", "£", "$", "%", "^", "&", "*", "(", ")", "_", "-", "+", "=", "{", "}", "[", "]", ":", ";", "@", "'", "~", "#", "<", ",", ".", ">", "?", "/", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "-:" };
        int[] intequiv = { 33, 32, 124, 92, 172, 96, 34, 163, 36, 37, 94, 38, 42, 40, 41, 95, 45, 43, 61, 123, 125, 91, 93, 58, 59, 64, 39, 126, 35, 60, 44, 46, 62, 63, 47, 49, 50, 51, 52, 53, 54, 55, 56, 57, 48, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 97, 98, 99, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114, 115, 116, 117, 118, 119, 120, 121, 122, 24};
        public void eqstack(string exp, string pop, int count, int[] row, int[] cols, string rems, string dte, string keyV, RichTextBox rtx, ToolStripProgressBar ts, int p, Label l, ToolStripLabel tst)
        {
            p++;
            tst.Text = "Process " + p + " ...";
            ts.Minimum = 1;
            ts.Value = 1;
            int start = 0;
            int[] now = new int[exp.Length];
            int[] dat = new int[dte.Length];
            int[] popul = new int[pop.Length];
            int[] remz = new int[rems.Length];
            int counta = count;
            int[] rowvar = new int[row.Length];
            int[] colvar = new int[cols.Length];
            int adderFI = 0;
            int adderLI = 0;
            ts.Maximum = 4 + cols.Length + row.Length + rems.Length + dte.Length + pop.Length + exp.Length;
            if (keyV.Length > 4)
            {
                rtx.Text = rtx.Text + "Skipping This for KeyPort eq(NO) \n";
                rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
                rtx.ScrollToCaret();
            }
            else
            {
                rtx.Text = rtx.Text + " Calling The >>KeyMaker \n Opening the Matrices \n";
                rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
                rtx.ScrollToCaret();
                int[] keyIl = new int[4];
                int startK = 0;
                while (startK < 4)
                {
                    ts.PerformStep();
                    string thisstr = keyV.Substring(startK, 1);
                    int slen = 0;
                    while (slen < supported.Length)
                    {
                        string shii = supported[slen];
                        if (thisstr == shii)
                        {
                            keyIl[startK] = intequiv[slen];
                            break;
                        }
                        else
                        {
                        }
                        slen++;
                    }
                    slen = 0;
                    startK++;
                }
                startK = 0;
                int[] iarr = new int[4];
                rtx.Text = rtx.Text + "Keeping the key \n";
                rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
                rtx.ScrollToCaret();
                while (startK < keyIl.Length)
                {
                    string nowC = keyIl[startK].ToString();
                    Console.WriteLine(keyIl[startK]);
                    int strN = nowC.Length;
                    int muu = 0;
                    int tempA = 0;
                    while (muu < strN)
                    {

                        string v = nowC.Substring(muu, 1);
                        if (v == "0")
                        {
                            tempA = tempA + 0;
                        }
                        else if (v == "1")
                        {
                            tempA = tempA + 1;
                        }
                        else if (v == "2")
                        {
                            tempA = tempA + 2;
                        }
                        else if (v == "3")
                        {
                            tempA = tempA + 3;
                        }
                        else if (v == "4")
                        {
                            tempA = tempA + 4;
                        }
                        else if (v == "5")
                        {
                            tempA = tempA + 5;
                        }
                        else if (v == "6")
                        {
                            tempA = tempA + 6;
                        }
                        else if (v == "7")
                        {
                            tempA = tempA + 7;
                        }
                        else if (v == "8")
                        {
                            tempA = tempA + 8;
                        }
                        else if (v == "9")
                        {
                            tempA = tempA + 9;
                        }
                        muu++;
                    }
                    //Console.WriteLine(nowC + " and addition is " + tempA);
                    iarr[startK] = tempA;
                    startK++;
                }
                rtx.Text = rtx.Text + "Dismissing The keyMaker \n";
                rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
                rtx.ScrollToCaret();
                adderFI = iarr[0] + iarr[1];
                adderLI = iarr[2] + iarr[3];
            }
            int switchval = 0;
            while (start < exp.Length)
            {
                ts.PerformStep();
                string thisstr = exp.Substring(start, 1);
                if (thisstr == "\n")
                {
                    thisstr = "-:";
                }
                int slen = 0;
                while (slen < supported.Length)
                {
                    string shii = supported[slen];
                    if (thisstr == shii)
                    {
                        if (switchval == 0)
                        {
                            now[start] = intequiv[slen] + adderFI;
                            switchval = 1;
                            // Console.WriteLine(switchval);
                        }
                        else
                        {
                            now[start] = intequiv[slen] + adderLI;
                            switchval = 0;
                            //Console.WriteLine(switchval);
                        }
                        break;
                    }
                    else
                    {
                    }
                    slen++;
                }
                slen = 0;
                start++;
            }
            start = 0;
            rtx.Text = rtx.Text + "Key was succesfully stashed \n";
            rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
            rtx.ScrollToCaret();
            while (start < pop.Length)
            {
                ts.PerformStep();
                string thisstr = pop.Substring(start, 1);
                if (thisstr == "\n")
                {
                    thisstr = "-:";
                }
                int slen = 0;
                while (slen < supported.Length)
                {
                    string shii = supported[slen];
                    if (thisstr == shii)
                    {
                        popul[start] = intequiv[slen];
                        break;
                    }
                    else
                    {
                    }
                    slen++;
                }
                slen = 0;
                start++;
            }
            rtx.Text = rtx.Text + "Keeping the Dancers \n";
            rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
            rtx.ScrollToCaret();
            start = 0;
            while (start < dte.Length)
            {
                ts.PerformStep();
                string thisstr = dte.Substring(start, 1);
                if (thisstr == "\n")
                {
                    thisstr = "-:";
                }
                int slen = 0;
                while (slen < supported.Length)
                {
                    string shii = supported[slen];
                    if (thisstr == shii)
                    {
                        dat[start] = intequiv[slen];
                        break;
                    }
                    else
                    {
                    }
                    slen++;
                }
                slen = 0;
                start++;
            }
            start = 0;
            while (start < rems.Length)
            {
                ts.PerformStep();
                string thisstr = rems.Substring(start, 1);
                if (thisstr == "\n")
                {
                    //thisstr = ":-";
                    remz[start] = 24;
                }
                else
                {
                    int slen = 0;
                    while (slen < supported.Length)
                    {
                        string shii = supported[slen];
                        if (thisstr == shii)
                        {
                            remz[start] = intequiv[slen];
                            break;
                        }
                        else
                        {
                        }
                        slen++;
                    }
                    slen = 0;
                }
                start++;
            }
            rtx.Text = rtx.Text + "Keeping the singers \n";
            rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
            rtx.ScrollToCaret();
            start = 0;
            while (start < row.Length)
            {
                ts.PerformStep();
                int thisstr = row[start];
                if (thisstr > 9)
                {
                    int rem = thisstr - 10;
                    rowvar[start] = 100 + rem;
                }
                else
                {

                    int slen = 0;
                    while (slen < supported.Length)
                    {
                        string shii = supported[slen];
                        if (thisstr.ToString() == shii)
                        {
                            rowvar[start] = intequiv[slen];
                            break;
                        }
                        else
                        {
                        }
                        slen++;
                    }
                    slen = 0;
                }
                start++;
            }
            start = 0;
            while (start < cols.Length)
            {
                ts.PerformStep();
                int thisstr = cols[start];
                if (thisstr > 9)
                {
                    int rem = thisstr - 10;
                    colvar[start] = 100 + rem;
                }
                else
                {
                    int slen = 0;
                    while (slen < supported.Length)
                    {
                        string shii = supported[slen];
                        if (thisstr.ToString() == shii)
                        {
                            colvar[start] = intequiv[slen];
                            break;
                        }
                        else
                        {
                        }
                        slen++;
                    }
                    slen = 0;
                }
                start++;
            }
            //int sz = 0;
            //while (sz < colvar.Length)
            //{
            //    //  Console.WriteLine(colvar[sz] + "," + rowvar[sz]+"---"+row[sz]+","+cols[sz]);
            //    sz++;
            //}
         
            rtx.Text = rtx.Text + "Keeping the seats \n";
            rtx.SelectionStart = rtx.Text.Length; 
            rtx.ScrollToCaret();
            converter(now, exp, counta, colvar, rowvar, remz, popul, row, cols, dat, keyV, rtx, ts,  p,l, tst);
        }
        public void converter(int[] hey, string line, int counts, int[] cols, int[] row, int[] rem, int[] pop, int[] rowint, int[] colsint, int[] datet, string keyM, RichTextBox rtx, ToolStripProgressBar ts, int p, Label l, ToolStripLabel tst)
        {
            p++;
            tst.Text = "Process " + p + " ...";
            ts.Minimum = 1;
            ts.Value = 1;
            string[] cons = new string[hey.Length];
            int[] keyzg = new int[8];
            string strcount = "";
            string[] keyvm = new string[8];
            string[] column = new string[cols.Length];
            string[] rows = new string[row.Length];
            string[] remPopula = new string[rem.Length];
            string[] populate = new string[pop.Length];
            string[] datee = new string[datet.Length];
            int intgo = 128;
            int start = 0;
            ts.Maximum = 8 + hey.Length + datet.Length + colsint.Length + row.Length + rem.Length + pop.Length + pop.Length;
            if (keyM.Length > 4)
            {
                rtx.Text = rtx.Text + "Keeping a light matrix for KeyPort eq(No) \n";
                rtx.SelectionStart = rtx.Text.Length; 
                rtx.ScrollToCaret();
                keyzg[0] = 0;
                keyzg[1] = 255;
                keyzg[2] = 255;
                keyzg[3] = 255;
                keyzg[4] = 255;
                keyzg[5] = 255;
                keyzg[6] = 255;
                keyzg[7] = 0;
            }
            else
            {
                // Console.Write("Reaches here");
                rtx.Text = rtx.Text + "Keeping a Heavy matrix for KeyPort eq(Yes) \n";
                rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
                rtx.ScrollToCaret();
                keyzg[0] = 0;
                keyzg[1] = 153;
                keyzg[2] = 129;
                keyzg[3] = 231;
                keyzg[4] = 231;
                keyzg[5] = 247;
                keyzg[6] = 199;
                keyzg[7] = 0;
            }
            while (start < 8)
            {
                ts.PerformStep();
                int tobeC = keyzg[start];
                while (intgo > 1)
                {
                    if (tobeC >= intgo)
                    {
                        keyvm[start] = keyvm[start] + "1";
                        tobeC = tobeC - intgo;
                    }
                    else
                    {
                        keyvm[start] = keyvm[start] + "0";
                    }

                    intgo = intgo / 2;
                }
                if (intgo == 1)
                {
                    if (tobeC == 1)
                    {
                        keyvm[start] = keyvm[start] + "1";
                    }
                    else
                    {
                        keyvm[start] = keyvm[start] + "0";
                    }
                }
                intgo = 128;
                start++;
            }
            intgo = 128;
            start = 0;
            while (start < hey.Length)
            {
                ts.PerformStep();
                int tobeC = hey[start];
                while (intgo > 1)
                {
                    if (tobeC >= intgo)
                    {
                        cons[start] = cons[start] + "1";
                        tobeC = tobeC - intgo;
                    }
                    else
                    {
                        cons[start] = cons[start] + "0";
                    }

                    intgo = intgo / 2;
                }
                if (intgo == 1)
                {
                    if (tobeC == 1)
                    {
                        cons[start] = cons[start] + "1";
                    }
                    else
                    {
                        cons[start] = cons[start] + "0";
                    }
                }
                intgo = 128;
                start++;
            }
            intgo = 128;
            start = 0;
            while (start < datet.Length)
            {
                ts.PerformStep();
                int tobeC = datet[start];
                while (intgo > 1)
                {
                    if (tobeC >= intgo)
                    {
                        datee[start] = datee[start] + "1";
                        tobeC = tobeC - intgo;
                    }
                    else
                    {
                        datee[start] = datee[start] + "0";
                    }

                    intgo = intgo / 2;
                }
                if (intgo == 1)
                {
                    if (tobeC == 1)
                    {
                        datee[start] = datee[start] + "1";
                    }
                    else
                    {
                        datee[start] = datee[start] + "0";
                    }
                }
                intgo = 128;
                start++;
            }
            intgo = 128;
            start = 0;
            while (start < colsint.Length)
            {
                ts.PerformStep();
                int tobeC = cols[start];
                while (intgo > 1)
                {
                    if (tobeC >= intgo)
                    {
                        column[start] = column[start] + "1";
                        tobeC = tobeC - intgo;
                    }
                    else
                    {
                        column[start] = column[start] + "0";
                    }

                    intgo = intgo / 2;
                }
                if (intgo == 1)
                {
                    if (tobeC == 1)
                    {
                        column[start] = column[start] + "1";
                    }
                    else
                    {
                        column[start] = column[start] + "0";
                    }
                }
                intgo = 128;
                start++;
            }
            intgo = 128;
            start = 0;
            while (start < row.Length)
            {
                ts.PerformStep();
                int tobeC = row[start];
                while (intgo > 1)
                {
                    if (tobeC >= intgo)
                    {
                        rows[start] = rows[start] + "1";
                        tobeC = tobeC - intgo;
                    }
                    else
                    {
                        rows[start] = rows[start] + "0";
                    }

                    intgo = intgo / 2;
                }
                if (intgo == 1)
                {
                    if (tobeC == 1)
                    {
                        rows[start] = rows[start] + "1";
                    }
                    else
                    {
                        rows[start] = rows[start] + "0";
                    }
                }
                intgo = 128;
                start++;
            }
            intgo = 128;
            start = 0;
            while (start < rem.Length)
            {
                ts.PerformStep();
                int tobeC = rem[start];
                while (intgo > 1)
                {
                    if (tobeC >= intgo)
                    {
                        remPopula[start] = remPopula[start] + "1";
                        tobeC = tobeC - intgo;
                    }
                    else
                    {
                        remPopula[start] = remPopula[start] + "0";
                    }

                    intgo = intgo / 2;
                }
                if (intgo == 1)
                {
                    if (tobeC == 1)
                    {
                        remPopula[start] = remPopula[start] + "1";
                    }
                    else
                    {
                        remPopula[start] = remPopula[start] + "0";
                    }
                }
                intgo = 128;
                start++;
            }
            intgo = 128;
            start = 0;
            while (start < pop.Length)
            {
                ts.PerformStep();
                int tobeC = pop[start];
                while (intgo > 1)
                {
                    if (tobeC >= intgo)
                    {
                        populate[start] = populate[start] + "1";
                        tobeC = tobeC - intgo;
                    }
                    else
                    {
                        populate[start] = populate[start] + "0";
                    }

                    intgo = intgo / 2;
                }
                if (intgo == 1)
                {
                    if (tobeC == 1)
                    {
                        populate[start] = populate[start] + "1";
                    }
                    else
                    {
                        populate[start] = populate[start] + "0";
                    }
                }
                intgo = 128;
                start++;
            }
            int tobeCi = counts;
            intgo = 128;
            while (intgo > 1)
            {
                if (tobeCi >= intgo)
                {
                    strcount = strcount + "1";
                    tobeCi = tobeCi - intgo;
                }
                else
                {
                    strcount = strcount + "0";
                }

                intgo = intgo / 2;
            }
            if (intgo == 1)
            {
                if (tobeCi == 1)
                {
                    strcount = strcount + "1";
                }
                else
                {
                    strcount = strcount + "0";
                }
            }
            rtx.Text = rtx.Text + "Arabic Dec Learnt! \n";
            rtx.SelectionStart = rtx.Text.Length; //Set the current caret position at the end
            rtx.ScrollToCaret();
            binstack hui = new binstack();
            hui.falseStack(line, cons, column, rows, populate, remPopula, strcount, rowint, colsint, datee, keyvm, rtx, ts, p, l,tst);
        }
    }
    class inputStack
    {
        public void coll()
        {
            string key;
            Console.WriteLine("Please enter data to be encrypted");
            string inport;
            inport = Console.ReadLine();
            Console.WriteLine("Do you want a key for the encryption?");
            string f = Console.ReadLine();
            if (f == "y")
            {
                Console.WriteLine("You have requested a key for your encryption, please supply four characters from the keyboard. \n Remember, this key will be required for the decryption.");
                key = Console.ReadLine();
                while (key.Length != 4)
                {
                    Console.WriteLine("Something seems wrong with your key, Four characters are allowed, no more, no less\n Please type again... ");
                    key = Console.ReadLine();
                }
            }
            else
            {
                key = "Hey No key!";
            }

            if (inport.Length > 160 || inport.Length < 1)
            {
                Console.WriteLine("Max of 160 characters and minimum of 1 character is required");
                Console.ReadLine();
            }
            else
            {
                //safeChar(inport, key);
            }
        }
        public void safeChar(string exp, string keyStat, RichTextBox rTx, RichTextBox rt2, ToolStripProgressBar ts, int p, Label l, ToolStripLabel tst)
        {
            rt2.Text =rt2.Text+"Engine was succesfully contacted RESP 1; \n >>Locate safechar \n";
            rTx.Text = ">> Start Engine: IsValid? "+exp+"\n";
            rTx.SelectionStart = rTx.Text.Length; //Set the current caret position at the end
            rTx.ScrollToCaret();
            string[] supported = { "!", " ", "|", @"\", "¬", "`", "\"", "£", "$", "%", "^", "&", "*", "(", ")", "_", "-", "+", "=", "{", "}", "[", "]", ":", ";", "@", "'", "~", "#", "<", ",", ".", ">", "?", "/", "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "-:" };
            int errors = 0;
            int err = 0;
            string unsup = "";
            string unsurpK = "";
            int snuz = supported.Length;
            int vall = exp.Length;
            int init = 0;
            int inni = 0;
            p++;
            ts.Minimum = 1;
            ts.Maximum = vall;
            ts.Value = 1;
            tst.Text = "Process " + p + " ...";
            while (init < vall)
            {
                ts.PerformStep();
                string nstr = exp.Substring(init, 1);
                if (nstr == "\n")
                {
                    nstr = "-:";
                }
                int no = 0;
                while (inni < snuz)
                {
                    string pstr = supported[inni];
                    if (nstr == pstr)
                    {
                        no = 0;
                        break;
                    }
                    else
                    {
                        no = no + 1;
                    }
                    inni = inni + 1;
                }
                if (no > 0)
                {
                    errors = errors + 1;
                    unsup = unsup + "," + nstr;
                }
                inni = 0;
                init = init + 1;
            }
            if (keyStat != "Hey No key!")
            {
                rTx.Text = rTx.Text + ">> IsValidKey? " + keyStat+"\n";
                rTx.SelectionStart = rTx.Text.Length; //Set the current caret position at the end
                rTx.ScrollToCaret();
                err = 0;
                int initK = 0;
                int initBp = 0;
                while (initK < 4)
                {
                    string kstr = keyStat.Substring(initK, 1);
                    if (kstr == "\n")
                    {

                        //Console.WriteLine("An undefined character was found in your key, Please try again");
                        break;
                    }
                    int no = 0;
                    while (initBp < supported.Length)
                    {
                        string pstr = supported[initBp];
                        if (kstr == pstr)
                        {
                            no = 0;
                            break;
                        }
                        else
                        {
                            no = no + 1;
                        }
                        initBp = initBp + 1;
                    }
                    if (no > 0)
                    {
                        err = err + 1;
                        unsurpK = unsurpK + "," + kstr;
                    }
                    initBp = 0;
                    initK = initK + 1;
                }
            }
            else
            {
                rTx.Text = rTx.Text + " KeyPort: 0 \n";
                rTx.SelectionStart = rTx.Text.Length; //Set the current caret position at the end
                rTx.ScrollToCaret();
            }
            if (errors > 0)
            {
                rTx.Text = rTx.Text + errors + " characters was not supported: " + unsup.Substring(1, unsup.Length - 1)+"\n These chracters have skipped validation and has caused the program to terminate \n";
                rTx.SelectionStart = rTx.Text.Length; //Set the current caret position at the end
                rTx.ScrollToCaret();
                //Console.WriteLine(errors + " characters wasnt supported: " + unsup.Substring(1, unsup.Length - 1));
                //Console.WriteLine(err + " characters wasnt supported in your key: " + unsurpK.Substring(1, unsurpK.Length - 1));
               // Console.ReadLine();
            }
            else if (err > 0)
            {
                rTx.Text = rTx.Text + err + " characters was not supported in your key: " + unsurpK.Substring(1, unsurpK.Length - 1)+"\n";
                rTx.SelectionStart = rTx.Text.Length; //Set the current caret position at the end
                rTx.ScrollToCaret();
                //Console.WriteLine(err + " characters wasnt supported in your key: " + unsurpK.Substring(1, unsurpK.Length - 1));
                //Console.ReadLine();
            }
            else
            {
                rTx.Text = rTx.Text + "Validation Succesful \n SomeBit passed \n starting Core Engine \n >> Locate arenc";
                rTx.SelectionStart = rTx.Text.Length; //Set the current caret position at the end
                rTx.ScrollToCaret();
                int[] a = { 3, 3 };
                pstack pst = new pstack();
                pst.arenc(exp, 0, "j", a, keyStat, rTx, ts, p,l, tst);
            }
        }
    }
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        inputStack iop = new inputStack();
    //        iop.coll();
    //    }
    //}
}
