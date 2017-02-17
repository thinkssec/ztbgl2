using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// ҵ�����ڵ��
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:18:56
    /// </summary>
    [Serializable]
    public class BfNodesModel : BasisSuperModel
    {
        
			/// <summary>
			///��ǰ�ڵ���
			/// </summary>
			public virtual string BF_NODEID
			{
				get;
				set;
			}

			/// <summary>
			///ҵ����ID
			/// </summary>
			public virtual string BF_ID
			{
				get;
				set;
			}

			/// <summary>
			///ҵ�����汾
			/// </summary>
			public virtual int BF_VERSION
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ�����
			/// </summary>
			public virtual string BF_NODENAME
			{
				get;
				set;
			}

			/// <summary>
			///ȱʡ�������
			/// </summary>
			public virtual string BF_AUDITOPINION
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ�����
			/// </summary>
			public virtual string BF_NODEDESC
			{
				get;
				set;
			}

			/// <summary>
			///��֧�ڵ���ת����:0=���� 1=��ѡһ
			/// </summary>
			public virtual int? BF_FLOWTYPE1
			{
				get;
				set;
			}

			/// <summary>
			///�����̽ڵ���ת����:1=����ģʽ 0=����ģʽ
			/// </summary>
			public virtual int? BF_FLOWTYPE2
			{
				get;
				set;
			}

			/// <summary>
			///������ҵ����ID
			/// </summary>
			public virtual string SUB_BF_ID
			{
				get;
				set;
			}

			/// <summary>
			///��Ͻڵ���ת����:0=�ȴ����з�֧��ת���� 1=�ȴ�һ����֧��ת����
			/// </summary>
			public virtual int? BF_FLOWTYPE3
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ��Ӧ��
            ///��Modules��ʼ��ȫ·��
			/// </summary>
			public virtual string BF_FORM
			{
				get;
				set;
			}

			/// <summary>
			///���ڴ���ʽ:0=������  1=������һ�ڵ�  2=ת�����˴���
			/// </summary>
			public virtual int? BF_EXTENDEDTREATMENT
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ�����
			/// </summary>
			public virtual string BF_NODETYPE
			{
				get;
				set;
			}

			/// <summary>
			///������ҵ�����汾
			/// </summary>
			public virtual int? SUB_BF_VERSION
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ����ֵ
			/// </summary>
			public virtual int? BF_PROGRESSVALUE
			{
				get;
				set;
			}

			/// <summary>
			///�Ƿ��������
			/// </summary>
			public virtual int? BF_COMMISSION
			{
				get;
				set;
			}

			/// <summary>
			///�Ƿ�֧�ֻ���
			/// </summary>
			public virtual int? BF_FORWARD
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ������
			/// </summary>
			public virtual string BF_DUTYOFFICER
			{
				get;
				set;
			}

			/// <summary>
			///�Ƿ�Ϊ�ؼ��ڵ�
			/// </summary>
			public virtual int? BF_KEYPOINT
			{
				get;
				set;
			}

			/// <summary>
			///����ʱ��
			/// </summary>
			public virtual int? BF_TIMELIMIT
			{
				get;
				set;
			}

			/// <summary>
			///�ڵ�֪ͨ��
			/// </summary>
			public virtual string BF_NOTIFIER
			{
				get;
				set;
			}

			/// <summary>
			///�Ƿ�Ϊ�����쳣���Ƶ�
			/// </summary>
			public virtual int? BF_CONTROLPOINT
			{
				get;
				set;
			}

			/// <summary>
			///��Ϣ���ѷ�ʽ:SMS MSG EMAIL
			/// </summary>
			public virtual string BF_REMINDWAY
			{
				get;
				set;
            }


            #region �����������

            /// <summary>
            /// ҵ����������--����ʵ��  
            /// </summary>
            public virtual BfPublishModel BfPublish { get; set; }

            ///// <summary>
            ///// ҵ�����ڵ��ɫ����
            ///// </summary>
            //public virtual IList<BfNoderolesModel> BfNoderoles
            //{
            //    get;
            //    set;
            //}

            #endregion

    }

}
