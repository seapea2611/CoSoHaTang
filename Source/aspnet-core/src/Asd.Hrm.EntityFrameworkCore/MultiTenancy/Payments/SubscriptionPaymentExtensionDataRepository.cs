using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using Asd.Hrm.EntityFrameworkCore;
using Asd.Hrm.EntityFrameworkCore.Repositories;

namespace Asd.Hrm.MultiTenancy.Payments
{
    public class SubscriptionPaymentExtensionDataRepository : HrmRepositoryBase<SubscriptionPaymentExtensionData, long>,
        ISubscriptionPaymentExtensionDataRepository
    {
        public SubscriptionPaymentExtensionDataRepository(IDbContextProvider<HrmDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public async Task<string> GetExtensionDataAsync(long subscriptionPaymentId, string key)
        {
            var data = await FirstOrDefaultAsync(p => p.SubscriptionPaymentId == subscriptionPaymentId && p.Key == key);

            return data?.Value;
        }

        public async Task<long?> GetPaymentIdOrNullAsync(string key, string value)
        {
            var data = await FirstOrDefaultAsync(p => p.Key == key && p.Value == value);
            return data?.SubscriptionPaymentId;
        }

        public async Task SetExtensionDataAsync(long subscriptionPaymentId, string key, string value)
        {
            var data = await FirstOrDefaultAsync(p => p.SubscriptionPaymentId == subscriptionPaymentId && p.Key == key);

            if (data != null)
            {
                await DeleteAsync(data);
            }

            await InsertAsync(new SubscriptionPaymentExtensionData()
            {
                SubscriptionPaymentId = subscriptionPaymentId,
                Key = key,
                Value = value
            });
        }

    }
}
