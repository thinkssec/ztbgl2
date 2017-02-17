using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Article
{
    /// <summary>
    /// ���ı����ݱ�
    /// ������:����������
    /// ����ʱ��:	2014/2/7 13:50:48
    /// </summary>
    [Serializable]
    public class ArticleClobModel : CommonSuperModel
    {
        #region ����������

        /// <summary>
        ///�ı�ID
        /// </summary>
        public virtual string ARCID
        {
            get;
            set;
        }

        /// <summary>
        ///������������
        /// </summary>
        public virtual string ARCCONTENTOTHER
        {
            get;
            set;
        }

        /// <summary>
        ///����ID
        /// </summary>
        public virtual string ASSOCIATIONID
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string ARCCONTENTCN
        {
            get;
            set;
        }

        /// <summary>
        ///��ע˵��
        /// </summary>
        public virtual string ARCBZ
        {
            get;
            set;
        }

        #endregion
    }

}
