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

        public List<String> valueMoods()
        {
            return moodDao.loadDataComboBox();
        }

        public Boolean validateInsert(int id_user, int mood, String fecha)
        {
            Mood newMood = new Mood(id_user, mood, fecha); 
            return moodDao.insertMood(newMood);
        }

        public List<Mood> loadDatamoods()
        {
            moods = moodDao.loadData();
            return moods;
        }

        public List<Mood> loadOnePersonMood(int id_user)
        {
            moods = moodDao.loadOnePersonMood(id_user);
            return moods;
        }

    }
}
