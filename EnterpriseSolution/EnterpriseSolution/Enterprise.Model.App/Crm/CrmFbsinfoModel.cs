using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Crm
{
    /// <summary>
    /// �ְ�����Ϣ��
	/// ������:����������
	/// ����ʱ��:	2013/12/11 11:28:03
    /// </summary>
    [Serializable]
    public class CrmFbsinfoModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�ְ���ID
			/// </summary>
			public virtual string FBSID
			{
				get;
				set;
			}

			/// <summary>
			///�ְ��̱��
			/// </summary>
			public virtual string FBSBH
			{
				get;
				set;
			}

			/// <summary>
			///ͨ�ŵ�ַ
			/// </summary>
			public virtual string TXDZ
			{
				get;
				set;
			}

			/// <summary>
			///�ְ�������
			/// </summary>
			public virtual string FBSZZ
			{
				get;
				set;
			}

			/// <summary>
			///�����г�����
			/// </summary>
			public virtual string SCQY
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string FJ
			{
				get;
				set;
			}

			/// <summary>
			///�ְ�������
			/// </summary>
			public virtual string FBSMC
			{
				get;
				set;
			}

			/// <summary>
			///��ҵ���
			/// </summary>
			public virtual string QYJJ
			{
				get;
				set;
			}

			/// <summary>
			///��ҵ����
			/// </summary>
			public virtual string QYLX
			{
				get;
				set;
			}

        #endregion
    }

}
