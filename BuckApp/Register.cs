using Controller;
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
    public partial class Register : Form
    {
        String username, password, confirmPassword, email;

        UserController usercontroller;

        public Register()
        {
            this.MaximizeBox = false;
            InitializeComponent();
            usercontroller = new UserController(); 
        }
        
        private void registerUser(object sender, EventArgs e)
        {
            username = tbUsername.Text;
            password = tbPassword.Text;
            confirmPassword = tbConfirmPassword.Text;
            email = tbEmail.Text;

            if (username.Equals(String.Empty) || password.Equals(String.Empty) || confirmPassword.Equals(String.Empty) || email.Equals(String.Empty))
            {
                MessageBox.Show("No pueden haber campos vacios !!");
            }
            else if(password.Length <= 8)
            {
                MessageBox.Show("Longitud minima debe superar los 8 digitos");
            }
            else if (usercontroller.sameEmail(email) == true)
            {
                MessageBox.Show("Error, correo registrado anteriormente !!");
            }
            else if (controlEmail(email) == false)
            {
                MessageBox.Show("Modelo de correo incorrecto!!");
            }
            else
            {
                if(controlName() == true)
                {
                    controlpass();
                }
                
            }
        }

        private bool controlName()
        {
            if (usercontroller.sameName(username) == true)
            {
                MessageBox.Show("Error, usuario registrado anteriormente !!");
                tbUsername.Text = "";
                return false;
            }
            else
            {
                return true;
            }

        }

        private bool controlEmail(String email)
        {
            Boolean b;
            if ( email.Contains("@gmail.com") || email.Contains("@hotmail.com"))
            {
                b = true;
            }
            else
            {
                b = false;
            }
            return b;
        }

        private void controlpass()
        {
            if (password.Equals(confirmPassword))
            {
                usercontroller.validateRegister(username, password, email);
                MessageBox.Show("Usuario registrado correctamente !!");
                Close();
            }
            else
            {
                MessageBox.Show("Las dos contraseñas no coinciden !!");
                cleanTextBoxPassword();
            }
        }
        
        private void cleanTextBoxPassword()
        {
            tbPassword.Text = String.Empty;
            tbConfirmPassword.Text = String.Empty;
        }
    }
}
