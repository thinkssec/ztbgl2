using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectProfitData.cs
    /// ��������: ���ݲ�-��ֵ�ǼǱ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-11-5 15:48:22
    /// </summary>
    public interface IProjectProfitData : IDataApp<ProjectProfitModel>
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
