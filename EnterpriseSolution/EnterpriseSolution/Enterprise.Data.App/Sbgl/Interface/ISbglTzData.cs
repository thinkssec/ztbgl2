using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Sbgl;

namespace Enterprise.Data.App.Sbgl
{	

    /// <summary>
    /// �ļ���:  ISbglTzData.cs
    /// ��������: ���ݲ�-�豸����̨�˱����ݷ��ʽӿ�
    /// �����ˣ�����������
    /// ����ʱ�䣺2015/4/28 15:13:23
    /// </summary>
    public interface ISbglTzData : IDataApp<SbglTzModel>
    {
        #region ����������
        
	    /// <summary>
        /// ����������ȡΨһ��¼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SbglTzModel GetSingle(string key);

	    /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<SbglTzModel> GetListBySQL(string sql);

        /// <summary>
        /// ִ�л���SQL��ԭ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        bool ExecuteSQL(string sql);

        #endregion
    }

}
