using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class CategoriesController
    {
        private CategoryDAO categoryDAO;

        public CategoriesController()
        {
            categoryDAO = new CategoryDAO();
        }

        /// <summary>
        /// collects the values ​​you have received from the database in a list
        /// </summary>
        /// <returns> list of categories </returns>
        public List <Categories> loadDataComboBox()
        {
            return categoryDAO.loadDataComboBox();
        }
    }
}
