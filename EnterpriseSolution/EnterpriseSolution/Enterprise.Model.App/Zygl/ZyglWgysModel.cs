using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Zygl
{
    /// <summary>
    /// 完工验收
	/// 创建人:代码生成器
	/// 创建时间:	2015/5/28 17:52:44
    /// </summary>
    [Serializable]
    public class ZyglWgysModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///
			/// </summary>
			public virtual string WID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string ZID
			{
				get;
				set;
			}

			/// <summary>
			///施工单位
			/// </summary>
			public virtual string SGDW
			{
				get;
				set;
			}

			/// <summary>
			///施工现场描述
			/// </summary>
			public virtual string SGXCMS
			{
				get;
				set;
			}

			/// <summary>
			///预计费用总计
			/// </summary>
			public virtual decimal? YJFYZJ
			{
				get;
				set;
			}

			/// <summary>
			///劳务费
			/// </summary>
			public virtual decimal? LWF
			{
				get;
				set;
			}

			/// <summary>
			///油管
			/// </summary>
			public virtual decimal? YG
			{
				get;
				set;
			}

			/// <summary>
			///抽油杆
			/// </summary>
			public virtual decimal? CYG
			{
				get;
				set;
			}

			/// <summary>
			///泵
			/// </summary>
			public virtual decimal? BENG
			{
				get;
				set;
			}

			/// <summary>
			///封隔器
			/// </summary>
			public virtual decimal? FGQ
			{
				get;
				set;
			}

			/// <summary>
			///其他
			/// </summary>
			public virtual decimal? QT
			{
				get;
				set;
			}

			/// <summary>
			///射孔费
			/// </summary>
			public virtual decimal? SKF
			{
				get;
				set;
			}

			/// <summary>
			///测压费
			/// </summary>
			public virtual decimal? CYF
			{
				get;
				set;
			}

			/// <summary>
			///化工料
			/// </summary>
			public virtual decimal? HGL
			{
				get;
				set;
			}

			/// <summary>
			///找水费
			/// </summary>
			public virtual decimal? ZSF
			{
				get;
				set;
			}

			/// <summary>
			///技术服务
			/// </summary>
			public virtual decimal? JSFW
			{
				get;
				set;
			}

			/// <summary>
			///附件文件名称
			/// </summary>
			public virtual string FNAMES
			{
				get;
				set;
			}

			/// <summary>
			///附件保存名称
			/// </summary>
			public virtual string FVIEWNAMES
			{
				get;
				set;
			}

			/// <summary>
			///-2:临时保存
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

        #endregion
    }

}
