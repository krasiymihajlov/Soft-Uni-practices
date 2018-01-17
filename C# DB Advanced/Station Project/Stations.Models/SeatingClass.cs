namespace Stations.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;

    public class SeatingClass
    {
        public SeatingClass()
        {
            this.TrainSeats = new HashSet<TrainSeat>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(2, MinimumLength = 2)]
        public string Abbreviation { get; set; }

        public ICollection<TrainSeat> TrainSeats { get; set; } //?
    }
}
