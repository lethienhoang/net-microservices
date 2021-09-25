using PlatformService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.Services
{
    public interface IPlatformService
    {
        public IEnumerable<PlatformReadDto> GetAll();

        public PlatformReadDto GetById(int id);

        public void Insert(PlatformCreateDto platformdto);
    }
}
