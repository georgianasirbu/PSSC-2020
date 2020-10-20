using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Intrebare.Domain.CreateRaspunsWorkflow
{
    public struct CreateRaspunsCmd
    {
        [Required]
        public string Raspuns { get; private set; }
        [Required]
        public string RaspunsEditat { get; private set; }
     
        public CreateRaspunsCmd(string raspuns, string raspunseditat)
        {
            Raspuns = raspuns;
            RaspunsEditat = raspunseditat;
           
        }
    }
}

