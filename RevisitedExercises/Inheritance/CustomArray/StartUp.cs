namespace CustomArray
{
    public class StartUp
    {
        static void Main(string[] args)
        {
           CustomList<int> list = new CustomList<int>();

            list.Add(1);    
            list.Add(2);
            list.Add(3);
            list.Add(4);

            list.Add(5);
        }
    }
}