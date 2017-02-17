using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.Common.Supervise;

namespace Enterprise.Data.Common.Supervise
{	

    /// <summary>
    /// 文件名:  ISuperviseInfoData.cs
    /// 功能描述: 数据层-督办事务表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013/3/13 10:53:09
    /// </summary>
    public interface ISuperviseInfoData : IDataCommon<SuperviseInfoModel>
    {
        #region 代码生成器
        ///// <summary>
        ///// 获取数据集合
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        #endregion
        void Delete(string dbid);
    }

}
