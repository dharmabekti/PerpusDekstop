using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace PerpusDekstop.DAO
{
    class DBConnection
    {
        public string ConnectionString()
        {
            string ConnectionString = @"Server = RAAVA\RAAVA;
                Database = DBPERPUS; 
                integrated security = true";

            return ConnectionString;
        }
    }
}


