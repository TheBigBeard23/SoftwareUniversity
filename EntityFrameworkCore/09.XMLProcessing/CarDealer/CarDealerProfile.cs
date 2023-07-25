﻿using AutoMapper;
using CarDealer.DTOs.Export;
using CarDealer.DTOs.Import;
using CarDealer.Models;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            // Supplier
            this.CreateMap<ImportSupplierDto, Supplier>();

            //Part
            this.CreateMap<ImportPartDto, Part>()
                .ForMember(d => d.SupplierId,
                opt => opt.MapFrom(s => s.SupplierId!.Value));

            //Car
            this.CreateMap<ImportCarDto, Car>()
                .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());
            this.CreateMap<Car, ExportCarDto>();

            //Customer
            this.CreateMap<ImportCustomerDto, Customer>();

            //Sale
            this.CreateMap<ImportSaleDto,Sale>();
        }
    }
}
