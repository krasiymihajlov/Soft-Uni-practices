namespace Stations.DataProcessor.ImportDto
{
    using Stations.Models;
    using Stations.Models.Enum;
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TripDto
    {
        [Required]
        [MaxLength(10)]
        public string Train { get; set; }

        [Required]
        [MaxLength(50)]
        public string OriginStation { get; set; }

        [Required]
        [MaxLength(50)]
        public string DestinationStation { get; set; }
       
        [Required]
        public string DepartureTime { get; set; }

        //Must be > DepartureTime
        [Required]
        public string ArrivalTime { get; set; }
        
        public TripStatus? Status { get; set; }

        public string TimeDifference { get; set; }
    }
}
