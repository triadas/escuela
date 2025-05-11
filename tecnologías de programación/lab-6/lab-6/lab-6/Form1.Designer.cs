namespace lab_6
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
            gValues = new ListBox();
            button1 = new Button();
            yStepValue = new TextBox();
            ynValue = new TextBox();
            y0Value = new TextBox();
            yStepText = new Label();
            ynText = new Label();
            y0Text = new Label();
            xStepValue = new TextBox();
            xnValue = new TextBox();
            x0Value = new TextBox();
            xStepText = new Label();
            xnText = new Label();
            x0Text = new Label();
            GText = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            nudFileNumber = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudFileNumber).BeginInit();
            SuspendLayout();
            // 
            // gValues
            // 
            gValues.Font = new Font("Arial", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            gValues.FormattingEnabled = true;
            gValues.ItemHeight = 14;
            gValues.Location = new Point(476, 50);
            gValues.Name = "gValues";
            gValues.Size = new Size(99, 158);
            gValues.TabIndex = 0;
            gValues.TabStop = false;
            // 
            // button1
            // 
            button1.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button1.Location = new Point(252, 215);
            button1.Name = "button1";
            button1.Size = new Size(127, 53);
            button1.TabIndex = 7;
            button1.Text = "Рассчитать G(x,y)";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // yStepValue
            // 
            yStepValue.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            yStepValue.Location = new Point(319, 161);
            yStepValue.Name = "yStepValue";
            yStepValue.Size = new Size(68, 26);
            yStepValue.TabIndex = 6;
            // 
            // ynValue
            // 
            ynValue.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ynValue.Location = new Point(319, 99);
            ynValue.Name = "ynValue";
            ynValue.Size = new Size(68, 26);
            ynValue.TabIndex = 5;
            // 
            // y0Value
            // 
            y0Value.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            y0Value.Location = new Point(319, 39);
            y0Value.Name = "y0Value";
            y0Value.Size = new Size(68, 26);
            y0Value.TabIndex = 4;
            // 
            // yStepText
            // 
            yStepText.AutoSize = true;
            yStepText.Location = new Point(252, 164);
            yStepText.Name = "yStepText";
            yStepText.Size = new Size(61, 19);
            yStepText.TabIndex = 13;
            yStepText.Text = "step y:";
            // 
            // ynText
            // 
            ynText.AutoSize = true;
            ynText.Location = new Point(279, 102);
            ynText.Name = "ynText";
            ynText.Size = new Size(34, 19);
            ynText.TabIndex = 12;
            ynText.Text = "yn:";
            // 
            // y0Text
            // 
            y0Text.AutoSize = true;
            y0Text.Location = new Point(280, 42);
            y0Text.Name = "y0Text";
            y0Text.Size = new Size(33, 19);
            y0Text.TabIndex = 11;
            y0Text.Text = "y0:";
            // 
            // xStepValue
            // 
            xStepValue.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            xStepValue.Location = new Point(101, 162);
            xStepValue.Name = "xStepValue";
            xStepValue.Size = new Size(68, 26);
            xStepValue.TabIndex = 3;
            // 
            // xnValue
            // 
            xnValue.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            xnValue.Location = new Point(101, 100);
            xnValue.Name = "xnValue";
            xnValue.Size = new Size(68, 26);
            xnValue.TabIndex = 2;
            // 
            // x0Value
            // 
            x0Value.Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            x0Value.Location = new Point(101, 40);
            x0Value.Name = "x0Value";
            x0Value.Size = new Size(68, 26);
            x0Value.TabIndex = 1;
            // 
            // xStepText
            // 
            xStepText.AutoSize = true;
            xStepText.Location = new Point(37, 164);
            xStepText.Name = "xStepText";
            xStepText.Size = new Size(61, 19);
            xStepText.TabIndex = 19;
            xStepText.Text = "step x:";
            // 
            // xnText
            // 
            xnText.AutoSize = true;
            xnText.Location = new Point(64, 103);
            xnText.Name = "xnText";
            xnText.Size = new Size(34, 19);
            xnText.TabIndex = 18;
            xnText.Text = "xn:";
            // 
            // x0Text
            // 
            x0Text.AutoSize = true;
            x0Text.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            x0Text.Location = new Point(64, 43);
            x0Text.Name = "x0Text";
            x0Text.Size = new Size(31, 18);
            x0Text.TabIndex = 17;
            x0Text.Text = "x0:";
            // 
            // GText
            // 
            GText.AutoSize = true;
            GText.Location = new Point(490, 28);
            GText.Name = "GText";
            GText.Size = new Size(59, 19);
            GText.TabIndex = 20;
            GText.Text = "G(x,y):";
            // 
            // button2
            // 
            button2.Font = new Font("Arial", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button2.Location = new Point(37, 226);
            button2.Name = "button2";
            button2.Size = new Size(99, 42);
            button2.TabIndex = 21;
            button2.Text = "Заполнить по умолчанию";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Arial", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            button3.Location = new Point(476, 226);
            button3.Name = "button3";
            button3.Size = new Size(99, 42);
            button3.TabIndex = 22;
            button3.Text = "очистить значения G(x,y)";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(593, 226);
            button4.Name = "button4";
            button4.Size = new Size(92, 42);
            button4.TabIndex = 23;
            button4.Text = "R";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // nudFileNumber
            // 
            nudFileNumber.Location = new Point(593, 182);
            nudFileNumber.Maximum = new decimal(new int[] { 99999, 0, 0, 0 });
            nudFileNumber.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudFileNumber.Name = "nudFileNumber";
            nudFileNumber.Size = new Size(92, 26);
            nudFileNumber.TabIndex = 24;
            nudFileNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(730, 292);
            Controls.Add(nudFileNumber);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(GText);
            Controls.Add(xStepValue);
            Controls.Add(xnValue);
            Controls.Add(x0Value);
            Controls.Add(xStepText);
            Controls.Add(xnText);
            Controls.Add(x0Text);
            Controls.Add(yStepValue);
            Controls.Add(ynValue);
            Controls.Add(y0Value);
            Controls.Add(yStepText);
            Controls.Add(ynText);
            Controls.Add(y0Text);
            Controls.Add(button1);
            Controls.Add(gValues);
            Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)nudFileNumber).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox gValues;
        private Button button1;
        private TextBox yStepValue;
        private TextBox ynValue;
        private TextBox y0Value;
        private Label yStepText;
        private Label ynText;
        private Label y0Text;
        private TextBox xStepValue;
        private TextBox xnValue;
        private TextBox x0Value;
        private Label xStepText;
        private Label xnText;
        private Label x0Text;
        private Label GText;
        private Button button2;
        private Button button3;
        private Button button4;
        private NumericUpDown nudFileNumber;
    }
}
