using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// ϵͳģ��
    /// ������:����������
    /// ����ʱ��:2015/3/17 14:20:13
    /// </summary>
    [Serializable]
    public class SysModuleModel : BasisSuperModel
    {
        #region ����������

        /// <summary>
        ///�Զ����
        /// </summary>
        public virtual string MODULEID
        {
            get;
            set;
        }

        /// <summary>
        ///ģ�����
        /// </summary>
        public virtual string MCODE
        {
            get;
            set;
        }

        /// <summary>
        ///ģ������
        /// </summary>
        public virtual string MNAME
        {
            get;
            set;
        }

        /// <summary>
        ///�������
        /// </summary>
        public virtual string MPARENTID
        {
            get;
            set;
        }

        /// <summary>
        ///ģ���Ŀ¼
        /// </summary>
        public virtual string MROOTID
        {
            get;
            set;
        }

        /// <summary>
        ///ǰ��Сͼ��
        /// </summary>
        public virtual string MIMAGE
        {
            get;
            set;
        }

        /// <summary>
        ///����Ŀ��
        /// </summary>
        public virtual string MTARGET
        {
            get;
            set;
        }

        /// <summary>
        ///���ӵ�ַ
        /// </summary>
        public virtual string MURL
        {
            get;
            set;
        }

        /// <summary>
        ///�Ƿ���ʾ
        /// </summary>
        public virtual int? MDELETE
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual int? MORDERBY
        {
            get;
            set;
        }

        /// <summary>
        ///�Ƿ�����
        /// </summary>
        public virtual int? MSINGLE
        {
            get;
            set;
        }

        /// <summary>
        /// WEBӳ��·��
        /// </summary>
        public virtual string MWEBURL
        {
            get;
            set;
        }

        /// <summary>
        /// WEBӳ��·������
        /// </summary>
        public virtual string MWEBPARAM
        {
            get;
            set;
        }

        #endregion
    }

}
