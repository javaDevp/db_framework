using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touha.common.db
{
    public class DBSqlData : DBBase
    {
        public DBSqlData()
        {
            base._DbConnection = new SqlConnection();
        }
    }
}
