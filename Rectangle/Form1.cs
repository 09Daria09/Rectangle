using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rectangle
{
    public partial class Form1 : Form
    {
        Panel rectangle = new Panel();
        public Form1()
        {
            rectangle = new Panel();
            InitializeComponent();

            rectangle.BackColor = Color.LightGray;
            rectangle.BorderStyle = BorderStyle.FixedSingle;
            rectangle.Margin = new Padding(10);
            rectangle.Dock = DockStyle.None;
            rectangle.Location = new Point(20, 20);
            rectangle.Size = new Size(200, 100);

            Controls.Add(rectangle);
            BackColor = Color.Lavender;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            rectangle.Location = new Point(10, 10);
            rectangle.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 20);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point point = this.PointToClient(MousePosition);

                if (rectangle.ClientRectangle.Contains(rectangle.PointToClient(point)))
                {
                    MessageBox.Show("Точка находится внутри прямоугольника");
                }
                else if (point.X <= rectangle.Left || point.X >= rectangle.Right ||
                         point.Y <= rectangle.Top || point.Y >= rectangle.Bottom)
                {
                    MessageBox.Show("Точка находится снаружи прямоугольника");
                }
                else
                {
                    MessageBox.Show("Точка находится на границе прямоугольника");
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                this.Text = "Ширина = " + this.ClientSize.Width.ToString() +
                            ", Высота = " + this.ClientSize.Height.ToString();
            }

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = "X = " + e.X.ToString() + ", Y = " + e.Y.ToString();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Point point = rectangle.PointToClient(MousePosition);

            if (rectangle.ClientRectangle.Contains(point))
            {
                MessageBox.Show("Точка находится внутри прямоугольника");
            }
            else if (point.X <= rectangle.Left || point.X >= rectangle.Right ||
                     point.Y <= rectangle.Top || point.Y >= rectangle.Bottom)
            {
                MessageBox.Show("Точка находится снаружи прямоугольника");
            }
            else
            {
                MessageBox.Show("Точка находится на границе прямоугольника");
            }
        }
    }
}
