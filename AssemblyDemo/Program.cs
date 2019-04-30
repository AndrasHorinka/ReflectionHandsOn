using System;
using System.Reflection;

namespace AssemblyDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            const string path = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.dll";

            // Load a specific Assembly
            var assembly = Assembly.LoadFile(path);
            ShowAssembly(assembly);

            // Get our Assembly
            var ourAssembly = Assembly.GetExecutingAssembly();
            ShowAssembly(ourAssembly);

            Console.Read();
        }

        private static void ShowAssembly(Assembly assembly)
        {
            Console.WriteLine("Assembly Details as follows");
            Console.WriteLine("---------------------------");
            Console.WriteLine(
                $"{assembly.FullName}\n {assembly.GlobalAssemblyCache}\n {assembly.Location}\n {assembly.ImageRuntimeVersion}");

            foreach (var method in assembly.GetModules())
            {
                Console.WriteLine($"{method}");
                Console.WriteLine("---------------------------");
            }
        }
    }
}