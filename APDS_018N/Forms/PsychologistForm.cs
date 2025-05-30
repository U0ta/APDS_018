using APDS_018.Business.Services;
using APDS_018.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APDS_018N.Forms
{
    public partial class PsychologistForm : Form
    {
        private readonly long _testId;
        private readonly RespondentServices _respondentService;
        private readonly TestingServices _testingService;
        private readonly ResultServices _resultService;

        public PsychologistForm(
            long testId,
            RespondentServices respondentService,
            TestingServices testingService,
            ResultServices resultService)
        {
            InitializeComponent();
            _testId = testId;
            _respondentService = respondentService;
            _testingService = testingService;
            _resultService = resultService;
            LoadRespondents();
        }

        private void LoadRespondents()
        {
            // Загрузка всех респондентов для данного теста
            var respondents = _testingService.GetTestingsByTest(_testId)
                .Select(t => t.Respondent)
                .Distinct()
                .ToList();

            dgvRespondents.DataSource = respondents;
        }

        private void btnAddRespondent_Click(object sender, EventArgs e)
        {
            var editForm = new RespondentEditForm();
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                _respondentService.AddRespondent(editForm.Respondent);
                LoadRespondents();
            }
        }

        private void btnViewTests_Click(object sender, EventArgs e)
        {
            if (dgvRespondents.CurrentRow?.DataBoundItem is Respondent respondent)
            {
                var testings = _testingService.GetTestingsByRespondent(respondent.Id);
                dgvTestings.DataSource = testings;
            }
        }

        private void btnViewResults_Click(object sender, EventArgs e)
        {
            if (dgvTestings.CurrentRow?.DataBoundItem is Testing testing)
            {
                var results = _resultService.GetResultsByTesting(testing.Id);
                dgvResults.DataSource = results;
            }
        }
        private void btnEditRespondent_Click(object sender, EventArgs e)
        {
            if (dgvRespondents.CurrentRow?.DataBoundItem is Respondent respondent)
            {
                var editForm = new RespondentEditForm(respondent);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _respondentService.UpdateRespondent(editForm.Respondent);
                    LoadRespondents();
                }
            }
        }

        private void btnDeleteRespondent_Click(object sender, EventArgs e)
        {
            if (dgvRespondents.CurrentRow?.DataBoundItem is Respondent respondent)
            {
                if (MessageBox.Show("Delete the respondent?", "Confirmation",
                    MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _respondentService.DeleteRespondent(respondent.Id);
                    LoadRespondents();
                }
            }
        }
    }
}
