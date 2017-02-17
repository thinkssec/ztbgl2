using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Document
{
    /// <summary>
    /// �ĵ������ñ�
	/// ������:����������
	/// ����ʱ��:	2014/3/6 8:24:58
    /// </summary>
    [Serializable]
    public class DocumentConfigModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///����ID
			/// </summary>
			public virtual string PZID
			{
				get;
				set;
			}

			/// <summary>
            ///�Ƿ��ˮӡ 1=�� 0=��
			/// </summary>
			public virtual int? SFJSY
			{
				get;
				set;
			}

			/// <summary>
            ///�Ƿ��������� 1=�� 0=��
			/// </summary>
			public virtual int? SFYXXZ
			{
				get;
				set;
			}

			/// <summary>
            ///�Ƿ��Զ�ת�� 1=�� 0=��
			/// </summary>
			public virtual int? SFZDZH
			{
				get;
				set;
			}

			/// <summary>
			///���ؽ�ɫ�趨
			/// </summary>
			public virtual string XZJSSD
			{
				get;
				set;
			}

			/// <summary>
			///ˮӡ����
			/// </summary>
			public virtual string SYWZ
			{
				get;
				set;
			}

        #endregion
    }

}
