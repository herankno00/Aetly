using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace Aetly.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SjlController : ControllerBase
    {
        // GET: api/qh
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
        [HttpPost]
        public string Getcontent(int index) {

            return "名称，价格，收藏数量";

        }

    }
}
