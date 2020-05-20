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
    public partial class AddEvents : Form
    {
        int userID;
        List<String> typeEvents, valueMoods;
        private EventController eventController;
        private MoodController moodController;
        User user;
        String newName, newDescription, newCity, newDirection, newDate,newTime, newDuration, newCategory, newMood;
        int nPart,newMaxPart, valueMood;
        DateTime datehoy,datepasar;
        public AddEvents(User user)
        {
            InitializeComponent();
            eventController = new EventController();
            moodController = new MoodController();
            loadComboBox();
            loadMoodComboBox();
            this.user = user;
        }

        private void loadComboBox()
        {
            typeEvents = eventController.loadDataComboBox();
            for (int i = 0; i < typeEvents.Count; i++)
            {
                CbType.Items.Add(typeEvents[i]);
            }
        }

        private void loadMoodComboBox()
        {
            valueMoods = moodController.valueMoods();
            for (int i = 0; i < valueMoods.Count; i++)
            {
                cbMood.Items.Add(valueMoods[i]);
            }
        }
        
        private void txtMaxParticipantes_KeyPress(object sender, KeyPressEventArgs e)
        {
            eventController.validateNumbers(e);
        }

        private void loadData()
        {
            newName = txtName.Text;
            newDescription = txtDescription.Text;
            newCity = txtLocation.Text;
            newDirection = txtDirection.Text;
            newDate = dtpDate.Value.ToShortDateString();
            newTime = dtpTime.Value.ToShortTimeString();
            newDuration = dtpDate.Value.ToShortTimeString();
            nPart = 0;
            newMaxPart = Convert.ToInt32(txtMaxParticipants.Text);
            newCategory = CbType.Text;
            newMood = cbMood.Text;
            putValuesMood();
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

        private void saveEvent(object sender, EventArgs e)
        {
            try
            {
                datehoy = DateTime.Today;
                loadData();
                String dateFinal = newDate + " " + newTime;
                userID = this.user.Id;
                if (txtName.Text.Length == 0 || txtDescription.Text.Length == 0 || txtLocation.Text.Length == 0 ||
                    txtDirection.Text.Length == 0|| newDate.Length == 0 || newTime.Length == 0 || newDuration.Length == 0 || 
                    txtMaxParticipants.Text.Length == 0||newCategory.Length == 0 || newMood.Length == 0 )
                {
                    MessageBox.Show("Los Campos no pueden estar vacios!");
                }
                else if (newMaxPart > 100)
                {
                    MessageBox.Show("Numero de participantes maximos superado");
                    txtMaxParticipants.Text = "";
                }
                else
                {
                    datepasar = Convert.ToDateTime(dateFinal);
                    if (datepasar>= datehoy)
                    {
                        eventController.addEvent(newName, newDescription, newCity, newDirection, dateFinal, newDuration, nPart, newMaxPart, newCategory, valueMood, userID);
                        MessageBox.Show("El evento se ha añadido correctamente!");
                        cleanFields();
                    }else
                    {
                        MessageBox.Show("Has puesto una fecha anterior a la de hoy!");
                    }

                    
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Campos vacios o Formato no correcto");
            }
        }

        public void cleanFields()
        {
            txtName.Text = String.Empty;
            txtDescription.Text = String.Empty;
            txtLocation.Text = String.Empty;
            txtDirection.Text = String.Empty;
            txtMaxParticipants.Text = String.Empty;
            
        }
    }
}
