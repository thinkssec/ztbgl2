using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Bf
{
    /// <summary>
    /// ҵ����������
	/// ������:����������
	/// ����ʱ��:	2013-2-4 12:18:49
    /// </summary>
    [Serializable]
    public class BfBaseModel : BasisSuperModel
    {
        
			/// <summary>
			///ҵ����ID
			/// </summary>
			public virtual string BF_ID
			{
				get;
				set;
			}

			/// <summary>
			///��������
			/// </summary>
			public virtual DateTime? BF_CDATE
			{
				get;
				set;
			}

			/// <summary>
			///��ǰ״̬:1=���� 0=����
			/// </summary>
			public virtual int? BF_STATUS
			{
				get;
				set;
			}

			/// <summary>
			///ҵ������
			/// </summary>
			public virtual string BF_TYPE
			{
				get;
				set;
			}

			/// <summary>
			///ҵ��������
			/// </summary>
			public virtual string BF_NAME
			{
				get;
				set;
			}


            //private IList<BfPublishModel> _basisBfPublishes = new List<BfPublishModel>();

            //public virtual IList<BfPublishModel> BfPublishes
            //{
            //    get { return _basisBfPublishes; }
            //    set { _basisBfPublishes = value; }
            //}

    }

}
