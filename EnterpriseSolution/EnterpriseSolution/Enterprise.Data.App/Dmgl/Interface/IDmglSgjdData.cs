using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Dmgl;

namespace Enterprise.Data.App.Dmgl
{	

    /// <summary>
    /// 文件名:  IDmglSgjdData.cs
    /// 功能描述: 数据层-施工进度数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2015/5/17 15:16:26
    /// </summary>
    public interface IDmglSgjdData : IDataApp<DmglSgjdModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<DmglSgjdModel> GetListBySQL(string sql);

        #endregion
    }

}
