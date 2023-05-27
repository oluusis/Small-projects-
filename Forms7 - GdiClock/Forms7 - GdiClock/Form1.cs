using System.Drawing.Printing;

namespace Forms7___GdiClock
{
    public partial class Form1 : Form
    {
        private float a;
        private float b;
        private float c;
        public Form1()
        {
            InitializeComponent();
            DateTime dateTime = DateTime.Now;
            a = dateTime.Second*6;
            b = dateTime.Minute*6;
            c = dateTime.Hour * 6*5;
            this.timer1.Start();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.TranslateTransform(panel1.Width / 2, panel1.Height / 2);
            Pen p = new Pen(Color.Black, 1.5f);
            Pen pw = new Pen(Color.Red, 1.5f);
            PointF pf = new PointF(0, -100);
            SolidBrush solidBrush = new SolidBrush(Color.Black);

            //sekundy
            g.RotateTransform(a);
            g.DrawLine(pw, 0, 0, 0, -100);
            g.RotateTransform(-a);
            //minuty
            g.RotateTransform(b);
            g.DrawLine(p, 0, 0, 0, -80);
            g.RotateTransform(-b);
            //hodiny
            g.RotateTransform(c);
            g.DrawLine(p, 0, 0, 0, -40);
            g.RotateTransform(-c);

            for (int i = 1; i <= 12; i++)
            {
                g.RotateTransform(30f);
                e.Graphics.DrawString(Convert.ToString(i), new Font("Times New Roman", 18), solidBrush, pf);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.panel1.Invalidate();
            a += 6f;
            if (a == 360f)
            {
                b += 6f;
                a -= 360f;
            }
            if(b == 360f)
            {
                c += 30f;
                b -= 360f;
            }
        }
    }
}