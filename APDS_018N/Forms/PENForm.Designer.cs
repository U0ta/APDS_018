namespace APDS_018N.Forms
{
    partial class PENForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PENForm));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            checkedListBox1 = new CheckedListBox();
            label4 = new Label();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(332, 9);
            label1.Name = "label1";
            label1.Size = new Size(133, 25);
            label1.TabIndex = 0;
            label1.Text = "Instruction";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(143, 34);
            label2.Name = "label2";
            label2.Size = new Size(513, 105);
            label2.TabIndex = 1;
            label2.Text = resources.GetString("label2.Text");
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(344, 156);
            label3.Name = "label3";
            label3.Size = new Size(100, 25);
            label3.TabIndex = 2;
            label3.Text = "Question";
            // 
            // checkedListBox1
            // 
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Items.AddRange(new object[] { "Да", "Нет" });
            checkedListBox1.Location = new Point(332, 274);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.Size = new Size(120, 40);
            checkedListBox1.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(143, 195);
            label4.MaximumSize = new Size(500, 300);
            label4.Name = "label4";
            label4.Size = new Size(0, 17);
            label4.TabIndex = 4;
            // 
            // button1
            // 
            button1.Location = new Point(12, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 5;
            button1.Text = "Further";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // PENForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(checkedListBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "PENForm";
            Text = "EPI";
            Load += PENForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private CheckedListBox checkedListBox1;
        private Label label4;
        private Button button1;
    }
}