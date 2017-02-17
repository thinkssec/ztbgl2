using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Sbgl
{
    /// <summary>
    /// �豸ά����Ŀ���ձ��浥
    /// ������:����������
    /// ����ʱ��:2015/4/28 15:01:25
    /// </summary>
    [Serializable]
    public class SbglYsbgdModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///���ձ��浥ID
        /// </summary>
        public virtual string BGDID
        {
            get;
            set;
        }

        /// <summary>
        ///���ձ�������
        /// </summary>
        public virtual string BGDPH
        {
            get;
            set;
        }

        /// <summary>
        /// �ƻ���ID
        /// </summary>
        public virtual string JHBID
        {
            get;
            set;
        }

        /// <summary>
        ///�豸ά����Ŀ����
        /// </summary>
        public virtual string WXXMMC
        {
            get;
            set;
        }

        /// <summary>
        ///���ƺ���
        /// </summary>
        public virtual string CLPH
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
        ///������λ
        /// </summary>
        public virtual string JLDW
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual int? SL
        {
            get;
            set;
        }

        /// <summary>
        ///���ڵص�
        /// </summary>
        public virtual string SZDD
        {
            get;
            set;
        }

        /// <summary>
        ///ά�޹���������
        /// </summary>
        public virtual string GZLMS
        {
            get;
            set;
        }

        /// <summary>
        ///����ά������
        /// </summary>
        public virtual DateTime? KGRQ
        {
            get;
            set;
        }

        /// <summary>
        ///����ʹ������
        /// </summary>
        public virtual DateTime? JFRQ
        {
            get;
            set;
        }

        /// <summary>
        ///ԭֵ
        /// </summary>
        public virtual decimal? SBYZ
        {
            get;
            set;
        }

        /// <summary>
        ///����
        /// </summary>
        public virtual decimal? SBDJ
        {
            get;
            set;
        }

        /// <summary>
        ///�ܼ�
        /// </summary>
        public virtual decimal? SBZJ
        {
            get;
            set;
        }

        /// <summary>
        ///�����������ע
        /// </summary>
        public virtual string YSYJBZ
        {
            get;
            set;
        }

        /// <summary>
        ///ά�޵�λ
        /// </summary>
        public virtual string WXDW
        {
            get;
            set;
        }

        /// <summary>
        ///���״̬
        /// </summary>
        public virtual int? SHZT
        {
            get;
            set;
        }

        /// <summary>
        ///���ո���
        /// </summary>
        public virtual string YSFJ
        {
            get;
            set;
        }

        #endregion

        #region ��������

        /// <summary>
        /// ά�޼ƻ������
        /// </summary>
        public virtual SbglWxjhbModel WxjhModel
        {
            get;
            set;
        }

        #endregion
    }

}
