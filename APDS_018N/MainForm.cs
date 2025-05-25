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


        public MainForm(TestServices testService)
        {
            InitializeComponent();
            _testService = testService;
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
    }
}
