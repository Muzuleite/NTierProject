using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Validation.Models.RequestModels.Orders;
using Project.Validation.Models.ResponseModels.Orders;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderManager _orderManager;
        private readonly IMapper _mapper;

        public OrderController(IOrderManager orderManager, IMapper mapper)
        {
            _orderManager = orderManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Orders()
        {
            var values = await _orderManager.GetAllAsync();
            return Ok(_mapper.Map<List<OrderResponseModel>>(values));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Order(int id)
        {
            var value = await _orderManager.GetByIdAsync(id);
            return Ok(_mapper.Map<OrderResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderRequestModel model)
        {
            var dto = _mapper.Map<OrderDto>(model);
            await _orderManager.CreateAsync(dto);
            return Ok("Sipariş oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrder(UpdateOrderRequestModel model)
        {
            var dto = _mapper.Map<OrderDto>(model);
            await _orderManager.UpdateAsync(dto);
            return Ok("Sipariş güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyOrder(int id)
        {
            return Ok(await _orderManager.SoftDeleteAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            return Ok(await _orderManager.HardDeleteAsync(id));
        }
    }
}
