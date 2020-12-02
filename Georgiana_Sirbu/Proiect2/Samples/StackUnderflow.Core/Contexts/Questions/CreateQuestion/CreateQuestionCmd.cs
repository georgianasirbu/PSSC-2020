using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion
{
    public struct CreateQuestionCmd
    {

        [Required]
        public string Title { get; private set; }

            
        [Required]
        public string Description { get; private set; }

            
        [Required]            
        public string Tag { get; private set; }
   
        public CreateQuestionCmd(string title, strind description, string tag)           
        {
            Title = title;              
            Description = description;              
            Tag = tag;            
        }

       
    }
    
}
