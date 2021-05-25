using RodinaStore.DateBase;
using RodinaStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RodinaStore.Forms
{
    public partial class CreateCategoryForm : Form
    {
        private Category _categ;


        List<Category> category = RodinaStoreController.Instance.GetCategories();
        public CreateCategoryForm()
        {
            InitializeComponent();
            foreach (var item in category)
            {
                comboCat.Items.Add(item.Name);
                cbCategory.Items.Add(item.Name);
            }
            comboCat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            listBox1.Items.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(txtSize.Text);
            txtSize.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            listBox1.Items.Remove(listBox1.SelectedItem);
        }


        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (ValidateAddCategory())
            {
                if (_categ == null)
                    _categ = new Category();
                _categ.Name = txtName.Text;
                _categ.Size = checkBox1.Checked;
                if (checkBox1.Checked)
                {
                    string sizes = "";
                    foreach (var item in listBox1.Items)
                        sizes += item.ToString() + ";";

                    _categ.Sizes = sizes.Remove(sizes.Length - 1, 1);
                }
                _categ.Discount = int.Parse(numericDiscount.Value.ToString()) * 100;


                if (!checkBox2.Checked)
                {
                    RodinaStoreController.Instance.UpdateCategory(_categ);
                    if (MessageBox.Show("Категория успешно создана! Вы хотите добавить еще?", "Успешно!", MessageBoxButtons.YesNo, MessageBoxIcon.Information) != DialogResult.Yes)
                        Close();
                    category = RodinaStoreController.Instance.GetCategories();
                    FillForm();
                }
                else
                {
                    MessageBox.Show("Категория успешно изменена!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RodinaStoreController.Instance.UpdateCategory(_categ);
                    Close();
                }
            }
        }

        private void FillForm()
        {
            _categ = null;
            listBox1.Items.Clear();
            txtName.Text = "";
            txtSize.Text = "";
            numericDiscount.Value = 0;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            cbCategory.Items.Clear();
            comboCat.Items.Clear();
            foreach (var item in category)
            {
                comboCat.Items.Add(item.Name);
                cbCategory.Items.Add(item.Name);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtSize.Enabled = true;
                listBox1.Enabled = true;
                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                //simpleButton1.Enabled = true;
                comboCat.Enabled = true;
                //simpleButton2.Enabled = true;
            }
            else
            {
                txtSize.Enabled = false;
                listBox1.Enabled = false;
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                comboCat.Enabled = false;
                //simpleButton1.Enabled = false;
                //simpleButton2.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnWrap_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void txtSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter && txtSize.Text != "")
            {
                btnAdd_Click(sender, e);
            }
        }

        private void comboCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Category cat = category[comboCat.SelectedIndex];
            foreach (var item in cat.ArraySizes)
                listBox1.Items.Add(item);
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            _categ = category.FirstOrDefault(t => t.Name.ToString() == cbCategory.Items[cbCategory.SelectedIndex].ToString());
            if (_categ != null)
            {
                txtName.Text = _categ.Name;
                listBox1.Items.Clear();
                foreach (var item in _categ.ArraySizes)
                {
                    listBox1.Items.Add(item);
                }
                numericDiscount.Value = _categ.Discount / 100;
                checkBox1.Checked = _categ.Size;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                cbCategory.Enabled = true;
            }
            else
            {
                cbCategory.Enabled = false;
                FillForm();
            }
        }

        private bool ValidateAddCategory()
        {
            if (String.IsNullOrEmpty(txtName.Text))
            {
                errorProvider.SetError(txtName, "Не указано имя!");
                return false;
            }

            errorProvider.Clear();
            return true;
        }

        private void BtnUp_Click(object sender, EventArgs e)
        {
            try
            {
                var item = listBox1.SelectedItem;
                listBox1.Items[listBox1.SelectedIndex] = listBox1.Items[listBox1.SelectedIndex - 1];
                listBox1.Items[listBox1.SelectedIndex - 1] = item;
                listBox1.SelectedIndex = listBox1.SelectedIndex - 1;
            }
            catch (Exception)
            {
            }
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            try
            {
                var item = listBox1.SelectedItem;
                listBox1.Items[listBox1.SelectedIndex] = listBox1.Items[listBox1.SelectedIndex + 1];
                listBox1.Items[listBox1.SelectedIndex + 1] = item;
                listBox1.SelectedIndex = listBox1.SelectedIndex + 1;
            }
            catch (Exception)
            {
            }
        }
    }
}
