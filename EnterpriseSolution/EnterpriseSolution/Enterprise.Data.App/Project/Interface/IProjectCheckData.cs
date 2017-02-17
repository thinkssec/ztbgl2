using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectCheckData.cs
    /// ��������: ���ݲ�-�����Ϣ�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-11-5 15:48:14
    /// </summary>
    public interface IProjectCheckData : IDataApp<ProjectCheckModel>
    {
        #region ����������
        
        /// <summary>
        /// ִ��������ӡ��޸ġ�ɾ������
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool ExecuteLst(IList<ProjectCheckModel> models);

        #endregion
    }

}
