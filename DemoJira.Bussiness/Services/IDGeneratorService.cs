using DemoJira.Bussiness.ServiceInterface;
using DemoJira.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoJira.Bussiness.Services
{
    public class IDGeneratorService:IIdGeneratorService
    {
        private readonly SiraDBContext _context;

        public IDGeneratorService(SiraDBContext context)
        {
            _context = context;
        }

        public async Task<string> GenerateNextIdAsync(string type)
        {
            string prefix = type == "Task" ? "TA" : "BG";
            string lastId = await _context.Tasks
                .Where(t => t.Type == type)
                .OrderByDescending(t => t.HexId)
                .Select(t => t.HexId)
                .FirstOrDefaultAsync();

            int nextNumber = 1;
            if (!string.IsNullOrEmpty(lastId))
            {
                nextNumber = int.Parse(lastId.Substring(2)) + 1;
            }

            return $"{prefix}{nextNumber:D4}";
        }
    }
}
