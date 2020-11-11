using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Tema6.Inputs
{
    public class ValidateReplyCmd
    {
       
        public int AuthorId { get; }
        public int QuestionId { get; }
        [StringRange(10,500)]
        public string Text { get; }
        public ValidateReplyCmd(int authorid,int questionid,string text)
        {
            AuthorId = authorid;
            QuestionId = questionid;
            Text = text;
        }


    }
}
