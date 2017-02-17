using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// �������
    /// ������:����������
    /// ����ʱ��:	2013/12/1 14:10:58
    /// </summary>
    [Serializable]
    public class ProjectFztsyjModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///����ID
        /// </summary>
        public virtual string ID
        {
            get;
            set;
        }

        /// <summary>
        ///�ĵ�����
        /// </summary>
        public virtual string WDMC
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
        ///�Ǽ�����
        /// </summary>
        public virtual DateTime? DJRQ
        {
            get;
            set;
        }

        /// <summary>
        ///��Ƶ�λ
        /// </summary>
        public virtual string SJDW
        {
            get;
            set;
        }

        /// <summary>
        ///�Ǽ���
        /// </summary>
        public virtual int? DJR
        {
            get;
            set;
        }

        /// <summary>
        ///���
        /// </summary>
        public virtual string BH
        {
            get;
            set;
        }

        /// <summary>
        ///�ĵ�����
        /// </summary>
        public virtual string WDLX
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
        ///���״̬:0=δ��� 1=���ͨ�� 2=��˲�ͨ�� 3=��ӡ���
        /// </summary>
        public virtual int? SHZT
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual DateTime? TSRQ
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
        ///������
        /// </summary>
        public virtual string SHYJ
        {
            get;
            set;
        }

        #endregion


        #region ��������

        /// <summary>
        /// ��֤�����ļ�����
        /// </summary>
        public virtual IList<ProjectFztswjModel> FztswjList
        {
            get;
            set;
        }

        #endregion
    }

}
