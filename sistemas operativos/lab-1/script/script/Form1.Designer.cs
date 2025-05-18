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
            enterNumberText = new Label();
            ShowValue = new Button();
            enterNumberValue = new TextBox();
            SuspendLayout();
            // 
            // enterNumberText
            // 
            enterNumberText.AutoSize = true;
            enterNumberText.Location = new Point(55, 85);
            enterNumberText.Name = "enterNumberText";
            enterNumberText.Size = new Size(101, 18);
            enterNumberText.TabIndex = 0;
            enterNumberText.Text = "введи число:";
            // 
            // ShowValue
            // 
            ShowValue.BackColor = Color.White;
            ShowValue.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            ShowValue.Location = new Point(176, 131);
            ShowValue.Name = "ShowValue";
            ShowValue.Size = new Size(102, 46);
            ShowValue.TabIndex = 1;
            ShowValue.Text = "нажми на меня";
            ShowValue.UseVisualStyleBackColor = false;
            ShowValue.Click += ShowValue_Click;
            // 
            // enterNumberValue
            // 
            enterNumberValue.Location = new Point(162, 82);
            enterNumberValue.Name = "enterNumberValue";
            enterNumberValue.Size = new Size(163, 26);
            enterNumberValue.TabIndex = 2;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(416, 250);
            Controls.Add(enterNumberValue);
            Controls.Add(ShowValue);
            Controls.Add(enterNumberText);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label enterNumberText;
        private Button ShowValue;
        private TextBox enterNumberValue;
    }
}
