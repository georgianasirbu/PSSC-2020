using System;
using System.Collections.Generic;

namespace Intrebare.Domain.CreateIntrebareWorkflow
{
    [Serializable]
    public class ExceptionTag: Exception
    {
        public ExceptionTag()
        {
        }

        public ExceptionTag(List<string> tag) : base($" \"{tag.Count}\".Trebuie sa fie cel putin un tag si cel mult 3!")
        {
        }

    }
}