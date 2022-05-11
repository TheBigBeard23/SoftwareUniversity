using System;
using System.IO;

namespace _04.MergeTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                using (StreamReader firstReader = new StreamReader("../../../firstInput.txt"))
                {
                    using (StreamReader secondReader = new StreamReader("../../../secondInput.txt"))
                    {
                        string line = string.Empty;
                        bool fisrtFileIsEmpty = false;
                        bool secondFileIsEmpty = false;

                        while (!fisrtFileIsEmpty || !secondFileIsEmpty)
                        {
                            if (!fisrtFileIsEmpty)
                            {
                                line = firstReader.ReadLine();
                                WriteLine(writer, line, ref fisrtFileIsEmpty);
                            }

                            if (!secondFileIsEmpty)
                            {
                                line = secondReader.ReadLine();
                                WriteLine(writer, line, ref secondFileIsEmpty);
                            }

                        }
                    }
                }
            }
        }

        private static void WriteLine(StreamWriter writer, string line, ref bool fileIsEmpty)
        {
            if (line != null)
            {
                writer.WriteLine(line);
                fileIsEmpty = false;
            }
            else
            {
                fileIsEmpty = true;
            }
        }

    }
}
