using RodinaStore.DateBase;
using RodinaStore.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace RodinaStore.Forms
{
    public partial class SettingsForm : Form
    {

        List<User> users = RodinaStoreController.Instance.GetUsers();
        MySettings settings = new MySettings();

        private static bool IsFirstTryChangePass = false;
        private static string firtsPass;

        private static bool SettingIsChanged = false;

        public SettingsForm()
        {
            InitializeComponent();
            cbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            txtBoxPass.UseSystemPasswordChar = true;
            FillComboBox();
            string connection = MySettings.GetConnectionStringByName("MainConnection.RodinaStore");
            txtBoxConnectionString.Text = connection;
            //
            //AppSettingsTextAndLabel();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnWrap_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnClose_Click_1(object sender, EventArgs e)
        {
            if (!SettingIsChanged) Close();
            if (MessageBox.Show("Вы хотите сохранить изменения?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                RodinaStoreController.Instance.SaveChanges();
                Properties.Database.Default.Save();
            }
            Close();
        }

        private void BtnWrap_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FillComboBox()
        {
            cbUsers.Items.Clear();
            foreach (var item in users)
            {
                cbUsers.Items.Add(item.Login);
            }
        }

        private void ChListBoxPermissions_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnNewUser_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Login = "guest" + users[users.Count - 1].Id;
            user.Permission = new Permission();
            RodinaStoreController.Instance.UpdateUsers(user);
            users = RodinaStoreController.Instance.GetUsers();
            FillComboBox();
            cbUsers.SelectedIndex = users.Count - 1;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            User user = users.FirstOrDefault(t => t.Login == cbUsers.Items[cbUsers.SelectedIndex].ToString());
            user.Login = txtBoxLogin.Text;
            user.NickName = txtBoxFullName.Text;
            user.LockUser = cbBlockUser.Checked;
            Permission perm = new Permission();
            perm.AddProduct = chListBoxPermissions.GetItemChecked(0);
            perm.AddFirm = chListBoxPermissions.GetItemChecked(1);
            perm.AddCategory = chListBoxPermissions.GetItemChecked(2);
            perm.EditProduct = chListBoxPermissions.GetItemChecked(3);
            perm.DeleteProduct = chListBoxPermissions.GetItemChecked(4);
            perm.EditFirm = chListBoxPermissions.GetItemChecked(5);
            perm.EditCategory = chListBoxPermissions.GetItemChecked(6);
            perm.AddClient = chListBoxPermissions.GetItemChecked(7);
            perm.EditClient = chListBoxPermissions.GetItemChecked(8);
            perm.DeleteClient = chListBoxPermissions.GetItemChecked(9);
            perm.WithdrawalOfCash = chListBoxPermissions.GetItemChecked(10);
            perm.ViewStats = chListBoxPermissions.GetItemChecked(11);
            perm.ViewHistoryCart = chListBoxPermissions.GetItemChecked(12);
            perm.ReturnProduct = chListBoxPermissions.GetItemChecked(13);
            perm.ViewHistoryChanged = chListBoxPermissions.GetItemChecked(14);
            user.Permission = perm;
            RodinaStoreController.Instance.UpdateUsers(user);
            FillComboBox();
            cbUsers.SelectedIndex = 0;
            MessageBox.Show("Сохранения изменены!", "Успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            User user = users.FirstOrDefault(t => t.Login == cbUsers.Items[cbUsers.SelectedIndex].ToString());
            RodinaStoreController.Instance.DeleteUser(user);
            users = RodinaStoreController.Instance.GetUsers();
            FillComboBox();
            cbUsers.SelectedIndex = 0;
        }

        private void BtnChangePass_Click(object sender, EventArgs e)
        {
            if (!IsFirstTryChangePass)
            {
                lblEditPass.ForeColor = Color.Red;
                lblEditPass.Text = "Повторите пароль.";
                IsFirstTryChangePass = true;
                firtsPass = txtBoxPass.Text;
                txtBoxPass.Text = "";
            }
            else
            {
                if (firtsPass == txtBoxPass.Text)
                {
                    User user = users.FirstOrDefault(t => t.Login == cbUsers.Items[cbUsers.SelectedIndex].ToString());
                    user.Password = txtBoxPass.Text;
                    RodinaStoreController.Instance.UpdateUsers(user);
                    lblEditPass.ForeColor = Color.Green;
                    lblEditPass.Text = "Пароль изменен.";
                    IsFirstTryChangePass = false;
                }
                else
                {
                    lblEditPass.ForeColor = Color.Red;
                    lblEditPass.Text = "Пароль введен неверно. Повторите попытку.";
                    IsFirstTryChangePass = false;
                }
            }
        }

        private void CbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblEditPass.Text = "";
            if (users[cbUsers.SelectedIndex].Login == "admin")
            {
                btnDelete.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
            }
            txtBoxLogin.Text = users[cbUsers.SelectedIndex].Login;
            txtBoxFullName.Text = users[cbUsers.SelectedIndex].NickName;
            cbBlockUser.Checked = users[cbUsers.SelectedIndex].LockUser;
            txtBoxPass.Text = "";
            Permission perm = users[cbUsers.SelectedIndex].Permission;
            chListBoxPermissions.SetItemChecked(0, perm.AddProduct);
            chListBoxPermissions.SetItemChecked(1, perm.AddFirm);
            chListBoxPermissions.SetItemChecked(2, perm.AddCategory);
            chListBoxPermissions.SetItemChecked(3, perm.EditProduct);
            chListBoxPermissions.SetItemChecked(4, perm.DeleteProduct);
            chListBoxPermissions.SetItemChecked(5, perm.EditFirm);
            chListBoxPermissions.SetItemChecked(6, perm.EditCategory);
            chListBoxPermissions.SetItemChecked(7, perm.AddClient);
            chListBoxPermissions.SetItemChecked(8, perm.EditClient);
            chListBoxPermissions.SetItemChecked(9, perm.DeleteClient);
            chListBoxPermissions.SetItemChecked(10, perm.WithdrawalOfCash);
            chListBoxPermissions.SetItemChecked(11, perm.ViewStats);
            chListBoxPermissions.SetItemChecked(12, perm.ViewHistoryCart);
            chListBoxPermissions.SetItemChecked(13, perm.ReturnProduct);
        }

        private void BtnConnectionStringSave_Click(object sender, EventArgs e)
        {
            if (RodinaStoreContext.CheckConnection(txtBoxConnectionString.Text))
                MySettings.ChangeConnectionStringByName("MainConnection.RodinaStore", txtBoxConnectionString.Text);
        }
    }
}
