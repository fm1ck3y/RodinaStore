using RodinaStore.Model;
using RodinaStore.Forms;
using RodinaStore.DateBase;
using BarcodeLib;

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;


namespace RodinaStore
{
    public partial class Main : Form
    {
        public Till t = new Till();
        private User _user;

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

        public User user
        {
            get
            {
                return _user;
            }
        }

        // List<Product> products = new List<Product>();
        List<Product> products = RodinaStoreController.Instance.GetProducts();
        Cart cartProd = new Cart();

        public Main(User get_user = null)
        {
            InitializeComponent();
            _user = get_user;
            FillToolStrip();
            StyleDGV();
            UpdateGrid();
            UpdateElements();
        }


        private void StyleDGV()
        {
            dgvProds.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProds.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvProds.MultiSelect = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvCart.MultiSelect = false;
            txtDescFirm.ScrollBars = ScrollBars.Vertical;
            txtDescr.ScrollBars = ScrollBars.Vertical;
        }

        public void UpdateGrid()
        {
            dgvProds.DataSource = null;
            dgvProds.DataSource = products;
            dgvCart.DataSource = null;
            dgvCart.DataSource = cartProd.CartItems.GetRange(0, cartProd.CartItems.Count);
        }

        public System.Drawing.Image GetBitmap(byte[] img)
        {
            using (var stream = new MemoryStream(img))
            {
                return System.Drawing.Image.FromStream(stream);
            }
        }


        public void UpdateElements()
        {
            lblCountcart.Text = cartProd.Count.ToString() + " шт. " + "    Итого к оплате: " + cartProd.DiscountPrice.ToString("C2");
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnWrap_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FillToolStrip()
        {
            tsUser.Text = $"Текущая смена пользователя:  {user.NickName}.";

            ToolTip tp = new ToolTip();
            tp.SetToolTip(btnAddProduct, "Добавить товар");
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenu.Show(MousePosition, ToolStripDropDownDirection.Right);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in cartProd.CartItems)
                SoldItem.UpdateSold(item.product, user, item.Count, client: item.client);
            cartProd = new Cart();
            UpdateGrid();
            UpdateElements();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                switch (e.Value.ToString())
                {
                    case "М": { e.CellStyle.BackColor = Color.Blue; break; }
                    case "Ж": { e.CellStyle.BackColor = Color.Pink; break; }
                    default:
                        { e.CellStyle.BackColor = Color.Gray; }

                        break;
                }
            }

            if (e.ColumnIndex == 8)
            {
                e.CellStyle.BackColor = products[e.RowIndex].Color;
                e.Value = "";
            }

            if (e.ColumnIndex == 7)
            {
                e.Value = products[e.RowIndex].Category.Name;
            }
        }

