namespace APDS_018N
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            menuToolStripMenuItem = new ToolStripMenuItem();
            testCreationModeToolStripMenuItem = new ToolStripMenuItem();
            questionCreateModeToolStripMenuItem = new ToolStripMenuItem();
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            btnPsychologistMode = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            menuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { testCreationModeToolStripMenuItem, questionCreateModeToolStripMenuItem });
            menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            menuToolStripMenuItem.Size = new Size(50, 20);
            menuToolStripMenuItem.Text = "Menu";
            // 
            // testCreationModeToolStripMenuItem
            // 
            testCreationModeToolStripMenuItem.Name = "testCreationModeToolStripMenuItem";
            testCreationModeToolStripMenuItem.Size = new Size(191, 22);
            testCreationModeToolStripMenuItem.Text = "Test creation mode";
            testCreationModeToolStripMenuItem.Click += testCreationModeToolStripMenuItem_Click;
            // 
            // questionCreateModeToolStripMenuItem
            // 
            questionCreateModeToolStripMenuItem.Name = "questionCreateModeToolStripMenuItem";
            questionCreateModeToolStripMenuItem.Size = new Size(191, 22);
            questionCreateModeToolStripMenuItem.Text = "Question create mode";
            questionCreateModeToolStripMenuItem.Click += questionCreateModeToolStripMenuItem_Click;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button1.Location = new Point(268, 239);
            button1.Name = "button1";
            button1.Size = new Size(252, 35);
            button1.TabIndex = 1;
            button1.Text = "Eysenck Personality Inventory PEN";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            button2.Location = new Point(268, 280);
            button2.Name = "button2";
            button2.Size = new Size(252, 35);
            button2.TabIndex = 2;
            button2.Text = "Red and black Schulte table";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Cascadia Code", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(163, 98);
            label1.Name = "label1";
            label1.Size = new Size(485, 75);
            label1.TabIndex = 3;
            label1.Text = "Automated system of psychodiagnostics\r\nAuthor: Smirnov M.A., student of group 4503\r\nVariant: 18";
            label1.Click += label1_Click;
            // 
            // btnPsychologistMode
            // 
            btnPsychologistMode.Anchor = AnchorStyles.Bottom;
            btnPsychologistMode.Location = new Point(268, 321);
            btnPsychologistMode.Name = "btnPsychologistMode";
            btnPsychologistMode.Size = new Size(252, 27);
            btnPsychologistMode.TabIndex = 4;
            btnPsychologistMode.Text = "Psychologist mode";
            btnPsychologistMode.UseVisualStyleBackColor = true;
            btnPsychologistMode.Click += btnPsychologistMode_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnPsychologistMode);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "APDS";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuToolStripMenuItem;
        private ToolStripMenuItem testCreationModeToolStripMenuItem;
        private ToolStripMenuItem questionCreateModeToolStripMenuItem;
        private Button button1;
        private Button button2;
        private Label label1;
        private Button btnPsychologistMode;
    }
}