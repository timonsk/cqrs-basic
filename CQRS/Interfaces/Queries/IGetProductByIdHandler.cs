using System.Threading.Tasks;
using CQRS.Models.RequestModels.Queries;
using CQRS.Models.ResponseModels.Queries;

namespace CQRS.Interfaces.Queries
{
    public interface IGetProductByIdHandler
    {
         Task<GetProductByIdResponseModel> GetProductById(GetProductByIdRequestModel productModel);
    }
}