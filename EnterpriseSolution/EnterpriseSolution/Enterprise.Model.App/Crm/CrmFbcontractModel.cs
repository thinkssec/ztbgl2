using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// �ְ���ͬ��
    /// ������:����������
    /// ����ʱ��:	2013/12/11 11:28:00
    /// </summary>
    [Serializable]
    public class CrmFbcontractModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///�ְ���ͬID
        /// </summary>
        public virtual string FBHTID
        {
            get;
            set;
        }

        /// <summary>
        ///�ְ���ͬ����
        /// </summary>
        public virtual string HTFJ
        {
            get;
            set;
        }

        /// <summary>
        ///��ͬ�ְ���
        /// </summary>
        public virtual string HTFBS
        {
            get;
            set;
        }

        /// <summary>
        ///��ͬ��������
        /// </summary>
        public virtual DateTime? HTJSRQ
        {
            get;
            set;
        }

        /// <summary>
        ///��ͬ���
        /// </summary>
        public virtual string HTBH
        {
            get;
            set;
        }

        /// <summary>
        ///��ͬ״̬:0=δ��� 1=���ͨ�� 2=��˲�ͨ��
        /// </summary>
        public virtual int? HTZT
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual DateTime? JBRQ
        {
            get;
            set;
        }

        /// <summary>
        ///����ϵͳID
        /// </summary>
        public virtual string GLXTID
        {
            get;
            set;
        }

        /// <summary>
        ///��ͬ��ʼ����
        /// </summary>
        public virtual DateTime? HTQSRQ
        {
            get;
            set;
        }

        /// <summary>
        ///��ͬ���
        /// </summary>
        public virtual decimal HTJE
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? JBR
        {
            get;
            set;
        }

        /// <summary>
        ///�ְ���ϵ��ID
        /// </summary>
        public virtual string PERID
        {
            get;
            set;
        }

        /// <summary>
        ///��ͬ����
        /// </summary>
        public virtual string FBHTNAME
        {
            get;
            set;
        }

        #endregion
    }

}
