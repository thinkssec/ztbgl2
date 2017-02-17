using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectPlanData.cs
    /// ��������: ���ݲ�-��Ŀ�ƻ������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-11-5 15:48:22
    /// </summary>
    public interface IProjectPlanData : IDataApp<ProjectPlanModel>
    {
        #region ����������
        ///// <summary>
        ///// ��ȡ���ݼ���
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        #endregion        

        void CreatePlan(string planId, string ProjectId);

        void RebuildEmptyPlan(string planId, string ProjectId);
    }

}
