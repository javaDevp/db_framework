using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace touha.common.db
{
    /// <summary>
    /// 参数集合类
    /// </summary>
    public class DataParamCol : NameObjectCollectionBase
    {
        #region 构造函数
        public DataParamCol()
        {
        }

        public DataParamCol(params DataParam[] paras)
        {
            foreach (DataParam para in paras)
            {
                base.BaseAdd(para.Name, para);
            }
        }

        public DataParamCol(params object[] paras)
        {
            this.AddBatch(paras);
        }
        #endregion

        #region 集合的增、删、取等操作
        public void Add(DataParam para)
        {
            base.BaseAdd(para.Name, para);
        }

        public void Add(string paramName, object paramValue)
        {
            base.BaseAdd(paramName, new InputDataParam(paramName, paramValue));
        }

        public void Add(string[] paramName, object[] paramValue)
        {
            for (int i = 0; i < paramName.GetLength(0); i++)
            {
                base.BaseAdd(paramName[i], new InputDataParam(paramName[i], paramValue[i]));
            }
        }

        public void AddBatch(params object[] para)
        {
            for (int i = 0; i < para.GetLength(0); i++)
            {
                string name = para[i].ToString();
                base.BaseAdd(name, new InputDataParam(name, para[i]));
                i++;
            }
        }

        public void Clear()
        {
            base.BaseClear();
        }

        public IEnumerator GetEnumerator()
        {
            //NameObjectCollectionBase类GetEnumerator方法，返回NameObjectKeysEnumerator
            return new DataParamColEnumerator(this, base.GetEnumerator());
        }

        public void Remove(string paramName)
        {
            base.BaseRemove(paramName);
        }

        public void RemoveAt(int idx)
        {
            base.BaseRemoveAt(idx);
        }

        public DataParam this[int index]
        {
            get
            {
                return (DataParam)base.BaseGet(index);
            }
        }

        public DataParam this[string index]
        {
            get
            {
                return (DataParam)base.BaseGet(index);
            }
        }
        #endregion

        /// <summary>
        /// 内部类，参数集合对应的迭代类
        /// </summary>
        private class DataParamColEnumerator : IEnumerator
        {
            #region 字段
            private DataParamCol _dataParamCol;

            private IEnumerator _enumerator;
            #endregion

            #region 构造函数
            public DataParamColEnumerator(DataParamCol dataPramCol, IEnumerator enumerator)
            {
                this._dataParamCol = dataPramCol;
                this._enumerator = enumerator;
            }
            #endregion

            #region 实现IEnumerator接口方法
            public virtual bool MoveNext()
            {
                return this._enumerator.MoveNext();
            }

            public virtual void Reset()
            {
                this._enumerator.Reset();
            }

            public virtual Object Current
            {
                get
                {
                    return this._dataParamCol[(string)this._enumerator.Current];
                }
            }
            #endregion
        }
    }
}
