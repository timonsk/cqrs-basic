using CQRS.Models.RequestModels.Queries;
using CQRS.Models.ResponseModels.Queries;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CQRS.Interfaces.Queries
{
    public interface ICategoryQueryHandler
    {
        Task<List<GetCategoryByNameResponseModel>> GetCategoryByName(GetCategoryByNameRequestModel categoryByNameRequestModel);
    }
}
