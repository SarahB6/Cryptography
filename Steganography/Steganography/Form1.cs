using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Steganography
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string catPath = @"C:\Users\Sarah\Desktop\from.jpg";
            Image original = new Bitmap(catPath);
            string hillPath = @"C:\Users\Sarah\Desktop\to.jpg";
            Image toEmbed = new Bitmap(hillPath);
            Bitmap ogMap = new Bitmap(original);
            Bitmap toEmMap = new Bitmap(toEmbed);
            Bitmap toReturnMap = new Bitmap(original);
            for (int x = 0; x < ogMap.Width; x++)
            {
                for (int y = 0; y < ogMap.Height; y++)
                {
                    Color currOg = ogMap.GetPixel(x, y);
                    Color currEmb = toEmMap.GetPixel(x, y);

                    Color newC = makeNewColor(currOg, currEmb);

                    toReturnMap.SetPixel(x, y, newC);     

                }
            }

            pictureBox1.Image = toReturnMap;

        }

        private Color makeNewColor (Color currOg, Color currEmb)
        {
            byte rOg = (byte)(currOg.R >> 4);
            byte rEm = (byte)(currEmb.R >> 4);
            byte rOgOnTop = (byte)(rOg << 4);
            // byte rtogether = (byte)(rOgOnTop | 0000_0000); 1000100 and 1000100
            byte rtogether = (byte)(rOgOnTop | rEm);

            byte bOg = (byte)(currOg.B >> 4);
            byte bEm = (byte)(currEmb.B >> 4);
            byte bOgOnTop = (byte)(bOg << 4);
            // byte btogether = (byte)(rOgOnTop | 0000_0000);
            byte btogether = (byte)(bOgOnTop | bEm);

            byte gOg = (byte)(currOg.G >> 4);
            byte gEm = (byte)(currEmb.G >> 4);
            byte gOgOnTop = (byte)(gOg << 4);
            // byte gtogether = (byte)(rOgOnTop | 0000_0000);
            byte gtogether = (byte)(gOgOnTop | gEm);

            byte aOg = (byte)(currOg.A >> 4);
            byte aEm = (byte)(currEmb.A >> 4);
            byte aOgOnTop = (byte)(aOg << 4);
            // byte atogether = (byte)(aOgOnTop | 0000_0000);
            byte atogether = (byte)(aOgOnTop | aEm);

            return Color.FromArgb(atogether, rtogether, gtogether, btogether);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
