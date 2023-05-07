using JinnDev.Utilities.Monad;
using MaybeDemo.Data.Entities;
using Xunit;

namespace MaybeDemo.Tests
{
    public class PersonTests
    {
        [Fact]
        public void MaybeMiddleName_HasValue_ReturnsMiddleName()
        {
            var expected = "MiddleName";
            var sut = new PersonEntity { MiddleName = expected };
            var actual = PersonService.GetMiddleNameFromPerson(sut);
            Assert.Equal(expected, actual.Value);
        }

        [Fact]
        public void MaybeMiddleName_OnlyFullRaw_ReturnsParsedMiddleName()
        {
            var expected = "Middle";
            var raw = $"First {expected} Last";
            var sut = new PersonEntity { FullNameRaw = raw };
            var actual = PersonService.GetMiddleNameFromPerson(sut);
            Assert.Equal(expected, actual.Value);
        }

        [Fact]
        public void MaybeMiddleName_Null_ReturnsMaybeNone()
        {
            var actual = PersonService.GetMiddleNameFromPerson(null);
            Assert.Equal(Maybe.NONE, actual);
        }

        [Fact]
        public void ReParseMiddleNameFromFullName_TwoPartName_ReturnsMaybeNone()
        {
            var raw = $"First Last";
            var sut = new PersonEntity { FullNameRaw = raw };
            var actual = PersonService.GetMiddleNameFromPerson(sut);
            Assert.Equal(Maybe.NONE, actual);
        }

        [Fact]
        public void ProperNounCasing_RegularName_ReturnsCased()
        {
            var actual = PersonService.ProperNounCasing("middle");
            Assert.Equal("Middle", actual);
        }

        [Fact]
        public void ProperNounCasing_InitialOnly_ReturnsCased()
        {
            var actual = PersonService.ProperNounCasing("m");
            Assert.Equal("M", actual);
        }

        [Fact]
        public void ProperNounCasing_NullName_ReturnsCased()
        {
            var actual = PersonService.ProperNounCasing(null);
            Assert.Equal(Maybe.NONE, actual);
        }
    }
}