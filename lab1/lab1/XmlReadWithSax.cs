using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace lab1
{
    public static class XmlReadWithSax
    {
        internal static void Read(string filepath)
        {
            var settings = new XmlReaderSettings
            {
                IgnoreComments = true,
                IgnoreProcessingInstructions = true,
                IgnoreWhitespace = true
            };

            var reader = XmlReader.Create(filepath, settings);

            var count = 0;
            var commonNameForms = new Dictionary<string, HashSet<string>>();
            var entityCreamCount = new Dictionary<string, int>();
            var entityTabletCount = new Dictionary<string, int>();

            reader.MoveToContent();
            while (reader.Read())
            {
                if (reader.NodeType != XmlNodeType.Element || reader.Name != "produktLeczniczy")
                    continue;
                var entity = reader.GetAttribute("podmiotOdpowiedzialny");
                var form = reader.GetAttribute("postac");
                var commonName = reader.GetAttribute("nazwaPowszechnieStosowana");

                if (form == "Krem" && commonName == "Mometasoni furoas")
                    count++;

                if (commonNameForms.ContainsKey(commonName!))
                    commonNameForms[commonName!].Add(form);
                else
                    commonNameForms[commonName!] = new HashSet<string> { form };

                if (form == "Krem")
                {
                    if (entityCreamCount.ContainsKey(entity))
                        entityCreamCount[entity]++;
                    else
                        entityCreamCount[entity] = 1;
                }
                else if (form.Contains("Tabletki"))
                {
                    if (entityTabletCount.ContainsKey(entity))
                        entityTabletCount[entity]++;
                    else
                        entityTabletCount[entity] = 1;
                }
            }

            var mostCreamsEntity = entityCreamCount.Aggregate((left, right) => left.Value > right.Value ? left : right).Key;
            var mostTabletsEntity = entityTabletCount.Aggregate((left, right) => left.Value > right.Value ? left : right).Key;
            var topThreeCreamEntities = (from ele in entityCreamCount orderby ele.Value descending select ele).Take(3);

            Console.WriteLine($"Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest Mometasoni furoas: {count}");
            Console.WriteLine($"Liczba preparatów leczniczych o takiej samie nazwie powszechnej, pod różnymi postaciami: {commonNameForms.Values.Count(set => set.Count > 1)}");
            Console.WriteLine($"Podmiot produkujacy najwiecej kremow: {mostCreamsEntity}, podmiot produkujacy najwiecej tabletek: {mostTabletsEntity}");
            Console.WriteLine($"3 podmioty produkujace najwiecej kremu: ");
            foreach (var (entity, creamCount) in topThreeCreamEntities)
                Console.WriteLine($"\t{entity}: {creamCount}");
        }
    }
}