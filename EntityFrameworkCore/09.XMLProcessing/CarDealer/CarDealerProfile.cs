namespace CarDealer
{

    using AutoMapper;
    using CarDealer.DTOs.Export;
    using CarDealer.DTOs.Import;
    using CarDealer.Models;

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
                        .SelectMany(sl => sl.Car.PartsCars)
                        .Sum(p => p.Part.Price)));

            //Sale
            this.CreateMap<ImportSaleDto, Sale>();
            this.CreateMap<Sale, ExportSaleWithAppliedDiscount>()
                .ForMember(d => d.CustomerName, opt => opt
                .MapFrom(s => s.Customer.Name))
                .ForMember(d => d.Price, opt => opt
                .MapFrom(s => s.Car.PartsCars.Sum(pc => pc.Part.Price)))
                .ForMember(d => d.PriceWithDiscount, opt => opt
                .MapFrom(s => decimal.Parse(((100 - s.Discount) / 100 * s.Car.PartsCars.Sum(pc => pc.Part.Price))
                .ToString("F2"))));
        }
    }
}
