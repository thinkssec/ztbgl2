using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Zygl;

namespace Enterprise.Data.App.Zygl
{	

    /// <summary>
    /// 文件名:  IZyglWgqtfyData.cs
    /// 功能描述: 数据层-数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/5/27 16:33:49
    /// </summary>
    public interface IZyglWgqtfyData : IDataApp<ZyglWgqtfyModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ZyglWgqtfyModel> GetListBySQL(string sql);

        #endregion
    }

}
