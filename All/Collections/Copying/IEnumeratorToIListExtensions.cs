// Copyright 2017 Robbert Abrahamse
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;

namespace All.Collections.Copying
{
    public static class IEnumeratorToIListExtensions
    {
        public static IList<T> CopyTo<T>(this IEnumerator<T> enumerator, IList<T> destination, int destinationBeginIndex, int count)
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
