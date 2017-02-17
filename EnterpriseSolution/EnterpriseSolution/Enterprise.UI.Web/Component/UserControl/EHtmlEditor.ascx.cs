using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Enterprise.Component.Infrastructure;

namespace Enterprise.UI.Web.Component.UserControl
{
    public partial class EHtmlEditor : System.Web.UI.UserControl
    {

        public int MaxLength { get; set; }
        public bool Required { get; set; }
        public ShowTool Tools { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ToolString { get; set; }
        public string invalidMessage { get; set; }
        public string Text { get { return tb_htmleditor.Text; } set { tb_htmleditor.Text = value; } }
        public string HtmlId { get { return tb_htmleditor.ClientID; } }
        public string OnUpladFunc { get; set; }

        public EHtmlEditor()
        {
            ToolString = "mini";
            Tools = ShowTool.mini;
            MaxLength = 2000;
            Required = false;
            Height = 140;
            Width = 600;
            invalidMessage = string.Empty;
            OnUpladFunc = "DoNothing";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Tools == ShowTool.noUpload)
                {
                    ToolString = "Cut,Copy,Paste,|,FontSize,Bold,Align,List";
                }
                if (Tools == ShowTool.full)
                    ToolString = "full";
                if (Tools == ShowTool.mini)
                    ToolString = "mini";
                if (Tools == ShowTool.simple)
                    ToolString = "simple";
            }
        }
        
    }

    public enum ShowTool { 
        full,
        simple,
        mini,
        noUpload
    }
}