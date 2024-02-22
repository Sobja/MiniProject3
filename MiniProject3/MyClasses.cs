using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClasses
{   //creating a dictionary of exchange rates using collection-initializer syntax
    public class SimpleCurrencyConventer
    {
        private IDictionary<string, double> exchangeRates = new Dictionary<string, double>();
        public SimpleCurrencyConventer()
        {
            exchangeRates.Add("USD", 1.0000);
            exchangeRates.Add("SEK", 10.33);
            exchangeRates.Add("EUR", 0.92);
        }
    
    public double ExchangeFromUSD(double priceUSD, string currency) 
        {
            if (currency == "USD") return priceUSD;
            else return priceUSD * exchangeRates[currency];
        }
    }
    public class Asset
    {
        public string Brand {  get; set; }
        public string Model { get; set; }   
        public string Office { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string Currency { get; set;}
        public double Price { get; set; }

        public Asset(string brand, string model, string office, DateTime purchaseDate, string currency ,double price )
        {
            Brand = brand;
            Model = model;
            Office = office;
            PurchaseDate = purchaseDate;
            Currency = currency;
            Price = price;
            
        }
        public virtual string TypeOfAsset() { return "Undefined"; }
        
    }
    public class Computer : Asset
    {   
        public Computer(string brand, string model, string office, DateTime purchaseDate, string currency, double price) 
                        : base(brand, model, office, purchaseDate, currency, price)
        {
        }
              
        public override string TypeOfAsset() { return "Computer"; }
    }
    public class Phone : Asset
    {
        public Phone(string brand, string model, string office, DateTime purchaseDate, string currency, double price) 
                    : base(brand, model, office, purchaseDate, currency, price)
        {
        }

        public override string TypeOfAsset() { return "Phone"; }
    }
    class CompanyAssets : List<Asset>  // ProductList derived from class List
    {
        public void AddNewAsset() 
        {
            // Under construction
            Console.WriteLine("AddNewAsset - Not implemented");
        }
        public void ShowAllAssets() 
        {
            Console.WriteLine("Type      Brand       Model               Office      Purchase Date  Price in USD  Currency  Local price today\n" +
                              "----      -----       -----               ------      -------------  ------------  --------  -----------------"); // our handcrafted header ;)
            
            List<Asset> assets = this.OrderBy(asset => asset.TypeOfAsset()).ThenBy(asset => asset.PurchaseDate).ToList(); // Create a local List to sort assets
            var exCurrency = new SimpleCurrencyConventer();
            foreach (var item in assets)
            {   
                var assetAge = ((DateTime.Now.Month - item.PurchaseDate.Month) + 12 * (DateTime.Now.Year - item.PurchaseDate.Year)); // Asset's age in months
                if (assetAge > 33) Console.ForegroundColor = ConsoleColor.Red; // Asset purchased less than 3 months away from 3 years
                else if (assetAge > 30) Console.ForegroundColor = ConsoleColor.Yellow; // Asset purchased less than 6 months away from 3 years
                
                var sb = new StringBuilder();               // Use StringBuilder for better clarity
                sb.Append(item.TypeOfAsset().PadRight(10));
                sb.Append(item.Brand.PadRight(12));
                sb.Append(item.Model.PadRight(20));
                sb.Append(item.Office.PadRight(12));
                sb.Append(item.PurchaseDate.ToString("MM/dd/yyyy").PadRight(15));
                sb.Append(item.Price.ToString().PadRight(14));
                sb.Append(item.Currency.PadRight(10));
                sb.Append(exCurrency.ExchangeFromUSD(item.Price,item.Currency).ToString("0.##"));

                Console.WriteLine(sb.ToString());
                Console.ResetColor();
            }
        }
        public void SearchAsset() 
        {
            // Under construction
            Console.WriteLine("SearchAsset - Not implemented");
        }
    }
    


} // End of namespace My Classes