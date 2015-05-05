using KingT.Common.Base;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touha.common.db
{
    public static class DBBaseHelper
    {
        private static List<DBLink> _DatabaseList = new List<DBLink>();

        public static DBLink CreateDBLink(string conn_name)
        {
            string name = conn_name + "DBPassWord";
            string str2 = conn_name + "DataSource";
            string str3 = conn_name + "DataBase";
            string source = ConfigurationManager.AppSettings.Get(name);
            string key = ConfigurationManager.AppSettings.Get("UserSerial").Reversal();
            string password = DataCrypto.Decrypting(source, key);
            string connectstring = ConfigurationManager.AppSettings.Get(str2);
            string str8 = ConfigurationManager.AppSettings.Get(str3);
            if (str8 == null)
            {
                str8 = "ORACLE";
            }
            return new DBLink(conn_name, str8, connectstring, password);
        }

        public static DBBase GetDBBase()
        {
            return GetDBBase("");
        }

        public static DBBase GetDBBase(string conn_name)
        {
            DBLink link = _DatabaseList.Find(o => o.DBLinkName == conn_name);
            if (link == null)
            {
                lock (_DatabaseList)
                {
                    link = CreateDBLink(conn_name);
                    _DatabaseList.Add(link);
                }
            }
            string connectString = link.ConnectString + ";Password=" + link.Password;
            string dbName = link.DBName;
            if (dbName == null)
            {
                dbName = "ORACLE";
            }
            DBType dbType = DBType.Oracle;
            if (dbName != null && dbName == "SQL SERVER")
            {
                dbType = DBType.SqlServer;
            }
            else
            {
                dbType = DBType.Oracle;
            }
            return GetDBBase(dbType, connectString);
        }

        public static DBBase GetDBBase(DBType dbType, string connectString)
        {
            DBBase db;
            if (dbType == DBType.SqlServer)
            {
                db = new DBSqlData();
            }
            else
            {
                db = new DBOracleData();
            }
            db.SetConnectString(connectString);
            return db;
        }
    }
}
