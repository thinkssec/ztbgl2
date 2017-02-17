using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Supervise
{
    /// <summary>
    /// 督办事务表
	/// 创建人:代码生成器
	/// 创建时间:	2013/3/13 15:23:41
    /// </summary>
    [Serializable]
    public class SuperviseInfoModel : CommonSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///督办ID
			/// </summary>
			public virtual string DBID
			{
				get;
				set;
			}

			/// <summary>
			///负责领导ID
			/// </summary>
			public virtual int? FZLD
			{
				get;
				set;
			}

			/// <summary>
			///督办下达时间
			/// </summary>
			public virtual string XDSJ
			{
				get;
				set;
			}

			/// <summary>
			///督办编号
			/// </summary>
			public virtual string DBBH
			{
				get;
				set;
			}

			/// <summary>
			///标题
			/// </summary>
			public virtual string DBBT
			{
				get;
				set;
			}

			/// <summary>
			///督办时间
			/// </summary>
			public virtual string DBSJ
			{
				get;
				set;
			}

			/// <summary>
			///督办内容
			/// </summary>
			public virtual string DBNR
			{
				get;
				set;
			}

			/// <summary>
			///完成时间
			/// </summary>
			public virtual string YQWCSJ
			{
				get;
				set;
			}
            
            /// <summary>
            /// 督办人
            /// </summary>
            public virtual int DBR
            {
                get;
                set;
            }

        #endregion
    }

}
