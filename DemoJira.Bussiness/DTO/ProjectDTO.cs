using DemoJira.DataAccess.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoJira.Bussiness.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<IterationDTO> Iterations { get; set; }
    }
}