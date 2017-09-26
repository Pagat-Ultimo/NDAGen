using NDAGenLib.Common;
using NDAGenLib.Facade;
using System;

namespace NDAGenTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            string ModelNamespace = "PetStore.Model";
            string ServiceNamespace = "PetStore.Facade";
            string ServiceName = "PetStore";
            NDAConfig.ConnectionString = "http://petstore.swagger.io";
            NDAConfig.Path = "v2/swagger.json";
            NDAGenerator gen = new NDAGenerator();
            Console.WriteLine("End");
            Console.ReadLine();
        }
    }
}
