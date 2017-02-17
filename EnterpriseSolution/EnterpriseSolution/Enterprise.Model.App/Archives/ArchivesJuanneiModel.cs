using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Archives
{
    /// <summary>
    /// ����Ŀ¼��
    /// ������:����������
    /// ����ʱ��:	2014/2/7 13:50:45
    /// </summary>
    [Serializable]
    public class ArchivesJuanneiModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///����Ŀ¼ID
        /// </summary>
        public virtual string JNID
        {
            get;
            set;
        }

        /// <summary>
        ///�ļ�����
        /// </summary>
        public virtual string JNWJMC
        {
            get;
            set;
        }

        /// <summary>
        ///ҳ��
        /// </summary>
        public virtual int? JNYH
        {
            get;
            set;
        }

        /// <summary>
        ///��ע
        /// </summary>
        public virtual string JNBZ
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual DateTime? JNRQ
        {
            get;
            set;
        }

        /// <summary>
        ///����Ŀ¼ID
        /// </summary>
        public virtual string AJID
        {
            get;
            set;
        }

        /// <summary>
        ///��ص�λ
        /// </summary>
        public virtual string JNXGDW
        {
            get;
            set;
        }

        /// <summary>
        ///�ĺ�
        /// </summary>
        public virtual string JNWH
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual string JNFJ
        {
            get;
            set;
        }

        #endregion
    }

}
