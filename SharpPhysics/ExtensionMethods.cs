using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpPhysics
{
    public static class ExtensionMethods
    {
        public static void Each<T>(this IEnumerable<T> self, Action<T> action)
        {
            foreach (var each in self)
            {
                action(each);
            }
        }
    }
}
