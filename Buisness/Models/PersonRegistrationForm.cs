using System.ComponentModel.DataAnnotations;

namespace mainApp.Models;

public class PersonRegistrationForm
{
    [Required]
    [MinLength(2, ErrorMessage = "Must be at lest 2 characters long.")]
    public string FirstName { get; set; } = null!;

    [Required]
    [MinLength(2, ErrorMessage = "Must be at lest 2 characters long.")]
    public string LastName { get; set; } = null!;

    [Required]
    [EmailAddress]
    [RegularExpression("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$:^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format.")]
    public string Email { get; set; } = null!;

    [Required]
    public string PhoneNumber { get; set; } = null!;

    [Required]
    [MinLength(2, ErrorMessage = "Must be at lest 2 characters long.")]
    public string StreetAddress { get; set; } = null!;

    [Required] 
    public string PostCode { get; set; } = null!;

    [Required]
    [MinLength(2, ErrorMessage = "Must be at lest 2 characters long.")]
    public string Town { get; set; } = null!;

}

