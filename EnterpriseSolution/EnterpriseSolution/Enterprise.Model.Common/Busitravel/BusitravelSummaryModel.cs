using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// 出差情况汇总表
    /// 创建人:代码生成器
    /// 创建时间:	2013-6-24 20:24:42
    /// </summary>
    [Serializable]
    public class BusitravelSummaryModel : CommonSuperModel
    {
        #region 代码生成器

        /// <summary>
        /// ID
        /// </summary>
        public virtual string BID
        {
            get;
            set;
        }

        /// <summary>
        ///行程关闭日期
        /// </summary>
        public virtual DateTime? BCLOSE
        {
            get;
            set;
        }

        /// <summary>
        ///出差编号
        /// </summary>
        public virtual int? BREQSNUM
        {
            get;
            set;
        }

        /// <summary>
        ///结束时间
        /// </summary>
        public virtual DateTime? BEND
        {
            get;
            set;
        }

        /// <summary>
        ///行程凭证
        /// </summary>
        public virtual string BILL
        {
            get;
            set;
        }

        /// <summary>
        ///目的地
        /// </summary>
        public virtual string BDESTINATION
        {
            get;
            set;
        }

        /// <summary>
        ///出差类型
        ///0=哈国 1=中国
        /// </summary>
        public virtual int? BTYPE
        {
            get;
            set;
        }

        /// <summary>
        ///申请事由
        /// </summary>
        public virtual string BSUBJECT
        {
            get;
            set;
        }

        /// <summary>
        ///办理日期
        /// </summary>
        public virtual DateTime? BTRANSDATE
        {
            get;
            set;
        }

        /// <summary>
        ///申请人
        /// </summary>
        public virtual int? BREQUSER
        {
            get;
            set;
        }

        /// <summary>
        ///批准日期
        /// </summary>
        public virtual DateTime? BAPPROVEDATE
        {
            get;
            set;
        }

        /// <summary>
        ///起始时间
        /// </summary>
        public virtual DateTime? BSTART
        {
            get;
            set;
        }

        /// <summary>
        ///申请人姓名
        /// </summary>
        public virtual string BUSERNAME
        {
            get;
            set;
        }

        /// <summary>
        ///行程状态
        ///0=未审批 1=审批通过 2=审批不通过
        ///3=已办理票务 4=行程关闭 5=行程取消
        /// </summary>
        public virtual int? BSTATE
        {
            get;
            set;
        }

        /// <summary>
        ///票务办理人
        /// </summary>
        public virtual int? BTICKETUSER
        {
            get;
            set;
        }

        /// <summary>
        /// 出差天数
        /// </summary>
        public virtual int? BDAYS
        {
            get;
            set;
        }

        /// <summary>
        /// 出差限制天数
        /// </summary>
        public virtual int? BMAXDAYS
        {
            get;
            set;
        }

        /// <summary>
        /// 表单语言类型
        /// </summary>
        public virtual string BLANG
        {
            get;
            set;
        }

        /// <summary>
        /// 所属单位
        /// </summary>
        public virtual int? BDEPTID
        {
            get;
            set;
        }


        #endregion

    }



    /// <summary>
    /// 出差情况统计表
    /// 创建人:qw
    /// 创建时间:	2013-7-2
    /// </summary>
    [Serializable]
    public class BusitravelStatisModel
    {
        /// <summary>
        /// 单位ID 
        /// </summary>
        public int DEPTID
        {
            get;
            set;
        }

        /// <summary>
        /// 单位名称
        /// </summary>
        public string DeptName
        {
            get;
            set;
        }

        /// <summary>
        /// 人员ID 
        /// </summary>
        public int USERID
        {
            get;
            set;
        }

        /// <summary>
        /// 人员姓名
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// 年度 
        /// </summary>
        public int YEAR
        {
            get;
            set;
        }

        /// <summary>
        /// 1月出差天数 
        /// </summary>
        public int JanuaryDays
        {
            get;
            set;
        }

        /// <summary>
        /// 2月出差天数 
        /// </summary>
        public int FebruaryDays
        {
            get;
            set;
        }

        /// <summary>
        /// 3月出差天数 
        /// </summary>
        public int MarchDays
        {
            get;
            set;
        }

        /// <summary>
        /// 4月出差天数 
        /// </summary>
        public int AprilDays
        {
            get;
            set;
        }

        /// <summary>
        /// 5月出差天数 
        /// </summary>
        public int MayDays
        {
            get;
            set;
        }

        /// <summary>
        /// 6月出差天数 
        /// </summary>
        public int JuneDays
        {
            get;
            set;
        }

        /// <summary>
        /// 7月出差天数 
        /// </summary>
        public int JulyDays
        {
            get;
            set;
        }

        /// <summary>
        /// 8月出差天数 
        /// </summary>
        public int AugustDays
        {
            get;
            set;
        }

        /// <summary>
        /// 9月出差天数 
        /// </summary>
        public int SeptemberDays
        {
            get;
            set;
        }

        /// <summary>
        /// 10月出差天数 
        /// </summary>
        public int OctoberDays
        {
            get;
            set;
        }

        /// <summary>
        /// 11月出差天数 
        /// </summary>
        public int NovemberDays
        {
            get;
            set;
        }

        /// <summary>
        /// 12月出差天数 
        /// </summary>
        public int DecemberDays
        {
            get;
            set;
        }

        /// <summary>
        /// 小计出差天数
        /// </summary>
        public int TotalDays
        {
            get;
            set;
        }

    }

}
