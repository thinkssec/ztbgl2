using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Publicize
{
    /// <summary>
    /// ��������Ͷ��
    /// ������:����������
    /// ����ʱ��:	2014/2/8 10:32:28
    /// </summary>
    [Serializable]
    public class PublicizeInfoModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///Ͷ��ID
        /// </summary>
        public virtual string PUBID
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual DateTime? PUBDATE
        {
            get;
            set;
        }

        /// <summary>
        ///Ͷ������
        /// </summary>
        public virtual DateTime? SUBMITDATE
        {
            get;
            set;
        }

        /// <summary>
        ///�û�ID
        /// </summary>
        public virtual int USERID
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual string PUBTITLE
        {
            get;
            set;
        }

        /// <summary>
        ///��ĿID
        /// </summary>
        public virtual string LMID
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

        /// <summary>
        ///������λ
        /// </summary>
        public virtual string PUBDEPT
        {
            get;
            set;
        }

        /// <summary>
        ///���״̬:0=δ��� 1=���ͨ�� 2=��˲�ͨ�� 3=�ѷ���
        /// </summary>
        public virtual int? STATUS
        {
            get;
            set;
        }

        /// <summary>
        ///�������
        /// </summary>
        public virtual DateTime? AUDITDATE
        {
            get;
            set;
        }

        /// <summary>
        ///�������
        /// </summary>
        public virtual int? CLICKS
        {
            get;
            set;
        }




        /// <summary>
        ///�Ƿ��Ƽ�����ҳ��1���Ƽ� 0�����Ƽ�
        /// </summary>
        public virtual string RECOMMEND
        {
            get;
            set;
        }

        /// <summary>
        ///��������ͼ
        /// </summary>
        public virtual string SLT
        {
            get;
            set;
        }

        /// <summary>
        ///�Ƿ��ö� 0�����ö� 1���ö�
        /// </summary>
        public virtual string ZD
        {
            get;
            set;
        }
        #endregion
    }

}
