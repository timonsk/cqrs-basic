using System.Threading.Tasks;
using CQRS.Models.RequestModels.Queries;
using CQRS.Models.ResponseModels.Queries;

namespace CQRS.Interfaces.Queries
{
    public interface IProductQueryHandler
    {
         Task<GetProductByIdResponseModel> GetProductById(GetProductByIdRequestModel productModel);
    }
}
