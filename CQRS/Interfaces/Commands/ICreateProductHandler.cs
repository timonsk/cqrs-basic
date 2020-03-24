using System.Threading.Tasks;
using CQRS.Models.ResponseModels.Commands;
using CQRS.Models.RequestModels.Commands;

namespace CQRS.Interfaces.Commands
{
    public interface ICreateProductHandler
    {
         Task<CreateProductResponseModel> CreateProduct(CreateProductRequestModel productRequestModel);
    }
}