using AutoMapper;
using ConfirmCoords.Domain.Models;
using ConfirmCoords.Domain.ViewModels;
using ConfirmCoords.EF_Core.Dto;

namespace ConfirmCoords.EF_Core.MapperProfiles
{
    public class CoordProfile : Profile
    {
        public CoordProfile()
        {
            CreateMap<CoordDbo, CoordDetails>()
                .ReverseMap();
            CreateMap<CoordDbo, CreatingCoordViewModel>()
                .ReverseMap();
        }
    }
}
