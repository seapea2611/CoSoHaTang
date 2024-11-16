using System.Collections.Generic;
using Asd.Hrm.Authorization.Delegation;
using Asd.Hrm.Authorization.Users.Delegation.Dto;

namespace Asd.Hrm.Web.Areas.App.Models.Layout
{
    public class ActiveUserDelegationsComboboxViewModel
    {
        public IUserDelegationConfiguration UserDelegationConfiguration { get; set; }
        
        public List<UserDelegationDto> UserDelegations { get; set; }
    }
}
