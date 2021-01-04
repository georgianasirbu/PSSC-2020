using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Access.Primitives.Extensions.ObjectExtensions;
using Access.Primitives.IO;
using Microsoft.AspNetCore.Mvc;
using StackUnderflow.Domain.Core;
using StackUnderflow.Domain.Core.Contexts;
using StackUnderflow.Domain.Schema.Backoffice.CreateQuestionOp;
using StackUnderflow.EF.Models;
using Access.Primitives.EFCore;
using StackUnderflow.Domain.Schema.Backoffice.InviteTenantAdminOp;
using StackUnderflow.Domain.Schema.Backoffice;
using LanguageExt;
using Microsoft.AspNetCore.Http;

namespace StackUnderflow.API.Rest.Controllers
{
    [ApiController]
    [Route("question")]
    public class Question_Controller : ControllerBase
    {
        private readonly IInterpreterAsync _interpreter;
        private readonly StackUnderflowContext _dbContext;

        public Question_Controller(IInterpreterAsync interpreter, StackUnderflowContext dbContext)
        {
            _interpreter = interpreter;
            _dbContext = dbContext;
        }

        [HttpPost("question")]
        public async Task<IActionResult> CreateQuestion([FromBody] CreateQuestionCmd createQuestionCmd)
        {
            QuestionWriteContext ctx = new QuestionWriteContext(
                new EFList<Question>(_dbContext.Question),
                new EFList<User>(_dbContext.User));

            var dependencies = new QuestionDependencies();
            dependencies.GenerateInvitationToken = () => Guid.NewGuid().ToString();
            dependencies.SendInvitationEmail = (InvitationLetter letter) => async ()=>new InvitationAcknowledgement(Guid.NewGuid().ToString());

            var expr = from createQuestionResult in QuestionDomain.CreateQuestion(createQuestionCmd)
                       let question = createQuestionResult.SafeCast<CreateQuestionResult.QuestionCreated>().Select(p => p.question)
                       let createQuestionCmd = new CreateQuestionCmd(question)
                       from CreateQuestionResult in QuestionDomain.CreateQuestion(createQuestionCmd)
                       select new { createQuestionResult, CrateQuestionResult };

            var r = await _interpreter.Interpret(expr, ctx, dependencies);
            _dbContext.SaveChanges();
            return r.createQuestiontResult.Match(
                created => (IActionResult)Ok(created.question.TenantId),
                notCreated => StatusCode(StatusCodes.Status500InternalServerError, "Tenant could not be created."),//todo return 500 (),
            invalidRequest => BadRequest("Invalid request."));
        }
    }
}
