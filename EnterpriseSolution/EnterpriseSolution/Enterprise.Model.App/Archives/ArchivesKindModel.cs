using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Archives
{
    /// <summary>
    /// ��������
    /// ������:����������
    /// ����ʱ��:	2014/2/7 13:50:45
    /// </summary>
    [Serializable]
    public class ArchivesKindModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///�����
        /// </summary>
        public virtual string ARCLBBH
        {
            get;
            set;
        }

        /// <summary>
        ///�ϼ����
        /// </summary>
        public virtual string ARCSJBH
        {
            get;
            set;
        }

        /// <summary>
        ///�������
        /// </summary>
        public virtual string ARCLBMC
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual int? ARCLBXH
        {
            get;
            set;
        }

        #endregion
    }

}
