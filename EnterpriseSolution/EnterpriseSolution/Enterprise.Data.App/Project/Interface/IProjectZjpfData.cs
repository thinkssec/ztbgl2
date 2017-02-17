using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectZjpfData.cs
    /// 功能描述: 数据层-评分标准数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/7/3 12:43:12
    /// </summary>
    public interface IProjectZjpfData : IDataApp<ProjectZjpfModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectZjpfModel> GetListBySQL(string sql);
        void CreateZjpf(string[] bzid, string[] df, string projid, int userid, string crminfo);
        void CreateZjpf(string[] bzid, string[] df, string projid, int userid);
        void UpdZjpf(string projid, int userid, int status);
        #endregion
    }

}
