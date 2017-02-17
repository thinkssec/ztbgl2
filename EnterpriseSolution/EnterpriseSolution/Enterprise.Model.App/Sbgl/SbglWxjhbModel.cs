using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Sbgl
{
    /// <summary>
    /// �豸ά�޼ƻ���
    /// ������:����������
    /// ����ʱ��:2015/4/28 15:01:25
    /// </summary>
    [Serializable]
    public class SbglWxjhbModel : AppSuperModel
    {
        #region ����������

        /// <summary>
        ///�ƻ���ID
        /// </summary>
        public virtual string JHBID
        {
            get;
            set;
        }

        /// <summary>
        ///�豸ά������
        /// </summary>
        public virtual string SBWXPH
        {
            get;
            set;
        }

        /// <summary>
        ///ʹ�õ�λ
        /// </summary>
        public virtual string SBSYDW
        {
            get;
            set;
        }

        /// <summary>
        ///ά���豸����
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
        public virtual string CLXH
        {
            get;
            set;
        }

        /// <summary>
        ///�Ա��
        /// </summary>
        public virtual string SBBH
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
        ///��װ�ص�
        /// </summary>
        public virtual string AZDD
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
        ///����ʱ�����ʻ���
        /// </summary>
        public virtual string YXSJLC
        {
            get;
            set;
        }

        /// <summary>
        ///�ϴ���������
        /// </summary>
        public virtual DateTime? SCXLRQ
        {
            get;
            set;
        }

        /// <summary>
        ///Ԥ����������
        /// </summary>
        public virtual DateTime? SXRQ
        {
            get;
            set;
        }

        /// <summary>
        ///ά������
        /// </summary>
        public virtual string SBWXNR
        {
            get;
            set;
        }

        /// <summary>
        ///Ԥ��ά�޷���
        /// </summary>
        public virtual decimal? YJWXFY
        {
            get;
            set;
        }

        /// <summary>
        ///����ά�޵�λ
        /// </summary>
        public virtual string JYWXDW
        {
            get;
            set;
        }

        /// <summary>
        ///ά������״̬
        /// </summary>
        public virtual int? SQZT
        {
            get;
            set;
        }

        /// <summary>
        ///�����
        /// </summary>
        public virtual string TBR
        {
            get;
            set;
        }

        /// <summary>
        ///�������
        /// </summary>
        public virtual DateTime? TBRQ
        {
            get;
            set;
        }

        /// <summary>
        ///��ע
        /// </summary>
        public virtual string BZ
        {
            get;
            set;
        }

        #endregion

        #region �Զ�������

        /// <summary>
        /// ���޵���ݺ��·�
        /// </summary>
        public virtual string SXNY
        {
            get
            {
                return (SXRQ != null) ? SXRQ.Value.ToString("yyyy-MM") : "";
            }
        }

        #endregion

    }

}
