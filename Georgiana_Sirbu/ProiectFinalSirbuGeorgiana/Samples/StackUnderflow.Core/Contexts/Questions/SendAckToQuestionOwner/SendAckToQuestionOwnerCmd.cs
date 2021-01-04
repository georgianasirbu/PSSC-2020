using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace StackUnderflow.Domain.Core.Contexts.Question.SendAckToQuestionOwner
{
    public class SendAckToQuestionOwnerCmd
	{
	[Required]
	public int QuestionID{get;}
	[Required]
	public string Title {get;}
	[Required]
	public string Description {get;}
	[Required]
	public string Tag{get;}
	public SendAckToQuestionOwnerCmd(int questionID, string title, string description, string tag) 
	{
	QuestionID=questionID;
	Title=title;
	Description=description;
	Tag=tag;
	}
	
}
	
}
