using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Access.Primitives.IO;
using LanguageExt;
using StackUnderflow.Domain.Schema.Backoffice.CreateTenantOp;
using StackUnderflow.EF.Models;
using static LanguageExt.Prelude;

namespace StackUnderflow.Domain.Core.Contexts
{

     public class BackofficeWriteContext
    {
        public ICollection<Tenant> Tenants { get; }
       

        public BackofficeWriteContext(ICollection<Tenant> tenants)
        {
            Tenants = tenants ?? new List<Tenant>(0);
           
        }
    }
}