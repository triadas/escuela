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
            treeViewRegistry = new TreeView();
            textBoxValue = new TextBox();
            buttonWrite = new Button();
            buttonBackup = new Button();
            buttonRestore = new Button();
            listBoxLog = new ListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // treeViewRegistry
            // 
            treeViewRegistry.Location = new Point(33, 44);
            treeViewRegistry.Name = "treeViewRegistry";
            treeViewRegistry.Size = new Size(236, 171);
            treeViewRegistry.TabIndex = 0;
            treeViewRegistry.BeforeExpand += treeViewRegistry_BeforeExpand;
            treeViewRegistry.AfterSelect += treeViewRegistry_AfterSelect;
            // 
            // textBoxValue
            // 
            textBoxValue.Location = new Point(332, 56);
            textBoxValue.Name = "textBoxValue";
            textBoxValue.Size = new Size(137, 23);
            textBoxValue.TabIndex = 1;
            // 
            // buttonWrite
            // 
            buttonWrite.Location = new Point(332, 84);
            buttonWrite.Name = "buttonWrite";
            buttonWrite.Size = new Size(137, 23);
            buttonWrite.TabIndex = 2;
            buttonWrite.Text = "Записать";
            buttonWrite.UseVisualStyleBackColor = true;
            buttonWrite.Click += buttonWrite_Click;
            // 
            // buttonBackup
            // 
            buttonBackup.Location = new Point(332, 113);
            buttonBackup.Name = "buttonBackup";
            buttonBackup.Size = new Size(137, 23);
            buttonBackup.TabIndex = 3;
            buttonBackup.Text = "Создать бэкап";
            buttonBackup.UseVisualStyleBackColor = true;
            buttonBackup.Click += buttonBackup_Click;
            // 
            // buttonRestore
            // 
            buttonRestore.Location = new Point(332, 142);
            buttonRestore.Name = "buttonRestore";
            buttonRestore.Size = new Size(137, 23);
            buttonRestore.TabIndex = 4;
            buttonRestore.Text = "Восстановить";
            buttonRestore.UseVisualStyleBackColor = true;
            buttonRestore.Click += buttonRestore_Click;
            // 
            // listBoxLog
            // 
            listBoxLog.FormattingEnabled = true;
            listBoxLog.ItemHeight = 15;
            listBoxLog.Location = new Point(349, 206);
            listBoxLog.Name = "listBoxLog";
            listBoxLog.Size = new Size(120, 94);
            listBoxLog.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(37, 15);
            label1.Name = "label1";
            label1.Size = new Size(44, 15);
            label1.TabIndex = 6;
            label1.Text = "Реестр";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(349, 29);
            label2.Name = "label2";
            label2.Size = new Size(99, 15);
            label2.TabIndex = 7;
            label2.Text = "Значение ключа";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(366, 188);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 8;
            label3.Text = "Лог изменений";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(509, 321);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listBoxLog);
            Controls.Add(buttonRestore);
            Controls.Add(buttonBackup);
            Controls.Add(buttonWrite);
            Controls.Add(textBoxValue);
            Controls.Add(treeViewRegistry);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TreeView treeViewRegistry;
        private TextBox textBoxValue;
        private Button buttonWrite;
        private Button buttonBackup;
        private Button buttonRestore;
        private ListBox listBoxLog;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
