using System;

namespace CQRS.Interfaces.Storage
{
    public interface IStorageObject
    {
        Guid Id { get; set; }
    }
}