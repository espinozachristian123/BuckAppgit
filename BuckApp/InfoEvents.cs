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
        int id_event, n_participants, n_maxParticipants, id_user, valueMood;

        String newName, newDescr, newCity, newDirection, newDate, newTime, newDuration, newType, newMood;
        String newCompleteDirection;
        
        int newNumMax;

        List<String> valuesMood;
        List<Categories> categories;

        EventController eventController;
        MoodController moodController;
        CategoriesController categoriesController;

        TakeUbication ubication;

        User user;

        public InfoEvents(int id_event, String name, String description, String city, String direction, String date, String time,
            String duration, int n_participants, int n_maxParticipants, String type, String mood, int id_user, User user)
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
            this.user = user;
            eventController = new EventController();
            moodController = new MoodController();
            categoriesController = new CategoriesController();
            categories = new List<Categories>();
        }

        /// <summary>
        /// Load of methods to run this window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void InfoEvents_Load(object sender, EventArgs e)
        {
            putDataFields();
            hideFields();
            loadComboBox();
            loadMoodComboBox();
        }

        /// <summary>
        ///  Get the values of the selected event and set in the fields of this window.
        /// </summary>
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

        /// <summary>
        /// Hide the fields depend on user and admin.
        /// if the user has not created the event, they can only register
        /// if the user is a Admin he only can show the event and the delete if the event are incorrectly.
        /// </summary>
        private void hideFields()
        {
            if (user.Rol.Equals("admin"))
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
                btRegisterEvent.Enabled = false;
                btnAddUbication.Enabled = false;
                btModify.Enabled = false;
                btDelete.Enabled = true;
            }
            else if ((id_user != user.Id) && (user.Rol.Equals("user")))
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
                btnAddUbication.Enabled = false;
                btModify.Enabled = false;
                btDelete.Enabled = false;
            }
        }
        /// <summary>
        /// Get the values of data base and load the combobox whith the that values.
        /// </summary>
        private void loadComboBox()
        {
            categories = categoriesController.loadDataComboBox();
            for (int i = 0; i < categories.Count; i++)
            {
                cbType.Items.Add(categories[i].Name);
            }
        }

        /// <summary>
        /// Get the values of data base and load the combobox whith the that values.
        /// </summary>
        private void loadMoodComboBox()
        {
            valuesMood = moodController.valueMoods();
            for (int i = 0; i < valuesMood.Count; i++)
            {
                cbMood.Items.Add(valuesMood[i]);
            }
        }

        /// <summary>
        /// Check if the user are registered or not.
        /// If the user aren't registered check two items,
        ///     the first if the num_participantes are smaller than num_max_participants,
        ///     the second  if today's date is not higher than the event.
        ///     if this condition is fullfiled, the user register in the event
        ///     and update the num of participants in the event.
        ///If the user are registered, the program notify the user of registered, and show the option if the user want to delete of event. 
        ///     if the user click "YES" delete the register and update the  num of participants of event.
        ///     in case of any error, the program will show a message of error in the screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void registerEvent(object sender, EventArgs e)
        {
            Boolean a = eventController.checkRegister(id_event, user.Id);
            DateTime dateFinal = Convert.ToDateTime(date + " " + time);
            DateTime dateActual = Convert.ToDateTime(DateTime.Now.ToString());
            if (a == false)
            {
                if ((n_participants < n_maxParticipants) && (dateFinal >= dateActual))
                {
                    Boolean b = eventController.registerEvent(dateFinal, id_event, user.Id);
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
                    Boolean d = eventController.deleteRegisterEvent(id_event, user.Id);
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
        /// <summary>
        /// Ask the user if he want modify the event,
        /// if the user Click "YES" the program,check all params if are correctly
        /// and then modify the event
        /// in case of error the program show a message of error in the screen.
        /// if the user Click "No", the program not modify the event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                    if (newName.Length == 0 || newDescr.Length == 0 || newCity.Length == 0 ||
                    newDirection.Length == 0 || newDate.Length == 0 || newTime.Length == 0 || newDuration.Length == 0 ||
                    newNumMax == 0 || newType.Length == 0 || newMood.Length == 0)
                    {
                        MessageBox.Show("Los Campos no pueden estar vacios!");
                    } else if (newNumMax > 100)
                    {
                        MessageBox.Show("Numero de participantes maximos superado (Maximo 100 Participantes)");

                    }
                    else
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
                    
                }
                else
                {
                    MessageBox.Show("No puedes poner una fecha anterior a la de hoy!!");
                }
            }
        }
        /// <summary>
        /// We control the maxParticipants field so that the keyboard cannot be used to enter a non-numeric character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbMaxParticipants_KeyPress(object sender, KeyPressEventArgs e)
        {
            eventController.validateNumbers(e);
        }

        /// <summary>
        /// take the new values of fields and save in a variable.
        /// </summary>
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

        /// <summary>
        /// Take the value of the mood from the option chosen by the user
        /// </summary>
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

        /// <summary>
        /// ask the user if he want delete the event,
        /// if user click "Yes" the program delete the event,
        /// in case of error, the program show a message of error in the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// When the user presses the Add location button, the window changes to that of google maps
        //  when you close the window you get the value of the location
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addUbication_Click(object sender, EventArgs e)
        {
            TakeUbication ubication = new TakeUbication();
            ubication.ShowDialog();
            newCompleteDirection = ubication.Direccion_Definitiva;
            takeUbication();
        }

        /// <summary>
        /// Get the value of the google maps location and put them in the corresponding fields
        /// </summary>
        private void takeUbication()
        {
            String[] info = newCompleteDirection.Split(',');
            switch (info.Length)
            {
                case 1:
                    MessageBox.Show("No se ha encontrado la ciudad!! Escribalo manualmente");
                    tbCity.Text = String.Empty;
                    tbDirection.Text = info[0];
                    break;
                case 2:
                    tbCity.Text = info[1];
                    tbDirection.Text = info[0];
                    break;
                case 3:
                    if(info[2].Any(c => char.IsDigit(c)) == true)
                    {
                        tbCity.Text = info[2];
                        tbDirection.Text = info[0] + "," + info[1];
                    }
                    else
                    {
                        tbCity.Text = info[1];
                        tbDirection.Text = info[0];
                    }
                    break;
                case 4:
                    tbCity.Text = info[2];
                    tbDirection.Text = info[0] + "," + info[1];
                    break;
            }
        }
    }
}
