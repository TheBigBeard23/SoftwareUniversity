
namespace MiniORM.App;

using MiniORM.App.Data;
internal class StartUp
{
    public static void Main(string[] args)
    {
        SoftUniDbContext dbCtx = new SoftUniDbContext(Config.ConnectionString);
        Console.WriteLine("23");
    }
}
