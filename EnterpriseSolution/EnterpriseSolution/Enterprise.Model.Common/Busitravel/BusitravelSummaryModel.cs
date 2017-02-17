using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// ����������ܱ�
    /// ������:����������
    /// ����ʱ��:	2013-6-24 20:24:42
    /// </summary>
    [Serializable]
    public class BusitravelSummaryModel : CommonSuperModel
    {
        #region ����������

        /// <summary>
        /// ID
        /// </summary>
        public virtual string BID
        {
            get;
            set;
        }

        /// <summary>
        ///�г̹ر�����
        /// </summary>
        public virtual DateTime? BCLOSE
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? BREQSNUM
        {
            get;
            set;
        }

        /// <summary>
        ///����ʱ��
        /// </summary>
        public virtual DateTime? BEND
        {
            get;
            set;
        }

        /// <summary>
        ///�г�ƾ֤
        /// </summary>
        public virtual string BILL
        {
            get;
            set;
        }

        /// <summary>
        ///Ŀ�ĵ�
        /// </summary>
        public virtual string BDESTINATION
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        ///0=���� 1=�й�
        /// </summary>
        public virtual int? BTYPE
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
        ///��������
        /// </summary>
        public virtual DateTime? BTRANSDATE
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? BREQUSER
        {
            get;
            set;
        }

        /// <summary>
        ///��׼����
        /// </summary>
        public virtual DateTime? BAPPROVEDATE
        {
            get;
            set;
        }

        /// <summary>
        ///��ʼʱ��
        /// </summary>
        public virtual DateTime? BSTART
        {
            get;
            set;
        }

        /// <summary>
        ///����������
        /// </summary>
        public virtual string BUSERNAME
        {
            get;
            set;
        }

        /// <summary>
        ///�г�״̬
        ///0=δ���� 1=����ͨ�� 2=������ͨ��
        ///3=�Ѱ���Ʊ�� 4=�г̹ر� 5=�г�ȡ��
        /// </summary>
        public virtual int? BSTATE
        {
            get;
            set;
        }

        /// <summary>
        ///Ʊ�������
        /// </summary>
        public virtual int? BTICKETUSER
        {
            get;
            set;
        }

        /// <summary>
        /// ��������
        /// </summary>
        public virtual int? BDAYS
        {
            get;
            set;
        }

        /// <summary>
        /// ������������
        /// </summary>
        public virtual int? BMAXDAYS
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

        /// <summary>
        /// ������λ
        /// </summary>
        public virtual int? BDEPTID
        {
            get;
            set;
        }


        #endregion

    }



    /// <summary>
    /// �������ͳ�Ʊ�
    /// ������:qw
    /// ����ʱ��:	2013-7-2
    /// </summary>
    [Serializable]
    public class BusitravelStatisModel
    {
        /// <summary>
        /// ��λID 
        /// </summary>
        public int DEPTID
        {
            get;
            set;
        }

        /// <summary>
        /// ��λ����
        /// </summary>
        public string DeptName
        {
            get;
            set;
        }

        /// <summary>
        /// ��ԱID 
        /// </summary>
        public int USERID
        {
            get;
            set;
        }

        /// <summary>
        /// ��Ա����
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// ��� 
        /// </summary>
        public int YEAR
        {
            get;
            set;
        }

        /// <summary>
        /// 1�³������� 
        /// </summary>
        public int JanuaryDays
        {
            get;
            set;
        }

        /// <summary>
        /// 2�³������� 
        /// </summary>
        public int FebruaryDays
        {
            get;
            set;
        }

        /// <summary>
        /// 3�³������� 
        /// </summary>
        public int MarchDays
        {
            get;
            set;
        }

        /// <summary>
        /// 4�³������� 
        /// </summary>
        public int AprilDays
        {
            get;
            set;
        }

        /// <summary>
        /// 5�³������� 
        /// </summary>
        public int MayDays
        {
            get;
            set;
        }

        /// <summary>
        /// 6�³������� 
        /// </summary>
        public int JuneDays
        {
            get;
            set;
        }

        /// <summary>
        /// 7�³������� 
        /// </summary>
        public int JulyDays
        {
            get;
            set;
        }

        /// <summary>
        /// 8�³������� 
        /// </summary>
        public int AugustDays
        {
            get;
            set;
        }

        /// <summary>
        /// 9�³������� 
        /// </summary>
        public int SeptemberDays
        {
            get;
            set;
        }

        /// <summary>
        /// 10�³������� 
        /// </summary>
        public int OctoberDays
        {
            get;
            set;
        }

        /// <summary>
        /// 11�³������� 
        /// </summary>
        public int NovemberDays
        {
            get;
            set;
        }

        /// <summary>
        /// 12�³������� 
        /// </summary>
        public int DecemberDays
        {
            get;
            set;
        }

        /// <summary>
        /// С�Ƴ�������
        /// </summary>
        public int TotalDays
        {
            get;
            set;
        }

    }

}
