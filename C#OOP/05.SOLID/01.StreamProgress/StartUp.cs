using System;
using System.Threading;

namespace StreamProgress
{
    public class StartUp
    {
        static void Main()
        {
            SendFile();
            SendMusic();

        }

        private static void SendMusic()
        {
            Music music = new Music("Fyre", "Caesar", 500, 0);

            StreamProgressInfo progressInfo = new StreamProgressInfo(music);
            var progress = 0;

            Console.WriteLine($"Sending {music.GetType().Name}");
            while (progress <= 100)
            {
                Console.WriteLine($"{progress}% sent");
                music.BytesSent += 5;
                progress = progressInfo.CalculateCurrentPercent();
                Thread.Sleep(400);
            }
            Console.WriteLine($"{music.GetType().Name}'s sent");
            Console.WriteLine("------------------------");
        }

        private static void SendFile()
        {
            File file = new File("text", 100, 0);

            StreamProgressInfo progressInfo = new StreamProgressInfo(file);
            var progress = 0;

            Console.WriteLine($"Sending {file.GetType().Name}");
            while (progress <= 100)
            {
                Console.WriteLine($"{progress}% sent");
                file.BytesSent += 5;
                progress = progressInfo.CalculateCurrentPercent();
                Thread.Sleep(400);
            }
            Console.WriteLine($"{file.GetType().Name}'s sent");
            Console.WriteLine("------------------------");
        }
    }
}
