using mainApp.Factories;
using mainApp.Models;

namespace ConsoleApplication_Tests.Factories;


public class PersonFactory_Tests
{
    [Fact]
    public void Create_ShouldReturnPersonRegistrationForm()
    {
        //Act
        var result = PersonFactory.Create();

        //Assert
        Assert.NotNull(result);
        Assert.IsType<PersonRegistrationForm>(result);
    }

    [Fact]
    public void Create_ShouldReturnPersoEntity_WhenPersonRegistrationFormIsProvided()
    {
        //Arrange
        var personRegistrationForm = new PersonRegistrationForm()
        {
            FirstName = "First name",
            LastName = "Last name",
            Email = "email",
            PhoneNumber = "Phone number",
            StreetAddress = "Street address",
            PostCode = "Postcode",
            Town = "Town"
        };

        //Act
        var result = PersonFactory.Create(personRegistrationForm);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<PersonEntity>(result);
        Assert.Equal(personRegistrationForm.FirstName, result.FirstName);
        Assert.Equal(personRegistrationForm.LastName, result.LastName);
        Assert.Equal(personRegistrationForm.Email, result.Email);
        Assert.Equal(personRegistrationForm.PhoneNumber, result.PhoneNumber);
        Assert.Equal(personRegistrationForm.StreetAddress, result.StreetAddress);
        Assert.Equal(personRegistrationForm.PostCode, result.PostCode);
        Assert.Equal(personRegistrationForm.Town, result.Town);
    }

    [Fact]
    public void Create_ShouldReturnPerson_WhenPersonEntityIsProvided()
    {
        //Arrange
        var personEntity = new PersonEntity()
        {
            FirstName = "First name",
            LastName = "Last name",
            Email = "email",
            PhoneNumber = "Phone number",
            StreetAddress = "Street address",
            PostCode = "Postcode",
            Town = "Town"
        };

        //Act
        var result = PersonFactory.Create(personEntity);

        //Assert
        Assert.NotNull(result);
        Assert.IsType<Person>(result);
        Assert.Equal(personEntity.FirstName, result.FirstName);
        Assert.Equal(personEntity.LastName, result.LastName);
        Assert.Equal(personEntity.Email, result.Email);
        Assert.Equal(personEntity.PhoneNumber, result.PhoneNumber);
        Assert.Equal(personEntity.StreetAddress, result.StreetAddress);
        Assert.Equal(personEntity.PostCode, result.PostCode);
        Assert.Equal(personEntity.Town, result.Town);
    }
}



