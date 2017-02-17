using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.App.Ui
{
    /// <summary>
    /// 
	/// ������:����������
	/// ����ʱ��:	2013/12/3 13:48:42
    /// </summary>
    [Serializable]
    public class UiDefaultModel : AppSuperModel
    {
        #region ����������
        
			/// <summary>
			///����
			/// </summary>
			public virtual string DEFAULTID
			{
				get;
				set;
			}

			/// <summary>
			///UI����
			/// </summary>
			public virtual string UICONTENT
			{
				get;
				set;
			}

			/// <summary>
			///��ɫID
			/// </summary>
			public virtual int? ROLEID
			{
				get;
				set;
			}

        #endregion

        /// <summary>
        /// ��ɫ
        /// </summary>
        public virtual Enterprise.Model.Basis.Sys.SysRoleModel SysRole
        {get;set;}
    }

}
