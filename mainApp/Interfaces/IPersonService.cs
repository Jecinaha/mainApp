using mainApp.Models;

namespace mainApp.Interfaces
{
    public interface IPersonService
    {
        bool Create(PersonRegistrationForm form);
        IEnumerable<Person> GetAll();
    }
}