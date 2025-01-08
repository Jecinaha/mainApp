using System.Diagnostics;

namespace Buisness.Helpers;

public static class UniqueIdentifierGenerator
{
    public static string GenerateUniqueId()
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
