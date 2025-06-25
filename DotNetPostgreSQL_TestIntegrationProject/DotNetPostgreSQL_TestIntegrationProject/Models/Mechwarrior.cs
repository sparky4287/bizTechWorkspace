using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DotNetPostgreSQL_TestIntegrationProject.Models
{
    public class Mechwarrior
    {
        public int Id { get; set; }

        public DateOnly HireDate { get; set; }

        public int ExperienceId { get; set; }

        public int RankId { get; set; }

        public int Score { get; set; }

        public string? Background { get; set; }
    }
}
