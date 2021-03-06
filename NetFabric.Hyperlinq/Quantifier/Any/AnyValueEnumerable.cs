﻿using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static bool Any<TEnumerable, TEnumerator>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TEnumerator>
            where TEnumerator : struct, IValueEnumerator
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            using (var enumerator = source.GetValueEnumerator())
            {
                return enumerator.TryMoveNext();
            }
        }

        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            using (var enumerator = source.GetValueEnumerator())
            {
                return enumerator.TryMoveNext();
            }
        }

        public static bool Any<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            using (var enumerator = source.GetValueEnumerator())
            {
                while (enumerator.TryMoveNext(out var current))
                {
                    if (predicate(current))
                        return true;
                }
            }
            return false;
        }
    }
}
