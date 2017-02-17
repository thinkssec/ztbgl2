using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ʒ��֤֤��Ǽ�


	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:17
    /// </summary>
    [Serializable]
    public class ProjectCprzzsModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��Ʒ��֤ID
			/// </summary>
			public virtual string CPRZID
			{
				get;
				set;
			}

			/// <summary>
			///���赥λ
			/// </summary>
			public virtual string SYDW
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? SPR
			{
				get;
				set;
			}

			/// <summary>
			///֤������
			/// </summary>
			public virtual string ZSMC
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual int? BZR
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string SHYJG
			{
				get;
				set;
			}

			/// <summary>
			///�䷢����
			/// </summary>
			public virtual DateTime? BFRQ
			{
				get;
				set;
			}

			/// <summary>
			///У����
			/// </summary>
			public virtual int? JDR
			{
				get;
				set;
			}

			/// <summary>
			///�����
			/// </summary>
			public virtual int? SHR
			{
				get;
				set;
			}

			/// <summary>
			///֤����
			/// </summary>
			public virtual string ZSBH
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
			///֤������
			/// </summary>
			public virtual string ZSNR
			{
				get;
				set;
			}

			/// <summary>
			///��ĿID
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///�����÷�
			/// </summary>
			public virtual decimal? ZLDF
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string SHYJ
			{
				get;
				set;
			}

            /// <summary>
            ///��ǰ״̬��0=δ��� 1=���ͨ��  2=��˲�ͨ��
            /// </summary>
            public virtual int? PRTSTATUS
            {
                get;
                set;
            }

            /// <summary>
            ///�ύ��
            /// </summary>
            public virtual int? SUBMITTER
            {
                get;
                set;
            }

        #endregion
    }

}
