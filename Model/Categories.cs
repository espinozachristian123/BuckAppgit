using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Categories
    {
        private int id;
        private String name;

        public Categories()
        {
            
        }

        public Categories(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public Categories( string name)
        {
            this.name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}
