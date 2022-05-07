#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Aetly.Data;
using Aetly.MOD;
using Microsoft.Extensions.Options;
using System.Drawing;
using System.Collections.Generic;

namespace Aetly.Controllers
{
    /// <summary>
    /// 日常post
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class qhController : ControllerBase
    {
        public qhController(IConfiguration configuration)
        {
            //_context = new home_QQContext(configuration);
        }

        // GET: api/qh
        [HttpGet]
        public    ActionResult  Gethome(string path)
        {
            Image img = null;
            MemoryStream ms;
            try
            {
                img = Image.FromFile(@"./images/dd/" + path);
                  ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (Exception)
            {
               
                img = Image.FromFile(@"./images/dd/isanlul.png");
                 ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
          
   
            return File(ms.ToArray(), "image/jpg");
        }


        // POST: api/qh
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123764
        [HttpPost]
        public IActionResult Posthome_QQ()
        {
            
            int index = int.Parse(Request.Form["index"]);
            string typep =  Request.Form["type"];
            List<home_QQ>  blogslist =null ;
            List<home_Cs>  blogslists =null ;

            JsonResult jsonResult = new JsonResult("页码错误"); ;
            // JsonResult jsonResult = new JsonResult(DataList.error); ;

            if (index <= 0)
            {
                Error er = new() { msg="页码错误",alltext="测试",Time= DateTime.Now.ToString("F")

            };
                DataList.adderrorlog(er); 
                return jsonResult;
            }
            if (typep=="c#")
            {
                blogslists = DataList.home_Cs;
                int count = blogslists.Count;
                int abs = count % 6;
                int page = abs == 0 ? count / 6 : (count / 6) + 1;
                if (index > page)
                {
                    blogslists = new List<home_Cs>();
                    jsonResult = new JsonResult(blogslists);
                    return jsonResult;
                }


                if (count - index * 6 >= 0)
                {
                    blogslists = blogslists.Skip(count - index * 6).Take(6).ToList();
                }
                else
                {

                    blogslists = blogslists.Take(abs).ToList();
                }

                jsonResult = new JsonResult(blogslists);
                return jsonResult;
            }
            else
            {
                blogslist = DataList.home_QQs;
                int count = blogslist.Count;
                int abs = count % 6;
                int page = abs == 0 ? count / 6 : (count / 6) + 1;
                if (index > page)
                {
                    blogslist = new List<home_QQ>();
                    jsonResult = new JsonResult(blogslist);
                    return jsonResult;
                }


                if (count - index * 6 >= 0)
                {
                    blogslist = blogslist.Skip(count - index * 6).Take(6).ToList();
                }
                else
                {

                    blogslist = blogslist.Take(abs).ToList();
                }

                jsonResult = new JsonResult(blogslist);
                return jsonResult;

            }
       
        }



    }


}
