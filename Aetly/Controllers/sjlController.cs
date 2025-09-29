using Aetly.Data;
using Aetly.MOD;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Aetly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SjlController : ControllerBase
    {
        // GET: api/sjl
        [HttpGet]
        public ActionResult Gethome(string path)
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
        
        /// <summary>
        /// 获取收藏列表内容 (Get collection list content)
        /// </summary>
        /// <param name="index">页码 (Page number)</param>
        /// <returns>收藏品列表 (Collection items list)</returns>
        [HttpPost]
        public IActionResult Getcontent(int index) 
        {
            JsonResult jsonResult;
            List<Collection> collectionsList = DataList.collections;
            
            if (index <= 0)
            {
                Error er = new() 
                { 
                    msg = "页码错误",
                    alltext = "收藏列表页码参数错误",
                    Time = DateTime.Now.ToString("F")
                };
                DataList.adderrorlog(er);
                return new JsonResult("页码错误");
            }

            int count = collectionsList.Count;
            int pageSize = 6; // 每页显示6个收藏品
            int abs = count % pageSize;
            int page = abs == 0 ? count / pageSize : (count / pageSize) + 1;
            
            if (index > page)
            {
                collectionsList = new List<Collection>();
                jsonResult = new JsonResult(collectionsList);
                return jsonResult;
            }

            // 分页逻辑：从最新的开始显示
            if (count - index * pageSize >= 0)
            {
                collectionsList = collectionsList.Skip(count - index * pageSize).Take(pageSize).ToList();
            }
            else
            {
                collectionsList = collectionsList.Take(abs).ToList();
            }

            jsonResult = new JsonResult(collectionsList);
            return jsonResult;
        }

        /// <summary>
        /// 添加收藏品 (Add collection item)
        /// </summary>
        /// <param name="collection">收藏品信息</param>
        /// <returns>操作结果</returns>
        [HttpPut]
        public IActionResult AddCollection([FromBody] Collection collection)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(collection.name))
                {
                    return BadRequest("收藏品名称不能为空");
                }

                DataList.addCollection(collection);
                return Ok("收藏品添加成功");
            }
            catch (Exception ex)
            {
                Error er = new() 
                { 
                    msg = "添加收藏品失败",
                    alltext = ex.Message,
                    Time = DateTime.Now.ToString("F")
                };
                DataList.adderrorlog(er);
                return StatusCode(500, "添加收藏品失败");
            }
        }
    }
}
