using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ���Ա����
    /// ������:����������
    /// ����ʱ��:	2014/6/19 15:35:18
    /// </summary>
    [Serializable]
    public class ProjectMbroutsideModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///��ͳ�Ա��ID
        /// </summary>
        public virtual string MBROUTID
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
        ///��Ա����
        /// </summary>
        public virtual string USERNAME
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
        ///��λ״̬
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

        #region �Զ�������

        /// <summary>
        ///��Ŀ���Ա��ID
        /// </summary>
        public virtual string MEMBERID
        {
            get 
            { 
                return MBROUTID; 
            }
        }

        #endregion
    }

}
