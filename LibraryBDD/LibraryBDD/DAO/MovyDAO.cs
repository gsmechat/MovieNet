using LibraryBDD.DAOImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBDD.DAO
{
    public class MovyDAO : MovyDAOImpl
    {
        //DataModelContainerCTX DMCCTX = new DataModelContainerCTX();
        DataModelContainerCTX DMCCTX = DataModelContainerCTX.Instance;

        public List<Movy> getAllMovys()
        {
            List<Movy> movyList = new List<Movy>();

            var query = DMCCTX.ctx.Movies;
            // var query = ctx.Movies.ToList();
            DMCCTX.ctx.SaveChanges();

            movyList = (List<Movy>)query.ToList();

            return movyList;
        }

        public Movy getMovy(Movy mm)
        {
            Movy movy = new Movy();

            var query = DMCCTX.ctx.Movies.Where(m => m.Id.Equals(mm.Id)).First();
            DMCCTX.ctx.SaveChanges();

            movy = (Movy)query;

            return movy;
        }

        public void updateMovy(Movy movy)
        {
            DMCCTX.ctx.Movies.Attach(movy);
            var entry = DMCCTX.ctx.Entry(movy);

            entry.Property(e => e.Genre).IsModified = true;
            entry.Property(e => e.Summary).IsModified = true;
            entry.Property(e => e.Title).IsModified = true;
           //entry.Property(e => e.Avis).IsModified = true;

            DMCCTX.ctx.SaveChanges();
        }

        public void deleteMovy(Movy movy)
        {
            DAOFacadeSingleton DAOF = new DAOFacadeSingleton();
            if (movy.Avis.Count != 0)
            {
                foreach (Avi a in movy.Avis.ToList())
                {
                    Avi aa = DAOF.getAvi(a.Id);
                    DMCCTX.ctx.Avis.Attach(aa);
                    DMCCTX.ctx.Avis.Remove(aa);
                }
            }

            DMCCTX.ctx.Movies.Attach(movy);
            DMCCTX.ctx.Movies.Remove(movy);

            DMCCTX.ctx.SaveChanges();
        }

        public void insertMovy(Movy movy)
        {
            DMCCTX.ctx.Movies.Add(movy);

            DMCCTX.ctx.SaveChanges();
        }
    }
}
