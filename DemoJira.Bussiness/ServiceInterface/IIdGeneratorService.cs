using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.ServiceInterface
{
    public interface IIdGeneratorService
    {
        Task<string> GenerateNextIdAsync(string type);

        Task<int> GenerateNextRelationIdAsync();

    }
}
