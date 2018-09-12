using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Reflection;
using System.Data;
using System.Collections;
using System.Net;
using System.Collections.Specialized;

namespace application.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// 请求Http页面
        /// </summary>
        /// <param name="url"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static string GetHtml(string url, int timeout)
        {
            string strResult;
            try
            {
                HttpWebRequest myReq = (HttpWebRequest)HttpWebRequest.Create(url);
                myReq.Timeout = timeout;
                HttpWebResponse HttpWResp = (HttpWebResponse)myReq.GetResponse();
                Stream myStream = HttpWResp.GetResponseStream();
                StreamReader sr = new StreamReader(myStream, Encoding.Default);
                StringBuilder strBuilder = new StringBuilder();
                while (-1 != sr.Peek())
                {
                    strBuilder.Append(sr.ReadLine());
                }

                strResult = strBuilder.ToString();
            }
            catch (Exception exp)
            {
                strResult = "错误：" + exp.Message;
            }

            return strResult;
        }

        /// <summary>
        /// 获取指定网页源码
        /// </summary>
        /// <param name="url">指定的网页</param>
        /// <returns>网页源码</returns>
        public static string GetHtml(string url)
        {
            string strHTML = "";
            WebClient myWebClient = new WebClient();
            Stream myStream = myWebClient.OpenRead(url);
            StreamReader sr = new StreamReader(myStream, Encoding.GetEncoding("gb2312"));
            strHTML = sr.ReadToEnd();
            myStream.Close();
            return strHTML;
        }
        /// <summary>
        /// 指定网页并返回 (每日一词语)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string getPostBackStream(string url)
        {
            WebClient myWebClient = new WebClient();
            NameValueCollection myNameValueCollection = new NameValueCollection();
            myNameValueCollection.Add("title", "this is title");
            myNameValueCollection.Add("excerpt", "this is excerpt");
            byte[] responseArray = myWebClient.UploadValues(url, "POST", myNameValueCollection);
            return Encoding.UTF8.GetString(responseArray);
        }
        /// <summary>
        /// 获取网页图片(http://cdn.iciba.com/news/word/big_20180618b.jpg)
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static System.Drawing.Image GrabAPicture(string url)
        {
            System.Net.WebRequest webreq = System.Net.WebRequest.Create(url);
            System.Net.WebResponse webres = webreq.GetResponse();
            using (System.IO.Stream stream = webres.GetResponseStream())
            {
                 return  System.Drawing.Image.FromStream(stream);//Image.FromStream(stream);
            }
        }
    }
}
