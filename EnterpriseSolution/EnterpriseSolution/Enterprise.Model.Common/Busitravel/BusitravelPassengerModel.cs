using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Busitravel
{
    /// <summary>
    /// �����Ա��
    /// ������:����������
    /// ����ʱ��:	2013-6-24 20:24:41
    /// </summary>
    [Serializable]
    public class BusitravelPassengerModel : CommonSuperModel
    {
        #region ����������

        /// <summary>
        ///BID
        /// </summary>
        public virtual string BID
        {
            get;
            set;
        }

        /// <summary>
        /// �˿���ϵͳ���û�ID
        /// </summary>
        public virtual int USERID
        {
            get;
            set;
        }

        /// <summary>
        ///����˵��
        /// </summary>
        public virtual string ADDITION
        {
            get;
            set;
        }

        /// <summary>
        ///���ձ��
        /// </summary>
        public virtual string PASSPORT
        {
            get;
            set;
        }

        /// <summary>
        ///��Ա����
        /// </summary>
        public virtual string PASSENGER
        {
            get;
            set;
        }

        #endregion
    }

}
