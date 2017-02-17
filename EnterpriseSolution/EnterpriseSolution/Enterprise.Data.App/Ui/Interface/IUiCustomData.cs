using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Ui;

namespace Enterprise.Data.App.Ui
{	

    /// <summary>
    /// �ļ���:  IUiCustomData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/3 13:48:43
    /// </summary>
    public interface IUiCustomData : IDataApp<UiCustomModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<UiCustomModel> GetListBySQL(string sql);

        #endregion
    }

}
