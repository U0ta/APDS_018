using APDS_018.Business.Services;
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
    public partial class PsychologistLoginForm : Form
    {
        private readonly TestServices _testService;
        private readonly TestingServices _testingService;
        private readonly RespondentServices _respondentService;
        private readonly ResultServices _resultService;

        public PsychologistLoginForm(TestServices testService, TestingServices testingServices,
            RespondentServices respondentServices, ResultServices resultServices)
        {
            InitializeComponent();
            _testService = testService;
            _testingService = testingServices;
            _respondentService = respondentServices;
            _resultService = resultServices;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (long.TryParse(txtTestId.Text, out long testId))
            {
                var test = _testService.GetTestById(testId);

                if (test != null && test.Code == txtPassword.Text)
                {
                    var psychologistForm = new PsychologistForm(
                        testId,
                        _respondentService,
                        _testingService,
                        _resultService
                    );
                    psychologistForm.TopMost = true;
                    psychologistForm.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid Test ID ot code, ", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
