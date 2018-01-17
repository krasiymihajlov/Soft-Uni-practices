namespace Stations.DataProcessor.ImportDto.Tickets
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Card")]
    public class CardDto
    {
        [XmlAttribute("Name")]
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
