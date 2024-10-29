
### Program (Hlavní třída)

Třída `Program` je vstupním bodem programu a obsahuje metodu `Main`, která provádí následující kroky:

1. **Nastavení kultury a kódování:** Nastavuje kulturní prostředí na české (cs-CZ) a výstupní kódování na UTF-8.
2. **Načtení dat:** Čte vstupní data o produktech ze souboru, jehož cesta je specifikována jako první argument příkazové řádky.
3. **Zpracování dat:** Používá metodu `ParseData` k převodu načtených dat do pole produktů (`Product[]`).
4. **Výpočet souhrnných hodnot:** Vypočítá celkovou cenu produktů a průměrnou váhu jedné položky.
5. **Výpis výsledků:** Vypisuje seznam produktů, celkovou cenu a průměrnou váhu.

---

### Třída Product

Třída `Product` reprezentuje jednotlivý produkt a obsahuje tyto vlastnosti:

- **Name (string):** Název produktu.
- **Price (double):** Cena za jednu jednotku produktu.
- **Quantity (int?):** Počet jednotek produktu. Hodnota může být `null`, pokud není známa.
- **ProductWeight (Weight):** Struktura reprezentující váhu produktu.

Třída `Product` také obsahuje metodu `Write`, která vrací řetězec s informacemi o produktu, tj. název, množství a cena.

#### Struktura Weight

Vnořená struktura `Weight` slouží k reprezentaci váhy produktu. Obsahuje:

- **Value (double):** Číselná hodnota váhy.
- **Unit (Unit):** Měrná jednotka váhy (g, dkg, kg).

---

### Metody:

##### `Main(string[] args)`

Hlavní metoda programu, která zpracovává data a vypisuje výsledky. Provádí analýzu produktů a výpočet souhrnných hodnot.

##### `ParseData(string data)`

Tato metoda analyzuje textová data, rozdělí je na jednotlivé řádky a každou řádku interpretuje jako vlastnost konkrétního produktu. Vrací pole produktů.

- **Parametry:** `data` (řetězec se všemi daty produktů)
- **Výstup:** Pole `Product[]` obsahující všechny načtené produkty

##### `CreateProduct(string name)`

Vytvoří instanci produktu s předem definovanými výchozími hodnotami pro cenu, množství a váhu.

- **Parametry:** `name` (název produktu)
- **Výstup:** Nový objekt `Product`

##### `ParseWeight(string weightData)`

Interpretuje textovou hodnotu váhy a jednotky a vrací strukturu `Weight`.

- **Parametry:** `weightData` (řetězec obsahující hodnotu váhy a jednotku, např. „1 kg“)
- **Výstup:** Struktura `Product.Weight`

##### `GetTotalProductsPrice(Product[] products)`

Vypočítá celkovou cenu všech produktů na základě jejich jednotkové ceny a množství.

- **Parametry:** `products` (pole produktů)
- **Výstup:** Celková cena (`double`)

##### `GetAverageItemWeight(Product[] products)`

Vypočítá průměrnou váhu jednoho produktu, přičemž konvertuje všechny váhy do jednotky kilogramů (kg) před výpočtem.

- **Parametry:** `products` (pole produktů)
- **Výstup:** Průměrná váha (`double`)

---

### Výčtový typ Unit

Výčtový typ `Unit` definuje možné jednotky váhy:

- `g` - gramy
- `dkg` - dekagramy
- `kg` - kilogramy

Jednotky se používají ve struktuře `Weight` pro označení měrné jednotky váhy produktu.

---

### Příklad vstupního souboru

Formát vstupních dat očekávaný metodou `ParseData`:
```
Produkt A
- price: 10.5
- quantity: 3
- weight: 500 g

Produkt B
- price: 15
- weight: 1 kg

```

```c#
```
## Podrobný popis funkce `ParseData`

Metoda `ParseData` je klíčová část programu, která zajišťuje čtení a rozpoznání dat o produktech. Pracuje s textovými daty a převádí je do objektů `Product`. Každý produkt obsahuje název, cenu, množství a váhu.

### Průběh parsování

