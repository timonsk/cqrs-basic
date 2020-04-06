using System;
using System.Threading.Tasks;
using CQRS.Interfaces.Commands;
using CQRS.Interfaces.Storage;
using CQRS.Models.RequestModels.Commands;
using CQRS.Models.ResponseModels.Commands;
using CQRS.Models.Stoarage;

namespace CQRS.Handlers.Commands
{
    public class CategoryCommandHandler : ICategoryCommandHandler
    {
        private readonly IInMemoryStorage _inMemoryStorage;

        public CategoryCommandHandler(IInMemoryStorage inMemoryStorage)
        {
            _inMemoryStorage = inMemoryStorage != null ? inMemoryStorage : throw new ArgumentNullException(nameof(inMemoryStorage));
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public async Task<CreateCategoryResponseModel> CreateCategory(CreateCategoryRequestModel createCategoryRequestModel)
        {
            if (createCategoryRequestModel == null)
            {
                throw new ArgumentNullException(nameof(createCategoryRequestModel));
            }

            var createCategoryResponseModel = new CreateCategoryResponseModel();

            try
            {
                await _inMemoryStorage.Save(
                    new Category
                    {
                        Id = createCategoryRequestModel.Id,
                        Description = createCategoryRequestModel.Description,
                        Name = createCategoryRequestModel.Name,
                        UserId = createCategoryRequestModel.UserId,
                    }, true)
                    .ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                createCategoryResponseModel.ErrorMessage = ex.Message;
            }

            return createCategoryResponseModel;
        }
    }
}
