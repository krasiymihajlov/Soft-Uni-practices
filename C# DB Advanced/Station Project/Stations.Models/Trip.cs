namespace Stations.Models
{
    using Stations.Models.Enum;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Trip
    {
        public Trip()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }

        [Required]
        public int OriginStationId { get; set; }
        public Station OriginStation { get; set; }

        [Required]
        public int DestinationStationId { get; set; }
        public Station DestinationStation { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        //Must be > DepartureTime
        [Required]
        public DateTime ArrivalTime { get; set; }

        [Required]
        public int TrainId { get; set; }
        public Train Train { get; set; }

        public TripStatus Status { get; set; }

        public TimeSpan? TimeDifference { get; set; }

        public ICollection<Ticket> Tickets { get; set; } //?
    }
}