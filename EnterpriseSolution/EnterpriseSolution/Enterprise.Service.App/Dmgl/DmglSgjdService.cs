using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Dmgl;
using Enterprise.Model.App.Dmgl;

namespace Enterprise.Service.App.Dmgl
{
	
    /// <summary>
    /// �ļ���:  DmglSgjdService.cs
    /// ��������: ҵ���߼���-ʩ���������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/5/17 15:16:26
    /// </summary>
    public class DmglSgjdService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IDmglSgjdData dal = new DmglSgjdData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DmglSgjdModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<DmglSgjdModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<DmglSgjdModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(DmglSgjdModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
