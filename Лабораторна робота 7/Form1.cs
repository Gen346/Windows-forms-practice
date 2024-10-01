using System;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Лабораторна_робота_7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hScrollBar1.Scroll += (sender, e) => UpdateConstantsLabels();
            hScrollBar2.Scroll += (sender, e) => UpdateConstantsLabels();
            button2.Click += (sender, e) => ToggleSpeedTextBoxVisibility();
            button3.Click += (sender, e) => ToggleAccelerationTextBoxVisibility();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
            UpdateConstantsLabels();
            speed = GetSpeed(hScrollBar1, hScrollBar2);
            UpdateSpeed();
            UpdateAcceleration();
            
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            
            UpdateConstantsLabels();
            UpdateSpeed();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        int t = 1; //t, time
        const double p = 3.14;
        double speed;
        protected double GetSpeed(HScrollBar hScrollBar1, HScrollBar hScrollBar2)
        {
            double xV = hScrollBar1.Value / (p * Math.Cos(hScrollBar2.Value * t));
            double yV = hScrollBar1.Value / (p * Math.Sin(hScrollBar2.Value * t));
            double speed = Math.Sqrt(xV * xV + yV * yV);
            return speed;
        }
        private double GetAcceleration(double speed, double t)
        {

            double aX = speed / t;
            double aY = speed / t;

            double acceleration = Math.Sqrt(aX * aX + aY * aY);
            return acceleration;
        }
        private void UpdateConstantsLabels()
        {
            int a = hScrollBar1.Value;
            int b = hScrollBar2.Value;
            
            label1.Text =
                $"Закон руху" + "\n" +
                $"x={a}/p*cos({b}*t)" + "\n" +
                $"y ={a}/p*cos({b}*t)";
        }
        private void ToggleSpeedTextBoxVisibility()
        {
            textBox1.Visible = !textBox1.Visible;
        }
        private void ToggleAccelerationTextBoxVisibility()
        {
            textBox2.Visible = !textBox2.Visible;
        }
        private void UpdateSpeed()
        {
            double speed = GetSpeed(hScrollBar1, hScrollBar2 );
            textBox1.Text = speed.ToString();
        }
        private void UpdateAcceleration()
        {
            double acceleration = GetAcceleration(speed, t);
            textBox2.Text = acceleration.ToString();
        }
    }
}
