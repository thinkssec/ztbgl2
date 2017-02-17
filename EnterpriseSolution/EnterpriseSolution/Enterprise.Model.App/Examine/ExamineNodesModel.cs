using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Examine
{
    /// <summary>
    /// �������̽ڵ��
    /// ������:����������
    /// ����ʱ��:	2013-11-5 15:48:10
    /// </summary>
    [Serializable]
    public class ExamineNodesModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///�ڵ����
        /// </summary>
        public virtual string NODECODE
        {
            get;
            set;
        }

        /// <summary>
        ///�ڵ���
        /// </summary>
        public virtual string NODEBH
        {
            get;
            set;
        }

        /// <summary>
        ///�ڵ�Ȩֵ
        /// </summary>
        public virtual int? NODEVALUE
        {
            get;
            set;
        }

        /// <summary>
        ///�Ƿ�ؼ��ڵ�
        /// </summary>
        public virtual int? KEYNODE
        {
            get;
            set;
        }

        /// <summary>
        ///�ڵ�����
        /// </summary>
        public virtual string NODENAME
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string NODEPARAM
        {
            get;
            set;
        }

        /// <summary>
        ///�������
        /// </summary>
        public virtual DateTime? ADDDATE
        {
            get;
            set;
        }

        /// <summary>
        ///�ڵ�·��
        /// </summary>
        public virtual string NODEPATH
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
        ///�ڵ�ͼ��
        /// </summary>
        public virtual string NODEICON
        {
            get;
            set;
        }

        /// <summary>
        ///�ڵ�״̬��0=���ɼ� 1=�ɼ� 2=����
        /// </summary>
        public virtual int? NODESTATUS
        {
            get;
            set;
        }

        /// <summary>
        /// WEBӳ��·��
        /// </summary>
        public virtual string WEBURL
        {
            get;
            set;
        }

        /// <summary>
        /// WEB·������
        /// </summary>
        public virtual string WEBPARAM
        {
            get;
            set;
        }

        #endregion
    }

}
