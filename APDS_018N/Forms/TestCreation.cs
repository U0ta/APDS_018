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
            MessageBox.Show(
                    "Test created",
                    "Success",
                    MessageBoxButtons.OK      
            );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            { 
                int checkId = Convert.ToInt32(textBox10.Text);
                Test? test = _testServices.GetTestById(checkId);
                if (test != null)
                {
                    textBox9.Text = $"Id: {test.Id}{Environment.NewLine}" +
                    $"NameTest: {test.NameTest}{Environment.NewLine}" +
                    $"Code: {test.Code}{Environment.NewLine}" +
                    $"RunFile: {test.RunFile}{Environment.NewLine}" +
                    $"Instruction: {test.Instruction}{Environment.NewLine}" +
                    $"Help: {test.Help}{Environment.NewLine}" +
                    $"Developer: {test.Developer}{Environment.NewLine}" +
                    $"Psycologist: {test.Psycologist}{Environment.NewLine}" +
                    $"Version: {test.Version}{Environment.NewLine}";
                }
                else
                {
                    MessageBox.Show(
                    "Invalid ID",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                    );
                }
            } catch (Exception ex)
            {
                MessageBox.Show(
                "Invalid ID type",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            long deleteId = 0;
            try
            {
                deleteId = Convert.ToInt64(textBox10.Text);
                _testServices.DeleteTest(deleteId);
                MessageBox.Show("Test deleted", "Success", MessageBoxButtons.OK);
                textBox9.Text = string.Empty;
            } catch (Exception ex)
            {
                MessageBox.Show(
                "Invalid ID type",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }
        }
    }
}
