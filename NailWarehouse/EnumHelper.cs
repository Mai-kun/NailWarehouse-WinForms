using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NailWarehouse
{
    internal static class EnumHelper
    {
        /// <summary>
        /// Получение всех атрибутов описания из Enum
        /// </summary>
        public static IEnumerable<string> GetEnumDescriptions(Type enumType)
        {
            var strings = new Collection<string>();
            foreach (Enum value in Enum.GetValues(enumType))
            {
                strings.Add(GetEnumDescription(value));
            }
            return strings;
        }

        /// <summary>
        /// Получение атрибута описания из Enum по одному из свойств
        /// </summary>
        public static string GetEnumDescription(Enum value)
        {
            var fields = value.GetType().GetField(value.ToString());
            var attributes = fields?.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes is not null)
            {
                return ((DescriptionAttribute)attributes[0]).Description;
            }

            return value.ToString();
        }
    }
}
