using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目沟通记录表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:14
    /// </summary>
    [Serializable]
    public class ProjectCommunicationModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///沟通记录ID
			/// </summary>
			public virtual string CMMCID
			{
				get;
				set;
			}

			/// <summary>
			///附件
			/// </summary>
			public virtual string ATTACHEMENT
			{
				get;
				set;
			}

			/// <summary>
			///记录人
			/// </summary>
			public virtual string RECORDER
			{
				get;
				set;
			}

			/// <summary>
			///沟通对象
			/// </summary>
			public virtual string CMMCOBJECT
			{
				get;
				set;
			}

			/// <summary>
			///沟通主题
			/// </summary>
			public virtual string CMMCTITLE
			{
				get;
				set;
			}

			/// <summary>
			///记录时间
			/// </summary>
			public virtual DateTime? RECORDDATE
			{
				get;
				set;
			}

			/// <summary>
			///沟通方式
			/// </summary>
			public virtual string CMMCWAY
			{
				get;
				set;
			}

			/// <summary>
			///沟通内容
			/// </summary>
			public virtual string CMMCCONT
			{
				get;
				set;
			}

			/// <summary>
			///项目ID
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

        #endregion
    }

}
