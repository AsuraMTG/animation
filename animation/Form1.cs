using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        bool indul = false;
        int szamlalo = 0;
        Bitmap hatter;
        Bitmap minta;
        Bitmap kicsi;
        Graphics g;
        int aktx = 14;
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (indul == false)
            {
                indul = true;
                button1.Text = "Állj";
                timer1.Enabled = true;
                szamlalo++;
            }
            else
            {
                indul = false;
                button1.Text = "Indít";
                timer1.Enabled = false;
                
            }
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((indul == true) && (szamlalo < 20))
            { 
                szamlalo++;
                label1.Text = Convert.ToString(szamlalo);
            }
            else
            {
                indul = false;
                if ((indul == false) && (szamlalo > 0))
                {
                    szamlalo--;
                    label1.Text = Convert.ToString(szamlalo);
                }
                if (szamlalo == 0)
                {
                    indul = true;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string utvonal = openFileDialog1.FileName;
                hatter = (Bitmap)Image.FromFile(utvonal);
                minta = (Bitmap)Image.FromFile(utvonal);
                
            }
            pictureBox1.Image = hatter;
            imageList1.TransparentColor = Color.Fuchsia;
            kicsi = (Bitmap)imageList1.Images[0];
            g = Graphics.FromImage(hatter);
            g.DrawImage(kicsi, aktx, 200, 44, 44); 
        }
    }
}
