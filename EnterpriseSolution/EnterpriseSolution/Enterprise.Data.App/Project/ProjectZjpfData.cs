using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Component.Infrastructure;
using Enterprise.Component.Cache;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{

    /// <summary>
    /// �ļ���:  ProjectZjpfData.cs
    /// ��������: ���ݲ�-���ֱ�׼���ݷ��ʷ���ʵ����
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/7/3 12:43:12
    /// </summary>
    public class ProjectZjpfData : IProjectZjpfData
    {
        #region ����������
		/// <summary>
        /// ����������
        /// </summary>
        public static readonly string CacheClassKey = WebKeys.CacheItemKey + typeof(ProjectZjpfData).ToString();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ProjectZjpfModel> GetList()
        {
            IList<ProjectZjpfModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectZjpfModel>)CacheHelper.GetCache(CacheClassKey + "_GetList");
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectZjpfData> db = new ORMDataAccess<ProjectZjpfData>())
                {
                    list = db.Query<ProjectZjpfModel>("from ProjectZjpfModel");
                    
		    //if (WebKeys.EnableCaching)
           	    //{
                    ////���ݴ��뻺��ϵͳ
                    //CacheItemRefreshAction refreshAction =
                        //new CacheItemRefreshAction(typeof(ProjectZjpfData), false);
                    //refreshAction.ConstuctParms = null;
                    //refreshAction.MethodName = "GetList";
                    //refreshAction.Parameters = null;//new object[]{};
                    //CacheHelper.Add(CacheClassKey + "_GetList", list, refreshAction);
		    //}
                }
            }
            return list;
        }

        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<ProjectZjpfModel> GetListByHQL(string hql)
        {
            IList<ProjectZjpfModel> list = null;
            //if (WebKeys.EnableCaching)
            //{
                //list = (IList<ProjectZjpfModel>)CacheHelper.GetCache(CacheClassKey + "_GetListByHQL_" + hql);
            //}

            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectZjpfData> db = new ORMDataAccess<ProjectZjpfData>())
                {
			if (string.IsNullOrEmpty(hql))
			{
				list = db.Query<ProjectZjpfModel>("from ProjectZjpfModel");
			}
			else
			{
				list = db.Query<ProjectZjpfModel>(hql);
			}

			    //if (WebKeys.EnableCaching)
	           	    //{
	                    ////���ݴ��뻺��ϵͳ
	                    //CacheItemRefreshAction refreshAction =
	                        //new CacheItemRefreshAction(typeof(ProjectZjpfData), false);
	                    //refreshAction.ConstuctParms = null;
	                    //refreshAction.MethodName = "GetListByHQL";
	                    //refreshAction.Parameters = new object[]{ hql };
	                    //CacheHelper.Add(CacheClassKey + "_GetListByHQL_" + hql, list, refreshAction);
			    //}
                }
            }
            return list;
        }


	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ProjectZjpfModel> GetListBySQL(string sql)
        {
            IList<ProjectZjpfModel> list = null;
            if (list == null || list.Count == 0)
            {
                using (ORMDataAccess<ProjectZjpfData> db = new ORMDataAccess<ProjectZjpfData>())
                {
                    if (!string.IsNullOrEmpty(sql))
                    {
                        list = db.QueryBySQL<ProjectZjpfModel>(sql, typeof(ProjectZjpfModel));

                    }
                }
            }
            return list;
        }


        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ProjectZjpfModel model)
        {
            bool isResult = true;

            using (ORMDataAccess<ProjectZjpfData> db = new ORMDataAccess<ProjectZjpfData>())
            {
                if (model.DB_Option_Action == WebKeys.InsertAction)
                {
                    db.Insert(model);
                }
                else if (model.DB_Option_Action == WebKeys.UpdateAction)
                {
                    db.Update(model);
                }
                else if (model.DB_Option_Action == WebKeys.DeleteAction)
                {
                    db.Delete(model);
                }
            }

		if (WebKeys.EnableCaching)
		{
		    //�����صĻ���
		    CacheHelper.RemoveCacheForClassKey(CacheClassKey);
		}
            return isResult;
        }

        public void CreateZjpf(string[] bzid, string[] df, string projid, int userid,string crminfo)
        {
            using (ORMDataAccess<ProjectZjpfData> db = new ORMDataAccess<ProjectZjpfData>())
            {
                string sql = "begin ";
                sql+=" delete from APP_PROJECT_ZJPF where projid='"+projid+"' and submitter="+userid+" and crminfo='"+crminfo+"';";
                int i = 0;
                foreach (var id in bzid) {
                    if (!string.IsNullOrEmpty(id)) {
                        string f=df[i];
                        if(string.IsNullOrEmpty(f))
                            f="0";
                        sql += @"insert into APP_PROJECT_ZJPF (pfid,bzid,projid,submitter,pf,status,crminfo) 
                        values('"+Guid.NewGuid()+"','"+id+"','"+projid+"',"+userid+","+f+",-1,'"+crminfo+"');";
                    }
                    i++;
                }

                sql += "null;end;";
                db.ExecuteNonQuery(sql, null);
            }
        }

        public void CreateZjpf(string[] bzid, string[] df, string projid, int userid)
        {
            using (ORMDataAccess<ProjectZjpfData> db = new ORMDataAccess<ProjectZjpfData>())
            {
                string sql = "begin ";
                sql += " delete from APP_PROJECT_ZJPF where projid='" + projid + "' and submitter=" + userid + " ;";
                int i = 0;
                foreach (var id in bzid)
                {
                    if (!string.IsNullOrEmpty(id))
                    {
                        string f = df[i];
                        string[] bz_crm = id.Split('*');
                        if (string.IsNullOrEmpty(f))
                            f = "0";
                        sql += @"insert into APP_PROJECT_ZJPF (pfid,bzid,projid,submitter,pf,status,crminfo) 
                        values('" + Guid.NewGuid() + "','" + bz_crm[0] + "','" + projid + "'," + userid + "," + f + ",-1,'" + bz_crm[1] + "');";
                    }
                    i++;
                }

                sql += "null;end;";
                db.ExecuteNonQuery(sql, null);
            }
        }
        public void UpdZjpf(string projid, int userid, int status)
        {
            using (ORMDataAccess<ProjectZjpfData> db = new ORMDataAccess<ProjectZjpfData>())
            {
                string sql = "begin ";
                sql += " update APP_PROJECT_ZJPF set status="+status+" where projid='" + projid + "' and submitter=" + userid + " ;";   
                sql += "null;end;";
                db.ExecuteNonQuery(sql, null);
            }
        }


        #endregion
    }
}
