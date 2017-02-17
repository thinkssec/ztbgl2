using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectPlanData.cs
    /// 功能描述: 数据层-项目计划表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-11-5 15:48:22
    /// </summary>
    public interface IProjectPlanData : IDataApp<ProjectPlanModel>
    {
        #region 代码生成器
        ///// <summary>
        ///// 获取数据集合
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        #endregion        

        void CreatePlan(string planId, string ProjectId);

        void RebuildEmptyPlan(string planId, string ProjectId);
    }

}
