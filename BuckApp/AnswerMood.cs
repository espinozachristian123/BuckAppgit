﻿using Controller;
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
        int mood;
        MoodController moodController;
        User user;
        DateTime fechaHoy;

        public AnswerMood(User user)
        {
            InitializeComponent();
            moodController = new MoodController();
            this.user = user;
        }

        private void Botones(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            switch (b.Name)
            {
                case "button1":
                    mood = 1;
                    break;
                case "button2":
                    mood = 2;
                    break;
                case "button3":
                    mood = 3;
                    break;
                case "button4":
                    mood = 4;
                    break;
                case "button5":
                    mood = 5;
                    break;
            }
            validate(mood);
        }

        public void validate(int mood)
        {
            fechaHoy = DateTime.Today;
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
                        this.Show();
                    }
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
        }
    }
}