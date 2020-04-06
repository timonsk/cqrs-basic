using System;

namespace CQRS.Models.RequestModels.Queries
{
    public class GetProductByIdRequestModel
    {
        public Guid ProductId { get; set; }
    }
}
