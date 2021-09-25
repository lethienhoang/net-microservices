using AutoMapper;
using PlatformService.Dtos;
using PlatformService.Models;
using PlatformService.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Services
{
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepo _platformRepo;
        private readonly IMapper _mapper;
        public PlatformService(IPlatformRepo platformRepo, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _mapper = mapper;
        }

        public IEnumerable<PlatformReadDto> GetAll()
        {
            var platforms = _platformRepo.GetAllPlatforms();
            var resutls = _mapper.Map<IEnumerable<PlatformReadDto>>(platforms);

            return resutls;
        }

        public PlatformReadDto GetById(int id)
        {
            var platform = _platformRepo.GetPlatformById(id);
            if (platform == null)
            {
                return null;
            }

            var result = _mapper.Map<PlatformReadDto>(platform);

            return result;
        }

        public void Insert(PlatformCreateDto platformdto)
        {
            if (platformdto == null)
            {
                throw new Exception("body is requried");
            }

            var platform = _mapper.Map<Platform>(platformdto);
            _platformRepo.CreatePlatform(platform);
            _platformRepo.SaveChange();
        }
    }
}
