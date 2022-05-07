using Aetly.Data;
using Aetly.MOD;
using Aetly.util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Aetly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class StksController : ControllerBase
    {
        public static homeContext _context = null;// new home_QQContext();
        // GET: api/<StksController>
        [HttpGet]
        public IActionResult Get()
        {
            string str = https.GetHttpResponse("https://r.qzone.qq.com/fcg-bin/cgi_get_portrait.fcg?uins=1600211151");
            //portraitCallBack({"1600211151":["http://qlogo4.store.qq.com/qzone/1600211151/1600211151/100",11363,-1,0,0,0,"淄博冠军王哥",0]})
            JObject json = JObject.Parse(str.Split('(')[1].Split(')')[0]);
            string resp = json.GetValue("1600211151")[6].ToString();
            // resp = https.UTF8ToGB2312(resp);
            Stks stks = new Stks();
            stks.Name = resp;

            JsonResult jsonResult = new JsonResult(stks);
            return jsonResult;
        }

        // GET api/<StksController>/5
        [HttpGet("{id}")]
        public IActionResult GetAsync(string id)
        {
            if (id=="bilibili")
            {
                return Rgx.bilibili();
            }
            return null;

        }

        

        // POST api/<StksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<StksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
