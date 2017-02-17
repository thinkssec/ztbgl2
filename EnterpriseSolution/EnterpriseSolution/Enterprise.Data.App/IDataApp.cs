using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Data.App
{

    /// <summary>
    /// 文件名:  IDataApp.cs
    /// 功能描述: 应用平台数据访问接口
    /// 创建人：qw
    /// 创建日期: 2013.11.5
    /// </summary>
    public interface IDataApp<T>
    {

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        IList<T> GetList();

        /// <summary>
        /// 执行添加、修改、删除操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Execute(T t);

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <param name="hql">Nhibernate HQL,如果hql为空 返回所有数据</param>
        /// <returns></returns>
        IList<T> GetListByHQL(string hql);


    }

}
