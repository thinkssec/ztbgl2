using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 项目物料消耗表
	/// 创建人:代码生成器
	/// 创建时间:	2014/6/19 15:35:14
    /// </summary>
    [Serializable]
    public class ProjectMaterialModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///ID
			/// </summary>
			public virtual string ID
			{
				get;
				set;
			}

			/// <summary>
			///物料类别:1=生产设备及配件,2=检验检测仪器及仪表,3=生产材料,4=办公设备,5=办公用品与耗材,6=办公家具,7=劳保用品,8=其他零杂物资
			/// </summary>
			public virtual string WLLB
			{
				get;
				set;
			}

			/// <summary>
			///总金额
			/// </summary>
			public virtual decimal? ZJE
			{
				get;
				set;
			}

			/// <summary>
			///领用人
			/// </summary>
			public virtual string LYR
			{
				get;
				set;
			}

			/// <summary>
			///数量
			/// </summary>
			public virtual int? SL
			{
				get;
				set;
			}

			/// <summary>
			///物料单位
			/// </summary>
			public virtual string WLDW
			{
				get;
				set;
			}

			/// <summary>
			///单价
			/// </summary>
			public virtual decimal? DJ
			{
				get;
				set;
			}

			/// <summary>
			///备注
			/// </summary>
			public virtual string MEMO
			{
				get;
				set;
			}

			/// <summary>
			///物料名称
			/// </summary>
			public virtual string WLMC
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

			/// <summary>
			///领用日期
			/// </summary>
			public virtual DateTime? LYRQ
			{
				get;
				set;
			}

        #endregion
    }

}
