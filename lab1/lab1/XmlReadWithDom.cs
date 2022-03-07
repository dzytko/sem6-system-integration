using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace lab1
{
    public static class XMLReadWithDomApproach
    {
        internal static void Read(string filepath)
        {
            var doc = new XmlDocument();
            doc.Load(filepath);

            var count = 0;
            var commonNameForms = new Dictionary<string, HashSet<string>>();
            var drugs = doc.GetElementsByTagName("produktLeczniczy");
            var entityCreamCount = new Dictionary<string, int>();
            var entityTabletCount = new Dictionary<string, int>();
            foreach (XmlNode drug in drugs)
            {
                var form = drug!.Attributes!.GetNamedItem("postac")!.Value!;
                var commonName = drug!.Attributes!.GetNamedItem("nazwaPowszechnieStosowana")!.Value!;
                var entity = drug!.Attributes!.GetNamedItem("podmiotOdpowiedzialny")!.Value!;

                if (form == "Krem" && commonName == "Mometasoni furoas")
                    count++;

                if (commonNameForms.ContainsKey(commonName))
                    commonNameForms[commonName].Add(form);
                else
                    commonNameForms[commonName] = new HashSet<string> { form };

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

            var mostCreamsEntity = entityCreamCount.Aggregate((left, right) => left.Value > right.Value ? left : right);
            var mostTabletsEntity = entityTabletCount.Aggregate((left, right) => left.Value > right.Value ? left : right);
            var topThreeCreamEntities = (from ele in entityCreamCount orderby ele.Value descending select ele).Take(3);

            Console.WriteLine($"Liczba produktów leczniczych w postaci kremu, których jedyną substancją czynną jest Mometasoni furoas: {count}");
            Console.WriteLine($"Liczba preparatów leczniczych o takiej samie nazwie powszechnej, pod różnymi postaciami: {commonNameForms.Values.Count(set => set.Count > 1)}");
            Console.WriteLine($"Podmiot produkujacy najwiecej kremow: {mostCreamsEntity.Key}({mostCreamsEntity.Value}), podmiot produkujacy najwiecej tabletek: {mostTabletsEntity.Key}({mostTabletsEntity.Value})");
            Console.WriteLine($"3 podmioty produkujace najwiecej kremu: ");
            foreach (var (entity, creamCount) in topThreeCreamEntities)
                Console.WriteLine($"\t{entity}: {creamCount}");
        }
    }
}