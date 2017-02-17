using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ������ȫ�����Ŀ
    /// ������:����������
    /// ����ʱ��:	2013/11/26 17:18:03
    /// </summary>
    [Serializable]
    public class ProjectQhsecheckitemModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///ITEM��ʶ
        /// </summary>
        public virtual string ITEMID
        {
            get;
            set;
        }

        /// <summary>
        /// ��������ID
        /// </summary>
        public virtual string ID
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual string CHECKCONTS
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string TYPENAME
        {
            get;
            set;
        }

        /// <summary>
        ///��ע
        /// </summary>
        public virtual string MEMO
        {
            get;
            set;
        }

        /// <summary>
        ///��׼��ֵ
        /// </summary>
        public virtual int? STANDARD
        {
            get;
            set;
        }

        /// <summary>
        ///�÷�
        /// </summary>
        public virtual decimal? SCORE
        {
            get;
            set;
        }

        #endregion
    }

}
