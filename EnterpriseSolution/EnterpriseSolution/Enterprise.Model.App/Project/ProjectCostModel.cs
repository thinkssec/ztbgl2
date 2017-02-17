using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Enterprise.Model.App.Examine;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ���ü�¼��
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:16
    /// </summary>
    [Serializable]
    public class ProjectCostModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///���ü�¼ID
        /// </summary>
        public virtual string COSTID
        {
            get;
            set;
        }

        /// <summary>
        ///֧������
        /// </summary>
        public virtual DateTime? COSTDATE
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual string OPERATER
        {
            get;
            set;
        }

        /// <summary>
        ///Ʊ�������
        /// </summary>
        public virtual string PRETRIAL
        {
            get;
            set;
        }

        /// <summary>
        ///֧��˵��
        /// </summary>
        public virtual string EXPLAIN
        {
            get;
            set;
        }

        /// <summary>
        ///�Ƿ��з�Ʊ
        /// </summary>
        public virtual int? ISBILL
        {
            get;
            set;
        }

        /// <summary>
        ///���
        /// </summary>
        public virtual decimal AMOUNT
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual DateTime? OPERATEDATE
        {
            get;
            set;
        }

        /// <summary>
        ///Ʊ������
        /// </summary>
        public virtual int? TICKETS
        {
            get;
            set;
        }

        /// <summary>
        ///��Ŀ����
        /// </summary>
        public virtual string COSTCODE
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? PROCESSOR
        {
            get;
            set;
        }

        /// <summary>
        ///��¼״̬
        /// </summary>
        public virtual int? STATUS
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


        #region �������

        /// <summary>
        ///�ɱ���ĿMODEL
        /// </summary>
        public virtual ExamineCostModel ExamineCostInfo
        {
            get;
            set;
        }

        #endregion
    }

}
