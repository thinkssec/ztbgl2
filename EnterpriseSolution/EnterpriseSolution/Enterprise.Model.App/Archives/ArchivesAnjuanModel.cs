using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Archives
{
    /// <summary>
    /// ����Ŀ¼��
    /// ������:����������
    /// ����ʱ��:	2014/2/7 13:50:44
    /// </summary>
    [Serializable]
    public class ArchivesAnjuanModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///����Ŀ¼ID
        /// </summary>
        public virtual string AJID
        {
            get;
            set;
        }

        /// <summary>
        ///����λ��
        /// </summary>
        public virtual string AJBCWZ
        {
            get;
            set;
        }

        /// <summary>
        ///���
        /// </summary>
        public virtual string AJND
        {
            get;
            set;
        }

        /// <summary>
        ///��ע
        /// </summary>
        public virtual string AJBZ
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual string AJDAH
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual int? AJQX
        {
            get;
            set;
        }

        /// <summary>
        ///�����
        /// </summary>
        public virtual string ARCLBBH
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual string AJTM
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual int? AJJS
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual string AJJDR
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual DateTime? AJJDRQ
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

        #endregion
    }

}
