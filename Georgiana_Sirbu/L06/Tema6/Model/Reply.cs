using System;
using System.Collections.Generic;
using System.Text;

namespace Tema6.Model
{
    public class Reply
    {
        public int ReplyId { get; }
        public int QuestionId { get; }
        public int AuthorId { get; }
        public string Text{get; }
        public Reply(int replyid,int questionid,int authorid,string text)
        {
            ReplyId = replyid;
            QuestionId = questionid;
            AuthorId = authorid;
            Text = text;
        }
    }
}
