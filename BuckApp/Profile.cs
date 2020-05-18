﻿using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuckApp
{
    public partial class Profile : Form
    {
        User user;
        UserController usercontrol;

        public Profile(User user)
        {
            InitializeComponent();
            usercontrol = new UserController();
            this.user = user;
            loadData();
            
        }

       private void loadData()
        {
            txtName.Text = user.Username;
            txtPassword.Text = user.Password;
            txtconfirm.Text = user.Password;
            txtEmail.Text = user.Email;
            txtRol.Text = user.Rol;
        }
        Boolean b;

        private void modificarPerfil(object sender, EventArgs e)
        {
            String newName = txtName.Text;
            String newPass = txtPassword.Text;
            String confirm = txtconfirm.Text;
            String newEmail = txtEmail.Text;

            var result = MessageBox.Show("Estas seguro que quieres modificar el Usuario?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                if (txtName.Equals(String.Empty) || txtPassword.Equals(String.Empty) || txtconfirm.Equals(String.Empty) || txtEmail.Equals(String.Empty))
                {
                    MessageBox.Show("No pueden haber campos vacios !!");
                }
                else if (newName.Equals(user.Username) && newPass.Equals(user.Password) && newEmail.Equals(user.Email))
                {
                    MessageBox.Show("No se ha modificado el ningun campo");
                }
                else if (!newName.Equals(user.Username) || !newPass.Equals(user.Password) || !newEmail.Equals(user.Email))
                {
                    controlName();
                    controlEmail();
                    if (newPass.Equals(confirm))
                    {
                        usercontrol.modifyPass(newPass, user.Id);
                    }
                    else
                    {
                        MessageBox.Show("Password confirm no coincide");
                    }
                }
            }
            else
            {
                MessageBox.Show("El Usuario no se ha podido modificar !!");
            }


        }
        private void controlEmail()
        {
           String newEmail = txtEmail.Text;
            if (!newEmail.Equals(user.Email))
            {
                if (usercontrol.sameEmail(newEmail) == true)
                {
                    MessageBox.Show("Error, correo registrado anteriormente !!");
                }
                else
                {
                    usercontrol.modifyEmail(newEmail, user.Id);
                }
            }
        }

        private void controlName()
        {
            String newName = txtName.Text;
            if (!newName.Equals(user.Username))
            {
                if (usercontrol.sameName(newName) == true)
                {
                    MessageBox.Show("Error, usuario registrado anteriormente !!");
                }
                else
                {
                    usercontrol.modifyNames(newName,user.Id);
                }
            }
        }
    }
}
