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
            tabControl = new TabControl();
            tabPage1 = new TabPage();
            txtValue = new TextBox();
            vScrollBar = new VScrollBar();
            hScrollBar = new HScrollBar();
            tabPage2 = new TabPage();
            chkNonZero = new CheckBox();
            chkZero = new CheckBox();
            chkNegative = new CheckBox();
            chkPositive = new CheckBox();
            tabPage3 = new TabPage();
            dataGridViewMatrix = new DataGridView();
            tabControl.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMatrix).BeginInit();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage2);
            tabControl.Controls.Add(tabPage3);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(800, 450);
            tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtValue);
            tabPage1.Controls.Add(vScrollBar);
            tabPage1.Controls.Add(hScrollBar);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(792, 422);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Прицел";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtValue
            // 
            txtValue.Location = new Point(377, 197);
            txtValue.Name = "txtValue";
            txtValue.ReadOnly = true;
            txtValue.Size = new Size(29, 23);
            txtValue.TabIndex = 2;
            // 
            // vScrollBar
            // 
            vScrollBar.Dock = DockStyle.Right;
            vScrollBar.LargeChange = 1;
            vScrollBar.Location = new Point(772, 3);
            vScrollBar.Name = "vScrollBar";
            vScrollBar.Size = new Size(17, 399);
            vScrollBar.TabIndex = 1;
            // 
            // hScrollBar
            // 
            hScrollBar.Dock = DockStyle.Bottom;
            hScrollBar.LargeChange = 1;
            hScrollBar.Location = new Point(3, 402);
            hScrollBar.Name = "hScrollBar";
            hScrollBar.Size = new Size(786, 17);
            hScrollBar.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(chkNonZero);
            tabPage2.Controls.Add(chkZero);
            tabPage2.Controls.Add(chkNegative);
            tabPage2.Controls.Add(chkPositive);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(792, 422);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Фильтры";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkNonZero
            // 
            chkNonZero.AutoSize = true;
            chkNonZero.Location = new Point(84, 156);
            chkNonZero.Name = "chkNonZero";
            chkNonZero.Size = new Size(88, 19);
            chkNonZero.TabIndex = 3;
            chkNonZero.Text = "Ненулевые";
            chkNonZero.UseVisualStyleBackColor = true;
            // 
            // chkZero
            // 
            chkZero.AutoSize = true;
            chkZero.Location = new Point(84, 124);
            chkZero.Name = "chkZero";
            chkZero.Size = new Size(75, 19);
            chkZero.TabIndex = 2;
            chkZero.Text = "Нулевые";
            chkZero.UseVisualStyleBackColor = true;
            // 
            // chkNegative
            // 
            chkNegative.AutoSize = true;
            chkNegative.Location = new Point(86, 94);
            chkNegative.Name = "chkNegative";
            chkNegative.Size = new Size(113, 19);
            chkNegative.TabIndex = 1;
            chkNegative.Text = "Отрицательные";
            chkNegative.UseVisualStyleBackColor = true;
            // 
            // chkPositive
            // 
            chkPositive.AutoSize = true;
            chkPositive.Location = new Point(87, 62);
            chkPositive.Name = "chkPositive";
            chkPositive.Size = new Size(118, 19);
            chkPositive.TabIndex = 0;
            chkPositive.Text = "\tПоложительные";
            chkPositive.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dataGridViewMatrix);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(792, 422);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Матрица";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewMatrix
            // 
            dataGridViewMatrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMatrix.Dock = DockStyle.Fill;
            dataGridViewMatrix.Location = new Point(3, 3);
            dataGridViewMatrix.Name = "dataGridViewMatrix";
            dataGridViewMatrix.ReadOnly = true;
            dataGridViewMatrix.Size = new Size(786, 416);
            dataGridViewMatrix.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tabControl);
            Name = "Form1";
            Text = " ";
            Load += Form1_Load;
            tabControl.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewMatrix).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private VScrollBar vScrollBar;
        private HScrollBar hScrollBar;
        private TabPage tabPage3;
        private TextBox txtValue;
        private CheckBox chkNonZero;
        private CheckBox chkZero;
        private CheckBox chkNegative;
        private CheckBox chkPositive;
        private DataGridView dataGridViewMatrix;
    }
}
