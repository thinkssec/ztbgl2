using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// ҵ����δ������Ϣ��
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:18:58
    /// </summary>
    [Serializable]
    public class BfUnhandledmsgModel : BasisSuperModel
    {

        #region ����������

        /// <summary>
        ///��ϢID
        /// </summary>
        public virtual string BF_MSGID
        {
            get;
            set;
        }

        /// <summary>
        ///�����˵�¼��
        /// </summary>
        public virtual string BF_SENDERNAME
        {
            get;
            set;
        }

        /// <summary>
        ///���˵��
        /// </summary>
        public virtual string BF_REMARK
        {
            get;
            set;
        }

        /// <summary>
        ///���б�ID
        /// </summary>
        public virtual string BF_RUNID
        {
            get;
            set;
        }

        /// <summary>
        ///��Ϣ����
        /// </summary>
        public virtual string BF_MSGTITLE
        {
            get;
            set;
        }

        /// <summary>
        ///�����˵�¼��
        /// </summary>
        public virtual string BF_RECIPIENTSNAME
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? BF_RECIPIENTS
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? BF_SENDER
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual DateTime? BF_DEALTIME
        {
            get;
            set;
        }

        /// <summary>
        ///ʵ����ɫ��ID
        /// </summary>
        public virtual string BF_INSTANCEROLEID
        {
            get;
            set;
        }

        /// <summary>
        ///��Ϣ����
        /// </summary>
        public virtual string BF_MSGTEXT
        {
            get;
            set;
        }

        /// <summary>
        ///��ȡ��־:0=δ�� 1=�Ѷ� -1=�û�������
        /// </summary>
        public virtual int? BF_ISREAD
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? BF_RESULT
        {
            get;
            set;
        }

        /// <summary>
        ///ҵ����������ID
        /// </summary>
        public virtual string BF_INSTANCEID
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual DateTime? BF_SENDTIME
        {
            get;
            set;
        }

        #endregion	

    }

}
