using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Ui
{
    /// <summary>
    /// 
	/// 创建人:代码生成器
	/// 创建时间:	2013/12/3 13:48:42
    /// </summary>
    [Serializable]
    public class UiDefaultModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///主键
			/// </summary>
			public virtual string DEFAULTID
			{
				get;
				set;
			}

			/// <summary>
			///UI内容
			/// </summary>
			public virtual string UICONTENT
			{
				get;
				set;
			}

			/// <summary>
			///角色ID
			/// </summary>
			public virtual int? ROLEID
			{
				get;
				set;
			}

        #endregion

        /// <summary>
        /// 角色
        /// </summary>
        public virtual Enterprise.Model.Basis.Sys.SysRoleModel SysRole
        {get;set;}
    }

}
