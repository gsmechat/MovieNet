using LibraryBDD.DAOImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBDD.DAO
{
    public class UserDAO : UserDAOImpl
    {
        //DataModelContainerCTX DMCCTX = new DataModelContainerCTX();
        DataModelContainerCTX DMCCTX = DataModelContainerCTX.Instance;

        public List<User> getAllUsers()
        {
            List<User> userList = new List<User>();

            var query = DMCCTX.ctx.Users;
            DMCCTX.ctx.SaveChanges();

            userList = (List<User>)query.ToList();

            return userList;
        }

        public List<User> isUser(User uu)
        {
            List<User> userList = new List<User>();

            var query = DMCCTX.ctx.Users.Where(u => u.Login.Equals(uu.Login)).Where(u => u.Password.Equals(uu.Password));
            DMCCTX.ctx.SaveChanges();

            userList = (List<User>)query.ToList();

            return userList;
        }

        public User getUser(User uu)
        {
            User user = new User();

            var query = DMCCTX.ctx.Users.Where(u => u.Id.Equals(uu.Id)).First();
            DMCCTX.ctx.SaveChanges();

            user = (User)query;

            return user;
        }

        public void updateUser(User user)
        {
            DMCCTX.ctx.Users.Attach(user);
            var entry = DMCCTX.ctx.Entry(user);

            entry.Property(e => e.Avis).IsModified = true;
            entry.Property(e => e.Login).IsModified = true;
            entry.Property(e => e.Password).IsModified = true;
            entry.Property(e => e.Avis).IsModified = true;

            DMCCTX.ctx.SaveChanges();
        }

        public void deleteUser(User user)
        {
            DMCCTX.ctx.Users.Attach(user);
            DMCCTX.ctx.Users.Remove(user);

            DMCCTX.ctx.SaveChanges();
        }

        public void insertUser(User user)
        {
            DMCCTX.ctx.Users.Add(user);

            DMCCTX.ctx.SaveChanges();
        }
    }
}
