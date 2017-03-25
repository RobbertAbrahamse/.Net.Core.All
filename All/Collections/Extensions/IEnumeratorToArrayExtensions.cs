using System;
using System.Collections.Generic;

namespace All.Collections.Extensions
{
    public static class IEnumeratorToArrayExtensions
    {
        public static T[] ToArray<T>(this IEnumerator<T> enumerator, T[] destination, Int64 destinationBeginIndex, Int64 count)
        {
            var destinationLastIndex = destinationBeginIndex + count;
            for (var destinationIndex = destinationBeginIndex; destinationIndex < destinationLastIndex; destinationIndex++)
            {
                destination[destinationIndex] = enumerator.Current;
                if (!enumerator.MoveNext() && destinationIndex < (destinationLastIndex - 1))
                {
                    throw new Exception($"Enumerator of {typeof(T).FullName} cannot move to the next needed item at destinationIndex {destinationIndex}.");
                }
            }

            return destination;
        }
    }
}
