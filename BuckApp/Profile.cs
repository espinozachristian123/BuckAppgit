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
        /// Put all the information of the user in the corresponding fields
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
        /// Check that the fields to be modified are not empty
        /// Check that the new password entered has a minimum size of 8 characters
        /// Check that the fields that have already been entered have been modified
        /// Check if any field has been modified and if this condition is met, call the methods
        /// Check if any field has been modified and if this condition is met, call the methods to control the names and the email entered
        /// Also check if the new password is the same when confirming password
        /// If these conditions are met, the user modifies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modificarPerfil(object sender, EventArgs e)
        {
            String newName = txtName.Text;
            String newPass = txtPassword.Text;
            String confirm = txtconfirm.Text;
            String newEmail = txtEmail.Text;
            bool check1=false,check2 = false;
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
                    if (newPass.Equals(confirm))
                    {
                        if (modifytheEmail(check1) == true  && modifythename(check2) ==  true)
                        {
                            MessageBox.Show("Usuario modificado");
                            usercontrol.modifyUser(newName, newPass, newEmail, user.Id);
                        }
                        else
                        {
                            
                            MessageBox.Show("Usuario no modificado");
                        }
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
        /// Take the new value of the email field.
        /// If the new email, already exists in the database or does not comply
        /// with the default mail model the program notifies the user of an error
        /// If not modify the mail to the user
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        private Boolean modifytheEmail(bool check)
        {
            String newEmail = txtEmail.Text;
            check = true;
            if (!newEmail.Equals(user.Email))
            {
                if (usercontrol.sameEmail(newEmail) == true)
                {
                    MessageBox.Show("Error, correo registrado anteriormente !!");
                    txtEmail.Text = user.Email;
                    check = false;
                }
                else if (controlEmail(newEmail) == false)
                {
                    MessageBox.Show("Modelo de correo no valido. Debe ser gmail o hotmail !!");
                    txtEmail.Text = user.Email;
                    check = false;
                }
                else
                {
                    check = true;
                }
            }
            return check;
        }
        /// <summary>
        /// Take the new value in the name field.
        /// If the new name already exists in the database notify the user
        /// Otherwise modify the name of the user
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>

        private Boolean modifythename(bool check)
        {
            check = true;
            String newName = txtName.Text;
            if (!newName.Equals(user.Username))
            {
                if (usercontrol.sameName(newName) == true)
                {
                    MessageBox.Show("Error, usuario registrado anteriormente !!");
                    txtName.Text = user.Username;
                    check = false;
                }
                else
                {
                    usercontrol.modifyNames(newName, user.Id);
                    check = true;
                }
            }
            return check;
        }
        /// <summary>
        /// Check that the email model is valid
        /// </summary>
        /// <param name="email"></param>
        /// <returns> true if the email is correct and false if it is not </returns>
        private bool controlEmail(String email)
        {
            Boolean b;
            if (email.Contains("@gmail.com") || email.Contains("@hotmail.com"))
            {
                b = true;
            }
            else
            {
                b = false;
            }
            return b;
        }

    }
}
