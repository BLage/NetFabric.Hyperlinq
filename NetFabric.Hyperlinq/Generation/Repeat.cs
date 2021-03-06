using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static RepeatEnumerable<TSource> Repeat<TSource>(TSource value, int count)
        {
            if (count < 0) ThrowHelper.ThrowArgumentOutOfRangeException(nameof(count));

            return new RepeatEnumerable<TSource>(value, count);
        }

        public readonly struct RepeatEnumerable<TSource>
            : IValueReadOnlyList<TSource, RepeatEnumerable<TSource>.ValueEnumerator>
        {
            internal readonly TSource value;
            internal readonly int count;

            internal RepeatEnumerable(TSource value, int count)
            {
                this.value = value;
                this.count = count;
            }

            public Enumerator GetEnumerator() => new Enumerator(in this);
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator(in this);

            public int Count() => count;

            public TSource this[int index]
            {
                get
                {
                    if (index < 0 || index >= count) ThrowHelper.ThrowIndexOutOfRangeException();

                    return value;
                }
            }

            public struct Enumerator 
            {
                readonly TSource value;
                int counter;

                internal Enumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                    counter = enumerable.count;
                }

                public TSource Current => value;

                public bool MoveNext() => counter-- > 0;
            }

            public struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                readonly TSource value;
                int counter;

                internal ValueEnumerator(in RepeatEnumerable<TSource> enumerable)
                {
                    value = enumerable.value;
                    counter = enumerable.count;
                }

                public bool TryMoveNext(out TSource current)
                {
                    if (counter-- > 0)
                    {
                        current = value;
                        return true;
                    }
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => counter-- > 0;

                public void Dispose() { }
            }

            public int Count(Func<TSource, bool> predicate)
                => (count != 0 && predicate(value)) ? count : 0;

            public bool All(Func<TSource, bool> predicate)
                => count != 0 && predicate(value);

            public bool Any()
                => count != 0;

            public bool Any(Func<TSource, bool> predicate)
                => count != 0 && predicate(value);

            public bool Contains(TSource value)
                => count != 0 && this.value.Equals(value);

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => count != 0 && comparer.Equals(this.value, value);

            public ValueReadOnlyList.SelectEnumerable<RepeatEnumerable<TSource>, ValueEnumerator, TSource, TResult> Select<TResult>(Func<TSource, TResult> selector) 
                => ValueReadOnlyList.Select<RepeatEnumerable<TSource>, ValueEnumerator, TSource, TResult>(this, selector);

            public ValueReadOnlyList.WhereEnumerable<RepeatEnumerable<TSource>, ValueEnumerator, TSource> Where(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.Where<RepeatEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource First()
                => (count > 0) ? value : ThrowHelper.ThrowEmptySequence<TSource>();
            public TSource First(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.First<RepeatEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource FirstOrDefault()
                => (count > 0) ? value : default;
            public TSource FirstOrDefault(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.FirstOrDefault<RepeatEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource Single()
                => (count == 0) ? ThrowHelper.ThrowEmptySequence<TSource>() : ((count == 1) ? value : ThrowHelper.ThrowNotSingleSequence<TSource>());
            public TSource Single(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.Single<RepeatEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public TSource SingleOrDefault()
                => (count == 0) ? default : ((count == 1) ? value : ThrowHelper.ThrowNotSingleSequence<TSource>());
            public TSource SingleOrDefault(Func<TSource, bool> predicate) 
                => ValueReadOnlyList.SingleOrDefault<RepeatEnumerable<TSource>, ValueEnumerator, TSource>(this, predicate);

            public IEnumerable<TSource> AsEnumerable()
                => ValueEnumerable.AsEnumerable<RepeatEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public IReadOnlyCollection<TSource> AsReadOnlyCollection()
                => ValueReadOnlyCollection.AsReadOnlyCollection<RepeatEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public IReadOnlyList<TSource> AsReadOnlyList()
                => ValueReadOnlyList.AsReadOnlyList<RepeatEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public TSource[] ToArray()
                => ValueReadOnlyList.ToArray<RepeatEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public List<TSource> ToList()
                => ValueReadOnlyCollection.ToList<RepeatEnumerable<TSource>, ValueEnumerator, TSource>(this);
        }

        public static TSource? FirstOrNull<TSource>(this RepeatEnumerable<TSource> source)
            where TSource : struct
                => (source.count > 0) ? source.value : (TSource?)null;

        public static TSource? FirstOrNull<TSource>(this RepeatEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
                => ValueReadOnlyList.FirstOrNull<RepeatEnumerable<TSource>, RepeatEnumerable<TSource>.ValueEnumerator, TSource>(source, predicate);

        public static TSource? SingleOrNull<TSource>(this RepeatEnumerable<TSource> source)
            where TSource : struct
                => (source.count == 0) ? null : ((source.count == 1) ? source.value : ThrowHelper.ThrowNotSingleSequence<TSource?>());

        public static TSource? SingleOrNull<TSource>(this RepeatEnumerable<TSource> source, Func<TSource, bool> predicate)
            where TSource : struct
                => ValueReadOnlyList.SingleOrNull<RepeatEnumerable<TSource>, RepeatEnumerable<TSource>.ValueEnumerator, TSource>(source, predicate);
    }
}

