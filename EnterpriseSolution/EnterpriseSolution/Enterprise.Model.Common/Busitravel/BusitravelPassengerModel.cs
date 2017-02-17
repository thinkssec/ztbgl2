using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// 出差成员表
    /// 创建人:代码生成器
    /// 创建时间:	2013-6-24 20:24:41
    /// </summary>
    [Serializable]
    public class BusitravelPassengerModel : CommonSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///BID
        /// </summary>
        public virtual string BID
        {
            get;
            set;
        }

        /// <summary>
        /// 乘客在系统中用户ID
        /// </summary>
        public virtual int USERID
        {
            get;
            set;
        }

        /// <summary>
        ///附加说明
        /// </summary>
        public virtual string ADDITION
        {
            get;
            set;
        }

        /// <summary>
        ///护照编号
        /// </summary>
        public virtual string PASSPORT
        {
            get;
            set;
        }

        /// <summary>
        ///乘员姓名
        /// </summary>
        public virtual string PASSENGER
        {
            get;
            set;
        }

        #endregion
    }

}
