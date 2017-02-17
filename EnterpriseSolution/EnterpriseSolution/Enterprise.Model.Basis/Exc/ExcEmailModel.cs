using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// �ʼ����ͱ�
    /// ������:����������
    /// ����ʱ��:	2013-2-4 12:19:23
    /// </summary>
    [Serializable]
    public class ExcEmailModel : BasisSuperModel
    {

        /// <summary>
        ///�ʼ�ID
        /// </summary>
        public virtual string EXC_EMAILID
        {
            get;
            set;
        }

        /// <summary>
        ///�ڵ�ID
        /// </summary>
        public virtual string EXC_NODEID
        {
            get;
            set;
        }

        /// <summary>
        ///����״̬:�ѷ���  δ����  ��ʧ��
        /// </summary>
        public virtual string EXC_SENDSTATUS
        {
            get;
            set;
        }

        /// <summary>
        ///��¼ID
        /// </summary>
        public virtual string EXC_RECORDID
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string EXC_SENDEMAIL
        {
            get;
            set;
        }

        /// <summary>
        ///����ʱ��
        /// </summary>
        public virtual DateTime? EXC_SENDTIME
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string EXC_EMAILMESSAGE
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual string EXC_SENDER
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string EXC_RECEIVEREMAIL
        {
            get;
            set;
        }

        /// <summary>
        ///�������
        /// </summary>
        public virtual string EXC_EMAILTITLE
        {
            get;
            set;
        }

        /// <summary>
        ///��������ID
        /// </summary>
        public virtual string EXC_OBJECTID
        {
            get;
            set;
        }

    }

}
