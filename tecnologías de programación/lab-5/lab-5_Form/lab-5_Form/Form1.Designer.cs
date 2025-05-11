namespace lab_5_Form
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
            enterText = new Label();
            value = new TextBox();
            setDefaultValue = new Button();
            setValue = new Button();
            SuspendLayout();
            // 
            // enterText
            // 
            enterText.AutoSize = true;
            enterText.Location = new Point(100, 59);
            enterText.Name = "enterText";
            enterText.Size = new Size(87, 18);
            enterText.TabIndex = 0;
            enterText.Text = "enter value:";
            // 
            // value
            // 
            value.Location = new Point(201, 56);
            value.Name = "value";
            value.Size = new Size(122, 26);
            value.TabIndex = 1;
            // 
            // setDefaultValue
            // 
            setDefaultValue.Location = new Point(100, 111);
            setDefaultValue.Name = "setDefaultValue";
            setDefaultValue.Size = new Size(101, 44);
            setDefaultValue.TabIndex = 2;
            setDefaultValue.Text = "Set default value";
            setDefaultValue.UseVisualStyleBackColor = true;
            setDefaultValue.Click += setDefaultValue_Click;
            // 
            // setValue
            // 
            setValue.Location = new Point(219, 111);
            setValue.Name = "setValue";
            setValue.Size = new Size(104, 44);
            setValue.TabIndex = 3;
            setValue.Text = "Set value";
            setValue.UseVisualStyleBackColor = true;
            setValue.Click += setValue_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 230);
            Controls.Add(setValue);
            Controls.Add(setDefaultValue);
            Controls.Add(value);
            Controls.Add(enterText);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            Margin = new Padding(4);
            Name = "MainForm";
            Text = "MainForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label enterText;
        private TextBox value;
        private Button setDefaultValue;
        private Button setValue;
    }
}
