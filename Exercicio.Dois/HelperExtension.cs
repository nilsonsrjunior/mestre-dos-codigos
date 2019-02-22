using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio.Dois
{
    public static class HelperExtension
    {
        public static bool IsEnumerable(this Type type)
        {
            if (type == null || type == typeof(string))
                return false;

            return typeof(IEnumerable).IsAssignableFrom(type);
        }
    }
}
