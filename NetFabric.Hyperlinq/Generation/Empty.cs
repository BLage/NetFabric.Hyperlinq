using System;
using System.Collections.Generic;

namespace NetFabric.Hyperlinq
{
    public static partial class Enumerable
    {
        public static EmptyEnumerable<TSource> Empty<TSource>() =>
            new EmptyEnumerable<TSource>();

        public readonly struct EmptyEnumerable<TSource>
            : IValueReadOnlyList<TSource, EmptyEnumerable<TSource>.ValueEnumerator>
        {
            public Enumerator GetEnumerator() => new Enumerator();
            public ValueEnumerator GetValueEnumerator() => new ValueEnumerator();

            public int Count() => 0;

            public TSource this[int index] { get { ThrowHelper.ThrowIndexOutOfRangeException(); return default; } }

            public readonly struct Enumerator
            {
                public TSource Current => default;

                public bool MoveNext() => false;
            }

            public readonly struct ValueEnumerator
                : IValueEnumerator<TSource>
            {
                public bool TryMoveNext(out TSource current)
                {
                    current = default;
                    return false;
                }

                public bool TryMoveNext() => false;

                public void Dispose() { }
            }

            public int Count(Func<TSource, bool> _)
                => 0;

            public bool All(Func<TSource, bool> predicate)
                => false;

            public bool Any()
                => false;

            public bool Any(Func<TSource, bool> predicate)
                => false;

            public bool Contains(TSource value)
                => false;

            public bool Contains(TSource value, IEqualityComparer<TSource> comparer)
                => false;

            public EmptyEnumerable<TSource> Select<TResult>(Func<TSource, TResult> selector)
            {
                if (selector is null) ThrowHelper.ThrowArgumentNullException(nameof(selector));

                return this;
            }

            public EmptyEnumerable<TSource> Where(Func<TSource, bool> predicate)
            {
                if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

                return this;
            }

            public TSource First() => ThrowHelper.ThrowEmptySequence<TSource>();
            public TSource First(Func<TSource, bool> _) => ThrowHelper.ThrowEmptySequence<TSource>();

            public TSource FirstOrDefault() => default;
            public TSource FirstOrDefault(Func<TSource, bool> _) => default;

            public TSource Single() => ThrowHelper.ThrowEmptySequence<TSource>();
            public TSource Single(Func<TSource, bool> _) => ThrowHelper.ThrowEmptySequence<TSource>();

            public TSource SingleOrDefault() => default;
            public TSource SingleOrDefault(Func<TSource, bool> _) => default;

            public IEnumerable<TSource> AsEnumerable()
                => System.Linq.Enumerable.Empty<TSource>();

            public IReadOnlyCollection<TSource> AsReadOnlyCollection()
                => ValueReadOnlyCollection.AsReadOnlyCollection<EmptyEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public IReadOnlyList<TSource> AsReadOnlyList()
                => ValueReadOnlyList.AsReadOnlyList<EmptyEnumerable<TSource>, ValueEnumerator, TSource>(this);

            public TSource[] ToArray()
                => new TSource[0];

            public List<TSource> ToList()
                => new List<TSource>();
        }

        public static TSource? FirstOrNull<TSource>(this EmptyEnumerable<TSource> _)
            where TSource : struct
            => null;

        public static TSource? FirstOrNull<TSource>(this EmptyEnumerable<TSource> _, Func<TSource, bool> predicate)
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return null;
        }

        public static TSource? SingleOrNull<TSource>(this EmptyEnumerable<TSource> _)
            where TSource : struct
            => null;

        public static TSource? SingleOrNull<TSource>(this EmptyEnumerable<TSource> _, Func<TSource, bool> predicate)
            where TSource : struct
        {
            if (predicate is null) ThrowHelper.ThrowArgumentNullException(nameof(predicate));

            return null;
        }
    }
}

