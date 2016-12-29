using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace Krypt
{
    class positionWriter
    {
        public void runner(int charCount, string inp, string keyV, RichTextBox rc, ToolStripProgressBar ts, int p, Label l, ToolStripLabel tst)
        {
            p++;
            tst.Text = "Process " + p + " ...";
            ts.Minimum = 1;
            ts.Value = 1;
            ts.Maximum = charCount;
            rc.Text = rc.Text + ">>PosWr \nPosWr Located \n Microsoft CrLib loaded \n do: \n";
            int a = charCount;
            int maximumValue = 431;
            int minimumValue = 0;
            int[] randarray = new int[a];
            int start = 0;
            int err = 0;
            RNGCryptoServiceProvider _generator = new RNGCryptoServiceProvider();
            while (start < a)
            {
                ts.PerformStep();
                byte[] randomNumber = new byte[1];
                _generator.GetBytes(randomNumber);
                double asciiValueOfRandomCharacter = Convert.ToDouble(randomNumber[0]);
                double multiplier = Math.Max(0, (asciiValueOfRandomCharacter / 255d) - 0.00000000001d);
                int range = maximumValue - minimumValue + 1;
                double randomValueInRange = Math.Floor(multiplier * range);
                randarray[start] = (int)(minimumValue + randomValueInRange);
                int localcounter = 0;
                if (start < 1)
                {
                }
                else
                {
                    while (localcounter < start - 1)
                    {
                        if (randarray[localcounter] == randarray[start])
                        {
                            err++;
                            // Console.WriteLine("index " + localcounter + " equals " + start);
                            rc.Text = rc.Text + randarray[localcounter]+" eqs "+ randarray[start]+" on "+localcounter+" iter: Conflict Encountered: Retrying... \n";
                            break;
                        }
                        else
                        {
                            err = 0;
                        }
                        localcounter++;
                    }
                }
                if (err > 0)
                {

                }
                else
                {
                    //Console.WriteLine(randarray[start]);
                    start++;
                }
            }
            rc.Text = rc.Text + " Broke free: do terminated... \n >>Locate arenc: \n";
            pstack hji = new pstack();
            hji.arenc(inp, 0, "Me", randarray, keyV, rc,ts,  p, l, tst);
        }
    }
}
