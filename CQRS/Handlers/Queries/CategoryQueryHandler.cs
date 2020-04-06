using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Interfaces.Queries;
using CQRS.Interfaces.Storage;
using CQRS.Models.RequestModels.Queries;
using CQRS.Models.ResponseModels.Queries;
using CQRS.Models.Stoarage;

namespace CQRS.Handlers.Queries
{
    public class CategoryQueryHandler : ICategoryQueryHandler
    {
        private readonly IInMemoryStorage _inMemoryStorage;

        public CategoryQueryHandler(IInMemoryStorage inMemoryStorage)
        {
            _inMemoryStorage = inMemoryStorage != null ? inMemoryStorage : throw new ArgumentNullException(nameof(inMemoryStorage));
        }

        public async Task<List<GetCategoryByNameResponseModel>> GetCategoryByName(GetCategoryByNameRequestModel categoryByNameRequestModel)
        {
            return (await _inMemoryStorage.GetAll<Category>().ConfigureAwait(false))
                ?.Where(c => c.Name == categoryByNameRequestModel.Name)
                ?.Select(c => new GetCategoryByNameResponseModel
                {
                    Id = c.Id,
                    Description = c.Description,
                    Name = c.Name,
                    UserId = c.UserId,
                })
                ?.ToList();
        }
    }
}
