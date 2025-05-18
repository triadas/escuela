namespace WinFormsApp1
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
            btnStart = new Button();
            btnPauseResume = new Button();
            btnStop = new Button();
            lblIteration = new Label();
            cmbPriority = new ComboBox();
            SuspendLayout();
            // 
            // btnStart
            // 
            btnStart.Location = new Point(267, 81);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(327, 32);
            btnStart.TabIndex = 0;
            btnStart.Text = "Запуск потока";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnPauseResume
            // 
            btnPauseResume.Location = new Point(267, 119);
            btnPauseResume.Name = "btnPauseResume";
            btnPauseResume.Size = new Size(327, 32);
            btnPauseResume.TabIndex = 1;
            btnPauseResume.Text = "Пауза / Возобновление";
            btnPauseResume.UseVisualStyleBackColor = true;
            btnPauseResume.Click += btnPauseResume_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(267, 157);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(327, 32);
            btnStop.TabIndex = 2;
            btnStop.Text = "Остановить поток";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lblIteration
            // 
            lblIteration.AutoSize = true;
            lblIteration.Location = new Point(267, 230);
            lblIteration.Name = "lblIteration";
            lblIteration.Size = new Size(327, 25);
            lblIteration.TabIndex = 4;
            lblIteration.Text = "Для отображения номера итерации";
            // 
            // cmbPriority
            // 
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Items.AddRange(new object[] { "Низкий", "Обычный", "Высокий" });
            cmbPriority.Location = new Point(267, 268);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(327, 33);
            cmbPriority.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(624, 339);
            Controls.Add(cmbPriority);
            Controls.Add(lblIteration);
            Controls.Add(btnStop);
            Controls.Add(btnPauseResume);
            Controls.Add(btnStart);
            Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5);
            Name = "MainForm";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnStart;
        private Button btnPauseResume;
        private Button btnStop;
        private Label lblIteration;
        private ComboBox cmbPriority;
    }
}
