using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Enterprise.Component.Infrastructure;
namespace Enterprise.Component.Control
{
    /// <summary>
    /// 菜单按钮
    /// </summary>
    [TypeConverter(typeof(TypeConverter))]
    public class HeadMenuButtonItem
    {
        #region "Private Variables"
        private string _ButtonName;
        private string _ButtonUrl;
        private Utility.PopedomType _ButtonPopedom;
        private Utility.UrlType _ButtonUrlType = Utility.UrlType.Href;
        private string _ButtonIcon;
        private bool _ButtonVisible = true;
        #endregion

        #region "Public Variables"
        /// <summary>
        /// 构造函数
        /// </summary>
        public HeadMenuButtonItem()
            : this(String.Empty, String.Empty, Utility.PopedomType.List, Utility.UrlType.Href, string.Empty, true)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_ButtonName">按钮名称</param>
        /// <param name="_ButtonUrl">按钮链接</param>
        /// <param name="_ButtonPopedom">按钮所属权限</param>
        /// <param name="_ButtonUrlType">按钮链接类型</param>
        /// <param name="_ButtonIcon">按钮Icon</param>
        /// <param name="_ButtonVisible">是否显示</param>
        public HeadMenuButtonItem(string _ButtonName, string _ButtonUrl, Utility.PopedomType _ButtonPopedom,
            Utility.UrlType _ButtonUrlType, string _ButtonIcon, bool _ButtonVisible
            )
        {
            this._ButtonIcon = _ButtonIcon;
            this._ButtonName = _ButtonName;
            this._ButtonPopedom = _ButtonPopedom;
            this._ButtonUrl = _ButtonUrl;
            this._ButtonUrlType = _ButtonUrlType;
            this._ButtonVisible = _ButtonVisible;
        }



        /// <summary>
        /// 按钮名称
        /// </summary>
        [
        Category("Behavior"),
        DefaultValue(""),
        Description("按钮名称"),
        NotifyParentProperty(true),
        ]
        public string ButtonName
        {
            get
            {
                return _ButtonName;
            }
            set
            {
                _ButtonName = value;
            }
        }
        /// <summary>
        /// 按钮链接
        /// </summary>
        [
        Category("Behavior"),
        DefaultValue(""),
        Description("按钮链接"),
        NotifyParentProperty(true),
        ]
        public string ButtonUrl
        {
            get
            {
                return _ButtonUrl;
            }
            set
            {
                _ButtonUrl = value;
            }
        }
        /// <summary>
        /// 按钮所属权限
        /// </summary>
        [
        Category("Behavior"),
        DefaultValue(""),
        Description("按钮所属权限"),
        NotifyParentProperty(true),
        ]
        public Utility.PopedomType ButtonPopedom
        {
            get
            {
                return _ButtonPopedom;
            }
            set
            {
                _ButtonPopedom = value;
            }
        }
        /// <summary>
        /// 按钮链接类型 默认为url
        /// </summary>
        [
        Category("Behavior"),
        DefaultValue(""),
        Description("按钮链接类型 默认为url"),
        NotifyParentProperty(true),
        ]
        public Utility.UrlType ButtonUrlType
        {
            get
            {
                return _ButtonUrlType;
            }
            set
            {
                _ButtonUrlType = value;
            }
        }
        /// <summary>
        /// 按钮Icon 默认为空
        /// </summary>
        [
        Category("Behavior"),
        DefaultValue(""),
        Description("按钮Icon 默认为空"),
        NotifyParentProperty(true),
        ]
        public string ButtonIcon
        {
            get
            {
                return _ButtonIcon;
            }
            set
            {
                _ButtonIcon = value;
            }
        }
        /// <summary> 
        /// 按钮是否显示 默认为true
        /// </summary>

        [
        Category("Behavior"),
        DefaultValue(""),
        Description("按钮是否显示 默认为true"),
        NotifyParentProperty(true),
        ]
        public bool ButtonVisible
        {
            get
            {
                return _ButtonVisible;
            }
            set
            {
                _ButtonVisible = value;
            }
        }
        #endregion

    }
}
