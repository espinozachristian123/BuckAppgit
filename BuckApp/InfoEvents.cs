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
    public partial class InfoEvents : Form
    {
        String name, description, localidad, fecha, type;
        int n_participantes, n_maxParticipantes, id_user, userID;
        EventDAO model_even = new EventDAO();
        List<Event> events;
        List<String> typeEvents;
        private EventController eventController;
        int comienzo,nummax;
        User user;


        public InfoEvents(User user)
        {
            InitializeComponent();
            this.user = user;
        }
        private void Registrar_event(object sender, EventArgs e)
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
            MessageBox.Show(Combotipo.Text);
            MessageBox.Show(userID.ToString());



            model_even.insertar_event(tbName.Text, tbDescription.Text, tbLocalidad.Text, fecha.ToString(), comienzo, nummax,Combotipo.Text,userID);
            tbName.Text = "";
            tbDescription.Text = "";
            tbLocalidad.Text = "";
            tbNInscritos.Text = "";
            tbMaxParticipantes.Text = "";
           
            //this.Close();
        }

        public InfoEvents(String name, String description, String localidad, String fecha, 
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

        private void ocultarCampos()
        {
            if(id_user != userID)
            {
                tbName.Enabled = false;
                tbDescription.Enabled = false;
                tbLocalidad.Enabled = false;
                tbFecha.Enabled = false;
                tbNInscritos.Enabled = false;
                tbMaxParticipantes.Enabled = false;
                tbTipo.Enabled = false;
            }
        }

        private void cargarComboBox()
        {
            typeEvents = eventController.cargarDatosComboBox();
            for (int i = 0; i < typeEvents.Count; i++)
            {
                Combotipo.Items.Add(typeEvents[i]);
            }
        }
    }
}
