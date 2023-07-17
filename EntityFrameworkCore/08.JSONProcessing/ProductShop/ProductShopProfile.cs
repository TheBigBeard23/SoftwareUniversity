
namespace ProductShop
{
    using AutoMapper;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            //User
            this.CreateMap<ImportUserDTO, User>();
        }
    }
}
