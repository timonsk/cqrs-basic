using System;
using System.Threading.Tasks;
using CQRS.Interfaces.Commands;
using CQRS.Interfaces.Queries;
using CQRS.Models.RequestModels.Commands;
using CQRS.Models.RequestModels.Queries;
using CQRS.Models.ResponseModels.Commands;
using CQRS.Models.ResponseModels.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CQRS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ICreateProductHandler _createProductHandler;
        public readonly IGetProductByIdHandler _getProductByIdHandler;

        public ProductController(
            ILogger<ProductController> logger,
            ICreateProductHandler createProductHandler,
            IGetProductByIdHandler getProductByIdHandler
            )
        {
            _logger = logger;
            _createProductHandler = createProductHandler;
            _getProductByIdHandler = getProductByIdHandler;
        }

        [HttpGet]
        public Task<GetProductByIdResponseModel> Get([FromQuery] Guid id)
        {
            return _getProductByIdHandler.GetProductById(new GetProductByIdRequestModel { ProductId = id });
        }

        [HttpPost]
        public Task<CreateProductResponseModel> Create([FromBody] CreateProductRequestModel productRequestModel)
        {
            return _createProductHandler.CreateProduct(productRequestModel);
        }
    }
}
