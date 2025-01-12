namespace Buisness.Helpers;

public static class IdentifierGenerator
{
    public static string GenerateId() => Guid.NewGuid().ToString();
}
