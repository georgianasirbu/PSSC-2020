using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharp.Choices;

namespace Intrebare.Domain.CreateIntrebareWorkflow
{
    
    [AsChoice]
    public static partial class CreateIntrebareResult
    {
        
        public interface ICreateIntrebareResult
        {
            
        }
        public class IntrebarePostata: ICreateIntrebareResult
        {
            public Guid IntrebareId { get; private set; }
            public string Descriere { get; private set; }
            public string Tag { get; private set; }
	    public int VoteCount { get; private set; }

            public IntrebarePostata(Guid intrebareId, string descriere, string tag, int votecount)
            {
                IntrebareId = intrebareId;
                Descriere = descriere;
                Tag = tag;
		VoteCount=votecount
            }
        }
       
        public class IntrebareaNuEPostata : ICreateIntrebareResult
        {
            public string Reason { get; set; }

            public IntrebareaNuEPostata(string reason)
            {
                Reason = reason;
            }
        }
        
        public class IntrebareValidationFailed: ICreateIntrebareResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public IntrebareValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}

    