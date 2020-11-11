using System;
using Tema6.Outputs;
using Access.Primitives.IO;



namespace Tema6
{
    class Program
    {
        static void Main(string[] args)
        {
            var wf = from createReplyResult in Domain.ValidateReply(100, 10, "gfht")
                     let validReply = (ValidateReplyResult.ReplyValidated)createReplyResult
                     from checkLanguageResult in BoundedContext.CheckLanguage(validReply.Reply.Answer)
                     from ownerAck in Domain.SendAckToQuestionOwner(CheckLanguageResult)
                     from authorAck in Domain.SendAckToReplyAuthor(CheckLanguageResult)
                     select (validReply, checkLanguageResult, ownerAck, authorAck);

           
            Console.WriteLine("Hello World!");
        }

    }
    
}