1. **Rozdělení na řádky:**

	```csharp
char[] LineSeparators = new[] { '\n', '\r' }; string[] lines = data.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);`
	```
	
Program načte celý text (řetězec `data`) a rozdělí jej na řádky podle  oddělovačů `\n` a `\r`, aby získal jednotlivé řádky (v proměnné `lines`).

2. **Inicializace proměnných:**
```csharp
List<Product> products = new List<Product>(); Product? currentProduct = null;
```

`products` je seznam, do kterého se ukládají všechny instance produktů. `currentProduct`  reprezentuje produkt, který se aktuálně analyzuje a plní daty.

3. **Hlavní smyčka přes řádky:**
    
```csharp
foreach (string line in lines.Skip(1))  {     string trimmedLine = line.Trim(); }
```
    
Smyčka zpracovává každou řádku po jedné a ignoruje prázdné znaky na začátku a konci (`Trim()`).
    
4. **Zpracování vlastností produktu:** Smyčka používá několik podmínek ke kontrole, zda řádek obsahuje určitou vlastnost produktu (cenu, množství nebo váhu), nebo nový produkt. V závislosti na typu řádku provede potřebné akce:

- **Cena produktu (`- price: VALUE`)**
    
```csharp
if (trimmedLine.StartsWith("- price: ")) {     if (currentProduct != null)     {         double price;         if (double.TryParse(trimmedLine.Substring(8).Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out price))         {             currentProduct.Price = price;         }     } }
```
    
Pokud řádek začíná `- price:`, vyjme text za tímto klíčovým slovem (`trimmedLine.Substring(8).Trim()`), pokusí se jej převést na číslo (`TryParse`) a uloží cenu do vlastnosti `Price` aktuálního produktu (`currentProduct`).
    
- **Množství produktu (`- quantity: VALUE`)**
```csharp
else if (trimmedLine.StartsWith("- quantity: ")) {     if (currentProduct != null)     {         int quantity;         if (int.TryParse(trimmedLine.Substring(11).Trim(), out quantity))         {             currentProduct.Quantity = quantity;         }     } }
```
    
Pokud řádek začíná `- quantity:`, podobně jako u ceny extrahuje hodnotu za tímto klíčovým slovem a pokusí se ji převést na celé číslo. Pokud je úspěšné, uloží hodnotu do vlastnosti `Quantity`.
    
- **Váha produktu (`- weight: VALUE UNIT`)**
    
```csharp
else if (trimmedLine.StartsWith("- weight: ")) 
{     
	if (currentProduct != null)   
	{         
		var weightData = trimmedLine.Substring(9).Trim();
		currentProduct.ProductWeight = ParseWeight(weightData);     
	} 
}
```

    
Pokud řádek obsahuje `- weight:`, metoda získá řetězec `weightData` s údajem o váze a jednotce (například `500 g` nebo `1 kg`) a předá jej metodě `ParseWeight`. Tato metoda vrátí strukturu `Weight`, kterou uloží do vlastnosti `ProductWeight`.

### Nový produkt:
```csharp
else {     
	if (currentProduct != null)     
	{         
		products.Add(currentProduct);     
	}     
	currentProduct = CreateProduct(trimmedLine[2..]);  // Odebrání "- " z názvu }
```
    
    
Pokud řádek neobsahuje žádnou z výše uvedených vlastností, bere se jako název nového produktu. Aktuální produkt (`currentProduct`) se přidá do seznamu `products`, a vytvoří se nová instance produktu s názvem na daném řádku (pomocí `CreateProduct`).
    
2. **Poslední produkt:** Na konci smyčky může být `currentProduct` stále aktivní (pokud je to poslední produkt v datech), takže se po smyčce ještě jednou přidá do `products`.
    

### Výstup

Metoda `ParseData` vrací pole (`Product[]`) všech produktů, které našla a vytvořila během parsování.


# Zdrojový kód:

```csharp
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;

namespace DU1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("cs-CZ");
            Console.OutputEncoding = System.Text.Encoding.UTF8;



            string data = File.ReadAllText(args[0]);

            Product[] products = ParseData(data);
            double sum = GetTotalProductsPrice(products);
            double averageWeight = GetAverageItemWeight(products);

            Console.WriteLine("Produkty:");
            foreach (var p in products)
            {
               Console.WriteLine( p.Write());
            }
            Console.WriteLine();
            Console.WriteLine("Celková cena produktů: {0} Kč",sum);
            Console.WriteLine("Průměrná váha položky: {0} kg", Math.Round(averageWeight, 3));

        }
        public static Product[] ParseData(string data)
        {
            List<Product> products = new List<Product>();
            char[] LineSeparators = new[] { '\n', '\r' };

            string[] lines = data.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);

            Product? currentProduct = null;
            foreach (string line in lines.Skip(1)) 
            {
                string trimmedLine = line.Trim();

                if (trimmedLine.StartsWith("- price: "))
                {
                    if (currentProduct != null)
                    {
                        double price;
                        if (double.TryParse(trimmedLine.Substring(8).Trim(), NumberStyles.Float, CultureInfo.InvariantCulture, out price))
                        {
                            currentProduct.Price = price;
                        }
                    }
                }
                else if (trimmedLine.StartsWith("- quantity: "))
                {
                    if (currentProduct != null)
                    {
                        int quantity;
                        if (int.TryParse(trimmedLine.Substring(11).Trim(), out quantity))
                        {
                            currentProduct.Quantity = quantity;
                        }
                    }
                }
                else if (trimmedLine.StartsWith("- weight: "))
                {
                    if (currentProduct != null)
                    {
                        var weightData = trimmedLine.Substring(9).Trim();
                        currentProduct.ProductWeight = ParseWeight(weightData);
                    }
                }
                else
                {
                    if (currentProduct != null)
                    {
                        products.Add(currentProduct);
                    }

                    currentProduct = CreateProduct(trimmedLine[2..]);  // Odebrání "- " z názvu
                }
            }

            if (currentProduct != null)
            {
                products.Add(currentProduct);
            }

            return products.ToArray();
        }

        private static Product CreateProduct(string name)
        {
            return new Product { Name = name, Price = 0, Quantity = null, ProductWeight = new Product.Weight() };
        }

        public static Product.Weight ParseWeight(string weightData)
        {
            double value = 0;
            Unit unit = Unit.g;
            string[] parts = weightData.Split(' ');
            if (parts.Length > 0) 
            {
                if(double.TryParse(parts[0], NumberStyles.Float, CultureInfo.InvariantCulture, out value))
                {
                    if (parts[1].Equals("kg", StringComparison.OrdinalIgnoreCase))
                    {
                        unit = Unit.kg;
                    }
                    else if (parts[1].Equals("g", StringComparison.OrdinalIgnoreCase))
                    {
                        unit = Unit.g;
                    }
                    else if (parts[1].Equals("dkg", StringComparison.OrdinalIgnoreCase))
                    {
                        unit = Unit.dkg;
                    }
                }
            }
            return new Product.Weight { Value = value, Unit = unit };

        }
        public static double GetTotalProductsPrice(Product[] products)
        {
            double total = 0;
            foreach (Product p in products)
            {
                total += (p.Quantity ?? 0) * p.Price;
            }
            return total;
        }

        public static double GetAverageItemWeight(Product[] products)
        {
            double total = 0;
            foreach (Product p in products)
            {
                switch (p.ProductWeight.Unit)
                {
                    case Unit.kg:
                        total += p.ProductWeight.Value;
                        break;
                    case Unit.g:
                        total += p.ProductWeight.Value / 1000;
                        break;
                    case Unit.dkg:
                        total += p.ProductWeight.Value / 100;
                        break;
                }
            }
            return total / products.Length;
        }
    }
    public class Product
{
    public required string Name { get; set;}
    public required double Price { get; set;}
    public int? Quantity { get; set;}
    public Weight ProductWeight { get; set; }
    public struct Weight
    {
        public double Value { get; set; }
        public Unit Unit { get; set; }
    }

    public string Write()
    {
        string quantityText = string.Empty;
        if (Quantity.HasValue) {
            quantityText = Quantity.Value.ToString() + " ks";
        }
        else
        {
            quantityText = "neznámé množství";
        }

        string weightText = $"{ProductWeight.Value} {ProductWeight.Unit}";

        return string.Format("{0} {1}; {2} Kč", Name, quantityText, Price);
    }


}
  public enum Unit
  {
      g,
      dkg,
      kg
  }

    }

```