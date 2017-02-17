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
    /// �ļ���:  ExcSmsService.cs
    /// ��������: ҵ���߼���-���ŷ��ͱ����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:29
    /// </summary>
    public class ExcSmsService
    {

        #region δ����
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExcSmsData unhandleDal = new ExcSmsData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcSmsModel> GetUnhandleList()
        {
            return unhandleDal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteUnhandle(ExcSmsModel model)
        {
            return unhandleDal.Execute(model);
        }

        #endregion

        #region �Ѵ���

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExcHandlesmsData handleDal = new ExcHandlesmsData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcHandlesmsModel> GetHandleList()
        {
            return handleDal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteHandle(ExcHandlesmsModel model)
        {
            return handleDal.Execute(model);
        }

        #endregion


    }

}
