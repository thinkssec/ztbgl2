using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 系统模块
    /// 创建人:代码生成器
    /// 创建时间:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysModuleModel : BasisSuperModel
    {
        #region 代码生成器

        /// <summary>
        ///自动编号
        /// </summary>
        public virtual string MODULEID
        {
            get;
            set;
        }

        /// <summary>
        ///模块编码
        /// </summary>
        public virtual string MCODE
        {
            get;
            set;
        }

        /// <summary>
        ///模块名称
        /// </summary>
        public virtual string MNAME
        {
            get;
            set;
        }

        /// <summary>
        ///父级编号
        /// </summary>
        public virtual string MPARENTID
        {
            get;
            set;
        }

        /// <summary>
        ///模块根目录
        /// </summary>
        public virtual string MROOTID
        {
            get;
            set;
        }

        /// <summary>
        ///前面小图标
        /// </summary>
        public virtual string MIMAGE
        {
            get;
            set;
        }

        /// <summary>
        ///链接目标
        /// </summary>
        public virtual string MTARGET
        {
            get;
            set;
        }

        /// <summary>
        ///链接地址
        /// </summary>
        public virtual string MURL
        {
            get;
            set;
        }

        /// <summary>
        ///是否显示
        /// </summary>
        public virtual int? MDELETE
        {
            get;
            set;
        }

        /// <summary>
        ///排序
        /// </summary>
        public virtual int? MORDERBY
        {
            get;
            set;
        }

        /// <summary>
        ///是否单链接
        /// </summary>
        public virtual int? MSINGLE
        {
            get;
            set;
        }

        /// <summary>
        /// WEB映射路径
        /// </summary>
        public virtual string MWEBURL
        {
            get;
            set;
        }

        /// <summary>
        /// WEB映射路径参数
        /// </summary>
        public virtual string MWEBPARAM
        {
            get;
            set;
        }

        #endregion
    }

}
