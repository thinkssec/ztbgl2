using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Examine
{
    /// <summary>
    /// �ɱ���Ŀ��
    /// ������:����������
    /// ����ʱ��:	2013-11-7 14:36:26
    /// </summary>
    [Serializable]
    public class ExamineCostModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///��Ŀ����
        /// </summary>
        public virtual string COSTCODE
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual string COSTNAME
        {
            get;
            set;
        }

        /// <summary>
        ///�ɱ������
        /// </summary>
        public virtual string ITEMCODE
        {
            get;
            set;
        }

        /// <summary>
        ///�ϼ�����
        /// </summary>
        public virtual string PARENTCODE
        {
            get;
            set;
        }

        #endregion

    }

}
