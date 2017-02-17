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
    /// �ļ���:  ExcMessageService.cs
    /// ��������: ҵ���߼���-��ʱ��Ϣ���ͱ����ݴ���
    /// �����ˣ�����������
	/// ����ʱ�� ��2013-2-4 12:19:28
    /// </summary>
    public class ExcMessageService
    {

        #region δ����
        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExcMessageData unhandleDal = new ExcMessageData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcMessageModel> GetUnhandleList()
        {
            return unhandleDal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteUnhandle(ExcMessageModel model)
        {
            return unhandleDal.Execute(model);
        }
        #endregion

        #region �Ѵ���

        /// <summary>
        /// �õ����ݷ�����ʵ��
        /// </summary>
        private static readonly IExcHandlemessageData handleDal = new ExcHandlemessageData();

        /// <summary>
        /// ��ȡ���ݼ���
        /// </summary>
        /// <returns></returns>
        public IList<ExcHandlemessageModel> GetHandleList()
        {
            return handleDal.GetList();
        }

        /// <summary>
        /// ִ����ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool ExecuteHandle(ExcHandlemessageModel model)
        {
            return handleDal.Execute(model);
        }

        #endregion
    }

}
