using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Sbgl;
using Enterprise.Model.App.Sbgl;
using Enterprise.Service.Basis.Sys;

namespace Enterprise.Service.App.Sbgl
{
	
    /// <summary>
    /// �ļ���:  SbglWxjhbService.cs
    /// ��������: ҵ���߼���-�豸ά�޼ƻ������ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2015/4/30 8:22:37
    /// </summary>
    public class SbglWxjhbService
    {
        #region ����������

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ISbglWxjhbData dal = new SbglWxjhbData();

        /// <summary>
        /// ����������ȡΨһ��¼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SbglWxjhbModel GetSingle(string key)
        {
            return dal.GetSingle(key);
        }

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SbglWxjhbModel model)
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
        public bool ExecuteListByAction(IList<SbglWxjhbModel> lst, string actionName)
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
        /// ������˺����ڽ��в�ѯ
        /// </summary>
        /// <param name="yy">��</param>
        /// <param name="mm">��</param>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetListByTbrAndTbrq(string yy, string mm)
        {
            string hql = "from SbglWxjhbModel c where c.TBR='" + SysUserService.GetUserName(Utility.Get_UserId) + "' ";
            if (string.IsNullOrEmpty(mm))
            {
                hql += " and to_char(c.TBRQ,'yyyy')='" + string.Format("{0}", yy) + "' ";
            }
            else
            {
                hql += " and to_char(c.TBRQ,'yyyy-MM')='" + string.Format("{0}-{1}", yy, mm) + "' ";
            }
            return GetListByHQL(hql);
        }


        /// <summary>
        /// �����������ڽ��в�ѯ
        /// </summary>
        /// <param name="yy">��</param>
        /// <param name="mm">��</param>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetListBySXRQ(string yy, string mm)
        {
            string hql = "from SbglWxjhbModel c where 1=1 ";
            if (string.IsNullOrEmpty(mm))
            {
                hql += " and to_char(c.SXRQ,'yyyy')='" + string.Format("{0}", yy) + "' ";
            }
            else
            {
                hql += " and to_char(c.SXRQ,'yyyy-MM')='" + string.Format("{0}-{1}", yy, mm) + "' ";
            }
            return GetListByHQL(hql);
        }


        /// <summary>
        /// ����ά�����Ž��в�ѯ
        /// </summary>
        /// <param name="wxph">ά������</param>
        /// <returns></returns>
        public IList<SbglWxjhbModel> GetListBySbwxph(string wxph)
        {
            string hql = "from SbglWxjhbModel c where c.SBWXPH='" + wxph + "' order by c.SBBH";
            return GetListByHQL(hql);
        }

    }

}
