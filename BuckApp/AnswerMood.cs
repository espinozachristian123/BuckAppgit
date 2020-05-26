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
    public partial class AnswerMood : Form
    {
        String fechaHoy;
        int mood;

        MoodController moodController;
        User user;
        
        public AnswerMood(User user)
        {
            InitializeComponent();
            moodController = new MoodController();
            this.user = user;
        }

        /// <summary>
        /// Take the value of the mood from the option chosen by the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Buttons(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Name)
            {
                case "btVeryBad":
                    mood = 1;
                    break;
                case "btBad":
                    mood = 2;
                    break;
                case "btNormal":
                    mood = 3;
                    break;
                case "btGood":
                    mood = 4;
                    break;
                case "btVeryGood":
                    mood = 5;
                    break;
            }
            validate(mood);
        }

        /// <summary>
        /// ask the user if are he shure and then check the answer.
        /// if the answer is yes, insert the value of mood and the Date in database.
        /// if the insert is correctly , the program will show the next window.
        /// in case of error , the program show a message of error.
        /// </summary>
        /// <param name="mood"></param>
        public void validate(int mood)
        {
            fechaHoy = DateTime.Today.ToShortDateString();
            var result = MessageBox.Show("Estas seguro?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Boolean b = moodController.validateInsert(user.Id, mood, fechaHoy.ToString());
                if (b == true)
                {
                    MainUser mainUser = new MainUser(user);
                    this.Hide();
                    mainUser.ShowDialog();
                    if (mainUser.Exit == true)
                    {
                        Login login = new Login();
                        login.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No se ha podido insertar tu estado de animo","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// hide form answer and return in login window
        /// </summary>
        private void AnswerMood_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
