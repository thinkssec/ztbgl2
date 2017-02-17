using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Project;

namespace Enterprise.Data.App.Project
{	

    /// <summary>
    /// �ļ���:  IProjectZlglData.cs
    /// ��������: ���ݲ�-��Ŀ������������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2014/6/21 17:32:40
    /// </summary>
    public interface IProjectZlglData : IDataApp<ProjectZlglModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ProjectZlglModel> GetListBySQL(string sql);

        #endregion
    }

}
