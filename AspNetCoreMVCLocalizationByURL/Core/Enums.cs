using AspNetCoreMVCLocalizationByURL.Internationalization;
using AspNetCoreMVCLocalizationByURL.Resources.Enum;

namespace AspNetCoreMVCLocalizationByURL
{
    [EnumResource(typeof(DaysOfWeekResource))]
    enum DaysOfWeek
    {
        Saturday,
        Sunday,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }
}
