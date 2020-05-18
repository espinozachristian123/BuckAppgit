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

        public MoodController()
        {
            moodDao = new MoodDAO();
        }

        public Boolean validateInsert(int id_user, int mood, String fecha)
        {
            return moodDao.insertMood(id_user, mood, fecha);
        }
    }
}
