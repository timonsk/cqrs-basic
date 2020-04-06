using System.Collections.Generic;
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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ICategoryCommandHandler _categoryCommandHandler;
        private readonly ICategoryQueryHandler _categoryQueryHandler;

        public CategoryController(
            ILogger<ProductController> logger,
            ICategoryCommandHandler categoryCommandHandler,
            ICategoryQueryHandler categoryQueryHandler)
        {
            _logger = logger;
            _categoryCommandHandler = categoryCommandHandler;
            _categoryQueryHandler = categoryQueryHandler;
        }

        [HttpGet]
        public Task<List<GetCategoryByNameResponseModel>> Get([FromQuery] string categoryName)
        {
            _logger.LogDebug($"Got request for getting category by name: {categoryName}");
            return _categoryQueryHandler.GetCategoryByName(new GetCategoryByNameRequestModel { Name = categoryName });
        }

        [HttpPost]
        public Task<CreateCategoryResponseModel> Create([FromBody] CreateCategoryRequestModel categoryRequestModel)
        {
            _logger.LogDebug($"Got request for creating category with name: {categoryRequestModel?.Name} and user id: {categoryRequestModel?.UserId}");
            return _categoryCommandHandler.CreateCategory(categoryRequestModel);
        }
    }
}
