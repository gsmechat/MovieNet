using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBDD
{
    public sealed class DAOFacadeSingleton
    {
        private static readonly DAOFacadeSingleton instance = new DAOFacadeSingleton();

        private readonly MovyMethodeDAO movies;
        private readonly AviMethodeDAO avis;
        private readonly UserMethodeDAO users;

        public DAOFacadeSingleton()
        {
            movies = new MovyMethodeDAO();
            avis = new AviMethodeDAO();
            users = new UserMethodeDAO();
        }
        
        public static DAOFacadeSingleton Instance
        {
            get
            {
                return instance;
            }
        }

        /*************** METHODE for Movies *******************/
        public List<Movy> getAllMovys()
        {
            return movies.getAllMovys();
        }

        public Movy getMovie(Movy mm)
        {
            return movies.getMovie(mm);
        }

        public Avi getAvi(int i)
        {
            return avis.getAvi(i);
        }

        public void insertMovie(Movy movie)
        {
            movies.insertMovie(movie);
        }

        public void deleteMovie(Movy movie)
        {
            movies.deleteMovy(movie);
        }

        public void updateMovie(Movy movie)
        {
            movies.updateMovy(movie);
        }
        

        /*************** METHODE for Users *******************/
        public List<User> getAllUsers()
        {
            return users.getAllUsers();
        }

        public void insertUser(User u)
        {
            users.insertUser(u);
        }

        public List<User> isUser(User u)
        {
            return users.isUser(u);
        }

        public User getUser(User u)
        {
            return users.getUser(u);
        }

        /*************** METHODE for Avis *******************/

        public List<Avi> getAllAvisforIdMovie(Movy movie)
        {
            return avis.getAllAvisforIdMovie(movie);
        }

        public void insertAvis(Avi a)
        {
            avis.insertAvis(a);
        }
    }

    class MovyMethodeDAO
    {
        DAO.MovyDAO MDAO = new DAO.MovyDAO();

        public List <Movy> getAllMovys()
        {
            List <Movy> MovyList = MDAO.getAllMovys();
            return MovyList;
        }

        public Movy getMovie(Movy mm)
        {
            Movy movie = MDAO.getMovy(mm);
            return movie;
        }

        public void updateMovy(Movy movy)
        {
            MDAO.updateMovy(movy);
        }

        public void deleteMovy(Movy movy)
        {
            MDAO.deleteMovy(movy);
        }

        public void insertMovie(Movy movy)
        {
             MDAO.insertMovy(movy);
        }
    }

    class AviMethodeDAO
    {
        DAO.AviDAO ADAO = new DAO.AviDAO();

        public List<Avi> getAllAvisforIdMovie(Movy m)
        {
            List<Avi> AviList = ADAO.getAllAvisforIdMovie(m);
            return AviList;
        }
        public List<Avi> getAllAvis()
        {
            List<Avi> AviList = ADAO.getAllAvis();
            return AviList;
        }

        public Avi getAvi(int id)
        {
            Avi avis = ADAO.getAvi(id);
            return avis;
        }

        public void updateAvi(Avi avi)
        {
            ADAO.updateAvi(avi);
        }

        public void deleteAvi(Avi avi)
        {
            ADAO.deleteAvi(avi);
        }

        public void insertAvis(Avi avi)
        {
            ADAO.insertAvi(avi);
        }
    }

    class UserMethodeDAO
    {
        DAO.UserDAO UDAO = new DAO.UserDAO();

        public List<User> isUser(User u)
        {
            List<User> userList = UDAO.isUser(u);
            return userList;
        }

        public List<User> getAllUsers()
        {
            List<User> userList = UDAO.getAllUsers();
            return userList;
        }

        public User getUser(User u)
        {
            User user = UDAO.getUser(u);
            return user;
        }

        public void updateUser(User user)
        {
            UDAO.updateUser(user);
        }

        public void deleteUser(User user)
        {
            UDAO.deleteUser(user);
        }

        public void insertUser(User user)
        {
            UDAO.insertUser(user);
        }
    }

}
