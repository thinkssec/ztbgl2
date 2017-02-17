using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Model.Basis.Sys;
namespace Enterprise.Data.Basis.Sys
{
    /// <summary>
    /// 文件名:  SysRoleData.cs
    /// 功能描述: 数据层-用户职务表数据访问方法实现类
    /// 创建人：caitou
    /// 创建日期: 2013.1.29
    /// </summary>
    public class SysUserDutyData:ISysUserDutyData
    {
        /// <summary>
        /// 数据集合
        /// </summary>
        /// <returns></returns>
        public IList<SysUserDutyModel> GetList()
        {
            IList<SysUserDutyModel> list = null;
            using (ORMDataAccess<SysUserDutyData> db = new ORMDataAccess<SysUserDutyData>())
            {
                list = db.Query<SysUserDutyModel>("from SysUserDutyModel");
            }
            return list;
        }

        /// <summary>
        /// 获取指定查询条件下的数据集合
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<SysUserDutyModel> GetListBySQL(string sql)
        {
            IList<SysUserDutyModel> list = null;
            using (ORMDataAccess<SysUserDutyData> db = new ORMDataAccess<SysUserDutyData>())
            {
                list = db.QueryBySQL<SysUserDutyModel>(sql, typeof(SysUserDutyModel));
            }
            return list;
        }

        /// <summary>
        /// 操作方法
        /// </summary>
        /// <param name="t">实体类</param>
        /// <returns></returns>
        public bool Execute(SysUserDutyModel t)
        {
            bool isResult = true;
            using (ORMDataAccess<SysUserDutyData> db = new ORMDataAccess<SysUserDutyData>())
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
