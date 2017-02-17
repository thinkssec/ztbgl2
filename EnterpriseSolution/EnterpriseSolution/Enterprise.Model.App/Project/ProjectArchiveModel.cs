using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ���ϴ浵��
    /// ������:����������
    /// ����ʱ��:	2013-11-5 15:48:13
    /// </summary>
    [Serializable]
    public class ProjectArchiveModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///���ϱ�ID
        /// </summary>
        public virtual string ARCHIVEID
        {
            get;
            set;
        }

        /// <summary>
        ///�˶���
        /// </summary>
        public virtual int? CHECKER
        {
            get;
            set;
        }

        /// <summary>
        ///�������
        /// </summary>
        public virtual string ARCHIVEMEDIA
        {
            get;
            set;
        }

        /// <summary>
        ///�ύʱ��
        /// </summary>
        public virtual DateTime? SUBMITDATE
        {
            get;
            set;
        }

        /// <summary>
        ///�ĵ�����
        /// </summary>
        public virtual string ARCHIVENAME
        {
            get;
            set;
        }

        /// <summary>
        ///�˶�״̬
        ///0=δ�˶� 1=�Ѻ˶�
        /// </summary>
        public virtual int? CHECKSTATUS
        {
            get;
            set;
        }

        /// <summary>
        ///�˶�����
        /// </summary>
        public virtual DateTime? CHECKDATE
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual int? ARCHIVECOUNT
        {
            get;
            set;
        }

        /// <summary>
        ///ҳ��
        /// </summary>
        public virtual int? ARCHIVEPAGE
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

        /// <summary>
        ///����
        /// </summary>
        public virtual string ATTACHMENT
        {
            get;
            set;
        }

        #endregion
    }

}
