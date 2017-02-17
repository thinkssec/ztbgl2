using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// HSE��֯����
	/// ������:����������
	/// ����ʱ��:	2013/11/20 11:34:29
    /// </summary>
    [Serializable]
    public class ProjectHsezzjgModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///ID
			/// </summary>
			public virtual string ID
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
			///����
			/// </summary>
			public virtual string XM
			{
				get;
				set;
			}

			/// <summary>
			///ְ��
			/// </summary>
			public virtual string ZW
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
			///ְ��
			/// </summary>
			public virtual string ZZ
			{
				get;
				set;
			}

        #endregion
    }

}
