namespace FastFood.DataProcessor.Dto.Import
{
    using FastFood.Models;
    using FastFood.Models.Enums;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using System.Collections.Generic;

    [XmlType("Order")]
    public class OrderDto
    {
        public OrderDto()
        {
            this.Items = new OrderItemDto[0];
        }

        [Required]
        [XmlElement("Customer")]
        public string Customer { get; set; }

        [Required]
        [XmlElement("Employee")]
        public string EmployeeName { get; set; }

        [Required]
        [XmlElement("DateTime")]
        public string DateTime { get; set; }

        [Required]
        [XmlElement("Type")]
        public OrderType Type { get; set; } = OrderType.ForHere;

        [Required]
        public OrderItemDto[] Items { get; set; }
    }
}
