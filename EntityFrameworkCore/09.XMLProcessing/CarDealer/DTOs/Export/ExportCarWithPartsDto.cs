﻿namespace CarDealer.DTOs.Export
{

    using System.Xml.Serialization;

    [XmlType("car")]
    public class ExportCarWithPartsDto
    {
        [XmlAttribute("make")]
        public string Make { get; set; } = null!;

        [XmlAttribute("model")]
        public string Model { get; set; } = null!;

        [XmlAttribute("traveled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public ExportPartDto[] Parts { get; set; } = null!;
    }
}
