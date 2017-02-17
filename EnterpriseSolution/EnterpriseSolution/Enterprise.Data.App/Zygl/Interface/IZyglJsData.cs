using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Zygl;

namespace Enterprise.Data.App.Zygl
{	

    /// <summary>
    /// 文件名:  IZyglJsData.cs
    /// 功能描述: 数据层-作业结算数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/5/29 11:11:47
    /// </summary>
    public interface IZyglJsData : IDataApp<ZyglJsModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ZyglJsModel> GetListBySQL(string sql);

        #endregion
    }

}
