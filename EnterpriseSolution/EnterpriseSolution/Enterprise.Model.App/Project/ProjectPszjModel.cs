using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目评审专家
	/// 创建人:代码生成器
	/// 创建时间:	2015/7/3 18:03:12
    /// </summary>
    [Serializable]
    public class ProjectPszjModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual string ZID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PERSONID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PERSONNAME
			{
				get;
				set;
			}

			/// <summary>
			///1评委组长 2：主持人
			/// </summary>
			public virtual string ROLE
			{
				get;
				set;
			}

			/// <summary>
			///1:技术评委2经济评委 3需求评委  5:工作人员 6，监督人员
			/// </summary>
			public virtual int? LB
			{
				get;
				set;
			}

			/// <summary>
			///-1临时保存，0提交
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

        #endregion
    }

}
