﻿using System;

namespace NetFabric.Hyperlinq
{
    public static partial class ValueEnumerable
    {
        public static bool All<TEnumerable, TEnumerator, TSource>(this TEnumerable source, Func<TSource, bool> predicate)
            where TEnumerable : IValueEnumerable<TSource, TEnumerator>
            where TEnumerator : struct, IValueEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));

            using (var enumerator = source.GetValueEnumerator())
            {
                while (enumerator.TryMoveNext(out var current))
                {
                    if (!predicate(current))
                        return false;
                }
            }
            return true;
        }
    }
}
