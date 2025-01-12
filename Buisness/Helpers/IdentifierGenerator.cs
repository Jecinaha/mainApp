using System.Diagnostics;

namespace Buisness.Helpers;

public static class IdentifierGenerator
{
    public static string GenerateId()
    {
        try
        {
            return Guid.NewGuid().ToString().Split('-')[0];
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return null!;
        }

    }
}
