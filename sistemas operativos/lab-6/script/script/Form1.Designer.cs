namespace script
{
    partial class Form1
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
            buttonResize = new Button();
            listBoxWindows = new ListBox();
            SuspendLayout();
            // 
            // buttonResize
            // 
            buttonResize.Location = new Point(350, 398);
            buttonResize.Name = "buttonResize";
            buttonResize.Size = new Size(75, 23);
            buttonResize.TabIndex = 0;
            buttonResize.Text = "button1";
            buttonResize.UseVisualStyleBackColor = true;
            buttonResize.Click += buttonResize_Click;
            // 
            // listBoxWindows
            // 
            listBoxWindows.FormattingEnabled = true;
            listBoxWindows.ItemHeight = 15;
            listBoxWindows.Location = new Point(31, 28);
            listBoxWindows.Name = "listBoxWindows";
            listBoxWindows.Size = new Size(728, 364);
            listBoxWindows.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxWindows);
            Controls.Add(buttonResize);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonResize;
        private ListBox listBoxWindows;
    }
}
