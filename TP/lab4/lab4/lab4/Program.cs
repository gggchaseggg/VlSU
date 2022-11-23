// See https://aka.ms/new-console-template for more information
using lab4;
using lab6;

Console.WriteLine("Hello, World!");
Console.WriteLine(ForTest.isTrue("true"));
try
{
    Console.WriteLine(ForTest.isTrue("Exception"));
    
} catch (ArgumentException) {
    Console.WriteLine("Ошибка");
}
Console.WriteLine(ForTest.isTrue(1));
Console.WriteLine(ForTest.isTrue(false));

Console.WriteLine(Library.multiplyByTwo(4));
Console.WriteLine(Library.multiplyByThree(7));
Console.WriteLine(Library.multiply(4,8));