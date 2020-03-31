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
using AzureLab.AzureResources.Utility;


namespace AzureLab.AzureResources.Repositories
{
    public class VMRepository
    {

        public Platform Platform { get; set; }

        public VMRepository()
        {
            
        }

        public VM GetById(string id)
        {
            var vm = Platform.Manager.VirtualMachines.GetById(id);

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
            var vmList = Platform.Manager.VirtualMachines.List();

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
