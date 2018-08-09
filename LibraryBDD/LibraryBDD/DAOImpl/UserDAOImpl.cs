using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBDD.DAOImpl
{
    interface UserDAOImpl
    {
        List<User> getAllUsers();
        User getUser(User user);
        void updateUser(User user);
        void deleteUser(User user);
        void insertUser(User user);
    }
}
