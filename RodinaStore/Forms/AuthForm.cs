using System;
using System.Collections.Generic;
using RodinaStore.DateBase;
using RodinaStore.Model;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RodinaStore.Forms
{
    public partial class AuthForm : Form
    {
        private static User _user;

        public static User user
        {
            get { return _user; }
        }


        List<User> users = new List<User>();

        public AuthForm(User user = null, bool firstLaunch = true)
        {
            if (firstLaunch)
            {
                BaseObject.IsLoading = true;
                LoadingForm lf = new LoadingForm();
                lf.ShowDialog();
                BaseObject.IsLoading = false;
            }
            InitializeComponent();
            txtPass.UseSystemPasswordChar = true;
            _user = user;
            if (user != null)
                txtLogin.Text = user.Login;
            txtLogin.Text = "admin";
            txtPass.Text = "admin";
        }

        public User create_admin_user()
        {
            User admin_user = new User();
            admin_user.Login = "admin";
            admin_user.Password = "admin";
            admin_user.NickName = "admin";
            Permission perm = new Permission();
            perm.AddCategory = true;
            perm.AddClient = true;
            perm.AddFirm = true;
            perm.AddProduct = true;
            perm.DeleteClient = true;
            perm.DeleteProduct = true;
            perm.EditCategory = true;
            perm.EditClient = true;
            perm.EditFirm = true;
            perm.EditProduct = true;
            admin_user.Permission = perm;
            RodinaStoreController.Instance.UpdateUsers(admin_user);
            return admin_user;
        }

        private void CheckAccount()
        {
            users = RodinaStoreController.Instance.GetUsers();
            if (users.Count == 0)
                users.Add(create_admin_user());

            if (users != null)
                _user = users.FirstOrDefault(t => t.Login.ToString() == txtLogin.Text);

            if (_user != null)
            {
                if (user.Password == txtPass.Text)
                {
                    Hide();
                    Main f = new Main(user);
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    lblError.Text = "Неверный пароль. Попробуйте еще раз.";
                    lblError.ForeColor = Color.Red;
                    lblError.Visible = true;
                }

            }
            else
            {
                lblError.Text = "Такого аккаунта не существует! Попробуйте еще раз.";
                lblError.ForeColor = Color.Red;
                lblError.Visible = true;
            }
        }

        private void BtnAuth_Click(object sender, EventArgs e)
        {
            CheckAccount();
        }

        private void TxtPass_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                BtnAuth_Click(sender, e);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnWrap_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
