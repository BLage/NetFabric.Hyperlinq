﻿using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class IReadOnlyListExtensions
    {
        public static int Count<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.Count<TSource>(array, predicate);
                default:
                    return ReadOnlyList.Count<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static bool All<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.All<TSource>(array, predicate);
                default:
                    return ReadOnlyList.All<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static bool Any<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.Any<TSource>(array);
                default:
                    return ReadOnlyList.Any<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static bool Any<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.Any<TSource>(array, predicate);
                default:
                    return ReadOnlyList.Any<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static bool Contains<TSource>(this IReadOnlyList<TSource> source, TSource value)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.Contains<TSource>(array, value);
                default:
                    return ReadOnlyList.Contains<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, value);
            }
        }

        public static bool Contains<TSource>(this IReadOnlyList<TSource> source, TSource value, IEqualityComparer<TSource> comparer)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.Contains<TSource>(array, value, comparer);
                default:
                    return ReadOnlyList.Contains<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, value, comparer);
            }
        }

        public static ReadOnlyList.SelectEnumerable<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyList<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyList.Select<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource, TResult>(source, selector);

        public static ReadOnlyList.WhereEnumerable<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource> Where<TSource>(
            this IReadOnlyList<TSource> source,
            Func<TSource, bool> predicate) 
            => ReadOnlyList.Where<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);

        public static TSource First<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.First<TSource>(array);
                default:
                    return ReadOnlyList.First<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource First<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.First<TSource>(array, predicate);
                default:
                    return ReadOnlyList.First<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.FirstOrDefault<TSource>(array);
                default:
                    return ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource FirstOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.FirstOrDefault<TSource>(array, predicate);
                default:
                    return ReadOnlyList.FirstOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IReadOnlyList<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.FirstOrNull<TSource>(array);
                default:
                    return ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource? FirstOrNull<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.FirstOrNull<TSource>(array, predicate);
                default:
                    return ReadOnlyList.FirstOrNull<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource Single<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.Single<TSource>(array);
                default:
                    return ReadOnlyList.Single<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource Single<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.Single<TSource>(array, predicate);
                default:
                    return ReadOnlyList.Single<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.SingleOrDefault<TSource>(array);
                default:
                    return ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource SingleOrDefault<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.SingleOrDefault<TSource>(array, predicate);
                default:
                    return ReadOnlyList.SingleOrDefault<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IReadOnlyList<TSource> source)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.SingleOrNull<TSource>(array);
                default:
                    return ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
            }
        }

        public static TSource? SingleOrNull<TSource>(this IReadOnlyList<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
        {
            switch (source)
            {
                case TSource[] array:
                    return ArrayExtensions.SingleOrNull<TSource>(array, predicate);
                default:
                    return ReadOnlyList.SingleOrNull<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source, predicate);
            }
        }

        public static ReadOnlyList.AsValueReadOnlyListEnumerable<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource> AsValueReadOnlyList<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.AsValueReadOnlyList<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);

        public static TSource[] ToArray<TSource>(this IReadOnlyList<TSource> source)
            => ReadOnlyList.ToArray<IReadOnlyList<TSource>, IEnumerator<TSource>, TSource>(source);
    }
}
