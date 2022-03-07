using System;
using System.Collections.Generic;
using System.Xml;

namespace lab1
{
    public static class DeeperAnalysis
    {
        internal static void ReadActiveIngredientStats(string filepath)
        {
            var doc = new XmlDocument();
            doc.Load(filepath);

            var drugs = doc.GetElementsByTagName("produktLeczniczy");
            var oneActiveIngredientCount = 0;
            var multipleActiveIngredientsCount = 0;

            foreach (XmlNode drug in drugs)
            {
                if (drug.FirstChild!.ChildNodes.Count > 1)
                    multipleActiveIngredientsCount++;
                else
                    oneActiveIngredientCount++;
            }

            Console.WriteLine($"Liczba produktow z jednym aktwynym skladnikiem: {oneActiveIngredientCount}");
            Console.WriteLine($"Liczba produktow z wieloma aktwynymi skladnikami: {multipleActiveIngredientsCount}");
        }

        internal static void PackingOptionsAnalysis(string filepath)
        {
            var doc = new XmlDocument();
            doc.Load(filepath);

            var drugs = doc.GetElementsByTagName("produktLeczniczy");

            var numberOfPackingOptionsCount = new SortedDictionary<int, int>();
            foreach (XmlNode drug in drugs)
            {
                var packingOptionsCount = drug.ChildNodes.Item(1)!.ChildNodes.Count;
                if (numberOfPackingOptionsCount.ContainsKey(packingOptionsCount))
                    numberOfPackingOptionsCount[packingOptionsCount]++;
                else
                    numberOfPackingOptionsCount[packingOptionsCount] = 1;
            }

            Console.WriteLine("\nLiczba roznych opakowan leku: ilosc");
            foreach (var (numberOfPackingOptions, count) in numberOfPackingOptionsCount)
                Console.WriteLine($"{numberOfPackingOptions}: {count}");
        }
    }
}