using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touha.common.db
{
    public class ReturnDataParam : DataParam
    {
        #region 构造方法
        public ReturnDataParam(string paramName)
            : base(paramName, null, ParameterDirection.ReturnValue)
        {
        }

        public ReturnDataParam(string paramName, object type)
            : this(paramName)
        {
            base.Type = type.ToString();
        }

        public ReturnDataParam(string paramName, object type, int size)
            : this(paramName, type)
        {
            base.Size = size;
        }
        #endregion
    }
}
