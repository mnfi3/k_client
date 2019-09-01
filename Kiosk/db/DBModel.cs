using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiosk.db
{
    class DBModel
    {
        protected DB db;
        protected Dictionary<string, string> values;
        public DBModel()
        {
            this.db = new DB();
            values = new Dictionary<string, string>();
        }

    }
}
