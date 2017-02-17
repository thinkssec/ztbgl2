using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Enterprise.Component.Infrastructure;
using System.Text;
using System.Collections;

namespace Enterprise.UI.Web.Modules.Demo.SupCan
{
    public partial class TreeListDemo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnOk_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            try
            {
                string data = Server.UrlDecode(HDData.Value);
                sb.Append(SupCanTool.InsertSQL(data, "a0", typeof(ShipHwModel)) + "<br/>");
                sb.Append(SupCanTool.UpdateSQL(data, "b0", typeof(ShipHwModel)) + "<br/>");
                sb.Append(SupCanTool.DeleteSQL(data, "c0", typeof(ShipHwModel)));
                //sb.Append();
                //string aa = Server.UrlDecode(HDData.Value);
                Response.Write(sb.ToString());
                Response.End();
                //ClientScript.RegisterStartupScript(this.GetType(), "", "<script type='text/javascript' language='javascript'>alert('" +  + "');</script>");
            }
            catch
            {

            }
        }

        protected string GetObjectData()
        {
            List<ShipHwModel> list = new List<ShipHwModel>();

            ShipHwModel m = new ShipHwModel();
            m.OrderID = "10249";//订单号
            m.Country = "Germany";//国家
            m.CustomerID = "TOMSP";//客户号
            m.OrderDate = DateTime.Parse("2006-7-4");//销售日期
            //m.RequiredDate = DateTime.Parse("2006-8-5");//接单日期
            m.Freight = 65.83;//货重
            m.ShipName = "Victuailles en stock";//船名
            m.ShipCity = "Reims";//城市
            m.ShipAddress = "Rua do Pao, 67";//地址
            list.Add(m);

            m = new ShipHwModel();
            m.OrderID = "10248";//订单号
            m.Country = "France";//国家
            m.CustomerID = "VINET";//客户号
            m.OrderDate = DateTime.Parse("2006-07-04");//销售日期
            m.RequiredDate = DateTime.Parse("2006-08-01");//接单日期
            m.Freight = 22;//货重
            m.ShipName = "Hanari Carnes";//船名
            m.ShipCity = "Lyon";//城市
            m.ShipAddress = "2, rue du Commerce";//地址
            list.Add(m);

            m = new ShipHwModel();
            m.OrderID = "10300";//订单号
            m.Country = "France";//国家
            m.CustomerID = "VINET";//客户号
            m.OrderDate = DateTime.Parse("2006-07-04");//销售日期
            m.RequiredDate = DateTime.Parse("2006-08-01");//接单日期
            m.Freight = 22;//货重
            m.ShipName = "Hanari Carnes";//船名
            m.ShipCity = "Lyon";//城市
            m.ShipAddress = "2, rue du Commerce";//地址
            list.Add(m);

            m = new ShipHwModel();
            m.OrderID = "10301";//订单号
            m.Country = "France";//国家
            m.CustomerID = "VINET";//客户号
            m.OrderDate = DateTime.Parse("2006-07-04");//销售日期
            m.RequiredDate = DateTime.Parse("2006-08-01");//接单日期
            m.Freight = 22;//货重
            m.ShipName = "Hanari Carnes";//船名
            m.ShipCity = "Lyon";//城市
            m.ShipAddress = "2, rue du Commerce";//地址
            list.Add(m);

            ArrayList array = new ArrayList();
            array.AddRange(list);

            List<string> colNames = new List<string>();
            colNames.Add("OrderID");
            colNames.Add("Country");
            colNames.Add("CustomerID");
            colNames.Add("OrderDate");
            colNames.Add("RequiredDate");
            colNames.Add("Freight");
            colNames.Add("ShipName");
            colNames.Add("ShipCity");
            colNames.Add("ShipAddress");

            return (SupCanTool.ConvertArrayToSupCanXml(array, typeof(ShipHwModel), colNames.ToArray(), 0, 1000));
        }

    }
}