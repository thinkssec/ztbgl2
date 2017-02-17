using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Crm;

namespace Enterprise.Data.App.Crm
{	

    /// <summary>
    /// 文件名:  ICrmPbsurveyData.cs
    /// 功能描述: 数据层-乙方单位评价表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2014/3/31 17:16:08
    /// </summary>
    public interface ICrmPbsurveyData : IDataApp<CrmPbsurveyModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 返回原生SQL的查询列表
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<CrmPbsurveyModel> GetListBySQL(string sql);

        #endregion
    }

}
