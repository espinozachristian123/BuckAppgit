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
        String name, description, city, date, type, duration,direction,time;
        int  id_event, n_participants, n_maxParticipants, id_user, userID, mood;

        List<String> typeEvents;
        
        EventController eventController;

        public InfoEvents(int id_event, String name, String description, String city, String direction, String date,String time,
            String duration, int n_participants, int n_maxParticipants, String type, int mood, int id_user, int userID)
        {
            InitializeComponent();
            this.id_event = id_event;
            this.name = name;
            this.description = description;
            this.city = city;
            this.direction = direction;
            this.date = date;
            this.time = time;
            this.duration = duration;
            this.n_participants = n_participants;
            this.n_maxParticipants = n_maxParticipants;
            this.type = type;
            this.mood = mood;
            this.id_user = id_user;
            this.userID = userID;
            eventController = new EventController();
            loadComboBox();
        }

        private void InfoEvents_Load(object sender, EventArgs e)
        {
            putDataTextBox();
            hideFields();
        }

        private void putDataTextBox()
        {
            tbName.Text = name;
            tbDescription.Text = description;
            tbCity.Text = city;
            tbDirection.Text = direction;
            dtpDate.Value = Convert.ToDateTime(date);
            tbTime.Text = time;
            tbDuration.Text = duration;
            tbNEnroll.Text = Convert.ToString(n_participants);
            tbMaxParticipants.Text = Convert.ToString(n_maxParticipants);
            cbType.Text = type;
            tbMood.Text = Convert.ToString(mood);
        }

        private void hideFields()
        {
            if (id_user != userID)
            {
                tbName.ReadOnly = true;
                tbDescription.ReadOnly = true;
                tbCity.ReadOnly = true;
                dtpDate.Enabled = false;
                tbNEnroll.ReadOnly = true;
                tbMaxParticipants.ReadOnly = true;
                cbType.Enabled = false;
                btModify.Enabled = false;
                btDelete.Enabled = false;
            }
        }

        private void loadComboBox()
        {
            typeEvents = eventController.loadDataComboBox();
            for (int i = 0; i < typeEvents.Count; i++)
            {
                cbType.Items.Add(typeEvents[i]);
            }
        }

        private void registerEvent(object sender, EventArgs e)
        {
            Boolean a = eventController.checkRegister(id_event, userID);
            DateTime dateFinal = Convert.ToDateTime(date + " " + time);
            DateTime dateActual = Convert.ToDateTime(DateTime.Now.ToString());
            if(a == false)
            {
                if ((n_participants < n_maxParticipants) && (dateFinal >= dateActual))
                {
                    Boolean b = eventController.registerEvent(dateFinal, id_event, userID);
                    if (b == true)
                    {
                        n_participants++;
                        Boolean c = eventController.updateNumMax(n_participants, id_event);
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
                var result = MessageBox.Show("El usuario ya esta registrado en este evento! Quieres eliminarte del evento?", "Borrarte de la actividad", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Boolean d = eventController.deleteRegisterEvent(id_event, userID);
                    if(d == true)
                    {
                        n_participants--;
                        Boolean f = eventController.updateNumMax(n_participants,id_event);
                        if (f == true)
                        {
                            MessageBox.Show("Usuario borrado del evento!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error!! El usuario no se ha podido borrar del evento");
                    }
                }
            }
            
        }

        private void modifyEvent(object sender, EventArgs e)
        {
            String newName = tbName.Text;
            String newDescr = tbDescription.Text;
            String newLocation = tbCity.Text;
            DateTime newDate = dtpDate.Value;
            int newNum_max = Convert.ToInt16(tbMaxParticipants.Text);
            String newType = cbType.SelectedItem.ToString();
            var result = MessageBox.Show("Estas seguro que quieres modificar el evento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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
            var result = MessageBox.Show("Estas seguro que quieres borrar el evento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Boolean b = eventController.deleteEvent(id_event);
                if (b == true)
                {
                    MessageBox.Show("Evento borrado correctamente !!");
                    Close();
                }
                else
                {
                    MessageBox.Show("EL evento no se ha podido borrar !!");
                }
            }
        }
    }
}
