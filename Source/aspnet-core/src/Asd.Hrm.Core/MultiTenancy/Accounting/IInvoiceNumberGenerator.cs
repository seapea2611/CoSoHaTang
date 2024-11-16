using System.Threading.Tasks;
using Abp.Dependency;

namespace Asd.Hrm.MultiTenancy.Accounting
{
    public interface IInvoiceNumberGenerator : ITransientDependency
    {
        Task<string> GetNewInvoiceNumber();
    }
}