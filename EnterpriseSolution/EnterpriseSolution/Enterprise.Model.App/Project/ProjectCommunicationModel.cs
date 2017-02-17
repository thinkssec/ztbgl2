using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ��ͨ��¼��
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:14
    /// </summary>
    [Serializable]
    public class ProjectCommunicationModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��ͨ��¼ID
			/// </summary>
			public virtual string CMMCID
			{
				get;
				set;
			}

			/// <summary>
			///����
			/// </summary>
			public virtual string ATTACHEMENT
			{
				get;
				set;
			}

			/// <summary>
			///��¼��
			/// </summary>
			public virtual string RECORDER
			{
				get;
				set;
			}

			/// <summary>
			///��ͨ����
			/// </summary>
			public virtual string CMMCOBJECT
			{
				get;
				set;
			}

			/// <summary>
			///��ͨ����
			/// </summary>
			public virtual string CMMCTITLE
			{
				get;
				set;
			}

			/// <summary>
			///��¼ʱ��
			/// </summary>
			public virtual DateTime? RECORDDATE
			{
				get;
				set;
			}

			/// <summary>
			///��ͨ��ʽ
			/// </summary>
			public virtual string CMMCWAY
			{
				get;
				set;
			}

			/// <summary>
			///��ͨ����
			/// </summary>
			public virtual string CMMCCONT
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

        #endregion
    }

}
