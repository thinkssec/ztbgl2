using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Zygl;

namespace Enterprise.Data.App.Zygl
{	

    /// <summary>
    /// �ļ���:  IZyglWgqtfyData.cs
    /// ��������: ���ݲ�-���ݷ��ʽӿ�
	/// �����ˣ�����������
	/// ����ʱ�䣺2015/5/27 16:33:49
    /// </summary>
    public interface IZyglWgqtfyData : IDataApp<ZyglWgqtfyModel>
    {
        #region ����������
        
        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<ZyglWgqtfyModel> GetListBySQL(string sql);

        #endregion
    }

}
