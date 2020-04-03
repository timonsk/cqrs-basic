using CQRS.Models.RequestModels.Commands;
using CQRS.Models.ResponseModels.Commands;
using System.Threading.Tasks;

namespace CQRS.Interfaces.Commands
{
    public interface ICategoryCommandHandler
    {
        Task<CreateCategoryResponseModel> CreateCategory(CreateCategoryRequestModel createCategoryRequestModel);
    }
}
