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
        UserController usercontroller;
        //Prueba
        //hola 
        public Register()
        {
            InitializeComponent();
            usercontroller = new UserController(); 
        }

        private void registerUser(object sender, EventArgs e)
        {
            String username = tbUsername.Text;
            String password = tbPassword.Text;
            String confirmPassword = tbConfirmPassword.Text;
            String email = tbEmail.Text;
            
            if (username.Equals(String.Empty) || password.Equals(String.Empty) || confirmPassword.Equals(String.Empty) || email.Equals(String.Empty))
            {
                MessageBox.Show("No pueden haber campos vacios !!");
            }
            else if (usercontroller.sameEmail(email) == true)
            {
                MessageBox.Show("Error, correo registrado anteriormente !!");
            }
            else
            {
                if (password.Equals(confirmPassword))
                {
                    usercontroller.validateRegister(username, password, email);
                    MessageBox.Show("Usuario registrado correctamente !!");
                }
                else
                {
                    MessageBox.Show("Las dos contraseñas no coinciden !!");
                    cleanTextBoxPassword();
                }
            }
        }

        private void cleanTextBoxPassword()
        {
            tbPassword.Text = String.Empty;
            tbConfirmPassword.Text = String.Empty;
        }


    }
}
