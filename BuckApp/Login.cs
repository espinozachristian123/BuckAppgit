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

        /// <summary>
        ///we collect the data from the textbox, if the fields are empty the program returns an error message
        ///If the information is complete, we search for a user with those credentials in the database.
        ///If the user is not found, the program notifies the client, otherwise the program accesses the following window with the user's complete information.
        ///To decide which window goes to the user, the program looks at 2 factors: 1- Registration of a state of mind 2- If that registration is from today or not
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    if (user.Rol.Equals("user"))
                    {
                        DateTime lastDate = moodController.takeDate(user.Id);
                        if (lastDate == today)
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
                    else if(user.Rol.Equals("admin"))
                    {
                        MainUser mainUser = new MainUser(user);
                        this.Hide();
                        mainUser.ShowDialog();
                        if (mainUser.Exit == true)
                        {
                            this.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No existe un usuario con estas credenciales!");
                }
                cleanFields();
            }
        }

        /// <summary>
        /// Empty the current two fields
        /// </summary>
        private void cleanFields()
        {
            tbUsername.Text = "";
            tbPassword.Text = "";
        }

        /// <summary>
        /// Redirect to the register window to be able to log in later
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerClick(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }
    }
}
