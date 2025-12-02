using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Validation.Models.RequestModels.OrderDetails;
using Project.Validation.Models.ResponseModels.OrderDetails;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailManager _manager;
        private readonly IMapper _mapper;

        public OrderDetailController(IOrderDetailManager manager, IMapper mapper)
        {
            _manager = manager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetails()
        {
            var values = await _manager.GetAllAsync();
            return Ok(_mapper.Map<List<OrderDetailResponseModel>>(values));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> OrderDetail(int id)
        {
            var value = await _manager.GetByIdAsync(id);
            return Ok(_mapper.Map<OrderDetailResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailRequestModel model)
        {
            var dto = _mapper.Map<OrderDetailDto>(model);
            await _manager.CreateAsync(dto);
            return Ok("OrderDetail oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailRequestModel model)
        {
            var dto = _mapper.Map<OrderDetailDto>(model);
            await _manager.UpdateAsync(dto);
            return Ok("OrderDetail güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyOrderDetail(int id)
        {
            return Ok(await _manager.SoftDeleteAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            return Ok(await _manager.HardDeleteAsync(id));
        }
    }
}
