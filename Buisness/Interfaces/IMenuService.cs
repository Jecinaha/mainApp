namespace mainApp.Services
{
    public interface IMenuService
    {
        void CreatePersons();
        void MenuOptionSelector(string option);
        string PromptAndValidate(string prompt, string propertyName);
        void ShowMainMenu();
        void WiewAllPersons();
    }
}