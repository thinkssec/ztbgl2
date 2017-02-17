using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Common.Article
{
    /// <summary>
    /// ֪ͨ��������Ϣ��
    /// ������:����������
    /// ����ʱ��:	2013/4/18 9:51:26
    /// </summary>
    [Serializable]
    public class ArticleInfoModel : CommonSuperModel
    {
        #region ����������

        /// <summary>
        ///�Զ����
        /// </summary>
        public virtual string ARTICLEID
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual int? ADEPARTMENT
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? AUSER
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual string ATYPE
        {
            get;
            set;
        }

        /// <summary>
        ///���ı���
        /// </summary>
        public virtual string ATITLE
        {
            get;
            set;
        }

        /// <summary>
        ///���ı���
        /// </summary>
        public virtual string ATITLERU
        {
            get;
            set;
        }

        /// <summary>
        ///����ʱ��
        /// </summary>
        public virtual DateTime? ARELEASETIME
        {
            get;
            set;
        }

        /// <summary>
        ///��Чʱ��
        /// </summary>
        public virtual DateTime? AINVALIDTIME
        {
            get;
            set;
        }

        /// <summary>
        ///ǩ����
        /// </summary>
        public virtual string ARECEVIEUSER
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? ACREATEUSER
        {
            get;
            set;
        }

        /// <summary>
        ///����ʱ��
        /// </summary>
        public virtual DateTime? ACREATETIME
        {
            get;
            set;
        }

        /// <summary>
        ///��Ŀ���
        /// </summary>
        public virtual string AMODULEID
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string ACONTENT
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string ACONTENTRU
        {
            get;
            set;
        }

        /// <summary>
        ///�汾��
        /// </summary>
        public virtual string AVERSION
        {
            get;
            set;
        }

        /// <summary>
        ///��׼����
        /// </summary>
        public virtual DateTime? APPROVALDATE
        {
            get;
            set;
        }

        /// <summary>
        ///��Ч����
        /// </summary>
        public virtual DateTime? AISSUEDATE
        {
            get;
            set;
        }

        /// <summary>
        ///�ƶ����� 0=�¼� 1=�޶�
        /// </summary>
        public virtual string ASYSTEMTYPE
        {
            get;
            set;
        }

        /// <summary>
        ///������������
        /// </summary>
        public virtual string AFVIEWNAMES
        {
            get;
            set;
        }

        /// <summary>
        ///�����ļ�����
        /// </summary>
        public virtual string AFNAMES
        {
            get;
            set;
        }

        #endregion
    }

}
