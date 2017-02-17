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
    /// �ļ���:  ZyglWgysService.cs
    /// ��������: ҵ���߼���-�깤�������ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2015/5/27 16:33:49
    /// </summary>
    public class ZyglWgysService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IZyglWgysData dal = new ZyglWgysData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ZyglWgysModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ����������ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ZyglWgysModel> GetListByHQL(string hql)
        {
            return dal.GetListByHQL(hql);
        }

	/// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public IList<ZyglWgysModel> GetListBySQL(string sql)
        {
            return dal.GetListBySQL(sql);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(ZyglWgysModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
