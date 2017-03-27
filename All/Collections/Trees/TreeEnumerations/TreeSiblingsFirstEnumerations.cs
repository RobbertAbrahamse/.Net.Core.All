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
using System.Linq;
using System.Collections.Generic;

namespace All.Collections.Trees.TreeEnumerations
{
    public static class TreeSiblingsFirstEnumerations
    {
        /// <summary>
        /// Tree siblings first enumeration without a check for cycles.
        /// Child items are obtained by using a Func<TItem, IEnumerable<TItem>> that gives the childs from a given TItem
        /// </summary>
        /// <typeparam name="TItem">The type of the nodes (items)</typeparam>
        /// <param name="rootItems">The root items to enumerate which can have child items</param>
        /// <param name="getChildItemsFunc">A func to obtain child items of an item</param>
        /// <returns></returns>
        public static IEnumerable<TItem> TreeSiblingsFirstEnumerate<TItem>(this IEnumerable<TItem> rootItems, Func<TItem, IEnumerable<TItem>> getChildItemsFunc)
        {
            var enumerablesStillToFollow = new Queue<IEnumerable<TItem>>();
            enumerablesStillToFollow.Enqueue(rootItems);

            while (enumerablesStillToFollow.Any())
            {
                foreach (var item in enumerablesStillToFollow.Dequeue())
                {
                    yield return item;

                    var childItems = getChildItemsFunc(item);
                    if (childItems != null)
                    {
                        enumerablesStillToFollow.Enqueue(childItems);
                    }
                }
            }
        }
    }
}
