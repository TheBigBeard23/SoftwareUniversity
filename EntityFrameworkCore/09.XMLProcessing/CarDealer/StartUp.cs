using CarDealer.Data;
using CarDealer.DTOs.Import;
using CarDealer.Models;
using CarDealer.Utilities;
using System.Xml.Serialization;

namespace CarDealer
{
    public class StartUp
    {
        public static void Main()
        {
            CarDealerContext context = new CarDealerContext();
            string xml = File.ReadAllText("../../../Datasets/suppliers.xml");
            string result = ImportSuppliers(context, xml);
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
    }
}