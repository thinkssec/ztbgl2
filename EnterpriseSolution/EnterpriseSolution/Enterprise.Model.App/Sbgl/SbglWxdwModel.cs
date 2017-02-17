using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Sbgl
{
    /// <summary>
    /// 设备维修单位信息表
    /// 创建人:代码生成器
    /// 创建时间:2015/4/28 15:01:25
    /// </summary>
    [Serializable]
    public class SbglWxdwModel : AppSuperModel
    {
        #region 代码生成器
        
			/// <summary>
			///厂家编号
			/// </summary>
			public virtual string CJBH
			{
				get;
				set;
			}

			/// <summary>
			///厂家名称
			/// </summary>
			public virtual string CJMC
			{
				get;
				set;
			}

			/// <summary>
			///厂家地址
			/// </summary>
			public virtual string CJDZ
			{
				get;
				set;
			}

			/// <summary>
			///厂家资质
			/// </summary>
			public virtual string CJZZ
			{
				get;
				set;
			}

			/// <summary>
			///银行账户
			/// </summary>
			public virtual string YHZH
			{
				get;
				set;
			}

			/// <summary>
			///联系人
			/// </summary>
			public virtual string LXR
			{
				get;
				set;
			}

			/// <summary>
			///联系方式
			/// </summary>
			public virtual string LXFS
			{
				get;
				set;
			}

			/// <summary>
			///当前状态
			/// </summary>
			public virtual int? DQZT
			{
				get;
				set;
			}

			/// <summary>
			///登记日期
			/// </summary>
			public virtual DateTime? DJRQ
			{
				get;
				set;
			}

			/// <summary>
			///登记人
			/// </summary>
			public virtual string DJR
			{
				get;
				set;
			}

        #endregion
    }

}
