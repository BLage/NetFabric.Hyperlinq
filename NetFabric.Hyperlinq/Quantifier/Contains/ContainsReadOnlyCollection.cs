using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class ReadOnlyCollection
    {
        public static bool Contains<TEnumerable, TEnumerator, TSource>(this TEnumerable source, TSource value, IEqualityComparer<TSource> comparer = null)
            where TEnumerable : IReadOnlyCollection<TSource>
            where TEnumerator : IEnumerator<TSource>
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (source.Count == 0) return false;

            if (comparer is null)
            {
                using (var enumerator = Dynamic.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(source))
                {
                    while (enumerator.MoveNext())
                    {
                        if (EqualityComparer<TSource>.Default.Equals(enumerator.Current, value))
                            return true;
                    }
                }
            }
            else
            {
                using (var enumerator = Dynamic.GetEnumerator<TEnumerable, TEnumerator, TSource>.Invoke(source))
                {
                    while (enumerator.MoveNext())
                    {
                        if (comparer.Equals(enumerator.Current, value))
                            return true;
                    }
                }
            }

            return false;
        }
    }
}

