using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touha.common.db
{
    public class DBOracleData : DBBase
    {
        public DBOracleData()
        {
            base._DbConnection = new OracleConnection();
        }

        protected override void AddParam(IDbCommand command, DataParamCol dataParamCol)
        {
            foreach (DataParam param in dataParamCol)
            {
                if (param.Value == null)
                {
                    param.Value = DBNull.Value;
                }
                if (param.Value.GetType().Name == "DateTime" && (DateTime)param.Value == DateTime.MinValue)
                {
                    param.Value = DBNull.Value;
                }
                ((OracleCommand)command).Parameters.AddWithValue(param.Name, param.Value);
                ((OracleCommand)command).Parameters[param.Name].Direction = param.Direction;
                if (param.Size != 0)
                {
                    ((OracleCommand)command).Parameters[param.Name].Size = param.Size;
                }
                if (param.Type != null)
                {
                    ((OracleCommand)command).Parameters[param.Name].OracleType = this.GetDBType(param.Type);
                }
            }
        }

        protected OracleType GetDBType(string type)
        {
            OracleType varChar = (OracleType)0;
            varChar = OracleType.VarChar;
            try
            {
                switch (type)
                {
                    case "System.String":
                        return OracleType.VarChar;

                    case "System.Int64":
                    case "System.Int32":
                    case "System.Int16":
                    case "System.Single":
                    case "System.Double":
                    case "System.Decimal":
                        return OracleType.Number;

                    case "System.DateTime":
                        return OracleType.DateTime;

                    case "System.Object":
                        return OracleType.Blob;

                    case "System.Boolean":
                        return OracleType.Cursor;
                }
                throw new DataException("不支持的参数类型: " + type.ToString());
            }
            catch
            {
            }
            return varChar;
        }
    }
}
