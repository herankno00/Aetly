using Aetly.Data;
using Aetly.MOD;
using Aetly.util;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aetly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DmgController : ControllerBase
    {
      

        // GET: api/<DmgController>
        [HttpGet]
        public IActionResult Get(string str)
        {
            //string [] s=str.Split('@');
            //home_Mk hm = new home_Mk();
            //hm.mk_name = s[0];
            //hm.mk_time = s[1];
            //hm.mk_singer = s[2]; try
            //{
            //    if (DataList.addmk(hm))
            //    {
            //        return "成功";

            //    }
            //    return "失败";
            //}
            //catch (Exception)
            //{

            //    return "失败";
            //}
            JsonResult json = null;

            if (str== "bilibili")
            {

                try
                {
                    json = Rgx.bilibili();

                }
                catch (Exception)
                {

                    json = new JsonResult("失败");
                }

            }
            return json;
        }

        // GET api/<DmgController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<DmgController>
        [HttpPost]
        public IActionResult Post( )
        {
                JsonResult jsonResult;
        int index = int.Parse(Request.Form["index"]);
            string typep = Request.Form["type"];
            List<home_Mk> blogslists = null;
            List<home_Gm> blogslistsgm = null;
            if (typep=="音乐")
            {
                blogslists = DataList.home_Mk;
                int count = blogslists.Count;
                int abs = count % 50;
                int page = abs == 0 ? count / 50 : (count / 50) + 1;
                if (index > page)
                {
                    blogslists = new List<home_Mk>();
                    jsonResult = new JsonResult(blogslists);
                    return jsonResult;
                }


                if (count - index * 50 >= 0)
                {
                    blogslists = blogslists.Skip(count - index * 50).Take(50).ToList();
                }
                else
                {

                    blogslists = blogslists.Take(abs).ToList();
                }

                jsonResult = new JsonResult(blogslists);
                return jsonResult;
            }
            else if (typep=="游戏")
            {
                blogslistsgm = DataList.home_Gm;
                int count = blogslistsgm.Count;
                int abs = count % 5;
                int page = abs == 0 ? count / 5 : (count / 5) + 1;
                if (index > page)
                {
                    blogslistsgm = new List<home_Gm>();
                    jsonResult = new JsonResult(blogslistsgm);
                    return jsonResult;
                }


                if (count - index * 5 >= 0)
                {
                    blogslistsgm = blogslistsgm.Skip(count - index * 5).Take(5).ToList();
                }
                else
                {

                    blogslistsgm = blogslistsgm.Take(abs).ToList();
                }

                jsonResult = new JsonResult(blogslistsgm);
                return jsonResult;
            }
            return new JsonResult("");
        }

        // PUT api/<DmgController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DmgController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
