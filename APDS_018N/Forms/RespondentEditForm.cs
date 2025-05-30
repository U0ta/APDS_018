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
    public partial class RespondentEditForm : Form
    {
        // Изменяем свойство для корректной работы дизайнера
        private Respondent _respondent;
        public Respondent Respondent => _respondent;

        public RespondentEditForm(Respondent respondent = null)
        {
            InitializeComponent();
            _respondent = respondent ?? new Respondent();

            LoadData();
        }

        private void LoadData()
        {
            // Загрузка данных в контролы
            txtSurname.Text = _respondent.Surname;
            txtName.Text = _respondent.NameResp;
            txtMidlename.Text = _respondent.Midlename;
            cmbSex.SelectedItem = _respondent.Sex;
            dtpBorn.Value = _respondent.Born != default ? _respondent.Born : DateTime.Now.AddYears(-20);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Сохранение данных из контролов
            _respondent.Surname = txtSurname.Text;
            _respondent.NameResp = txtName.Text;
            _respondent.Midlename = txtMidlename.Text;
            _respondent.Sex = cmbSex.SelectedItem?.ToString();
            _respondent.Born = dtpBorn.Value;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
