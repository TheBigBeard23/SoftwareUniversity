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
            string xml = File.ReadAllText("../../../Datasets/parts.xml");
            string result = ImportParts(context, xml);
            Console.WriteLine(result);
        }

        //---------------- Import Data ----------------

        //01.Import Users
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

        //02.Import Products
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
    }
}