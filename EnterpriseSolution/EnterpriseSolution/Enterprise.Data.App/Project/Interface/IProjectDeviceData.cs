using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectDeviceData.cs
    /// 功能描述: 数据层-项目设备表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2014/6/19 15:35:20
    /// </summary>
    public interface IProjectDeviceData : IDataApp<ProjectDeviceModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectDeviceModel> GetListBySQL(string sql);

        #endregion
    }

}
