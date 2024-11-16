using Xamarin.Forms.Internals;

namespace Asd.Hrm.Behaviors
{
    [Preserve(AllMembers = true)]
    public interface IAction
    {
        bool Execute(object sender, object parameter);
    }
}