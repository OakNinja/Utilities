using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oni.Utilities
{
    public class Common
    {
        public static void CheckValueNotNullOrEmptyAction<T>(Action action, T value)
        {
            var valueAsString = value as string;
            if (valueAsString != null)
            {
                if (!string.IsNullOrEmpty(valueAsString))
                    action();
            }
            else if (value != null)
                action();
        }



        public static void CheckValueNotNullOrEmptyAction<T>(Action action, Func<T> value)
        {
            CheckValueNotNullOrEmptyAction(action, value());
        }
    }
}
