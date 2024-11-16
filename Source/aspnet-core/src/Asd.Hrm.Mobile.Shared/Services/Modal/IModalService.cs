using System.Threading.Tasks;
using Asd.Hrm.Views;
using Xamarin.Forms;

namespace Asd.Hrm.Services.Modal
{
    public interface IModalService
    {
        Task ShowModalAsync(Page page);

        Task ShowModalAsync<TView>(object navigationParameter) where TView : IXamarinView;

        Task<Page> CloseModalAsync();
    }
}
