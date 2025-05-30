namespace APDS_018N.Forms
{
    partial class PsychologistForm
    {
        // Основные элементы
        private DataGridView dgvRespondents;
        private DataGridView dgvTestings;
        private DataGridView dgvResults;
        private Button btnAddRespondent;
        private Button btnEditRespondent;
        private Button btnDeleteRespondent;
        private Button btnViewTests;
        private Button btnViewResults;

        private void InitializeComponent()
        {
            // Настройка DataGridView для респондентов
            dgvRespondents = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 200,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dgvTestings = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 200,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            dgvResults = new DataGridView
            {
                Dock = DockStyle.Top,
                Height = 200,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Аналогично настраиваем dgvTestings и dgvResults

            // Кнопки управления
            btnAddRespondent = new Button { Text = "Add", Dock = DockStyle.Top };
            btnEditRespondent = new Button { Text = "Edit", Dock = DockStyle.Top };
            btnDeleteRespondent = new Button { Text = "Delete", Dock = DockStyle.Top };
            btnViewTests = new Button { Text = "View Tests", Dock = DockStyle.Top };
            btnViewResults = new Button { Text = "View Results", Dock = DockStyle.Top };

            // Расположение элементов
            var leftPanel = new Panel { Dock = DockStyle.Left, Width = 200 };
            leftPanel.Controls.AddRange(new Control[] { btnAddRespondent, btnEditRespondent, btnDeleteRespondent, btnViewTests, btnViewResults });

            var mainPanel = new Panel { Dock = DockStyle.Fill };
            mainPanel.Controls.Add(dgvResults);
            mainPanel.Controls.Add(dgvTestings);
            mainPanel.Controls.Add(dgvRespondents);

            this.Controls.Add(mainPanel);
            this.Controls.Add(leftPanel);

            // Привязка событий
            btnAddRespondent.Click += btnAddRespondent_Click;
            btnEditRespondent.Click += btnEditRespondent_Click;
            this.btnDeleteRespondent.Click += btnDeleteRespondent_Click;
            this.btnViewTests.Click += btnViewTests_Click;
            this.btnViewResults.Click += btnViewResults_Click;
            // ... остальные обработчики
        }

    }
}