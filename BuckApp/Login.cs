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
                MessageBox.Show("Username or password are empty!!");
            }
            else
            {
                String rol = userController.validateUser(username, password);
                if (rol.Equals(String.Empty))
                {
                    MessageBox.Show("Users or password are incorrect");

                }
                else if (rol.Equals("admin"))
                {
                    MessageBox.Show("ADMIN!! ");

                }
                else if (rol.Equals("user"))
                {
                    AnswerMood mood = new AnswerMood(userController.User);
                    mood.ShowDialog();
                    /*MainUser user = new MainUser(userController.User);
                    this.Hide();
                    user.ShowDialog();
                    if (user.Exit == true)
                    {
                        this.Show();
                    }*/
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
