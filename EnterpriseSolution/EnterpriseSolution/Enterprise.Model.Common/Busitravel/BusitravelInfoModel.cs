using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// ���������
	/// ������:����������
	/// ����ʱ��:	2013-2-23 17:52:25
    /// </summary>
    [Serializable]
    public class BusitravelInfoModel : CommonSuperModel
    {
        #region ����������

        /// <summary>
        ///�Զ����
        /// </summary>
        public virtual string BID
        {
            get;
            set;
        }

        /// <summary>
        ///���ű��
        /// </summary>
        public virtual int? DEPTID
        {
            get;
            set;
        }

        /// <summary>
        ///�ر��г�
        /// </summary>
        public virtual int? BCLOSE
        {
            get;
            set;
        }

        /// <summary>
        ///���뵥����ʱ��
        /// </summary>
        public virtual DateTime? BCREATETIME
        {
            get;
            set;
        }

        /// <summary>
        ///��Ʊ����
        /// </summary>
        public virtual string BTICKETTYPE
        {
            get;
            set;
        }

        /// <summary>
        ///����·��
        /// </summary>
        public virtual string BLINE
        {
            get;
            set;
        }

        /// <summary>
        ///�û����
        /// </summary>
        public virtual int? USERID
        {
            get;
            set;
        }

        /// <summary>
        ///��ֹʱ��
        /// </summary>
        public virtual DateTime? BENDTIME
        {
            get;
            set;
        }

        /// <summary>
        ///����Ŀ�ĵ�
        /// </summary>
        public virtual string BDESTINATION
        {
            get;
            set;
        }

        /// <summary>
        ///�����б�
        /// </summary>
        public virtual string BCHECKERS
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string BSUBJECT
        {
            get;
            set;
        }

        /// <summary>
        ///�ر�ʱ��
        /// </summary>
        public virtual DateTime? BCLOSETIME
        {
            get;
            set;
        }

        /// <summary>
        ///���뵥״̬
        ///0=δ���� 1=����ͨ�� 2=������ͨ��
        ///3=�Ѱ���Ʊ�� 4=�г̹ر� 5=�г�ȡ��
        /// </summary>
        public virtual int BSTATE
        {
            get;
            set;
        }

        /// <summary>
        ///��ʼʱ��
        /// </summary>
        public virtual DateTime? BSTARTIME
        {
            get;
            set;
        }

        /// <summary>
        /// Ŀ�ĵ�����
        /// 0=���� 1=�й�
        /// </summary>
        public virtual int BDESTYPE
        {
            get;
            set;
        }
        
        #endregion
    }

}
