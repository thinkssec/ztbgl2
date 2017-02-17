using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Examine
{
    /// <summary>
    /// 成本科目表
    /// 创建人:代码生成器
    /// 创建时间:	2013-11-7 14:36:26
    /// </summary>
    [Serializable]
    public class ExamineCostModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///科目代号
        /// </summary>
        public virtual string COSTCODE
        {
            get;
            set;
        }

        /// <summary>
        ///类型名称
        /// </summary>
        public virtual string COSTNAME
        {
            get;
            set;
        }

        /// <summary>
        ///成本项代码
        /// </summary>
        public virtual string ITEMCODE
        {
            get;
            set;
        }

        /// <summary>
        ///上级代号
        /// </summary>
        public virtual string PARENTCODE
        {
            get;
            set;
        }

        #endregion

    }

}
