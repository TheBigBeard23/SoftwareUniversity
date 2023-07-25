using AutoMapper;
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
            this.CreateMap<Supplier, ExportLocalSupplierDto>()
                .ForMember(d => d.PartCount, opt => opt
                .MapFrom(s => s.Parts.Count));

            //Part
            this.CreateMap<ImportPartDto, Part>()
                .ForMember(d => d.SupplierId,
                opt => opt.MapFrom(s => s.SupplierId!.Value));
            this.CreateMap<Part, ExportPartDto>();

            //Car
            this.CreateMap<ImportCarDto, Car>()
                .ForSourceMember(s => s.Parts, opt => opt.DoNotValidate());
            this.CreateMap<Car, ExportCarDto>();
            this.CreateMap<Car, ExportCarBmwDto>();
            this.CreateMap<Car, ExportCarWithPartsDto>()
                .ForMember(d => d.Parts, opt => opt
                .MapFrom(s => s.PartsCars
                                         .OrderByDescending(pc => pc.Part.Price)
                                         .Select(pc => pc.Part).ToArray()));

            //Customer
            this.CreateMap<ImportCustomerDto, Customer>();
            this.CreateMap<Customer, ExportCustomerDto>()
                .ForMember(d => d.BoughtCars, opt => opt
                .MapFrom(s => s.Sales.Count))
                .ForMember(d => d.SpendMoney, opt => opt
                .MapFrom(s => s.Sales
                        .SelectMany(s => s.Car.PartsCars)
                        .Sum(p => p.Part.Price)));

            //Sale
            this.CreateMap<ImportSaleDto, Sale>();
        }
    }
}
