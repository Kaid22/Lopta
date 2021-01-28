using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lopta
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Start();
        }

        Lopta lopta;
        Random r = new Random();
        int brPokusaja = 0;
        int brPogodaka = 0;
        bool pogodjena = false;

        private void timer1_Tick(object sender, EventArgs e)
        {
            Graphics g = CreateGraphics();
            g.Clear(BackColor);
            int x = r.Next(15, ClientRectangle.Width - 15);
            int y = r.Next(15, ClientRectangle.Height - 15);
            lopta = new Lopta(new Point(x, y), 15, Color.Red);
            lopta.Boji(g);
            brPokusaja++;
            pogodjena = false;
            Text = brPogodaka + " od " + brPokusaja;
        }

        private void Form2_MouseClick(object sender, MouseEventArgs e)
        {
            if (!pogodjena)
            {
                if(lopta.SadrziTacku(new Point(e.X, e.Y)))
                {
                    pogodjena = true;
                    brPogodaka++;
                    Text = brPogodaka + " od " + brPokusaja;
                }
            }
        }
    }
}
