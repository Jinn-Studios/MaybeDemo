using MaybeDemo.Data.Entities;
using Xunit;

namespace MaybeDemo.Tests
{
    public class PersonTests
    {
        [Fact]
        public void MaybeMiddleName_HasValue_ReturnsMiddleName()
        {
            var expected = "Middle Name";
            var sut = new PersonEntity { MiddleName = expected };
            var actual = PersonService.MaybeMiddleName(sut);
            Assert.Equal(expected, actual.Value);
        }

        [Fact]
        public void MaybeMiddleName_OnlyFullRaw_ReturnsParsedMiddleName()
        {
            var expected = "Middle";
            var raw = $"First {expected} Last";
            var sut = new PersonEntity { FullNameRaw = raw };
            var actual = PersonService.MaybeMiddleName(sut);
            Assert.Equal(expected, actual.Value);
        }

        [Fact]
        public void MaybeMiddleName_Null_ReturnsMaybeNone()
        {
            var actual = PersonService.MaybeMiddleName(null);
            Assert.False(actual.HasValue);
        }

        [Fact]
        public void ReParseMiddleNameFromFullName_ThreePartName_ReturnsMiddleName()
        {
            var expected = "Middle";
            var raw = $"First {expected} Last";
            var actual = PersonService.ReParseMiddleNameFromFullName(raw);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void ReParseMiddleNameFromFullName_TwoPartName_ReturnsMaybeNone()
        {
            var raw = $"First Last";
            var actual = PersonService.ReParseMiddleNameFromFullName(raw);
            Assert.False(actual.HasValue);
        }

        [Fact]
        public void ReParseMiddleNameFromFullName_Null_ReturnsMaybeNone()
        {
            var actual = PersonService.ReParseMiddleNameFromFullName(null);
            Assert.False(actual.HasValue);
        }
    }
}