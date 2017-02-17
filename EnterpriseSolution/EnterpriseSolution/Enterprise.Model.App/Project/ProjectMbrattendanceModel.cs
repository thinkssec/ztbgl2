using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ��Ա��̬��
    /// ������:����������
    /// ����ʱ��:	2014/6/19 15:35:17
    /// </summary>
    [Serializable]
    public class ProjectMbrattendanceModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///��Ա��̬ID
        /// </summary>
        public virtual string ID
        {
            get;
            set;
        }

        /// <summary>
        ///��¼����
        /// </summary>
        public virtual DateTime? JLRQ
        {
            get;
            set;
        }

        /// <summary>
        ///-1=�ϸ� 0=���� 1=���� 2=���� 3=���
        /// </summary>
        public virtual int? RYDT
        {
            get;
            set;
        }

        /// <summary>
        ///���˵��
        /// </summary>
        public virtual string MEMO
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
        ///��Ŀ���Ա��ID
        /// </summary>
        public virtual string MEMBERID
        {
            get;
            set;
        }

        /// <summary>
        ///��Ա����
        /// </summary>
        public virtual string MBRNAME
        {
            get;
            set;
        }

        /// <summary>
        /// ��Ա����
        /// ְ��,����
        /// </summary>
        public virtual string MBRPROPERTY
        {
            get;
            set;
        }

        #endregion

    }

}
