using Abp.Data;
using Abp.Domain.Entities;
using Abp.EntityFrameworkCore;
using Abp.EntityFrameworkCore.Repositories;
using Abp.MultiTenancy;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace Asd.Hrm.EntityFrameworkCore.Repositories
{
    /// <summary>
    /// Base class for custom repositories of the application.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    /// <typeparam name="TPrimaryKey">Primary key type of the entity</typeparam>
    public abstract class HrmRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<HrmDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        private readonly IActiveTransactionProvider _transactionProvider;

        protected HrmRepositoryBase(IDbContextProvider<HrmDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        protected HrmRepositoryBase(IDbContextProvider<HrmDbContext> dbContextProvider, IActiveTransactionProvider transactionProvider)
        : base(dbContextProvider)
        {
            _transactionProvider = transactionProvider;
        }

        //add your common methods for all repositories
        public DbCommand CreateCommand(string commandText, CommandType commandType, params SqlParameter[] parameters)
        {
            var command = GetConnection().CreateCommand();
            command.CommandTimeout = 600;
            command.CommandText = commandText;
            command.CommandType = commandType;
            command.Transaction = GetActiveTransaction();

            foreach (var parameter in parameters)
            {
                command.Parameters.Add(parameter);
            }

            return command;
        }

        public void EnsureConnectionOpen()
        {
            var connection = GetConnection().CreateCommand();

            if (connection.Connection.State != ConnectionState.Open)
            {
                connection.Connection.Open();
            }
        }
        public DbTransaction GetActiveTransaction()
        {
            return (DbTransaction)_transactionProvider.GetActiveTransaction(new ActiveTransactionProviderArgs
    {
        {"ContextType", typeof(HrmDbContext) },
        {"MultiTenancySide", MultiTenancySide }
    });
        }
    }
    
    /// <summary>
    /// Base class for custom repositories of the application.
    /// This is a shortcut of <see cref="HrmRepositoryBase{TEntity,TPrimaryKey}"/> for <see cref="int"/> primary key.
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public abstract class HrmRepositoryBase<TEntity> : HrmRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected HrmRepositoryBase(IDbContextProvider<HrmDbContext> dbContextProvider, Abp.Data.IActiveTransactionProvider transactionProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)!!!
    }
}
