using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Article
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2013/2/28 10:54:44
    /// </summary>
    [Serializable]
    public class ArticleRecevieModel : CommonSuperModel
    {
        #region ����������

        /// <summary>
        ///  �Զ����
        /// </summary>
        public virtual string RECEVIEID
        {
            get;
            set;
        }

        /// <summary>
        /// ǩ��ʱ��
        /// </summary>
        public virtual DateTime? RDATETIME
        {
            get;
            set;
        }

        /// <summary>
        ///  ǩ����
        /// </summary>
        public virtual int? RUSERID
        {
            get;
            set;
        }

        /// <summary>
        ///  �������±��
        /// </summary>
        public virtual string INFOID
        {
            get;
            set;
        }

        #endregion
    }

}
