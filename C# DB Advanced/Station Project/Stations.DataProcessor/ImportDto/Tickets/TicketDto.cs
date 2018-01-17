namespace Stations.DataProcessor.ImportDto.Tickets
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Ticket")]
    public class TicketDto
    {
        [XmlAttribute("price")]
        [Required]
        [Range(typeof(decimal), "0", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [XmlAttribute("seat")]
        [Required]
        [RegularExpression(@"^[A-Z]{2}\d{1,6}$")]
        public string SeatingPlace { get; set; }

        [Required]
        public TripDto Trip { get; set; }

        public CardDto Card { get; set; }
    }
}
