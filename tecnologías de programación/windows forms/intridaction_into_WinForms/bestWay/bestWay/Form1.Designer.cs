namespace bestWay
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
            firstNameLabel = new Label();
            firstNameText = new TextBox();
            lastNameText = new TextBox();
            lastNameLabel = new Label();
            sayHelloButton = new Button();
            SuspendLayout();
            // 
            // firstNameLabel
            // 
            firstNameLabel.AutoSize = true;
            firstNameLabel.Location = new Point(108, 60);
            firstNameLabel.Margin = new Padding(4, 0, 4, 0);
            firstNameLabel.Name = "firstNameLabel";
            firstNameLabel.Size = new Size(89, 18);
            firstNameLabel.TabIndex = 0;
            firstNameLabel.Text = "First Name:";
            // 
            // firstNameText
            // 
            firstNameText.Location = new Point(200, 57);
            firstNameText.Name = "firstNameText";
            firstNameText.Size = new Size(100, 26);
            firstNameText.TabIndex = 1;
            // 
            // lastNameText
            // 
            lastNameText.Location = new Point(200, 95);
            lastNameText.Name = "lastNameText";
            lastNameText.Size = new Size(100, 26);
            lastNameText.TabIndex = 2;
            // 
            // lastNameLabel
            // 
            lastNameLabel.AutoSize = true;
            lastNameLabel.Location = new Point(108, 98);
            lastNameLabel.Margin = new Padding(4, 0, 4, 0);
            lastNameLabel.Name = "lastNameLabel";
            lastNameLabel.Size = new Size(88, 18);
            lastNameLabel.TabIndex = 2;
            lastNameLabel.Text = "Last Name:";
            // 
            // sayHelloButton
            // 
            sayHelloButton.Location = new Point(154, 164);
            sayHelloButton.Name = "sayHelloButton";
            sayHelloButton.Size = new Size(86, 31);
            sayHelloButton.TabIndex = 3;
            sayHelloButton.Text = "Say Hello";
            sayHelloButton.UseVisualStyleBackColor = true;
            sayHelloButton.Click += sayHelloButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(436, 274);
            Controls.Add(sayHelloButton);
            Controls.Add(lastNameText);
            Controls.Add(lastNameLabel);
            Controls.Add(firstNameText);
            Controls.Add(firstNameLabel);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label firstNameLabel;
        private TextBox firstNameText;
        private TextBox lastNameText;
        private Label lastNameLabel;
        private Button sayHelloButton;
    }
}
