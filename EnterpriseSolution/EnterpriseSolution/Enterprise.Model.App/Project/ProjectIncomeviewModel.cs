using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2013/12/10 9:41:28
    /// </summary>
    [Serializable]
    public class ProjectIncomeviewModel : AppSuperModel
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
		/// ��ͬ����
		/// </summary>
		public virtual decimal? HTSR
		{
			get;
			set;
		}

		/// <summary>
		/// �ؿ�����
		/// </summary>
        public virtual decimal? HKSR
		{
			get;
			set;
		}

		/// <summary>
		/// Ԥ������
		/// </summary>
        public virtual decimal? YJSR
		{
			get;
			set;
		}

		/// <summary>
		/// ��Ŀ�ɱ�
		/// </summary>
        public virtual decimal? XMCB
		{
			get;
			set;
		}

		/// <summary>
        /// ��Ŀ��ֵ
		/// </summary>
        public virtual decimal? XMCZ
		{
			get;
			set;
		}

		/// <summary>
		/// ��������
		/// </summary>
        public virtual decimal? JSSR
		{
			get;
			set;
		}

		/// <summary>
		/// ��ĿID
		/// </summary>
		public virtual string PROJID
		{
			get;
			set;
		}

        #endregion

        #region ��������

        /// <summary>
        /// ��Ŀ
        /// </summary>
        public virtual ProjectInfoModel ProjectInfo
        {
            get;
            set;
        }

        /// <summary>
        /// ����
        /// </summary>
        public virtual Enterprise.Model.Basis.Sys.SysDepartMentModel Department
        {
            get;
            set;
        }
        #endregion
    }
}
