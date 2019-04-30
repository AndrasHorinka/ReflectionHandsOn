using System;
using System.Reflection;

namespace AssemblyDemoTypeInfo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var path = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.ServiceProcess.dll";

            var bindingFlags = BindingFlags.Public | BindingFlags.DeclaredOnly | BindingFlags.Instance;
            var ourAssembly = Assembly.LoadFile(path);

            Console.WriteLine(ourAssembly.FullName);
            Console.WriteLine("-----------------------------");
            var types = ourAssembly.GetTypes();

            foreach (var type in types)
            {
                Console.WriteLine(type.FullName);
                var MemberInfo = type.GetMembers(bindingFlags);

                foreach (var info in MemberInfo) Console.WriteLine($"{info.Name} - {info.MemberType} ");
            }

            Console.ReadKey();
        }
    }
}