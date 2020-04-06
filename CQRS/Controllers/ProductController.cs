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
        private readonly IProductCommandHandler _productCommandHandler;
        private readonly IProductQueryHandler _productQueryHandler;

        public ProductController(
            ILogger<ProductController> logger,
            IProductCommandHandler productCommandHandler,
            IProductQueryHandler productQueryHandler)
        {
            _logger = logger;
            _productCommandHandler = productCommandHandler;
            _productQueryHandler = productQueryHandler;
        }

        [HttpGet]
        public Task<GetProductByIdResponseModel> Get([FromQuery] Guid id)
        {
            _logger.LogDebug($"Got request for getting product by id: {id}");
            return _productQueryHandler.GetProductById(new GetProductByIdRequestModel { ProductId = id });
        }

        [HttpPost]
        public Task<CreateProductResponseModel> Create([FromBody] CreateProductRequestModel productRequestModel)
        {
            _logger.LogDebug($"Got request for creating product with name: {productRequestModel?.Name} and category id: {productRequestModel?.CategoryId}");
            return _productCommandHandler.CreateProduct(productRequestModel);
        }
    }
}
