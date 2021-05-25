using RodinaStore.DateBase;
using RodinaStore.Model;
using System;
using System.Windows.Forms;

namespace RodinaStore.Forms
{
    public partial class AddClientForm : Form
    {

        private Client _client;

        public Client Client
        {
            get
            {
                return _client;
            }
        }

        public AddClientForm(Client client = null)
        {
            InitializeComponent();
            if (client!= null)
            {
                _client = client;
                UpdateTxt();
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (Client == null)
                _client = new Client();

            _client.FIO = txtFam.Text + " " + txtName.Text + " " + txtOtech.Text;
            string number = txtNum.Text;
            var charsDelete = new string[] { "+", "(", ")", "-" };
            foreach (var item in charsDelete)
                number = number.Replace(item, string.Empty);
            _client.Number = long.Parse(number);
            _client.Discount = double.Parse(numericDiscount.Value.ToString()) / 100;
            RodinaStoreController.Instance.UpdateClient(Client);
            MessageBox.Show("Клиент создан!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void UpdateTxt()
        {
            string[] FIO = Client.FIO.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            txtName.Text = FIO[0];
            txtFam.Text = FIO[1];
            txtOtech.Text = FIO[2];
            txtNum.Text = Client.Number.ToString();
            numericDiscount.Value = decimal.Parse((Client.Discount * 100).ToString());
        }

        private void btnWrap_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
