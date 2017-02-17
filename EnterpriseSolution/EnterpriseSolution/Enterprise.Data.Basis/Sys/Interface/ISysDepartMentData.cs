using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enterprise.Component.ORM;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.Data.Basis.Sys
{
    /// <summary>
    /// 文件名:  ISysDepartMentData.cs
    /// 功能描述: 数据层-部门表数据访问接口
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public interface ISysDepartMentData : IDataBasis<SysDepartMentModel>
    {
        /// <summary>
        /// 根据ID获取部门信息MODEL
        /// </summary>
        /// <param name="deptId"></param>
        /// <returns></returns>
        SysDepartMentModel GetModelById(int deptId);

        /// <summary>
        /// 返回数据集合
        /// 按顺序号排序，并根据单位层级显示单位名称
        /// </summary>
        /// <returns></returns>
        IList<SysDepartMentModel> GetTreeList();
    }
}
