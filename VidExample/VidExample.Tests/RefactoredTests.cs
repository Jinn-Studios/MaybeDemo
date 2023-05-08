namespace VidExample.Tests;
using Xunit;

public class RefactoredTests
{
    [Fact]
    public void ValidateNum_Positive_None()
    {
        var expected = 123456;
        var actual = RefactoredService.ValidateNum(expected);
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void ValidateNum_Zero_Throws()
    {
        Assert.Throws<Exception>(() => RefactoredService.ValidateNum(0));
    }

    [Fact]
    public void ValidateNum_Null_Throws()
    {
        Assert.Throws<Exception>(() => RefactoredService.ValidateNum(null));
    }

    [Fact]
    public void ValidateDate_Recent()
    {
        var actual = RefactoredService.ValidateDate(DateTime.Now);
        Assert.Equal("Within Century", actual);
    }

    [Fact]
    public void ValidateDate_Old()
    {
        var actual = RefactoredService.ValidateDate(new DateTime(1990, 1, 1));
        Assert.Equal("Last Century", actual);
    }

    [Fact]
    public void FinalizeDoThings_ThisCentury()
    {
        var actual = RefactoredService.FinalizeDoThings(2020, 2, "msg");
        Assert.Equal("msg = 10", actual);
    }

    [Fact]
    public void FinalizeDoThings_LastCentury()
    {
        var actual = RefactoredService.FinalizeDoThings(1990, 2, "msg");
        Assert.Equal("msg = -10", actual);
    }
}