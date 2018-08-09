using LibraryBDD.DAOImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBDD.DAO
{
    public class AviDAO : AviDAOImpl
    {
        DataModelContainerCTX DMCCTX = DataModelContainerCTX.Instance;

        public List<Avi> getAllAvisforIdMovie(Movy movi)
        {
            List<Avi> avis = new List<Avi>();
            if (movi != null)
            {
                var query = DMCCTX.ctx.Avis.Where(m => m.Movies_Id.Equals(movi.Id));

                DMCCTX.ctx.SaveChanges();

                avis = (List<Avi>)query.ToList();
            }
            return avis;
        }

        public List<Avi> getAllAvis()
        {
            List<Avi> avisList = new List<Avi>();

            var query = DMCCTX.ctx.Avis.ToList();
            DMCCTX.ctx.SaveChanges();

            avisList = (List<Avi>)query.ToList();

            return avisList;
        }

        public Avi getAvi(int id)
        {
            Avi avis = new Avi();

            var query = DMCCTX.ctx.Avis.Where(a => a.Id.Equals(id)).First();
            DMCCTX.ctx.SaveChanges();

            avis = (Avi)query;

            return avis;
        }

        public void updateAvi(Avi avis)
        {
            DMCCTX.ctx.Avis.Attach(avis);
            var entry = DMCCTX.ctx.Entry(avis);

            entry.Property(e => e.Commentaire).IsModified = true;
            entry.Property(e => e.Movy).IsModified = true;
            entry.Property(e => e.Note).IsModified = true;
            entry.Property(e => e.User).IsModified = true;

            DMCCTX.ctx.SaveChanges();
        }

        public void deleteAvi(Avi avis)
        {
            DMCCTX.ctx.Avis.Attach(avis);
            DMCCTX.ctx.Avis.Remove(avis);

            DMCCTX.ctx.SaveChanges();
        }

        public void insertAvi(Avi avis)
        {
            DMCCTX.ctx.Avis.Add(avis);

            DMCCTX.ctx.SaveChanges();
        }
    }
}
