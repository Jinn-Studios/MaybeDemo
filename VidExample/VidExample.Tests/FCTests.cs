namespace VidExample.Tests;
using JinnDev.Utilities.Monad;
using VidExample.Data.Core;
using VidExample.Data.Entities;
using Xunit;

public class FCTests
{
    [Fact]
    public void ValidateNum_Positive_None()
    {
        var expected = 123456;
        var actual = FC.ValidateNum(expected);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateNum_Zero_None()
    {
        var actual = FC.ValidateNum(0);
        Assert.Equal(Maybe.NONE, actual);
    }

    [Fact]
    public void ValidateNum_Null_None()
    {
        var actual = FC.ValidateNum(null);
        Assert.Equal(Maybe.NONE, actual);
    }

    [Fact]
    public void ValidateDate_Recent()
    {
        var actual = FC.ValidateDate(DateTime.Now);
        Assert.Equal("Within Century", actual);
    }

    [Fact]
    public void ValidateDate_Old()
    {
        var actual = FC.ValidateDate(new DateTime(1990, 1, 1));
        Assert.Equal("Last Century", actual);
    }

    [Fact]
    public void FinalizeDoThings_ThisCentury()
    {
        var actual = FC.FinalizeDoThings(2020, 2, "msg");
        Assert.Equal("msg = 10", actual);
    }

    [Fact]
    public void FinalizeDoThings_LastCentury()
    {
        var actual = FC.FinalizeDoThings(1990, 2, "msg");
        Assert.Equal("msg = -10", actual);
    }
}