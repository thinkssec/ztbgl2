using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Sys;
using Enterprise.Model.Basis.Sys;

namespace Enterprise.Service.Basis.Sys
{
	
    /// <summary>
    /// �ļ���:  SysUserindividService.cs
    /// ��������: ҵ���߼���-���Ի����ñ����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-7-3 11:42:29
    /// </summary>
    public class SysUserindividService
    {
        #region ����������
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly ISysUserindividData dal = new SysUserindividData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<SysUserindividModel> GetList()
        {
            return dal.GetList();
        }

        /// <summary>
        /// ��ȡָ��ID������
        /// </summary>
        /// <returns></returns>
        public SysUserindividModel GetModelById(int id)
        {
            return dal.GetModelById(id);
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Execute(SysUserindividModel model)
        {
            return dal.Execute(model);
        }
        #endregion
    }

}
