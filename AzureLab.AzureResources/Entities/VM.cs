using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Azure.Management.Compute.Fluent;

namespace AzureLab.AzureResources.Entities
{
    public class VM
    {
        public string IPAddress { get; set; }
        public string Name { get; set; }
        public string ResourceGroupName { get; set; }
        public string ResourceId { get; set; }
        public string Status { get; set; }
    }
}
