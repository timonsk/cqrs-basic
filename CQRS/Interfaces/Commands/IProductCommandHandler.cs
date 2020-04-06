using System.Threading.Tasks;
using CQRS.Models.RequestModels.Commands;
using CQRS.Models.ResponseModels.Commands;

namespace CQRS.Interfaces.Commands
{
    public interface IProductCommandHandler
    {
         Task<CreateProductResponseModel> CreateProduct(CreateProductRequestModel productRequestModel);
    }
}
