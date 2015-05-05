using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touha.common.db
{
    public class OutputDataParam : DataParam
    {
        #region 构造方法
        public OutputDataParam(string paramName)
            : base(paramName, null, ParameterDirection.Output)
        {
            if (Size == 0)
            {
                //4000
                base.Size = 0xfa0;
            }
        }

        public OutputDataParam(string paramName, object type)
            : this(paramName)
        {
            base.Type = type.ToString();
        }

        public OutputDataParam(string paramName, object type, int size)
            : this(paramName, type)
        {
            base.Size = size;
        }
        #endregion
    }
}
