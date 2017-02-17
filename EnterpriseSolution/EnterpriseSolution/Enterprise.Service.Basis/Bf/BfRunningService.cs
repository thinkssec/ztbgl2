using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Bf;
using Enterprise.Model.Basis.Bf;

namespace Enterprise.Service.Basis.Bf
{
    /// <summary>
    /// �ļ���:  BfRunningService.cs
    /// ��������: ҵ���߼���-ҵ�������б����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:18:58
    /// </summary>
    public class BfRunningService
    {

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IBfRunningData dal = new BfRunningData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<BfRunningModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ���������������ݼ���
        /// </summary>
        /// <param name="hql">HQL</param>
        /// <returns></returns>
        public IList<BfRunningModel> GetList(string hql)
        {
            return dal.GetList(hql);
        }

        /// <summary>
        /// ����ʵ��ID�������ݼ���
        /// </summary>
        /// <param name="instanceId">ʵ��ID</param>
        /// <returns></returns>
        public IList<BfRunningModel> GetListByInstanceId(string instanceId)
        {
            return dal.GetListByInstanceId(instanceId);
        }

         /// <summary>
        /// ����ID���ز�ѯ���
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public BfRunningModel GetModelById(string id)
        {
            return dal.GetModelById(id);
        }
        
        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(BfRunningModel model)
        {
            return dal.Execute(model);
        }

        /// <summary>
        /// ����������ѯ�������
        /// </summary>
        /// <param name="sql">ԭ��SQL</param>
        /// <returns></returns>
        public IList<BfRunningModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

    }

}
