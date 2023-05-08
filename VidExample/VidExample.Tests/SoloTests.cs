namespace VidExample.Tests;
using VidExample.Data.Core;
using VidExample.Data.Entities;
using Xunit;

#pragma warning disable xUnit1004
public class SoloTests
{
    [Fact(Skip = "Because lol")]
    public void ValidateNum_Positive_None()
    {
        var expected = 123456;
        var mockRepo = new MockRepo(new SomeEntity { NumOrSomething = expected });
        var sut = new SoloService(mockRepo);
        var actual = sut.DoThings(1);
        Assert.Equal("Something", actual);
    }

    [Fact(Skip = "Because lol")]
    public void ValidateNum_Zero_None()
    {
        var expected = 0;
        var mockRepo = new MockRepo(new SomeEntity { NumOrSomething = expected });
        var sut = new SoloService(mockRepo);
        var actual = sut.DoThings(1);
        Assert.Equal("Something", actual);
    }

    [Fact(Skip = "Because lol")]
    public void ValidateNum_Null_None()
    {
        int? expected = null;
        var mockRepo = new MockRepo(new SomeEntity { NumOrSomething = expected });
        var sut = new SoloService(mockRepo);
        var actual = sut.DoThings(1);
        Assert.Equal("Something", actual);
    }

    [Fact(Skip = "Because lol")]
    public void ValidateDate_Recent()
    {
        DateTime? expected = DateTime.Now;
        var mockRepo = new MockRepo(new SomeEntity { SomeDateTime = expected });
        var sut = new SoloService(mockRepo);
        var actual = sut.DoThings(1);
        Assert.Equal("Something", actual);
    }

    [Fact(Skip = "Because lol")]
    public void ValidateDate_Old()
    {
        DateTime? expected = new DateTime(1990, 1, 1);
        var mockRepo = new MockRepo(new SomeEntity { SomeDateTime = expected });
        var sut = new SoloService(mockRepo);
        var actual = sut.DoThings(1);
        Assert.Equal("Something", actual);
    }

    [Fact(Skip = "Because lol")]
    public void FinalizeDoThings_ThisCentury()
    {
        var mockRepo = new MockRepo(new SomeEntity { /*...*/ });
        var sut = new SoloService(mockRepo);
        var actual = sut.DoThings(1);
        Assert.Equal("Something", actual);
    }

    [Fact(Skip = "Because lol")]
    public void FinalizeDoThings_LastCentury()
    {
        var mockRepo = new MockRepo(new SomeEntity { /*...*/ });
        var sut = new SoloService(mockRepo);
        var actual = sut.DoThings(1);
        Assert.Equal("Something", actual);
    }
}

public class MockRepo : IRepo
{
    private readonly SomeEntity _sut;

    public MockRepo(SomeEntity sut)
    {
        _sut = sut;
    }

    public SomeEntity GetItem(int itemId) => _sut;
}