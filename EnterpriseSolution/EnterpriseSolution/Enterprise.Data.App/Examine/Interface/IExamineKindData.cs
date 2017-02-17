using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Examine;

namespace Enterprise.Data.App.Examine
{	

    /// <summary>
    /// 文件名:  IExamineKindData.cs
    /// 功能描述: 数据层-检验类型表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-11-8 14:53:58
    /// </summary>
    public interface IExamineKindData : IDataApp<ExamineKindModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ExamineKindModel> GetListBySQL(string sql);

        #endregion
    }

}
