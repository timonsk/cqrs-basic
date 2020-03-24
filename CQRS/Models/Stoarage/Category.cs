using System;
using CQRS.Interfaces.Storage;

namespace CQRS.Models.Stoarage
{
    public class Category : IStorageObject
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid UserId { get; set; }
    }
}