namespace ProductShop
{

    using AutoMapper;
    using Newtonsoft.Json;

    using ProductShop.Data;
    using ProductShop.DTOs.Import;
    using ProductShop.Models;

    public class StartUp
    {
        private static IMapper mapper;
        public static void Main()
        {
            mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            }));

            ProductShopContext context = new ProductShopContext();
            
            string inputJson = File.ReadAllText("../../../Datasets/products.json");
            string result = ImportProducts(context, inputJson);
            
            Console.WriteLine(result);
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            var userDtos = JsonConvert.DeserializeObject<ImportUserDto[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();

            foreach (ImportUserDto userDto in userDtos)
            {
                User user = mapper.Map<User>(userDto);
                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count} users";
        }
        public static string ImportProducts(ProductShopContext context, string inputJson)
        {
            ImportProductDto[] productDtos = JsonConvert.DeserializeObject<ImportProductDto[]>(inputJson);

            ICollection<Product> products = mapper.Map<Product[]>(productDtos);

            context.Products.AddRange(products);
            context.SaveChanges();

            return $"Successfully imported {products.Count} products";
        }
    }
}