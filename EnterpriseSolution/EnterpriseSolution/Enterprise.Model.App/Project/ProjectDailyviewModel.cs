using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// 
    /// ������:����������
    /// ����ʱ��:	2013/12/28 15:34:11
    /// </summary>
    [Serializable]
    public class ProjectDailyviewModel : AppSuperModel
    {
        #region ����������


        /// <summary>
        /// ����
        /// </summary>
        public virtual DateTime RQ
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

        /// <summary>
        /// ��Ŀ���ճɱ�����Ԫ��
        /// </summary>
        public virtual decimal XMCB
        {
            get;
            set;
        }

        /// <summary>
        /// ��Ŀ���ղ�ֵ����Ԫ��
        /// </summary>
        public virtual decimal XMCZ
        {
            get;
            set;
        }

        /// <summary>
        /// ��Ŀ���ս������루��Ԫ��
        /// </summary>
        public virtual decimal JSSR
        {
            get;
            set;
        }

        /// <summary>
        ///  ��Ŀ���ջؿ����루��Ԫ��
        /// </summary>
        public virtual decimal HKSR
        {
            get;
            set;
        }

        

        #endregion
    }

}
