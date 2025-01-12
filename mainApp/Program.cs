using System.Security.Authentication.ExtendedProtection;
using Buisness.Interfaces;
using mainApp.Interfaces;
using mainApp.Services;
using Microsoft.Extensions.DependencyInjection;


var serviceCollection = new ServiceCollection();
serviceCollection.AddSingleton<IFileService>(new FileService ());
serviceCollection.AddSingleton<IPersonService, PersonService>();

var serviceProvider = serviceCollection.BuildServiceProvider();
serviceCollection.AddSingleton<IMenuService, MenuService>();

var menuService = serviceProvider.GetService<IMenuService>();

menuService?.ShowMainMenu();
