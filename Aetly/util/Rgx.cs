using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Aetly.util
{
    public static class Rgx
    {
        //tkvalue
        public static JsonResult bilibili()
        {
            JsonResult json = null;
            string re = Requests.Get("https://space.bilibili.com/381372318");
            string stsr = re.Trim();
            Regex r = new Regex("apple-touch-icon"); // 定义一个Regex对象实例
            Match m = r.Match(stsr); // 在字符串中匹配
          
            string stsr2 = stsr.Substring(2512, stsr.Length - 2512).Split('\"')[1];
            string[] str = new string  [2];
            str[0] = stsr2;
            Regex r4 = new Regex("个人空间"); // 定义一个Regex对象实例
            Match m4 = r4.Match(stsr); // 在字符串中匹配


            Regex r5 = new Regex("title"); // 定义一个Regex对象实例
            Match m5 = r5.Match(stsr); // 在字符串中匹配

            string stsr3 = stsr.Substring(m5.Index + 6, m4.Index - m5.Index - 1 - 6);
            str[1] = stsr3;
            json    = new JsonResult(str); ;
            return json;
        }
    }
}
