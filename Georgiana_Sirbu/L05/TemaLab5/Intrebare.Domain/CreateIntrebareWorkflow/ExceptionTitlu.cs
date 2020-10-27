using System;
using System.Collections.Generic;

namespace Intrebare.Domain.CreateIntrebareWorkflow
{
    [Serializable]
    public class ExceptionTitlu : Exception
    {
        public ExceptionTitlu()
        {
        }

        public ExceptionTitlu(string question) : base($"\"{question}\" Nu poate sa fie mai mare de 1000 caractere.")
        {
        }

    }
}