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
    public partial class SubirEventos : Form
    {
        int userID;
        EventDAO model_even;
        List<String> typeEvents;
        private EventController eventController;
        User user;
        int comienzo=1, nummax=0;

        public SubirEventos(User user)
        {
            InitializeComponent();
            eventController = new EventController();
            model_even = new EventDAO();
            cargarComboBox();
            this.user = user;
        }

        private void cargarComboBox()
        {
            typeEvents = eventController.cargarDatosComboBox();
            for (int i = 0; i < typeEvents.Count; i++)
            {
                comboBox1.Items.Add(typeEvents[i]);
            }
        }

        private void txtMaxParticipantes_KeyPress(object sender, KeyPressEventArgs e)
        {
            eventController.validarnumeros(e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                nummax = Convert.ToInt32(txtMaxParticipantes.Text);
                DateTime fecha = dateTimePicker1.Value;
                userID = this.user.Id;
                if (txtName.Text.Length == 0 || txtDescription.Text.Length == 0 || txtLocation.Text.Length == 0 || txtMaxParticipantes.Text.Length == 0)
                {
                    MessageBox.Show("Los Campos no pueden estar vacios!");
                }
                else if (nummax > 100)
                {
                    MessageBox.Show("Numero de participantes maximos superado");
                    txtMaxParticipantes.Text = "";
                }
                else
                {
                    model_even.insertar_event(txtName.Text, txtDescription.Text, txtLocation.Text, fecha.ToString(), comienzo, nummax, comboBox1.Text, userID);
                    this.Close();
                }
            }
            catch(FormatException)
            {
                MessageBox.Show("Campos vacios o Formato no correcto");
            }



        }
       
    }
}
