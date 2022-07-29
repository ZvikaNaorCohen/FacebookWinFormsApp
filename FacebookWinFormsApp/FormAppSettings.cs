﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;

namespace BasicFacebookFeatures
{
    public partial class FormAppSettings : Form
    {
        private const string k_AppId = "1225204811548586";
        private LoginResult m_LoginResult;

        public FormAppSettings()
        {
            InitializeComponent();
            FacebookWrapper.FacebookService.s_CollectionLimit = 100;
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("design.patterns20cc"); /// the current password for Desig Patter

            m_LoginResult = FacebookService.Login(k_AppId, "email", "public_profile", "user_photos");

            //if(loginResult.LoggedInUser != null)
            //{
            //    buttonLogin.Text = $"Logged in as {loginResult.LoggedInUser.Name}";
            //    FormMain test = new FormMain();
            //    test.ShowDialog();
            //}

            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {
                User loggedInUser = m_LoginResult.LoggedInUser;
                FormMain test = new FormMain(loggedInUser);
                test.ShowDialog();
            }

            else
            {
                MessageBox.Show(m_LoginResult.ErrorMessage, "Login Failed");
            }

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            FacebookService.LogoutWithUI();
            this.buttonLogin.Text = "Login";
        }
    }
}