        private void добавитьВКорзинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Product selectedProd = dgvProds.SelectedRows[0].DataBoundItem as Product;
                CartItem item = cartProd.CartItems.FirstOrDefault(t => t.product == selectedProd);
                if (item == null)
                {
                    item = new CartItem();
                    item.product = selectedProd;
                    item.Count = 1;
                    item.client = cartProd.Client;
                    if (selectedProd.Stock > 0)
                        cartProd.CartItems.Add(item);
                    else
                        MessageBox.Show("Наличие товара ограничено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (selectedProd.Stock <= item.Count)
                        MessageBox.Show("Наличие товара ограничено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        item.Count += 1;
                }
                UpdateGrid();
                UpdateElements();
            }
            catch (Exception)
            {
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            добавитьВКорзинуToolStripMenuItem_Click(sender, e);
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            dgvCart.ClearSelection();
            if (dgvProds.SelectedRows.Count > 0)
            {
                Product selectedProd = dgvProds.SelectedRows[0].DataBoundItem as Product;
                UpdateLabel(selectedProd);
            }
        }

        public void UpdateLabel(Product selectedProd)
        {
            lblNameProd.Text = selectedProd.Name;
            lblBradeCode.Text = selectedProd.Barcode.ToString();
            lblCateg.Text = selectedProd.Category.Name;
            lblCountt.Text = selectedProd.Stock.ToString();
            lblDiscounts.Text = selectedProd.Discount.ToString("P1");
            lblMater.Text = selectedProd.Material;
            lblPrices.Text = selectedProd.Price.ToString("C2");
            lblSize.Text = selectedProd.Sizes;
            lblFirms.Text = selectedProd.Firm.Name;
            colorProd.BackColor = selectedProd.Color;
            txtDescr.Text = selectedProd.Description;
            lblageGroup.Text = selectedProd.AgeGroup;

            lblfir.Text = selectedProd.Firm.Name;
            dateTimePicker1.Value = selectedProd.Firm.DateBorn.Value;
            lblCountr.Text = selectedProd.Firm.Country;
            txtDescFirm.Text = selectedProd.Firm.Description;
            switch (selectedProd.Floor.ToString())
            {
                case "М": { lblFloor.Text = "Мужчина"; break; }
                case "Ж": { lblFloor.Text = "Женщина"; break; }
                default:
                    { lblFloor.Text = "Унисекс"; }
                    break;
            }


            try
            {
                pictureProd.Image = GetBitmap(selectedProd.Image);
            }
            catch (Exception)
            {
            }

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            dgvProds.ClearSelection();
            if (dgvCart.SelectedRows.Count > 0)
            {
                CartItem selectedItem = dgvCart.SelectedRows[0].DataBoundItem as CartItem;
                Product selectedProd = selectedItem.product;
                UpdateLabel(selectedProd);
            }
        }


        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewProductForm f = new AddNewProductForm(dgvProds.SelectedRows[0].DataBoundItem as Product);
            if (f.ShowDialog() == DialogResult.OK)
            {
                RodinaStoreController.Instance.GetProducts();
                UpdateGrid();
            }
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            CartItem selectedCart = dgvCart.SelectedRows[0].DataBoundItem as CartItem;
            cartProd.CartItems.Remove(selectedCart);
            UpdateGrid();
            UpdateElements();
        }

