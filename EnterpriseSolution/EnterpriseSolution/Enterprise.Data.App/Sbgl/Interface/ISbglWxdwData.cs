using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Sbgl;

namespace Enterprise.Data.App.Sbgl
{	

    /// <summary>
    /// 文件名:  ISbglWxdwData.cs
    /// 功能描述: 数据层-设备维修单位信息表数据访问接口
    /// 创建人：代码生成器
    /// 创建时间：2015/4/28 15:13:23
    /// </summary>
    public interface ISbglWxdwData : IDataApp<SbglWxdwModel>
    {
        #region 代码生成器
        
	    /// <summary>
        /// 根据主键获取唯一记录
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SbglWxdwModel GetSingle(string key);

	    /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<SbglWxdwModel> GetListBySQL(string sql);

        /// <summary>
        /// 执行基于SQL的原生操作
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        bool ExecuteSQL(string sql);

        #endregion
    }

}
