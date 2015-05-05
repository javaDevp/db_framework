using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touha.common.db
{
    /// <summary>
    /// 数据库类型（暂时只支持oracle，sqlserver,mysql可扩展）
    /// </summary>
    public enum DBType
    {
        Oracle,
        SqlServer,
        MySQL
    }
}
