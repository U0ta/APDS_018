using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APDS_018N;
using APDS_018.Data.Models;
using APDS_018.Business.Services;

namespace APDS_018N.Forms
{
    public partial class TestCreation : Form
    {
        private readonly MainForm _mainForm;
        private readonly TestServices _testServices;
        public TestCreation(MainForm mainForm, TestServices testServices)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _testServices = testServices;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var newTest = new Test
            {
                NameTest = textBox1.Text,
                Code = textBox2.Text,
                RunFile = textBox3.Text,
                Instruction = textBox4.Text,
                Help = textBox5.Text,
                Developer = textBox6.Text,
                Psycologist = textBox7.Text,
                Version = textBox8.Text
            };
            _testServices.AddTest(newTest);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int checkId = Convert.ToInt32(textBox10.Text);
            Test? test = _testServices.GetTestById(checkId);
            textBox9.Text = $"Id: {test.Id}\n" +
                $"NameTest: {test.NameTest}\n" +
                $"Code: {test.Code} \n" +
                $"RunFile: {test.RunFile} \n" +
                $"Instruction: {test.Instruction} \n" +
                $"Help: {test.Help}  \n" +
                $"Developer: {test.Developer}  \n" +
                $"Psycologist: {test.Psycologist}  \n" +
                $"Version: {test.Version}  \n";
        }
    }
}
