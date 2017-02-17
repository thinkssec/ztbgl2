using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 合同收入
    /// 创建人:代码生成器
    /// 创建时间:	2013-11-5 15:48:15
    /// </summary>
    [Serializable]
    public class ProjectContractModel : AppSuperModel
    {
        #region 代码生成器
            /// <summary>
			///合同ID主键
			/// </summary>
			public virtual string CONTRACTID
			{
				get;
				set;
			}

			/// <summary>
			///资金来源
			/// </summary>
			public virtual string ZJLY
			{
				get;
				set;
			}

			/// <summary>
			///关联系统编号
			/// </summary>
			public virtual string ASSOCIATEDNUM
			{
				get;
				set;
			}

			/// <summary>
			///内部合同：是或否
			/// </summary>
			public virtual string NBHT
			{
				get;
				set;
			}

			/// <summary>
			///签订日期
			/// </summary>
			public virtual DateTime? SIGNDATE
			{
				get;
				set;
			}

			/// <summary>
			///主办部门
			/// </summary>
			public virtual int? ZBBM
			{
				get;
				set;
			}

			/// <summary>
			///合同变更：0或1
			/// </summary>
			public virtual string HTBG
			{
				get;
				set;
			}

			/// <summary>
			///合同收入/标的金额
			/// </summary>
			public virtual decimal? TOTALINCOME
			{
				get;
				set;
			}

			/// <summary>
			///我方签约代表
			/// </summary>
			public virtual int? QYDB
			{
				get;
				set;
			}

			/// <summary>
			///总金额（元）
			/// </summary>
			public virtual decimal? ZJE
			{
				get;
				set;
			}

			/// <summary>
			///合同名称
			/// </summary>
			public virtual string CONTRACTNAME
			{
				get;
				set;
			}

			/// <summary>
			///完工日期
			/// </summary>
			public virtual DateTime? COMPLETEDATE
			{
				get;
				set;
			}

			/// <summary>
			///币种
			/// </summary>
			public virtual string BZ
			{
				get;
				set;
			}

			/// <summary>
			///合同编号
			/// </summary>
			public virtual string HTBH
			{
				get;
				set;
			}

			/// <summary>
			///已结算金额
			/// </summary>
			public virtual decimal? YJJE
			{
				get;
				set;
			}

			/// <summary>
			///计划金额
			/// </summary>
			public virtual decimal? JHJE
			{
				get;
				set;
			}

			/// <summary>
			///相对人
			/// </summary>
			public virtual string XDR
			{
				get;
				set;
			}

			/// <summary>
			///合同转让
			/// </summary>
			public virtual string HTZR
			{
				get;
				set;
			}

			/// <summary>
			///待终结
			/// </summary>
			public virtual string DZJ
			{
				get;
				set;
			}

			/// <summary>
			///所属项目
			/// </summary>
			public virtual string SSXM
			{
				get;
				set;
			}

			/// <summary>
			///合同序号
			/// </summary>
			public virtual string HTXH
			{
				get;
				set;
			}

			/// <summary>
			///剩余金额
			/// </summary>
			public virtual decimal? SYJE
			{
				get;
				set;
			}

			/// <summary>
			///当前办理人
			/// </summary>
			public virtual string DQBLR
			{
				get;
				set;
			}

			/// <summary>
			///所属阶段
			/// </summary>
			public virtual string SSJD
			{
				get;
				set;
			}

			/// <summary>
			///主办时间
			/// </summary>
			public virtual DateTime? ZBSJ
			{
				get;
				set;
			}

			/// <summary>
			///结算次数
			/// </summary>
			public virtual int? JSCS
			{
				get;
				set;
			}

			/// <summary>
			///关联交易：是或否
			/// </summary>
			public virtual string GLJY
			{
				get;
				set;
			}

			/// <summary>
			///经办人
			/// </summary>
			public virtual string JBR
			{
				get;
				set;
			}

			/// <summary>
			///合同中止
			/// </summary>
			public virtual string HTZZ
			{
				get;
				set;
			}

			/// <summary>
			///所属环节
			/// </summary>
			public virtual string SSHJ
			{
				get;
				set;
			}

			/// <summary>
			///备案时间
			/// </summary>
			public virtual DateTime? BASJ
			{
				get;
				set;
			}

			/// <summary>
			///单位归属
			/// </summary>
			public virtual string DWGS
			{
				get;
				set;
			}

			/// <summary>
			///资金流向
			/// </summary>
			public virtual string ZJLX
			{
				get;
				set;
			}

			/// <summary>
			///合同类别
			/// </summary>
			public virtual string HTLB
			{
				get;
				set;
			}


        #endregion


        #region 自定义

        /// <summary>
        ///项目合同收入
        /// </summary>
        public virtual decimal? INCOMEVALUE
        {
            get;
            set;
        }

        #endregion
    }

}
