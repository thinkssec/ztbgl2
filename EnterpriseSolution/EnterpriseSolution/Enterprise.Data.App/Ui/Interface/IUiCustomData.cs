using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Ui;

namespace Enterprise.Data.App.Ui
{	

    /// <summary>
    /// 文件名:  IUiCustomData.cs
    /// 功能描述: 数据层-数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/12/3 13:48:43
    /// </summary>
    public interface IUiCustomData : IDataApp<UiCustomModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<UiCustomModel> GetListBySQL(string sql);

        #endregion
    }

}
