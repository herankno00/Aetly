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
    }
}
