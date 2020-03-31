using System;
using System.Collections.Generic;
using System.Text;

namespace AzureLab.AzureResources.Utility
{
    public class ServicePrincipal
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string TenantId { get; set; }   
    }
}
