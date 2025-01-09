using mainApp.Interfaces;
using mainApp.Services;
using System.ComponentModel.DataAnnotations;

IMenuService menuService = new MenuService();

menuService.ShowMainMenu();

while (true)
{
    menuService.WiewAllPersons();
    menuService.CreatePersons();

}



