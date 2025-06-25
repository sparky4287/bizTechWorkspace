using Microsoft.EntityFrameworkCore;

namespace DotNetPostgreSQL_TestIntegrationProject.Models
{
    public class ExperienceLevel
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
