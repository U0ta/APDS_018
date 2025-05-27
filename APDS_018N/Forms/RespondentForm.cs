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
    public partial class RespondentForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly RespondentServices _respondentServices;
        private readonly QuestionServices _questionServices;
        private readonly string TestType;
        public RespondentForm(MainForm mainForm, RespondentServices respondentServices,QuestionServices questionServices, string testType)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _respondentServices = respondentServices;
            _questionServices = questionServices;
            TestType = testType;
        }

        private void RespondentForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = TestType;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                var newRespondent = new Respondent
                {
                    Surname = textBox3.Text,
                    NameResp = textBox1.Text,
                    Midlename = textBox2.Text,
                    Sex = comboBox1.SelectedItem.ToString(),
                    Born = dateTimePicker1.Value
                };
                _respondentServices.AddRespondent(newRespondent);
                MessageBox.Show(
                    "Information sended!",
                    "Success",
                    MessageBoxButtons.OK
                );
                //
                var penForm = new PENForm(_mainForm, _questionServices, TestType);
                penForm.Show();
                this.Close();
            } catch (Exception ex) {
                MessageBox.Show(
                    "Invalid values",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}
