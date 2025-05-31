namespace WindowInfoApp
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
            txtX = new TextBox();
            txtY = new TextBox();
            txtHeight = new TextBox();
            txtWidth = new TextBox();
            btnSetWindow = new Button();
            lblInfo = new Label();
            lstWindows = new ListBox();
            SuspendLayout();
            // 
            // txtX
            // 
            txtX.Location = new Point(187, 121);
            txtX.Name = "txtX";
            txtX.Size = new Size(100, 23);
            txtX.TabIndex = 1;
            // 
            // txtY
            // 
            txtY.Location = new Point(187, 150);
            txtY.Name = "txtY";
            txtY.Size = new Size(100, 23);
            txtY.TabIndex = 2;
            // 
            // txtHeight
            // 
            txtHeight.Location = new Point(187, 210);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(100, 23);
            txtHeight.TabIndex = 4;
            // 
            // txtWidth
            // 
            txtWidth.Location = new Point(187, 181);
            txtWidth.Name = "txtWidth";
            txtWidth.Size = new Size(100, 23);
            txtWidth.TabIndex = 3;
            // 
            // btnSetWindow
            // 
            btnSetWindow.Location = new Point(628, 201);
            btnSetWindow.Name = "btnSetWindow";
            btnSetWindow.Size = new Size(139, 32);
            btnSetWindow.TabIndex = 6;
            btnSetWindow.Text = "Изменить окно";
            btnSetWindow.UseVisualStyleBackColor = true;
            btnSetWindow.Click += btnSetWindow_Click;
            // 
            // lblInfo
            // 
            lblInfo.BorderStyle = BorderStyle.FixedSingle;
            lblInfo.Location = new Point(628, 123);
            lblInfo.Name = "lblInfo";
            lblInfo.Size = new Size(139, 71);
            lblInfo.TabIndex = 7;
            // 
            // lstWindows
            // 
            lstWindows.FormattingEnabled = true;
            lstWindows.ItemHeight = 15;
            lstWindows.Location = new Point(293, 121);
            lstWindows.Name = "lstWindows";
            lstWindows.Size = new Size(301, 109);
            lstWindows.TabIndex = 8;
            lstWindows.SelectedIndexChanged += lstWindows_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lstWindows);
            Controls.Add(lblInfo);
            Controls.Add(btnSetWindow);
            Controls.Add(txtHeight);
            Controls.Add(txtWidth);
            Controls.Add(txtY);
            Controls.Add(txtX);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtX;
        private TextBox txtY;
        private TextBox txtHeight;
        private TextBox txtWidth;
        private Button btnSetWindow;
        private Label lblInfo;
        private ListBox lstWindows;
    }
}
