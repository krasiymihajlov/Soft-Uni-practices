namespace Stations.DataProcessor.ImportDto
{
    using Stations.Models.Enum;
    using System.ComponentModel.DataAnnotations;

    public class TrainDto
    {
        public TrainDto()
        {
            this.Seats = new SeatsDto[0];
        }

        [Required]
        [MaxLength(10)]
        public string TrainNumber { get; set; }

        public TrainType? Type { get; set; }

        public SeatsDto[] Seats { get; set; }
    }
}
