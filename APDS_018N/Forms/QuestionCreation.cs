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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace APDS_018N.Forms
{
    public partial class QuestionCreation : Form
    {
        private readonly MainForm _mainForm;
        private readonly QuestionServices _questionServices;
        public QuestionCreation(MainForm mainForm, QuestionServices questionServices)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _questionServices = questionServices;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                var newQuestion = new Question
                {
                    TestId = Convert.ToInt64(textBox1.Text),
                    NumQuestion = Convert.ToInt64(textBox2.Text),
                    QuestionText = textBox3.Text,
                    QuestionType = textBox4.Text,
                    QuestionFile = textBox5.Text,
                };
                _questionServices.AddQuestion(newQuestion);
                MessageBox.Show(
                        "Question created",
                        "Success",
                        MessageBoxButtons.OK
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                "Invalid type of entered values",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error
                );
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int checkId = Convert.ToInt32(textBox10.Text);
                Question? question = _questionServices.GetQuestionById(checkId);
                if (question != null)
                {
                    textBox9.Text = $"Id: {question.Id}{Environment.NewLine}" +
                    $"Test ID: {question.TestId}{Environment.NewLine}" +
                    $"Question Number: {question.NumQuestion}{Environment.NewLine}" +
                    $"Text: {question.QuestionText}{Environment.NewLine}" +
                    $"Type: {question.QuestionType}{Environment.NewLine}" +
                    $"File: {question.QuestionFile}{Environment.NewLine}";
                    if (question.Test != null)
                    {
                        textBox9.Text += $"Test: {question.Test.NameTest}{Environment.NewLine}";
                    }

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
            }
            catch (Exception ex)
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
                _questionServices.DeleteQuestion(deleteId);
                MessageBox.Show("Question deleted", "Success", MessageBoxButtons.OK);
                textBox9.Text = string.Empty;
            }
            catch (Exception ex)
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

