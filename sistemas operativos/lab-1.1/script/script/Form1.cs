namespace script
{
    public partial class MainForm : Form
    {
        private Random random = new Random();

        private void moveTimer_Tick(object sender, EventArgs e)
        {
            MoveButtonRandomly();
        }

        private void MoveButtonRandomly()
        {
            int maxX = this.ClientSize.Width - movingButton.Width;
            int maxY = this.ClientSize.Height - movingButton.Height;

            int newX = random.Next(0, maxX + 1);
            int newY = random.Next(0, maxY + 1);

            movingButton.Location = new System.Drawing.Point(newX, newY);
        }

        private void movingButton_Click(object sender, EventArgs e)
        {
            moveTimer.Stop();
        }

    }
}
