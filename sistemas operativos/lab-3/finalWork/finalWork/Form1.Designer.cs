namespace finalWork
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
            infoValue = new TextBox();
            pathValue = new TextBox();
            showInfo = new Button();
            infoText = new TextBox();
            pathText = new TextBox();
            SuspendLayout();
            // 
            // infoValue
            // 
            infoValue.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            infoValue.Location = new Point(116, 23);
            infoValue.Multiline = true;
            infoValue.Name = "infoValue";
            infoValue.ReadOnly = true;
            infoValue.Size = new Size(444, 187);
            infoValue.TabIndex = 0;
            infoValue.TabStop = false;
            // 
            // pathValue
            // 
            pathValue.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            pathValue.Location = new Point(116, 216);
            pathValue.Name = "pathValue";
            pathValue.ReadOnly = true;
            pathValue.Size = new Size(308, 21);
            pathValue.TabIndex = 1;
            pathValue.TabStop = false;
            // 
            // showInfo
            // 
            showInfo.Font = new Font("Arial", 8.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            showInfo.Location = new Point(430, 216);
            showInfo.Name = "showInfo";
            showInfo.Size = new Size(130, 26);
            showInfo.TabIndex = 2;
            showInfo.Text = "смотреть инфу ";
            showInfo.UseVisualStyleBackColor = true;
            showInfo.Click += showInfo_Click;
            // 
            // infoText
            // 
            infoText.Location = new Point(12, 80);
            infoText.Multiline = true;
            infoText.Name = "infoText";
            infoText.ReadOnly = true;
            infoText.Size = new Size(98, 58);
            infoText.TabIndex = 3;
            infoText.TabStop = false;
            infoText.Text = "инфа о файле";
            // 
            // pathText
            // 
            pathText.Location = new Point(10, 216);
            pathText.Name = "pathText";
            pathText.ReadOnly = true;
            pathText.Size = new Size(100, 26);
            pathText.TabIndex = 4;
            pathText.TabStop = false;
            pathText.Text = "путь к файлу";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 313);
            Controls.Add(pathText);
            Controls.Add(infoText);
            Controls.Add(showInfo);
            Controls.Add(pathValue);
            Controls.Add(infoValue);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox infoValue;
        private TextBox pathValue;
        private Button showInfo;
        private TextBox infoText;
        private TextBox pathText;
    }
}
