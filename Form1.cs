using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace graphics_lab_5
{
    public partial class Form1 : Form
    {
        List<Point> pointsForBezier = new List<Point>();

        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pointsForBezier.Add(new Point(e.X, e.Y));

            foreach (Point p in pointsForBezier)
            {
                textBoxLog.AppendText(p.ToString());
            }
            textBoxLog.AppendText(Environment.NewLine);

            if (pointsForBezier.Count == 4)
            {
                Graphics gr = Graphics.FromImage(pictureBox1.Image);
                gr.DrawBeziers(new Pen(Color.Red), pointsForBezier.ToArray());
                pictureBox1.Refresh();
                gr.Dispose();
                pointsForBezier.Clear();
            }
        }
    }
}
