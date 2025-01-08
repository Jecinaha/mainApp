using System.Diagnostics;
using mainApp.Models;

namespace mainApp.Factories;

public static class PersonFactory
{
    public static PersonRegistrationForm Create()
    {
        return new PersonRegistrationForm();
    }
    public static PersonEntity Create(PersonRegistrationForm form)
    {
        try
        {
            return new PersonEntity()
            {
                FirstName = form.FirstName.Trim(),
                LastName = form.LastName.Trim(),
                Email = form.Email.Trim().ToLower(),
                PhoneNumber = form.PhoneNumber,
                StreetAddress = form.StreetAddress.Trim(),
                PostCode = form.PostCode,
                Town = form.Town.Trim()
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating PersonEntity: {ex.Message}");
            return null!;
        }
  
    }




    public static Person Create(PersonEntity entity)
    {
        try
        {
            return new Person()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
                StreetAddress = entity.StreetAddress,
                PostCode = entity.PostCode,
                Town = entity.Town,
            };
        }

        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating User: {ex.Message}");
            return null!;

        }
    }
}
