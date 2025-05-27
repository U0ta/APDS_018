using APDS_018.Business.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APDS_018N.Forms
{
    public partial class PENForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly QuestionServices _questionServices;
        private string TestType;
        private int Id = 1;
        public PENForm(MainForm mainForm, QuestionServices questionServices, string testType)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _questionServices = questionServices;
            TestType = testType;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Id++;
            label4.Text = _questionServices.GetQuestionById(Id).NumQuestion.ToString() + "." + " "
                + _questionServices.GetQuestionById(Id).QuestionText;
        }

        private void PENForm_Load(object sender, EventArgs e)
        {
            label4.Text =_questionServices.GetQuestionById(Id).NumQuestion.ToString() + "." + " "
                + _questionServices.GetQuestionById(Id).QuestionText;
        }
    }
}
