using System;
using System.Text;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace getdata
{
    class Program
    {
        static void Main(string[] args)
        {
            test();
        }

        public static string HttpGet(string url, Encoding enc)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Timeout = 10000;//设置10秒超时
                request.Proxy = null;
                request.Method = "GET";
                request.ContentType = "application/x-www-from-urlencoded";
                WebResponse response = request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), enc);
                StringBuilder sb = new StringBuilder();
                sb.Append(reader.ReadToEnd());
                reader.Close();
                reader.Dispose();
                response.Close();
                return sb.ToString();
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public static void test()
        {
            string result="";
            string Url="http://f.apiplus.cn/cqssc.json";
            string html = HttpGet(Url, Encoding.UTF8);
            if (!html.Substring(0, 5).Equals("{\"row", StringComparison.OrdinalIgnoreCase))
                throw new Exception(html);
            int startindex=html.IndexOf('[');
            int endindex=html.IndexOf(']');
            html=html.Substring(startindex);
            html=html.Substring(0,html.Length-1);
            var array = JsonConvert.DeserializeObject(html) as JArray;
            foreach (var json in array)
            {
                result += "\r\n";
                result += "采集时间:"+ DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +"\r\n";
                result += "开奖行数：" + array.Count + "\r\n";
                result += "开奖期号：" + json["expect"].ToString() + "\r\n";
                result += "开奖号码：" + json["opencode"].ToString() + "\r\n";
                result += "开奖时间：" + json["opentime"].ToString() + "\r\n";
            }
            
            System.Console.Write(result);
        }


    }
}
