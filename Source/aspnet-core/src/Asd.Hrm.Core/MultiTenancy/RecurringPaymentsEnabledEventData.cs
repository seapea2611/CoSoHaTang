using Abp.Events.Bus;

namespace Asd.Hrm.MultiTenancy
{
    public class RecurringPaymentsEnabledEventData : EventData
    {
        public int TenantId { get; set; }
    }
}