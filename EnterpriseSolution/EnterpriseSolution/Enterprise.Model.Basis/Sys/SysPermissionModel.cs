using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 权限实体
    /// </summary>
    public class SysPermissionModel
    {

        #region "Private Variables"
        private string _ApplicationName;
        private int _ApplicationID;
        private string _PageCode;
        private string _PageCodeName;
        private List<SysPermissionItemModel> _ItemList = new List<SysPermissionItemModel>();
        #endregion

        #region "Public Variables"
        /// <summary>
        /// 应用名称
        /// </summary>
        public string ApplicationName
        {
            get
            {
                return _ApplicationName;
            }
            set
            {
                _ApplicationName = value;
            }
        }

        /// <summary>
        /// 应用ID
        /// </summary>
        public int ApplicationId
        {
            get
            {
                return _ApplicationID;
            }
            set
            {
                _ApplicationID = value;
            }
        }
        /// <summary>
        /// 模块代码
        /// </summary>
        public string PageCode
        {
            get
            {
                return _PageCode;
            }
            set
            {
                _PageCode = value;
            }
        }
        /// <summary>
        /// 模块名称
        /// </summary>
        public string PageCodeName
        {
            get
            {
                return _PageCodeName;
            }
            set
            {
                _PageCodeName = value;
            }
        }

        /// <summary>
        /// 权限文件列表
        /// </summary>
        public List<SysPermissionItemModel> ItemList
        {
            get
            {
                return _ItemList;
            }
            set
            {
                _ItemList = value;
            }
        }
        #endregion

    }
}
