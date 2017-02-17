using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.Data.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysVisitLogData.cs
    /// 功能描述: 数据层-访问日志表数据访问方法实现类
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class SysVisitLogData:ISysVisitLogData
    {

        /// <summary>
        /// 数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysVisitLogModel> GetList()
        {
            IList<SysVisitLogModel> list = null;
            using (ORMDataAccess<SysVisitLogData> db = new ORMDataAccess<SysVisitLogData>())
            {
                list = db.Query<SysVisitLogModel>("from SysVisitLogModel");
            }
            return list;
        }

        /// <summary>
        /// 操作方法
        /// </summary>
        /// <param name="t">实体类</param>
        /// <returns></returns>
        public bool Execute(SysVisitLogModel t)
        {
            bool isResult = true;
            using (ORMDataAccess<SysVisitLogData> db = new ORMDataAccess<SysVisitLogData>())
            {
                if (t.DB_Option_Action == WebKeys.InsertAction)
                {
                    db.Insert(t);
                }
                else if (t.DB_Option_Action == WebKeys.UpdateAction)
                {
                    db.Update(t);
                }
                else if (t.DB_Option_Action == WebKeys.DeleteAction)
                {
                    db.Delete(t);
                }
            }
            return isResult;
        }

    }
}
