using Asd.Hrm.EntityFrameworkCore;

namespace Asd.Hrm.Migrations.Seed.Host
{
    public class InitialHostDbBuilder
    {
        private readonly HrmDbContext _context;

        public InitialHostDbBuilder(HrmDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultEditionCreator(_context).Create();
            new DefaultLanguagesCreator(_context).Create();
            new HostRoleAndUserCreator(_context).Create();
            new DefaultSettingsCreator(_context).Create();

            _context.SaveChanges();
        }
    }
}
