namespace APDS_018N.Forms
{
    partial class RespondentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RespondentForm));
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(207, 9);
            label1.Name = "label1";
            label1.Size = new Size(375, 25);
            label1.TabIndex = 0;
            label1.Text = "Fill in the information about you";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Location = new Point(347, 68);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(158, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Location = new Point(347, 117);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(158, 23);
            textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            textBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            textBox3.Location = new Point(347, 167);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(158, 23);
            textBox3.TabIndex = 3;
            // 
            // comboBox1
            // 
            comboBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Male", "Female" });
            comboBox1.Location = new Point(347, 213);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 4;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(263, 76);
            label2.Name = "label2";
            label2.Size = new Size(42, 15);
            label2.TabIndex = 5;
            label2.Text = "Name:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(263, 125);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 6;
            label3.Text = "Midlename:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(263, 175);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 7;
            label4.Text = "Surname:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(263, 221);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 8;
            label5.Text = "Gender:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(263, 264);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 9;
            label6.Text = "Date of birth:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dateTimePicker1.Location = new Point(347, 256);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 10;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.Location = new Point(713, 415);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 11;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 415);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 12;
            button2.Text = "Send";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // RespondentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dateTimePicker1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "RespondentForm";
            Text = "Respondent";
            Load += this.RespondentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private Button button2;
    }
}