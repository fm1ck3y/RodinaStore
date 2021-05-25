using BarcodeLib;
using RodinaStore.DateBase;
using RodinaStore.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RodinaStore.Forms
{
    public partial class AddNewProductForm : Form
    {
        private Product _prod;

        public Product prod
        {
            get
            {
                return _prod;
            }
        }

        public AddNewProductForm(Product product = null)
        {
            _prod = product;
            InitializeComponent();
            FillComboBox();
            if (prod != null)
            {
                FillLabel();
            }
        }

        private void FillLabel()
        {

            if (prod != null)
            {
                txtName.Text = prod.Name;
                txtMaterial.Text = prod.Material;
                numericPrice.Value = prod.Price;
                cbCategory.SelectedIndex = prod.Category.Id - 1;
                cbSize.Enabled = true;
                foreach (var item in prod.Category.ArraySizes)
                {
                    cbSize.Items.Add(item);
                }

                cbFirms.SelectedIndex = prod.Firm.Id - 1;
                numericStock.Value = prod.Stock;
                for (int i = 0; i < prod.Category.ArraySizes.Length; i++)
                {
                    if (prod.Category.ArraySizes[i] == prod.Sizes)
                    {
                        cbSize.SelectedIndex = i;
                        break;
                    }
                }

                switch (prod.Floor)
                {
                    case "М": { cbFloor.SelectedIndex = 0; break; }
                    case "Ж": { cbFloor.SelectedIndex = 1; break; }
                    case "У": { cbFloor.SelectedIndex = 2; break; }
                    default:
                        break;
                }

                int j = 0;
                foreach (var item in cbAgeGroup.Items)
                {
                    if (item.ToString() == prod.AgeGroup.ToString())
                    {
                        cbAgeGroup.SelectedIndex = j;
                        break;
                    }
                    j++;
                }

                txtDescript.Text = prod.Description;
                colorProd.BackColor = prod.Color;
                numericDiscount.Value = decimal.Parse((prod.Discount * 100).ToString());
                _imgProd = prod.Image;
            }
        }


        List<Firm> firms = RodinaStoreController.Instance.GetFirms();
        List<Category> categories = RodinaStoreController.Instance.GetCategories();

        public void FillComboBox()
        {
            foreach (var item in firms)
            {
                cbFirms.Items.Add(item.Name);
            }
            foreach (var item in categories)
            {
                cbCategory.Items.Add(item.Name);
            }
        }

        private void cbCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbSize.Items.Clear();
            Category cat = categories.FirstOrDefault(t => t.Name == cbCategory.SelectedItem.ToString());
            if (cat.Size == true)
            {
                cbSize.Enabled = true;
                foreach (var item in cat.ArraySizes)
                    cbSize.Items.Add(item);
            }
            else
                cbSize.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnWrap_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private byte[] _imgProd;
        private void button1_Click(object sender, EventArgs e)
        {
            if (ValidateAddProduct() == true)
            {
                if (prod == null)
                    _prod = new Product();

                if (_prod.Barcode == 0)
                    GenerationBarcode();

                _prod.Name = txtName.Text;
                _prod.Material = txtMaterial.Text;
                _prod.Price = numericPrice.Value;
                _prod.Category = categories.FirstOrDefault(t => t.Name == cbCategory.SelectedItem.ToString());
                _prod.Firm = firms.FirstOrDefault(t => t.Name == cbFirms.SelectedItem.ToString());
                _prod.Stock = int.Parse(numericStock.Value.ToString());
                _prod.Sizes = cbSize.SelectedItem.ToString();
                _prod.Description = txtDescript.Text;
                _prod.ColorInt = colorProd.BackColor.ToArgb();
                _prod.Discount = double.Parse(numericDiscount.Value.ToString()) / 100;
                _prod.Floor = cbFloor.SelectedItem.ToString().Remove(1, cbFloor.SelectedItem.ToString().Length - 1);
                _prod.AgeGroup = cbAgeGroup.SelectedItem.ToString();
                try
                {
                    _prod.Image = ImageProduct;
                }
                catch (Exception)
                {
                    _prod.Image = _imgProd;
                }
                if (_prod.Id == 0)
                {
                    MessageBox.Show("Продукт создан!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    OpenBarcodeForm();
                }
                else
                    MessageBox.Show("Продукт отредактирован!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                RodinaStoreController.Instance.Update(prod);
                Close();
                FillComboBox();
            }
        }

        public byte[] ImageProduct
        {
            get
            {
                var ms = new MemoryStream();
                Image.FromFile(_stringFoto).Save(ms, ImageFormat.Jpeg);
                var _img = ms.ToArray();
                ms.Close();
                return _img;
            }

        }

        private void GenerationBarcode()
        {
            bool BarcodeExists = true;
            while (BarcodeExists)
            {
                Random rand = new Random();
                _prod.Barcode = rand.Next(100000000, 199999999);
                List<Product> products = RodinaStoreController.Instance.GetProducts();
                Product findProdBarcode = products.FirstOrDefault(t => t.Barcode == _prod.Barcode);
                if (findProdBarcode == null)
                {
                    BarcodeExists = false;
                }
            }
        }

        private void OpenBarcodeForm()
        {
            BarcodeLib.Barcode barcode = new BarcodeLib.Barcode()
            {
                IncludeLabel = true,
                Alignment = AlignmentPositions.CENTER,
                Width = 300,
                Height = 100,
                RotateFlipType = RotateFlipType.RotateNoneFlipNone,
                BackColor = Color.White,
                ForeColor = Color.Black,
            };
            Image imgure = barcode.Encode(TYPE.CODE128B, _prod.Barcode.ToString());
            Barcode f = new Barcode(imgure, _prod.Barcode.ToString());
            f.ShowDialog();

        }

        private string _stringFoto;

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _stringFoto = openFileDialog1.FileName;
                MessageBox.Show("Фото загружено!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("Фото не загружено!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateAddProduct()
        {

            if (String.IsNullOrEmpty(txtName.Text))
            {
                errorProvider1.SetError(txtName, "Не указано имя!");
                return false;
            }


            if (cbCategory.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbCategory, "Не указана категория!");
                return false;
            }


            if (numericPrice.Value == 0)
            {
                errorProvider1.SetError(numericPrice, "Не указана цена!");
                return false;
            }


            if (numericStock.Value == 0)
            {
                errorProvider1.SetError(numericStock, "Не указано количество!");
                return false;
            }


            if (cbFirms.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbFirms, "Не указана фирма!");
                return false;
            }


            if (cbSize.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbSize, "Не указан размер!");
                return false;
            }


            if (String.IsNullOrEmpty(txtMaterial.Text))
            {
                errorProvider1.SetError(txtMaterial, "Не указан материал!");
                return false;
            }


            if (cbAgeGroup.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbAgeGroup, "Не указана возрастная группа!");
                return false;
            }


            if (cbFloor.SelectedIndex == -1)
            {
                errorProvider1.SetError(cbFloor, "Не указан пол!");
                return false;
            }
            errorProvider1.Clear();
            return true;

        }

        private void ColorProd_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = false;
            MyDialog.ShowHelp = true;
            MyDialog.Color = colorProd.BackColor;

            if (MyDialog.ShowDialog() == DialogResult.OK)
                colorProd.BackColor = MyDialog.Color;
        }
    }
}
