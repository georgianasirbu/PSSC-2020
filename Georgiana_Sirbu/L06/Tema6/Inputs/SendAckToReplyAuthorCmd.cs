using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Tema6.Outputs;

namespace Tema6.Inputs
{
   class SendAckToReplyAuthorCmd
    {
        
        public int ReplyId { get; }
        public int QuestionId { get; }
        public string Text { get; }
        public SendAckToReplyAuthorCmd(int replyid, int questionid, string text)
        {
            ReplyId = replyid;
            QuestionId = questionid;
            Text = text;
        }
    }
}
