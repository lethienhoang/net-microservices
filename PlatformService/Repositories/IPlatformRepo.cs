using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Repositories
{
    public interface IPlatformRepo
    {
         bool SaveChange();

         IEnumerable<Platform> GetAllPlatforms();

         Platform GetPlatformById(int id);

         void CreatePlatform(Platform platform);
    }
}