using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    static class SingleOrDefaultDowncasted<TEnumerable, TSource>
        where TEnumerable : IEnumerable<TSource>
    {
        const string methodName = "SingleOrDefault";

        static readonly TypeDictionary<Func<TEnumerable, TSource>> singleOrDefault = 
            new TypeDictionary<Func<TEnumerable, TSource>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, TSource>(methodName, enumerableType));

        static readonly TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>> singleOrDefaultPredicate = 
            new TypeDictionary<Func<TEnumerable, Func<TSource, bool>, TSource>>(
                enumerableType => Dynamic.GetEnumerableHandler<TEnumerable, TSource, Func<TSource, bool>, TSource>(methodName, enumerableType));

        public static TSource SingleOrDefault(TEnumerable source)
            => singleOrDefault.GetOrAdd(source.GetType())(source);

        public static TSource SingleOrDefault(TEnumerable source, Func<TSource, bool> predicate)
            => singleOrDefaultPredicate.GetOrAdd(source.GetType())(source, predicate);
    }
}