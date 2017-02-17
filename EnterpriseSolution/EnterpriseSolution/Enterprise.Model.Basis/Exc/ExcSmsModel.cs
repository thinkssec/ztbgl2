using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Exc
{
    /// <summary>
    /// ���ŷ��ͱ�
    /// ������:����������
    /// ����ʱ��:	2013-2-4 12:19:28
    /// </summary>
    [Serializable]
    public class ExcSmsModel : BasisSuperModel
    {

        /// <summary>
        ///��ϢID
        /// </summary>
        public virtual string EXC_SMSID
        {
            get;
            set;
        }

        /// <summary>
        ///���պ���
        /// </summary>
        public virtual string EXC_RECEIVENUM
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
        ///��Ϣ����
        /// </summary>
        public virtual string EXC_MSGTEXT
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
        ///������
        /// </summary>
        public virtual string EXC_SENDER
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
