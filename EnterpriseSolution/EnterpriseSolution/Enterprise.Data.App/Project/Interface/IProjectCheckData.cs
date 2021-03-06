using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// 文件名:  IProjectCheckData.cs
    /// 功能描述: 数据层-审核信息表数据访问接口
	/// 创建人：代码生成器
	/// 创建时间：2013-11-5 15:48:14
    /// </summary>
    public interface IProjectCheckData : IDataApp<ProjectCheckModel>
    {
        #region 代码生成器
        
        /// <summary>
        /// 执行批量添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool ExecuteLst(IList<ProjectCheckModel> models);

        #endregion
    }

}
