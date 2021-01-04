using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion
{
    [AsChoice]
    public static partial class CreateQuestionResult
    {
        public interface ICreateQuestionResult { }

        public class QuestionCreated : ICreateQuestionResult
        {
            public Guid QuestionID { get;private set; }
            public string Title {get; priate set;}
	    public string Description{get; private set;}
	    public string Tag{get;private set;}

            public QuestionCreated(Guid questionID, string title, string description, string tag)
            {
                QuestionID = questionID;
		Title=title;
		Description=description;
		Tag=tag;
            }
	}

        public class QuestionNotCreated : ICreateQuestionResult
        {
            public string Reason { get; set; }
	    public QuestionNotCreated(string reason)
	    {
		Reason=reason;
	     }

        }

        public class QuestionValidationFailed: ICreateQuestionResult
        {
           public IEnumerable<string>ValidationErrors {get; private set}
	public QuestionValidationFailed(IEnumerable<string> errors)
	{
		ValidationErrors=errors.AsEnumerable();
        }
	}
    }
}
