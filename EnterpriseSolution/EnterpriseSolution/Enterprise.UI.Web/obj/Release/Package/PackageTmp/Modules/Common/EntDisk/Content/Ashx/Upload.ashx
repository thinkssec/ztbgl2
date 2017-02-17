<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;
using Enterprise.Component.Infrastructure;

public class Upload : IHttpHandler {

    public void ProcessRequest (HttpContext context) {
        try
        {

            //文件保存目录路径
            string saveFilePath = FileHelper.RootFolder(context.Request.QueryString["path"]);
            string saveUrlPath = "/Public/" + context.Request.QueryString["path"] + "/";
            if (context.Request.Files["Filedata"] != null)
            {
                HttpPostedFile myFile = context.Request.Files["Filedata"];
                int nFileLen = myFile.ContentLength;
                byte[] myData = new byte[nFileLen];
                myFile.InputStream.Read(myData, 0, nFileLen);
                //文件保存名称
                string fileName = myFile.FileName;
                System.IO.FileStream newFile = new System.IO.FileStream(
                    saveFilePath + Path.DirectorySeparatorChar + fileName, System.IO.FileMode.Create);
                newFile.Write(myData, 0, myData.Length);
                newFile.Close();

                //输出实际保存的文件名
                context.Response.AddHeader("Content-Type", "text/html; charset=UTF-8");
                context.Response.Write(saveUrlPath + fileName);
                context.Response.End();
            }

            ////if (string.IsNullOrEmpty(filepath))
            ////{
            ////    filepath = HttpContext.Current.Server.MapPath(FileHelper.RootServerFolder);
            ////}
            ////else
            ////{
            ////    filepath = HttpContext.Current.Server.MapPath(FileHelper.RootServerFolder + FileHelper.Decrypt(filepath));
            ////}
            //filepath = FileHelper.RootFolder(filepath);
            //HttpPostedFile upload = context.Request.Files["Filedata"];
            //string name = upload.FileName; //DateTime.Now.Ticks.ToString() + Path.GetExtension(upload.FileName);

            //upload.SaveAs(Path.Combine(filepath, name));

            //context.Response.StatusCode = 200;
            //context.Response.Write(name);

            //#region "写入日志文件"
            ////LogServices.WriteLog("操作 : 上传文件 ; 文件名称: " + name);
            //#endregion
            
            
        }
        catch(Exception ex)
        {
            context.Response.StatusCode = 200;
            context.Response.Write(ex);
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}