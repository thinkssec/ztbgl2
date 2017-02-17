using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Sbgl;
using Enterprise.Model.App.Sbgl;
using System.Data;

namespace Enterprise.Service.App.Sbgl
{
	
    /// <summary>
    /// 文件名:  SbglYsbgdService.cs
    /// 功能描述: 业务逻辑层-设备维修项目验收报告单数据处理
    /// 创建人：代码生成器
    /// 创建时间 ：2015/4/30 8:22:37
    /// </summary>
    public class SbglYsbgdService
    {
        #region 代码生成器

        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly ISbglYsbgdData dal = new SbglYsbgdData();

        /// <summary>
        /// 根据主键获取唯一记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SbglYsbgdModel GetSingle(string key)
        {
            return dal.GetSingle(key);
        }

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SbglYsbgdModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SbglYsbgdModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<SbglYsbgdModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SbglYsbgdModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// 执行基于SQL的原生操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteSQL(string sql)
        {
            return dal.ExecuteSQL(sql);
        }

        /// <summary>
        /// 按指定的动作名称完成数据集合的处理
        /// </summary>
        /// <param name="lst">数据集合</param>
        /// <param name="actionName">动作名称</param>
        /// <returns></returns>
        public bool ExecuteListByAction(IList<SbglYsbgdModel> lst, string actionName)
        {
            bool isResult = false;
            foreach (var q in lst)
            {
                if (actionName == WebKeys.InsertAction)
                {
                    q.DB_Option_Action = WebKeys.InsertAction;
                    isResult = Execute(q);
                }
                else if (actionName == WebKeys.UpdateAction)
                {
                    q.DB_Option_Action = WebKeys.UpdateAction;
                    isResult = Execute(q);
                }
                else if (actionName == WebKeys.DeleteAction)
                {
                    q.DB_Option_Action = WebKeys.DeleteAction;
                    isResult = Execute(q);
                }
            }
            return isResult;
        }


        /// <summary>
        /// 获取查询数据集
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            return dal.GetDataTable(sql);
        }

        #endregion

        #region 自定义方法区

        /// <summary>
        /// 根据交付日期进行查询
        /// </summary>
        /// <param name="yy">年</param>
        /// <param name="mm">月</param>
        /// <returns></returns>
        public IList<SbglYsbgdModel> GetListByJFRQ(string yy, string mm)
        {
            string hql = "from SbglYsbgdModel c where 1=1 ";
            if (string.IsNullOrEmpty(mm))
            {
                hql += " and to_char(c.JFRQ,'yyyy')='" + string.Format("{0}", yy) + "' ";
            }
            else
            {
                hql += " and to_char(c.JFRQ,'yyyy-MM')='" + string.Format("{0}-{1}", yy, mm) + "' ";
            }
            return GetListByHQL(hql);
        }


        /// <summary>
        /// 根据验收报告批号进行查询
        /// </summary>
        /// <param name="wxph">批号</param>
        /// <returns></returns>
        public IList<SbglYsbgdModel> GetListByYsbgdph(string ph)
        {
            string hql = "from SbglYsbgdModel c where c.BGDPH='" + ph + "' order by c.BGDPH";
            return GetListByHQL(hql);
        }

        /// <summary>
        /// 获取图表用的数据串
        /// </summary>
        /// <param name="chartType">图表类型</param>
        /// <param name="yy">年</param>
        /// <param name="mm">月</param>
        /// <returns></returns>
        public string GetChartData(string chartType, string yy, string mm)
        {
            StringBuilder sb = new StringBuilder();
            string sql = string.Empty;
            if (chartType == "SBLX")
            {
                sql = "select b.sblx,sum(a.sbzj) from app_sbgl_ysbgd a, app_sbgl_wxjhb b where a.jhbid=b.jhbid and a.shzt='1' ";
                if (string.IsNullOrEmpty(mm))
                {
                    sql += " and to_char(a.JFRQ,'yyyy')='" + string.Format("{0}", yy) + "' ";
                }
                else
                {
                    sql += " and to_char(a.JFRQ,'yyyy-MM')='" + string.Format("{0}-{1}", yy, mm) + "' ";
                }
                sql += " group by b.sblx ";
                DataTable dt = GetDataTable(sql);
                sb.Append("费用统计图(按设备类型)\r\n");
                string key = string.Empty;
                string value = string.Empty;
                foreach (DataRow row in dt.Rows)
                {
                    ////sb.Append("北京\t上海\t杭州\t深圳\t广州\t天津\t重庆\r\n");
                    ////sb.Append("130\t33\t312\t134\t290\t90\t122");
                    key += row[0].ToRequestString() + "\t";
                    value += row[1].ToRequestString() + "\t";
                }
                sb.Append(key.TrimEnd("\t".ToCharArray()) + "\r\n");
                sb.Append(value.TrimEnd("\t".ToCharArray()));
            }
            else if (chartType == "SYDW")
            {
                sql = "select c.dname,sum(a.sbzj) from app_sbgl_ysbgd a, app_sbgl_wxjhb b,basis_sys_department c "
                    + " where a.jhbid=b.jhbid and b.sbsydw=c.deptid and a.shzt='1' ";
                if (string.IsNullOrEmpty(mm))
                {
                    sql += " and to_char(a.JFRQ,'yyyy')='" + string.Format("{0}", yy) + "' ";
                }
                else
                {
                    sql += " and to_char(a.JFRQ,'yyyy-MM')='" + string.Format("{0}-{1}", yy, mm) + "' ";
                }
                sql += " group by c.dname ";
                DataTable dt = GetDataTable(sql);
                sb.Append("费用统计图(按使用单位)\r\n");
                string key = string.Empty;
                string value = string.Empty;
                foreach (DataRow row in dt.Rows)
                {
                    ////sb.Append("北京\t上海\t杭州\t深圳\t广州\t天津\t重庆\r\n");
                    ////sb.Append("130\t33\t312\t134\t290\t90\t122");
                    key += row[0].ToRequestString() + "\t";
                    value += row[1].ToRequestString() + "\t";
                }
                sb.Append(key.TrimEnd("\t".ToCharArray()) + "\r\n");
                sb.Append(value.TrimEnd("\t".ToCharArray()));
            }
            return sb.ToString();
        }

        #endregion

    }

}
