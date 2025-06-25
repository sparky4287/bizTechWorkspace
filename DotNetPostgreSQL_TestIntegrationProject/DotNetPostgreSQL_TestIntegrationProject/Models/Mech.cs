namespace DotNetPostgreSQL_TestIntegrationProject.Models
{
    public class Mech
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public string? Description { get; set; }

        public int MechwarriorId { get; set; }
    }
}
