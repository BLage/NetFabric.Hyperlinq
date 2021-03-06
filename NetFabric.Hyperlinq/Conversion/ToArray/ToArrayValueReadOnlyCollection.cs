﻿using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueReadOnlyCollection
    {
        public static TSource[] ToArray<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueReadOnlyCollection<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var count = source.Count();
            var array = new TSource[count];
            var index = 0;
            using (var enumerator = source.GetValueEnumerator())
            {
                while (enumerator.TryMoveNext(out var current))
                {
                    array[index] = current;
                    index++;
                }
            }
            return array;
        }
    }
}
