using System;
using System.Collections.Generic;
using System.Text;

namespace AzureLab.AzureResources.Entities
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }
    }
}
