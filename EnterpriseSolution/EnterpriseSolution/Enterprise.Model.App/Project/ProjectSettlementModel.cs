using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ������ؿ��¼��
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:24
    /// </summary>
    [Serializable]
    public class ProjectSettlementModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///�����ID
        /// </summary>
        public virtual string SETTLEID
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual DateTime? ACCOUNTDATE
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string CONTENT
        {
            get;
            set;
        }

        /// <summary>
        ///�������ͣ�1=���� 2=�ؿ�
        /// </summary>
        public virtual int? TYPE
        {
            get;
            set;
        }

        /// <summary>
        ///������������
        /// </summary>
        public virtual string PAYOFFTYPE
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual decimal? AMOUNT
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual string OPERATOR
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
