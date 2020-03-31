using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

namespace AzureLab.AzureResources
{
    public class AzureManager
    {
        private static AzureCredentials _credentials; 
        private static IAzure _azure;

        public static IAzure Azure
        {
            get { return _azure; }
        }

        public static void Init(string clientId, string clientSecret, string tenantId)
        {
            _credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal("25436b99-13a3-4608-9dd0-1da85a2561bf", "aMsmvGWSd7bwXRxduf=7.g7mD5-IGhQ.", "10b07eba-f68b-403f-80c3-9c79c513279b", AzureEnvironment.AzureGlobalCloud);
            _azure = Azure.Configure()
                         .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                         .Authenticate(_credentials)
                         .WithDefaultSubscription();
        }
    }
}
