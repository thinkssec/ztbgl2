using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// ��ɫ��ȡ������
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:18:51
    /// </summary>
    [Serializable]
    public class BfClsmethodsModel : BasisSuperModel
    {
        
			/// <summary>
			///������ID
			/// </summary>
			public virtual string BF_CLSID
			{
				get;
				set;
			}

			/// <summary>
			///������
			/// </summary>
			public virtual string BF_CLSNAME
			{
				get;
				set;
			}

			/// <summary>
			///����˵��
			/// </summary>
			public virtual string BF_METHODDESC
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual string BF_METHOD
			{
				get;
				set;
			}

    }

}
