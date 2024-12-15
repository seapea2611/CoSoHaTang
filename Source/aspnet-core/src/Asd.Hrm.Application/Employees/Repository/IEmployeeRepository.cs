using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Employees.Repository
{
    public interface IEmployeeRepository : IRepository<Suggestion>
    {
        //Task<DataSet> SuggestEmployeeAll();
        Task<DataSet> GetEmployeeId(string name);
    }
    public class Suggestion : Entity
    {

    }    
}
