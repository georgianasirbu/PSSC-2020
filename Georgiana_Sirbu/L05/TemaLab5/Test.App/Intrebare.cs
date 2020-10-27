using Intrebare.Domain.CreateIntrebareWorkflow;
using System;
using System.Collections.Generic;
using System.Net;
using static Intrebare.Domain.CreateIntrebareWorkflow.CreateIntrebareResult;
using static Intrebare.Domain.CreateIntrebareWorkflow.Descriere

namespace Test.App
{
    class Intrebare
    {
        static void Main(string[] args)
        {
            
            var result = Nepublicata.Create("Titlu1", "Descriereeee", "Taag1");

            result.Match(
		Succ: question =>
                    {
                     
                        Console.WriteLine("Publicata");
                        
                    },
		Fail: ex =>
                    {
                        Console.WriteLine("Intrebarea nu poate fi publicata");
                     
                    }
                );
            Console.ReadLine();
        }
    }
}
