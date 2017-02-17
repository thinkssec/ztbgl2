using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目节点计划与运行表
	/// 创建人:代码生成器
	/// 创建时间:	2013-11-5 15:48:23
    /// </summary>
    [Serializable]
    public class ProjectRunningModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///项目ID
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///节点编码
			/// </summary>
			public virtual string NODECODE
			{
				get;
				set;
			}

			/// <summary>
			///计划完成时间
			/// </summary>
			public virtual DateTime? PFDATE
			{
				get;
				set;
			}

			/// <summary>
			///节点编号
			/// </summary>
			public virtual string NODEBH
			{
				get;
				set;
			}

			/// <summary>
			///节点权值
			/// </summary>
			public virtual int? NODEVALUE
			{
				get;
				set;
			}

			/// <summary>
			///关键节点
			/// </summary>
			public virtual int? KEYNODE
			{
				get;
				set;
			}

			/// <summary>
			///节点名称
			/// </summary>
			public virtual string NODENAME
			{
				get;
				set;
			}

			/// <summary>
			///运行状态
            ///为空=节点未释放 0=未运行 1=已运行
			/// </summary>
			public virtual int? RUNSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///实际完成时间
			/// </summary>
			public virtual DateTime? AFDATE
			{
				get;
				set;
			}

        #endregion
    }

}
