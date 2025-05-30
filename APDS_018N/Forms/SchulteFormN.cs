using APDS_018.Business.Services;
using APDS_018.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace APDS_018N.Forms
{
    public partial class SchulteFormN : Form
    {
        private readonly MainForm _mainForm;
        private readonly QuestionServices _questionServices;
        private readonly TestingServices _testingServices;
        private readonly ProtocolServices _protocolServices;
        private readonly ResultServices _resultServices;
        private Testing _testing;
        private readonly string _testType;
        private readonly long _respondentId;
        private bool isTimerActive = false;
        private short sendPressed = 0;
        private string tbText;
        private int testMode;
        string[,] cells1 = {
                { "9-т", "15-п", "9-м", "12-м", "16-е", "3-и", "10-в" },
                { "24-в", "23-ф", "1-к", "19-а", "15-л", "8-г", "17-а" },
                { "18-т", "14-ф", "13-ш", "6-с", "2-л", "10-е", "25-р" },
                { "11-к", "2-г", "24-ч", "23-ч", "5-ш", "12-б", "21-н" },
                { "20-б", "17-р", "11-р", "22-д", "19-т", "3-с", "13-ж" },
                { "7-х", "16-х", "6-ж", "22-п", "14-ц", "8-ц", "4-з" },
                { "7-з", "1-о", "20-н", "4-д", "5-и", "18-о", "21-у" }
            };
        string[,] cells2 = {
                { "7-y", "4-в", "15-в", "8-ч", "11-к", "1-г", "25-я" },
                { "14-ш", "18-л", "21-ф", "15-з", "3-и", "19-ф", "17-з" },
                { "7-ж", "2-х", "11-т", "10-с", "23-м", "8-м", "10-а" },
                { "17-б", "14-п", "6-р", "20-п", "13-ч", "23-ш", "5-у" },
                { "9-ж", "3-л", "22-б", "1-е", "16-ц", "6-д", "13-н" },
                { "2-и", "4-ц", "22-о", "20-а", "12-х", "19-р", "24-е" },
                { "24-г", "18-с", "12-т", "9-к", "16-н", "21-д", "5-о" }
            };

        string[] red1 = { "9-т", "12-м", "3-и",
                          "24-в", "1-к", "15-л", "17-а",
                          "14-ф", "6-с", "10-е",
                          "2-г", "23-ч", "5-ш", "21-н",
                          "20-б", "11-р", "19-т", "13-ж",
                          "16-х", "22-п", "8-ц",
                          "7-з", "4-д", "18-о" };
        string[] red2 = { "4-в", "8-ч", "1-г",
                          "14-ш", "15-з", "19-ф",
                          "7-ж", "11-т", "23-м", "10-а",
                          "17-б", "6-р", "20-п", "5-у",
                          "3-л", "16-ц", "13-н",
                          "2-и", "22-о", "12-х", "24-е",
                          "18-с", "9-к", "21-д" };

        string answerFirstTaskRed = "вчпнбтоахлфжмретцзсшдигк";
        string answerSecondTaskBlack = "олсзижхгмвкбшцпертанудфчр";
        string answerThirdTaskRed = "емодпфсбцзшнхтакчжрувлиг";
        string answerThirdTaskBlack = "ехицодымжсктчпвнзлрафбшгя";
        private long secondsPassed;
        private long[] secondsFirstTask = [0, 0];
        private long avgSeconds;
        private long thrdSeconds;

        public SchulteFormN(
            MainForm mainForm,
            QuestionServices questionServices,
            string testType,
            long respondentId,
            TestingServices testingServices,
            ResultServices resultServices,
            ProtocolServices protocolServices)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _questionServices = questionServices;
            _testType = testType;
            _respondentId = respondentId;
            _testingServices = testingServices;
            _resultServices = resultServices;
            _protocolServices = protocolServices;
            testMode = 1;
            this.KeyPreview = true;
            this.KeyDown += SchulteForm_KeyDown;

        }

        private void SchulteForm_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F11 && testMode == 1)
            {
                MessageBox.Show(
                    "\rНа Вашем бланке 25 черных и 24 красных чисел. " +
                    "Вы должны отыскать черные числа в возрастающей последовательности (от 1 до 25), " +
                    "а затем красные числа в убывающей последовательности (от 24 до 1). " +
                    "Каждый раз, находя необходимое число, запишите букву, соответствующую этому числу. " +
                    "Время выполнения задания фиксируется.",
                    "Instruction",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                e.Handled = true;
            }
            if (e.KeyCode == Keys.F11 && testMode == 3)
            {
                MessageBox.Show(
                    "\rТеперь Вы должны отыскивать черные числа в возрастающем порядке, " +
                    "а красные числа в убывающем порядке, одновременно, попеременно. Например: черная цифра 1, " +
                    "красная цифра 24, черная цифра 2, красная цифра 23 и так далее. " +
                    "\r\nБуквы, соответствующие красным цифрам записываются в одном ряду (сверху), " +
                    "а соответствующие черным – в другом (снизу), таким образом, получается два ряда букв.",
                    "Instruction",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
                e.Handled = true;
            }
        }


        private void SchulteFormN_Load(object sender, EventArgs e)
        {
            for (int row = 0; row < 7; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    var label = new Label
                    {
                        Text = cells1[row, col],
                        Font = new Font("Cascadia Code", 10, FontStyle.Bold),
                        Dock = DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        Margin = new Padding(0)
                    };

                    label.ForeColor = red1.Contains(cells1[row, col]) ? Color.Red : Color.Black;

                    tableLayoutPanel1.Controls.Add(label, col, row);
                }
            }
            label4.Hide();
            textBox1.Hide();
            button1.Hide();
            label6.Hide();

            //Testing
            var testing = new Testing
            {
                RespondentId = _respondentId,
                TestId = _testType == "RBT" ? 2 : 1,
                TestingDate = DateTime.Now.ToString("d"),
                TestingTime = DateTime.Now.ToString("T")
            };
            _testing = testing;
            _testingServices.AddTesting(testing);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls.Clear();
            for (int row = 0; row < 7; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    var label = new Label
                    {
                        Text = cells2[row, col],
                        Font = new Font("Cascadia Code", 10, FontStyle.Bold),
                        Dock = DockStyle.Fill,
                        TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        Margin = new Padding(0)
                    };

                    label.ForeColor = red2.Contains(cells2[row, col]) ? Color.Red : Color.Black;

                    tableLayoutPanel1.Controls.Add(label, col, row);
                }
            }
            testMode = 3;
            label3.Text = "Blank 2";
            avgSeconds = (secondsFirstTask[0] + secondsFirstTask[1]) / 2;
            button2.Show();
            tableLayoutPanel1.Show();
            label6.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text == "") { tbText = textBox1.Text; }
            else if (textBox2.Text != "" && textBox1.Text == "") { tbText = textBox2.Text; }
            else { tbText = $"{textBox1.Text}" + $":{textBox2.Text}"; }

            if ((testMode == 1 && tbText == answerSecondTaskBlack) || (testMode == 2 && tbText == answerFirstTaskRed)
                || (testMode == 3 && tbText == $"{answerThirdTaskRed}" + $":{answerThirdTaskBlack}"))
            {
                if (testMode == 1)
                {
                    secondsFirstTask[0] = secondsPassed;
                }
                if (testMode == 2)
                {
                    secondsFirstTask[1] = secondsPassed;
                    button1.Show();
                    button2.Hide();
                    tableLayoutPanel1.Hide();
                    label6.Show();
                }
                if (testMode == 3)
                {
                    thrdSeconds = secondsPassed;
                }
                sendPressed++;
                timer1.Stop();
                isTimerActive = false;
                if (testMode == 1)
                {
                    label4.Show();
                    textBox1.Show();
                    label5.Hide();
                    textBox2.Hide();
                }
                else if (testMode == 2)
                {
                    label5.Show();
                    textBox2.Show();
                }
                //Protocol
                DateTime dateTime = DateTime.MinValue.AddSeconds(secondsPassed);
                string formattedTime = dateTime.ToString("HH:mm:ss");
                try
                {
                    var protocol = new Protocol
                    {
                        TestingId = _testing.Id,
                        NumQuestion = 101 + testMode,
                        TimeAnswer = formattedTime,
                        AnswerText = tbText,
                        NumAnswer = testMode
                    };
                    _protocolServices.AddProtocol(protocol);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"{_testing.Id}\n" +
                        $"{ex}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
                if (testMode == 3)
                {
                    long diffSeconds = thrdSeconds - avgSeconds;
                    DateTime dateTimeN = DateTime.MinValue.AddSeconds(Math.Abs(diffSeconds));
                    string formattedTimeN = dateTime.ToString("HH:mm:ss");
                    //Result
                    var result = new Result
                    {
                        ParamResultId = 1,
                        TestingId = _testing.Id,
                        ValueResult = formattedTimeN
                    };
                    _resultServices.AddResult(result);
                    MessageBox.Show(
                       $"Бланк 1, среднее время: {avgSeconds / 60:00}:{avgSeconds % 60:00}{Environment.NewLine}" +
                       $"Бланк 2, время: {thrdSeconds / 60:00}:{thrdSeconds % 60:00}{Environment.NewLine}" +
                       $"Время переключения внимания: {formattedTimeN}",
                       "Результаты теста",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Information
                    );
                    this.Close();
                    _mainForm.Show();
                }
                if (testMode != 3) { testMode = 2; }
                secondsPassed = 0;
            }
            else
            {
                MessageBox.Show(
                        $"Вы ошиблись! Придется пройти тест заново.{Environment.NewLine}" +
                        $"{tbText}",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                var schulteFormNew = new SchulteFormN(_mainForm, _questionServices, _testType, _respondentId,
                                       _testingServices, _resultServices, _protocolServices);
                schulteFormNew.Show();
                this.Close();
            }
            textBox1.Text = "";
            textBox2.Text = "";
            tbText = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            secondsPassed++;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!isTimerActive) { timer1.Start(); isTimerActive = true; };
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!isTimerActive) { timer1.Start(); isTimerActive = true; };
        }

        private void button3_Click(object sender, EventArgs e)
        {
            _mainForm.Show();
            this.Close();
        }
    }
}
