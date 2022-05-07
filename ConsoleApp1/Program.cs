using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;


namespace ConsoleApp1
{

    internal class Program
    {
        //public int ID { get; set; }
        //public string? CZR { get; set; }
        //public string? CZRCARD { get; set; }
        //public string? BCXR { get; set; }
        //public string? BCXRCARD { get; set; }
        //public string? CXLX { get; set; }
        //public string? YT { get; set; }
        //public string? CXSJ { get; set; }
        static void Main(string[] args)
        {
            //string str = Console.ReadLine();
            // string[] str1 =  File.ReadAllLines(@"C:\Users\whater\Desktop\sc.txt");
            // string[] str2 =  File.ReadAllLines(@"C:\Users\whater\Desktop\ggs.txt");
            // string[] str3 = File.ReadAllLines(@"C:\Users\whater\Desktop\gs.txt");
            //for (int i = 0; i < str1.Length; i++)
            //{
            //   string ss= str3[i] + "@" + str1[i] + "@" + str2[i];
            //    string rss =  Requests.Get("https://localhost:7231/api/Dmg?str="+ss);
            //    if (rss == "成功") { 

            //        Console.WriteLine(ss+"_"+i);


            //    }  Thread.Sleep(1200); 
            //}
            //Dictionary<string, object> keyValuePairs = new Dictionary<string, object>() {
            //    { "CZR", "czr" },
            //    { "CZRCARD", "CZRCARD" },
            //    { "BCXR", "BCXR" },
            //    { "BCXRCARD", "BCXRCARD" },
            //    { "CXLX", "CXLX" },
            //    { "YT", "YT" },
            //};
            //Dictionary<string, object> keyValuePairs = new Dictionary<string, object>() {
            //    { "index", 2},
            //};

            //Console.WriteLine(re);
            // string re = Requests.Get("https://space.bilibili.com/381372318");
            // string stsr = re.Trim();

            // Regex r = new Regex("apple-touch-icon"); // 定义一个Regex对象实例
            // Match m = r.Match(stsr); // 在字符串中匹配
            // if (m.Success)
            // {

            // }

            //string stsr2 = stsr.Substring(2512, stsr.Length - 2512).Split('\"')[1];



            // Regex r4 = new Regex("个人空间"); // 定义一个Regex对象实例
            // Match m4 = r4.Match(stsr); // 在字符串中匹配


            // Regex r5 = new Regex("title"); // 定义一个Regex对象实例
            // Match m5 = r5.Match(stsr); // 在字符串中匹配

            // string stsr3 = stsr.Substring(m5.Index+6,  m4.Index- m5.Index-1 -6);
            //     Console.WriteLine(stsr3); //输入匹配字符的位置
            while (true)
            {
                Console.WriteLine(Solution.LongestPalindrome(Console.ReadLine()));

            }

            Console.ReadKey();
        }
    }
    public static class Solution
    {
        public static string sts = "";
        public static string LongestPalindrome(string s)
        {
            int let = s.Length;
            int index = 0;

            int startint = 0;
            int endint = s.Length;
            while (true)
            {
                string at = "";
                for (int i = startint; i < endint; i++)
                {
                    at += s[i]; 
                }
                if (ismaxstr(at))
                {
                    break;
                }


                endint++;
                startint++;
                if (endint > let)
                {
                index++;

                    startint = 0;
                    endint = let - index;
                    continue;
                }

            }
            return sts;

        }
        public static bool ismaxstr(string str)
        {
            char[] ca = str.ToCharArray();
            if (str == new String(ca.Reverse().ToArray()))
            {
                if (sts == "")
                {
                    sts = str;
                }
                if (str.Length < sts.Length)
                {
                    sts = str;
                }
                return true;
            }
            return false;

        }
    }
    public class Requests
    {
        //Designed By Mr.Xin 2020.4.23
        //Change By Mr.Xin 2020.5.6 解决缓存问题，引入缓存数据库  (只限于GET结构,POST 和其他数据结构另外进行添加)
        //BUG Fix By Mr.Xin 2020.5.7 禁止返回信息未空的数据
        public static string Get(string url, Dictionary<string, object> dic = null, int timeout = 10000, string UserAgent = null)
        {
            url = DicAndUrl(url, dic);
            string response = Request("GET", url, dic: dic, Timeout: timeout);
            return response;
        }
        public static string Gets(string url, Dictionary<string, object> dic = null, int timeout = 10000, string UserAgent = null)
        {
            url = DicAndUrl(url, dic);
            string response = Request("GET", url, dic: dic, Timeout: timeout);
            return response;
        }

        private static string DicAndUrl(string url, Dictionary<string, object> dic)
        {
            string param = "";
            if (dic != null)
                for (int count = 0; count < dic.Count; count++)
                    param += dic.ElementAt(count).Key + "=" + dic.ElementAt(count).Value.ToString() + "&";
            return url += "?" + param;
        }
        //这种写法很简单，但是不方面在其他的位置进行调用
        public static string Post(string url, Dictionary<string, object> dic = null, JObject json = null, int timeout = 10000, string UserAgent = null)
        {
            return Request("POST", url, dic: dic, json: json, Timeout: timeout, UserAgent: UserAgent);
        }
        public static string Put(string url, Dictionary<string, object> dic = null, int timeout = 10000, string UserAgent = null)
        {
            return Request("PUT", url, dic: dic, Timeout: timeout, UserAgent: UserAgent);
        }
        public static bool Downloade(string url, string filePath)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();

                Stream stream = new FileStream(filePath, FileMode.Create);
                byte[] bArr = new byte[1024];
                int size = responseStream.Read(bArr, 0, (int)bArr.Length);
                while (size > 0)
                {
                    stream.Write(bArr, 0, size);
                    size = responseStream.Read(bArr, 0, (int)bArr.Length);
                }
                stream.Close();
                responseStream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        ///requets 查询
        public static string Request(string Method, string url, Dictionary<string, object> dic = null, string ContentType = null, string data = null, JObject json = null, string headers = null, string cookies = null, string UserAgent = null, int Timeout = 30000, string Referer = null, string Proxy = null, bool KeepAlive = true)
        {
            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

                request.Method = Method;
                request.Referer = Referer ?? null;
                request.KeepAlive = KeepAlive;

                request.Timeout = Timeout;
                request.ServerCertificateValidationCallback = delegate { return true; };
                request.Headers.Add("cookie", cookies);

                request.UserAgent = UserAgent ?? "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/81.0.4044.113 Safari/537.36";

                if (Proxy != null)
                {
                    WebProxy WebProxy = new WebProxy(Proxy);
                    request.Proxy = WebProxy;
                }

                if (Method != "GET")
                {
                    byte[] bytePost = { };
                    if (json != null)
                    {
                        request.ContentType = "application/json;charset=utf-8";
                        bytePost = Encoding.UTF8.GetBytes(json.ToString());
                    }
                    if (dic != null)
                    {
                        request.ContentType = "application/x-www-form-urlencoded;charset=utf-8";
                        string param = "";
                        for (int count = 0; count < dic.Count; count++)
                            param += dic.ElementAt(count).Key + "=" + dic.ElementAt(count).Value.ToString() + "&";
                        bytePost = Encoding.UTF8.GetBytes(param.ToString());
                    }

                    request.ContentLength = bytePost.Length;
                    request.GetRequestStream().Write(bytePost, 0, bytePost.Length);
                    request.GetRequestStream().Close();
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader myStreamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));
                string r = myStreamReader.ReadToEnd();
                myStreamReader.Close();

                return r;
            }
            catch
            {

                return null;
            }
        }
    }


}
