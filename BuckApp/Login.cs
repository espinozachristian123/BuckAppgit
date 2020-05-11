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
    public partial class Login : Form
    {
        private UserController userController;

        public Login()
        {
            InitializeComponent();
            userController = new UserController();
        }

        private void validate(object sender, EventArgs e)
        {
            String username = tbUsername.Text;
            String password = tbPassword.Text;

            if (username.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Username or password are empty!!");
            }
            else
            {
                String rol = userController.validateUser(username, password);
                if (rol.Equals(String.Empty))
                {
                    MessageBox.Show("Users or password are incorrect");

                } else if (rol.Equals("admin"))
                {
                    MessageBox.Show("ADMIN!! ");

                } else if (rol.Equals("user"))
                {
                    MainUser user = new MainUser(userController.User);
                    user.ShowDialog();
                }

                cleanFields();
            }
        }

        private void cleanFields()
        {
            tbUsername.Text = "";
            tbPassword.Text = "";
        }

        private void btChekin_Click(object sender, EventArgs e)
        {
            //this.Close();
            
            mostrarventana();
        }
        private void mostrarventana()
        {
            Registro nw = new Registro();
            nw.Show();
        }
    }
}
