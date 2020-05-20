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

        public List <Categories> loadDataComboBox()
        {
            return categoryDAO.loadDataComboBox();
        }
    }
}
