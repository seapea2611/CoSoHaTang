using Abp.Data;
using Abp.Domain.Repositories;
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
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Asd.Hrm.Employees.Repository
{
    public class EmployeeRepository : HrmRepositoryBase<Suggestion>, IEmployeeRepository
    {
        /*private readonly IHostingEnvironment _env;
        private readonly IDbContextProvider<HrmDbContext> _dbContextProvider;*/
        public EmployeeRepository(IDbContextProvider<HrmDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
            : base(dbContextProvider, transactionProvider)
        {
        }
        /*public async Task<DataSet> SuggestEmployeeAll()
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
                        command.CommandText = "usp_GetEmployeeId";
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
        }*/

        public async Task<DataSet> GetEmployeeId(string name)
        {
            EnsureConnectionOpen();
            using (var command = CreateCommand("usp_GetEmployeeId", CommandType.StoredProcedure))
            {
                command.Parameters.Add(new SqlParameter("@Name", name));
                var dataReader = await command.ExecuteReaderAsync();
                string[] array = { "Data" };
                var ds = new DataSet();
                ds.Load(dataReader, LoadOption.OverwriteChanges, array);
                return ds;
            }
        }
     
    }
}
