using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touha.common.db
{
    public class DBLink
    {
        #region 字段
        private string _ConnectString;

        private string _DBLinkName;

        private string _DBName;

        private string _Password;
        #endregion

        public DBLink(string link_name, string db_name, string connect_string, string password)
        {
            this._DBLinkName = link_name;
            this._DBName = db_name;
            this._ConnectString = connect_string;
            this._Password = password;
        }

        #region 属性
        public string DBLinkName
        {
            get { return this._DBLinkName; }
        }

        public string DBName
        {
            get { return this._DBName; }
        }

        public string ConnectString
        {
            get { return this._ConnectString; }
        }

        public string Password
        {
            get { return this._Password; }
        }
        #endregion
    }
}
