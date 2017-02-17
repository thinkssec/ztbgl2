using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Examine
{
    /// <summary>
    /// ������ʩ���������
    /// ������:����������
    /// ����ʱ��:	2013-11-5 15:48:10
    /// </summary>
    [Serializable]
    public class ExamineProcessModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///��������
        /// </summary>
        public virtual string BJDM
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string BJMC
        {
            get;
            set;
        }

        /// <summary>
        ///�㼶˳��
        /// </summary>
        public virtual string CJSX
        {
            get;
            set;
        }

        /// <summary>
        ///��������ID
        /// </summary>
        public virtual int KINDID
        {
            get;
            set;
        }

        /// <summary>
        ///�ϼ�����
        /// </summary>
        public virtual string SJDM
        {
            get;
            set;
        }

        /// <summary>
        ///��ʼȨ��
        /// </summary>
        public virtual decimal? CSQZ
        {
            get;
            set;
        }

        #endregion


        #region ��������

        /// <summary>
        /// ��������MODEL
        /// </summary>
        public virtual ExamineKindModel ExamineKind
        {
            get;
            set;
        }

        #endregion
    }

}
