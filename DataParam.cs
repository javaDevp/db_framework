using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touha.common.db
{
    public abstract class DataParam
    {
        #region 字段
        public ParameterDirection Direction;

        public string Name;

        public int Size;

        public string Type;

        public object Value;
        #endregion

        #region 构造函数
        public DataParam()
        {
            this.Type = null;
            this.Value = null;
        }

        public DataParam(string paramName, ParameterDirection paramDirection):this()
        {
            this.Name = paramName;
            this.Direction = paramDirection;
        }

        public DataParam(string paramName, object paramValue, ParameterDirection paramDirection)
            : this(paramName, paramDirection)
        {
            this.Value = paramValue;
        }
        #endregion
    }
}
