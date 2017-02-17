using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��ͬ����
    /// ������:����������
    /// ����ʱ��:	2013-11-5 15:48:15
    /// </summary>
    [Serializable]
    public class ProjectContractModel : AppSuperModel
    {
        #region ����������
            /// <summary>
			///��ͬID����
			/// </summary>
			public virtual string CONTRACTID
			{
				get;
				set;
			}

			/// <summary>
			///�ʽ���Դ
			/// </summary>
			public virtual string ZJLY
			{
				get;
				set;
			}

			/// <summary>
			///����ϵͳ���
			/// </summary>
			public virtual string ASSOCIATEDNUM
			{
				get;
				set;
			}

			/// <summary>
			///�ڲ���ͬ���ǻ��
			/// </summary>
			public virtual string NBHT
			{
				get;
				set;
			}

			/// <summary>
			///ǩ������
			/// </summary>
			public virtual DateTime? SIGNDATE
			{
				get;
				set;
			}

			/// <summary>
			///���첿��
			/// </summary>
			public virtual int? ZBBM
			{
				get;
				set;
			}

			/// <summary>
			///��ͬ�����0��1
			/// </summary>
			public virtual string HTBG
			{
				get;
				set;
			}

			/// <summary>
			///��ͬ����/��Ľ��
			/// </summary>
			public virtual decimal? TOTALINCOME
			{
				get;
				set;
			}

			/// <summary>
			///�ҷ�ǩԼ����
			/// </summary>
			public virtual int? QYDB
			{
				get;
				set;
			}

			/// <summary>
			///�ܽ�Ԫ��
			/// </summary>
			public virtual decimal? ZJE
			{
				get;
				set;
			}

			/// <summary>
			///��ͬ����
			/// </summary>
			public virtual string CONTRACTNAME
			{
				get;
				set;
			}

			/// <summary>
			///�깤����
			/// </summary>
			public virtual DateTime? COMPLETEDATE
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string BZ
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
			///�ѽ�����
			/// </summary>
			public virtual decimal? YJJE
			{
				get;
				set;
			}

			/// <summary>
			///�ƻ����
			/// </summary>
			public virtual decimal? JHJE
			{
				get;
				set;
			}

			/// <summary>
			///�����
			/// </summary>
			public virtual string XDR
			{
				get;
				set;
			}

			/// <summary>
			///��ͬת��
			/// </summary>
			public virtual string HTZR
			{
				get;
				set;
			}

			/// <summary>
			///���ս�
			/// </summary>
			public virtual string DZJ
			{
				get;
				set;
			}

			/// <summary>
			///������Ŀ
			/// </summary>
			public virtual string SSXM
			{
				get;
				set;
			}

			/// <summary>
			///��ͬ���
			/// </summary>
			public virtual string HTXH
			{
				get;
				set;
			}

			/// <summary>
			///ʣ����
			/// </summary>
			public virtual decimal? SYJE
			{
				get;
				set;
			}

			/// <summary>
			///��ǰ������
			/// </summary>
			public virtual string DQBLR
			{
				get;
				set;
			}

			/// <summary>
			///�����׶�
			/// </summary>
			public virtual string SSJD
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? ZBSJ
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual int? JSCS
			{
				get;
				set;
			}

			/// <summary>
			///�������ף��ǻ��
			/// </summary>
			public virtual string GLJY
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string JBR
			{
				get;
				set;
			}

			/// <summary>
			///��ͬ��ֹ
			/// </summary>
			public virtual string HTZZ
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string SSHJ
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual DateTime? BASJ
			{
				get;
				set;
			}

			/// <summary>
			///��λ����
			/// </summary>
			public virtual string DWGS
			{
				get;
				set;
			}

			/// <summary>
			///�ʽ�����
			/// </summary>
			public virtual string ZJLX
			{
				get;
				set;
			}

			/// <summary>
			///��ͬ���
			/// </summary>
			public virtual string HTLB
			{
				get;
				set;
			}


        #endregion


        #region �Զ���

        /// <summary>
        ///��Ŀ��ͬ����
        /// </summary>
        public virtual decimal? INCOMEVALUE
        {
            get;
            set;
        }

        #endregion
    }

}
