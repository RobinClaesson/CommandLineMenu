using CommandLineMenu;

var alternatives = new List<string> { "Alternative 1", "Alternative 2", "Alternative 3" };

// Create Menu and add alternatives one by one
var menu1 = new Menu<string>();
menu1.Add("Alternative 1");
menu1.Add("Alternative 2");
menu1.Add("Alternative 3");
var result1 = menu1.ShowMenu();
Console.WriteLine($"Selected: {result1}");
Console.WriteLine();

// Create Menu and add alternatives in bulk
var menu2 = new Menu<string>();
menu2.AddRange(alternatives);
var result2 = menu2.ShowMenu();
Console.WriteLine($"Selected: {result2}");

// Create Menu with initial alternatives
var menu3 = new Menu<string>(alternatives);
var result3 = menu3.ShowMenu();
Console.WriteLine($"Selected: {result3}");
Console.WriteLine();

// Create Menu with IEnumerable initialisation
var menu4 = new Menu<string> { "Alternative 1", "Alternative 2", "Alternative 3" };
var result4 = menu4.ShowMenu();
Console.WriteLine($"Selected: {result4}");
Console.WriteLine();

// Create Menu from existing IEnumerable using IEnumerable.ToMenu()
var menu5 = alternatives.ToMenu();
var result5 = menu5.ShowMenu();
Console.WriteLine($"Selected: {result5}");
Console.WriteLine();

// Create Menu from other object type
var menu6 = Enum.GetValues<Alternatives>().ToMenu();
var result6 = menu6.ShowMenu();
Console.WriteLine($"Selected: {result6}");
Console.WriteLine();

enum Alternatives { Alternative1, Alternative2, Alternative3 }