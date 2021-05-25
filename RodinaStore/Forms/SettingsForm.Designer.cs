namespace RodinaStore.Forms
{
    partial class SettingsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.MainTab = new System.Windows.Forms.TabControl();
            this.tbMainSettings = new System.Windows.Forms.TabPage();
            this.cbIconTrey = new System.Windows.Forms.CheckBox();
            this.cbAutoRun = new System.Windows.Forms.CheckBox();
            this.tbUsers = new System.Windows.Forms.TabPage();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.cbBlockUser = new System.Windows.Forms.CheckBox();
            this.btnNewUser = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chListBoxPermissions = new System.Windows.Forms.CheckedListBox();
            this.lblPermissions = new System.Windows.Forms.Label();
            this.btnChangePass = new System.Windows.Forms.Button();
            this.txtBoxPass = new System.Windows.Forms.TextBox();
            this.txtBoxLogin = new System.Windows.Forms.TextBox();
            this.txtBoxFullName = new System.Windows.Forms.TextBox();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblLogin = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblnfoUser = new System.Windows.Forms.Label();
            this.lblSelectUser = new System.Windows.Forms.Label();
            this.tbDatabase = new System.Windows.Forms.TabPage();
            this.HeaderPanel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnClose = new Bunifu.Framework.UI.BunifuImageButton();
            this.btnWrap = new Bunifu.Framework.UI.BunifuImageButton();
            this.lblEditPass = new System.Windows.Forms.Label();
            this.lblConnectionString = new System.Windows.Forms.Label();
            this.txtBoxConnectionString = new System.Windows.Forms.TextBox();
            this.btnConnectionStringSave = new System.Windows.Forms.Button();
            this.MainTab.SuspendLayout();
            this.tbMainSettings.SuspendLayout();
            this.tbUsers.SuspendLayout();
            this.tbDatabase.SuspendLayout();
            this.HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWrap)).BeginInit();
            this.SuspendLayout();
            // 
            // MainTab
            // 
            this.MainTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainTab.Controls.Add(this.tbMainSettings);
            this.MainTab.Controls.Add(this.tbUsers);
            this.MainTab.Controls.Add(this.tbDatabase);
            this.MainTab.Location = new System.Drawing.Point(0, 30);
            this.MainTab.Name = "MainTab";
            this.MainTab.SelectedIndex = 0;
            this.MainTab.Size = new System.Drawing.Size(514, 417);
            this.MainTab.TabIndex = 13;
            // 
            // tbMainSettings
            // 
            this.tbMainSettings.Controls.Add(this.cbIconTrey);
            this.tbMainSettings.Controls.Add(this.cbAutoRun);
            this.tbMainSettings.Location = new System.Drawing.Point(4, 22);
            this.tbMainSettings.Name = "tbMainSettings";
            this.tbMainSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tbMainSettings.Size = new System.Drawing.Size(506, 391);
            this.tbMainSettings.TabIndex = 0;
            this.tbMainSettings.Text = "Общие настройки";
            this.tbMainSettings.UseVisualStyleBackColor = true;
            // 
            // cbIconTrey
            // 
            this.cbIconTrey.AutoSize = true;
            this.cbIconTrey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbIconTrey.ForeColor = System.Drawing.Color.Black;
            this.cbIconTrey.Location = new System.Drawing.Point(8, 43);
            this.cbIconTrey.Name = "cbIconTrey";
            this.cbIconTrey.Size = new System.Drawing.Size(225, 20);
            this.cbIconTrey.TabIndex = 103;
            this.cbIconTrey.Text = "Отображать иконку в трее";
            this.cbIconTrey.UseVisualStyleBackColor = true;
            // 
            // cbAutoRun
            // 
            this.cbAutoRun.AutoSize = true;
            this.cbAutoRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbAutoRun.ForeColor = System.Drawing.Color.Black;
            this.cbAutoRun.Location = new System.Drawing.Point(8, 17);
            this.cbAutoRun.Name = "cbAutoRun";
            this.cbAutoRun.Size = new System.Drawing.Size(375, 20);
            this.cbAutoRun.TabIndex = 101;
            this.cbAutoRun.Text = "Автоматически загружаться вместе с Windows";
            this.cbAutoRun.UseVisualStyleBackColor = true;
            // 
            // tbUsers
            // 
            this.tbUsers.Controls.Add(this.lblEditPass);
            this.tbUsers.Controls.Add(this.cbUsers);
            this.tbUsers.Controls.Add(this.cbBlockUser);
            this.tbUsers.Controls.Add(this.btnNewUser);
            this.tbUsers.Controls.Add(this.btnDelete);
            this.tbUsers.Controls.Add(this.btnSave);
            this.tbUsers.Controls.Add(this.chListBoxPermissions);
            this.tbUsers.Controls.Add(this.lblPermissions);
            this.tbUsers.Controls.Add(this.btnChangePass);
            this.tbUsers.Controls.Add(this.txtBoxPass);
            this.tbUsers.Controls.Add(this.txtBoxLogin);
            this.tbUsers.Controls.Add(this.txtBoxFullName);
            this.tbUsers.Controls.Add(this.lblPass);
            this.tbUsers.Controls.Add(this.lblLogin);
            this.tbUsers.Controls.Add(this.lblFullName);
            this.tbUsers.Controls.Add(this.lblnfoUser);
            this.tbUsers.Controls.Add(this.lblSelectUser);
            this.tbUsers.Location = new System.Drawing.Point(4, 22);
            this.tbUsers.Name = "tbUsers";
            this.tbUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tbUsers.Size = new System.Drawing.Size(506, 391);
            this.tbUsers.TabIndex = 1;
            this.tbUsers.Text = "Пользователи";
            this.tbUsers.UseVisualStyleBackColor = true;
            // 
            // cbUsers
            // 
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Location = new System.Drawing.Point(313, 17);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(182, 21);
            this.cbUsers.TabIndex = 19;
            this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.CbUsers_SelectedIndexChanged);
            // 
            // cbBlockUser
            // 
            this.cbBlockUser.AutoSize = true;
            this.cbBlockUser.Location = new System.Drawing.Point(54, 350);
            this.cbBlockUser.Name = "cbBlockUser";
            this.cbBlockUser.Size = new System.Drawing.Size(178, 17);
            this.cbBlockUser.TabIndex = 18;
            this.cbBlockUser.Text = "Заблокировать пользователя";
            this.cbBlockUser.UseVisualStyleBackColor = true;
            // 
            // btnNewUser
            // 
            this.btnNewUser.Location = new System.Drawing.Point(420, 346);
            this.btnNewUser.Name = "btnNewUser";
            this.btnNewUser.Size = new System.Drawing.Size(75, 23);
            this.btnNewUser.TabIndex = 17;
            this.btnNewUser.Text = "Новый";
            this.btnNewUser.UseVisualStyleBackColor = true;
            this.btnNewUser.Click += new System.EventHandler(this.BtnNewUser_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(339, 346);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(258, 346);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // chListBoxPermissions
            // 
            this.chListBoxPermissions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chListBoxPermissions.FormattingEnabled = true;
            this.chListBoxPermissions.Items.AddRange(new object[] {
            "Добавление нового продукта",
            "Добавление новой фирмы",
            "Добавление новой категории",
            "Редактирование существуещего продукта",
            "Удаление существующего продукта",
            "Редактирование существующей фирмы",
            "Редактирование существующей категории",
            "Добавление нового клиента",
            "Редактирование существующего клиента",
            "Удаление существующего клиента",
            "Снятие кассы",
            "Просмотр статистики",
            "Просмотр истории продаж ",
            "Оформление возврата",
            "Просмотр истории изменений"});
            this.chListBoxPermissions.Location = new System.Drawing.Point(54, 218);
            this.chListBoxPermissions.Name = "chListBoxPermissions";
            this.chListBoxPermissions.Size = new System.Drawing.Size(387, 122);
            this.chListBoxPermissions.TabIndex = 10;
            // 
            // lblPermissions
            // 
            this.lblPermissions.AutoSize = true;
            this.lblPermissions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermissions.Location = new System.Drawing.Point(172, 188);
            this.lblPermissions.Name = "lblPermissions";
            this.lblPermissions.Size = new System.Drawing.Size(164, 16);
            this.lblPermissions.TabIndex = 9;
            this.lblPermissions.Text = "Права пользователя";
            // 
            // btnChangePass
            // 
            this.btnChangePass.Location = new System.Drawing.Point(381, 145);
            this.btnChangePass.Name = "btnChangePass";
            this.btnChangePass.Size = new System.Drawing.Size(114, 23);
            this.btnChangePass.TabIndex = 8;
            this.btnChangePass.Text = "Сменить пароль";
            this.btnChangePass.UseVisualStyleBackColor = true;
            this.btnChangePass.Click += new System.EventHandler(this.BtnChangePass_Click);
            // 
            // txtBoxPass
            // 
            this.txtBoxPass.Location = new System.Drawing.Point(118, 147);
            this.txtBoxPass.Name = "txtBoxPass";
            this.txtBoxPass.Size = new System.Drawing.Size(257, 20);
            this.txtBoxPass.TabIndex = 7;
            // 
            // txtBoxLogin
            // 
            this.txtBoxLogin.Location = new System.Drawing.Point(118, 121);
            this.txtBoxLogin.Name = "txtBoxLogin";
            this.txtBoxLogin.Size = new System.Drawing.Size(257, 20);
            this.txtBoxLogin.TabIndex = 6;
            // 
            // txtBoxFullName
            // 
            this.txtBoxFullName.Location = new System.Drawing.Point(118, 94);
            this.txtBoxFullName.Name = "txtBoxFullName";
            this.txtBoxFullName.Size = new System.Drawing.Size(257, 20);
            this.txtBoxFullName.TabIndex = 5;
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPass.ForeColor = System.Drawing.Color.Firebrick;
            this.lblPass.Location = new System.Drawing.Point(40, 147);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(67, 16);
            this.lblPass.TabIndex = 4;
            this.lblPass.Text = "Пароль:";
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblLogin.ForeColor = System.Drawing.Color.Firebrick;
            this.lblLogin.Location = new System.Drawing.Point(51, 121);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(56, 16);
            this.lblLogin.TabIndex = 3;
            this.lblLogin.Text = "Логин:";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblFullName.ForeColor = System.Drawing.Color.Firebrick;
            this.lblFullName.Location = new System.Drawing.Point(8, 95);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(99, 16);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "Полное имя:";
            // 
            // lblnfoUser
            // 
            this.lblnfoUser.AutoSize = true;
            this.lblnfoUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnfoUser.Location = new System.Drawing.Point(133, 53);
            this.lblnfoUser.Name = "lblnfoUser";
            this.lblnfoUser.Size = new System.Drawing.Size(226, 16);
            this.lblnfoUser.TabIndex = 1;
            this.lblnfoUser.Text = "Информация о пользователе";
            // 
            // lblSelectUser
            // 
            this.lblSelectUser.AutoSize = true;
            this.lblSelectUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectUser.Location = new System.Drawing.Point(3, 18);
            this.lblSelectUser.Name = "lblSelectUser";
            this.lblSelectUser.Size = new System.Drawing.Size(304, 16);
            this.lblSelectUser.TabIndex = 0;
            this.lblSelectUser.Text = "Выбрать существующего пользователя:";
            // 
            // tbDatabase
            // 
            this.tbDatabase.Controls.Add(this.btnConnectionStringSave);
            this.tbDatabase.Controls.Add(this.txtBoxConnectionString);
            this.tbDatabase.Controls.Add(this.lblConnectionString);
            this.tbDatabase.Location = new System.Drawing.Point(4, 22);
            this.tbDatabase.Name = "tbDatabase";
            this.tbDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tbDatabase.Size = new System.Drawing.Size(506, 391);
            this.tbDatabase.TabIndex = 2;
            this.tbDatabase.Text = "База данных SQL";
            this.tbDatabase.UseVisualStyleBackColor = true;
            // 
            // HeaderPanel
            // 
            this.HeaderPanel.BackColor = System.Drawing.Color.Black;
            this.HeaderPanel.Controls.Add(this.btnClose);
            this.HeaderPanel.Controls.Add(this.btnWrap);
            this.HeaderPanel.Controls.Add(this.pictureBox2);
            this.HeaderPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.HeaderPanel.Location = new System.Drawing.Point(0, 0);
            this.HeaderPanel.Name = "HeaderPanel";
            this.HeaderPanel.Size = new System.Drawing.Size(514, 30);
            this.HeaderPanel.TabIndex = 14;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RodinaStore.Properties.Resources.RodinaStore;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(65, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.Black;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageActive = null;
            this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnClose.Location = new System.Drawing.Point(488, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(26, 30);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnClose.TabIndex = 6;
            this.btnClose.TabStop = false;
            this.btnClose.Zoom = 10;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click_1);
            // 
            // btnWrap
            // 
            this.btnWrap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnWrap.BackColor = System.Drawing.Color.Black;
            this.btnWrap.Image = ((System.Drawing.Image)(resources.GetObject("btnWrap.Image")));
            this.btnWrap.ImageActive = null;
            this.btnWrap.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.btnWrap.Location = new System.Drawing.Point(458, 0);
            this.btnWrap.Name = "btnWrap";
            this.btnWrap.Size = new System.Drawing.Size(26, 30);
            this.btnWrap.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnWrap.TabIndex = 5;
            this.btnWrap.TabStop = false;
            this.btnWrap.Zoom = 10;
            this.btnWrap.Click += new System.EventHandler(this.BtnWrap_Click_1);
            // 
            // lblEditPass
            // 
            this.lblEditPass.AutoSize = true;
            this.lblEditPass.Location = new System.Drawing.Point(118, 174);
            this.lblEditPass.Name = "lblEditPass";
            this.lblEditPass.Size = new System.Drawing.Size(0, 13);
            this.lblEditPass.TabIndex = 20;
            // 
            // lblConnectionString
            // 
            this.lblConnectionString.AutoSize = true;
            this.lblConnectionString.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblConnectionString.Location = new System.Drawing.Point(8, 21);
            this.lblConnectionString.Name = "lblConnectionString";
            this.lblConnectionString.Size = new System.Drawing.Size(141, 16);
            this.lblConnectionString.TabIndex = 0;
            this.lblConnectionString.Text = "Connection String : ";
            // 
            // txtBoxConnectionString
            // 
            this.txtBoxConnectionString.Location = new System.Drawing.Point(156, 20);
            this.txtBoxConnectionString.Multiline = true;
            this.txtBoxConnectionString.Name = "txtBoxConnectionString";
            this.txtBoxConnectionString.Size = new System.Drawing.Size(324, 68);
            this.txtBoxConnectionString.TabIndex = 1;
            // 
            // btnConnectionStringSave
            // 
            this.btnConnectionStringSave.Location = new System.Drawing.Point(11, 65);
            this.btnConnectionStringSave.Name = "btnConnectionStringSave";
            this.btnConnectionStringSave.Size = new System.Drawing.Size(138, 23);
            this.btnConnectionStringSave.TabIndex = 2;
            this.btnConnectionStringSave.Text = "Сохранить";
            this.btnConnectionStringSave.UseVisualStyleBackColor = true;
            this.btnConnectionStringSave.Click += new System.EventHandler(this.BtnConnectionStringSave_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(514, 459);
            this.Controls.Add(this.HeaderPanel);
            this.Controls.Add(this.MainTab);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.MainTab.ResumeLayout(false);
            this.tbMainSettings.ResumeLayout(false);
            this.tbMainSettings.PerformLayout();
            this.tbUsers.ResumeLayout(false);
            this.tbUsers.PerformLayout();
            this.tbDatabase.ResumeLayout(false);
            this.tbDatabase.PerformLayout();
            this.HeaderPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnWrap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl MainTab;
        private System.Windows.Forms.TabPage tbMainSettings;
        private System.Windows.Forms.TabPage tbUsers;
        private System.Windows.Forms.TabPage tbDatabase;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel HeaderPanel;
        private System.Windows.Forms.CheckBox cbIconTrey;
        private System.Windows.Forms.CheckBox cbAutoRun;
        private System.Windows.Forms.CheckBox cbBlockUser;
        private System.Windows.Forms.Button btnNewUser;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckedListBox chListBoxPermissions;
        private System.Windows.Forms.Label lblPermissions;
        private System.Windows.Forms.Button btnChangePass;
        private System.Windows.Forms.TextBox txtBoxPass;
        private System.Windows.Forms.TextBox txtBoxLogin;
        private System.Windows.Forms.TextBox txtBoxFullName;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblnfoUser;
        private System.Windows.Forms.Label lblSelectUser;
        private System.Windows.Forms.ComboBox cbUsers;
        private Bunifu.Framework.UI.BunifuImageButton btnClose;
        private Bunifu.Framework.UI.BunifuImageButton btnWrap;
        private System.Windows.Forms.Label lblEditPass;
        private System.Windows.Forms.Button btnConnectionStringSave;
        private System.Windows.Forms.TextBox txtBoxConnectionString;
        private System.Windows.Forms.Label lblConnectionString;
    }
}