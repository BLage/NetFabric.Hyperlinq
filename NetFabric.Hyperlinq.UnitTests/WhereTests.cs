using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace NetFabric.Hyperlinq.UnitTests
{
    public class WhereTests
    {
        [Fact]
        public void Where_With_NullSource_Should_Throw()
        {
            // Arrange

            // Act
            Action action = () => Enumerable.Where<IEnumerable<int>, IEnumerator<int>, int>(null, _ => true);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("source");
        }

        [Fact]
        public void Where_With_NullPredicate_Should_Throw()
        {
            // Arrange
            var enumerable = Enumerable.Empty<int>();

            // Act
            Action action = () => enumerable.Where(null);

            // Assert
            action.Should()
                .ThrowExactly<ArgumentNullException>()
                .And
                .ParamName.Should()
                    .Be("predicate");
        }

        public static TheoryData<int[], Func<int, bool>, int[]> IEnumerableData =>
            new TheoryData<int[], Func<int, bool>, int[]> 
            {
                { new int[] {}, new Func<int, bool>(_ => true), new int[] {} },
                { new int[] { 1 }, new Func<int, bool>(_ => true), new int[] { 1 } },
                { new int[] { 1 }, new Func<int, bool>(_ => false), new int[] { } },
                { new int[] { 1, 2, 3, 4, 5, 6 }, new Func<int, bool>(value => (value & 0x01) == 0), new int[] { 2, 4, 6 } },
            };

        [Theory]
        [MemberData(nameof(IEnumerableData))]
        public void Where_With_Array_Should_Succeed(int[] source, Func<int, bool> predicate, IEnumerable<int> expected)
        {
            // Arrange

            // Act
            var result = source.Where(predicate);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }

        [Theory]
        [MemberData(nameof(IEnumerableData))]
        public void Where_With_ReadOnlyList_Should_Succeed(IReadOnlyList<int> source, Func<int, bool> predicate, IReadOnlyList<int> expected)
        {
            // Arrange

            // Act
            var result = source.Where(predicate);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }

        [Theory]
        [MemberData(nameof(IEnumerableData))]
        public void Where_With_ReadOnlyCollection_Should_Succeed(IReadOnlyCollection<int> source, Func<int, bool> predicate, IReadOnlyCollection<int> expected)
        {
            // Arrange

            // Act
            var result = source.Where(predicate);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }

        [Theory]
        [MemberData(nameof(IEnumerableData))]
        public void Where_With_Enumerable_Should_Succeed(IEnumerable<int> source, Func<int, bool> predicate, IEnumerable<int> expected)
        {
            // Arrange

            // Act
            var result = source.Where(predicate);

            // Assert
            result.AsEnumerable().Should().Equal(expected);
        }
    }
}