using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
    /// ������:����������
    /// ����ʱ��:	2014/1/21 8:41:37
    /// </summary>
    [Serializable]
    public class ProjectFztzlviewModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        /// ��ͼ��
        /// </summary>
        public virtual int? STR
        {
            get;
            set;
        }

        /// <summary>
        /// ����
        /// egg.2014-01
        /// </summary>
        public virtual string NY
        {
            get;
            set;
        }

        /// <summary>
        /// ͼֽ��
        /// </summary>
        public virtual decimal? TZL
        {
            get;
            set;
        }

        #endregion
    }

}
