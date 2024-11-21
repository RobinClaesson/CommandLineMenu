# CommandLineMenu
[![NuGet Version](https://img.shields.io/nuget/v/ConsoleLineMenu.11.12.24.001)](https://www.nuget.org/packages/ConsoleLineMenu.11.12.24.001/)

.NET Library for creating menus that prompts the user to select an option and gives back the selected alternative. 

## Menu\<T>
``Menu<T>`` is the main class for creating and displaying menus. It implements ``IList<T>`` with the menu alternatives as the collection elements. 

### Create Menu
There are several ways to instantiate a new menu, see more examples in [CommandLineMenu.Examples](./CommandLineMenu.Examples/Program.cs): 
```csharp
// Create Menu and add alternatives one by one
var menu = new Menu<string>();
menu.Add("Alternative 1");
menu.Add("Alternative 2");
menu.Add("Alternative 3");

// Create Menu with IEnumerable initialisation
var menu = new Menu<string> { "Alternative 1", "Alternative 2", "Alternative 3" };

// Create Menu from existing IEnumerable using IEnumerable.ToMenu()
var alternatives = new List<string> { "Alternative 1", "Alternative 2", "Alternative 3" };
var menu = alternatives.ToMenu();

// Create Menu from other object type
enum Alternatives { Alternative1, Alternative2, Alternative3 }
var menu = Enum.GetValues<Alternatives>().ToMenu();
```

### Display Menu
To display a menu and get the object for the chosen alternative we call ``ShowMenu()``: 
```csharp
var result = menu4.ShowMenu();
```
![Console application displaying menu](./Assets/ShowMenu.png)