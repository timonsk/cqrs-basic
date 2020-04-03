using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Interfaces.Storage
{
    public interface IInMemoryStorage
    {
         Task Save<T>(T data, bool upsert);

         Task<T> Get<T>(Guid id);

        Task<IList<T>> GetAll<T>() where T : class;
    }
}