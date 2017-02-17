using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Sbgl
{
    /// <summary>
    /// �豸����̨�˱�
    /// ������:����������
    /// ����ʱ��:2015/4/28 15:01:25
    /// </summary>
    [Serializable]
    public class SbglTzModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///�豸�Ա��
        /// </summary>
        public virtual string SBBH
        {
            get;
            set;
        }

        /// <summary>
        ///�豸����
        /// </summary>
        public virtual string SBMC
        {
            get;
            set;
        }

        /// <summary>
        ///�豸����
        /// </summary>
        public virtual string SBLX
        {
            get;
            set;
        }

        /// <summary>
        ///����ͺ�
        /// </summary>
        public virtual string GGXH
        {
            get;
            set;
        }

        /// <summary>
        ///�����ƺ�
        /// </summary>
        public virtual string CLPH
        {
            get;
            set;
        }

        /// <summary>
        ///�豸ԭֵ
        /// </summary>
        public virtual decimal? SBYZ
        {
            get;
            set;
        }

        /// <summary>
        ///�豸��ֵ
        /// </summary>
        public virtual decimal? SBJZ
        {
            get;
            set;
        }

        /// <summary>
        /// ��װ�ص�
        /// </summary>
        public virtual string AZDD
        {
            get;
            set;
        }

        /// <summary>
        ///��������
        /// </summary>
        public virtual DateTime? CCRQ
        {
            get;
            set;
        }

        /// <summary>
        ///Ͷ������
        /// </summary>
        public virtual DateTime? TCRQ
        {
            get;
            set;
        }

        /// <summary>
        ///ʹ�õ�λ
        /// </summary>
        public virtual string SYDW
        {
            get;
            set;
        }

        /// <summary>
        ///������
        /// </summary>
        public virtual string BGR
        {
            get;
            set;
        }

        /// <summary>
        ///����ʱ�����ʻ���
        /// </summary>
        public virtual string YXSJLC
        {
            get;
            set;
        }

        /// <summary>
        ///�Ǽ�ʱ��
        /// </summary>
        public virtual DateTime? DJSJ
        {
            get;
            set;
        }

        /// <summary>
        ///�Ǽ���
        /// </summary>
        public virtual string DJR
        {
            get;
            set;
        }

        /// <summary>
        /// �豸״̬
        /// </summary>
        public virtual int? SBZT
        {
            get;
            set;
        }

        #endregion
    }

}
