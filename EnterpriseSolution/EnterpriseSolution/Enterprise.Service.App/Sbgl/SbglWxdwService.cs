using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Sbgl;
using Enterprise.Model.App.Sbgl;

namespace Enterprise.Service.App.Sbgl
{

    /// <summary>
    /// �ļ���:  SbglWxdwService.cs
    /// ��������: ҵ���߼���-�豸ά�޵�λ��Ϣ�����ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2015/4/28 15:01:25
    /// </summary>
    public class SbglWxdwService
    {
        #region ����������

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ISbglWxdwData dal = new SbglWxdwData();

        /// <summary>
        /// ����������ȡΨһ��¼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SbglWxdwModel GetSingle(string key)
        {
            return dal.GetSingle(key);
        }

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SbglWxdwModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SbglWxdwModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<SbglWxdwModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SbglWxdwModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// ִ�л���SQL��ԭ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public bool ExecuteSQL(string sql)
        {
            return dal.ExecuteSQL(sql);
        }

        /// <summary>
        /// ��ָ���Ķ�������������ݼ��ϵĴ���
        /// </summary>
        /// <param name="lst">���ݼ���</param>
        /// <param name="actionName">��������</param>
        /// <returns></returns>
        public bool ExecuteListByAction(IList<SbglWxdwModel> lst, string actionName)
        {
            bool isResult = false;
            foreach (var q in lst)
            {
                if (actionName == WebKeys.InsertAction)
                {
                    q.DB_Option_Action = WebKeys.InsertAction;
                    isResult = Execute(q);
                }
                else if (actionName == WebKeys.UpdateAction)
                {
                    q.DB_Option_Action = WebKeys.UpdateAction;
                    isResult = Execute(q);
                }
                else if (actionName == WebKeys.DeleteAction)
                {
                    q.DB_Option_Action = WebKeys.DeleteAction;
                    isResult = Execute(q);
                }
            }
            return isResult;
        }

        #endregion

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="bm"></param>
        /// <returns></returns>
        public static string GetCjmcByBm(string bm)
        {
            var q = dal.GetList().FirstOrDefault(p=>p.CJBH == bm);
            return (q != null) ? q.CJMC : "";
        }
    }

}
