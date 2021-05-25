using RodinaStore.DateBase;
using RodinaStore.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RodinaStore.Forms
{
    public partial class Clients : Form
    {
        List<Client> clients = RodinaStoreController.Instance.GetClients();
        public Clients()
        {
            InitializeComponent();
            UpdateGrid();
            dgvClients.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClients.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateGrid()
        {
            dgvClients.DataSource = null;
            dgvClients.DataSource = clients;
        }

        private void btnWrap_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void BtnAdd_Click(object sender, EventArgs e)
        {
            AddClientForm f = new AddClientForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                clients = RodinaStoreController.Instance.GetClients();
                UpdateGrid();
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            AddClientForm f = new AddClientForm(dgvClients.SelectedRows[0].DataBoundItem as Client);
            if (f.ShowDialog() == DialogResult.OK)
            {
                clients = RodinaStoreController.Instance.GetClients();
                UpdateGrid();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Client client = dgvClients.SelectedRows[0].DataBoundItem as Client;
            if (client != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить клиента " + client.FIO + " ?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RodinaStoreController.Instance.DeleteClient(client);
                    MessageBox.Show("Клиент удалён", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clients = RodinaStoreController.Instance.GetClients();
                    UpdateGrid();
                }

            }
            else
            {
                MessageBox.Show("Вы не выбрали клиента!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvClients_MouseDown(object sender, MouseEventArgs e)
        {
            ((DataGridView)sender).CurrentCell = null;
        }
    }
}
