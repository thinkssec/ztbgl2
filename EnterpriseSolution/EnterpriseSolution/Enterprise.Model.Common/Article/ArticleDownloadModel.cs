using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Article
{
    /// <summary>
    /// �ĵ����ع���
	/// ������:����������
	/// ����ʱ��:	2013-5-16 17:44:16
    /// </summary>
    [Serializable]
    public class ArticleDownloadModel : CommonSuperModel
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
        ///�ļ�����
        /// </summary>
        public virtual string FILENAME
        {
            get;
            set;
        }

        /// <summary>
        ///��Ա�˺�
        /// </summary>
        public virtual string ULOGIN
        {
            get;
            set;
        }

        /// <summary>
        ///�ĵ�ID
        /// </summary>
        public virtual string ARTICLEID
        {
            get;
            set;
        }

        /// <summary>
        ///��ע
        /// </summary>
        public virtual string BZ
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual DateTime XZRQ
        {
            get;
            set;
        }

        /// <summary>
        ///IP��ַ
        /// </summary>
        public virtual string UIP
        {
            get;
            set;
        }

        #endregion
    }

}
