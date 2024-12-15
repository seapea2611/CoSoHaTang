using Abp.Domain.Repositories;
using Asd.Hrm.Project;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Projects.Repository
{
    public interface IProjectRepository : IRepository<Asd.Hrm.Project.Projects>
    {
    }
}
