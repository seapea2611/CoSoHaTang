using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Asd.Hrm.MultiTenancy.Accounting.Dto;

namespace Asd.Hrm.MultiTenancy.Accounting
{
    public interface IInvoiceAppService
    {
        Task<InvoiceDto> GetInvoiceInfo(EntityDto<long> input);

        Task CreateInvoice(CreateInvoiceDto input);
    }
}
