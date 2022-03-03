using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyMaterials = new Dictionary<string, int>
            {
                {"shards",   0},
                {"motes",    0},
                {"fragments",0}
            };

            Dictionary<string, int> junkMaterials = new Dictionary<string, int>();

            bool itemObtained = false;
            string materialForItem = string.Empty;

            while (!itemObtained)
            {
                string[] materials = Console.ReadLine()
                                            .Split()
                                            .ToArray();

                for (int i = 0; i < materials.Length; i += 2)
                {
                    string material = materials[i + 1].ToLower();
                    int quantity = int.Parse(materials[i]);

                    if (keyMaterials.ContainsKey(material))
                    {
                        keyMaterials[material] += quantity;

                        if (keyMaterials[material] >= 250)
                        {
                            itemObtained = true;
                            materialForItem = material;
                            keyMaterials[material] -= 250;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(material))
                        {
                            junkMaterials[material] = 0;
                        }

                        junkMaterials[material] += quantity;
                    }
                }
            }

            if (materialForItem == "shards")
            {
                Console.WriteLine("Shadowmourne obtained!");
            }
            else if (materialForItem == "fragments")
            {
                Console.WriteLine("Valanyr obtained!");
            }
            else
            {
                Console.WriteLine("Dragonwrath obtained!");
            }

            foreach (var material in keyMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            foreach (var material in junkMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
