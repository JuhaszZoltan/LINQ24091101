using LINQ24091101;

#region cica lista
List<Cat> cats = [
    new() //01
    {
        Id = 1,
        Name = "Kolombusz",
        Sex = true,
        Birth = new DateTime(2020, 06, 20),
        Weight = 3.0F,
        Breed = "házimacska"
    },
    new() //02
    {
        Id = 2,
        Name = "Cikk-Cakk",
        Sex = false,
        Birth = new DateTime(2016, 08, 19),
        Weight = 2.1F,
        Breed = "házimacska"
    },
    new() //03
    {
        Id = 3,
        Name = "Pizsama",
        Sex = false,
        Birth = new DateTime(2022, 07, 11),
        Weight = 2.5F,
        Breed = "britt rövidszőrű"
    },
    new() //04
    {
        Id = 4,
        Name = "Megatron",
        Sex = true,
        Birth = new DateTime(2024, 05, 01),
        Weight = 0.9F,
        Breed = "szfinx"
    },
    new() //05
    {
        Id = 5,
        Name = "Bogyi",
        Sex = false,
        Birth = new DateTime(2021, 02, 14),
        Weight = 2.4F,
        Breed = "házimacska"
    },
    new() //06
    {
        Id = 6,
        Name = "Rozi",
        Sex = false,
        Birth = new DateTime(2021, 10, 28),
        Weight = 4.2F,
        Breed = "perzsa"
    },
    new() //07
    {
        Id = 7,
        Name = "Kombájn",
        Sex = true,
        Birth = new DateTime(2008, 07, 01),
        Weight = 5.1F,
        Breed = "perzsa"
    },
];
#endregion

/* eddig ismert nevezetes algoritmusok
 * sorozatszámítás (összegzést) => átlagszámítás
 * megszámlálás
 * szélsőérték meghatározás (minimum, maximum)
 * lineáris keresés
 * kiválasztás
 * eldöntés
 * 
 * kiválogatás
 * szétválogatás
 * "rendezés"
 * halmaztételek
*/

float linqOsszegzes = cats.Sum(c => c.Weight);
Console.WriteLine($"cicak osszsulya: {linqOsszegzes} Kg");

double linqAtlageletkor = cats.Average(c => c.Age);
Console.WriteLine($"cicak atlageletkora: {linqAtlageletkor} ev");

int linqHazimacskakSzama = cats.Count(c => c.Breed == "házimacska");
Console.WriteLine($"hazimacskak szama: {linqHazimacskakSzama} db");

DateTime linqLegfiatalabbMacskaSzD = cats.Max(c => c.Birth);
Console.WriteLine($"legfiatalabb cica szulinapja: {linqLegfiatalabbMacskaSzD:yyyy-MM-dd}");

Cat linqlegveznabbCic = cats.MinBy(c => c.Weight);
Console.WriteLine($"legvéznabb cica neve: {linqlegveznabbCic}");

int abcbenElsoCica = cats.IndexOf(cats.MinBy(c => c.Name));
Console.WriteLine($"nevsorban elso cica indexe: {abcbenElsoCica}");

//-------------------------

Console.WriteLine("cicak nev szerint rendezve:");
var nevSzerintRendezve = cats.OrderBy(c => c.Name);
foreach (var cat in nevSzerintRendezve)
{
    Console.WriteLine($"\t- {cat}");
}

Console.WriteLine("-----------------------------");

Console.WriteLine("cicak súly stzerint csokkenoben:");
var sulySzerint = cats.OrderByDescending(c => c.Weight);
foreach (var cat in sulySzerint)
{
    Console.WriteLine($"\t- {cat}");
}