namespace APDS_018N.Forms
{
    partial class PsychologistLoginForm
    {
        private TextBox txtTestId;
        private TextBox txtPassword;
        private Button btnLogin;
        private Button btnCancel;
        private Label label1;
        private Label label2;

        private void InitializeComponent()
        {
            this.txtTestId = new TextBox();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.btnCancel = new Button();
            this.label1 = new Label();
            this.label2 = new Label();

            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new Point(20, 20);
            this.label1.Text = "Test ID:";
            // 
            // txtTestId
            // 
            this.txtTestId.Location = new Point(120, 20);
            this.txtTestId.Size = new Size(200, 20);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new Point(20, 60);
            this.label2.Text = "Code:";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new Point(120, 60);
            this.txtPassword.Size = new Size(200, 20);
            this.txtPassword.PasswordChar = '*';
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new Point(120, 100);
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += btnLogin_Click;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(220, 100);
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += btnCancel_Click;
            // 
            // PsychologistLoginForm
            // 
            this.ClientSize = new Size(350, 150);
            this.Text = "Psychologist mode - login";
            this.Controls.AddRange(new Control[] {
            label1, label2, txtTestId, txtPassword, btnLogin, btnCancel
        });
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
        }
    }
}