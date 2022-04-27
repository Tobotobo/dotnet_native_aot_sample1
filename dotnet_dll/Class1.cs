using System.Runtime.InteropServices;

namespace dotnet_dll;

public class Class1
{
    [UnmanagedCallersOnly(EntryPoint = "add")]
    public static int Add(int a, int b)
    {
        return a + b;
    }
}
