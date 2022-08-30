using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace rihal.challenge.Application.Common.Utilities
{
    public static class PropertiesUtitlity
    {
        public static string GetValueOfPath(object obj, string reflectionPath)
        {
            Queue<PropertyInfo> propertiesInfo = GetProperties(obj, reflectionPath);
            if (propertiesInfo.Any() == false)
            {
                return null;
            }

            string properyValue = GetValue(obj, propertiesInfo);
            return properyValue ?? string.Empty;
        }

        private static string GetValue(object obj, Queue<PropertyInfo> values)
        {
            object objectLocation = obj;
            PropertyInfo propertyInfo = values.ToList().LastOrDefault();

            while (values.Count > 0)
            {
                if (objectLocation == null)
                {
                    return string.Empty;
                }

                objectLocation = values.Dequeue().GetValue(objectLocation);
            }

            if (objectLocation == null)
            {
                return null;
            }

            try
            {
                if (propertyInfo.PropertyType == typeof(DateTime))
                {
                    DateTime.TryParse(objectLocation.ToString(), out DateTime datetimeParsed);

                    if (datetimeParsed.TimeOfDay == new TimeSpan(0, 0, 0))
                    {
                        return DateTimeUtility.ConvertDateFormatedShorted(datetimeParsed);
                    }

                    return DateTimeUtility.ConvertDateFormatedShorted(datetimeParsed);
                }

                if (propertyInfo.PropertyType.BaseType == typeof(Enum))
                {
                    return EnumerationsUtility.GetEnumDescription((Enum)objectLocation);
                }
            }
            catch
            {
                return objectLocation.ToString();
            }

            return objectLocation.ToString();
        }

        private static Queue<PropertyInfo> GetProperties(object obj, string path)
        {
            Queue<PropertyInfo> values = new Queue<PropertyInfo>();

            Type objectType = obj.GetType();

            List<string> properties = path.Split('.').ToList();

            PropertyInfo propertyInfo = null;

            if (properties.FirstOrDefault().ToLower() == obj.GetType().Name.ToLower())
            {
                properties.RemoveAt(0);
            }

            foreach (string property in properties)
            {
                if (propertyInfo != null)
                {
                    Type propertyType = propertyInfo.PropertyType;
                    //propertyInfo = propertyType.GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
                    propertyInfo = propertyType.GetProperties().FirstOrDefault(p => p.Name.ToLower() == property.ToLower());
                    if (propertyInfo == null)
                    {
                        continue;
                    }

                    values.Enqueue(propertyInfo);
                }
                else
                {
                    //propertyInfo = objectType.GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
                    propertyInfo = objectType.GetProperties().FirstOrDefault(p => p.Name.ToLower() == property.ToLower());
                    if (propertyInfo == null)
                    {
                        continue;
                    }

                    values.Enqueue(propertyInfo);
                }
            }

            return values;
        }
    }
}
