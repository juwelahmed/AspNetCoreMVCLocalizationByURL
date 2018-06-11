using AspNetCoreMVCLocalizationByURL.Resources.Enum;
using System;
using System.Reflection;
using System.Resources;

namespace AspNetCoreMVCLocalizationByURL.Internationalization
{
    public static class EnumExtensions
    {
        public static string ToLocalizedString(this Enum en)
        {
            Type type = en.GetType();

            TypeInfo typeInfo = type.GetTypeInfo();

            EnumResourceAttribute attribute = 
                new EnumResourceAttribute(typeof(DaysOfWeekResource)); /*
                typeInfo.GetCustomAttribute<EnumResourceAttribute>(); //*/

            if(attribute != null)
            {
                ResourceManager manager =
                    new ResourceManager(attribute.ResourceType);

                return manager.GetString(en.ToString());
            }

            return en.ToString();
        }
    }
}
