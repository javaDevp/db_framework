using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touha.common.db
{
    public class InputOutputDataParam : DataParam
    {
        #region 构造方法
        public InputOutputDataParam(string paramName, object paramValue)
            : base(paramName, paramValue, ParameterDirection.InputOutput)
        {
            if (paramValue.GetType() == System.Type.GetType("System.String"))
            {
                //4000
                base.Size = 0xfa0;
            }
        }

        public InputOutputDataParam(string paramName, object paramValue, object type)
            : this(paramName, paramValue)
        {
            base.Type = type.ToString();
        }

        public InputOutputDataParam(string paramName, object paramValue, object type, int size)
            : this(paramName, paramValue, type)
        {
            base.Size = size;
        }
        #endregion
    }
}
