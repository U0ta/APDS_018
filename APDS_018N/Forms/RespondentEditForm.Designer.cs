namespace APDS_018N.Forms
{
    partial class RespondentEditForm
    {
        private TextBox txtSurname;
        private TextBox txtName;
        private TextBox txtMidlename;
        private ComboBox cmbSex;
        private DateTimePicker dtpBorn;
        private Button btnSave;
        private Button btnCancel;
        private Label[] labels;

        private void InitializeComponent()
        {
            this.txtSurname = new TextBox();
            this.txtName = new TextBox();
            this.txtMidlename = new TextBox();
            this.cmbSex = new ComboBox();
            this.dtpBorn = new DateTimePicker();
            this.btnSave = new Button();
            this.btnCancel = new Button();

            // Labels
            string[] labelTexts = { "Surname:", "Name:", "Midlename:", "Gender:", "Born:" };
            labels = new Label[labelTexts.Length];
            for (int i = 0; i < labelTexts.Length; i++)
            {
                labels[i] = new Label
                {
                    Text = labelTexts[i],
                    Location = new Point(20, 20 + i * 40),
                    AutoSize = true
                };
            }

            // Поля ввода
            txtSurname.Location = new Point(150, 20);
            txtName.Location = new Point(150, 60);
            txtMidlename.Location = new Point(150, 100);

            cmbSex.Location = new Point(150, 140);
            cmbSex.Items.AddRange(new object[] { "Male", "Female" });
            cmbSex.DropDownStyle = ComboBoxStyle.DropDownList;

            dtpBorn.Location = new Point(150, 180);
            dtpBorn.Format = DateTimePickerFormat.Short;

            // Кнопки
            btnSave.Text = "Save";
            btnSave.Location = new Point(80, 240);
            btnSave.Click += btnSave_Click;

            btnCancel.Text = "Cancel";
            btnCancel.Location = new Point(180, 240);
            btnCancel.Click += (s, e) => this.DialogResult = DialogResult.Cancel;

            // Форма
            this.ClientSize = new Size(300, 300);
            this.Text = "Respondent edit";
            this.Controls.AddRange(new Control[] {
            txtSurname, txtName, txtMidlename, cmbSex, dtpBorn, btnSave, btnCancel
        });
            this.Controls.AddRange(labels);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
        }
    }
}