using System;
using System.Reflection;

namespace AssemblyAttrDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var ourAssembly = Assembly.GetExecutingAssembly();
            var type = typeof(AssemblyDescriptionAttribute);

            var objects = ourAssembly.GetCustomAttributes(type, false);

            if (objects.Length > 0)
            {
                var newObject = (AssemblyDescriptionAttribute) objects[0];
                Console.WriteLine($"{newObject.Description}");
            }
        }
    }
}