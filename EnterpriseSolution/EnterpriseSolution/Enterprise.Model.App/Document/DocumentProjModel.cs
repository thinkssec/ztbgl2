using Enterprise.Model.App.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Document
{
    /// <summary>
    /// 业务文档库
	/// 创建人:代码生成器
	/// 创建时间:	2014/3/6 8:25:02
    /// </summary>
    [Serializable]
    public class DocumentProjModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///文档ID
			/// </summary>
			public virtual string DOCID
			{
				get;
				set;
			}

			/// <summary>
			///关联表ID
			/// </summary>
			public virtual string ASSOCIATIONID
			{
				get;
				set;
			}

			/// <summary>
			///文档路径
			/// </summary>
			public virtual string DOCPATH
			{
				get;
				set;
			}

			/// <summary>
			///文档状态: 0=已存档 1=已转换  2=不开放
			/// </summary>
			public virtual int? DOCSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///类别编号
			/// </summary>
			public virtual string LBBH
			{
				get;
				set;
			}

			/// <summary>
			///数据表名称
			/// </summary>
			public virtual string TABLENAME
			{
				get;
				set;
			}

			/// <summary>
			///文档出处
			/// </summary>
			public virtual string DOCQUARRY
			{
				get;
				set;
			}

			/// <summary>
			///文档添加人
			/// </summary>
			public virtual string DOCADDUSER
			{
				get;
				set;
			}

			/// <summary>
			///文档名称
			/// </summary>
			public virtual string DOCNAME
			{
				get;
				set;
			}

			/// <summary>
			///文档作者
			/// </summary>
			public virtual string DOCWRITER
			{
				get;
				set;
			}

			/// <summary>
			///文档概述
			/// </summary>
			public virtual string DOCOVERVIEW
			{
				get;
				set;
			}

			/// <summary>
			///存档日期
			/// </summary>
			public virtual DateTime? DOCSAVEDATE
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

            /// <summary>
            /// 项目infoMODEL
            /// </summary>
            public virtual ProjectInfoModel ProjectInfo
            {
                get;
                set;
            }
    }

}
