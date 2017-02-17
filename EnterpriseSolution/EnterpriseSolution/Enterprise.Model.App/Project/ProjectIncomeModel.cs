using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ��ͬ����
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:20
    /// </summary>
    [Serializable]
    public class ProjectIncomeModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��ͬ���
			/// </summary>
			public virtual string CONTRACTID
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
