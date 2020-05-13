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
        String name, description, localidad, fecha, type;
        int n_participantes, n_maxParticipantes, id_user, userID;
        EventDAO model_even = new EventDAO();
        List<Event> events;
        List<String> typeEvents;
        private EventController eventController;
        User user;
        int comienzo, nummax;
        public SubirEventos(User user)
        {
            InitializeComponent();
            eventController = new EventController();
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
            comienzo = 1;
            // tbNInscritos.Text = empezar;
            nummax = Convert.ToInt16(txtMaxParticipantes.Text);
            DateTime fecha = dateTimePicker1.Value;
            userID = this.user.Id;
            //MessageBox.Show(txtName.Text);
            //MessageBox.Show(txtDescription.Text);
            //MessageBox.Show(txtLocation.Text);
            MessageBox.Show(fecha.ToString("yyyy-MM-dd HH:mm:ss"));


            //MessageBox.Show(comienzo.ToString());
            //MessageBox.Show(nummax.ToString());
            //MessageBox.Show(comboBox1.Text);
            //MessageBox.Show(userID.ToString());



            model_even.insertar_event(txtName.Text, txtDescription.Text, txtLocation.Text, fecha.ToString(), comienzo, nummax, comboBox1.Text, userID);
            txtName.Text = "";
            txtDescription.Text = "";
            txtLocation.Text = "";
           // tbNInscritos.Text = "";
            txtMaxParticipantes.Text = "";

            this.Close();
        }







    }
}
