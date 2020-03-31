using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace AzureLab.AzureResources.Utility
{

    public class Platform
    {
        #region Private Data

        private AzureCredentials _credentials;
        private IAzure _manager;

        #endregion

        #region Properties

        public IAzure Manager
        {
            get { return _manager;  }
        }
        
        public ServicePrincipal ServicePrincipal { get; set; }

        #endregion

        #region Constructors
        
        public Platform( ServicePrincipal sp)
        {
            _credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal(sp.ClientId, sp.ClientSecret, sp.TenantId, AzureEnvironment.AzureGlobalCloud);
            _manager = Azure.Configure()
                            .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                            .Authenticate(_credentials)
                            .WithDefaultSubscription();

        }

        public Platform( string clientId, string clientSecret, string tenantId ) : this(new ServicePrincipal() { ClientId = clientId, ClientSecret = clientSecret, TenantId = tenantId })
        {   
        }

        #endregion

        public async Task StartVM( string groupName, string name )
        {
            await Manager.VirtualMachines.GetByResourceGroup(groupName, name).StartAsync();
        }

        public async Task StopVM(string groupName, string name)
        {
            await Manager.VirtualMachines.GetByResourceGroup(groupName, name).DeallocateAsync();
        }


    }
}
