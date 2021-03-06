﻿using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Array
    {
        public static WhereEnumerable<TSource> Where<TSource>(this TSource[] source, Func<TSource, bool> predicate) 
        {
            if (source == null) ThrowHelper.ThrowArgumentNullException(nameof(source));
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return new WhereEnumerable<TSource>(source, predicate);
        }

        public readonly struct WhereEnumerable<TSource>
            : IValueEnumerable<TSource, WhereEnumerable<TSource>.ValueEnumerator>
        {
            internal readonly TSource[] source;
            internal readonly Func<TSource, bool> predicate;

            internal WhereEnumerable(TSource[] source, Func<TSource, bool> predicate)
            {
                this.source = source;
                this.predicate = predicate;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public struct Enumerator 
            {
                readonly TSource[] source;
                readonly Func<TSource, bool> predicate;
                readonly int count;
                int index;

                internal Enumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public ref readonly TSource Current => ref source[index];

                public bool MoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                            return true;

                        index++;
                    }
                    return false;
                }
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource[] source;
                readonly Func<TSource, bool> predicate;
                readonly int count;
                int index;

                internal ValueEnumerator(in WhereEnumerable<TSource> enumerable)
                {
                    source = enumerable.source;
                    predicate = enumerable.predicate;
                    count = enumerable.source.Length;
                    index = -1;
                }

                public bool TryMoveNext(out TSource current)
                {
                    index++;
                    while (index < count)
                    {
                        current = source[index];
                        if (predicate(current))
                            return true;

                        index++;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext()
                {
                    index++;
                    while (index < count)
                    {
                        if (predicate(source[index]))
                            return true;

                        index++;
                    }
                    return false;
                }

                public void Dispose() { }
            }

            public int Count()
                => source.Count(predicate);

            public int Count(Func<TSource, bool> predicate)
                => ValueEnumerable.Count<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool All(Func<TSource, bool> predicate)
                => ValueEnumerable.All<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Any()
                => source.Any(predicate);

            public bool Any(Func<TSource, bool> predicate)
                => ValueEnumerable.Any<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public bool Contains(TSource value)
                => ValueEnumerable.Contains<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => ValueEnumerable.Contains<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, value, comparer);

            public Array.WhereSelectEnumerable<TSource, TResult> Select<TResult>(Func<TSource, TResult> selector)
                => Array.WhereSelect<TSource, TResult>(source, predicate, selector);

            public ValueEnumerable.WhereEnumerable<WhereEnumerable<TSource>, ValueEnumerator, TSource> Where(Func<TSource, bool> predicate)
                => ValueEnumerable.Where<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public ref readonly TSource First()
                => ref ArrayExtensions.First<TSource>(source, predicate);
            public TSource First(Func<TSource, bool> predicate)
                => ValueEnumerable.First<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public ref readonly TSource FirstOrDefault()
                => ref ArrayExtensions.FirstOrDefault<TSource>(source, predicate);
            public TSource FirstOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.FirstOrDefault<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public ref readonly TSource Single()
                => ref ArrayExtensions.Single<TSource>(source, predicate);
            public TSource Single(Func<TSource, bool> predicate)
                => ValueEnumerable.Single<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public ref readonly TSource SingleOrDefault()
                => ref ArrayExtensions.SingleOrDefault<TSource>(source, predicate);
            public TSource SingleOrDefault(Func<TSource, bool> predicate)
                => ValueEnumerable.SingleOrDefault<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public WhereEnumerable<TSource> AsValueEnumerable()
                => this;

            public TSource[] ToArray()
                => ValueEnumerable.ToArray<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueEnumerable.ToList<WhereEnumerable<TSource>, ValueEnumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TSource>(this WhereEnumerable<TSource> source)
            where TSource : struct
            => ArrayExtensions.FirstOrNull<TSource>(source.source, source.predicate);

        public static TSource? FirstOrNull<TSource>(this WhereEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => ValueEnumerable.FirstOrNull<WhereEnumerable<TSource>, WhereEnumerable<TSource>.ValueEnumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TSource>(this WhereEnumerable<TSource> source)
            where TSource : struct
            => ArrayExtensions.SingleOrNull<TSource>(source.source, source.predicate);

        public static TSource? SingleOrNull<TSource>(this WhereEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
            => ValueEnumerable.SingleOrNull<WhereEnumerable<TSource>, WhereEnumerable<TSource>.ValueEnumerator, TSource>(source, predicate);
    }
}

