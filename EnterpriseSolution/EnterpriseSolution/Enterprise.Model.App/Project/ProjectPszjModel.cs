using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ����ר��
	/// ������:����������
	/// ����ʱ��:	2015/7/3 18:03:12
    /// </summary>
    [Serializable]
    public class ProjectPszjModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///
			/// </summary>
			public virtual string ZID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PROJID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PERSONID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual int? DEPTID
			{
				get;
				set;
			}

			/// <summary>
			///
			/// </summary>
			public virtual string PERSONNAME
			{
				get;
				set;
			}

			/// <summary>
			///1��ί�鳤 2��������
			/// </summary>
			public virtual string ROLE
			{
				get;
				set;
			}

			/// <summary>
			///1:������ί2������ί 3������ί  5:������Ա 6���ල��Ա
			/// </summary>
			public virtual int? LB
			{
				get;
				set;
			}

			/// <summary>
			///-1��ʱ���棬0�ύ
			/// </summary>
			public virtual int? STATUS
			{
				get;
				set;
			}

        #endregion
    }

}
