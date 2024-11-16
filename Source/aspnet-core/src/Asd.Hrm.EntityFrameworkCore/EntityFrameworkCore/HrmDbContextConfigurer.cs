using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Asd.Hrm.EntityFrameworkCore
{
    public static class HrmDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<HrmDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<HrmDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}