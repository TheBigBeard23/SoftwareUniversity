﻿namespace CarDealer.DTOs.Export
{
    using System.Runtime.Serialization;
    using System.Xml.Serialization;

    [XmlType("customer")]
    public class ExportCustomerDto
    {

        [XmlAttribute("full-name")]
        public string Name { get; set; } = null!;

        [XmlAttribute("bought-cars")]
        public int BoughtCars { get; set; }

        [XmlAttribute("spent-money")]
        public decimal SpendMoney { get; set; }

    }
}
