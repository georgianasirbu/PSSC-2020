using CSharp.Choices;
using StackUnderflow.EF.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner
{
    [AsChoice]
    public static partial class SendAckToQuestionOwnerResult
    {
        public interface ISendAckToQuestionOwnerResult { }

        public class SendAck : ISendAckToQuestionOwnerResult
        {
            public int QuestionID { get; }
	    public string Title {get;}
	    public string Description {get;}
	    public string Tag{get;}
	public SendAck(int questionID, string title, string description, string tag) 
	{
	QuestionID=questionID;
	Title=title;
	Description=description;
	Tag=tag;
    }
}

        public class NotSentAck : ISendAckToQuestionOwnerResult
        {
            public string Msg { get; }

            public NotSentAck (string msg)
            {
                Msg = msg;
            }

        }
    }
}
