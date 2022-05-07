using Newtonsoft.Json;
using System.Text.Json.Serialization;
namespace Aetly.MOD
{
    public class objectHome {
        [System.Text.Json.Serialization.JsonIgnore]
        public int ID { get; set; }
        public string? title { get; set; }
        public string? Time { get; set; }
        public string? image_path { get; set; }
        public string? content_txt { get; set; }
    }

    public class home_QQ: objectHome
    {
 
        public string? like_num { get; set; }
        public string? Jz_path { get; set; }
    }
    public class   home_Cs : objectHome
    {
    }
    public class home_Mk {
    
        public string? mk_name { get; set; }
        public string? mk_time { get; set; }
        public string? mk_singer { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public int ID { get; set; }
    }
    public class home_Gm
    {
        public string? gm_image_path{ get; set; }
        public string? gm_name { get; set; }
        public string? gm_text { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public int ID { get; set; }
    }
}
