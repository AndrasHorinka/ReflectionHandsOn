using System;
using System.Reflection;
using System.Reflection.Emit;

namespace DynamicAssembly
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var myAssembly = new AssemblyName("MyAssemblyName");
            myAssembly.Version = new Version("88.77.66.55");

            var AssBuilder =
                AppDomain.CurrentDomain.DefineDynamicAssembly(myAssembly, AssemblyBuilderAccess.ReflectionOnly);

            var MyBadB = AssBuilder.DefineDynamicModule("CodeModule", "DemoAssembly.dll");

            var MyTypeB = MyBadB.DefineType("Beast", TypeAttributes.Public);

            var newMyType = MyTypeB.CreateType();
            Console.WriteLine(newMyType.FullName);
            Console.WriteLine("---------------------");

            foreach (var member in newMyType.GetMembers()) Console.WriteLine($"{member.MemberType} - {member.Name}");
        }
    }
}