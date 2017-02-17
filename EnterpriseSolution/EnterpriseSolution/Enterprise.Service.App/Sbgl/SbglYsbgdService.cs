using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Sbgl;
using Enterprise.Model.App.Sbgl;
using System.Data;

namespace Enterprise.Service.App.Sbgl
{
	
    /// <summary>
    /// �ļ���:  SbglYsbgdService.cs
    /// ��������: ҵ���߼���-�豸ά����Ŀ���ձ��浥���ݴ���
    /// �����ˣ�����������
    /// ����ʱ�� ��2015/4/30 8:22:37
    /// </summary>
    public class SbglYsbgdService
    {
        #region ����������

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ISbglYsbgdData dal = new SbglYsbgdData();

        /// <summary>
        /// ����������ȡΨһ��¼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public SbglYsbgdModel GetSingle(string key)
        {
            return dal.GetSingle(key);
        }

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SbglYsbgdModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SbglYsbgdModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<SbglYsbgdModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SbglYsbgdModel model)
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
        public bool ExecuteListByAction(IList<SbglYsbgdModel> lst, string actionName)
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


        /// <summary>
        /// ��ȡ��ѯ���ݼ�
        /// </summary>
        /// <param name="sql">SQL</param>
        /// <returns></returns>
        public DataTable GetDataTable(string sql)
        {
            return dal.GetDataTable(sql);
        }

        #endregion

        #region �Զ��巽����

        /// <summary>
        /// ���ݽ������ڽ��в�ѯ
        /// </summary>
        /// <param name="yy">��</param>
        /// <param name="mm">��</param>
        /// <returns></returns>
        public IList<SbglYsbgdModel> GetListByJFRQ(string yy, string mm)
        {
            string hql = "from SbglYsbgdModel c where 1=1 ";
            if (string.IsNullOrEmpty(mm))
            {
                hql += " and to_char(c.JFRQ,'yyyy')='" + string.Format("{0}", yy) + "' ";
            }
            else
            {
                hql += " and to_char(c.JFRQ,'yyyy-MM')='" + string.Format("{0}-{1}", yy, mm) + "' ";
            }
            return GetListByHQL(hql);
        }


        /// <summary>
        /// �������ձ������Ž��в�ѯ
        /// </summary>
        /// <param name="wxph">����</param>
        /// <returns></returns>
        public IList<SbglYsbgdModel> GetListByYsbgdph(string ph)
        {
            string hql = "from SbglYsbgdModel c where c.BGDPH='" + ph + "' order by c.BGDPH";
            return GetListByHQL(hql);
        }

        /// <summary>
        /// ��ȡͼ���õ����ݴ�
        /// </summary>
        /// <param name="chartType">ͼ������</param>
        /// <param name="yy">��</param>
        /// <param name="mm">��</param>
        /// <returns></returns>
        public string GetChartData(string chartType, string yy, string mm)
        {
            StringBuilder sb = new StringBuilder();
            string sql = string.Empty;
            if (chartType == "SBLX")
            {
                sql = "select b.sblx,sum(a.sbzj) from app_sbgl_ysbgd a, app_sbgl_wxjhb b where a.jhbid=b.jhbid and a.shzt='1' ";
                if (string.IsNullOrEmpty(mm))
                {
                    sql += " and to_char(a.JFRQ,'yyyy')='" + string.Format("{0}", yy) + "' ";
                }
                else
                {
                    sql += " and to_char(a.JFRQ,'yyyy-MM')='" + string.Format("{0}-{1}", yy, mm) + "' ";
                }
                sql += " group by b.sblx ";
                DataTable dt = GetDataTable(sql);
                sb.Append("����ͳ��ͼ(���豸����)\r\n");
                string key = string.Empty;
                string value = string.Empty;
                foreach (DataRow row in dt.Rows)
                {
                    ////sb.Append("����\t�Ϻ�\t����\t����\t����\t���\t����\r\n");
                    ////sb.Append("130\t33\t312\t134\t290\t90\t122");
                    key += row[0].ToRequestString() + "\t";
                    value += row[1].ToRequestString() + "\t";
                }
                sb.Append(key.TrimEnd("\t".ToCharArray()) + "\r\n");
                sb.Append(value.TrimEnd("\t".ToCharArray()));
            }
            else if (chartType == "SYDW")
            {
                sql = "select c.dname,sum(a.sbzj) from app_sbgl_ysbgd a, app_sbgl_wxjhb b,basis_sys_department c "
                    + " where a.jhbid=b.jhbid and b.sbsydw=c.deptid and a.shzt='1' ";
                if (string.IsNullOrEmpty(mm))
                {
                    sql += " and to_char(a.JFRQ,'yyyy')='" + string.Format("{0}", yy) + "' ";
                }
                else
                {
                    sql += " and to_char(a.JFRQ,'yyyy-MM')='" + string.Format("{0}-{1}", yy, mm) + "' ";
                }
                sql += " group by c.dname ";
                DataTable dt = GetDataTable(sql);
                sb.Append("����ͳ��ͼ(��ʹ�õ�λ)\r\n");
                string key = string.Empty;
                string value = string.Empty;
                foreach (DataRow row in dt.Rows)
                {
                    ////sb.Append("����\t�Ϻ�\t����\t����\t����\t���\t����\r\n");
                    ////sb.Append("130\t33\t312\t134\t290\t90\t122");
                    key += row[0].ToRequestString() + "\t";
                    value += row[1].ToRequestString() + "\t";
                }
                sb.Append(key.TrimEnd("\t".ToCharArray()) + "\r\n");
                sb.Append(value.TrimEnd("\t".ToCharArray()));
            }
            return sb.ToString();
        }

        #endregion

    }

}
