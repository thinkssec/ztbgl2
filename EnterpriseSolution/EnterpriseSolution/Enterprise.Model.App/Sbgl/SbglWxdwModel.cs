using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Sbgl
{
    /// <summary>
    /// �豸ά�޵�λ��Ϣ��
    /// ������:����������
    /// ����ʱ��:2015/4/28 15:01:25
    /// </summary>
    [Serializable]
    public class SbglWxdwModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///���ұ��
			/// </summary>
			public virtual string CJBH
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string CJMC
			{
				get;
				set;
			}

			/// <summary>
			///���ҵ�ַ
			/// </summary>
			public virtual string CJDZ
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string CJZZ
			{
				get;
				set;
			}

			/// <summary>
			///�����˻�
			/// </summary>
			public virtual string YHZH
			{
				get;
				set;
			}

			/// <summary>
			///��ϵ��
			/// </summary>
			public virtual string LXR
			{
				get;
				set;
			}

			/// <summary>
			///��ϵ��ʽ
			/// </summary>
			public virtual string LXFS
			{
				get;
				set;
			}

			/// <summary>
			///��ǰ״̬
			/// </summary>
			public virtual int? DQZT
			{
				get;
				set;
			}

			/// <summary>
			///�Ǽ�����
			/// </summary>
			public virtual DateTime? DJRQ
			{
				get;
				set;
			}

			/// <summary>
			///�Ǽ���
			/// </summary>
			public virtual string DJR
			{
				get;
				set;
			}

        #endregion
    }

}
