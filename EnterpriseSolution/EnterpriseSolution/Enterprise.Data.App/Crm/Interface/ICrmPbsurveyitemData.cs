using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// 文件名:  ICrmPbsurveyitemData.cs
    /// 功能描述: 数据层-乙方单位评价内容表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2014/3/31 17:16:11
    /// </summary>
    public interface ICrmPbsurveyitemData : IDataApp<CrmPbsurveyitemModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmPbsurveyitemModel> GetListBySQL(string sql);

        #endregion
    }

}
