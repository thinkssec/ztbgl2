using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Project
{
    /// <summary>
    /// ��Ŀ�ƻ���
	/// ������:����������
	/// ����ʱ��:	2013-11-5 15:48:21
    /// </summary>
    [Serializable]
    public class ProjectPlanModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///��Ŀ�ƻ���ID
			/// </summary>
			public virtual string PLANID
			{
				get;
				set;
			}

			/// <summary>
			///���״̬��-1=����� 0=��ͨ�� 1=ͨ�� 2=ͬ����
			/// </summary>
			public virtual int? AUDITSTATUS
			{
				get;
				set;
			}

			/// <summary>
			///��Ŀ�ſ�
			/// </summary>
			public virtual string PROJSURVEY
			{
				get;
				set;
			}

			/// <summary>
			///�����ƻ�
			/// </summary>
			public virtual string QUALITYPLAN
			{
				get;
				set;
			}

			/// <summary>
			///��ȫԤ��
			/// </summary>
			public virtual string PREPAREDNESS
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
			///�������
			/// </summary>
			public virtual DateTime? AUDITDATE
			{
				get;
				set;
			}

        #endregion

        /// <summary>
        /// �ɱ��ƻ�
        /// </summary>
            public virtual IList<Model.App.Project.ProjectCostplanModel> ProjectCostPlans
            {
                get;
                set;
            }
            
    }

}
