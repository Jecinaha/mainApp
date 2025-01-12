using System.ComponentModel.DataAnnotations;

namespace mainApp.Models;

public class PersonRegistrationForm
{
    [Required (ErrorMessage = "Du måste fylla i ett förnamn")]
    [MinLength(2, ErrorMessage = "Det måste vara minst 2 bokstäver")]
    public string FirstName { get; set; } = null!;

    [Required (ErrorMessage = "Du måste fylla i ett efternamn")]
    [MinLength(2, ErrorMessage = "Det måste vara minst 2 bokstäver")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Du måste fylla i en emailadress")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Emailen måste vara i rätt format")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Du måste fylla i ett telefonnummer")]
    [MinLength(2, ErrorMessage = "Det måste vara minst 2 bokstäver")]
    public string PhoneNumber { get; set; } = null!;

    [Required(ErrorMessage = "Du måste fylla i en gatuadress")]
    [MinLength(2, ErrorMessage = "Det måste vara minst 2 bokstäver")]
    public string StreetAddress { get; set; } = null!;

    [Required(ErrorMessage = "Du måste fylla i ett postnummer")]
    [MinLength(2, ErrorMessage = "Det måste vara minst 2 siffror")]
    public string PostCode { get; set; } = null!;

    [Required(ErrorMessage = "Du måste fylla i en ort")]
    [MinLength(2, ErrorMessage = "Det måste vara minst 2 bokstäver")]
    public string Town { get; set; } = null!;

}

