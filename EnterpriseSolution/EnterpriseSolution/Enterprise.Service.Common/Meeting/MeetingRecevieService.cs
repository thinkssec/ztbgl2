using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Common.Meeting;
using Enterprise.Model.Common.Meeting;

namespace Enterprise.Service.Common.Meeting
{
	
    /// <summary>
    /// 文件名:  MeetingRecevieService.cs
    /// 功能描述: 业务逻辑层-数据处理
    /// 创建人：代码生成器
	/// 创建时间 ：2013/3/1 15:50:39
    /// </summary>
    public class MeetingRecevieService
    {
        #region 代码生成器
        /// <summary>
        /// 得到数据访问类实例
        /// </summary>
        private static readonly IMeetingRecevieData dal = new MeetingRecevieData();

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<MeetingRecevieModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <returns></returns>
        public IList<MeetingRecevieModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(MeetingRecevieModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
