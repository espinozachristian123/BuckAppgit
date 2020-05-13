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
        int comienzo=1, nummax;
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

        private void button1_Click(object sender, EventArgs e)
        {
            nummax = Convert.ToInt16(txtMaxParticipantes.Text);
            DateTime fecha = dateTimePicker1.Value;
            userID = this.user.Id;
            model_even.insertar_event(txtName.Text, txtDescription.Text, txtLocation.Text, fecha.ToString(), comienzo, nummax, comboBox1.Text, userID);
            this.Close();
        }
    }
}
