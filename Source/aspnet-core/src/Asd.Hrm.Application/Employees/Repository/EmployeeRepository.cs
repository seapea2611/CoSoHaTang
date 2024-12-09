using Abp.Data;
using Abp.EntityFrameworkCore;
using Asd.Hrm.Employee;
using Asd.Hrm.EntityFrameworkCore;
using Asd.Hrm.EntityFrameworkCore.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Employees.Repository
{
    public class EmployeeRepository : HrmRepositoryBase<Asd.Hrm.Employee.Employees>, IEmployeeRepository
    {
        private readonly IHostingEnvironment _env;
        private readonly IDbContextProvider<HrmDbContext> _dbContextProvider;
        private readonly string _connectionString;
        public EmployeeRepository(IDbContextProvider<HrmDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider, string connectionString)
            : base(dbContextProvider, transactionProvider)
        {
            _connectionString = connectionString;
        }
        public async Task<DataSet> SuggestEmployeeAll()
        {
            // Khởi tạo DataSet
            DataSet dataSet = new DataSet();
            try
            {
                // Truy cập DbContext
                var dbContext = _dbContextProvider.GetDbContext();
                // Mở kết nối
                using (var connection = dbContext.Database.GetDbConnection())
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        // Cấu hình stored procedure
                        command.CommandText = "usp_SuggestEmployeeAll";
                        command.CommandType = CommandType.StoredProcedure;
                        // Sử dụng DataAdapter để điền DataSet
                        using (var adapter = new SqlDataAdapter((SqlCommand)command))
                        {
                            adapter.Fill(dataSet);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return dataSet;
        }


    }
}
