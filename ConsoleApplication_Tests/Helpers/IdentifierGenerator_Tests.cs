using Buisness.Helpers;

namespace ConsoleApplication_Tests.Helpers;

public class IdentifierGenerator_Tests
{
    [Fact]

    public void Generate_ShouldReturnGuidAsString()
    {
        //Act
        var result = IdentifierGenerator.GenerateId();

        //Assert
        Assert.NotNull(result);
        Assert.True(Guid.TryParse(result, out _));
    }
}
