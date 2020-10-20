using System;
using System.Collections.Generic;
using System.Text;
using Intrebare.Domain.CreateRaspunsWorkflow;
using static Intrebare.Domain.CreateRaspunsWorkflow.CreateRaspunsResult;
using CSharp.Choices;

namespace Test.App
{
    class Raspuns
    {
        static void Main(string[] args)
        {
   
            var cmd = new CreateRaspunsCmd("Raspuns1", "Raspuns Editat");
            var result = CreateRaspuns(cmd);

             result.Match(ProcessAnswerPosted,
                        ProcessAnswerNotPosted,
                        ProcessInvalidAnswer);

   

            Console.ReadLine();
        }

        private static ICreateRaspunsResult ProcessInvalidAnswer(RaspunsValidationFailed validationErrors)
        {
            Console.WriteLine("Validation failed");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static ICreateRaspunsResult ProcessAnswerNotPosted(Raspunsulnuepostat answerNotPosted)
        {
            Console.WriteLine($"Raspunsul nu e postat: {answerNotPosted.Reason}");
            return answerNotPosted;
        }

        private static ICreateRaspunsResult ProcessAnswerPosted(RaspunsPostat new_answer)
        {
            Console.WriteLine($"Raspuns {new_answer.RaspunsId}");
            Console.WriteLine($"Descriere {new_answer.Descriere}");
            return new_answer;
        }

        public static ICreateRaspunsResult CreateNewAnswer(CreateRaspunsCmd createAnswer)
        {
            if (string.IsNullOrWhiteSpace(createAnswer.DescriptionOfAnswer))
            {
                var errors = new List<string>() { "Descriere invalida" };
                return new RaspunsValidationFailed(errors);
            }

            
            var answerId = Guid.NewGuid();
            var result = new RaspunsPostat(RaspunsId, createAnswer.Descriere);

            return result;
        }
    }
}
