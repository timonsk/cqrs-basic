using CQRS.Interfaces.Commands;
using CQRS.Interfaces.Storage;
using CQRS.Models.RequestModels.Commands;
using CQRS.Models.ResponseModels.Commands;
using CQRS.Models.Stoarage;
using System;
using System.Threading.Tasks;

namespace CQRS.Handlers.Commands
{
    public class CategoryCommandHandler : ICategoryCommandHandler
    {
        private readonly IInMemoryStorage _inMemoryStorage;

        public CategoryCommandHandler(IInMemoryStorage inMemoryStorage)
        {
            _inMemoryStorage = inMemoryStorage != null ? inMemoryStorage : throw new ArgumentNullException(nameof(inMemoryStorage));
        }

        public async Task<CreateCategoryResponseModel> CreateCategory(CreateCategoryRequestModel createCategoryRequestModel)
        {
            var createCategoryResponseModel = new CreateCategoryResponseModel();

            try
            {
                await _inMemoryStorage.Save(new Category { 
                    Id = createCategoryRequestModel.Id,
                    Description = createCategoryRequestModel.Description,
                    Name = createCategoryRequestModel.Name,
                    UserId = createCategoryRequestModel.UserId
                }, true);
            }
            catch (Exception ex)
            {
                createCategoryResponseModel.ErrorMessage = ex.Message;
            }

            return createCategoryResponseModel;
        }
    }
}
