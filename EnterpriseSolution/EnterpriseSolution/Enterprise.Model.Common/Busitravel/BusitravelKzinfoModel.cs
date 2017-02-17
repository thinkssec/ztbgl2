using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// �����������뵥
    /// ������:����������
    /// ����ʱ��:	2013-6-24 20:24:40
    /// </summary>
    [Serializable]
    public class BusitravelKzinfoModel : CommonSuperModel
    {
        #region ����������

        /// <summary>
        ///BID
        /// </summary>
        public virtual string BID
        {
            get;
            set;
        }

        /// <summary>
        ///���벿��
        /// </summary>
        public virtual int? DEPTID
        {
            get;
            set;
        }

        /// <summary>
        ///פ������ʱ��
        /// </summary>
        public virtual DateTime? STAYEND
        {
            get;
            set;
        }

        /// <summary>
        ///�г̷�ʽ
        /// </summary>
        public virtual string AIRTICKET
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? USERID
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual int? PEOPLENUM
        {
            get;
            set;
        }

        /// <summary>
        ///��פ�Ƶ�����
        /// </summary>
        public virtual string HOTELNAME
        {
            get;
            set;
        }

        /// <summary>
        ///ȡ���г�����
        /// </summary>
        public virtual DateTime? BCLOSEDATE
        {
            get;
            set;
        }

        /// <summary>
        ///פ����ʼʱ��
        /// </summary>
        public virtual DateTime? STAYSTART
        {
            get;
            set;
        }

        /// <summary>
        ///Ŀ�ĵ�
        /// </summary>
        public virtual string DESTINATION
        {
            get;
            set;
        }

        /// <summary>
        ///�Ƶ귿������
        /// </summary>
        public virtual string ROOMTYPE
        {
            get;
            set;
        }

        /// <summary>
        ///��Ʊ����
        /// </summary>
        public virtual string CATEGORY
        {
            get;
            set;
        }

        /// <summary>
        ///���ʽ
        /// </summary>
        public virtual string PAYMENT
        {
            get;
            set;
        }

        /// <summary>
        ///����Ŀ��
        /// </summary>
        public virtual string PURPOSE
        {
            get;
            set;
        }

        /// <summary>
        ///;���ص�
        /// </summary>
        public virtual string ONROUTE
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual DateTime? APPLDATED
        {
            get;
            set;
        }

        /// <summary>
        ///����״̬
        ///0=δ���� 1=����ͨ�� 2=������ͨ��
        ///3=�Ѱ���Ʊ�� 4=�г̹ر� 5=�г�ȡ��
        /// </summary>
        public virtual int? BSTATE
        {
            get;
            set;
        }

        /// <summary>
        ///���ͷ�ʽ
        /// </summary>
        public virtual string TRANSFER
        {
            get;
            set;
        }

        /// <summary>
        /// ����������
        /// </summary>
        public virtual string BLANG
        {
            get;
            set;
        }

        #endregion
    }

}
