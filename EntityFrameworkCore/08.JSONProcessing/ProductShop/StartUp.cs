
namespace ProductShop
{
    using AutoMapper;
    using Data;
    using Newtonsoft.Json;
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

            string inputJson =
                File.ReadAllText(@"../../../Datasets/users.json");

            string result = ImportUsers(context, inputJson);
            Console.WriteLine(result);
        }
        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            ImportUserDTO[] userDtos =
                JsonConvert.DeserializeObject<ImportUserDTO[]>(inputJson);

            ICollection<User> validUsers = new HashSet<User>();

            foreach (ImportUserDTO userDTO in userDtos)
            {
                User user = mapper.Map<User>(userDTO);

                validUsers.Add(user);
            }

            context.Users.AddRange(validUsers);
            context.SaveChanges();

            return $"Successfully imported {validUsers.Count}";
        }
    }
}