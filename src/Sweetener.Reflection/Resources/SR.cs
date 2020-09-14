using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Sweetener
{
    internal static class SR
    {
        public static string UnrecognizedBinaryOperatorMessage => s_exceptionResourceManager.GetString(nameof(UnrecognizedBinaryOperatorMessage), CultureInfo.CurrentCulture);

        public static string UnrecognizedUnaryOperatorMessage => s_exceptionResourceManager.GetString(nameof(UnrecognizedUnaryOperatorMessage), CultureInfo.CurrentCulture);

        private static readonly ResourceManager s_exceptionResourceManager = new ResourceManager("Sweetener.Reflection.Resources.Exceptions", Assembly.GetExecutingAssembly());
    }
}
