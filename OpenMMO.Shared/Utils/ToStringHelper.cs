using System.Reflection;
using System.Text;

namespace OpenMMO.Shared.Utils
{
    public class ToStringHelper
    {
        public static string ToString<T>(T obj)
        {
            var sb = new StringBuilder($"Type: {typeof(T).FullName}");
            foreach (var propertyInfo in typeof(T).GetProperties(BindingFlags.Public))
            {
                sb.AppendLine($"{propertyInfo.Name}: {propertyInfo.GetValue(obj)}");
            }
            return sb.ToString();
        }
    }
}
