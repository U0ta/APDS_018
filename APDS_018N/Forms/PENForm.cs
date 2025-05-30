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
using APDS_018.Data;
using APDS_018.Data.Models;

namespace APDS_018N.Forms
{
    public partial class PENForm : Form
    {
        private readonly MainForm _mainForm;
        private readonly QuestionServices _questionServices;
        private readonly TestingServices _testingServices;
        private readonly ProtocolServices _protocolServices;
        private readonly ResultServices _resultServices;
        private Testing _testing;
        private int questionQuantity = 101;
        private string rbText;
        private string TestType;
        private int TestId;
        private int Id = 1;
        private long _respondentId;
        private long[] extraversion_introversion_yes = { 1, 5, 10, 15, 18, 26, 34, 38, 42, 50, 54, 58, 62, 66, 70,
                                                        74, 77, 81, 90, 92, 96};
        private long[] extraversion_introversion_no = { 22, 30, 46, 84 };
        private long[] neuroticism_yes = { 3, 7, 12, 16, 20, 24, 28, 32, 36, 40, 44, 48, 52, 56, 60,
                                        64, 68, 72, 75, 79, 83, 86, 89, 94, 98};
        private long[] psychoticism_yes = { 14, 23, 27, 31, 35, 47, 51, 55, 71, 85, 88, 93, 97 };
        private long[] psychoticism_no = { 2, 6, 9, 11, 19, 39, 43, 59, 63, 67, 78, 100 };
        private long[] lie_yes = { 13, 21, 33, 37, 61, 73, 87, 99 };
        private long[] lie_no = { 4, 8, 17, 25, 29, 41, 45, 49, 53, 57, 65, 69, 76, 80, 82, 91, 95 };
        private int ex_yes = 0;
        private int ex_no = 0;
        private int ne_yes = 0;
        private int psy_yes = 0;
        private int psy_no = 0;
        private int l_yes = 0;
        private int l_no = 0;
        private string status = "";

        public PENForm(MainForm mainForm, QuestionServices questionServices, string testType,
            long respondentId, TestingServices testingServices,
            ResultServices resultServices, ProtocolServices protocolServices)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _questionServices = questionServices;
            TestType = testType;
            _respondentId = respondentId;
            _testingServices = testingServices;
            _resultServices = resultServices;
            _protocolServices = protocolServices;
        }

