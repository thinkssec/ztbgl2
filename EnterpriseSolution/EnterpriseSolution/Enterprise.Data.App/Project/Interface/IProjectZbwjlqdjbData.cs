using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectZbwjlqdjbData.cs
    /// 功能描述: 数据层-招标文件领取登记表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/6/28 0:06:20
    /// </summary>
    public interface IProjectZbwjlqdjbData : IDataApp<ProjectZbwjlqdjbModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectZbwjlqdjbModel> GetListBySQL(string sql);

        #endregion
    }

}
