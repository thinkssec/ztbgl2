using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Model.Basis.Sys;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ���Ա��
    /// ������:����������
    /// ����ʱ��:	2013-11-5 15:48:20
    /// </summary>
    [Serializable]
    public class ProjectMemberModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///��Ŀ���Ա��ID
        /// </summary>
        public virtual string MEMBERID
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string PROJTASK
        {
            get;
            set;
        }

        /// <summary>
        ///�ϸ�ʱ��
        /// </summary>
        public virtual DateTime? POSTDATE
        {
            get;
            set;
        }

        /// <summary>
        ///��λ��ɫ
        /// </summary>
        public virtual string POSTROLE
        {
            get;
            set;
        }

        /// <summary>
        ///�������
        /// </summary>
        public virtual int? TASKSCALE
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
        ///���ʱ��
        /// </summary>
        public virtual DateTime? OFFPOSTDATE
        {
            get;
            set;
        }

        /// <summary>
        ///��ע
        /// </summary>
        public virtual string MEMO
        {
            get;
            set;
        }

        /// <summary>
        ///��λ״̬��0=��� 1=�ڸ� 2=����
        /// </summary>
        public virtual int? POSTSTATUS
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
        /// �����û�MODEL
        /// </summary>
        public virtual SysUserModel UserModel
        {
            get;
            set;
        }

        /// <summary>
        /// ������ĿMODEL
        /// </summary>
        public virtual ProjectInfoModel ProjectModel
        { get; set; }

        #endregion

       
    }

    /// <summary>
    /// ��Ŀ���Ա��ɫ
    /// </summary>
    public enum PM_ROLENAME
    {
        ��Ŀ������,
        ����������,
        �����鸺����,
        ���鹤��ʦ,
        �豸����Ա,
        ����Ա,
        ��ȫԱ,
        ��ͼԱ,
        ����Ա,
        ˾��
    }

}
