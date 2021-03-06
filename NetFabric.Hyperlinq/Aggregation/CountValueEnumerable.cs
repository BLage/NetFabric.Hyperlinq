﻿using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static int Count<TEnumerable, TEnumerator>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TEnumerator>
            where TEnumerator : struct, IValueEnumerator
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var count = 0;
            using (var enumerator = source.GetValueEnumerator())
            {
                while (enumerator.TryMoveNext())
                    count++;
            }
            return count;
        }

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var count = 0;
            using (var enumerator = source.GetValueEnumerator())
            {
                while (enumerator.TryMoveNext())
                    count++;
            }
            return count;
        }

        public static int Count<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            var count = 0;
            using (var enumerator = source.GetValueEnumerator())
            {
                while (enumerator.TryMoveNext(out var current))
                {
                    if (predicate(current))
                        count++;
                }
            }
            return count;
        }
    }
}
