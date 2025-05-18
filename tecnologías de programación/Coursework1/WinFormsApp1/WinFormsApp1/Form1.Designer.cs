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
            matrix = new DataGridView();
            showMatrixButton = new Button();
            chooseMatrixBox = new ComboBox();
            chooseMethodBox = new ComboBox();
            inputArrText = new TextBox();
            cntRows = new ComboBox();
            cntCols = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)matrix).BeginInit();
            SuspendLayout();
            // 
            // matrix
            // 
            matrix.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            matrix.Location = new Point(12, 73);
            matrix.Name = "matrix";
            matrix.Size = new Size(419, 243);
            matrix.TabIndex = 0;
            matrix.TabStop = false;
            // 
            // showMatrixButton
            // 
            showMatrixButton.Location = new Point(463, 222);
            showMatrixButton.Name = "showMatrixButton";
            showMatrixButton.Size = new Size(121, 33);
            showMatrixButton.TabIndex = 5;
            showMatrixButton.Text = "показать";
            showMatrixButton.UseVisualStyleBackColor = true;
            showMatrixButton.Click += showMatrixButton_Click;
            // 
            // chooseMatrixBox
            // 
            chooseMatrixBox.FormattingEnabled = true;
            chooseMatrixBox.Location = new Point(463, 159);
            chooseMatrixBox.Name = "chooseMatrixBox";
            chooseMatrixBox.Size = new Size(121, 30);
            chooseMatrixBox.TabIndex = 4;
            // 
            // chooseMethodBox
            // 
            chooseMethodBox.FormattingEnabled = true;
            chooseMethodBox.Items.AddRange(new object[] { "по строкам", "по столбцам", "змейкой" });
            chooseMethodBox.Location = new Point(463, 123);
            chooseMethodBox.Name = "chooseMethodBox";
            chooseMethodBox.Size = new Size(121, 30);
            chooseMethodBox.TabIndex = 3;
            // 
            // inputArrText
            // 
            inputArrText.Location = new Point(15, 28);
            inputArrText.Name = "inputArrText";
            inputArrText.ReadOnly = true;
            inputArrText.Size = new Size(569, 29);
            inputArrText.TabIndex = 0;
            inputArrText.TabStop = false;
            // 
            // cntRows
            // 
            cntRows.DropDownHeight = 50;
            cntRows.ForeColor = SystemColors.WindowText;
            cntRows.FormattingEnabled = true;
            cntRows.IntegralHeight = false;
            cntRows.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100" });
            cntRows.Location = new Point(463, 87);
            cntRows.Name = "cntRows";
            cntRows.Size = new Size(48, 30);
            cntRows.TabIndex = 1;
            cntRows.SelectedIndexChanged += cntRows_SelectedIndexChanged;
            // 
            // cntCols
            // 
            cntCols.DropDownHeight = 50;
            cntCols.FormattingEnabled = true;
            cntCols.IntegralHeight = false;
            cntCols.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26", "27", "28", "29", "30", "31", "32", "33", "34", "35", "36", "37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48", "49", "50", "51", "52", "53", "54", "55", "56", "57", "58", "59", "60", "61", "62", "63", "64", "65", "66", "67", "68", "69", "70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "81", "82", "83", "84", "85", "86", "87", "88", "89", "90", "91", "92", "93", "94", "95", "96", "97", "98", "99", "100" });
            cntCols.Location = new Point(536, 87);
            cntCols.Name = "cntCols";
            cntCols.Size = new Size(48, 30);
            cntCols.TabIndex = 2;
            cntCols.SelectedIndexChanged += cntCols_SelectedIndexChanged;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(616, 361);
            Controls.Add(cntCols);
            Controls.Add(cntRows);
            Controls.Add(inputArrText);
            Controls.Add(chooseMethodBox);
            Controls.Add(chooseMatrixBox);
            Controls.Add(showMatrixButton);
            Controls.Add(matrix);
            Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(5, 4, 5, 4);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)matrix).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView matrix;
        private Button showMatrixButton;
        private ComboBox chooseMatrixBox;
        private ComboBox chooseMethodBox;
        private TextBox inputArrText;
        private ComboBox cntRows;
        private ComboBox cntCols;
    }
}
