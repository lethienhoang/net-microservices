using AutoMapper;
using PlatformService.Dtos;
using PlatformService.ExternalServices.CommandService;
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
        private readonly ICommandHttpClient _commandHttpClient;
        private readonly IMapper _mapper;
        public PlatformService(IPlatformRepo platformRepo, ICommandHttpClient commandHttpClient, IMapper mapper)
        {
            _platformRepo = platformRepo;
            _commandHttpClient = commandHttpClient;
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

            // call external service
            var commandInfor = _commandHttpClient.GetCommandInfoByPlatformId(id).Result;
            result.Command = commandInfor;

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
