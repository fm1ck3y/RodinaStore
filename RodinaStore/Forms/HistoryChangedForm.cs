using RodinaStore.Model;
using System;
using System.Windows.Forms;

namespace RodinaStore.Forms
{
    public partial class HistoryChangedForm : Form
    {
        private Product _product;

        public Product product
        {
            get { return _product; }
        }

        public HistoryChangedForm(Product product = null)
        {
            InitializeComponent();
            _product = product;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView2.DataSource = _product.Audit;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnWrap_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void DataGridView2_MouseDown(object sender, MouseEventArgs e)
        {
            ((DataGridView)sender).CurrentCell = null;
        }
    }
}
