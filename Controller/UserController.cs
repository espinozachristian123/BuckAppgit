using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class UserController
    {
        private UserDAO model;
        private User user;

        public UserController()
        {
            model = new UserDAO();
        }

        /// <summary>
        /// Get the values username and password and then validate if the user exist or not.
        /// if user exist create a new user with the values are geting in database,
        /// else user is null.
        /// </summary>
        /// <param name="username"> value fields name </param>
        /// <param name="password">value fields pass </param>
        /// <returns>user</returns>
        public User validateUser(String username, String password)
        {
            User userValidate = new User(username,password);
            Boolean flag = model.loginUser(userValidate);
            if (flag)
            {
                user = new User(model.Id, username, password, model.Rol, model.Email);
            }
            else
            {
                user = null;
            }

            return user;
        }

        /// <summary>
        /// get the values of register window and pass to database
        /// </summary>
        /// <param name="username"> value fields name</param>
        /// <param name="password"> value fields pass</param>
        /// <param name="email"> value fields email</param>
        /// <returns> if flag is true the user are registred else  is false the user are registered </returns>
        public Boolean validateRegister(String username, String password, String email)
        {
            Boolean flag = model.register(username,password,email);
            return flag;
        }

        /// <summary>
        ///  get the new values of profile window and pass to database
        /// </summary>
        /// <param name="newName"> new value name </param>
        /// <param name="newPass"> new value pass</param>
        /// <param name="newEmail"> new value email</param>
        /// <param name="id_user"> id user login</param>
        /// <returns> if true the user are modify else not modify </returns>
        public bool modifyUser(string newName, string newPass, string newEmail, int id_user)
        {
            return model.modifyUser(newName, newPass, newEmail,id_user);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newName"> new value name </param>
        /// <returns></returns>
        public bool sameName(string newName)
        {
            return model.UserEquals(newName);
        }

        public Boolean sameEmail(String email)
        {
            return model.takeUser(email);
        }

        public bool modifyNames(string newName, int id_user)
        {
            return model.modifyName(newName, id_user);
        }

        public bool modifyEmail(string newEmail, int id)
        {
            return model.modifyEmail(newEmail, id);
        }

        public bool modifyPass(string newPass, int id)
        {
            return model.modifyPassword(newPass, id);
        }

        public User User { get => user; set => user = value; }

    }
}
