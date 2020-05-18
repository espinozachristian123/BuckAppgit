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
    public partial class Login : Form
    {
        private UserController userController;
        User user;

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
                MessageBox.Show("Ningun campo puede estar vacio!!");
            }
            else
            {
                user = userController.validateUser(username, password);
                if (user != null)
                {
                    MainUser mainUser = new MainUser(user);
                    this.Hide();
                    mainUser.ShowDialog();
                    if (mainUser.Exit == true)
                    {
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("No existe un usuario con estas credenciales!");
                }
                cleanFields();
            }
        }

        private void cleanFields()
        {
            tbUsername.Text = "";
            tbPassword.Text = "";

        }

        private void registerClick(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();

        }
    }
}