        private int secondsPassed = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            secondsPassed++;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            bool isRbActivated = false;
            if (radioButton1.Checked || radioButton2.Checked)
            {
                isRbActivated = true;
                secondsPassed = 0;
            }
            if (radioButton1.Checked)
            {
                rbText = radioButton1.Text;
            }
            if (radioButton2.Checked)
            {
                rbText = radioButton2.Text;
            }
            if (Id == 1) { timer1.Start(); }
            //
            if (l_yes > 10)
            {
                Id = 1;
                ex_yes = 0;
                ex_no = 0;
                ne_yes = 0;
                psy_yes = 0;
                psy_no = 0;
                l_yes = 0;
                l_no = 0;
                label4.Text = _questionServices.GetQuestionById(Id).NumQuestion.ToString() + "." + " "
                            + _questionServices.GetQuestionById(Id).QuestionText;
                MessageBox.Show(
                    "Вы брешите, товарищ!\n" +
                    "Придётся заново пройти тестирование.\n",
                    "Lie",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }

            //
            if (_questionServices.GetQuestionById(Id) == null || _questionServices.GetQuestionById(Id).NumQuestion > questionQuantity)
            {
                if (ne_yes >= 16)
                {
                    if (ex_yes <= 7)
                    {
                        status += "Меланхолик (М) – сдержанный, пессимистический, трезвый, ригидный.";
                    }
                    else if (ex_yes > 7 && ex_yes < 15)
                    {
                        status += "Меланхолически-холерический тип (MX) – добросовестный, капризный, нейротичный, обидчивый, неспокойный.";
                    }
                    else
                    {
                        status = "Холерик (X) – агрессивный, вспыльчивый, меняющий свои взгляды, импульсивный.";
                    }
                }
                else if (ne_yes > 8 && ne_yes < 16)
                {
                    if (ex_yes <= 7)
                    {
                        status += "Флегматико-меланхолический (ФМ) тип – старательный, пассивный, интроверт, тихий, необщительный.";
                    }
                    else if (ex_yes > 7 && ex_yes < 15)
                    {
                        status += "Меланхолик (М) – сдержанный, пессимистический, трезвый, ригидный.";
                    }
                    else
                    {
                        status = "Холерически-сангвинический тип (ХС) – оптимистический, активный, экстравертированный, общительный, доступный.";
                    }
                }
                else
                {
                    if (ex_yes <= 7)
                    {
                        status += "Флегматик (Ф) – надежный, владеющий собой, миролюбивый, рассудительный.";
                    }
                    else if (ex_yes > 7 && ex_yes < 15)
                    {
                        status += "Сангвинически-флегматический тип (СФ) – беззаботный, лидирующий, стабильный, спокойный, уравновешенный.";
                    }
                    else
                    {
                        status = "Сангвиник (С) – говорливый, быстро реагирующий, непринужденный, живой.";
                    }
                }
                MessageBox.Show(
                    $"Тест завершён!\n" +
                    $"Шкала экстроверсия-интроверсия: {ex_yes}\n" +
                    $"Шкала нейротизма: {ne_yes}\n" +
                    $"Шкала психотизма: {psy_yes}\n" +
                    $"Шкала лжи: {l_yes}\n" +
                    $"Ваш тип личности: {status}\n",
                    "Test results",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );




                //Result
                var result_ex = new Result
                {
                    ParamResultId = 1,
                    TestingId = _testing.Id,
                    ValueResult = ex_yes.ToString()
                };
                _resultServices.AddResult(result_ex);
                var result_ne = new Result
                {
                    ParamResultId = 2,
                    TestingId = _testing.Id,
                    ValueResult = ne_yes.ToString()
                };
                _resultServices.AddResult(result_ne);
                var result_psy = new Result
                {
                    ParamResultId = 3,
                    TestingId = _testing.Id,
                    ValueResult = psy_yes.ToString()
                };
                _resultServices.AddResult(result_psy);
                var result_l = new Result
                {
                    ParamResultId = 4,
                    TestingId = _testing.Id,
                    ValueResult = l_yes.ToString()
                };
                _resultServices.AddResult(result_l);
                _mainForm.Show();
                this.Close();
            }

            //
            if (isRbActivated && _questionServices.GetQuestionById(Id) != null)
            {
                if (rbText == "Да")
                {
                    if (extraversion_introversion_yes.Contains(_questionServices.GetQuestionById(Id).NumQuestion))
                    {
                        ex_yes++;
                    }
                    if (neuroticism_yes.Contains(_questionServices.GetQuestionById(Id).NumQuestion))
                    {
                        ne_yes++;
                    }
                    if (psychoticism_yes.Contains(_questionServices.GetQuestionById(Id).NumQuestion))
                    {
                        psy_yes++;
                    }
                    if (lie_yes.Contains(_questionServices.GetQuestionById(Id).NumQuestion))
                    {
                        l_yes++;
                    }
                }
                else
                {
                    if (extraversion_introversion_no.Contains(_questionServices.GetQuestionById(Id).NumQuestion))
                    {
                        ex_no++;
                    }
                    if (psychoticism_no.Contains(_questionServices.GetQuestionById(Id).NumQuestion))
                    {
                        psy_no++;
                    }
                    if (lie_no.Contains(_questionServices.GetQuestionById(Id).NumQuestion))
                    {
                        l_no++;
                    }
                }

                //Protocol
                DateTime dateTime = DateTime.MinValue.AddSeconds(secondsPassed);
                string formattedTime = dateTime.ToString("HH:mm:ss");
                try
                {
                    var protocol = new Protocol
                    {
                        TestingId = _testing.Id,
                        NumQuestion = _questionServices.GetQuestionById(Id).NumQuestion,
                        TimeAnswer = formattedTime,
                        AnswerText = rbText,
                        NumAnswer = rbText == "Да" ? 1 : 2
                    };
                    _protocolServices.AddProtocol(protocol);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"{_testing.Id}\n" +
                        $"{_questionServices.GetQuestionById(Id).NumQuestion}\n" +
                        $"{ex}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                Id++;
                secondsPassed = 0;
                if (Id <= questionQuantity)
                {
                    label4.Text = _questionServices.GetQuestionById(Id).NumQuestion.ToString() + "." + " "
                            + _questionServices.GetQuestionById(Id).QuestionText;
                }
            }
        }


        public void PENForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            //Testing
            if (TestType == "PEN") { TestId = 1; }
            var testing = new Testing
            {
                RespondentId = _respondentId,
                TestId = TestId,
                TestingDate = DateTime.Now.ToString("d"),
                TestingTime = DateTime.Now.ToString("T")
            };
            _testing = testing;
            _testingServices.AddTesting(testing);
            label4.Text = _questionServices.GetQuestionById(Id).NumQuestion.ToString() + "." + " "
                + _questionServices.GetQuestionById(Id).QuestionText;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
