using System;
using System.Reflection;

namespace DynamicCodeDemo
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var path = @"C:\Windows\Microsoft.NET\Framework\v4.0.30319\System.Web.dll";

            var ourAssembly = Assembly.LoadFile(path);
            var type = ourAssembly.GetType("System.Web.HttpUtility");

            var HtmlEncode = type.GetMethod("HtmlEncode", new[] {typeof(string)});
            var HTMLDecode = type.GetMethod("HtmlDecode", new[] {typeof(string)});


            var testCase = "Alp<h./c3n&4u#r!";

            Console.WriteLine(testCase);
            Console.WriteLine("---------------");


            var updatedTestcase = (string) HtmlEncode.Invoke(null, new object[] {testCase});
            Console.WriteLine("Encoded");
            Console.WriteLine(updatedTestcase);
            Console.WriteLine("---------------");

            var thirdStateString = (string) HTMLDecode.Invoke(null, new object[] {updatedTestcase});
            Console.WriteLine("Decoded");
            Console.WriteLine(thirdStateString);
        }
    }
}