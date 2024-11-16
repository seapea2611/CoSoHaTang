using System.Collections.Generic;
using MvvmHelpers;
using Asd.Hrm.Models.NavigationMenu;

namespace Asd.Hrm.Services.Navigation
{
    public interface IMenuProvider
    {
        ObservableRangeCollection<NavigationMenuItem> GetAuthorizedMenuItems(Dictionary<string, string> grantedPermissions);
    }
}