using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static StackUnderflow.Domain.Core.Contexts.Question.CreateQuestion.CreateQuestionResult;

namespace StackUnderflow.Domain.Core.Contexts.Question
{
     class CreateQuestionAdapter: Adapter<CreateQuestionCmd, ICreateQuestionResult, QuestionWriteContext,QuestionDependencies>
    {
       
        public override async Task<ICreateQuestionResult> Work(CreateQuestionCmd cmd, QuestionWriteContext state, QuestionDependencies dependencies)
        {
            var workflow = from valid in cmd.TryValidate()
                           let t = AddQuestion(state, CreateQuestionFromCmd(cmd))
                           select t;
            var result = await workflow.Match(
                Succ: r => r,
                Fail: ex => new InvalidQuestion(ex.Message);
            return result;
        }
	
	   
    }
}
