using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��ֵ�ǼǱ�
	/// ������:����������
	/// ����ʱ��:	2013/11/14 18:32:36
    /// </summary>
    [Serializable]
    public class ProjectProfitModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///��ֵ��ID
        /// </summary>
        public virtual string PROFITID
        {
            get;
            set;
        }

        /// <summary>
        ///���̽���
        /// </summary>
        public virtual decimal? PROGRESS
        {
            get;
            set;
        }

        /// <summary>
        ///�ۼƲ�ֵ
        /// </summary>
        public virtual decimal? SUMVALUE
        {
            get;
            set;
        }

        /// <summary>
        ///��ɲ�ֵ
        /// </summary>
        public virtual decimal COMPLETEVALUE
        {
            get;
            set;
        }

        /// <summary>
        ///�����ֵ
        /// </summary>
        public virtual decimal OUTSOURCEVALUE
        {
            get;
            set;
        }

        /// <summary>
        ///��ʼʱ��
        /// </summary>
        public virtual DateTime? STARTDATE
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual DateTime? CHECKDATE
        {
            get;
            set;
        }

        /// <summary>
        ///����ʱ��
        /// </summary>
        public virtual DateTime? ENDDATE
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual string PERIOD
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
        ///˳���
        /// </summary>
        public virtual int? ORDERBY
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
