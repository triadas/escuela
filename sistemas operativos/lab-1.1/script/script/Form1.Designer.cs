namespace script
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            movingButton = new Button();
            moveTimer = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // movingButton
            // 
            movingButton.Location = new Point(235, 144);
            movingButton.Name = "movingButton";
            movingButton.Size = new Size(103, 49);
            movingButton.TabIndex = 0;
            movingButton.Text = "нажми на меня";
            movingButton.UseVisualStyleBackColor = true;
            movingButton.Click += movingButton_Click;
            // 
            // moveTimer
            // 
            moveTimer.Enabled = true;
            moveTimer.Interval = 1000;
            moveTimer.Tick += moveTimer_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(584, 361);
            Controls.Add(movingButton);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 4, 4, 4);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
        }

        #endregion

        private Button movingButton;
        private System.Windows.Forms.Timer moveTimer;
    }
}
