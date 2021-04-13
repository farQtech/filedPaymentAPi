using AutoMapper;
using System.Collections.Generic;

namespace FiledPaymentService
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DB.Payment, Models.Payment>().ReverseMap();
            CreateMap<IEnumerable<DB.Payment>, IEnumerable<Models.Payment>>().ReverseMap();
        }
    }
}
