using CSharp.Choices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Intrebare.Domain.CreateRaspunsWorkflow
{

    [AsChoice]
    public static partial class CreateRaspunsResult
    {
        public interface ICreateRaspunsResult { }

        public class RaspunsPostat: ICreateRaspunsResult
        {
            public Guid RaspunsId { get; private set; }
            public string Descriere { get; private set; }

            public RaspunsPostat(Guid raspuns, string descriere)
            {
                RaspunsId = raspuns;
                Descriere = descriere;
            }
        }

        public class Raspunsulnuepostat: ICreateRaspunsResult
        {
            public string Reason { get; set; }

            public Raspunsulnuepostat(string reason)
            {
                Reason = reason;
            }
        }

        public class RaspunsValidationFailed: ICreateRaspunsResult
        {
            public IEnumerable<string> ValidationErrors { get; private set; }

            public RaspunsValidationFailed(IEnumerable<string> errors)
            {
                ValidationErrors = errors.AsEnumerable();
            }
        }
    }
}

}
