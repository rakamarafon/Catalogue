using Catalogue.DAL.Model;
using Catalogue.Models.Response;
using System.Linq;

namespace Catalogue.Core.Mapper
{
    public class AutoMapperProfileConfiguration : AutoMapper.Profile
    {
        public AutoMapperProfileConfiguration() : this("CatalogueProfile")
        {
        }

        protected AutoMapperProfileConfiguration(string profileName) : base(profileName)
        {
            CreateMap<Orders, OrderResponseModel>()
                .ForMember(x => x.OrderId, opt => opt.MapFrom(m => m.Id))
                .ForMember(x => x.TotalAmount, opt => opt.MapFrom(m => m.Items.ToList().Sum(p => p.Price)))
                .ForMember(x => x.CustomerId, opt => opt.MapFrom(m => m.User.CustomerId))
                .ForMember(x => x.Item, opt => opt.MapFrom(m => m.Items));

            CreateMap<Items, ItemResponseModel>()
                .ForMember(x => x.ItemName, opt => opt.MapFrom(m => m.Name))
                .ForMember(x => x.ItemPrice, opt => opt.MapFrom(m => m.Price))
                .ForMember(x => x.ItemUPC, opt => opt.MapFrom(m => m.UPC));
        }
    }
}
