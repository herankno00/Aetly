using Aetly.MOD;
using Microsoft.EntityFrameworkCore;

namespace Aetly.Data
{
    public class ErrorContext : DbContext
    {
        private readonly IConfiguration _Configuration;//读取配置文件
        public DbSet<Error> Error { get; set; }
        public ErrorContext(IConfiguration configuration)
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
