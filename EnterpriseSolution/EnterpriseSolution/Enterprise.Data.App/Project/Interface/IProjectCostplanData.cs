using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectCostplanData.cs
    /// ��������: ���ݲ�-�ɱ��ƻ������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-11-7 14:36:28
    /// </summary>
    public interface IProjectCostplanData : IDataApp<ProjectCostplanModel>
    {
        #region ����������
        ///// <summary>
        ///// ��ȡ���ݼ���
        ///// </summary>
        ///// <returns></returns>
        //IList<SysUserModel> GetListById(int id);
        #endregion
    }

}
