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
        private int userID, nPart, newMaxPart, valueMood;
        private String newName, newDescription, newCity, newDirection, newDate, newTime, newDuration, newCategory, newMood;
        private DateTime dateToday, dateEvent;

        private List<String> valueMoods;
        private List<Categories> categories;
        
        private EventController eventController;
        private MoodController moodController;
        private CategoriesController categoriesController;

        User user;
        
        public AddEvents(User user)
        {
            InitializeComponent();
            eventController = new EventController();
            moodController = new MoodController();
            categoriesController = new CategoriesController();
            categories = new List<Categories>();
            loadComboBox();
            loadMoodComboBox();
            this.user = user;
        }
        /// <summary>
        /// We load the categories we have per database and enter it in our combobox
        /// </summary>
        private void loadComboBox()
        {
            categories = categoriesController.loadDataComboBox();
            for (int i = 0; i < categories.Count; i++)
            {
                CbType.Items.Add(categories[i].Name);
            }
        }
        /// <summary>
        /// We load the mood values ​​that we have per database and enter it in our combobox
        /// </summary>
        private void loadMoodComboBox()
        {
            valueMoods = moodController.valueMoods();
            for (int i = 0; i < valueMoods.Count; i++)
            {
                cbMood.Items.Add(valueMoods[i]);
            }
        }
        /// <summary>
        /// We control the maxParticipants field so that the keyboard cannot be used to enter a non-numeric character
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtMaxParticipantes_KeyPress(object sender, KeyPressEventArgs e)
        {
            eventController.validateNumbers(e);
        }
        /// <summary>
        ///Check that the fields are not empty
        ///Check that the number of participants has not been exceeded by more than 100
        ///We check that the date entered is greater than or equal to today's date
        ///If this condition is met add the event
        ///If this condition is not met, inform the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveEvent(object sender, EventArgs e)
        {
            try
            {
                loadData();
                dateToday = DateTime.Today;
                String dateFinal = newDate + " " + newTime;
                if (newName.Length == 0 || newDescription.Length == 0 || newCity.Length == 0 ||
                    newDirection.Length == 0|| newDate.Length == 0 || newTime.Length == 0 || newDuration.Length == 0 || 
                    txtMaxParticipants.Text.Length == 0||newCategory.Length == 0 || newMood.Length == 0 )
                {
                    MessageBox.Show("Los Campos no pueden estar vacios!");
                }
                else if (newMaxPart > 100)
                {
                    MessageBox.Show("Numero de participantes maximos superado (Maximo 100 Participantes)");
                    txtMaxParticipants.Text = "";
                }
                else
                {
                    dateEvent = Convert.ToDateTime(dateFinal);
                    if (dateEvent >= dateToday)
                    {
                        eventController.addEvent(newName, newDescription, newCity, newDirection, dateFinal, newDuration, nPart, newMaxPart, newCategory, valueMood, userID);
                        MessageBox.Show("El evento se ha añadido correctamente!");
                        cleanFields();
                        Close();
                    }
                    else
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

        private void loadData()
        {
            newName = txtName.Text;
            newDescription = txtDescription.Text;
            newCity = txtLocation.Text;
            newDirection = txtDirection.Text;
            newDate = dtpDate.Value.ToShortDateString();
            newTime = dtpTime.Value.ToShortTimeString();
            newDuration = dtpDuration.Value.ToShortTimeString();
            nPart = 0;
            newMaxPart = Convert.ToInt32(txtMaxParticipants.Text);
            newCategory = CbType.Text;
            newMood = cbMood.Text;
            userID = this.user.Id;
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
        /// <summary>
        /// Clean our fields
        /// </summary>
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
