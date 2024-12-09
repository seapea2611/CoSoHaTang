using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Employees.Repository
{
    public interface IEmployeeRepository
    {
        Task<DataSet> SuggestEmployeeAll();
    }
}
