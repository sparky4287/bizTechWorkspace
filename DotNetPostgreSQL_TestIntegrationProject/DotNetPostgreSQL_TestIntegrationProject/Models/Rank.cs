using Microsoft.EntityFrameworkCore;

namespace DotNetPostgreSQL_TestIntegrationProject.Models
{
    public class Rank
    {
        public int Id { get; set; }

        public required string Name { get; set; }
    }
}
