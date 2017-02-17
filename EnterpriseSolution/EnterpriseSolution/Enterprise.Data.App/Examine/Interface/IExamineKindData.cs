using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Examine;

namespace Enterprise.Data.App.Examine
{	

    /// <summary>
    /// �ļ���:  IExamineKindData.cs
    /// ��������: ���ݲ�-�������ͱ����ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013-11-8 14:53:58
    /// </summary>
    public interface IExamineKindData : IDataApp<ExamineKindModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ExamineKindModel> GetListBySQL(string sql);

        #endregion
    }

}
