using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Enterprise.Component.Infrastructure;
namespace Enterprise.Component.Control
{
    /// <summary>
    /// 创建按钮
    /// </summary>
    public class CreateBT
    {
        /// <summary>
        /// 常用Button添加代码 By Caitou 2011/5/9  9:12
        /// </summary>
        /// <param name="name">System name</param>
        /// <param name="url">The URL.</param>
        /// <param name="pType">Type of the p.</param>
        /// <param name="head">The head.</param>
        /// UserName:Caitou
        /// Date：2011/5/9 9:12
        /// MachineName:CAITOU-PC
        public static void AddButton(string url, Utility.PopedomType pType, HeadMenuWebControls head)
        {
            HeadMenuButtonItem bt = new HeadMenuButtonItem();
            bt.ButtonUrl = url;
            bt.ButtonPopedom = pType;
            bt.ButtonUrlType = Utility.UrlType.Href;
            head.ButtonList.Add(bt);
        }
        /// <summary>
        /// 常用Button添加代码 By Caitou 2011/5/9  9:12
        /// </summary>
        /// <param name="name">System name</param>
        /// <param name="url">The URL.</param>
        /// <param name="pType">Type of the p.</param>
        /// <param name="head">The head.</param>
        /// UserName:Caitou
        /// Date：2011/5/9 9:12
        /// MachineName:CAITOU-PC
        public static void AddButton(string btIco, string name, string url, Utility.PopedomType pType, HeadMenuWebControls head)
        {
            HeadMenuButtonItem bt = new HeadMenuButtonItem();
            bt.ButtonIcon = btIco;
            bt.ButtonName = name;
            bt.ButtonUrl = url;
            bt.ButtonPopedom = pType;
            bt.ButtonUrlType = Utility.UrlType.Href;
            head.ButtonList.Add(bt);
        }

        /// <summary>
        /// 常用Button添加代码 By Caitou 2011/5/9  9:12
        /// </summary>
        /// <param name="name">System name</param>
        /// <param name="url">The URL.</param>
        /// <param name="pType">Type of the p.</param>
        /// <param name="head">The head.</param>
        /// UserName:Caitou
        /// Date：2011/5/9 9:12
        /// MachineName:CAITOU-PC
        public static void AddButton(string btIco, string name, string url, Utility.PopedomType pType, Utility.UrlType urlType, HeadMenuWebControls head)
        {
            HeadMenuButtonItem bt = new HeadMenuButtonItem();
            bt.ButtonIcon = btIco;
            bt.ButtonName = name;
            bt.ButtonUrl = url;
            bt.ButtonPopedom = pType;
            bt.ButtonUrlType = urlType;
            head.ButtonList.Add(bt);
        }


        /// <summary>
        /// 常用Button添加代码 By Caitou 2011/5/9  9:12
        /// </summary>
        /// <param name="name">System name</param>
        /// <param name="url">The URL.</param>
        /// <param name="pType">Type of the p.</param>
        /// <param name="head">The head.</param>
        /// UserName:Caitou
        /// Date：2011/5/9 9:12
        /// MachineName:CAITOU-PC
        public static void AddButton(string url, Utility.PopedomType pType, HeadMenuWeb head)
        {
            HeadMenuButtonItem bt = new HeadMenuButtonItem();
            bt.ButtonUrl = url;
            bt.ButtonPopedom = pType;
            bt.ButtonUrlType = Utility.UrlType.Href;
            head.ButtonList.Add(bt);
        }
        /// <summary>
        /// 常用Button添加代码 By Caitou 2011/5/9  9:12
        /// </summary>
        /// <param name="name">System name</param>
        /// <param name="url">The URL.</param>
        /// <param name="pType">Type of the p.</param>
        /// <param name="head">The head.</param>
        /// UserName:Caitou
        /// Date：2011/5/9 9:12
        /// MachineName:CAITOU-PC
        public static void AddButton(string btIco, string name, string url, Utility.PopedomType pType, HeadMenuWeb head)
        {
            HeadMenuButtonItem bt = new HeadMenuButtonItem();
            bt.ButtonIcon = btIco;
            bt.ButtonName = name;
            bt.ButtonUrl = url;
            bt.ButtonPopedom = pType;
            bt.ButtonUrlType = Utility.UrlType.Href;
            head.ButtonList.Add(bt);
        }

        /// <summary>
        /// 常用Button添加代码 By Caitou 2011/5/9  9:12
        /// </summary>
        /// <param name="name">System name</param>
        /// <param name="url">The URL.</param>
        /// <param name="pType">Type of the p.</param>
        /// <param name="head">The head.</param>
        /// UserName:Caitou
        /// Date：2011/5/9 9:12
        /// MachineName:CAITOU-PC
        public static void AddButton(string btIco, string name, string url, Utility.PopedomType pType, Utility.UrlType urlType, HeadMenuWeb head)
        {
            HeadMenuButtonItem bt = new HeadMenuButtonItem();
            bt.ButtonIcon = btIco;
            bt.ButtonName = name;
            bt.ButtonUrl = url;
            bt.ButtonPopedom = pType;
            bt.ButtonUrlType = urlType;
            head.ButtonList.Add(bt);
        }

    }
}
