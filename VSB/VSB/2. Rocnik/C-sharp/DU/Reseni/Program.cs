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

    }
