using System.Security.Authentication.ExtendedProtection;
using Buisness.Interfaces;
using mainApp.Interfaces;
using mainApp.Services;
using Microsoft.Extensions.DependencyInjection;


var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IFileService>(new FileService ());
serviceCollection.AddSingleton<IPersonService, PersonService>();
serviceCollection.AddSingleton<MenuService>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var menuService = serviceProvider.GetRequiredService<MenuService>();



menuService.ShowMainMenu();
