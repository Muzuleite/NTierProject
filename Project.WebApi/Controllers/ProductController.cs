using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Validation.Models.RequestModels.Products;
using Project.Validation.Models.ResponseModels.Products;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager _productManager;
        private readonly IMapper _mapper;

        public ProductController(IProductManager productManager, IMapper mapper)
        {
            _productManager = productManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Products()
        {
            var values = await _productManager.GetAllAsync();
            return Ok(_mapper.Map<List<ProductResponseModel>>(values));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Product(int id)
        {
            var value = await _productManager.GetByIdAsync(id);
            return Ok(_mapper.Map<ProductResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductRequestModel model)
        {
            var dto = _mapper.Map<ProductDto>(model);
            await _productManager.CreateAsync(dto);
            return Ok("Ürün eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequestModel model)
        {
            var dto = _mapper.Map<ProductDto>(model);
            await _productManager.UpdateAsync(dto);
            return Ok("Ürün güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyProduct(int id)
        {
            return Ok(await _productManager.SoftDeleteAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            return Ok(await _productManager.HardDeleteAsync(id));
        }
    }
}
