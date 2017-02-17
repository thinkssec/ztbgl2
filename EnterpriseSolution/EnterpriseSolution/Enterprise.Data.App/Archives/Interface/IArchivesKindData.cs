using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Archives;

namespace Enterprise.Data.App.Archives
{	

    /// <summary>
    /// 文件名:  IArchivesKindData.cs
    /// 功能描述: 数据层-案卷类别表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2014/2/7 13:50:46
    /// </summary>
    public interface IArchivesKindData : IDataApp<ArchivesKindModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ArchivesKindModel> GetListBySQL(string sql);

        #endregion
    }

}
