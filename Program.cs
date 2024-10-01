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
 * [x] sorozatszámítás (összegzést) => átlagszámítás
 * [x] megszámlálás
 * [x] szélsőérték meghatározás (minimum, maximum)
 * [x] lineáris keresés
 * [x] kiválasztás
 * [x] eldöntés
 * 
 * [x] kiválogatás
 * [x] szétválogatás
 * [x] "rendezés"
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

//-------------------------

/*
 * first
 * first or default
 * last
 * last or default
 * single
 * single or default
 -----------------
 * index of
*/

Console.WriteLine("-----------------------------");

var frst = cats.First(c => c.Breed == "perzsa");
Console.WriteLine($"az első perzsacica: {frst}");
//ha VAN egyezés, akkor a rendre ELSŐ {matching element}-el tér vissza
//ha NINCS egyezés, akkor "sequence contains no matching element"-et dob

var lst = cats.Last(c => c.Sex);
Console.WriteLine($"az utolsú kisfiú: {lst}");
//ha VAN egyezés, akkor a rendre UTOLSÓ {matching element}-el tér vissza
//ha NINCS egyezés, akkor "sequence contains no matching element"-et dob

var sngl = cats.Single(c => c.Breed == "szfinx");
Console.WriteLine($"az egyetlen kopszi: {sngl}");
//ha EGYETLEN EGY egyezés van, akkor a {matching element}-el tér vissza
//ha több egyezés is "LENNE", akkor "sequence contains more than one matching element"-et dob
//ha egyáltalán nincs egyezés, akkor "sequence contains no matching element"-et dob

Console.WriteLine("-----------------------------");

var frstod = cats.FirstOrDefault(c => c.Breed == "robot");
Console.WriteLine($"van-e robotcica?: {(frstod is null ? "nincs" : "van, ő:" + frstod)}");
//ha VAN egyezés, akkor a rendre ELSŐ {matching element}-el tér vissza
//ha NINCS egyezés, akkor ún. 'default' értékkel tér vissza, ami
//    REFERENCE (class)  type elemeknél {null}
//    VALUE     (struct) type elemeknél <<<általában>>> 'zéró érték', vagy "kitöltetlen" struct init

//int[] numbers = [11, 26, 50, 26, 3, 132, 42];
//var res = numbers.FirstOrDefault(n => n % 2031 == 0);
//Console.WriteLine($"res:= {res}");

var lstod = cats.LastOrDefault(c => c.Sex);
Console.WriteLine($"az utolsú kisfiú: {lstod}");
//ha VAN egyezés, akkor a rendre UTOLSÓ {matching element}-el tér vissza
//ha NINCS egyezés, akkor ún. 'default' értékkel tér vissza, ami
//    REFERENCE (class)  type elemeknél {null}
//    VALUE     (struct) type elemeknél 'zéró érték', vagy "kitöltetlen" struct init

var snglod = cats.SingleOrDefault(c => c.Breed == "szfinx");
Console.WriteLine($"az egyetlen kopszi: {snglod}");
//ha EGYETLEN EGY egyezés van, akkor a {matching element}-el tér vissza
//ha több egyezés is "LENNE", akkor "sequence contains more than one matching element"-et dob
//ha NINCS egyezés, akkor ún. 'default' értékkel tér vissza, ami
//    REFERENCE (class)  type elemeknél {null}
//    VALUE     (struct) type elemeknél 'zéró érték', vagy "kitöltetlen" struct init

var any = cats.Any(c => c.Breed == "perzsa");
Console.WriteLine($"{(any ? "van" : "nincs")} perzsa macska");

// .Exists()  <-- lényegében ua.
// .Contains() (generic) 

Console.WriteLine("~~~~~~~~~~~~~~~~~~");

var whr = cats.Where(c => c.Breed == "házimacska");
Console.WriteLine("házimacskák:");
foreach (var c in whr) Console.WriteLine($"\t- {c}");

Console.WriteLine("~~~~~~~~~~~~~~~~~~");

var grpb = cats.GroupBy(c => c.Breed);

Console.WriteLine("cicák alfajok szerint:");
foreach (var group in grpb.OrderBy(g => g.Key))
{
    Console.WriteLine($"\t{group.Key} ({group.Count()} db)");
    foreach (var cat in group.OrderBy(c => c.Name))
    {
        Console.WriteLine($"\t\t{cat}");
    }
}

//"halmazoknál":
// - Union, UnionBy         -> unió
// - Except, ExceptBy       -> különbség
// - Intersect, IntersectBy -> metszet

var slct = cats
    .Select(c => c.Breed) // <= kiválaszt egy property-t
    .Distinct()           // <= szűri az ismétlődéseket
    .Order();             // <= rendezi a szűrt string kollekciót
Console.Write("minden macskafajta: ");
foreach (var breed in slct) Console.Write(breed + " ");

//az order és az orderdescending (az orderBY helyett) akkor használható,
//ha a kollekció elemei nem összetettek

//var slct2 = cats.Select(c => new { c.Name, c.Breed });
//foreach (var item in slct2)
//{
//    Console.WriteLine($"{item.Name} + {item.Breed}");
//}

var ordrby = cats
    .OrderByDescending(c => c.Breed)
    .ThenBy(c => c.Name);
Console.WriteLine("\nmacskák fajta szerint csökkenőben, azon belül név szerint növekvőben:");
foreach (var cat in ordrby) Console.WriteLine($"\t{cat}");