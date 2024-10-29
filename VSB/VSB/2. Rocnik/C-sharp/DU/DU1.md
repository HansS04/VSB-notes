Cílem je vytvořit konzolovou aplikaci v .NET 8, která bude načítat pole produktů ze souboru, který je součástí zadání, nad tímto polem provede výpočty definované dále v zadání a výsledek vypíše na standardní výstup (do konzole).

Vaše metoda Main bude bude začínat tímto kódem:

```csharp
Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("cs-CZ");
Console.OutputEncoding = System.Text.Encoding.UTF8;

string data = File.ReadAllText(args[0]);

Product[] products = ParseData(data);

double sum = GetTotalProductsPrice(products);
double averageWeight = GetAverageItemWeight(products);

// TODO: doplnit další kód...
```

Cesta k vstupním souboru bude předána jako parametr při spuštění aplikace (viz kód výše).

- Vytvořte třídu **Product**, která bude reprezentovat jeden produkt. Jednotlivé vlastnosti produktu jsou následující:
    - Název produktu – text
    - Cena jednoho kusu – desetinné číslo.
    - Počet kusů - celé číslo. Počet kusů nemusí být znám (pozor, neznamená, že jich je 0).
    - Váha - **struktura** obsahující jednotku (výčtový typ) a hodnotu (desetinné číslo).
- Pro reprezentaci jednotlivých vlastnosti zvolte vhodné datové typy (pro desetinné číslo použijte typ double).
- Vytvořte metodu **ParseData**, které se předá obsah souboru (text) a která bude vracet pole produktů. Uvnitř této metody implementujte vlastní parsování vstupního souboru a mapování dat na dané produkty. Parsování váhy proveďte pomocí metody z následujícího bodu zadání. Bližší popis souboru naleznete v zadání níže.
- Vytvořte metodu **ParseWeight**, které se předá text obsahující váhu a tato metoda vrátí strukturu obsahující jednotku (výčtový typ) a hodnotu váhy v dané jednotce.
- Vytvořte metodu **GetTotalProductsPrice** pro výpočet celkové ceny všech produktů. Dejte pozor na situaci, kdy není tento počet znám. V tom případě daný produkt nezapočítávejte. Metoda bude přijímat pole produktů a vracet číslo.
- Vytvořte metodu **GetAverageItemWeight** pro výpočet průměrné hmotnosti jednoho kusu produktu **v kilogramech**. Metoda příjme pole produktů a vrátí průměrnou hmotnost zaokrouhlenou na 3 desetinná místa. Pro převod hmotnosti na kilogramy doplňte do struktury reprezentující váhu metodu **GetNormalizedValue** vracející váhu v kilogramech.
- Vypište do konzole seznam všech produktů, celkovou cenu a průměrnou váhu (viz ukázkový výstup níže).

## Pro vypracování se vám mohou hodit tyto metody:

- IndexOf - [https://learn.microsoft.com/cs-cz/dotnet/api/system.string.indexof?view=net-8.0](https://learn.microsoft.com/cs-cz/dotnet/api/system.string.indexof?view=net-8.0)
- Substring - [https://learn.microsoft.com/cs-cz/dotnet/api/system.string.substring?view=net-8.0](https://learn.microsoft.com/cs-cz/dotnet/api/system.string.substring?view=net-8.0)
- IsNullOrEmpty - [https://learn.microsoft.com/cs-cz/dotnet/api/system.string.isnullorempty?view=net-8.0](https://learn.microsoft.com/cs-cz/dotnet/api/system.string.isnullorempty?view=net-8.0)
- Split - [https://learn.microsoft.com/cs-cz/dotnet/api/system.string.split?view=net-8.0](https://learn.microsoft.com/cs-cz/dotnet/api/system.string.split?view=net-8.0)
- StartsWith - [https://learn.microsoft.com/cs-cz/dotnet/api/system.string.startswith?view=net-8.0](https://learn.microsoft.com/cs-cz/dotnet/api/system.string.startswith?view=net-8.0)
- TryParse - [https://learn.microsoft.com/cs-cz/dotnet/api/system.int64.tryparse?view=net-8.0](https://learn.microsoft.com/cs-cz/dotnet/api/system.int64.tryparse?view=net-8.0)
- Trim - [https://learn.microsoft.com/cs-cz/dotnet/api/system.string.trim?view=net-8.0](https://learn.microsoft.com/cs-cz/dotnet/api/system.string.trim?view=net-8.0)

## Testovací soubor

Pro otestování vaší implementace můžete použít tento soubor: [data.txt](https://kelvin.cs.vsb.cz/task/CSI/2024W/JAW254/DU1/asset/data.txt)

Soubor ideálně stáhněte přes pravé tlačítko myši a "Uložit soubor jako..." (pokud budete jen kopírovat text tak hrozí že poškodíte jeho strukturu).

Při čtení souboru si uvědomte, že existuje více možných oddělovačů řádků ([CRLF](https://developer.mozilla.org/en-US/docs/Glossary/CRLF)).

Soubor může také končit prázdným řádkem.

Soubor bude vždy začínat řádkem "products:". Následovat budou jednotlivé produkty. Název produktu je vždy odsazen 1 tabem následovaným pomlčkou. Za názvem produktu je dvojtečka. Vlastnosti produktu jsou vždy odsazeny 2 taby následovanými mezerou a pomlčkou. Tyto vlastnosti mohou být v libovolném pořadí!

Vlastnost "quantity" nemusí být vždy uvedena (v tom případě není znám počet kusů).

Vlastnost "weight" obsahuje váhu **jednoho** kusu. Tato váha může být v gramech, dekagramech, nebo kilogramech.
# Kompletní řešení : [[DU1 - Reseni]]
