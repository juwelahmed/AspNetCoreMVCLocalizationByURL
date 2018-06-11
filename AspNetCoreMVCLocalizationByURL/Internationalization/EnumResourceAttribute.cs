using System;

namespace AspNetCoreMVCLocalizationByURL.Internationalization
{
    public class EnumResourceAttribute : Attribute
    {
        public Type ResourceType { get; private set; }

        public EnumResourceAttribute(Type resourceType)
        {
            ResourceType = resourceType;
        }
    }
}
