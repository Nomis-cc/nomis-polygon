namespace Nomis.Utils.Extensions
{
    /// <summary>
    /// <see cref="Type"/> extension methods.
    /// </summary>
    public static class TypeExtensions
    {
        /// <summary>
        /// Get the name of the generic type.
        /// </summary>
        /// <param name="type">Тип.</param>
        /// <returns>Returns the name of the generic type.</returns>
        public static string GetGenericTypeName(this Type type)
        {
            if (type.IsGenericType)
            {
                string genericTypes = string.Join(",", type.GetGenericArguments().Select(GetGenericTypeName).ToArray());
                return $"{type.Name.Remove(type.Name.IndexOf('`'))}<{genericTypes}>";
            }

            return type.Name;
        }
    }
}