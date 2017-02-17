using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Document
{
    /// <summary>
    /// 文档转换表
    /// 创建人:代码生成器
    /// 创建时间:	2014/3/6 8:25:00
    /// </summary>
    [Serializable]
    public class DocumentConvertModel : AppSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///转换表ID
        /// </summary>
        public virtual string CVTID
        {
            get;
            set;
        }

        /// <summary>
        ///转换日期
        /// </summary>
        public virtual DateTime? CVTDATE
        {
            get;
            set;
        }

        /// <summary>
        ///转换后名称
        /// </summary>
        public virtual string CVTNAME
        {
            get;
            set;
        }

        /// <summary>
        ///文档ID
        /// </summary>
        public virtual string DOCID
        {
            get;
            set;
        }

        /// <summary>
        ///转换类型: pdf swf img
        /// </summary>
        public virtual string CVTTYPE
        {
            get;
            set;
        }

        /// <summary>
        ///转换后路径
        /// </summary>
        public virtual string CVTPATH
        {
            get;
            set;
        }

        #endregion


        #region 自定义属性

        /// <summary>
        /// 文档MODEL
        /// </summary>
        public virtual DocumentProjModel DocumentProj
        {
            get;
            set;
        }

        #endregion
    }

}
