using AutoMapper;
using Skinet.Application.ProductModel.Response;
using Skinet.Domain.ProductModel;

namespace Skinet.Application.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductResponse>();
        }
    }
}
