using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Bll.Dtos;
using Project.Bll.Managers.Abstracts;
using Project.Validation.Models.RequestModels.AppUserProfiles;
using Project.Validation.Models.ResponseModels.AppUserProfiles;

namespace Project.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserProfileController : ControllerBase
    {
        private readonly IAppUserProfileManager _profileManager;
        private readonly IMapper _mapper;

        public AppUserProfileController(IAppUserProfileManager profileManager, IMapper mapper)
        {
            _profileManager = profileManager;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfiles()
        {
            var values = await _profileManager.GetAllAsync();
            return Ok(_mapper.Map<List<AppUserProfileResponseModel>>(values));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfile(int id)
        {
            var value = await _profileManager.GetByIdAsync(id);
            return Ok(_mapper.Map<AppUserProfileResponseModel>(value));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProfile(CreateAppUserProfileRequestModel model)
        {
            var dto = _mapper.Map<AppUserProfileDto>(model);
            await _profileManager.CreateAsync(dto);
            return Ok("Profil oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile(UpdateAppUserProfileRequestModel model)
        {
            var dto = _mapper.Map<AppUserProfileDto>(model);
            await _profileManager.UpdateAsync(dto);
            return Ok("Profil güncellendi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PacifyProfile(int id)
        {
            return Ok(await _profileManager.SoftDeleteAsync(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfile(int id)
        {
            return Ok(await _profileManager.HardDeleteAsync(id));
        }
    }
}
