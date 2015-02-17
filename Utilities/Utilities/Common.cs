using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oni.Utilities
{
    public class CheckValue
    {
        public static void NotNullOrEmpty<T>(Action action, T value)
        {
            if (value == null || IsEmptyString(value))
                return;
            action();
        }

        public static void NotNullOrEmpty<T>(Action action, Func<T> value)
        {
            NotNullOrEmpty(action, value());
        }

        private static bool IsEmptyString<T>(T value)
        {
            var valueAsString = value as string;
            return (valueAsString != null && string.IsNullOrEmpty(valueAsString));
        }
    }


}
