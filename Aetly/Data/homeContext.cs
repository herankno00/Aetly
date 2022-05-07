using Aetly.MOD;
using Microsoft.EntityFrameworkCore;
 
namespace Aetly.Data

{
    public class homeContext : DbContext
    {
        private readonly IConfiguration _Configuration;//读取配置文件
        public DbSet<home_QQ> home_QQ { get; set; }
        public DbSet<home_Cs> home_Cs { get; set; }
        public DbSet<home_Mk> home_Mk { get; set; }
        public DbSet<home_Gm> home_Gm { get; set; }
        public homeContext(IConfiguration configuration)
        {
            _Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                   _Configuration["ConnectionStrings:DefaultConnection"]);
        }
    }
}

