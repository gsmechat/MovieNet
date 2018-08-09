using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBDD
{
    class Program
    {
        public DataModelContainer ctx = new DataModelContainer();

        static void Main(string[] args)
        {
            DataModelContainerCTX DMCCTX = new DataModelContainerCTX();
            //DataModelContainer ctx = new DataModelContainer();
            //ctx.Database.Connection.Close();
        }
    }
}
