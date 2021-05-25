using RodinaStore.DateBase;
using System;
using System.Threading;
using System.Windows.Forms;

namespace RodinaStore.Forms
{
    public partial class LoadingForm : Form
    {
        delegate void labelTextDelegate(string text);

        private void LabelText(string text)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new labelTextDelegate(LabelText), new object[] { text });
                return;
            }
            else
            {
                label3.Text = text;
            }
        }

        private void CloseForm()
        {
            if (InvokeRequired)
            {
                BeginInvoke(new System.Windows.Forms.MethodInvoker(() => this.Close()));
                Thrd.Abort();
                return;
            }
            else this.Close();
        }

        

        private Thread Thrd;

        public LoadingForm()
        {
            InitializeComponent();
            Thrd = new Thread(LoadDatabase);
            Thrd.Start();
        }


        private void LoadDatabase()
        {
            LabelText("Создание/загрузка базы данных..");
            RodinaStoreController.Instance.GetBaseObjects();
            LabelText("Загрузка продуктов...");
            RodinaStoreController.Instance.GetProducts();
            LabelText("Загрузка пользователей...");
            RodinaStoreController.Instance.GetUsers();
            LabelText("Загрузка категорий...");
            RodinaStoreController.Instance.GetCategories();
            LabelText("Загрузка фирм...");
            RodinaStoreController.Instance.GetFirms();
            LabelText("Загрузка истории продаж...");
            RodinaStoreController.Instance.GetSoldItems();            
            CloseForm();
        }



        private void btnWrap_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Environment.Exit(1);
        }
    }
}
