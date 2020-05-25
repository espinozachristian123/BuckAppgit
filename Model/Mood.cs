using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Mood
    {
        int id_user;
        private int mood;
        private string date;

        public Mood()
        {
            
        }

        public Mood(int id_user, int mood, string date)
        {
            this.id_user = id_user;
            this.mood = mood;
            this.date = date;
        }
        
        public int Id_user { get => id_user; set => id_user = value; }
        public int Mod { get => mood; set => mood = value; }
        public string Date { get => date; set => date = value; }
    }
}
