using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
    /// ������:����������
    /// ����ʱ��:	2013/12/10 10:44:41
    /// </summary>
    [Serializable]
    public class ProjectDeptincomeviewModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        /// ����ID
        /// </summary>
        public virtual int DEPTID
        {
            get;
            set;
        }

        /// <summary>
        /// ���
        /// </summary>
        public virtual int YEAR
        {
            get;
            set;
        }

        /// <summary>
        ///��ͬ����
        /// </summary>
        public virtual decimal? HTSR
        {
            get;
            set;
        }

        /// <summary>
        ///�ؿ�����
        /// </summary>
        public virtual decimal? HKSR
        {
            get;
            set;
        }

        /// <summary>
        ///Ԥ������
        /// </summary>
        public virtual decimal? YJSR
        {
            get;
            set;
        }

        /// <summary>
        ///��Ŀ�ɱ�
        /// </summary>
        public virtual decimal? XMCB
        {
            get;
            set;
        }

        /// <summary>
        ///��Ŀ��ֵ
        /// </summary>
        public virtual decimal? XMCZ
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual decimal? JSSR
        {
            get;
            set;
        }

        #endregion
    }

}
