using Controller;
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
        Boolean b;

        User user;
        UserController usercontrol;

        public Profile(User user)
        {
            InitializeComponent();
            usercontrol = new UserController();
            this.user = user;
            loadData();

        }

        /// <summary>
        /// Pone toda la informacion del usuario en los campos correspondientes
        /// </summary>
        private void loadData()
        {
            txtName.Text = user.Username;
            txtPassword.Text = user.Password;
            txtconfirm.Text = user.Password;
            txtEmail.Text = user.Email;
            txtRol.Text = user.Rol;
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                else if (newPass.Length <= 8)
                {
                    MessageBox.Show("El minimo de digitos debe de ser 9 !");
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

        /// <summary>
        /// Take the new value in the name field.
        /// If the new name already exists in the database notify the user
        /// Otherwise modify the name of the user
        /// </summary>
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
                    usercontrol.modifyNames(newName, user.Id);
                }
            }
        }

        /// <summary>
        /// Take the new value of the email field.
        /// If the new email, already exists in the database or does not comply
        /// with the default mail model the program notifies the user of an error
        /// If not modify the mail to the user
        /// </summary>
        private void controlEmail()
        {
            String newEmail = txtEmail.Text;
            if (!newEmail.Equals(user.Email))
            {
                if (usercontrol.sameEmail(newEmail) == true)
                {
                    MessageBox.Show("Error, correo registrado anteriormente !!");
                }
                else if(!(newEmail.Contains("@gmail.com"))|| !(newEmail.Contains("@hotmail.com")))
                {
                    MessageBox.Show("Modelo de correo no valido. Debe ser gmail o hotmail !!");
                }
                else
                {
                    usercontrol.modifyEmail(newEmail, user.Id);
                }
            }
        }
    }
}
