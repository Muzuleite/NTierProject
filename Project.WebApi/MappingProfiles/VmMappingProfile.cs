using AutoMapper;
using Project.Bll.Dtos;
using Project.Validation.Models.RequestModels.AppUserProfiles;
using Project.Validation.Models.RequestModels.AppUsers;
using Project.Validation.Models.RequestModels.Categories;
using Project.Validation.Models.RequestModels.OrderDetails;
using Project.Validation.Models.RequestModels.Orders;
using Project.Validation.Models.RequestModels.Products;
using Project.Validation.Models.ResponseModels.AppUserProfiles;
using Project.Validation.Models.ResponseModels.AppUsers;
using Project.Validation.Models.ResponseModels.Categories;
using Project.Validation.Models.ResponseModels.OrderDetails;
using Project.Validation.Models.ResponseModels.Orders;
using Project.Validation.Models.ResponseModels.Products;


namespace Project.WebApi.MappingProfiles
{
    public class VmMappingProfile : Profile
    {
        public VmMappingProfile()
        {
            
           

            CreateMap<CreateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<CreateAppUserRequestModel, AppUserDto>();
            CreateMap<CreateProductRequestModel, ProductDto>();
            CreateMap<CreateOrderRequestModel, OrderDto>();
            CreateMap<CreateOrderDetailRequestModel, OrderDetailDto>();
            CreateMap<CreateCategoryRequestModel, CategoryDto>();

            CreateMap<UpdateAppUserRequestModel, AppUserDto>();
            CreateMap<UpdateAppUserProfileRequestModel, AppUserProfileDto>();
            CreateMap<UpdateProductRequestModel, ProductDto>();
            CreateMap<UpdateCategoryRequestModel, CategoryDto>();
            CreateMap<UpdateOrderDetailRequestModel, OrderDetailDto>();
            CreateMap<UpdateOrderRequestModel, OrderDto>();


            CreateMap<CategoryDto, CategoryResponseModel>();
            CreateMap<AppUserDto, AppUserResponseModel>();
            CreateMap<AppUserProfileDto, AppUserProfileResponseModel>();
            CreateMap<ProductDto, ProductResponseModel>();
            CreateMap<OrderDto, OrderResponseModel>();
            CreateMap<OrderDetailDto, OrderDetailResponseModel>();
        }
    }
}
