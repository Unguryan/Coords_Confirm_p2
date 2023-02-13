using AutoMapper;
using ConfirmCoords.App.Commands.CreateCoord;
using ConfirmCoords.Domain.ViewModels;
using Coord.Domain.Events;

namespace ConfirmCoords.App.MapperProfiles
{
    public class CoordProfile : Profile
    {
        public CoordProfile()
        {
            CreateMap<CreatingCoordResultViewModel, CreatingCoordCommandResult>()
                .ReverseMap();
            CreateMap<CreatingCoordViewModel, CreatingCoordEvent>()
                .ReverseMap();
            CreateMap<CreatingCoordCommandResult, CreatedCoordEvent>()
                .ReverseMap();
        }
    }
}
