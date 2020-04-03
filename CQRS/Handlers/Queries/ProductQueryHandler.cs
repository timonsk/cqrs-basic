using System;
using System.Threading.Tasks;
using CQRS.Interfaces.Queries;
using CQRS.Interfaces.Storage;
using CQRS.Models.RequestModels.Queries;
using CQRS.Models.ResponseModels.Queries;
using CQRS.Models.Stoarage;

namespace CQRS.Handlers.Queries
{
    public class ProductQueryHandler : IProductQueryHandler
    {
        private readonly IInMemoryStorage _inMemoryStorage;

        public ProductQueryHandler(IInMemoryStorage inMemoryStorage)
        {
            _inMemoryStorage = inMemoryStorage != null ? inMemoryStorage : throw new ArgumentNullException(nameof(inMemoryStorage));
        }

        public async Task<GetProductByIdResponseModel> GetProductById(GetProductByIdRequestModel productModel)
        {
            var product = await _inMemoryStorage.Get<Product>(productModel.ProductId);

            return new GetProductByIdResponseModel
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Description = product.Description,
                Name = product.Name,
                UserId = product.UserId
            };
        }
    }
}