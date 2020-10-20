using Intrebare.Domain.CreateIntrebareWorkflow;
using System;
using System.Collections.Generic;
using System.Net;
using static Intrebare.Domain.CreateIntrebareWorkflow.CreateIntrebareResult;


namespace Test.App
{
    class Intrebare
    {
        static void Main(string[] args)
        {
            var cmd = new CreateIntrebareCmd("Titlu1", "Descriereeee", "Taag1");
            var result = CreateIntrebare(cmd);

            result.Match(ProcessQuetionPosted,
                        ProcessQuestionNotPosted,
                        ProcessInvalidQuestion);

            Console.ReadLine();
        }

        private static ICreateIntrebareResult ProcessInvalidQuestion(IntrebareValidationFailed validationErrors)
        {
            Console.WriteLine("Question validation failed: ");
            foreach (var error in validationErrors.ValidationErrors)
            {
                Console.WriteLine(error);
            }
            return validationErrors;
        }

        private static ICreateIntrebareResult ProcessQuestionNotPosted(IntrebareaNuEPostata questionNotPosted)
        {
            Console.WriteLine($"Question not posted: {intrebareaNuEPostata.Reason}");
            return intrebareaNuEPostata;
        }

        private static ICreateIntrebareResult ProcessQuetionPosted(IntrebarePostata new_question)
        {
            Console.WriteLine($"IntrebareId {new_question.IntrebareId}");
            Console.WriteLine($"Descriere {new_question.Descriere}");
            Console.WriteLine($"Tag {new_question.Tag}");
            return new_question;
        }

        public static ICreateIntrebareResult CreateNewQuestion(CreateIntrebareCmd createQuestion)
        {
            if (string.IsNullOrWhiteSpace(createQuestion.Descriere))
            {
                var errors = new List<string>() { "Nu ati adaugat descriere corecta" };
                return new IntrebareValidationFailed(errors);
            }

            if(string.IsNullOrEmpty(createQuestion.Titlu))
            {
                return new IntrebareaNuEPostata("Adaugati titlu!");
            }
             if(string.IsNullOrEmpty(createQuestion.Tag))
            {
                return new IntrebareaNuEPostata("Adaugati tag!");
            }

            var questionId = Guid.NewGuid();
            var result = new IntrebarePostata(intrebareId, createQuestion.Descriere); 

            return result;
        }
    }
}
