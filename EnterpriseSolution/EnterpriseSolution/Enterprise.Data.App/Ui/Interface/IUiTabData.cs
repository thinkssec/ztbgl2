using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Ui;

namespace Enterprise.Data.App.Ui
{	

    /// <summary>
    /// �ļ���:  IUiTabData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2013/12/4 10:14:12
    /// </summary>
    public interface IUiTabData : IDataApp<UiTabModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<UiTabModel> GetListBySQL(string sql);

        #endregion
    }

}
