namespace Stations.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class StationDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        public string Town { get; set; }
    }
}
