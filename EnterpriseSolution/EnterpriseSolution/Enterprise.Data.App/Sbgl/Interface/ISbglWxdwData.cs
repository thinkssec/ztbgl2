using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Sbgl;

namespace Enterprise.Data.App.Sbgl
{	

    /// <summary>
    /// �ļ���:  ISbglWxdwData.cs
    /// ��������: ���ݲ�-�豸ά�޵�λ��Ϣ�����ݷ��ʽӿ�
    /// �����ˣ�����������
    /// ����ʱ�䣺2015/4/28 15:13:23
    /// </summary>
    public interface ISbglWxdwData : IDataApp<SbglWxdwModel>
    {
        #region ����������
        
	    /// <summary>
        /// ����������ȡΨһ��¼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SbglWxdwModel GetSingle(string key);

	    /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<SbglWxdwModel> GetListBySQL(string sql);

        /// <summary>
        /// ִ�л���SQL��ԭ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        bool ExecuteSQL(string sql);

        #endregion
    }

}
