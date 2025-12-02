using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Validation.Models.RequestModels.AppUsers;
using Project.Validation.Models.RequestModels.OrderDetails;
using Project.Validation.Models.ResponseModels.AppUsers;
using Project.Validation.Models.ResponseModels.OrderDetails;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserController : ControllerBase
    {
        private readonly IAppUserManager _appUserManager;
        private readonly IMapper _mapper;

        public AppUserController(IAppUserManager appUserManager, IMapper mapper)
        {
            _appUserManager = appUserManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var values = await _appUserManager.GetAllAsync();
            return Ok(_mapper.Map<List<AppUserResponseModel>>(values));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var value = await _appUserManager.GetByIdAsync(id);
            return Ok(_mapper.Map<AppUserResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateAppUserRequestModel model)
        {
            var dto = _mapper.Map<AppUserDto>(model);
            await _appUserManager.CreateAsync(dto);
            return Ok("Kullanıcı başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UpdateAppUserRequestModel model)
        {
            var dto = _mapper.Map<AppUserDto>(model);
            await _appUserManager.UpdateAsync(dto);
            return Ok("Kullanıcı güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyUser(int id)
        {
            return Ok(await _appUserManager.SoftDeleteAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            return Ok(await _appUserManager.HardDeleteAsync(id));
        }
    }
   
}
