using Humanizer;
using System.Globalization;

Console.WriteLine("Por favor ingrese un nombre:");
string name = Console.ReadLine(); 
Console.WriteLine("Por favor ingrese un cargo:");
string position = Console.ReadLine();
Console.WriteLine("Por favor ingrese su edad:");
int age = int.Parse(Console.ReadLine());

Console.WriteLine($"Hola, su nombre es {name}, su cargo es {position} y su edad es {age.ToWords(new CultureInfo("es"))}");
