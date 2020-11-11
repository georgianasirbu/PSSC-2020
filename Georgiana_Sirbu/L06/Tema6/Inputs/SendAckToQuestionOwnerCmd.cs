using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Tema6.Outputs;

namespace Tema6.Inputs
{
    public class SendAckToQuestionOwnerCmd
    {
       
        public int ReplyId { get; }
        public int QuestionId { get; }
        public string Text { get; }

        public SendAckToQuestionOwnerCmd(int replyId, int questionId, string text)
        {
            ReplyId = replyId;
            QuestionId = questionId;
            Text = text;
        }
    }
}
