using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Ui;
using Enterprise.Model.App.Ui;

namespace Enterprise.Service.App.Ui
{
	
    /// <summary>
    /// �ļ���:  UiDefaultService.cs
    /// ��������: ҵ���߼���-���ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013/12/3 13:48:42
    /// </summary>
    public class UiDefaultService
    {
                

        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IUiDefaultData dal = new UiDefaultData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<UiDefaultModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<UiDefaultModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<UiDefaultModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(UiDefaultModel model)
        {
            return dal.Execute(model);
        }
        #endregion

        public UiDefaultModel GetListById(string Id)
        {
            return dal.GetListByHQL("from UiDefaultModel where DefaultID='"+Id+"'").FirstOrDefault();
        }

        public UiDefaultModel GetListByRoleId(string RoleId)
        {
            return dal.GetListByHQL("from UiDefaultModel where ROLEID='" + RoleId + "'").FirstOrDefault();
        }

        /// <summary>
        /// ���ݽ�ɫ���ϻ�ȡ����
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public IList<UiDefaultModel> GetListByRoles(IList<int> roles)
        {
            return dal.GetListByHQL("from UiDefaultModel where roleid in ("+ roles.ToJoin(',')+")");
        }

        /// <summary>
        /// ���ݽ�ɫ���ϻ�ȡ�����û����Ƶ�����
        /// </summary>
        /// <param name="roles"></param>
        /// <returns></returns>
        public IList<string> GetListUserTabIndexByRoles(IList<int> roles)
        {
            List<string> rtnList = new List<string>();
            IList<UiDefaultModel> list = dal.GetListByHQL("from UiDefaultModel where roleid in (" + roles.ToJoin(',') + ")");
            foreach (var q in list)
            {
                if (q.UICONTENT != "")
                {
                    rtnList.AddRange(q.UICONTENT.Split(','));
                }                
            }
            //ȥ���ظ�����
            return rtnList.Distinct().ToList();
        }
    }

}
