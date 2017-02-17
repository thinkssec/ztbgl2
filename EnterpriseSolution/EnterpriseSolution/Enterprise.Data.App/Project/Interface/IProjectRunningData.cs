using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectRunningData.cs
    /// 功能描述: 数据层-项目节点计划与运行表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-11-5 15:48:23
    /// </summary>
    public interface IProjectRunningData : IDataApp<ProjectRunningModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool ExecuteLst(IList<ProjectRunningModel> models);

        #endregion

        /// <summary>
        /// 生成树型控件脚本
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        string GetRunningEasyuiTreeHtmlById(string projectId);
    }

}
