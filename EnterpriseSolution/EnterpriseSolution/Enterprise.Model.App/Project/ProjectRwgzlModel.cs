using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// �������������
    /// ������:����������
    /// ����ʱ��:	2013-11-5 15:48:24
    /// </summary>
    [Serializable]
    public class ProjectRwgzlModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///��������ID
        /// </summary>
        public virtual string RWLID
        {
            get;
            set;
        }

        /// <summary>
        ///��Ƭԭ��
        /// </summary>
        public virtual string WSFPYY
        {
            get;
            set;
        }

        /// <summary>
        ///����˵��
        /// </summary>
        public virtual string JLSM
        {
            get;
            set;
        }

        /// <summary>
        ///����ʱ��
        /// </summary>
        public virtual DateTime? JYSJ
        {
            get;
            set;
        }

        /// <summary>
        ///���Ϲ鵵״̬
        /// </summary>
        public virtual int? ZLGDZT
        {
            get;
            set;
        }

        /// <summary>
        ///��Ƭ��
        /// </summary>
        public virtual decimal? WSFPL
        {
            get;
            set;
        }

        /// <summary>
        ///��ɹ�����
        /// </summary>
        public virtual decimal? WCGZL
        {
            get;
            set;
        }

        /// <summary>
        ///��Ƭ˵��
        /// </summary>
        public virtual string MEMO
        {
            get;
            set;
        }

        /// <summary>
        ///�߻���ID
        /// </summary>
        public virtual string CHID
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? JYR
        {
            get;
            set;
        }

        /// <summary>
        ///���鵥��
        /// </summary>
        public virtual string JYDH
        {
            get;
            set;
        }

        #endregion

        #region �������

        /// <summary>
        /// ����������߻�MODEL
        /// </summary>
        public virtual ProjectRwchModel ProjectRwch
        {
            get;
            set;
        }

        #endregion
    }

}