        private void распечататьШтрихкодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product prod = dgvProds.SelectedRows[0].DataBoundItem as Product;
            Image imgure = barcode.Encode(TYPE.CODE128B, prod.Barcode.ToString());
            Forms.Barcode f = new Forms.Barcode(imgure, prod.Barcode.ToString());
            f.ShowDialog();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены , что хотите удалить этот продукт?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RodinaStoreController.Instance.Delete(dgvProds.SelectedRows[0].DataBoundItem as Product);
                products = RodinaStoreController.Instance.GetProducts();
                UpdateGrid();
            }

        }

        private void Main_Load(object sender, EventArgs e)
        {
            cbFiltr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            Properties.Settings.Default.AddProduct = user.Permission.AddProduct;
            Properties.Settings.Default.AddFirm = user.Permission.AddFirm;
            Properties.Settings.Default.AddCat = user.Permission.AddCategory;
            Properties.Settings.Default.HistorySold = user.Permission.ViewHistoryCart;
            Properties.Settings.Default.Statistics = user.Permission.ViewStats;
            Properties.Settings.Default.EditFirm = user.Permission.EditFirm;
            Properties.Settings.Default.EditCategory = user.Permission.EditCategory;
            Properties.Settings.Default.AddClient = user.Permission.AddClient;
            Properties.Settings.Default.EditClient = user.Permission.EditClient;
            Properties.Settings.Default.DeleteClient = user.Permission.DeleteClient;

            btnAddProduct.Enabled = Properties.Settings.Default.AddProduct;
            btnAddFirm.Enabled = Properties.Settings.Default.AddFirm;
            btnAddCategory.Enabled = Properties.Settings.Default.AddCat;
            btnHistoryCart.Enabled = Properties.Settings.Default.HistorySold;

            изменитьToolStripMenuItem.Enabled = user.Permission.EditProduct;
            удалитьToolStripMenuItem.Enabled = user.Permission.DeleteProduct;
            просмотретьИзмененияToolStripMenuItem.Enabled = user.Permission.ViewHistoryChanged;
        }

        class TagsComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
            {
                return x.ToLower() == y.ToLower();
            }
            public int GetHashCode(string tag)
            {
                return tag.GetHashCode();
            }
        }

        private void Sort()
        {
            if (txtFind.Text == "")
            {
                UpdateGrid();
                return;
            }
            switch (cbFiltr.SelectedIndex)
            {
                case 0:
                    List<Product> prods = new List<Product>();
                    dgvProds.DataSource = products.Where(t => t.Tags.Contains(txtFind.Text, new TagsComparer())).ToList();
                    break;
                case 1:
                    dgvProds.DataSource = products.Where(t => t.Category.Name.ToLower() == txtFind.Text.ToLower()).ToList(); break;
                case 2:
                    dgvProds.DataSource = products.Where(t => t.Firm.Name.ToLower() == txtFind.Text.ToLower()).ToList(); break;
                case 3:
                    dgvProds.DataSource = products.Where(t => t.Sizes.ToLower() == txtFind.Text.ToLower()).ToList(); break;
                case 4:
                    dgvProds.DataSource = products.Where(t => t.Floor.ToLower() == txtFind.Text.ToLower()).ToList(); break;
                default:
                    break;
            }
        }

        private void txtFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            Sort();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = true;
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
            }
        }
        protected override void OnResize(EventArgs e)
        {
            //Скрывает
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
            }
        }

        private void просмотретьИзмененияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                HistoryChangedForm form = new HistoryChangedForm(dgvProds.SelectedRows[0].DataBoundItem as Product);
                form.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("Вы не выбрали товар для просмотра изменения!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {

            SoldItem.CheckIsReturn = true;
            HistoryCart f = new HistoryCart();
            if (f.ShowDialog() == DialogResult.OK)
            {
                SoldItem si = f.soldItem;
                List<User> users = RodinaStoreController.Instance.GetUsers();
                var User = users.FirstOrDefault(t => t.Login == si.Username);
                var Product = products.FirstOrDefault(t => t.Name == si.Name);
                int Stock = si.Stock;
                SoldItem.UpdateSold(Product, User, Stock, IdReturnSoldItem: si.Id);
                t.Money -= decimal.Parse(si.Discount.ToString()) * si.Price * si.Stock;
            }
            SoldItem.CheckIsReturn = false;
            UpdateGrid();
        }

        private void BtnAddProduct_Click(object sender, EventArgs e)
        {
            AddNewProductForm f = new AddNewProductForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                products = RodinaStoreController.Instance.GetProducts();
                UpdateGrid();
            }
        }

        private void BtnAddFirm_Click(object sender, EventArgs e)
        {
            CreateFirmForm f = new CreateFirmForm();
            f.ShowDialog();
        }

        private void BtnAddCategory_Click(object sender, EventArgs e)
        {
            CreateCategoryForm f = new CreateCategoryForm();
            f.ShowDialog();
        }

        private void BtnHistoryCart_Click(object sender, EventArgs e)
        {
            HistoryCart f = new HistoryCart();
            f.ShowDialog();
        }

        private void BtnClients_Click(object sender, EventArgs e)
        {
            Clients form = new Clients();
            form.ShowDialog();
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            SettingsForm form = new SettingsForm();
            form.ShowDialog();
            Main_Load(sender, e);
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти в меню авторизации?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Hide();
                AuthForm f = new AuthForm(user, false);
                f.ShowDialog();
                this.Close();
            }
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Sort();
        }

        private void DgvProds_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Right)
                ((DataGridView)sender).CurrentCell = null;
        }

        private void DgvCart_MouseDown(object sender, MouseEventArgs e)
        {
            ((DataGridView)sender).CurrentCell = null;
        }
    }
}
