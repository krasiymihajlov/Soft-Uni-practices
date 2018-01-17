namespace Stations.DataProcessor.ImportDto
{
    using Stations.Models.Enum;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Card")]
    public class CardDto
    {
        [Required]
        [MaxLength(128)]
        public string Name { get; set; }

        [Range(0, 120)]
        public int Age { get; set; }

        public CardType CardType { get; set; } = CardType.Normal;
    }
}
