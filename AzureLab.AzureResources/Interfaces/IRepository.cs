using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

using AzureLab.AzureResources.Entities;

namespace AzureLab.AzureResources.Interfaces
{
    public interface IRepository<T> where T : EntityBase
    {
        T GetById(int id);
        IEnumerable<T> List();
        // IEnumerable<T> List(Expression<Func<T, bool>> predicate);
    }
}
