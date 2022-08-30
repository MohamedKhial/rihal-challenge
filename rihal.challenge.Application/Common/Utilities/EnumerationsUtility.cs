using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace rihal.challenge.Application.Common.Utilities
{
    public static class EnumerationsUtility
    {
        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            if (fi == null)
            {
                return value.ToString();
            }

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static string GetEnumDescription(Type enumType, string value)
        {
            FieldInfo fi = enumType.GetField(value.ToString());

            if (fi == null)
            {
                return value.ToString();
            }

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static string GetDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null)
            {
                return value.ToString();
            }

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }

        public static string GetArabicDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null)
            {
                return value.ToString();
            }

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                ResourceManager resmgr = new ResourceManager("rihal.challenge.Application.Common.Localizations.Localization", Assembly.GetExecutingAssembly());
                string title = resmgr.GetString(attributes[0].Description, CultureInfo.GetCultureInfo("ar-QA"));
                return title;
            }
            else
            {
                return "";
            }
        }

        public static string GetEnglishDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi == null)
            {
                return value.ToString();
            }

            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                ResourceManager resmgr = new ResourceManager("rihal.challenge.Application.Common.Localizations.Localization", Assembly.GetExecutingAssembly());
                string title = resmgr.GetString(attributes[0].Description, CultureInfo.GetCultureInfo("en-US"));
                return title;
            }
            else
            {
                return "";
            }
        }
    }
}
