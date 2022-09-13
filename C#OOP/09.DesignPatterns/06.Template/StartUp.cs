using System;

namespace TemplateDemo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var sourdough = new Sourdough();
            sourdough.Make();

            var twelveGrain = new TwelveGrain();
            twelveGrain.Make();

            var wholeWheat = new WholeWheat();
            wholeWheat.Make();
        }
    }
}
