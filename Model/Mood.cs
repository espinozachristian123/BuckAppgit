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
        int moods;
        String fecha;
        private int mood;
        private string date;

        public Mood(int id_user, int mood, string date)
        {
            this.id_user = id_user;
            this.mood = mood;
            this.date = date;
        }

        public Mood(int id_user, int mood, string fecha, int id_user1)
        {
            this.id_user = id_user;
            this.moods = mood;
            this.fecha = fecha;
        }

        public int Id_user { get => id_user; set => id_user = value; }
        public int Moods { get => moods; set => moods = value; }
        public string Fecha { get => fecha; set => fecha = value; }
    }
}
