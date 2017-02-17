using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ͼֽ������¼�б�
    /// ������:����������
    /// ����ʱ��:	2013/12/1 14:10:59
    /// </summary>
    [Serializable]
    public class ProjectFztzjfjlModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///ID
        /// </summary>
        public virtual string ID
        {
            get;
            set;
        }

        /// <summary>
        ///�ļ�����
        /// </summary>
        public virtual string WJMC
        {
            get;
            set;
        }

        /// <summary>
        ///��ע
        /// </summary>
        public virtual string BZ
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual string FJ
        {
            get;
            set;
        }

        /// <summary>
        ///����ʱ��
        /// </summary>
        public virtual DateTime? JFSJ
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual string JSR
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual int? FS
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? JBR
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
        ///���
        /// </summary>
        public virtual string BC
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual string DAH
        {
            get;
            set;
        }

        #endregion
    }

}
