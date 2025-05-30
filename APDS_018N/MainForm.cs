using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APDS_018.Business.Services;
using APDS_018N.Forms;

namespace APDS_018N
{
    public partial class MainForm : Form
    {
        private readonly TestServices _testService;
        private readonly QuestionServices _questionService;
        private readonly RespondentServices _respondentService;
        private readonly TestingServices _testingServices;
        private readonly ProtocolServices _protocolServices;
        private readonly ResultServices _resultServices;

        public MainForm(TestServices testService,
                        QuestionServices questionService,
                        RespondentServices respondentService,
                        TestingServices testingServices,
                        ProtocolServices protocolServices,
                        ResultServices resultServices
        )
        {
            InitializeComponent();
            _testService = testService;
            _questionService = questionService;
            _respondentService = respondentService;
            _testingServices = testingServices;
            _protocolServices = protocolServices;
            _resultServices = resultServices;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void testCreationModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var testcreation = new TestCreation(this, _testService);
            testcreation.Show();
            this.Hide();
        }

        private void questionCreateModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var questioncreation = new QuestionCreation(this, _questionService);
            questioncreation.Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var respondent = new RespondentForm(this, _respondentService, _questionService, "PEN", _testingServices, _resultServices, _protocolServices);
            respondent.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var respondent = new RespondentForm(this, _respondentService, _questionService, "RBT", _testingServices, _resultServices, _protocolServices);
            respondent.Show();
            this.Hide();
        }

        private void btnPsychologistMode_Click(object sender, EventArgs e)
        {
            var loginForm = new PsychologistLoginForm( _testService, _testingServices, _respondentService, _resultServices);
            loginForm.ShowDialog();
        }
    }
}
