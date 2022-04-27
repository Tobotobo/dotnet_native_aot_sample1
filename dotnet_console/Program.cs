using System.Runtime.InteropServices;

[DllImport("dotnet_dll.dll")]
static extern int add(int a, int b);

// See https://aka.ms/new-console-template for more information
Console.WriteLine(add(1, 2));
