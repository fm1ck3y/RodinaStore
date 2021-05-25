using RodinaStore.Model;
using RodinaStore.DateBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace RodinaStore.Forms
{
    public partial class HistoryCart : Form
    {
        List<SoldItem> soldItems = RodinaStoreController.Instance.GetSoldItems();
        List<User> users = RodinaStoreController.Instance.GetUsers();
        private SoldItem _soldItem;
        public SoldItem soldItem
        {
            get
            {
                return _soldItem;
            }
            set
            {
                _soldItem = value;
            }
        }

        private double amount;
        public HistoryCart()
        {
            InitializeComponent();
            if (SoldItem.CheckIsReturn)
                btnSelect.Visible = true;

            UpdateGrid();
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            comboBox1.SelectedIndex = 0;
            CellLabelAmount();
        }

        private void CellLabelAmount()
        {
            amount = 0;
            List<SoldItem> list = new List<SoldItem>();
            switch (comboBox1.SelectedIndex)
            {
                case 0: list = soldItems.Where(t => t.Date.DayOfYear == dateTimePicker1.Value.DayOfYear && t.Date.Year == dateTimePicker1.Value.Year).ToList(); break;
                case 1: list = soldItems.Where(t => t.Date.Month == dateTimePicker1.Value.Month).ToList(); break;
                case 2: list = soldItems.Where(t => t.Date.Year == dateTimePicker1.Value.Year).ToList(); break;
                default:
                    break;
            }
            foreach (var item in list)
                amount += (item.IsReturn ? -1 : 1) * (double)item.Price * (item.Discount == 0 ? 1 : item.Discount) * item.Stock;

            label5.Text = amount.ToString() + " руб.";
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 10)
            {
                if (soldItems[(int)dataGridView2.Rows[e.RowIndex].Cells[0].Value - 1].IsReturn)
                    e.Value = $"Возврат (№{soldItems[(int)dataGridView2.Rows[e.RowIndex].Cells[0].Value - 1].IdReturnSoldItem})";
                else
                    e.Value = "Продажа";
            }
            if (e.ColumnIndex == 11)
                e.Value = ((double)soldItems[(int)dataGridView2.Rows[e.RowIndex].Cells[0].Value - 1].PriceWithDiscount * soldItems[(int)dataGridView2.Rows[e.RowIndex].Cells[0].Value - 1].Stock).ToString();
        }

        private void UpdateGrid()
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = soldItems;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnWrap_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            Sort();
            CellLabelAmount();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sort();
            CellLabelAmount();
        }

        private void Sort()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: dataGridView2.DataSource = soldItems.Where(t => t.Date.DayOfYear == dateTimePicker1.Value.DayOfYear && t.Date.Year == dateTimePicker1.Value.Year).ToList(); break;
                case 1: dataGridView2.DataSource = soldItems.Where(t => t.Date.Month == dateTimePicker1.Value.Month).ToList(); break;
                case 2: dataGridView2.DataSource = soldItems.Where(t => t.Date.Year == dateTimePicker1.Value.Year).ToList(); break;
                default:
                    break;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (textBox1.Text != "")
            {
                switch (comboBox2.SelectedIndex)
                {
                    case 0:
                        {
                            switch (comboBox1.SelectedIndex)
                            {
                                case 0: dataGridView2.DataSource = soldItems.Where(t => t.Username == textBox1.Text && t.Date.DayOfYear == dateTimePicker1.Value.DayOfYear && t.Date.Year == dateTimePicker1.Value.Year).ToList(); break;
                                case 1: dataGridView2.DataSource = soldItems.Where(t => t.Username == textBox1.Text && t.Date.Month == dateTimePicker1.Value.Month).ToList(); break;
                                case 2: dataGridView2.DataSource = soldItems.Where(t => t.Username == textBox1.Text && t.Date.Year == dateTimePicker1.Value.Year).ToList(); break;

                                default:
                                    break;
                            }
                            break;
                        }
                    case 1:
                        {
                            switch (comboBox1.SelectedIndex)
                            {
                                case 0: dataGridView2.DataSource = soldItems.Where(t => t.Category == textBox1.Text && t.Date.DayOfYear == dateTimePicker1.Value.DayOfYear && t.Date.Year == dateTimePicker1.Value.Year).ToList(); break;
                                case 1: dataGridView2.DataSource = soldItems.Where(t => t.Category == textBox1.Text && t.Date.Month == dateTimePicker1.Value.Month).ToList(); break;
                                case 2: dataGridView2.DataSource = soldItems.Where(t => t.Category == textBox1.Text && t.Date.Year == dateTimePicker1.Value.Year).ToList(); break;

                                default:
                                    break;
                            }
                            break;
                        }
                    case 2:
                        {
                            switch (comboBox1.SelectedIndex)
                            {
                                case 0: dataGridView2.DataSource = soldItems.Where(t => t.Firm == textBox1.Text && t.Date.DayOfYear == dateTimePicker1.Value.DayOfYear && t.Date.Year == dateTimePicker1.Value.Year).ToList(); break;
                                case 1: dataGridView2.DataSource = soldItems.Where(t => t.Firm == textBox1.Text && t.Date.Month == dateTimePicker1.Value.Month).ToList(); break;
                                case 2: dataGridView2.DataSource = soldItems.Where(t => t.Firm == textBox1.Text && t.Date.Year == dateTimePicker1.Value.Year).ToList(); break;

                                default:
                                    break;
                            }
                            break;
                        }
                    case 3:
                        {
                            switch (comboBox1.SelectedIndex)
                            {
                                case 0: dataGridView2.DataSource = soldItems.Where(t => t.Name == textBox1.Text && t.Date.DayOfYear == dateTimePicker1.Value.DayOfYear && t.Date.Year == dateTimePicker1.Value.Year).ToList(); break;
                                case 1: dataGridView2.DataSource = soldItems.Where(t => t.Name == textBox1.Text && t.Date.Month == dateTimePicker1.Value.Month).ToList(); break;
                                case 2: dataGridView2.DataSource = soldItems.Where(t => t.Name == textBox1.Text && t.Date.Year == dateTimePicker1.Value.Year).ToList(); break;

                                default:
                                    break;
                            }
                            break;
                        }

                    default:
                        break;
                }
            }

            else
            {
                Sort();

            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            SoldItem this_solditem = dataGridView2.SelectedRows[0].DataBoundItem as SoldItem;
            int returnsSoldItem = soldItems.Where(t => t.IdReturnSoldItem == this_solditem.Id).ToList().Count;
            if (this_solditem.IsReturn || returnsSoldItem != 0)
                MessageBox.Show("Невозможно вернуть товар!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                soldItem = this_solditem;
                DialogResult = DialogResult.OK;
            }
        }

        private void DataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            ((DataGridView)sender).CurrentCell = null;
        }
    }
}
