using AutoMapper;
using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using System.Data.Common;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static IMapper mapper;
        public static void Main()
        {
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CarDealerProfile>();
            }));

            CarDealerContext context = new CarDealerContext();
            string xml = File.ReadAllText("../../../Datasets/customers.xml");
            string result = ImportCustomers(context, xml);
            Console.WriteLine(result);
        }

        //---------------- Import Data ----------------

        //01. Import Users
        public static string ImportSuppliers(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ImportSupplierDto[] supplierDtos =
                xmlHelper.Deserialize<ImportSupplierDto[]>(inputXml, "Suppliers");

            ICollection<Supplier> validSuppliers = new HashSet<Supplier>();

            foreach (ImportSupplierDto supplierDto in supplierDtos)
            {
                if (supplierDto.Name != null)
                {
                    Supplier supplier = new Supplier()
                    {
                        Name = supplierDto.Name,
                        IsImporter = supplierDto.IsImporter
                    };
                    validSuppliers.Add(supplier);
                }
            }

            context.Suppliers.AddRange(validSuppliers);
            context.SaveChanges();

            return $"Successfully imported {validSuppliers.Count} suppliers!";
        }

        //02. Import Products
        public static string ImportParts(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ImportPartDto[] partDtos = xmlHelper.Deserialize<ImportPartDto[]>(inputXml, "Parts");

            ICollection<Part> validParts = new HashSet<Part>();

            foreach (var partDto in partDtos)
            {
                if (partDto.Name != null &&
                    partDto.SupplierId.HasValue &&
                    context.Suppliers.Any(s => s.Id == partDto.SupplierId))
                {
                    Part part = mapper.Map<Part>(partDto);
                    validParts.Add(part);
                }
            }

            context.Parts.AddRange(validParts);
            context.SaveChanges();

            return $"Successfully imported {validParts.Count} parts!";
        }

        //03. Import Cars
        public static string ImportCars(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ImportCarDto[] carDtos =
                xmlHelper.Deserialize<ImportCarDto[]>(inputXml, "Cars");

            ICollection<Car> validCars = new HashSet<Car>();

            foreach (ImportCarDto carDto in carDtos)
            {
                if (!string.IsNullOrEmpty(carDto.Make) &&
                    !string.IsNullOrEmpty(carDto.Model))
                {
                    Car car = mapper.Map<Car>(carDto);

                    foreach (var partDto in carDto.Parts.DistinctBy(p => p.PartId))
                    {
                        if (context.Parts.Any(p => p.Id == partDto.PartId))
                        {
                            PartCar carPart = new PartCar()
                            {
                                PartId = partDto.PartId
                            };
                            car.PartsCars.Add(carPart);
                        }
                    }

                    validCars.Add(car);
                }
            }

            context.Cars.AddRange(validCars);
            context.SaveChanges();

            return $"Successfully imported {validCars.Count} cars!";
        }

        //04. Import Customers
        public static string ImportCustomers(CarDealerContext context, string inputXml)
        {
            XmlHelper xmlHelper = new XmlHelper();

            ImportCustomerDto[] customerDtos = xmlHelper.Deserialize<ImportCustomerDto[]>(inputXml, "Customers");

            ICollection<Customer> validCustomers = new HashSet<Customer>();

            foreach (ImportCustomerDto customerDto in customerDtos)
            {
                if (!string.IsNullOrEmpty(customerDto.Name))
                {
                    validCustomers.Add(mapper.Map<Customer>(customerDto));
                }
            }
            context.Customers.AddRange(validCustomers);
            context.SaveChanges();

            return $"Successfully imported {validCustomers.Count} customers!";
        }
    }
}