using System.ComponentModel;
using System.Reflection;

namespace Commons
{
    public static class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            FieldInfo? fi = value.GetType().GetField(value.ToString());
            if (fi != null)
            {
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }
            return value.ToString();
        }
    }
}
