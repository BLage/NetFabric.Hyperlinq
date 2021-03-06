﻿using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class DictionaryValuesExtensions
    {
        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => source.Count;

        public static int Count<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.Count<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static bool All<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.All<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => source.Count != 0;

        public static bool Any<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => ReadOnlyCollection.Any<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, KeyValuePair<TKey, TValue> value)
            => source.Contains(value);

        public static bool Contains<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, KeyValuePair<TKey, TValue> value, IEqualityComparer<TValue> comparer)
            => source.Contains(value, comparer);

        public static ReadOnlyCollection.SelectEnumerable<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult> Select<TKey, TValue, TResult>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, TResult> selector) 
            => ReadOnlyCollection.Select<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue, TResult>(source, selector);

        public static Enumerable.WhereEnumerable<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue> Where<TKey, TValue>(
            this Dictionary<TKey, TValue>.ValueCollection source,
            Func<TValue, bool> predicate) 
            => Enumerable.Where<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue First<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.First<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue First<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => Enumerable.First<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.FirstOrDefault<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue FirstOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => Enumerable.FirstOrDefault<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue? FirstOrNull<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TValue : struct
            => ReadOnlyCollection.FirstOrNull<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue? FirstOrNull<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            where TValue : struct
            => Enumerable.FirstOrNull<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue Single<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.Single<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue Single<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => Enumerable.Single<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            => ReadOnlyCollection.SingleOrDefault<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue SingleOrDefault<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            => Enumerable.SingleOrDefault<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static TValue? SingleOrNull<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source)
            where TValue : struct
            => ReadOnlyCollection.SingleOrNull<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source);

        public static TValue? SingleOrNull<TKey, TValue>(this Dictionary<TKey, TValue>.ValueCollection source, Func<TValue, bool> predicate)
            where TValue : struct
            => Enumerable.SingleOrNull<Dictionary<TKey, TValue>.ValueCollection, Dictionary<TKey, TValue>.ValueCollection.Enumerator, TValue>(source, predicate);

        public static IEnumerable<TKey> AsEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Keys;

        public static IReadOnlyCollection<TKey> AsReadOnlyCollection<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => source.Keys;

        public static Enumerable.AsValueEnumerableEnumerable<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> AsValueEnumerable<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => Enumerable.AsValueEnumerable<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source.Keys);

        public static ReadOnlyCollection.AsValueReadOnlyCollectionEnumerable<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey> AsValueReadOnlyCollection<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.AsValueReadOnlyCollection<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source.Keys);

        public static TKey[] ToArray<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToArray<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source.Keys);

        public static List<TKey> ToList<TKey, TValue>(this Dictionary<TKey, TValue> source)
            => ReadOnlyCollection.ToList<Dictionary<TKey, TValue>.KeyCollection, Dictionary<TKey, TValue>.KeyCollection.Enumerator, TKey>(source.Keys);
    }
}
