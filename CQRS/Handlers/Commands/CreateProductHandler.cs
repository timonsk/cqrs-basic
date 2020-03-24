using System;
using System.Threading.Tasks;
using CQRS.Interfaces.Commands;
using CQRS.Interfaces.Storage;
using CQRS.Models.RequestModels.Commands;
using CQRS.Models.ResponseModels.Commands;
using CQRS.Models.Stoarage;

namespace CQRS.Handlers.Commands
{
    public class CreateProductHandler : ICreateProductHandler
    {
        private readonly IInMemoryStorage _inMemoryStorage;

        public CreateProductHandler(IInMemoryStorage inMemoryStorage)
        {
            _inMemoryStorage = inMemoryStorage;
        }

        public async Task<CreateProductResponseModel> CreateProduct(CreateProductRequestModel productRequestModel)
        {
            var createProductResponseModel = new CreateProductResponseModel();
            try
            {
                await _inMemoryStorage.Save<Product>(new Product
                {
                    Id = productRequestModel.Id,
                    CreateDate = DateTime.Now,
                    Name = productRequestModel.Name,
                    CategoryId = productRequestModel.CategoryId,
                    Description = productRequestModel.Description,
                    UserId = productRequestModel.UserId
                }, true);
            }
            catch (Exception ex)
            {
                createProductResponseModel.ErrorMessage = ex.Message;
            }

            return createProductResponseModel;
        }
    }
}