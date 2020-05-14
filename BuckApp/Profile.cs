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
    public partial class Profile : Form
    {
        User user;
        UserController usercontrol;
        public Profile(User user)
        {
            InitializeComponent();
            usercontrol = new UserController();
            this.user = user;
            meterdatos();
            
        }

       private void meterdatos()
        {
            txtName.Text = user.Username;
            txtPassword.Text = user.Password;
            txtEmail.Text = user.Email;
            txtRol.Text = user.Rol;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            String newName = txtName.Text;
            String newPass = txtPassword.Text;
            String newEmail = txtEmail.Text;
           
            var result = MessageBox.Show("Estas seguro que quieres modificar el Usuario?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Boolean b = usercontrol.modifiuser(newName, newPass, newEmail,user.Id);
                if (b == true)
                {
                    MessageBox.Show("Usuario modificado correctamente !!");
                }
                else
                {
                    MessageBox.Show("El Usuario no se ha podido modificar !!");
                }
            }
        }
    }
}
