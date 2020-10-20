using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Intrebare.Domain.CreateIntrebareWorkflow
{
    public struct CreateIntrebareCmd
    {
        [Required]
        public string Titlu { get; private set; }
        [Required]
        public string Descriere { get; private set; }
        [Required]
        public string Tag { get; private set; } 

        public CreateIntrebareCmd(string titlu, string descriere, string tag)
        {
            Titlu = titlu;
            Descriere = descriere;
            Tag = tag;
        }
    }
}
