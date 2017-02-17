using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ����߻���
    /// ������:����������
    /// ����ʱ��:	2013-11-5 15:48:24
    /// </summary>
    [Serializable]
    public class ProjectRwchModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///�߻���ID
        /// </summary>
        public virtual string CHID
        {
            get;
            set;
        }

        /// <summary>
        ///����Ȩ��
        /// </summary>
        public virtual decimal? RWQZ
        {
            get;
            set;
        }

        /// <summary>
        ///��λ
        /// </summary>
        public virtual string DW
        {
            get;
            set;
        }

        /// <summary>
        ///�ƻ����ʱ��
        /// </summary>
        public virtual DateTime? JHWCSJ
        {
            get;
            set;
        }

        /// <summary>
        ///רҵ����
        /// </summary>
        public virtual string ZYMC
        {
            get;
            set;
        }

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
        public virtual string GZNR
        {
            get;
            set;
        }

        /// <summary>
        ///ʵ�ʹ�����
        /// </summary>
        public virtual decimal? SJGZL
        {
            get;
            set;
        }

        /// <summary>
        ///����״̬��0=δ��� 1=�����
        /// </summary>
        public virtual int? RWZT
        {
            get;
            set;
        }

        /// <summary>
        ///���Ϲ鵵״̬:0=�� 1=��
        /// </summary>
        public virtual int? ZLGDZT
        {
            get;
            set;
        }

        /// <summary>
        ///Ԥ�ƹ�����
        /// </summary>
        public virtual decimal? YJGZL
        {
            get;
            set;
        }

        /// <summary>
        ///ʵ�����ʱ��
        /// </summary>
        public virtual DateTime? SJWCSJ
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
        /// ������������
        /// </summary>
        public virtual IList<ProjectRwgzlModel> RwgzlList
        {
            get;
            set;
        }

        #endregion
    }

}
