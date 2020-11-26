using System;
using System.Collections.Generic;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner
{
    public class CheckLangCmd
    {
	[Required]
        public string Text { get;private set; }
        
        public CheckLangCmd(string tet)
        {
            Text=text;
	}
    }
}
