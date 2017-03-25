using System.Collections.Generic;

namespace All.Collections.Arrays.Extensions
{
    public static class ArrayExtensions
    {
        public static IEnumerator<T> GetEnumerator<T>(this T[] items)
        {
            for (var e = items.GetEnumerator(); e.MoveNext();)
            {
                yield return (T)e.Current;
            }
        }
    }
}
