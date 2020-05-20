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
        String name, description, city, date, type, duration, direction, time, mood;
        int id_event, n_participants, n_maxParticipants, id_user, userID, valueMood;

        String newName, newDescr, newCity, newDirection, newDate, newTime, newDuration, newType, newMood;
        int newNumMax;

        List<String> valuesMood;
        List<Categories> categories;

        EventController eventController;
        MoodController moodController;
        CategoriesController categoriesController;

        public InfoEvents(int id_event, String name, String description, String city, String direction, String date, String time,
            String duration, int n_participants, int n_maxParticipants, String type, String mood, int id_user, int userID)
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
            moodController = new MoodController();
            categoriesController = new CategoriesController();
            categories = new List<Categories>();
        }

        private void InfoEvents_Load(object sender, EventArgs e)
        {
            putDataFields();
            hideFields();
            loadComboBox();
            loadMoodComboBox();
        }

        private void putDataFields()
        {
            tbName.Text = name;
            tbDescription.Text = description;
            tbCity.Text = city;
            tbDirection.Text = direction;
            dtpDate.Value = Convert.ToDateTime(date);
            dtpTime.Text = time;
            dtpDuration.Text = duration;
            tbNEnroll.Text = Convert.ToString(n_participants);
            tbMaxParticipants.Text = Convert.ToString(n_maxParticipants);
            cbType.Text = type;
            cbMood.Text = mood;
        }

        private void putValuesMood()
        {
            switch (newMood)
            {
                case "1.-Para personas que estan muy triste":
                    valueMood = 1;
                    break;

                case "2.-Para personas que estan triste":
                    valueMood = 2;
                    break;

                case "3.-Para personas que estan normal":
                    valueMood = 3;
                    break;

                case "4.-Para personas que estan bien":
                    valueMood = 4;
                    break;

                case "5.-Para personas que estan muy bien":
                    valueMood = 5;
                    break;
            }
        }

        private void hideFields()
        {
            if (id_user != userID)
            {
                tbName.ReadOnly = true;
                tbDescription.ReadOnly = true;
                tbCity.ReadOnly = true;
                tbDirection.ReadOnly = true;
                dtpDate.Enabled = false;
                dtpTime.Enabled = false;
                dtpDuration.Enabled = false;
                tbNEnroll.ReadOnly = true;
                tbMaxParticipants.ReadOnly = true;
                cbType.Enabled = false;
                cbMood.Enabled = false;
                btModify.Enabled = false;
                btDelete.Enabled = false;
            }
        }

        private void loadComboBox()
        {
            categories = categoriesController.loadDataComboBox();
            for (int i = 0; i < categories.Count; i++)
            {
                cbType.Items.Add(categories[i].Name);
            }
        }

        private void loadMoodComboBox()
        {
            valuesMood = moodController.valueMoods();
            for (int i = 0; i < valuesMood.Count; i++)
            {
                cbMood.Items.Add(valuesMood[i]);
            }
        }

        private void registerEvent(object sender, EventArgs e)
        {
            Boolean a = eventController.checkRegister(id_event, userID);
            DateTime dateFinal = Convert.ToDateTime(date + " " + time);
            DateTime dateActual = Convert.ToDateTime(DateTime.Now.ToString());
            if (a == false)
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
                            MessageBox.Show("Actividad completa o fuera de termino!!");
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
                    if (d == true)
                    {
                        n_participants--;
                        Boolean f = eventController.updateNumMax(n_participants, id_event);
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

        private void takeNewData()
        {
            newName = tbName.Text;
            newDescr = tbDescription.Text;
            newCity = tbCity.Text;
            newDirection = tbDirection.Text;
            newDate = dtpDate.Value.ToShortDateString();
            newTime = dtpTime.Value.ToShortTimeString();
            newDuration = dtpDuration.Value.ToShortTimeString();
            newNumMax = Convert.ToInt32(tbMaxParticipants.Text);
            newType = cbType.Text;
            newMood = cbMood.Text;
            putValuesMood();
        }

        private void modifyEvent(object sender, EventArgs e)
        {
            takeNewData();
            DateTime dateToday = DateTime.Today;
            String dateFinal = newDate + " " + newTime;
            var result = MessageBox.Show("Estas seguro que quieres modificar el evento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                if(Convert.ToDateTime(newDate) > dateToday)
                {
                    Boolean b = eventController.modifyEvent(newName, newDescr, newCity, newDirection, dateFinal, newDuration, newNumMax, newType, valueMood, id_event);
                    if (b == true)
                    {
                        MessageBox.Show("Evento modificado correctamente !!");
                    }
                    else
                    {
                        MessageBox.Show("EL evento no se ha podido modificar !!");
                    }
                }
                else
                {
                    MessageBox.Show("No puedes poner una fecha anterior a la de hoy!!");
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
