using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Ui;

namespace Enterprise.Data.App.Ui
{	

    /// <summary>
    /// �ļ���:  IUiDefaultData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/3 13:48:42
    /// </summary>
    public interface IUiDefaultData : IDataApp<UiDefaultModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<UiDefaultModel> GetListBySQL(string sql);

        #endregion
    }

}
