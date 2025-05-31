namespace WinFormsApp1
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
            textBoxX = new TextBox();
            buttonPostroit = new Button();
            buttonSokhranit = new Button();
            buttonOchinyt = new Button();
            buttonSchnit = new Button();
            listBox1 = new ListBox();
            plotView = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)plotView).BeginInit();
            SuspendLayout();
            // 
            // textBoxX
            // 
            textBoxX.Location = new Point(251, 251);
            textBoxX.Name = "textBoxX";
            textBoxX.Size = new Size(100, 23);
            textBoxX.TabIndex = 0;
            // 
            // buttonPostroit
            // 
            buttonPostroit.Location = new Point(443, 87);
            buttonPostroit.Name = "buttonPostroit";
            buttonPostroit.Size = new Size(123, 23);
            buttonPostroit.TabIndex = 1;
            buttonPostroit.Text = "Построить график";
            buttonPostroit.UseVisualStyleBackColor = true;
            buttonPostroit.Click += buttonPostroit_Click;
            // 
            // buttonSokhranit
            // 
            buttonSokhranit.Location = new Point(443, 115);
            buttonSokhranit.Name = "buttonSokhranit";
            buttonSokhranit.Size = new Size(123, 23);
            buttonSokhranit.TabIndex = 2;
            buttonSokhranit.Text = "Сохранить как";
            buttonSokhranit.UseVisualStyleBackColor = true;
            buttonSokhranit.Click += buttonSokhranit_Click;
            // 
            // buttonOchinyt
            // 
            buttonOchinyt.Location = new Point(444, 173);
            buttonOchinyt.Name = "buttonOchinyt";
            buttonOchinyt.Size = new Size(122, 23);
            buttonOchinyt.TabIndex = 2;
            buttonOchinyt.Text = "Очистить";
            buttonOchinyt.UseVisualStyleBackColor = true;
            buttonOchinyt.Click += buttonOchinyt_Click;
            // 
            // buttonSchnit
            // 
            buttonSchnit.Location = new Point(444, 144);
            buttonSchnit.Name = "buttonSchnit";
            buttonSchnit.Size = new Size(122, 23);
            buttonSchnit.TabIndex = 2;
            buttonSchnit.Text = "Считать";
            buttonSchnit.UseVisualStyleBackColor = true;
            buttonSchnit.Click += buttonSchnit_Click;
            // 
            // listBox1
            // 
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(103, 229);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(120, 94);
            listBox1.TabIndex = 3;
            // 
            // plotView
            // 
            plotView.Location = new Point(85, 33);
            plotView.Name = "plotView";
            plotView.Size = new Size(232, 163);
            plotView.TabIndex = 4;
            plotView.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(plotView);
            Controls.Add(listBox1);
            Controls.Add(buttonSchnit);
            Controls.Add(buttonOchinyt);
            Controls.Add(buttonSokhranit);
            Controls.Add(buttonPostroit);
            Controls.Add(textBoxX);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)plotView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxX;
        private Button buttonPostroit;
        private Button buttonSokhranit;
        private Button buttonOchinyt;
        private Button buttonSchnit;
        private ListBox listBox1;
        private PictureBox plotView;
    }
}
