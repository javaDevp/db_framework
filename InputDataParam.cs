using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touha.common.db
{
    public class InputDataParam : DataParam
    {
        #region 构造方法
        public InputDataParam(string paramName, object paramValue)
            : base(paramName, paramValue, ParameterDirection.Input)
        {
        }

        public InputDataParam(string paramName, object paramValue, object type)
            : this(paramName, paramValue)
        {
            base.Type = type.ToString();
        }

        public InputDataParam(string paramName, object paramValue, object type, int size)
            : this(paramName, paramValue, type)
        {
            base.Size = size;
        }
        #endregion
    }
}
