using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Enterprise.UI.Web.Modules.App.Project
{
    /// <summary>
    /// my 的摘要说明
    /// </summary>
    public class my : IHttpHandler
    {
        string ImageStoragePath = HttpContext.Current.Server.MapPath("~/Modules/Public/Zbwj/").ToString();
        string sourcePath = HttpContext.Current.Server.MapPath("~/Modules/Public/Zbwj/Null").ToString();
        const string suffix = ".doc";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String fileName="xmzb"; 
            String projid="asdfasa-1123";
            //sourcePath = sourcePath + "/" + projid;
            if (!Directory.Exists(sourcePath))
            {
                Directory.CreateDirectory(sourcePath);
            }

            FileStream fff = null;
            try
            {
                //if (File.Exists(Path.Combine(sourcePath, fileName + suffix)))
                //{
                //    File.Delete(Path.Combine(sourcePath, fileName + suffix));
                //}

                //fff = new FileStream(Path.Combine(sourcePath, fileName + suffix), FileMode.OpenOrCreate, FileAccess.ReadWrite);

            }
            catch (Exception e)
            {
            }
            finally
            {
                if (fff != null)
                    fff.Close();
                fff = null;
            }

            string filePath = Path.Combine(ImageStoragePath, fileName + suffix);
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
            else
            {
            }
            string targetPath = ImageStoragePath;
            string sourceFile = System.IO.Path.Combine(sourcePath, fileName + suffix);
            //Directory.Delete(targetPath + deptN,true);
            if (!Directory.Exists(targetPath + projid))
            {
                Directory.CreateDirectory(targetPath + projid);
            }
            ReplaceToWord(sourceFile, System.IO.Path.Combine(targetPath + projid, fileName + suffix));

            context.Response.Write("Hello World");
        }
        protected void ReplaceToWord(string moban,string dest)
        {

            Application app = null;
            Microsoft.Office.Interop.Word.Document doc = null;
            //将要导出的新word文件名
            //string newFile = DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc";
            string physicNewFile = dest;
            try
            {
                app = new Application();//创建word应用程序
                object fileName = moban;//模板文件
                //打开模板文件
                object oMissing = System.Reflection.Missing.Value;
                doc = app.Documents.Open(ref fileName,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing);

                //构造数据
                Dictionary<string, string> datas = new Dictionary<string, string>();
                datas.Add("{param.000}", "张三");
                datas.Add("{param.001}", "dddddddddddddddddasdfasd大是大非");
                datas.Add("{param.zbf1}", "男");
                datas.Add("{provinve}", "浙江");
                datas.Add("{address}", "浙江省杭州市");
                datas.Add("{education}", "本科");
                datas.Add("{telephone}", "12345678");
                datas.Add("{cardno}", "123456789012345678");

                object replace = WdReplace.wdReplaceAll;
                foreach (var item in datas)
                {
                    app.Selection.Find.Replacement.ClearFormatting();
                    app.Selection.Find.ClearFormatting();
                    app.Selection.Find.Text = item.Key;//需要被替换的文本
                    app.Selection.Find.Replacement.Text = item.Value;//替换文本 

                    //执行替换操作
                    app.Selection.Find.Execute(
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing, ref oMissing,
                    ref oMissing, ref replace,
                    ref oMissing, ref oMissing,
                    ref oMissing, ref oMissing);
                }

                //对替换好的word模板另存为一个新的word文档
                doc.SaveAs(physicNewFile,
                oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing, oMissing,
                oMissing, oMissing, oMissing, oMissing, oMissing, oMissing);

                //准备导出word
                //Response.Clear();
                //Response.Buffer = true;
                //Response.Charset = "utf-8";
                //Response.AddHeader("Content-Disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMddHHmmssss") + ".doc");
                //Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
                //Response.ContentType = "application/ms-word";
                //Response.End();
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                //这边为了捕获Response.End引起的异常
            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (doc != null)
                {
                    doc.Close();//关闭word文档
                }
                if (app != null)
                {
                    app.Quit();//退出word应用程序
                }
                //如果文件存在则输出到客户端
                //if (File.Exists(physicNewFile))
                //{
                //    Response.WriteFile(physicNewFile);
                //}
            }
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