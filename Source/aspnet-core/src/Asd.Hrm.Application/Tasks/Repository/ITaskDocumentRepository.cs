using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Asd.Hrm.Employees.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Tasks.Repository
{
    public interface ITaskDocumentRepository : IRepository<Suggestion>
    {
        //Task<DataSet> SuggestEmployeeAll();
        Task<DataSet> GetEmployeeId(string name);
    }

}
