using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryBDD
{
    public sealed class DataModelContainerCTX
    {
        private static readonly DataModelContainerCTX instance = new DataModelContainerCTX();

        public static DataModelContainerCTX Instance
        {
            get
            {
                return instance;
            }
        }

        public DataModelContainer ctx;

        public DataModelContainerCTX()
        {
            ctx = new DataModelContainer();
        }
    }
}