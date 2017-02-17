using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Sbgl;
using System.Data;

namespace Enterprise.Data.App.Sbgl
{	

    /// <summary>
    /// 文件名:  ISbglYsbgdData.cs
    /// 功能描述: 数据层-设备维修项目验收报告单数据访问接口
    /// 创建人：代码生成器
    /// 创建时间：2015/4/30 8:22:37
    /// </summary>
    public interface ISbglYsbgdData : IDataApp<SbglYsbgdModel>
    {
        #region 代码生成器

        /// <summary>
        /// 根据主键获取唯一记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SbglYsbgdModel GetSingle(string key);

        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<SbglYsbgdModel> GetListBySQL(string sql);

        /// <summary>
        /// 执行基于SQL的原生操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        bool ExecuteSQL(string sql);

        /// <summary>
        /// 获取查询数据集
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns></returns>
        DataTable GetDataTable(string sql);

        #endregion
    }

}
