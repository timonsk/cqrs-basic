using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CQRS.Interfaces.Storage;

namespace CQRS.Storage
{
    public class InMemoryStorage : IInMemoryStorage
    {
        private Dictionary<Guid, object> _storage = new Dictionary<Guid, object>();

        public Task<T> Get<T>(Guid id)
        {
            if (!_storage.ContainsKey(id)) {
                return Task.FromResult((T)Activator.CreateInstance(typeof(T)));
            }
            return Task.FromResult((T)_storage[id]);
        }

        public Task Save<T>(T data, bool upsert)
        {
            if (data == null) {
                throw new ArgumentNullException(nameof(data));
            }
            
            var stObject = data as IStorageObject;
            if (stObject == null) {
                throw new InvalidOperationException($"Object is not type of {nameof(IStorageObject)}");
            }

            if (_storage.ContainsKey(stObject.Id)) {
                if (!upsert) {
                    throw new ArgumentException($"Duplicate primary key: {stObject.Id}");
                }
                _storage[stObject.Id] = data;
            }

            _storage.Add(stObject.Id, data);

            return Task.CompletedTask;
        }
    }
}