using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class MoodController
    {
        private MoodDAO moodDao;
        private List<Mood> moods;
        public MoodController()
        {
            moodDao = new MoodDAO();
        }

        /// <summary>
        /// collects the values ​​you have received from the database in a list
        /// </summary>
        /// <returns> list Mood </returns>
        public List<String> valueMoods()
        {
            return moodDao.loadDataComboBox();
        }

        /// <summary>
        /// collects the date of the last mood record of a person from the database
        /// </summary>
        /// <param name="userID"> id user login </param>
        /// <returns> last mood date of a person </returns>
        public DateTime takeDate(int userID)
        {
            return moodDao.checkDate(userID);
        }

        /// <summary>
        /// passes a mood a dao event and returns a boolean
        /// </summary>
        /// <param name="id_user"> id user login </param>
        /// <param name="mood"> value selected user </param>
        /// <param name="fecha"> date today </param>
        /// <returns> true if inserted and false if not </returns>
        public Boolean validateInsert(int id_user, int mood, String fecha)
        {
            Mood newMood = new Mood(id_user, mood, fecha); 
            return moodDao.insertMood(newMood);
        }


        /// <summary>
        /// collects all the mood values ​​of a person
        /// </summary>
        /// <param name="id_user"> id user login</param>
        /// <returns> Mood list</returns>
        public List<Mood> loadOnePersonMood(int id_user)
        {
            moods = moodDao.loadOnePersonMood(id_user);
            return moods;
        }

    }
}
