using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBDD.DAOImpl
{
    interface AviDAOImpl
    {
        List<Avi> getAllAvis();
        Avi getAvi(int id);
        void updateAvi(Avi avi);
        void deleteAvi(Avi avi);
        void insertAvi(Avi avi);
    }
}
