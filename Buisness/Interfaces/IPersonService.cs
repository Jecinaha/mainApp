using mainApp.Models;

namespace Buisness.Interfaces
{
    public interface IPersonService
    {
        void ClearList();
        bool Create(PersonRegistrationForm form);
        IEnumerable<Person> GetAll();
    }
}