using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Data.Common
{

    public interface IDataCommon<T>
    {

        /// <summary>
        /// 获取数据集合
        /// </summary>
        /// <returns></returns>
        IList<T> GetList();

        /// <summary>
        /// 执行CUD操作
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Execute(T t);

        /// <summary>
        /// 根据条件获取数据集合
        /// </summary>
        /// <param name="hql">Nhibernate HQL,如果hql为空 返回所有数据</param>
        /// <returns></returns>
        IList<T> GetList(string hql);

    }
}
