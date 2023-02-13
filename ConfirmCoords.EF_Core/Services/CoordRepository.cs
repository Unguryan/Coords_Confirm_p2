using AutoMapper;
using ConfirmCoords.App.Services;
using ConfirmCoords.Domain.Models;
using ConfirmCoords.Domain.ViewModels;
using ConfirmCoords.EF_Core.Context;
using ConfirmCoords.EF_Core.Dto;
using Microsoft.EntityFrameworkCore;

namespace ConfirmCoords.EF_Core.Services
{
    public class CoordRepository : ICoordRepository
    {
        private readonly IMapper _mapper;
        private readonly CoordContext _coordContext;

        public CoordRepository(IMapper mapper, CoordContext coordContext)
        {
            _mapper = mapper;
            _coordContext = coordContext;
        }

        public async Task<CoordDetails> AddCoordDetails(CreatingCoordViewModel coordVM)
        {
            var coordToAdd = _mapper.Map<CoordDbo>(coordVM);
            coordToAdd.Created = DateTime.Now;

            var res = await _coordContext.Coords.AddAsync(coordToAdd);
            await _coordContext.SaveChangesAsync();

            return _mapper.Map<CoordDetails>(res.Entity);
        }

        public async Task<CoordDetails> GetCoordDetails(int id)
        {
            var res = await _coordContext.Coords.FirstOrDefaultAsync(c => c.Id == id);

            return _mapper.Map<CoordDetails>(res);
        }
    }
}
