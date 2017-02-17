using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Document
{
    /// <summary>
    /// �ĵ�ת����
    /// ������:����������
    /// ����ʱ��:	2014/3/6 8:25:00
    /// </summary>
    [Serializable]
    public class DocumentConvertModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///ת����ID
        /// </summary>
        public virtual string CVTID
        {
            get;
            set;
        }

        /// <summary>
        ///ת������
        /// </summary>
        public virtual DateTime? CVTDATE
        {
            get;
            set;
        }

        /// <summary>
        ///ת��������
        /// </summary>
        public virtual string CVTNAME
        {
            get;
            set;
        }

        /// <summary>
        ///�ĵ�ID
        /// </summary>
        public virtual string DOCID
        {
            get;
            set;
        }

        /// <summary>
        ///ת������: pdf swf img
        /// </summary>
        public virtual string CVTTYPE
        {
            get;
            set;
        }

        /// <summary>
        ///ת����·��
        /// </summary>
        public virtual string CVTPATH
        {
            get;
            set;
        }

        #endregion


        #region �Զ�������

        /// <summary>
        /// �ĵ�MODEL
        /// </summary>
        public virtual DocumentProjModel DocumentProj
        {
            get;
            set;
        }

        #endregion
    }

}
