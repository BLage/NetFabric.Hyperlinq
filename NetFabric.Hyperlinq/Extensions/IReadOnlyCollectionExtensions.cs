﻿using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static class IReadOnlyCollectionExtensions
    {
        public static int Count<TSource>(this IReadOnlyCollection<TSource> source)
            => source.Count;

        public static ReadOnlyCollection.SelectEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TResult> Select<TSource, TResult>(
            this IReadOnlyCollection<TSource> source,
            Func<TSource, TResult> selector) 
            => ReadOnlyCollection.Select<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource, TResult>(source, selector);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource> AsValueReadOnlyCollection<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);

        public static List<TSource> ToList<TSource>(this IReadOnlyCollection<TSource> source)
            => ReadOnlyCollection.ToList<IReadOnlyCollection<TSource>, IEnumerator<TSource>, TSource>(source);
    }
}
