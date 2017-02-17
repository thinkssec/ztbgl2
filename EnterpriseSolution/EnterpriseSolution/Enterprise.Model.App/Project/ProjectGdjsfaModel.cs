using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��������
    /// ������:����������
    /// ����ʱ��:	2013-11-5 15:48:19
    /// </summary>
    [Serializable]
    public class ProjectGdjsfaModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///��������ID
        /// </summary>
        public virtual string JSFAID
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string FAMC
        {
            get;
            set;
        }

        /// <summary>
        ///�汾��
        /// </summary>
        public virtual string BBH
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? SPR
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string SHYJG
        {
            get;
            set;
        }

        /// <summary>
        ///У����
        /// </summary>
        public virtual int? JDR
        {
            get;
            set;
        }

        /// <summary>
        ///�����
        /// </summary>
        public virtual int? SHR
        {
            get;
            set;
        }

        /// <summary>
        ///��д��
        /// </summary>
        public virtual int? BXR
        {
            get;
            set;
        }

        /// <summary>
        ///�ϴ�����
        /// </summary>
        public virtual string SCFJ
        {
            get;
            set;
        }

        /// <summary>
        ///ǩ��ʱ��
        /// </summary>
        public virtual DateTime? QFRQ
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
        ///�����÷�
        /// </summary>
        public virtual decimal? ZLDF
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual string SHYJ
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
        ///��ǰ״̬��0=δ��� 1=���ͨ��  2=��˲�ͨ��  3=��ӡ���
        /// </summary>
        public virtual int? PRTSTATUS
        {
            get;
            set;
        }

        /// <summary>
        ///�ύ��
        /// </summary>
        public virtual int? SUBMITTER
        {
            get;
            set;
        }


        #endregion
    }

}
