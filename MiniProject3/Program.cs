using MyClasses;
using System.Numerics;
using static System.Runtime.InteropServices.JavaScript.JSType;

// Create sample data
CompanyAssets companyAssets = new CompanyAssets();
companyAssets.Add(new Computer("HP", "Elitebook", "Sweden", Convert.ToDateTime("2020-10-02"), "SEK", 588));
companyAssets.Add(new Computer("Asus", "W234", "USA", Convert.ToDateTime("2017-04-21"), "USD", 1200));
companyAssets.Add(new Computer("Lenovo", "Yoga 730", "USA", Convert.ToDateTime("2018-05-28"), "USD", 835));
companyAssets.Add(new Computer("Lenovo", "Yoga 730", "USA", Convert.ToDateTime("2023-05-21"), "USD", 1030));
companyAssets.Add(new Computer("HP", "Elitebook", "Spain", Convert.ToDateTime("2019-06-01"), "EUR", 1423));
companyAssets.Add(new Phone("iPhone", "8", "Spain", Convert.ToDateTime("2018-12-29"), "EUR", 970));
companyAssets.Add(new Phone("iPhone", "11", "Spain", Convert.ToDateTime("2020-09-25"), "EUR", 990));
companyAssets.Add(new Phone("iPhone", "X", "Sweden", Convert.ToDateTime("2021-06-15"), "SEK", 1245));
companyAssets.Add(new Phone("Motorola", "Razr", "Sweden", Convert.ToDateTime("2021-02-22"), "SEK", 970));

companyAssets.ShowAllAssets();