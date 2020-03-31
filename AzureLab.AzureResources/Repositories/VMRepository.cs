using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Azure.Management.Compute.Fluent;
using Microsoft.Azure.Management.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.Azure.Management.ResourceManager.Fluent.Authentication;
using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

using AzureLab.AzureResources.Entities;
using AzureLab.AzureResources.Interfaces;


namespace AzureLab.AzureResources.Repositories
{
    public class VMRepository
    {

        private static AzureCredentials credentials = SdkContext.AzureCredentialsFactory.FromServicePrincipal("25436b99-13a3-4608-9dd0-1da85a2561bf", "aMsmvGWSd7bwXRxduf=7.g7mD5-IGhQ.", "10b07eba-f68b-403f-80c3-9c79c513279b", AzureEnvironment.AzureGlobalCloud);
        private static IAzure azure;

        public VMRepository()
        {
            azure = Azure.Configure()
                         .WithLogLevel(HttpLoggingDelegatingHandler.Level.Basic)
                         .Authenticate(credentials)
                         .WithDefaultSubscription();

        }

        public VM GetById(string id)
        {
            var vm = azure.VirtualMachines.GetById(id);

            VM result = new VM()
            {
                IPAddress = vm.GetPrimaryNetworkInterface().PrimaryPrivateIP,
                ResourceId = vm.Id,
                Name = vm.Name,
                Status = vm.PowerState.Value
            };

            return result;
        }

        public IEnumerable<VM> List()
        {
            List<VM> result = new List<VM>();
            var vmList = azure.VirtualMachines.List();

            foreach (var vm in vmList)
            {
                result.Add(new VM() { 
                    IPAddress = vm.GetPrimaryNetworkInterface().PrimaryPrivateIP,
                    Name = vm.Name,
                    ResourceGroupName = vm.ResourceGroupName,
                    ResourceId = vm.Id,
                    Status = vm.PowerState.Value 
                });
            }

            return result;
        }

        /*
        public virtual IEnumerable<T> List(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbContext.Set<T>()
                   .Where(predicate)
                   .AsEnumerable();
        }
        */

    }
}
