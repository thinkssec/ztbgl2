using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Examine
{
    /// <summary>
    /// 检验设施与过程名称
    /// 创建人:代码生成器
    /// 创建时间:	2013-11-5 15:48:10
    /// </summary>
    [Serializable]
    public class ExamineProcessModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///本级代码
        /// </summary>
        public virtual string BJDM
        {
            get;
            set;
        }

        /// <summary>
        ///本级名称
        /// </summary>
        public virtual string BJMC
        {
            get;
            set;
        }

        /// <summary>
        ///层级顺序
        /// </summary>
        public virtual string CJSX
        {
            get;
            set;
        }

        /// <summary>
        ///检验类型ID
        /// </summary>
        public virtual int KINDID
        {
            get;
            set;
        }

        /// <summary>
        ///上级代码
        /// </summary>
        public virtual string SJDM
        {
            get;
            set;
        }

        /// <summary>
        ///初始权重
        /// </summary>
        public virtual decimal? CSQZ
        {
            get;
            set;
        }

        #endregion


        #region 关联对象

        /// <summary>
        /// 检验类型MODEL
        /// </summary>
        public virtual ExamineKindModel ExamineKind
        {
            get;
            set;
        }

        #endregion
    }

}
