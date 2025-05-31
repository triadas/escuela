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
            browseButton = new Button();
            selectButton = new Button();
            saveButton = new Button();
            loadButton = new Button();
            selectedFiles = new ListBox();
            picture = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)picture).BeginInit();
            SuspendLayout();
            // 
            // browseButton
            // 
            browseButton.Location = new Point(24, 252);
            browseButton.Name = "browseButton";
            browseButton.Size = new Size(75, 33);
            browseButton.TabIndex = 0;
            browseButton.Text = "обзор";
            browseButton.UseVisualStyleBackColor = true;
            browseButton.Click += browseButton_Click;
            // 
            // selectButton
            // 
            selectButton.Location = new Point(105, 252);
            selectButton.Name = "selectButton";
            selectButton.Size = new Size(80, 33);
            selectButton.TabIndex = 1;
            selectButton.Text = "выбрать";
            selectButton.UseVisualStyleBackColor = true;
            selectButton.Click += selectButton_Click;
            // 
            // saveButton
            // 
            saveButton.Location = new Point(445, 12);
            saveButton.Name = "saveButton";
            saveButton.Size = new Size(91, 33);
            saveButton.TabIndex = 2;
            saveButton.Text = "созранить";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // loadButton
            // 
            loadButton.Location = new Point(445, 51);
            loadButton.Name = "loadButton";
            loadButton.Size = new Size(91, 33);
            loadButton.TabIndex = 3;
            loadButton.Text = "загрузить";
            loadButton.UseVisualStyleBackColor = true;
            loadButton.Click += loadButton_Click;
            // 
            // selectedFiles
            // 
            selectedFiles.Font = new Font("Arial", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            selectedFiles.FormattingEnabled = true;
            selectedFiles.ItemHeight = 15;
            selectedFiles.Location = new Point(24, 45);
            selectedFiles.Name = "selectedFiles";
            selectedFiles.Size = new Size(147, 184);
            selectedFiles.TabIndex = 4;
            // 
            // picture
            // 
            picture.Location = new Point(199, 45);
            picture.Name = "picture";
            picture.Size = new Size(198, 184);
            picture.SizeMode = PictureBoxSizeMode.Zoom;
            picture.TabIndex = 6;
            picture.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(548, 303);
            Controls.Add(picture);
            Controls.Add(selectedFiles);
            Controls.Add(loadButton);
            Controls.Add(saveButton);
            Controls.Add(selectButton);
            Controls.Add(browseButton);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)picture).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button browseButton;
        private Button selectButton;
        private Button saveButton;
        private Button loadButton;
        private ListBox selectedFiles;
        private PictureBox picture;
    }
}
