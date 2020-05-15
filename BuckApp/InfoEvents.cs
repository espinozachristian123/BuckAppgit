using Controller;
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
        int  id_event, n_participantes, n_maxParticipantes, id_user, userID;

        List<String> typeEvents;
        
        EventController eventController;
        
        public InfoEvents(int id_event,String name, String description, String localidad, String fecha, 
            int n_participantes, int n_maxParticipantes, String type, int id_user, int userID)
        {
            InitializeComponent();
            this.id_event = id_event;
            this.name = name;
            this.description = description;
            this.localidad = localidad;
            this.fecha = fecha;
            this.n_participantes = n_participantes;
            this.n_maxParticipantes = n_maxParticipantes;
            this.type = type;
            this.id_user = id_user;
            this.userID = userID;
            eventController = new EventController();
            cargarComboBox();
        }

        private void InfoEvents_Load(object sender, EventArgs e)
        {
            ponerDatosTextBox();
            ocultarCampos();
        }

        private void ponerDatosTextBox()
        {
            tbName.Text = name;
            tbDescription.Text = description;
            tbLocalidad.Text = localidad;
            dtpFecha.Value = Convert.ToDateTime(fecha);
            tbNInscritos.Text = Convert.ToString(n_participantes);
            tbMaxParticipantes.Text = Convert.ToString(n_maxParticipantes);
            cbTipo.Text = type;
        }

        private void ocultarCampos()
        {
            if (id_user != userID)
            {
                tbName.ReadOnly = true;
                tbDescription.ReadOnly = true;
                tbLocalidad.ReadOnly = true;
                dtpFecha.Enabled = false;
                tbNInscritos.ReadOnly = true;
                tbMaxParticipantes.ReadOnly = true;
                cbTipo.Enabled = false;
                btModify.Enabled = false;
                btDelete.Enabled = false;
            }
        }

        private void cargarComboBox()
        {
            typeEvents = eventController.cargarDatosComboBox();
            for (int i = 0; i < typeEvents.Count; i++)
            {
                cbTipo.Items.Add(typeEvents[i]);
            }
        }

        private void registerEvent(object sender, EventArgs e)
        {
            Boolean a = eventController.checkRegister(id_event, id_user);
            if(a == false)
            {
                if (n_participantes < n_maxParticipantes)
                {
                    Boolean b = eventController.registerEvent(fecha, id_event, id_user);
                    if (b == true)
                    {
                        n_participantes++;
                        Boolean c = eventController.updateNumMax(n_participantes, id_event);
                        if (c == true)
                        {
                            MessageBox.Show("Usuario registrado en el evento!");
                        }
                        else
                        {
                            MessageBox.Show("Actividad completa!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El usuario no ha podido registrarse. Actividad completa!");
                }
            }
            else
            {
                MessageBox.Show("El usuario ya esta registrado en este evento!");
            }
            
        }

        private void modifyEvent(object sender, EventArgs e)
        {
            String newName = tbName.Text;
            String newDescr = tbDescription.Text;
            String newLocation = tbLocalidad.Text;
            DateTime newDate = dtpFecha.Value;
            int newNum_max = Convert.ToInt16(tbMaxParticipantes.Text);
            String newType = cbTipo.SelectedItem.ToString();
            var result = MessageBox.Show("Estas seguro que quieres modificar el evento?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if(result == DialogResult.Yes)
            {
                Boolean b = eventController.modifyEvent(newName, newDescr, newLocation, newDate, newNum_max, newType, id_event);
                if (b == true)
                {
                    MessageBox.Show("Evento modificado correctamente !!");
                }
                else
                {
                    MessageBox.Show("EL evento no se ha podido modificar !!");
                }
            }
        }

        private void deleteEventClick(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Estas seguro que quieres borrar el evento?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            if (result == DialogResult.Yes)
            {
                Boolean b = eventController.deleteEvent(id_event);
                if (b == true)
                {
                    MessageBox.Show("Evento borrado correctamente !!");
                }
                else
                {
                    MessageBox.Show("EL evento no se ha podido borrar !!");
                }
            }
        }
    }
}
