using Abp.Application.Services.Dto;

namespace Asd.Hrm.Authorization.Users.Dto
{
    public interface IGetLoginAttemptsInput: ISortedResultRequest
    {
        string Filter { get; set; }
    }
}