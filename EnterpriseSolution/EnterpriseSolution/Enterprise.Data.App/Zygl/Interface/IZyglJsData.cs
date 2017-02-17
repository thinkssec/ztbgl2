using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Zygl;

namespace Enterprise.Data.App.Zygl
{	

    /// <summary>
    /// �ļ���:  IZyglJsData.cs
    /// ��������: ���ݲ�-��ҵ�������ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/5/29 11:11:47
    /// </summary>
    public interface IZyglJsData : IDataApp<ZyglJsModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ZyglJsModel> GetListBySQL(string sql);

        #endregion
    }

}
