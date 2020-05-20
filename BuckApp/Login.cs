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
        private MoodController moodController;

        User user;

        public Login()
        {
            InitializeComponent();
            userController = new UserController();
            moodController = new MoodController();
        }

        private void validate(object sender, EventArgs e)
        {
            String username = tbUsername.Text;
            String password = tbPassword.Text;

            DateTime today = DateTime.Today;
            

            if (username.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Ningun campo puede estar vacio!!");
            }
            else
            {
                user = userController.validateUser(username, password);
                if (user != null)
                {
                    DateTime lastDate = moodController.takeDate(user.Id);
                    if(lastDate == today)
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
                        AnswerMood answerMood = new AnswerMood(user);
                        this.Hide();
                        answerMood.ShowDialog();
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
