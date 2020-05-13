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
    public partial class combotipo : Form
    {
        String name, description, localidad, fecha, type;
        int n_participantes, n_maxParticipantes, id_user, userID;
        EventDAO model_even = new EventDAO();
        List<Event> events;
        List<String> typeEvents;
        private EventController eventController;
        int comienzo,nummax;

        private void btRegisterEvent_Click(object sender, EventArgs e)
        {
            //tbNInscritos.Text = Convert.ToString(n_participantes);
            //tbMaxParticipantes.Text = Convert.ToString(n_maxParticipantes);
            //tbTipo.Text = type;
            comienzo = Convert.ToInt32(tbNInscritos.Text);
            comienzo = 1;
            // tbNInscritos.Text = empezar;
            nummax = Convert.ToInt16(tbMaxParticipantes.Text);
            DateTime fecha = datepicker.Value;
            userID = this.user.Id;
            MessageBox.Show(tbName.Text);
            MessageBox.Show(tbDescription.Text);
            MessageBox.Show(tbLocalidad.Text);
            MessageBox.Show(fecha.ToString());


            MessageBox.Show(comienzo.ToString());
            MessageBox.Show(nummax.ToString());
            MessageBox.Show(comboBox1.Text);
            MessageBox.Show(userID.ToString());



            model_even.insertar_event(tbName.Text, tbDescription.Text, tbLocalidad.Text, fecha.ToString(), comienzo, nummax, comboBox1.Text, userID);
            tbName.Text = "";
            tbDescription.Text = "";
            tbLocalidad.Text = "";
            tbNInscritos.Text = "";
            tbMaxParticipantes.Text = "";

            //this.Close();
        }

        User user;


        public combotipo(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void Registrar_event(object sender, EventArgs e)
        {
           
        }

        public combotipo(String name, String description, String localidad, String fecha, 
            int n_participantes, int n_maxParticipantes, String type, int id_user, int userID)
        {
            InitializeComponent();
            this.name = name;
            this.description = description;
            this.localidad = localidad;
            this.fecha = fecha;
            this.n_participantes = n_participantes;
            this.n_maxParticipantes = n_maxParticipantes;
            this.type = type;
            this.id_user = id_user;
            this.userID = userID;
        }

        private void InfoEvents_Load(object sender, EventArgs e)
        {
            eventController = new EventController();
            ponerDatosTextBox();
            ocultarCampos();
            cargarComboBox();
        }
        
        private void ponerDatosTextBox()
        {
            tbName.Text = name;
            tbDescription.Text = description;
            tbLocalidad.Text = localidad;
            tbFecha.Text = fecha;
            tbNInscritos.Text = Convert.ToString(n_participantes);
            tbMaxParticipantes.Text = Convert.ToString(n_maxParticipantes);
            tbTipo.Text = type;
        }
        //infoevents
        private void ocultarCampos()
        {
            if (id_user != userID)
            {
                tbName.ReadOnly = true;
                tbDescription.ReadOnly = true;
                tbLocalidad.ReadOnly = true;
                tbFecha.ReadOnly = true;
                tbNInscritos.ReadOnly = true;
                tbMaxParticipantes.ReadOnly = true;
                tbTipo.ReadOnly = true;
                btModify.Enabled = false;
                btDelete.Enabled = false;
            }
        }

        private void cargarComboBox()
        {
            typeEvents = eventController.cargarDatosComboBox();
            for (int i = 0; i < typeEvents.Count; i++)
            {
                comboBox1.Items.Add(typeEvents[i]);
            }
        }
    }
}
