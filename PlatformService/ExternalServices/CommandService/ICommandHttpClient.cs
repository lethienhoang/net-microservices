using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlatformService.ExternalServices.CommandService
{
    public interface ICommandHttpClient
    {
        public Task<string> GetCommandInfoByPlatformId(int paltformId);
    }
}
