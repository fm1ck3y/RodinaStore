using RodinaStore.DateBase;
using RodinaStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RodinaStore.Forms
{
    public partial class CreateFirmForm : Form
    {
        private Firm _firm; 

        public CreateFirmForm()
        {
            GetFirms();
            InitializeComponent();
            cbFirms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            checkBox2.Checked = false;
            cbFirms.Items.Clear();
            foreach (var item in firms)
                cbFirms.Items.Add(item.Name);

        }
        public List<Firm> firms = new List<Firm>();
        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (ValidateCreateFirm())
            {
                if (_firm == null)
                    _firm = new Firm();

                _firm.Name = txtName.Text;
                _firm.DateBorn = dateTimePicker1.Value;
                _firm.Description = txtDesc.Text;
                _firm.Country = txtCountry.Text;

                RodinaStoreController.Instance.UpdateFirm(_firm);
                if (checkBox2.Checked)
                {
                    if (MessageBox.Show("Фирма отредактирована. Вы хотите продолжить?", "Успешно!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                        FillForm();
                    else
                        Close();
                }
                else
                {
                    if (MessageBox.Show("Фирма создана. Вы хотите добавить еще фирму?", "Успешно!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        FillForm();
                        firms = RodinaStoreController.Instance.GetFirms();
                    }
                    else
                        Close();
                }
            }
        }



        private void GetFirms()
        {
            firms = RodinaStoreController.Instance.GetFirms();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnWrap_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                cbFirms.Enabled = true;
            }
            else
            {
                cbFirms.Enabled = false;
                FillForm();
                _firm = null;
            }
        }

        private void cbFirms_SelectedIndexChanged(object sender, EventArgs e)
        {
            _firm = firms.FirstOrDefault(t => t.Name.ToString() == cbFirms.Items[cbFirms.SelectedIndex].ToString());
            txtCountry.Text = _firm.Country;
            txtDesc.Text = _firm.Description;
            txtName.Text = _firm.Name;
            dateTimePicker1.Value = _firm.DateBorn.Value;
        }

        private void FillForm()
        {
            _firm = null;
            checkBox2.Checked = false;
            cbFirms.Items.Clear();
            foreach (var item in firms)
                cbFirms.Items.Add(item.Name);
            txtCountry.Text = "";
            txtDesc.Text = "";
            txtName.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }
        private bool ValidateCreateFirm()
        {
            if (String.IsNullOrEmpty(txtName.Text) )
            {
                errorProvider1.SetError(txtName, "Не указано имя!");
                return false;
            }

            if (String.IsNullOrEmpty(txtCountry.Text))
            {
                errorProvider1.SetError(txtCountry, "Не указана страна!");
                return false;
            }

            errorProvider1.Clear();
            return true;
        }
    }
}
