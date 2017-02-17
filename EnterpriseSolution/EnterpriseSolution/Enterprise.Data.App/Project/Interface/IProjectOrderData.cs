using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectOrderData.cs
    /// ��������: ���ݲ�-��Ŀ�´�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-11-5 15:48:21
    /// </summary>
    public interface IProjectOrderData : IDataApp<ProjectOrderModel>
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
