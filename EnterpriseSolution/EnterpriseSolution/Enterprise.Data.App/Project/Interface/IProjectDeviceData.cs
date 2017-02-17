using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectDeviceData.cs
    /// ��������: ���ݲ�-��Ŀ�豸�����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/6/19 15:35:20
    /// </summary>
    public interface IProjectDeviceData : IDataApp<ProjectDeviceModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectDeviceModel> GetListBySQL(string sql);

        #endregion
    }

}
