using System;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            MessageBox.Show("ты победил");
        }

        private void MoveButtonRandomly()
        {
            int maxX = this.ClientSize.Width - button1.Width;
            int maxY = this.ClientSize.Height - button1.Height;
            int newX = random.Next(0, maxX + 1);
            int newY = random.Next(0, maxY + 1);
            button1.Location = new System.Drawing.Point(newX, newY);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            MoveButtonRandomly();
        }

        private Random random = new Random();
    }
}
