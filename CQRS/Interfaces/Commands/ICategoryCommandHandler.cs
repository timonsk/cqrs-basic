using System.Threading.Tasks;
using CQRS.Models.RequestModels.Commands;
using CQRS.Models.ResponseModels.Commands;

namespace CQRS.Interfaces.Commands
{
    public interface ICategoryCommandHandler
    {
        Task<CreateCategoryResponseModel> CreateCategory(CreateCategoryRequestModel createCategoryRequestModel);
    }
}
