using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.App.Zygl;
using Enterprise.Model.App.Zygl;

namespace Enterprise.Service.App.Zygl
{
	
    /// <summary>
    /// �ļ���:  ZyglJsService.cs
    /// ��������: ҵ���߼���-��ҵ�������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/5/29 11:11:47
    /// </summary>
    public class ZyglJsService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IZyglJsData dal = new ZyglJsData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ZyglJsModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ZyglJsModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ZyglJsModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ZyglJsModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
