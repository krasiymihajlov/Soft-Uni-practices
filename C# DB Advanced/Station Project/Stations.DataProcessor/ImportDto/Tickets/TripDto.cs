namespace Stations.DataProcessor.ImportDto.Tickets
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Trip")]
    public class TripDto
    {
        [XmlElement("OriginStation")]
        [Required]
        [MaxLength(50)]
        public string OriginStation { get; set; }

        [XmlElement("DestinationStation")]
        [Required]
        [MaxLength(50)]
        public string DestinationStation { get; set; }

        [XmlElement("DepartureTime")]
        [Required]
        public string DepartureTime { get; set; }
    }
}
