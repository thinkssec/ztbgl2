using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enterprise.Model.Basis.Sys
{
    /// <summary>
    /// 权限项
    /// </summary>
    public class SysPermissionItemModel
    {
        /// <summary>
        /// 项名称
        /// </summary>
        public string Item_Name { get; set; }

        /// <summary>
        /// 项值
        /// </summary>
        public int Item_Value { get; set; }

        /// <summary>
        /// 项列表
        /// </summary>
        public string Item_FileList { get; set; }

    }
}
