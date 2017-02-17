using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.ORM;
using Enterprise.Model.App.Sbgl;

namespace Enterprise.Data.App.Sbgl
{	

    /// <summary>
    /// �ļ���:  ISbglWxjhbData.cs
    /// ��������: ���ݲ�-�豸ά�޼ƻ������ݷ��ʽӿ�
    /// �����ˣ�����������
    /// ����ʱ�䣺2015/4/30 8:22:37
    /// </summary>
    public interface ISbglWxjhbData : IDataApp<SbglWxjhbModel>
    {
        #region ����������

        /// <summary>
        /// ����������ȡΨһ��¼
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        SbglWxjhbModel GetSingle(string key);

        /// <summary>
        /// ����ԭ��SQL�Ĳ�ѯ�б�
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        IList<SbglWxjhbModel> GetListBySQL(string sql);

        /// <summary>
        /// ִ�л���SQL��ԭ������
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        bool ExecuteSQL(string sql);

        #endregion
    }

}
