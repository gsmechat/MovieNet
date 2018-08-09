using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBDD.DAOImpl
{
    interface MovyDAOImpl
    {
        List<Movy> getAllMovys();
        Movy getMovy(Movy movy);
        void updateMovy(Movy movy);
        void deleteMovy(Movy movy);
        void insertMovy(Movy movy);
    }
}
