namespace Sweetener.Reflection
{
    /// <summary>
    /// A collection of methods for accessing type members regardless of their intended level of access.
    /// </summary>
    public static class AccessBypass
    {
        /// <summary>
        /// Creates a dynamic object for accessing the instance members of type <typeparamref name="T"/>.
        /// </summary>
        /// <typeparam name="T">The type with non-public members.</typeparam>
        /// <returns>
        /// A dynamic object whose members are equivalent to that of an instance of type <typeparamref name="T"/>.
        /// </returns>
        public static dynamic Create<T>(T value)
            => new Reflected<T>(value);
    }
}
