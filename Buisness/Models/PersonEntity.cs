using System.ComponentModel.DataAnnotations;

namespace mainApp.Models;

public class PersonEntity
{
    [Key] 
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string PhoneNumber { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public string PostCode { get; set; } = null!;
    public string Town { get; set; } = null!;
}

