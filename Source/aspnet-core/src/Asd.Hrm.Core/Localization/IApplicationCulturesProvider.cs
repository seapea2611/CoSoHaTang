using System.Globalization;

namespace Asd.Hrm.Localization
{
    public interface IApplicationCulturesProvider
    {
        CultureInfo[] GetAllCultures();
    }
}