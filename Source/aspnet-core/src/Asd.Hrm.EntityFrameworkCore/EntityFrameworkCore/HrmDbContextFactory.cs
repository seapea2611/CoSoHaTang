using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Asd.Hrm.Configuration;
using Asd.Hrm.Web;

namespace Asd.Hrm.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class HrmDbContextFactory : IDesignTimeDbContextFactory<HrmDbContext>
    {
        public HrmDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<HrmDbContext>();

            /*
             You can provide an environmentName parameter to the AppConfigurations.Get method. 
             In this case, AppConfigurations will try to read appsettings.{environmentName}.json.
             Use Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") method or from string[] args to get environment if necessary.
             https://docs.microsoft.com/en-us/ef/core/cli/dbcontext-creation?tabs=dotnet-core-cli#args
             */
            var configuration = AppConfigurations.Get(
                WebContentDirectoryFinder.CalculateContentRootFolder(),
                addUserSecrets: true
            );

            HrmDbContextConfigurer.Configure(builder, configuration.GetConnectionString(HrmConsts.ConnectionStringName));

            return new HrmDbContext(builder.Options);
        }
    }
}
