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
    /// <summary>
    /// SupCanDataHandler 的摘要说明
    /// </summary>
    public class SupCanDataHandler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write(GetObjectData());
        }

        protected string GetObjectData()
        {
            List<ShipHwModel> list = new List<ShipHwModel>();

            ShipHwModel m = new ShipHwModel();
            m.OrderID  = "10249";//订单号
            m.Country  = "Germany";//国家
            m.CustomerID = "TOMSP";//客户号
            m.OrderDate = DateTime.Parse("2006-7-4");//销售日期
            //m.RequiredDate = DateTime.Parse("2006-8-5");//接单日期
            m.Freight = 65.83;//货重
            m.ShipName  = "Victuailles en stock";//船名
            m.ShipCity  = "Reims";//城市
            m.ShipAddress  = "Rua do Pao, 67";//地址
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

        protected string GetData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("OrderID", typeof(System.String));
            dt.Columns.Add("Country", typeof(System.String));
            dt.Columns.Add("CustomerID", typeof(System.String));
            dt.Columns.Add("OrderDate", typeof(System.String));
            dt.Columns.Add("RequiredDate", typeof(System.String));
            dt.Columns.Add("Freight", typeof(System.String));
            dt.Columns.Add("ShipName", typeof(System.String));
            dt.Columns.Add("ShipCity", typeof(System.String));
            dt.Columns.Add("ShipAddress", typeof(System.String));
            /*
            国家
            订单号
            客户号
            销售日期
            接单日期
            货重  double
            船名
            城市
            地址
             * 
            France	10248	VINET	2006-7-4	2006-8-1		"Com Test'c	5bc"	Reims	
            Germany	10249	TOMSP	2006-7-4	2006-8-16	11.6100	Toms Spezialitten	Munster	Luisenstr. 48
            Brazil	10250	HANAR	2006-7-4	2006-8-5	65.8300	Hanari Carnes	Rio de Janeiro	Rua do Pao, 67
            France	10251	VICTE	2006-7-4	2006-8-5	41.3400	Victuailles en stock	Lyon	2, rue du Commerce
             */
            DataRow dr = dt.NewRow();
            dr[0] = "10248";//订单号
            dr[1] = "France";//国家
            dr[2] = "VINET";//客户号
            dr[3] = "2006-07-04";//销售日期
            dr[4] = "2006-08-01";//接单日期
            dr[5] = "22";//货重
            dr[6] = "Hanari Carnes";//船名
            dr[7] = "Lyon";//城市
            dr[8] = "2, rue du Commerce";//地址
            dt.Rows.Add(dr);
            dr = dt.NewRow();
            dr[0] = "10249";//订单号
            dr[1] = "Germany";//国家
            dr[2] = "TOMSP";//客户号
            dr[3] = "2006-7-4";//销售日期
            dr[4] = "2006-8-5";//接单日期
            dr[5] = "65.83";//货重
            dr[6] = "Victuailles en stock";//船名
            dr[7] = "Reims";//城市
            dr[8] = "Rua do Pao, 67";//地址
            dt.Rows.Add(dr);

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
            //"OrderID,Country,CustomerID,OrderDate,RequiredDate,Freight,ShipName,ShipCity,ShipAddress"
            string[] arr = colNames.ToArray();
            return (SupCanTool.ConvertDataTableToSupCanXml(dt, arr.ToJoin(','), 0, 1000));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}