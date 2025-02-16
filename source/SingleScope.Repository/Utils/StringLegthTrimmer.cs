using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace SingleScope.Repository.Utils
{
    public class StringLengthTrimmer
    {
        public T TrimStringProperties<T>(T obj, params string[] propertyNames)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (propertyNames.Contains(property.Name))
                {
                    TrimStringProperty(obj, property);
                }
            }

            return obj;
        }

        public T TrimStringProperties<T>(T obj)
        {
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                TrimStringProperty(obj, property);
            }

            return obj;
        }

        public T TrimStringProperty<T>(T obj, PropertyInfo property)
        {
            if (property.PropertyType == typeof(string) && property.CanWrite && property.CanRead)
            {
                var value = property.GetValue(obj) as string;
                if (value != null)
                {
                    var stringLengthAttribute = property.GetCustomAttribute<StringLengthAttribute>();
                    if (stringLengthAttribute != null)
                    {
                        int maxLength = stringLengthAttribute.MaximumLength;
                        if (value.Length > maxLength)
                        {
                            property.SetValue(obj, value.Substring(0, maxLength));
                        }
                    }
                }
            }

            return obj;
        }

        public int GetMaxStringLength<T>(T obj, string propertyName)
        {
            return GetMaxStringLength(obj!.GetType(), propertyName);
        }

        public int GetMaxStringLength<T>(string propertyName)
        {
            PropertyInfo[] properties = typeof(T).GetProperties();
            PropertyInfo? property = properties.SingleOrDefault(e => e.Name == propertyName);

            if (property == null)
            {
                return 0;
            }

            if (!property.CanRead)
            {
                return int.MaxValue;
            }

            var stringLengthAttribute = property.GetCustomAttribute<StringLengthAttribute>();
            if (stringLengthAttribute != null)
            {
                return stringLengthAttribute.MaximumLength;
            }

            return int.MaxValue;
        }

        public string TrimToProperty<T>(string input, string propertyName)
        {
            int maxLength = GetMaxStringLength<T>(propertyName);
            if (maxLength < input.Length)
            {
                return input.Substring(0, maxLength);
            }

            return input;
        }

        public string TrimToProperty<T>(string input, T obj, string propertyName)
        {
            int maxLength = GetMaxStringLength(obj, propertyName);
            if (maxLength < input.Length)
            {
                return input.Substring(0, maxLength);
            }

            return input;
        }
    }
}
