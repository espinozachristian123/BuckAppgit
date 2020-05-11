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
    public partial class Registro : Form
    {
        UserDAO model = new UserDAO();
        public Registro()
        {
            InitializeComponent();
        }

        private void btnregistro(object sender, EventArgs e)
        {
            string roluser = "user";
            model.registrase(txtName.Text, txtConfirm.Text, roluser, Email.Text);
            txtName.Text = "";
            txtPassword.Text = "";
            txtConfirm.Text = "";
            txtEmail.Text = "";
            this.Close();
            //volverlogin();
        }

        private void volverlogin()
        {
            Login lg = new Login();
            lg.Show();
        }
    }
}
