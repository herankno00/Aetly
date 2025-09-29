using Aetly.MOD;

namespace Aetly.Data
{
    public static  class DataList
    {
        private static   homeContext _hqcontext;
        private static   ErrorContext _ercontext;
         
        public static List<home_QQ> home_QQs = new List<home_QQ>();
        public static List<Error > error = new List<Error>();
        public static List<home_Cs> home_Cs = new List<home_Cs>();
        public static List<home_Mk> home_Mk = new List<home_Mk>();
        public static List<home_Gm> home_Gm = new List<home_Gm>();
        public static List<Collection> collections = new List<Collection>();
        public static IConfiguration config = null;
        #region//home_Mk
        public static void homemkloadtk(IConfiguration configuration)
        {
            if (_hqcontext == null)
            {
                config = configuration;
                _hqcontext = new homeContext(configuration);
            }
            home_Mk = _hqcontext.home_Mk.ToList();
        }
        /// <summary>
        /// 增加home_QQ
        /// </summary>
        /// <param name="value">添加的数据</param>
        /// <returns>true</returns>
        public static bool addmk(home_Mk value)
        {
            _hqcontext.home_Mk.Add(value);
            _hqcontext.SaveChanges();
            DataList.homemkloadtk(config);
            return true;
        }
        #endregion

        #region//homeqq
        public static void homeqqloadtk(IConfiguration configuration) {
            if (_hqcontext == null)
            {
                config = configuration;
                _hqcontext = new homeContext(configuration);
            }
            home_QQs= _hqcontext.home_QQ.ToList();
        }
        /// <summary>
        /// 增加home_QQ
        /// </summary>
        /// <param name="value">添加的数据</param>
        /// <returns>true</returns>
        public static bool addhq(home_QQ value)
        {
            _hqcontext.home_QQ.Add(value);
            _hqcontext.SaveChanges();
            DataList.homeqqloadtk(config);
            return true;
        }
        #endregion

        #region//homecs
        public static void homecsloadtk(IConfiguration configuration)
        {
            if (_hqcontext == null)
            {
                config = configuration;
                _hqcontext = new homeContext(configuration);
            }
            home_Cs = _hqcontext.home_Cs.ToList();
        }
        /// <summary>
        /// 增加home_Cs
        /// </summary>
        /// <param name="value">添加的数据</param>
        /// <returns>true</returns>
        public static bool addCs(home_Cs value)
        {
            _hqcontext.home_Cs.Add(value);
            _hqcontext.SaveChanges();
            DataList.homeqqloadtk(config);
            return true;
        }
        #endregion


        #region//error
        public static void errorloadtk(IConfiguration configuration)
        {
            if (_ercontext == null)
            {
                config = configuration;
                _ercontext = new ErrorContext(configuration);
            }
            error = _ercontext.Error.ToList();
        }
        /// <summary>
        /// 增加Error
        /// </summary>
        /// <param name="value">添加的数据</param>
        /// <returns>true</returns>
        public static bool adderrorlog(Error value)
        {
            _ercontext.Error.Add(value);
            _ercontext.SaveChanges();
            DataList.errorloadtk(config);
            return true;
        }
        #endregion

        #region//gm
        public static void homeloadgm(IConfiguration configuration)
        {
            if (_hqcontext == null)
            {
                config = configuration;
                _hqcontext = new homeContext(configuration);
            }
            home_Gm = _hqcontext.home_Gm.ToList();
        }
        /// <summary>
        /// 增加Error
        /// </summary>
        /// <param name="value">添加的数据</param>
        /// <returns>true</returns>
        public static bool homeloadgm(home_Gm value)
        {
            _hqcontext.home_Gm.Add(value);
            _hqcontext.SaveChanges();
            DataList.homeloadgm(config);
            return true;
        }
        #endregion

        #region//collections
        /// <summary>
        /// 初始化收藏列表数据
        /// </summary>
        public static void initializeCollections()
        {
            if (collections.Count == 0)
            {
                collections.AddRange(new List<Collection>
                {
                    new Collection { ID = 1, name = "古董花瓶", price = 1288.00m, collection_count = 3, image_path = "vase1.jpg", description = "清代青花瓷花瓶", created_time = DateTime.Now.AddDays(-30) },
                    new Collection { ID = 2, name = "古书籍", price = 588.00m, collection_count = 15, image_path = "book1.jpg", description = "明代古籍善本", created_time = DateTime.Now.AddDays(-25) },
                    new Collection { ID = 3, name = "玉器摆件", price = 2888.00m, collection_count = 5, image_path = "jade1.jpg", description = "和田玉观音摆件", created_time = DateTime.Now.AddDays(-20) },
                    new Collection { ID = 4, name = "古代钱币", price = 188.00m, collection_count = 50, image_path = "coin1.jpg", description = "宋代铜钱", created_time = DateTime.Now.AddDays(-15) },
                    new Collection { ID = 5, name = "字画作品", price = 3888.00m, collection_count = 8, image_path = "painting1.jpg", description = "名家山水画", created_time = DateTime.Now.AddDays(-10) },
                    new Collection { ID = 6, name = "陶瓷茶具", price = 788.00m, collection_count = 12, image_path = "tea1.jpg", description = "景德镇陶瓷茶具套装", created_time = DateTime.Now.AddDays(-5) }
                });
            }
        }

        /// <summary>
        /// 添加收藏品
        /// </summary>
        /// <param name="value">收藏品数据</param>
        /// <returns>true</returns>
        public static bool addCollection(Collection value)
        {
            value.ID = collections.Count > 0 ? collections.Max(c => c.ID) + 1 : 1;
            value.created_time = DateTime.Now;
            collections.Add(value);
            return true;
        }
        #endregion
    }
}
