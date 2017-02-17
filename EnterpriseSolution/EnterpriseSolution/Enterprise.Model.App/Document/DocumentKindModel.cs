using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Document
{
    /// <summary>
    /// �ĵ������
	/// ������:����������
	/// ����ʱ��:	2014/3/6 8:25:02
    /// </summary>
    [Serializable]
    public class DocumentKindModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///�����
			/// </summary>
			public virtual string LBBH
			{
				get;
				set;
			}

			/// <summary>
			///�������
			/// </summary>
			public virtual string LBMC
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string LBXH
			{
				get;
				set;
			}

			/// <summary>
			///�ϼ����
			/// </summary>
			public virtual string SJBH
			{
				get;
				set;
			}

        #endregion
    }

}
