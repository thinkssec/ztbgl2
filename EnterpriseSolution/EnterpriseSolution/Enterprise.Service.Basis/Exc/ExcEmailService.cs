using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;

using Enterprise.Component.Infrastructure;
using Enterprise.Data.Basis.Exc;
using Enterprise.Model.Basis.Exc;

namespace Enterprise.Service.Basis.Exc
{
    /// <summary>
    /// �ļ���:  ExcEmailService.cs
    /// ��������: ҵ���߼���-�ʼ����ͱ����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:24
    /// </summary>
    public class ExcEmailService
    {

        /// <summary>
        /// �õ�δ�����EMAIL���ݷ�����ʵ��
        /// </summary>
        private static readonly IExcEmailData unhandleDal = new ExcEmailData();
        /// <summary>
        /// �õ��Ѵ����EMAIL���ݷ�����ʵ��
        /// </summary>
        private static readonly IExcHandleemailData handleDal = new ExcHandleemailData();

        #region δ����

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcEmailModel> GetUnhandleList()
        {
            return unhandleDal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteUnhandle(ExcEmailModel model)
        {
            return unhandleDal.Execute(model);
        }

        #endregion

        #region �Ѵ���

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcHandleemailModel> GetHandleList()
        {
            return handleDal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteHandle(ExcHandleemailModel model)
        {
            return handleDal.Execute(model);
        }

        #endregion
    }

}
